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
        /// Lists the business areas that carry catalog records, each with its query and command counts.
        /// Areas with no records (e.g. Internal) are absent.
        /// </summary>
        [McpServerTool(Name = "monitor_api_list_modules", ReadOnly = true, UseStructuredContent = true)]
        [Description("List the Monitor ERP API business areas that carry catalog records, with each area's " +
                     "query and command record counts. Read-only; never executes against a live ERP.")]
        public static MonitorApiListModulesResponse ListModules(CatalogService catalog) =>
            new(catalog.Index.ListModules());

        private static MonitorApiSearchResult ToSearchResult(CatalogRecord record) =>
            new(
                record.Type == RecordType.Query ? "query" : "command",
                record.Module,
                record.ClrType,
                record.Name,
                record.Route,
                record.Method,
                record.FullPath,
                record.Description);
    }
}
