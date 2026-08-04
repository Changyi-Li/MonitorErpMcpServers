namespace MonitorErpMcp.Catalog.Model
{
    /// <summary>The family of a catalog record.</summary>
    public enum RecordType
    {
        /// <summary>A read-only GET operation backed by <c>[ApiEntity]</c>.</summary>
        Query,

        /// <summary>A state-changing POST operation backed by <c>[ApiCommand]</c>.</summary>
        Command,

        /// <summary>
        /// A plain request/response DTO class reached via a field. Not directly searchable and carries
        /// no HTTP route; reached by <c>clrType</c> from its parents via the derived <see cref="CatalogRecord.UsedBy"/>.
        /// </summary>
        Dto,
    }

    /// <summary>A bilingual (English/Chinese) text pair.</summary>
    public sealed record BilingualText
    {
        public string En { get; init; } = string.Empty;
        public string Zh { get; init; } = string.Empty;
    }

    /// <summary>The classification of a field, implied by its CLR type and attributes.</summary>
    public enum FieldKind
    {
        /// <summary>A plain scalar (string, bool, integer, number, date-time, uuid, timespan).</summary>
        Raw,

        /// <summary>An enum field serialized as its integer code; carries <see cref="FieldRecord.Enum"/>.</summary>
        Enum,

        /// <summary>An id field marked <c>[References]</c> naming the referenced entity; carries <see cref="FieldRecord.References"/>.</summary>
        Reference,

        /// <summary>A field marked <c>[Expandable]</c> that returns the full referenced entity on request.</summary>
        Expandable,

        /// <summary>A <c>*Input</c> wrapper (<c>null</c> = "do not touch" vs <c>{ "Value": null }</c> = explicit null).</summary>
        InputWrapper,

        /// <summary>A field whose type is itself a command; identifies the nested command's input type.</summary>
        NestedCommand,

        /// <summary>A field whose type is a plain DTO class; carries <see cref="FieldRecord.RefClrType"/>.</summary>
        Dto,
    }

    /// <summary>An enum field's numeric value vocabulary.</summary>
    public sealed record FieldEnum
    {
        /// <summary>Full CLR type name of the enum, e.g. <c>Monitor.API.Inventory.Commands.Parts.PartSaveAsStates</c>.</summary>
        public required string ClrType { get; init; }

        /// <summary>The named members with their integer codes, honoring <c>[Flags]</c> (incl. <c>All = -1</c>).</summary>
        public required IReadOnlyList<FieldEnumValue> Values { get; init; }
    }

    /// <summary>One named enum member with its integer code.</summary>
    public sealed record FieldEnumValue
    {
        public required string Name { get; init; }
        public required long Value { get; init; }
    }

    /// <summary>
    /// Identity of a Monitor ERP API operation, derived by reflection from the pinned
    /// <c>MonitorG5.Api</c> assembly. <c>ClrType</c> is the canonical identity key.
    /// </summary>
    public sealed record CatalogRecord
    {
        /// <summary>Query (<c>[ApiEntity]</c>), command (<c>[ApiCommand]</c>), or dto (plain referenced class).</summary>
        public required RecordType Type { get; init; }

        /// <summary>Business area, e.g. <c>Inventory</c>; the <c>ApiCategory</c> name. <c>null</c> on dto records.</summary>
        public required string? Module { get; init; }

        /// <summary>Full CLR type name, e.g. <c>Monitor.API.Inventory.Part</c>.</summary>
        public required string ClrType { get; init; }

        /// <summary>Route segment for queries/commands (e.g. <c>Parts</c>); the simple class name on dto records.</summary>
        public required string Name { get; init; }

        /// <summary>Route with host, language, and company omitted, e.g. <c>api/v1/Inventory/Parts</c>. <c>null</c> on dto records.</summary>
        public required string? Route { get; init; }

        /// <summary><c>GET</c> for queries, <c>POST</c> for commands. <c>null</c> on dto records.</summary>
        public required string? Method { get; init; }

        /// <summary>Commands only: <c>{Category}/{EntityName}/{CommandName}</c>, e.g. <c>Inventory/Parts/Create</c>.</summary>
        public string? FullPath { get; init; }

        /// <summary>Dto records only: the clrTypes of the records (query/command/dto) whose fields reference this dto.</summary>
        public IReadOnlyList<string> UsedBy { get; init; } = [];

        /// <summary>
        /// Queries only: the OData query options the GET endpoint supports. The pinned assembly does not
        /// encode these, so all queries support the standard six — <c>filter</c>, <c>select</c>,
        /// <c>expand</c>, <c>orderby</c>, <c>top</c>, <c>skip</c>.
        /// </summary>
        public IReadOnlyList<string> QueryOptions { get; init; } = [];

        /// <summary>
        /// Queries only: the clrTypes of the commands that mutate this entity, derived by joining every
        /// <c>[ApiCommand](Category, EntityName)</c> to the matching <c>[ApiEntity](Category, Name)</c> —
        /// never hand-maintained. Empty on commands and dto records.
        /// </summary>
        public IReadOnlyList<string> RelatedCommands { get; init; } = [];

        /// <summary>Commands only: whether the POST is batchable (the <c>/Many</c> route suffix), from <c>ApiCommandAttribute.AllowMultiple</c>.</summary>
        public bool Batchable { get; init; }

        /// <summary>Commands only: whether the request body is multipart/form-data, from <c>ApiMultipartFormCommandAttribute</c>.</summary>
        public bool MultipartForm { get; init; }

        /// <summary>
        /// Commands only: the command's response type. The assembly encodes no per-command response DTOs
        /// (those exist only in the online help), so every command defaults to <c>EntityCommandResponse</c>.
        /// </summary>
        public string? Output { get; init; }

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
        /// The record's fields. On a query record these are the API response members (constraints such
        /// as <see cref="FieldRecord.NotNull"/>/<see cref="FieldRecord.MaxLength"/>/
        /// <see cref="FieldRecord.Unique"/> are informational data-model facts). On a command record they
        /// are the request-body inputs (<see cref="FieldRecord.Mandatory"/>/
        /// <see cref="FieldRecord.MandatoryWhen"/>/<see cref="FieldRecord.Default"/> are input semantics).
        /// A dto record's fields carry the class's actual constraints.
        /// </summary>
        public IReadOnlyList<FieldRecord> Fields { get; init; } = [];

        /// <summary>Bilingual description placeholder; hand-authored content fills this in later.</summary>
        public required BilingualText Description { get; init; }
    }

    /// <summary>
    /// One field of a query, command, or dto record. <see cref="JsonType"/>/<see cref="Format"/> carry the
    /// generic JSON wire type (the vocabulary an agent needs to produce valid JSON without knowing C#);
    /// <see cref="ClrType"/> remains the identity key for the .NET type behind the field. <see cref="Kind"/>
    /// classifies the field so an agent knows how to shape its value.
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

        /// <summary>The field classification (raw, enum, reference, expandable, input wrapper, nested command, dto).</summary>
        public required FieldKind Kind { get; init; }

        /// <summary>Reference kind: the referenced entity's simple CLR name, e.g. <c>ProductGroup</c>.</summary>
        public string? References { get; init; }

        /// <summary>Dto/nested-command/expandable/reference kind: the referenced type's full CLR name (element type for collections).</summary>
        public string? RefClrType { get; init; }

        /// <summary>Enum kind (and enum-valued input wrappers): the numeric value vocabulary.</summary>
        public FieldEnum? Enum { get; init; }

        /// <summary>Command and dto records: whether the field must be sent in the request body. False on query response members.</summary>
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
