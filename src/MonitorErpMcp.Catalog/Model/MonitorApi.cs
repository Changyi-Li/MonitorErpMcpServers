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
    /// The MCP-visible response envelope for <c>monitor_api_get_record</c>: the full record with its
    /// identity, availability, canonical helpUrl, and fields.
    /// </summary>
    public sealed record MonitorApiGetRecordResponse(
        string Type,
        string Module,
        string ClrType,
        string Name,
        string Route,
        string Method,
        string? FullPath,
        string? AvailableSince,
        string? ObsoleteSince,
        string HelpUrl,
        BilingualText Description,
        IReadOnlyList<MonitorApiField> Fields);

    /// <summary>
    /// One field of a record with its generic wire type (<c>jsonType</c>/<c>format</c>) and constraints.
    /// On a query record the field is a response member (constraints are informational data-model facts);
    /// on a command record it is a request-body input with <c>mandatory</c>/<c>mandatoryWhen</c>/<c>default</c>
    /// input semantics.
    /// </summary>
    public sealed record MonitorApiField(
        string Name,
        string ClrType,
        string JsonType,
        string? Format,
        bool Mandatory,
        string? MandatoryWhen,
        string? Default,
        bool NotNull,
        int? MaxLength,
        int? MinLength,
        bool Unique,
        bool Expandable,
        string? AvailableSince,
        string? ObsoleteSince,
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
