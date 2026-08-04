using MonitorErpMcp.Catalog.Model;

namespace MonitorErpMcp.Catalog.Content
{
    /// <summary>
    /// The <c>Content(...)</c> builder for hand-authored content entries, with defaults so a record
    /// without examples is a one-liner. Authoring order is en first (canonical), zh second
    /// (translation pass); the same order holds for descriptions, aliases, and field descriptions.
    /// </summary>
    public static class ContentEntryFactory
    {
        /// <summary>
        /// Builds a <see cref="ContentEntry"/> keyed by <paramref name="clrType"/>. A record with only
        /// a description is <c>Content(clrType, en, zh)</c>; aliases and field descriptions are optional.
        /// Passing a <paramref name="fields"/> entry whose <see cref="FieldDescription.Field"/> repeats a
        /// previously authored field throws, so a duplicate key in one entry fails fast at startup.
        /// </summary>
        public static ContentEntry Content(
            string clrType,
            string? descriptionEn = null,
            string? descriptionZh = null,
            IReadOnlyList<string>? aliasesEn = null,
            IReadOnlyList<string>? aliasesZh = null,
            IEnumerable<FieldDescription>? fields = null,
            IEnumerable<CatalogExample>? examples = null)
        {
            var description = descriptionEn is null && descriptionZh is null
                ? null
                : new BilingualText { En = descriptionEn ?? string.Empty, Zh = descriptionZh ?? string.Empty };

            var hasAliases = aliasesEn?.Count > 0 || aliasesZh?.Count > 0;
            var aliases = hasAliases
                ? new SearchAliases { En = aliasesEn ?? [], Zh = aliasesZh ?? [] }
                : null;

            return new ContentEntry
            {
                ClrType = clrType,
                Description = description,
                Aliases = aliases,
                FieldDescriptions = fields?.ToDictionary(
                    f => f.Field,
                    f => new BilingualText { En = f.En, Zh = f.Zh },
                    StringComparer.Ordinal) ?? new Dictionary<string, BilingualText>(StringComparer.Ordinal),
                Examples = examples?.ToList() ?? [],
            };
        }

        /// <summary>
        /// Builds one bilingual field description (en first, zh second) for use in <c>Content(... fields:)</c>.
        /// <c>zh</c> is required so every authored field is bilingual, as the coverage tiers demand.
        /// </summary>
        public static FieldDescription F(string field, string en, string zh) => new(field, en, zh);

        /// <summary>
        /// Builds one hand-authored example (en first, zh second) for use in <c>Content(... examples:)</c>.
        /// A query/command example carries a route, method, and body; a many example carries an array
        /// request on the <c>/Many</c> route; a batch example carries ordered <see cref="Step"/>s.
        /// </summary>
        public static CatalogExample Example(
            ExampleKind kind,
            string titleEn,
            string titleZh,
            string explanationEn,
            string explanationZh,
            string? route = null,
            string? method = null,
            string? query = null,
            object? request = null,
            object? response = null,
            IEnumerable<BatchExampleStep>? steps = null) => new()
        {
            Kind = kind,
            Title = new BilingualText { En = titleEn, Zh = titleZh },
            Explanation = new BilingualText { En = explanationEn, Zh = explanationZh },
            Route = route,
            Method = method,
            Query = query,
            Request = request,
            Response = response,
            Steps = steps?.ToList(),
        };

        /// <summary>Builds one step of a batch example; the optional bilingual note explains how it forwards values from prior steps.</summary>
        public static BatchExampleStep Step(
            string route,
            string method,
            object? request = null,
            string? noteEn = null,
            string? noteZh = null) => new()
        {
            Route = route,
            Method = method,
            Request = request,
            Note = noteEn is null && noteZh is null
                ? null
                : new BilingualText { En = noteEn ?? string.Empty, Zh = noteZh ?? string.Empty },
        };
    }
}
