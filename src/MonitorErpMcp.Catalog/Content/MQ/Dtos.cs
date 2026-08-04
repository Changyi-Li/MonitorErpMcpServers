namespace MonitorErpMcp.Catalog.Content.MQ
{
    /// <summary>
    /// Hand-authored content for MQ dto records. The MQ area exposes no dto records in the pinned
    /// assembly, so this family is empty; the file exists to keep the per-area
    /// <c>Content/&lt;Module&gt;/{Queries,Commands,Dtos}.cs</c> structure uniform.
    /// </summary>
    public static class Dtos
    {
        /// <summary>Hand-authored entries for this family, merged by <c>clrType</c> onto the structural catalog.</summary>
        public static readonly ContentEntry[] Entries = [];
    }
}
