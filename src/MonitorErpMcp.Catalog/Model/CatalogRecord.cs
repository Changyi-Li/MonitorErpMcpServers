namespace MonitorErpMcp.Catalog.Model
{
    /// <summary>The family of a catalog record.</summary>
    public enum RecordType
    {
        /// <summary>A read-only GET operation backed by <c>[ApiEntity]</c>.</summary>
        Query,

        /// <summary>A state-changing POST operation backed by <c>[ApiCommand]</c>.</summary>
        Command,
    }

    /// <summary>A bilingual (English/Chinese) text pair.</summary>
    public sealed record BilingualText
    {
        public string En { get; init; } = string.Empty;
        public string Zh { get; init; } = string.Empty;
    }

    /// <summary>
    /// Identity of a Monitor ERP API operation, derived by reflection from the pinned
    /// <c>MonitorG5.Api</c> assembly. <c>ClrType</c> is the canonical identity key.
    /// </summary>
    public sealed record CatalogRecord
    {
        /// <summary>Query (<c>[ApiEntity]</c>) or command (<c>[ApiCommand]</c>).</summary>
        public required RecordType Type { get; init; }

        /// <summary>Business area, e.g. <c>Inventory</c>; the <c>ApiCategory</c> name.</summary>
        public required string Module { get; init; }

        /// <summary>Full CLR type name, e.g. <c>Monitor.API.Inventory.Part</c>.</summary>
        public required string ClrType { get; init; }

        /// <summary>Route segment: plural for queries (e.g. <c>Parts</c>); command title for commands.</summary>
        public required string Name { get; init; }

        /// <summary>Route with host, language, and company omitted, e.g. <c>api/v1/Inventory/Parts</c>.</summary>
        public required string Route { get; init; }

        /// <summary><c>GET</c> for queries, <c>POST</c> for commands.</summary>
        public required string Method { get; init; }

        /// <summary>Commands only: <c>{Category}/{EntityName}/{CommandName}</c>, e.g. <c>Inventory/Parts/Create</c>.</summary>
        public string? FullPath { get; init; }

        /// <summary>Version the operation was introduced in, e.g. <c>2.18</c>.</summary>
        public string? AvailableSince { get; init; }

        /// <summary>Version the operation was obsoleted in; <c>null</c> while current.</summary>
        public string? ObsoleteSince { get; init; }

        /// <summary>
        /// Canonical reference on api.monitor.se, derived from <see cref="ClrType"/>. Never a content
        /// source — a link a human consults for the authoritative reference.
        /// </summary>
        public string HelpUrl => $"https://api.monitor.se/api/{ClrType}.html";

        /// <summary>
        /// The operation's fields. On a query record these are the API response members (constraints
        /// such as <see cref="FieldRecord.NotNull"/>/<see cref="FieldRecord.MaxLength"/>/
        /// <see cref="FieldRecord.Unique"/> are informational data-model facts). On a command record
        /// they are the request-body inputs (<see cref="FieldRecord.Mandatory"/>/
        /// <see cref="FieldRecord.MandatoryWhen"/>/<see cref="FieldRecord.Default"/> are input semantics).
        /// </summary>
        public IReadOnlyList<FieldRecord> Fields { get; init; } = [];

        /// <summary>Bilingual description placeholder; hand-authored content fills this in later.</summary>
        public required BilingualText Description { get; init; }
    }

    /// <summary>
    /// One field of a query or command record. <see cref="JsonType"/>/<see cref="Format"/> carry the
    /// generic JSON wire type (the vocabulary an agent needs to produce valid JSON without knowing C#);
    /// <see cref="ClrType"/> remains the identity key for the .NET type behind the field.
    /// </summary>
    public sealed record FieldRecord
    {
        /// <summary>Property name, e.g. <c>PartNumber</c>.</summary>
        public required string Name { get; init; }

        /// <summary>Full CLR type of the field, e.g. <c>System.String</c> or <c>System.Int64</c>.</summary>
        public required string ClrType { get; init; }

        /// <summary>Generic JSON wire type: <c>string</c>, <c>boolean</c>, <c>integer</c>, <c>number</c>, <c>array</c>, or <c>object</c>.</summary>
        public required string JsonType { get; init; }

        /// <summary>Wire format, e.g. <c>int32</c>, <c>int64</c>, <c>decimal</c>, <c>date-time</c>, <c>uuid</c>, <c>timespan</c>.</summary>
        public string? Format { get; init; }

        /// <summary>Command records only: whether the field must be sent in the request body. False on query response members.</summary>
        public bool Mandatory { get; init; }

        /// <summary>The circumstance under which the field is mandatory, from <c>MandatoryAttribute</c> (e.g. <c>PartLocationName</c> is mandatory when reporting to a new location).</summary>
        public string? MandatoryWhen { get; init; }

        /// <summary>Default value text from <c>DefaultAttribute</c>, when the API applies one.</summary>
        public string? Default { get; init; }

        /// <summary>Whether the field is not nullable.</summary>
        public bool NotNull { get; init; }

        /// <summary>Maximum length for string fields.</summary>
        public int? MaxLength { get; init; }

        /// <summary>Minimum length for string fields.</summary>
        public int? MinLength { get; init; }

        /// <summary>Whether the value must be unique.</summary>
        public bool Unique { get; init; }

        /// <summary>Whether the referenced entity is expandable in query responses.</summary>
        public bool Expandable { get; init; }

        /// <summary>Version the field was introduced in, e.g. <c>2.40</c>.</summary>
        public string? AvailableSince { get; init; }

        /// <summary>Version the field was obsoleted in; <c>null</c> while current.</summary>
        public string? ObsoleteSince { get; init; }

        /// <summary>Bilingual description placeholder; hand-authored content fills this in later.</summary>
        public required BilingualText Description { get; init; }
    }
}
