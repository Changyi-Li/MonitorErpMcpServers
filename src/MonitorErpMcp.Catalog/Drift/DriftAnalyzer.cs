using MonitorErpMcp.Catalog.Content;
using MonitorErpMcp.Catalog.Model;

namespace MonitorErpMcp.Catalog.Drift
{
    /// <summary>
    /// Compares the authored content baseline against the structural catalog of the current assembly
    /// and categorizes the drift: needs-content (records without content; important fields without
    /// descriptions), orphaned (content keys whose record/field no longer exists), and possible
    /// renames (an orphaned entry whose described fields match a new record's full field set — the
    /// author remaps the key instead of re-authoring). Pure and testable at seam A over any record
    /// set, so a fixture assembly bump exercises it without touching the real assembly.
    /// </summary>
    public static class DriftAnalyzer
    {
        /// <summary>
        /// Categorizes the drift between <paramref name="records"/> (the current structural catalog)
        /// and <paramref name="contentByClrType"/> (the authored baseline).
        /// </summary>
        public static DriftReport Analyze(
            IReadOnlyList<CatalogRecord> records,
            IReadOnlyDictionary<string, ContentEntry> contentByClrType)
        {
            ArgumentNullException.ThrowIfNull(records);
            ArgumentNullException.ThrowIfNull(contentByClrType);

            var recordByClrType = records.ToDictionary(r => r.ClrType, StringComparer.OrdinalIgnoreCase);

            var needsContentRecords = new List<NeedsContentRecord>();
            var needsContentFields = new List<NeedsContentField>();
            foreach (var record in records)
            {
                var importantFields = record.Fields.Where(IsImportant).ToList();
                if (!contentByClrType.TryGetValue(record.ClrType, out var entry))
                {
                    // No content at all: a searchable query/command needs T1 identity; a dto needs
                    // content only when it carries important request-input fields worth describing.
                    if (record.Type != RecordType.Dto || importantFields.Count > 0)
                    {
                        needsContentRecords.Add(new NeedsContentRecord(
                            record.ClrType, record.Type, importantFields));
                    }

                    continue;
                }

                // Authored record: an important field the content does not describe yet is new content.
                needsContentFields.AddRange(
                    importantFields
                        .Where(f => !entry.FieldDescriptions.ContainsKey(f.Name))
                        .Select(f => new NeedsContentField(record.ClrType, f.Name)));
            }

            var orphanedRecords = new List<OrphanedRecord>();
            var orphanedFields = new List<OrphanedField>();
            foreach (var (clrType, entry) in contentByClrType)
            {
                if (!recordByClrType.TryGetValue(clrType, out var record))
                {
                    orphanedRecords.Add(new OrphanedRecord(clrType));
                    continue;
                }

                var fieldNames = record.Fields.Select(f => f.Name).ToHashSet(StringComparer.Ordinal);
                orphanedFields.AddRange(
                    entry.FieldDescriptions.Keys
                        .Where(fieldName => !fieldNames.Contains(fieldName))
                        .Select(fieldName => new OrphanedField(clrType, fieldName)));
            }

            var possibleRenames = PossibleRenames(orphanedRecords, contentByClrType, records);

            return new DriftReport(
                needsContentRecords,
                needsContentFields,
                orphanedRecords,
                orphanedFields,
                possibleRenames);
        }

        /// <summary>
        /// An orphaned content entry is a likely rename when the fields it describes all still exist
        /// on a new record and cover that record's important fields — the author remaps the key rather
        /// than re-authoring. Comparing against the important set (the T2 coverage tier) rather than
        /// the full field list keeps the heuristic useful for records whose content described only
        /// important fields. Best-effort: a rename of a record with no field descriptions is invisible
        /// to content alone, so it is not reported.
        /// </summary>
        private static List<PossibleRename> PossibleRenames(
            IEnumerable<OrphanedRecord> orphanedRecords,
            IReadOnlyDictionary<string, ContentEntry> contentByClrType,
            IReadOnlyList<CatalogRecord> records)
        {
            var renames = new List<PossibleRename>();
            foreach (var orphanClrType in orphanedRecords.Select(o => o.ClrType))
            {
                var described = contentByClrType[orphanClrType].FieldDescriptions.Keys
                    .ToHashSet(StringComparer.Ordinal);
                if (described.Count == 0)
                {
                    continue;
                }

                foreach (var record in records)
                {
                    var fieldNames = record.Fields.Select(f => f.Name).ToHashSet(StringComparer.Ordinal);
                    var important = record.Fields.Where(IsImportant).Select(f => f.Name).ToHashSet(StringComparer.Ordinal);
                    if (important.Count > 0
                        && described.IsSubsetOf(fieldNames)
                        && important.IsSubsetOf(described))
                    {
                        renames.Add(new PossibleRename(orphanClrType, record.ClrType));
                        break;
                    }
                }
            }

            return renames;
        }

        /// <summary>
        /// A field worth authoring content for (the T2 coverage set): request-input semantics
        /// (mandatory/mandatoryWhen) and the classified kinds that need explaining (enum, reference,
        /// expandable, input wrapper, nested command), plus uniqueness. Self-evident raw fields are
        /// deliberately excluded, so an all-self-evident dto (e.g. a template of copy flags) is not
        /// flagged.
        /// </summary>
        public static bool IsImportant(FieldRecord field) =>
            field.Mandatory
            || field.MandatoryWhen is not null
            || field.Unique
            || field.Kind is FieldKind.Enum or FieldKind.Reference or FieldKind.Expandable
                or FieldKind.InputWrapper or FieldKind.NestedCommand;
    }
}
