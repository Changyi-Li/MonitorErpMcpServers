using System.Text;

namespace MonitorErpMcp.Catalog.Drift
{
    /// <summary>
    /// Emits the <c>Content/Pending.cs</c> scaffold: one stub per needs-content record, with the
    /// correct <c>clrType</c> key and its important-field keys, all text empty. The file compiles
    /// (it uses the same <c>Content(...)</c>/<c>F(...)</c> builders) but is never a content source —
    /// authors copy entries into the per-module files and fill in the bilingual text.
    /// </summary>
    public static class PendingContentGenerator
    {
        /// <summary>Produces the full Pending.cs source for the given report's needs-content records.</summary>
        public static string Generate(DriftReport report)
        {
            ArgumentNullException.ThrowIfNull(report);

            var sb = new StringBuilder();
            sb.AppendLine("namespace MonitorErpMcp.Catalog.Content");
            sb.AppendLine("{");
            sb.AppendLine("    // The using-static sits inside the namespace so the imported Content(...) builder binds before");
            sb.AppendLine("    // the enclosing MonitorErpMcp.Catalog.Content namespace in simple-name lookup.");
            sb.AppendLine("    using static MonitorErpMcp.Catalog.Content.ContentEntryFactory;");
            sb.AppendLine();
            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// Generated stub entries for records that currently have no authored content, produced by");
            sb.AppendLine("    /// the drift generator. This file is regenerated on every assembly bump and is a triage");
            sb.AppendLine("    /// scaffold, never a content source — copy each entry into its per-module");
            sb.AppendLine("    /// Content/&lt;Module&gt;/{Queries,Commands,Dtos}.cs file and fill in the en/zh text.");
            sb.AppendLine("    /// </summary>");
            sb.AppendLine("    public static class Pending");
            sb.AppendLine("    {");
            sb.AppendLine("        /// <summary>Stub entries keyed by clrType, with empty text and important-field keys.</summary>");
            sb.AppendLine("        public static readonly ContentEntry[] Entries =");
            sb.AppendLine("        [");

            foreach (var record in report.NeedsContentRecords.OrderBy(r => r.ClrType, StringComparer.Ordinal))
            {
                AppendEntry(sb, record);
            }

            sb.AppendLine("        ];");
            sb.AppendLine("    }");
            sb.AppendLine("}");
            return sb.ToString();
        }

        private static void AppendEntry(StringBuilder sb, NeedsContentRecord record)
        {
            sb.AppendLine("            Content(");
            sb.AppendLine($"                \"{record.ClrType}\",");
            sb.AppendLine("                \"\", // description en");

            if (record.ImportantFields.Count > 0)
            {
                sb.AppendLine("                \"\", // description zh");
                sb.AppendLine("                fields: [");
                foreach (var field in record.ImportantFields.OrderBy(f => f.Name, StringComparer.Ordinal))
                {
                    sb.AppendLine($"                    F(\"{field.Name}\", \"\", \"\"),");
                }

                sb.AppendLine("                ]),");
            }
            else
            {
                // No fields: the zh argument is the last one, so no trailing comma.
                sb.AppendLine("                \"\"), // description zh");
            }
        }
    }
}
