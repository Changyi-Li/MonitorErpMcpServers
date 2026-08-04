using Monitor.API.Infrastructure;
using MonitorErpMcp.Catalog.Content;
using MonitorErpMcp.Catalog.Drift;
using MonitorErpMcp.Catalog.Extraction;
using MonitorErpMcp.Catalog.Model;

namespace MonitorErpMcp.Tests
{
    /// <summary>
    /// Seam A: the drift pipeline — needs-content / orphaned / possible-renames over a fixture
    /// assembly bump, the Pending.cs stub keys, and the guarantee that a generation run never rewrites
    /// the authored per-module content files.
    /// </summary>
    public class DriftTests
    {
        // ---- Fixture: a small pre-bump catalog plus its authored content -----------------

        private static readonly string OldA = "Fixture.A";
        private static readonly string OldB = "Fixture.B";
        private static readonly string OldC = "Fixture.C";
        private static readonly string OldD = "Fixture.D";
        private static readonly string RenamedB = "Fixture.RenamedB";
        private static readonly string NewE = "Fixture.E";
        private static readonly string NewF = "Fixture.F";

        /// <summary>The pre-bump catalog: A, B, C, D, with A/B partially covered by authored field content.</summary>
        private static IReadOnlyList<CatalogRecord> OldCatalog() =>
        [
            Record(OldA, "A", Field("Id", mandatory: true), Field("Name"), Field("ObsoleteField", unique: true)),
            Record(OldB, "B", Field("BId", mandatory: true), Field("BName")),
            Record(OldC, "C", Field("CId")),
            Record(OldD, "D", Field("DId")),
        ];

        /// <summary>The authored content baseline for the pre-bump catalog.</summary>
        private static IReadOnlyDictionary<string, ContentEntry> AuthoredContent() =>
            new Dictionary<string, ContentEntry>(StringComparer.OrdinalIgnoreCase)
            {
                [OldA] = ContentEntryFactory.Content(OldA, "A desc", "A 描述",
                    fields: [ContentEntryFactory.F("Id", "", ""), ContentEntryFactory.F("ObsoleteField", "", "")]),
                [OldB] = ContentEntryFactory.Content(OldB, "B desc", "B 描述",
                    fields: [ContentEntryFactory.F("BId", "", ""), ContentEntryFactory.F("BName", "", "")]),
                [OldC] = ContentEntryFactory.Content(OldC, "C desc", "C 描述"),
                [OldD] = ContentEntryFactory.Content(OldD, "D desc", "D 描述"),
            };

        /// <summary>
        /// The post-bump catalog: A gains a mandatory field, B is renamed, C is removed, E is added,
        /// and F is added with only self-evident (raw, non-mandatory) fields.
        /// </summary>
        private static IReadOnlyList<CatalogRecord> BumpedCatalog() =>
        [
            Record(OldA, "A", Field("Id", mandatory: true), Field("Name"), Field("NewField", mandatory: true)),
            Record(RenamedB, "B", Field("BId", mandatory: true), Field("BName")),
            Record(OldD, "D", Field("DId")),
            Record(NewE, "E", Field("EId", mandatory: true), Field("EName")),
            Record(NewF, "F", Field("FName")),
        ];

        private static CatalogRecord Record(string clrType, string name, params FieldRecord[] fields) => new()
        {
            Type = RecordType.Query,
            Module = "Fixture",
            ClrType = clrType,
            Name = name,
            Route = $"api/v1/Fixture/{name}",
            Method = "GET",
            Fields = fields,
            Description = new BilingualText(),
        };

        private static FieldRecord Field(string name, FieldKind kind = FieldKind.Raw, bool mandatory = false, bool unique = false) => new()
        {
            Name = name,
            ClrType = "System.String",
            JsonType = "string",
            Kind = kind,
            Mandatory = mandatory,
            Unique = unique,
            Description = new BilingualText(),
        };

        // ---- Drift analysis -------------------------------------------------------------

        [Fact]
        public void FixtureBump_FlagsNeedsContent()
        {
            var report = DriftAnalyzer.Analyze(BumpedCatalog(), AuthoredContent());

            // The added record and the renamed record's new clrType both lack content.
            Assert.Contains(report.NeedsContentRecords, r => r.ClrType == NewE);
            Assert.Contains(report.NeedsContentRecords, r => r.ClrType == RenamedB);
            Assert.DoesNotContain(report.NeedsContentRecords, r => r.ClrType == OldA);

            // The new record's stub keys are its important (mandatory) fields only.
            var added = Assert.Single(report.NeedsContentRecords, r => r.ClrType == NewE);
            Assert.Equal(["EId"], added.ImportantFields.Select(f => f.Name));

            // A record with only self-evident fields is still flagged for content, but carries no field keys.
            var selfEvident = Assert.Single(report.NeedsContentRecords, r => r.ClrType == NewF);
            Assert.Empty(selfEvident.ImportantFields);

            // A mandatory field added to an authored record is needs-content.
            Assert.Contains(report.NeedsContentFields, f => f == new NeedsContentField(OldA, "NewField"));
        }

        [Fact]
        public void FixtureBump_FlagsOrphaned()
        {
            var report = DriftAnalyzer.Analyze(BumpedCatalog(), AuthoredContent());

            // Removed record and renamed-away old clrType are orphaned content.
            Assert.Contains(report.OrphanedRecords, o => o.ClrType == OldC);
            Assert.Contains(report.OrphanedRecords, o => o.ClrType == OldB);

            // An authored field description whose field is gone from a kept record is orphaned.
            Assert.Contains(report.OrphanedFields, f => f == new OrphanedField(OldA, "ObsoleteField"));
        }

        [Fact]
        public void FixtureBump_FlagsPossibleRename()
        {
            var report = DriftAnalyzer.Analyze(BumpedCatalog(), AuthoredContent());

            // B's described fields equal the renamed record's full field set -> one-time remap.
            var rename = Assert.Single(report.PossibleRenames);
            Assert.Equal((OldB, RenamedB), (rename.OldClrType, rename.NewClrType));
        }

        [Fact]
        public void CleanCatalog_ProducesEmptyReport()
        {
            // Same catalog on both sides: no drift at all.
            var report = DriftAnalyzer.Analyze(OldCatalog(), AuthoredContent());

            Assert.Empty(report.NeedsContentRecords);
            Assert.Empty(report.NeedsContentFields);
            Assert.Empty(report.OrphanedRecords);
            Assert.Empty(report.OrphanedFields);
            Assert.Empty(report.PossibleRenames);
        }

        // ---- Pending.cs stubs -----------------------------------------------------------

        [Fact]
        public void PendingGenerator_EmitsStubKeysForNewRecords()
        {
            var report = DriftAnalyzer.Analyze(BumpedCatalog(), AuthoredContent());
            var pending = PendingContentGenerator.Generate(report);

            // Correct clrType keys and important-field keys, all text empty.
            Assert.Contains($"\"{NewE}\"", pending);
            Assert.Contains("F(\"EId\", \"\", \"\")", pending);
            Assert.Contains($"\"{RenamedB}\"", pending);
            Assert.Contains("F(\"BId\", \"\", \"\")", pending);

            // Non-important fields get no stub key.
            Assert.DoesNotContain("F(\"EName\"", pending);

            // A record with no important fields gets a valid no-fields stub: the zh argument is the
            // last one, so the generated line is `"")` — never a trailing comma.
            Assert.Contains($"\"{NewF}\"", pending);
            Assert.Contains("\"\"), // description zh", pending);
        }

        // ---- Authored files are never rewritten ------------------------------------------

        [Fact]
        public async Task GenerationRun_WritesOnlyReportAndPending_LeavesAuthoredFilesByteIdentical()
        {
            var authoredFiles = AuthoredContentFiles();
            var before = new Dictionary<string, byte[]>(StringComparer.Ordinal);
            foreach (var path in authoredFiles)
            {
                before[path] = await File.ReadAllBytesAsync(path, TestContext.Current.CancellationToken);
            }

            var temp = Path.Combine(Path.GetTempPath(), "monitor-erp-drift-" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(temp);
            try
            {
                var reportPath = Path.Combine(temp, "drift-report.txt");
                var pendingPath = Path.Combine(temp, "Pending.cs");

                var records = CatalogMapper.MapAssembly(typeof(ApiEntityAttribute).Assembly);
                var report = DriftAnalyzer.Analyze(records, CatalogContent.ByClrType);
                var merged = ContentMerger.Apply(records, CatalogContent.ByClrType);
                var authored = merged.Count(r => r.Description.En.Length > 0 || r.Description.Zh.Length > 0);
                await DriftEmitter.WriteAsync(
                    DriftReportFormatter.Format(report, "26.3.11.2189", authored, merged.Count),
                    PendingContentGenerator.Generate(report),
                    reportPath,
                    pendingPath);

                // Only the two designated outputs were produced.
                var expected = new[] { Path.GetFullPath(reportPath), Path.GetFullPath(pendingPath) }
                    .OrderBy(x => x, StringComparer.Ordinal)
                    .ToArray();
                var produced = Directory.GetFiles(temp, "*", SearchOption.AllDirectories)
                    .Select(Path.GetFullPath)
                    .OrderBy(x => x, StringComparer.Ordinal)
                    .ToArray();
                Assert.Equal(expected, produced);

                // The authored per-module content files are byte-identical after the run.
                foreach (var path in authoredFiles)
                {
                    Assert.Equal(before[path], await File.ReadAllBytesAsync(path, TestContext.Current.CancellationToken));
                }
            }
            finally
            {
                Directory.Delete(temp, recursive: true);
            }
        }

        /// <summary>The hand-authored per-module content files under Content/&lt;Module&gt;/ (not the top-level infra or Pending.cs).</summary>
        private static List<string> AuthoredContentFiles()
        {
            var contentRoot = Path.Combine(RepoRoot(), "src", "MonitorErpMcp.Catalog", "Content");
            return Directory.GetFiles(contentRoot, "*.cs", SearchOption.AllDirectories)
                .Where(p => !Path.GetFileName(p).Equals("Pending.cs", StringComparison.OrdinalIgnoreCase))
                .Where(p => !string.Equals(Path.GetDirectoryName(p), contentRoot, StringComparison.OrdinalIgnoreCase))
                .OrderBy(p => p, StringComparer.Ordinal)
                .ToList();
        }

        private static string RepoRoot()
        {
            var dir = new DirectoryInfo(AppContext.BaseDirectory);
            while (dir is not null && !File.Exists(Path.Combine(dir.FullName, "MonitorErpMcpServers.slnx")))
            {
                dir = dir.Parent;
            }

            return dir?.FullName ?? throw new InvalidOperationException("Repo root not found from " + AppContext.BaseDirectory);
        }
    }
}
