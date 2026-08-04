using Monitor.API.Infrastructure;
using MonitorErpMcp.Catalog.Content;
using MonitorErpMcp.Catalog.Extraction;
using MonitorErpMcp.Catalog.Search;

namespace MonitorErpMcp.Server
{
    /// <summary>
    /// Builds the materialized, merged, and indexed catalog once at startup by reflecting over the
    /// pinned <c>MonitorG5.Api</c> assembly and applying the hand-authored content by <c>clrType</c>.
    /// Tools are thin adapters over <see cref="Index"/>.
    /// </summary>
    public sealed class CatalogService
    {
        public CatalogService()
        {
            var assembly = typeof(ApiEntityAttribute).Assembly;
            var structural = CatalogMapper.MapAssembly(assembly);
            Index = new CatalogIndex(ContentMerger.Apply(structural, CatalogContent.ByClrType));
        }

        /// <summary>The materialized catalog: records, search, and module listing.</summary>
        public CatalogIndex Index { get; }
    }
}
