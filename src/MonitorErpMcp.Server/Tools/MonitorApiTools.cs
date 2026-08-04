using ModelContextProtocol;
using ModelContextProtocol.Server;
using MonitorErpMcp.Catalog.Model;
using System.ComponentModel;

namespace MonitorErpMcp.Server.Tools
{
    /// <summary>
    /// Read-only catalog lookup tools over the Monitor ERP API surface. Both tools return structured
    /// content with a JSON text fallback and never execute anything against a live ERP.
    /// </summary>
    [McpServerToolType]
    public sealed class MonitorApiTools
    {
        private const int DefaultLimit = 10;
        private const int MaxLimit = 50;

        // Static-only tools; a non-static type is required by WithTools<T>.
        private MonitorApiTools() { }

        /// <summary>
        /// Searches the combined query+command catalog by keyword. Matches are case-insensitive
        /// substrings over record name, CLR type, command full path, and route, optionally narrowed
        /// by <c>type</c> and <c>module</c>, and paged by <c>limit</c>/<c>offset</c>.
        /// </summary>
        [McpServerTool(Name = "monitor_api_search", ReadOnly = true, UseStructuredContent = true)]
        [Description("Search the Monitor ERP API catalog for queries (GET) and commands (POST) by keyword. " +
                     "Returns matching records with their identity: type, module, clrType, name, route, method, " +
                     "fullPath (commands), and bilingual description. Use type='query'|'command' and module to narrow, " +
                     "and limit (1-50, default 10) and offset (>= 0, default 0) to page. Never executes against a live ERP.")]
        public static MonitorApiSearchResponse Search(
            CatalogService catalog,
            [Description("Keyword to match case-insensitively as a substring over record name, CLR type, command full path, and route.")]
            string keyword,
            [Description("Optional filter: 'query' or 'command'.")]
            string? type = null,
            [Description("Optional filter: business area (module), e.g. 'Inventory'.")]
            string? module = null,
            [Description("Maximum number of results to return; must be between 1 and 50. Default 10.")]
            int limit = DefaultLimit,
            [Description("Number of results to skip before returning; must be non-negative. Default 0.")]
            int offset = 0)
        {
            if (type is not null
                && !type.Equals("query", StringComparison.OrdinalIgnoreCase)
                && !type.Equals("command", StringComparison.OrdinalIgnoreCase))
            {
                throw new McpException($"Invalid type filter '{type}'; expected 'query' or 'command'.");
            }

            if (limit is < 1 or > MaxLimit)
            {
                throw new McpException($"limit must be between 1 and {MaxLimit}; got {limit}.");
            }

            if (offset < 0)
            {
                throw new McpException($"offset must be non-negative; got {offset}.");
            }

            var result = catalog.Index.Search(keyword, type, module, limit, offset);
            return new MonitorApiSearchResponse(
                result.Total,
                result.Offset,
                result.Limit,
                result.Results.Select(ToSearchResult).ToList());
        }

        /// <summary>
        /// Returns the full record for one query or command, resolved by full CLR type name
        /// (<c>clrType</c>) or route path (<c>path</c>). A record's display <c>name</c> collides across
        /// records and is not an addressable key, so it is never resolved here.
        /// </summary>
        [McpServerTool(Name = "monitor_api_get_record", ReadOnly = true, UseStructuredContent = true)]
        [Description("Return the full catalog record for one Monitor ERP API query or command, resolved by full " +
                     "CLR type name (clrType) or route path (path). name is not an addressable key and never resolves. " +
                     "Exactly one of clrType or path must be given. Returns the record identity, availableSince/obsoleteSince, " +
                     "helpUrl, and every field with its generic wire type (jsonType/format) and constraints: query fields are " +
                     "response members with informational constraints (notNull, maxLength, minLength, unique, expandable); command " +
                     "fields are request-body inputs with mandatory/mandatoryWhen/default semantics. expand controls nested DTO " +
                     "expansion inline: '0' (refs only), '1', ..., or 'full' (default 'full') returns the whole tree in one call — " +
                     "dto fields carry inline fields/items and their refClrType. Oversized responses are truncated at the size " +
                     "guard (~10K tokens) with expandNote 'truncated at depth N (size guard)'. Read-only; never executes against a live ERP.")]
        public static MonitorApiGetRecordResponse GetRecord(
            CatalogService catalog,
            [Description("Full CLR type name, e.g. 'Monitor.API.Inventory.Part'. Provide exactly one of clrType or path.")]
            string? clrType = null,
            [Description("Route path, e.g. 'api/v1/Inventory/Parts' or 'Inventory/Parts' (with or without the api/v1/ prefix). Provide exactly one of clrType or path.")]
            string? path = null,
            [Description("Nested DTO expansion depth: '0' (refs only), '1', ..., or 'full' (default 'full', the whole tree inline).")]
            string expand = "full")
        {
            var hasClrType = !string.IsNullOrWhiteSpace(clrType);
            var hasPath = !string.IsNullOrWhiteSpace(path);

            if (hasClrType == hasPath)
            {
                throw new McpException("Provide exactly one of clrType or path to identify the record; " +
                                       "a record's display name is not an addressable key.");
            }

            var maxDepth = ParseExpand(expand);

            var record = hasClrType
                ? catalog.Index.GetByClrType(clrType!)
                : catalog.Index.GetByPath(path!);

            if (record is null)
            {
                throw new McpException($"No catalog record found for {(hasClrType ? $"clrType '{clrType}'" : $"path '{path}'")}. " +
                                       "Resolve by clrType (full CLR type name, e.g. 'Monitor.API.Inventory.Part') or by path " +
                                       "(route, e.g. 'api/v1/Inventory/Parts'); a record's display name is not an addressable key.");
            }

            return ToGetRecordResponse(catalog.Index.Expand(record, maxDepth));
        }

        /// <summary>
        /// Lists the business areas that carry catalog records, each with its query and command counts.
        /// Areas with no records (e.g. Internal) are absent.
        /// </summary>
        [McpServerTool(Name = "monitor_api_list_modules", ReadOnly = true, UseStructuredContent = true)]
        [Description("List the Monitor ERP API business areas that carry catalog records, with each area's " +
                     "query and command record counts. Read-only; never executes against a live ERP.")]
        public static MonitorApiListModulesResponse ListModules(CatalogService catalog) =>
            new(catalog.Index.ListModules());

        /// <summary>Maps <c>expand</c> to a dto-expansion depth: <c>0</c>/<c>1</c>/… or <c>full</c> (unbounded).</summary>
        private static int ParseExpand(string expand)
        {
            if (expand.Equals("full", StringComparison.OrdinalIgnoreCase))
            {
                return int.MaxValue;
            }

            if (int.TryParse(expand, out var depth) && depth >= 0)
            {
                return depth;
            }

            throw new McpException($"Invalid expand value '{expand}'; expected '0', '1', ..., or 'full'.");
        }

        private static MonitorApiGetRecordResponse ToGetRecordResponse(CatalogRecord record) =>
            new(
                Type: WireTypeName(record.Type),
                Module: record.Module,
                ClrType: record.ClrType,
                Name: record.Name,
                Route: record.Route,
                Method: record.Method,
                FullPath: record.FullPath,
                QueryOptions: record.QueryOptions,
                RelatedCommands: record.RelatedCommands,
                Batchable: record.Batchable,
                MultipartForm: record.MultipartForm,
                Output: record.Output,
                AvailableSince: record.AvailableSince,
                ObsoleteSince: record.ObsoleteSince,
                HelpUrl: record.HelpUrl,
                ExpandNote: record.ExpandNote,
                UsedBy: record.UsedBy,
                Description: record.Description,
                Fields: record.Fields.Select(ToField).ToList());

        private static MonitorApiField ToField(FieldRecord field) =>
            new(
                Name: field.Name,
                ClrType: field.ClrType,
                JsonType: field.JsonType,
                Format: field.Format,
                Kind: WireKindName(field.Kind),
                References: field.References,
                RefClrType: field.RefClrType,
                Enum: ToFieldEnum(field.Enum),
                Mandatory: field.Mandatory,
                MandatoryWhen: field.MandatoryWhen,
                Default: field.Default,
                NotNull: field.NotNull,
                MaxLength: field.MaxLength,
                MinLength: field.MinLength,
                Unique: field.Unique,
                Expandable: field.Expandable,
                AvailableSince: field.AvailableSince,
                ObsoleteSince: field.ObsoleteSince,
                Fields: field.JsonType == "array" ? null : field.Inline?.Select(ToField).ToList(),
                Items: field.JsonType == "array" ? field.Inline?.Select(ToField).ToList() : null,
                Description: field.Description);

        private static MonitorApiFieldEnum? ToFieldEnum(FieldEnum? fieldEnum) =>
            fieldEnum is null
                ? null
                : new MonitorApiFieldEnum(
                    fieldEnum.ClrType,
                    fieldEnum.Values.Select(v => new MonitorApiEnumValue(v.Name, v.Value)).ToList());

        /// <summary>The MCP-visible wire name for a record family.</summary>
        private static string WireTypeName(RecordType type) => type switch
        {
            RecordType.Query => "query",
            RecordType.Command => "command",
            _ => "dto",
        };

        /// <summary>The MCP-visible wire name for a field kind.</summary>
        private static string WireKindName(FieldKind kind) => kind switch
        {
            FieldKind.Raw => "raw",
            FieldKind.Enum => "enum",
            FieldKind.Reference => "reference",
            FieldKind.Expandable => "expandable",
            FieldKind.InputWrapper => "inputWrapper",
            FieldKind.NestedCommand => "nestedCommand",
            _ => "dto",
        };

        private static MonitorApiSearchResult ToSearchResult(CatalogRecord record) =>
            new(
                WireTypeName(record.Type),
                // Only query/command records reach search; dto records carry null module/route/method.
                record.Module!,
                record.ClrType,
                record.Name,
                record.Route!,
                record.Method!,
                record.FullPath,
                record.Description);
    }
}
