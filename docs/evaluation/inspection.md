# Evaluation: pinned 10-pair

Proves that an LLM given **only** the three `monitor_api_*` tools can answer realistic, complex
questions about the pinned Monitor ERP API surface. The artifact is `evaluation.xml` (10
question/answer pairs); this document records the methodology: how the pairs were designed, how every
answer was verified by reflection against the pinned assembly, and how to run the evaluation against
the real server over stdio through the mcp-builder harness.

## Scope

- **Server:** the catalog MCP server (`src/MonitorErpMcp.Server`), pinned to `MonitorG5.Api`
  26.3.11.2189 (the `Monitor.API.dll` assembly, 1,717 types, 1,157 catalog records).
- **Tools under test:** `monitor_api_search` (keyword, `type`/`module` filters, paging),
  `monitor_api_get_record` (`clrType`/`path`, nested `expand`), `monitor_api_list_modules`.
- **Format:** the `mcp-builder` evaluation schema (`<evaluation><qa_pair><question>/<answer>`).
- **Pinned answers:** every answer is fixed for the pinned assembly version, so the evaluation is
  stable and rerunnable.

## Question design

The ten pairs follow the mcp-builder evaluation guide (`reference/evaluation.md`): read-only,
independent, non-destructive, with a single verifiable value per answer. They are realistic tasks a
human or agent would actually do with the Monitor ERP API, and are deliberately not solvable by a
single exact-match keyword search. Together they exercise the whole tool surface:

| # | What it stresses | Tool path | Answer |
|---|------------------|-----------|--------|
| 1 | Field-constraint synthesis (`unique`, `maxLength`) | search → get_record → scan fields | `PartNumber` |
| 2 | Nested DTO expansion + `mandatoryWhen` | search → get_record(expand=full) → drill `Rows`→`Locations`→`ArrivalLocation` | `If reporting to a new location.` |
| 3 | Command discrimination (`multipartForm`) | search → get_record both hits → compare | `UploadFileStream` |
| 4 | Enum values | get_record → `PackagingType` enum | `2` (EurPallets) |
| 5 | Derived edges (`relatedCommands`) | get_record → count | `63` |
| 6 | Aggregation across modules | list_modules → compare command counts | `Sales` (180) |
| 7 | Chinese alias / token matching | search `物料` → top hit | `Parts` |
| 8 | `availableSince` versioning | search → get_record → version | `2.29` |
| 9 | DTO cross-reference (`usedBy`) | get_record `ArrivalLocation` → usedBy → get_record | `ReceivingInspectionRow` |
| 10 | Boolean `batchable` | search → get_record | `True` |

The answers span diverse modalities (field name, condition text, display name, integer, count,
module name, version string, boolean) so string-comparison verification is unambiguous.

## Answer verification

Every answer was verified **by reflection against the pinned assembly**, in two independent ways:

1. **Live run against the real server over stdio.** A scripted MCP client (`StdioClientTransport` +
   `McpClient` from the .NET SDK) spawned the actual `MonitorErpMcp.Server.exe` and drove the three
   tools through the exact call sequences an LLM would take (search → get_record with `expand=full`,
   list_modules, enum/usedBy drills). All ten answers were confirmed against the returned records.
2. **Locked in the test suite.** `tests/MonitorErpMcp.Tests/EvaluationAnswersTests.cs` encodes the
   ten answers and asserts each against `CatalogService` (which reflects over the pinned assembly),
   so a catalog drift that changes any answer fails the suite — the "all pass" claim stays
   reproducible.

Answers deliberately avoid dynamic state (counts of live entities, current dates, etc.); they derive
only from the versioned assembly and the merged content layer.

## Running the evaluation (mcp-builder harness)

The mcp-builder harness (`evaluation.py`) drives the real server over **stdio**: it spawns the server
process itself, connects over JSON-RPC, and for each pair asks a Claude model to answer using only the
tools, then scores by direct string comparison.

**Prerequisites**

- Python 3 with `pip install -r .agents/skills/mcp-builder/scripts/requirements.txt`
  (`anthropic`, `mcp`).
- An `ANTHROPIC_API_KEY`.
- A build of the server (the harness launches the exe, so run `dotnet build` first and point `-c` at
  the produced `MonitorErpMcp.Server.exe`).

**Command**

```bash
python .agents/skills/mcp-builder/scripts/evaluation.py \
  -t stdio \
  -c "src/MonitorErpMcp.Server/bin/Debug/net10.0/MonitorErpMcp.Server.exe" \
  -o docs/evaluation/report.md \
  docs/evaluation/evaluation.xml
```

Notes:

- stdio is the server's default transport, so no `-a`/`--args` argument is required; the harness owns
  the process lifecycle (do not run the server manually). `-t` selects the transport (`stdio`), `-c`
  the command to spawn, `-o` the report path.
- The harness run is a **manual step**: it drives a Claude model and needs `ANTHROPIC_API_KEY`, so it
  is not executed in this repo's test suite or CI. The ten answers are independently locked by
  `EvaluationAnswersTests.cs` (reflection over the pinned assembly) and were confirmed over stdio, so
  the suite is the durable "all pass" gate; the harness is the end-to-end model-behavior check.
- The report (`-o`) records per-task summaries, the model's tool feedback, duration, and tool-call
  counts; overall accuracy is correct/total.
- If accuracy drops, read the per-task feedback first — the usual cause is a tool description or
  return shape that does not lead the model to the right record, which is a server-contract issue to
  fix in `Tools/MonitorApiTools.cs`, not a question issue.
