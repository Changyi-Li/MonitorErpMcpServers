using Monitor.API.Infrastructure;
using MonitorErpMcp.Catalog.Extraction;
using MonitorErpMcp.Catalog.Search;

namespace MonitorErpMcp.Server
{
    /// <summary>
    /// Builds the materialized and indexed catalog once at startup by reflecting over the pinned
    /// <c>MonitorG5.Api</c> assembly. Tools are thin adapters over <see cref="Index"/>.
    /// </summary>
    public sealed class CatalogService
    {
        public CatalogService()
        {
            var assembly = typeof(ApiEntityAttribute).Assembly;
            Index = new CatalogIndex(CatalogMapper.MapAssembly(assembly));
        }

        /// <summary>The materialized catalog: records, search, and module listing.</summary>
        public CatalogIndex Index { get; }
    }
}
