using Monitor.API.Infrastructure;
using MonitorErpMcp.Catalog.Content;
using MonitorErpMcp.Catalog.Drift;
using MonitorErpMcp.Catalog.Extraction;

// Dev-time drift pipeline: reflects over the pinned MonitorG5.Api assembly (the same CatalogMapper
// the server uses), compares the structural catalog against the authored content baseline, and emits
// the drift report plus Content/Pending.cs stubs. The authored per-module content files are never
// written here, so a generation run leaves them byte-identical. Drift is not a CI gate — it is the
// triage queue for the next authoring pass.
var reportPath = args.Length > 0 ? args[0] : Path.Combine("docs", "drift-report.txt");
var pendingPath = args.Length > 1 ? args[1] : Path.Combine("src", "MonitorErpMcp.Catalog", "Content", "Pending.cs");

var assembly = typeof(ApiEntityAttribute).Assembly;
var records = CatalogMapper.MapAssembly(assembly);
var report = DriftAnalyzer.Analyze(records, CatalogContent.ByClrType);
var version = assembly.GetName().Version?.ToString() ?? "unknown";

// Run the merger too (as the server does) so the report can state the content-coverage baseline:
// how many records carry an authored identity after content lands.
var merged = ContentMerger.Apply(records, CatalogContent.ByClrType);
var authoredIdentity = merged.Count(r => r.Description.En.Length > 0 || r.Description.Zh.Length > 0);

var reportText = DriftReportFormatter.Format(report, version, authoredIdentity, merged.Count);
var pendingText = PendingContentGenerator.Generate(report);

await DriftEmitter.WriteAsync(reportText, pendingText, reportPath, pendingPath);

Console.WriteLine(reportText);
Console.WriteLine($"Pending stubs written to {pendingPath}");
