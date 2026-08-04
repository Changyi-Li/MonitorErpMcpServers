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

        /// <summary>Bilingual description placeholder; hand-authored content fills this in later.</summary>
        public required BilingualText Description { get; init; }
    }
}
