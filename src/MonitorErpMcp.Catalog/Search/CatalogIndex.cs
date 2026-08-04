using Monitor.API.Infrastructure;
using MonitorErpMcp.Catalog.Model;

namespace MonitorErpMcp.Catalog.Search
{
    /// <summary>A page of search hits over the materialized catalog.</summary>
    public sealed record CatalogSearchResult(
        int Total,
        int Offset,
        int Limit,
        IReadOnlyList<CatalogRecord> Results);

    /// <summary>
    /// The materialized catalog: the immutable records built once at startup plus the search index
    /// and module listing over them. Pure data; no MCP dependency.
    /// </summary>
    public sealed class CatalogIndex
    {
        private readonly IReadOnlyList<CatalogRecord> _records;

        public CatalogIndex(IReadOnlyList<CatalogRecord> records)
        {
            _records = records;
        }

        public IReadOnlyList<CatalogRecord> Records => _records;

        public int QueryCount => _records.Count(r => r.Type == RecordType.Query);

        public int CommandCount => _records.Count(r => r.Type == RecordType.Command);

        /// <summary>
        /// Finds records whose name, CLR type, command full path, or route contains
        /// <paramref name="keyword"/> (case-insensitive substring), optionally narrowed by
        /// <c>type</c> and <c>module</c>, and paged by <paramref name="offset"/>/<paramref name="limit"/>.
        /// </summary>
        /// <remarks>
        /// Results are ranked exact match first, then prefix, then substring over the matched field;
        /// ties break queries before commands, then by shorter name (the core entity — e.g. <c>Parts</c>
        /// for <c>"part"</c> — surfaces before compound names that merely share the prefix), then by
        /// <c>ApiCategory</c> order, then by name. See docs/adr/0001-search-ranking-tiebreak.md.
        /// </remarks>
        public CatalogSearchResult Search(
            string keyword,
            string? type = null,
            string? module = null,
            int limit = 10,
            int offset = 0)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(keyword);
            ArgumentOutOfRangeException.ThrowIfNegative(offset);
            ArgumentOutOfRangeException.ThrowIfNegative(limit);

            IEnumerable<CatalogRecord> matches = _records.Where(r => Matches(r, keyword));

            if (type is not null)
            {
                matches = matches.Where(r => r.Type == ParseType(type));
            }

            if (module is not null)
            {
                matches = matches.Where(r => string.Equals(r.Module, module, StringComparison.OrdinalIgnoreCase));
            }

            var all = matches
                .Select(r => (Record: r, Score: MatchScore(r, keyword)))
                .OrderBy(x => x.Score)
                .ThenBy(x => x.Record.Type == RecordType.Query ? 0 : 1)
                .ThenBy(x => x.Record.Name.Length)
                .ThenBy(x => CategoryOrder(x.Record.Module))
                .ThenBy(x => x.Record.Name, StringComparer.Ordinal)
                .Select(x => x.Record)
                .ToList();

            return new CatalogSearchResult(all.Count, offset, limit, all.Skip(offset).Take(limit).ToList());
        }

        /// <summary>
        /// Lists the business areas that carry records with their query/command counts,
        /// in <c>ApiCategory</c> enumeration order. Areas with no records (e.g. Internal) are absent.
        /// </summary>
        public IReadOnlyList<CatalogModuleStats> ListModules() =>
            _records
                .GroupBy(r => r.Module)
                .OrderBy(g => CategoryOrder(g.Key))
                .Select(g => new CatalogModuleStats(
                    g.Key,
                    g.Count(r => r.Type == RecordType.Query),
                    g.Count(r => r.Type == RecordType.Command)))
                .ToList();

        /// <summary>The identity fields a keyword may match.</summary>
        private static IEnumerable<string> SearchableFields(CatalogRecord record)
        {
            yield return record.Name;
            yield return record.ClrType;
            if (record.FullPath is not null)
            {
                yield return record.FullPath;
            }

            yield return record.Route;
        }

        private static bool Matches(CatalogRecord record, string keyword) =>
            SearchableFields(record).Any(f => f.Contains(keyword, StringComparison.OrdinalIgnoreCase));

        /// <summary>Best (lowest) match score across the searchable fields.</summary>
        private static int MatchScore(CatalogRecord record, string keyword) =>
            SearchableFields(record).Min(f => FieldScore(f, keyword));

        /// <summary>0 = exact, 1 = prefix, 2 = substring; <see cref="int.MaxValue"/> if no match.</summary>
        private static int FieldScore(string field, string keyword)
        {
            if (field.Equals(keyword, StringComparison.OrdinalIgnoreCase))
            {
                return 0;
            }

            if (field.StartsWith(keyword, StringComparison.OrdinalIgnoreCase))
            {
                return 1;
            }

            return field.Contains(keyword, StringComparison.OrdinalIgnoreCase) ? 2 : int.MaxValue;
        }

        private static RecordType ParseType(string type) => type.ToLowerInvariant() switch
        {
            "query" => RecordType.Query,
            "command" => RecordType.Command,
            _ => throw new ArgumentException($"Invalid type filter '{type}'; expected 'query' or 'command'.", nameof(type)),
        };

        private static int CategoryOrder(string module) =>
            Enum.TryParse<ApiCategory>(module, out var category) ? (int)category : int.MaxValue;
    }
}
