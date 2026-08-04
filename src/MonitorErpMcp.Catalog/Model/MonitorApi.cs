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
    /// identity, availability, canonical helpUrl, and fields. Dto records carry <c>usedBy</c> and have
    /// <c>module</c>/<c>route</c>/<c>method</c> as <c>null</c> (no HTTP surface).
    /// </summary>
    public sealed record MonitorApiGetRecordResponse(
        string Type,
        string? Module,
        string ClrType,
        string Name,
        string? Route,
        string? Method,
        string? FullPath,
        IReadOnlyList<string> QueryOptions,
        IReadOnlyList<string> RelatedCommands,
        bool Batchable,
        bool MultipartForm,
        string? Output,
        string? AvailableSince,
        string? ObsoleteSince,
        string HelpUrl,
        string? ExpandNote,
        IReadOnlyList<string> UsedBy,
        BilingualText Description,
        IReadOnlyList<MonitorApiField> Fields);

    /// <summary>
    /// One field of a record with its generic wire type (<c>jsonType</c>/<c>format</c>), classification
    /// (<c>kind</c>), and constraints. On a query record the field is a response member (constraints are
    /// informational data-model facts); on a command record it is a request-body input with
    /// <c>mandatory</c>/<c>mandatoryWhen</c>/<c>default</c> input semantics.
    /// </summary>
    public sealed record MonitorApiField(
        string Name,
        string ClrType,
        string JsonType,
        string? Format,
        string Kind,
        string? References,
        string? RefClrType,
        MonitorApiFieldEnum? Enum,
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
        IReadOnlyList<MonitorApiField>? Fields,
        IReadOnlyList<MonitorApiField>? Items,
        BilingualText Description);

    /// <summary>An enum field's numeric value vocabulary in the MCP-visible envelope.</summary>
    public sealed record MonitorApiFieldEnum(
        string ClrType,
        IReadOnlyList<MonitorApiEnumValue> Values);

    /// <summary>One named enum member with its integer code.</summary>
    public sealed record MonitorApiEnumValue(
        string Name,
        long Value);

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
