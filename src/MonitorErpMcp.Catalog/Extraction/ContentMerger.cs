using MonitorErpMcp.Catalog.Content;
using MonitorErpMcp.Catalog.Model;

namespace MonitorErpMcp.Catalog.Extraction
{
    /// <summary>
    /// Merges hand-authored content onto the structural catalog by <c>clrType</c> key: record
    /// descriptions and aliases for searchable records, and field descriptions for every family.
    /// Authored content is applied onto immutable <c>with</c> copies, so the base mapper output is
    /// never mutated and content survives assembly regeneration (structure re-derives, content merges).
    /// </summary>
    public static class ContentMerger
    {
        /// <summary>
        /// Returns the structural records with content applied, keyed by <see cref="ContentEntry.ClrType"/>.
        /// Records without an entry are returned unchanged.
        /// </summary>
        /// <remarks>
        /// dto records carry field descriptions only — never a record description or aliases — because
        /// they are reached via their parents and are not directly searchable.
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
            if (!contentByClrType.TryGetValue(record.ClrType, out var entry))
            {
                return record;
            }

            var fields = record.Fields
                .Select(f => entry.FieldDescriptions.TryGetValue(f.Name, out var text)
                    ? f with { Description = Merge(text, f.Description) }
                    : f)
                .ToList();

            if (record.Type == RecordType.Dto)
            {
                return record with { Fields = fields };
            }

            return record with
            {
                Fields = fields,
                Description = entry.Description is null ? record.Description : Merge(entry.Description, record.Description),
                Aliases = entry.Aliases is null
                    ? record.Aliases
                    : new SearchAliases { En = entry.Aliases.En, Zh = entry.Aliases.Zh },
            };
        }

        /// <summary>Applies only non-empty authored text; the structural value otherwise stays untouched.</summary>
        private static BilingualText Merge(BilingualText authored, BilingualText structural) => new()
        {
            En = string.IsNullOrEmpty(authored.En) ? structural.En : authored.En,
            Zh = string.IsNullOrEmpty(authored.Zh) ? structural.Zh : authored.Zh,
        };
    }
}
