using MonitorErpMcp.Catalog.Model;

namespace MonitorErpMcp.Catalog.Content
{
    /// <summary>
    /// One field-level content item: the bilingual description for a single field, keyed by the field
    /// name when it is folded into a <see cref="ContentEntry"/>'s <see cref="ContentEntry.FieldDescriptions"/>.
    /// </summary>
    public sealed record FieldDescription(string Field, string En, string Zh);

    /// <summary>
    /// One clrType-keyed unit of hand-authored content: a bilingual description and search aliases for
    /// a query/command record, plus bilingual field descriptions. <c>ClrType</c> is the merge key, so
    /// content survives assembly regeneration — structure re-derives, content merges by key.
    /// </summary>
    /// <remarks>
    /// dto records carry only <see cref="FieldDescriptions"/>: they are reached via their parents and
    /// are not searchable, so the merger never applies a record description or aliases to one. Examples
    /// arrive with the examples tier (T3) and are out of scope here.
    /// </remarks>
    public sealed record ContentEntry
    {
        /// <summary>Full CLR type name, the merge key, e.g. <c>Monitor.API.Inventory.Part</c>.</summary>
        public required string ClrType { get; init; }

        /// <summary>Bilingual record description (en first, zh second). <c>null</c> when unauthored.</summary>
        public BilingualText? Description { get; init; }

        /// <summary>Bilingual search aliases; <c>null</c> when unauthored.</summary>
        public SearchAliases? Aliases { get; init; }

        /// <summary>Bilingual field descriptions keyed by field name; empty when none are authored.</summary>
        public IReadOnlyDictionary<string, BilingualText> FieldDescriptions { get; init; } =
            new Dictionary<string, BilingualText>(StringComparer.Ordinal);
    }
}
