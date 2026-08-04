using Monitor.API.Infrastructure;
using MonitorErpMcp.Catalog.Extraction;
using MonitorErpMcp.Catalog.Model;
using MonitorErpMcp.Catalog.Search;

namespace MonitorErpMcp.Tests
{
    /// <summary>
    /// Seam A: search, filtering, pagination, and module listing over the materialized catalog.
    /// </summary>
    public class CatalogIndexTests
    {
        private static readonly CatalogIndex Index = new(CatalogMapper.MapAssembly(typeof(ApiEntityAttribute).Assembly));

        [Fact]
        public void Search_Part_ReturnsTheInventoryPartsQueryWithItsGetRoute()
        {
            var result = Index.Search("part");

            Assert.Equal(114, result.Total);
            Assert.Contains(result.Results, r =>
                r.Type == RecordType.Query
                && r.Module == "Inventory"
                && r.Name == "Parts"
                && r.Route == "api/v1/Inventory/Parts"
                && r.Method == "GET");
        }

        [Fact]
        public void Search_Part_RanksTheInventoryPartsQueryFirst()
        {
            var result = Index.Search("part");

            Assert.Equal("api/v1/Inventory/Parts", result.Results[0].Route);
        }

        [Fact]
        public void Search_IsCaseInsensitive()
        {
            Assert.Equal(Index.Search("part").Total, Index.Search("PART").Total);
            Assert.Equal(Index.Search("part").Total, Index.Search("Part").Total);
        }

        [Fact]
        public void Search_MatchesNameClrTypeFullPathAndRoute()
        {
            // name
            Assert.True(Index.Search("Parts").Total >= 1);
            // clrType
            Assert.True(Index.Search("Monitor.API.Inventory.Part").Total >= 1);
            // fullPath (commands only): the exact fullPath match ranks first
            var byFullPath = Index.Search("Inventory/Parts/Create");
            Assert.Equal("Inventory/Parts/Create", byFullPath.Results[0].FullPath);
            Assert.Equal("api/v1/Inventory/Parts/Create", byFullPath.Results[0].Route);
            // route
            var byRoute = Index.Search("api/v1/Inventory/Parts");
            Assert.Equal("api/v1/Inventory/Parts", byRoute.Results[0].Route);
        }

        [Fact]
        public void Search_TypeFilter_NarrowsToQueryOrCommandOnly()
        {
            var queries = Index.Search("part", type: "query");
            var commands = Index.Search("part", type: "command");

            Assert.Equal(27, queries.Total);
            Assert.Equal(87, commands.Total);
            Assert.All(queries.Results, r => Assert.Equal(RecordType.Query, r.Type));
            Assert.All(commands.Results, r => Assert.Equal(RecordType.Command, r.Type));
        }

        [Fact]
        public void Search_ModuleFilter_NarrowsToThatBusinessArea()
        {
            var result = Index.Search("parts", module: "Inventory");
            Assert.All(result.Results, r => Assert.Equal("Inventory", r.Module));
        }

        [Fact]
        public void Search_ModuleFilter_IsCaseInsensitive()
        {
            Assert.Equal(
                Index.Search("parts", module: "Inventory").Total,
                Index.Search("parts", module: "inventory").Total);
        }

        [Fact]
        public void Search_TypeAndModuleFilters_Combine()
        {
            var result = Index.Search("parts", type: "query", module: "Inventory");

            Assert.Equal(1, result.Total);
            var part = Assert.Single(result.Results);
            Assert.Equal(RecordType.Query, part.Type);
            Assert.Equal("api/v1/Inventory/Parts", part.Route);
        }

        [Fact]
        public void Search_InvalidTypeFilter_Throws()
        {
            Assert.Throws<ArgumentException>(() => Index.Search("part", type: "dto"));
        }

        [Fact]
        public void Search_InvalidBounds_Throw()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Index.Search("part", limit: -1));
            Assert.Throws<ArgumentOutOfRangeException>(() => Index.Search("part", offset: -1));
        }

        [Fact]
        public void Search_Pagination_IsBoundedByLimitAndOffset()
        {
            var firstPage = Index.Search("part", limit: 5, offset: 0);
            var secondPage = Index.Search("part", limit: 5, offset: 5);

            Assert.Equal(114, firstPage.Total);
            Assert.Equal(5, firstPage.Results.Count);
            Assert.Equal(5, secondPage.Results.Count);
            Assert.Equal(0, firstPage.Offset);
            Assert.Equal(5, secondPage.Offset);
            Assert.Equal(5, firstPage.Limit);
            // Pages are disjoint and stable.
            Assert.Empty(firstPage.Results.Intersect(secondPage.Results));
        }

        [Fact]
        public void Search_OffsetBeyondEnd_ReturnsEmptyPage()
        {
            var result = Index.Search("part", limit: 10, offset: 1000);
            Assert.Equal(114, result.Total);
            Assert.Empty(result.Results);
        }

        [Fact]
        public void Search_LimitLargerThanTotal_ReturnsAll()
        {
            var result = Index.Search("part", limit: 1000);
            Assert.Equal(114, result.Total);
            Assert.Equal(114, result.Results.Count);
        }

        [Fact]
        public void ListModules_ReturnsEightAreas_InternalAbsent()
        {
            var modules = Index.ListModules();

            Assert.Equal(8, modules.Count);
            Assert.Equal(
                ["Common", "Sales", "Purchase", "Inventory", "Manufacturing", "Accounting", "TimeRecording", "MQ"],
                modules.Select(m => m.Module));
            Assert.DoesNotContain(modules, m => m.Module == "Internal");
        }

        [Fact]
        public void ListModules_Counts_MatchTheFixedCensus()
        {
            var modules = Index.ListModules().ToDictionary(m => m.Module);

            Assert.Equal((113, 173), (modules["Common"].QueryCount, modules["Common"].CommandCount));
            Assert.Equal((64, 180), (modules["Sales"].QueryCount, modules["Sales"].CommandCount));
            Assert.Equal((49, 125), (modules["Inventory"].QueryCount, modules["Inventory"].CommandCount));
            Assert.Equal((42, 42), (modules["Accounting"].QueryCount, modules["Accounting"].CommandCount));
            Assert.Equal((0, 1), (modules["MQ"].QueryCount, modules["MQ"].CommandCount));

            Assert.Equal(348, modules.Values.Sum(m => m.QueryCount));
            Assert.Equal(716, modules.Values.Sum(m => m.CommandCount));
        }
    }
}
