namespace MonitorErpMcp.Catalog.Content
{
    /// <summary>
    /// The compiled content registry: every hand-authored content entry, aggregated from the
    /// per-module, per-family sources (<c>Content/&lt;Module&gt;/{Queries,Commands,Dtos}.cs</c>), and
    /// keyed by <c>clrType</c> for merge-time lookup. No file I/O at runtime — the content is
    /// type-checked C#. Adding a module's content means adding its three source files here.
    /// </summary>
    public static class CatalogContent
    {
        /// <summary>All content entries, in authoring order (module by module, en-first text).</summary>
        public static readonly IReadOnlyList<ContentEntry> Entries =
        [
            .. Inventory.Queries.Entries,
            .. Inventory.Commands.Entries,
            .. Inventory.Dtos.Entries,
            .. Sales.Queries.Entries,
            .. Sales.Commands.Entries,
            .. Sales.Dtos.Entries,
        ];

        /// <summary>Content keyed by <see cref="ContentEntry.ClrType"/> (case-insensitive), for <c>ContentMerger.Apply</c>.</summary>
        public static readonly IReadOnlyDictionary<string, ContentEntry> ByClrType =
            Entries.ToDictionary(e => e.ClrType, StringComparer.OrdinalIgnoreCase);
    }
}
