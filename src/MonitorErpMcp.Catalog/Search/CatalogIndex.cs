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
        /// <summary>The size-guard budget in estimated tokens (~10K, ≈ 40K characters of JSON).</summary>
        private const int SizeGuardTokenBudget = 10_000;

        // Token model (≈ 4 characters of serialized JSON per token): a base cost per record, a base
        // per field's metadata (~320 chars), and ~32 chars per enum value; inline subtrees are summed
        // recursively. Calibrated so a wide record like Customer (~150 fields) exceeds the budget
        // while dto-deep trees like ReportMeasuring (~22 fields) stay comfortably under it.
        private const int RecordTokenBase = 30;
        private const int FieldTokenBase = 80;
        private const int EnumValueTokens = 8;

        /// <summary>
        /// Offsets every description-field match below all identity-field tiers (identity scores run
        /// 0–2; a description match lands at ≥ 10), so a description-only hit never ties or outranks
        /// an alias/name/route hit. See <see cref="BestFieldScore"/>.
        /// </summary>
        private const int DescriptionTierOffset = 10;

        private readonly IReadOnlyList<CatalogRecord> _records;

        public CatalogIndex(IReadOnlyList<CatalogRecord> records)
        {
            _records = records;
        }

        public IReadOnlyList<CatalogRecord> Records => _records;

        public int QueryCount => _records.Count(r => r.Type == RecordType.Query);

        public int CommandCount => _records.Count(r => r.Type == RecordType.Command);

        /// <summary>
        /// Finds records whose searchable text matches <em>every</em> token of
        /// <paramref name="keyword"/> — a case-insensitive substring over the record's aliases (en,
        /// zh), name, CLR type, command full path, route, and, as a fallback tier, its bilingual
        /// description — optionally narrowed by <c>type</c> and <c>module</c>, and paged by
        /// <paramref name="offset"/>/<paramref name="limit"/>. No fuzzy matching: a token must be
        /// literally present (substring), so a near-miss keyword like <c>"cstomer"</c> resolves nothing.
        /// </summary>
        /// <remarks>
        /// Results are ranked exact match first, then prefix, then substring over the matched field;
        /// a multi-token keyword scores as the sum of each token's best per-field match. A
        /// description match is searched only as a fallback and never outranks an identity-field
        /// match (see <see cref="BestFieldScore"/>). Ties break queries before commands, then by
        /// shorter name (the core entity — e.g. <c>Parts</c> for <c>"part"</c> — surfaces before
        /// compound names that merely share the prefix), then by <c>ApiCategory</c> order, then by
        /// name. See docs/adr/0001-search-ranking-tiebreak.md.
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

            // Split on whitespace so a multi-word keyword must match on every token
            // (a single word is one token and behaves exactly as the previous substring match).
            var tokens = keyword.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            // Dto records are reached via their parents and are never directly searchable.
            var parsedType = type is null ? (RecordType?)null : ParseType(type);

            var all = _records
                .Where(r => r.Type != RecordType.Dto)
                .Select(r => (Record: r, Result: Evaluate(r, tokens)))
                .Where(x => x.Result.Matches)
                .Where(x => parsedType is null || x.Record.Type == parsedType)
                .Where(x => module is null || string.Equals(x.Record.Module, module, StringComparison.OrdinalIgnoreCase))
                .OrderBy(x => x.Result.Score)
                .ThenBy(x => x.Record.Type == RecordType.Query ? 0 : 1)
                .ThenBy(x => x.Record.Name.Length)
                .ThenBy(x => CategoryOrder(x.Record.Module!))
                .ThenBy(x => x.Record.Name, StringComparer.Ordinal)
                .Select(x => x.Record)
                .ToList();

            return new CatalogSearchResult(all.Count, offset, limit, all.Skip(offset).Take(limit).ToList());
        }

        /// <summary>
        /// Finds the record with the given full CLR type name, case-insensitively
        /// (<c>ClrType</c> is the canonical key). Returns <c>null</c> when nothing matches.
        /// </summary>
        public CatalogRecord? GetByClrType(string clrType) =>
            _records.FirstOrDefault(r => string.Equals(r.ClrType, clrType, StringComparison.OrdinalIgnoreCase));

        /// <summary>
        /// Finds the record whose route path matches, case-insensitively and with or without the
        /// leading <c>api/v1/</c> prefix. A record's display <c>Name</c> collides across records, so it
        /// is not an addressable path and never matches here.
        /// </summary>
        public CatalogRecord? GetByPath(string path)
        {
            var normalized = NormalizePath(path);
            return _records.FirstOrDefault(r =>
                r.Route is not null && string.Equals(NormalizePath(r.Route), normalized, StringComparison.Ordinal));
        }

        /// <summary>
        /// Returns the record with dto-kind fields expanded inline up to <paramref name="maxDepth"/>:
        /// a dto field carries both its inline <see cref="FieldRecord.Fields"/>/<see cref="FieldRecord.Items"/>
        /// and <see cref="FieldRecord.RefClrType"/> so the graph stays navigable. <c>0</c> returns refs
        /// only (no inline). The size guard bounds the response: if the expanded tree exceeds
        /// <see cref="SizeGuardTokenBudget"/> tokens, the expansion depth is reduced and
        /// <see cref="CatalogRecord.ExpandNote"/> reports <c>"truncated at depth N (size guard)"</c>.
        /// </summary>
        public CatalogRecord Expand(CatalogRecord record, int maxDepth)
        {
            if (maxDepth <= 0)
            {
                return record; // expand=0: refs only, nothing to inline or guard
            }

            // expand=full is "unbounded" — clamp only to the record's natural dto DAG depth so the
            // whole tree is produced when it fits, with no silent truncation cap.
            var targetDepth = Math.Min(maxDepth, NaturalDepth(record));

            var expanded = ExpandToDepth(record, targetDepth);
            if (EstimateTokens(expanded) <= SizeGuardTokenBudget)
            {
                return expanded;
            }

            // Oversized: find the largest depth that fits, falling back to refs only.
            for (var depth = targetDepth - 1; depth >= 0; depth--)
            {
                var candidate = ExpandToDepth(record, depth);
                if (EstimateTokens(candidate) <= SizeGuardTokenBudget)
                {
                    return candidate with { ExpandNote = $"truncated at depth {depth} (size guard)" };
                }
            }

            // Even refs only exceeds the budget (a wide record); report the smallest tree.
            return record with { ExpandNote = "truncated at depth 0 (size guard)" };
        }

        /// <summary>The deepest dto-hop level reachable from the record's fields (1-based).</summary>
        private int NaturalDepth(CatalogRecord record) =>
            record.Fields.Select(f => FieldDepth(f, 1, new HashSet<string>(StringComparer.Ordinal))).DefaultIfEmpty(0).Max();

        private int FieldDepth(FieldRecord field, int depth, HashSet<string> path)
        {
            if (field.Kind != FieldKind.Dto || field.RefClrType is null || !path.Add(field.RefClrType))
            {
                return 0;
            }

            var dto = GetByClrType(field.RefClrType);
            path.Remove(field.RefClrType);
            if (dto is null || dto.Type != RecordType.Dto)
            {
                return 0;
            }

            return Math.Max(depth, dto.Fields.Select(f => FieldDepth(f, depth + 1, path)).DefaultIfEmpty(depth).Max());
        }

        /// <summary>Copies the record with every dto-kind field inlined to the given depth.</summary>
        private CatalogRecord ExpandToDepth(CatalogRecord record, int maxDepth)
        {
            var path = new HashSet<string>(StringComparer.Ordinal);
            return record with { Fields = record.Fields.Select(f => ExpandField(f, 1, maxDepth, path)).ToList() };
        }

        private FieldRecord ExpandField(FieldRecord field, int depth, int maxDepth, HashSet<string> path)
        {
            if (field.Kind != FieldKind.Dto || field.RefClrType is null || depth > maxDepth)
            {
                return field;
            }

            // Break dto cycles: never inline a dto already on the current expansion path.
            if (!path.Add(field.RefClrType))
            {
                return field;
            }

            var dto = GetByClrType(field.RefClrType);
            if (dto is null || dto.Type != RecordType.Dto)
            {
                path.Remove(field.RefClrType);
                return field;
            }

            var inline = dto.Fields.Select(f => ExpandField(f, depth + 1, maxDepth, path)).ToList();
            path.Remove(field.RefClrType);

            return field with { Inline = inline };
        }

        /// <summary>
        /// A token estimate of the expanded response, proxying the serialized JSON size
        /// (≈ 4 characters per token): a base cost per field plus its enum values and inlined subtree.
        /// </summary>
        private static int EstimateTokens(CatalogRecord record) =>
            RecordTokenBase + record.Fields.Sum(EstimateTokens);

        private static int EstimateTokens(FieldRecord field) =>
            FieldTokenBase
            + (field.Enum?.Values.Count ?? 0) * EnumValueTokens
            + (field.Inline?.Sum(EstimateTokens) ?? 0);

        /// <summary>Lowercases the path and strips a leading <c>api/v1/</c> segment (and any surrounding slashes).</summary>
        private static string NormalizePath(string path)
        {
            var trimmed = path.Trim('/');
            const string prefix = "api/v1/";
            if (trimmed.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            {
                trimmed = trimmed[prefix.Length..];
            }

            return trimmed.ToLowerInvariant();
        }

        /// <summary>
        /// Lists the business areas that carry records with their query/command counts,
        /// in <c>ApiCategory</c> enumeration order. Areas with no records (e.g. Internal) are absent.
        /// </summary>
        public IReadOnlyList<CatalogModuleStats> ListModules() =>
            _records
                .Where(r => r.Type is RecordType.Query or RecordType.Command)
                .GroupBy(r => r.Module!)
                .OrderBy(g => CategoryOrder(g.Key))
                .Select(g => new CatalogModuleStats(
                    g.Key,
                    g.Count(r => r.Type == RecordType.Query),
                    g.Count(r => r.Type == RecordType.Command)))
                .ToList();

        /// <summary>The identity text a keyword token may match: aliases (en, zh), name, CLR type, full path, route.</summary>
        private static IEnumerable<string> IdentityFields(CatalogRecord record)
        {
            foreach (var alias in record.Aliases.En.Concat(record.Aliases.Zh))
            {
                yield return alias;
            }

            yield return record.Name;
            yield return record.ClrType;
            if (record.FullPath is not null)
            {
                yield return record.FullPath;
            }

            if (record.Route is not null)
            {
                yield return record.Route;
            }
        }

        /// <summary>The bilingual description text a keyword token may match, as the fallback tier.</summary>
        private static IEnumerable<string> DescriptionFields(CatalogRecord record)
        {
            yield return record.Description.En;
            yield return record.Description.Zh;
        }

        /// <summary>
        /// Evaluates a record against the keyword tokens in one pass. Every token must match some
        /// field (no fuzzy matching); the rank score is the sum of each token's best per-field match.
        /// A token that matches nothing fails the record outright, so the summed score is always finite.
        /// </summary>
        private static (bool Matches, int Score) Evaluate(CatalogRecord record, IReadOnlyList<string> tokens)
        {
            var score = 0;
            foreach (var token in tokens)
            {
                var best = BestFieldScore(record, token);
                if (best == int.MaxValue)
                {
                    return (false, int.MaxValue);
                }

                score += best;
            }

            return (true, score);
        }

        /// <summary>
        /// Best (lowest) match score for one token. An identity-field match (exact 0 / prefix 1 /
        /// substring 2) always wins; a description match is offset below every identity tier so it
        /// never outranks an alias/name/route hit. <see cref="int.MaxValue"/> when the token matches
        /// no field.
        /// </summary>
        private static int BestFieldScore(CatalogRecord record, string token)
        {
            var identity = IdentityFields(record).Min(f => FieldScore(f, token));
            if (identity != int.MaxValue)
            {
                return identity;
            }

            var description = DescriptionFields(record).Min(f => FieldScore(f, token));
            return description == int.MaxValue ? int.MaxValue : description + DescriptionTierOffset;
        }

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
