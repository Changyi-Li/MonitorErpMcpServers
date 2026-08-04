namespace MonitorErpMcp.Catalog.Model
{
    /// <summary>
    /// The MCP-visible response envelope for <c>monitor_api_search</c>.
    /// </summary>
    public sealed record MonitorApiSearchResponse(
        int Total,
        int Offset,
        int Limit,
        IReadOnlyList<MonitorApiSearchResult> Results);

    /// <summary>
    /// One search hit: the identity of a query or command record.
    /// </summary>
    public sealed record MonitorApiSearchResult(
        string Type,
        string Module,
        string ClrType,
        string Name,
        string Route,
        string Method,
        string? FullPath,
        BilingualText Description);

    /// <summary>
    /// One business area's query/command record counts.
    /// </summary>
    public sealed record CatalogModuleStats(
        string Module,
        int QueryCount,
        int CommandCount);

    /// <summary>
    /// The MCP-visible response envelope for <c>monitor_api_list_modules</c>. An object (not a bare
    /// array) so the structured content shape is stable across protocol versions.
    /// </summary>
    public sealed record MonitorApiListModulesResponse(
        IReadOnlyList<CatalogModuleStats> Modules);
}
