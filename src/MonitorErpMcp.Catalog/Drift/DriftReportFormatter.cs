using System.Text;

namespace MonitorErpMcp.Catalog.Drift
{
    /// <summary>Formats a <see cref="DriftReport"/> into the human-readable drift report text.</summary>
    public static class DriftReportFormatter
    {
        /// <summary>Produces the report text, categorizing needs-content / orphaned / possible renames.</summary>
        public static string Format(
            DriftReport report,
            string assemblyVersion,
            int authoredIdentityCount,
            int recordCount)
        {
            ArgumentNullException.ThrowIfNull(report);

            var sb = new StringBuilder();
            sb.AppendLine($"Drift report for MonitorG5.Api {assemblyVersion}");
            sb.AppendLine($"content coverage: {authoredIdentityCount}/{recordCount} records with authored identity");
            sb.AppendLine();

            sb.AppendLine($"needs-content records ({report.NeedsContentRecords.Count}):");
            foreach (var item in report.NeedsContentRecords.OrderBy(r => r.ClrType, StringComparer.Ordinal))
            {
                sb.AppendLine($"  [{item.Type.ToString().ToLowerInvariant()}] {item.ClrType}");
                if (item.ImportantFields.Count > 0)
                {
                    var fields = string.Join(", ", item.ImportantFields.Select(f => f.Name).OrderBy(x => x, StringComparer.Ordinal));
                    sb.AppendLine($"    important fields: {fields}");
                }
            }

            sb.AppendLine();
            sb.AppendLine($"needs-content fields ({report.NeedsContentFields.Count}):");
            foreach (var item in report.NeedsContentFields.OrderBy(f => f.ClrType, StringComparer.Ordinal).ThenBy(f => f.Field, StringComparer.Ordinal))
            {
                sb.AppendLine($"  {item.ClrType}: {item.Field}");
            }

            sb.AppendLine();
            sb.AppendLine($"orphaned records ({report.OrphanedRecords.Count}):");
            foreach (var item in report.OrphanedRecords.OrderBy(r => r.ClrType, StringComparer.Ordinal))
            {
                sb.AppendLine($"  {item.ClrType}");
            }

            sb.AppendLine();
            sb.AppendLine($"orphaned fields ({report.OrphanedFields.Count}):");
            foreach (var item in report.OrphanedFields.OrderBy(f => f.ClrType, StringComparer.Ordinal).ThenBy(f => f.Field, StringComparer.Ordinal))
            {
                sb.AppendLine($"  {item.ClrType}: {item.Field}");
            }

            sb.AppendLine();
            sb.AppendLine($"possible renames ({report.PossibleRenames.Count}):");
            foreach (var item in report.PossibleRenames.OrderBy(r => r.OldClrType, StringComparer.Ordinal))
            {
                sb.AppendLine($"  {item.OldClrType} -> {item.NewClrType}");
            }

            return sb.ToString();
        }
    }
}
