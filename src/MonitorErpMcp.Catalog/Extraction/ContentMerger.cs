using MonitorErpMcp.Catalog.Content;
using MonitorErpMcp.Catalog.Model;

namespace MonitorErpMcp.Catalog.Extraction
{
    /// <summary>
    /// Merges hand-authored content onto the structural catalog by <c>clrType</c> key: record
    /// descriptions and aliases for searchable records, field descriptions for every family, and
    /// examples (authored, plus a derived <c>many</c> example on every batchable command). Authored
    /// content is applied onto immutable <c>with</c> copies, so the base mapper output is never
    /// mutated and content survives assembly regeneration (structure re-derives, content merges).
    /// </summary>
    public static class ContentMerger
    {
        /// <summary>
        /// Returns the structural records with content applied, keyed by <see cref="ContentEntry.ClrType"/>.
        /// Records without an entry keep their structural identity, but a batchable command still
        /// gains a derived <c>many</c> example.
        /// </summary>
        /// <remarks>
        /// dto records carry field descriptions only — never a record description, aliases, or
        /// examples — because they are reached via their parents and are not directly searchable.
        /// </remarks>
        public static IReadOnlyList<CatalogRecord> Apply(
            IReadOnlyList<CatalogRecord> records,
            IReadOnlyDictionary<string, ContentEntry> contentByClrType)
        {
            ArgumentNullException.ThrowIfNull(records);
            ArgumentNullException.ThrowIfNull(contentByClrType);
            return records.Select(r => Merge(r, contentByClrType)).ToList();
        }

        private static CatalogRecord Merge(CatalogRecord record, IReadOnlyDictionary<string, ContentEntry> contentByClrType)
        {
            contentByClrType.TryGetValue(record.ClrType, out var entry);

            var fields = entry is null
                ? record.Fields
                : record.Fields
                    .Select(f => entry.FieldDescriptions.TryGetValue(f.Name, out var text)
                        ? f with { Description = Merge(text, f.Description) }
                        : f)
                    .ToList();

            // Examples apply even to records with no content entry: every batchable command carries
            // a derived many example unless the author authored one.
            var examples = ApplyExamples(record, entry);

            if (record.Type == RecordType.Dto)
            {
                return record with { Fields = fields, Examples = examples };
            }

            if (entry is null)
            {
                return record with { Examples = examples };
            }

            return record with
            {
                Fields = fields,
                Description = entry.Description is null ? record.Description : Merge(entry.Description, record.Description),
                Aliases = entry.Aliases is null
                    ? record.Aliases
                    : new SearchAliases { En = entry.Aliases.En, Zh = entry.Aliases.Zh },
                Examples = examples,
            };
        }

        /// <summary>Applies only non-empty authored text; the structural value otherwise stays untouched.</summary>
        private static BilingualText Merge(BilingualText authored, BilingualText structural) => new()
        {
            En = string.IsNullOrEmpty(authored.En) ? structural.En : authored.En,
            Zh = string.IsNullOrEmpty(authored.Zh) ? structural.Zh : authored.Zh,
        };

        /// <summary>
        /// The examples a record carries: its authored examples (queries/commands), plus a derived
        /// <see cref="ExampleKind.Many"/> example on every batchable command that has none. When a
        /// curated command example exists, its request seeds the derived many's element 1. dto
        /// records carry no examples — they are reached via their parents.
        /// </summary>
        private static IReadOnlyList<CatalogExample> ApplyExamples(CatalogRecord record, ContentEntry? entry)
        {
            if (record.Type == RecordType.Dto)
            {
                return [];
            }

            var examples = entry?.Examples.ToList() ?? [];
            if (record.Type == RecordType.Command && record.Batchable && !examples.Any(e => e.Kind == ExampleKind.Many))
            {
                var curatedRequest = examples.FirstOrDefault(e => e.Kind == ExampleKind.Command)?.Request;
                examples.Add(ManyExampleScaffolder.Derive(record, curatedRequest));
            }

            return examples;
        }
    }
}
