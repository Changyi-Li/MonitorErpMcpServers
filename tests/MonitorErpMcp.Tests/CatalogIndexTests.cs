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

        [Fact]
        public void GetByClrType_ResolvesQueryAndCommand()
        {
            Assert.Equal("api/v1/Inventory/Parts", Index.GetByClrType("Monitor.API.Inventory.Part")!.Route);
            Assert.Equal(
                "api/v1/Inventory/Parts/Create",
                Index.GetByClrType("Monitor.API.Inventory.Commands.Parts.CreatePart")!.Route);
        }

        [Fact]
        public void GetByClrType_IsCaseInsensitive()
        {
            Assert.Equal("api/v1/Inventory/Parts", Index.GetByClrType("monitor.api.inventory.part")!.Route);
        }

        [Fact]
        public void GetByPath_ResolvesWithOrWithoutPrefix()
        {
            Assert.Equal("Monitor.API.Inventory.Part", Index.GetByPath("api/v1/Inventory/Parts")!.ClrType);
            Assert.Equal("Monitor.API.Inventory.Part", Index.GetByPath("Inventory/Parts")!.ClrType);
            Assert.Equal("Monitor.API.Inventory.Part", Index.GetByPath("/api/v1/inventory/parts")!.ClrType);
            Assert.Equal("Monitor.API.Inventory.Part", Index.GetByPath("api/v1/Inventory/Parts/")!.ClrType);
            Assert.Equal(
                "Monitor.API.Inventory.Commands.Parts.CreatePart",
                Index.GetByPath("api/v1/Inventory/Parts/Create")!.ClrType);
        }

        [Fact]
        public void GetByPath_RejectsNameAsKey()
        {
            // A record's display name collides across records and is never an addressable path.
            Assert.Null(Index.GetByPath("Parts"));
            Assert.Null(Index.GetByPath("Customers"));
            Assert.Null(Index.GetByClrType("Parts"));
        }

        [Fact]
        public void GetByKey_UnknownKey_ReturnsNull()
        {
            Assert.Null(Index.GetByClrType("Monitor.API.No.Such.Type"));
            Assert.Null(Index.GetByPath("api/v1/No/SuchRoute"));
            Assert.Null(Index.GetByPath("api/v1"));
        }

        [Fact]
        public void Search_ExcludesDtoRecords()
        {
            // Dto records are reached via their parents and are never directly searchable.
            Assert.Equal(0, Index.Search("ArrivalLocation").Total);
            Assert.Equal(0, Index.Search("SetComment").Total);
            Assert.Equal(0, Index.Search("ArrivalRow").Total);
        }

        [Fact]
        public void GetByClrType_ResolvesDtoRecords()
        {
            var arrivalLocation = Index.GetByClrType("Monitor.API.Purchase.Commands.ArrivalReporting.ArrivalLocation");
            Assert.NotNull(arrivalLocation);
            Assert.Equal(RecordType.Dto, arrivalLocation!.Type);
            Assert.Equal("ArrivalLocation", arrivalLocation.Name);
            Assert.NotEmpty(arrivalLocation.Fields);
        }

        [Fact]
        public void GetByPath_NeverResolvesDtoRecords()
        {
            // A dto record has no HTTP route, so no path resolves to one.
            Assert.Null(Index.GetByPath("ArrivalLocation"));
            Assert.Equal(
                RecordType.Command,
                Index.GetByPath("Purchase/PurchaseOrders/ReportArrivals")!.Type);
        }

        [Fact]
        public void Expand_Full_InlinesDtoFieldsAndKeepsRefClrType()
        {
            var reportArrival = Index.GetByClrType("Monitor.API.Purchase.Commands.ArrivalReporting.ReportArrival")!;
            var expanded = Index.Expand(reportArrival, int.MaxValue);

            var rows = expanded.Fields.Single(f => f.Name == "Rows");
            Assert.Equal(FieldKind.Dto, rows.Kind);
            Assert.Equal("array", rows.JsonType);
            Assert.Equal("Monitor.API.Purchase.Commands.ArrivalReporting.ArrivalRow", rows.RefClrType);
            Assert.NotNull(rows.Inline); // array of dtos inlines the element shape

            var arrivalRow = rows.Inline!.Single(f => f.Name == "Locations");
            Assert.Equal("array", arrivalRow.JsonType);
            Assert.Equal("Monitor.API.Purchase.Commands.ArrivalReporting.ArrivalLocation", arrivalRow.RefClrType);
            Assert.NotNull(arrivalRow.Inline);
        }

        [Fact]
        public void Expand_Zero_ReturnsRefsOnly()
        {
            var reportArrival = Index.GetByClrType("Monitor.API.Purchase.Commands.ArrivalReporting.ReportArrival")!;
            var expanded = Index.Expand(reportArrival, 0);

            var rows = expanded.Fields.Single(f => f.Name == "Rows");
            Assert.Equal(FieldKind.Dto, rows.Kind);
            Assert.Equal("Monitor.API.Purchase.Commands.ArrivalReporting.ArrivalRow", rows.RefClrType);
            Assert.Null(rows.Inline);
        }

        [Fact]
        public void Expand_Depth_ControlsInlining()
        {
            var reportArrival = Index.GetByClrType("Monitor.API.Purchase.Commands.ArrivalReporting.ReportArrival")!;

            // One level: Rows' items are inlined, but their dto subfield (Locations) is refs-only.
            var depth1 = Index.Expand(reportArrival, 1);
            var rows1 = depth1.Fields.Single(f => f.Name == "Rows");
            Assert.NotNull(rows1.Inline);
            Assert.Null(rows1.Inline!.Single(f => f.Name == "Locations").Inline);

            // Two levels: Locations' items are inlined too.
            var depth2 = Index.Expand(reportArrival, 2);
            var rows2 = depth2.Fields.Single(f => f.Name == "Rows");
            Assert.NotNull(rows2.Inline!.Single(f => f.Name == "Locations").Inline);
        }

        [Fact]
        public void Expand_Full_ReportMeasuring_StaysBoundedAndComplete()
        {
            // The spec's worst-case tree is genuinely ~2K tokens, so a faithful 10K budget leaves it
            // complete with no size-guard note.
            var reportMeasuring = Index.GetByClrType("Monitor.API.Manufacturing.Commands.MeasuringReportings.ReportMeasuring")!;
            var expanded = Index.Expand(reportMeasuring, int.MaxValue);

            Assert.Null(expanded.ExpandNote);
            var reporting = expanded.Fields.Single(f => f.Name == "Reporting");
            Assert.Equal(FieldKind.Dto, reporting.Kind);
            Assert.NotNull(reporting.Inline);
        }

        [Fact]
        public void Expand_Full_OversizedRecord_TruncatesWithNote()
        {
            // Customer's response exceeds the 10K budget even without dto expansion (a wide record),
            // so the size guard reports refs-only with a truthful note.
            var customer = Index.GetByClrType("Monitor.API.Sales.Customer")!;
            var expanded = Index.Expand(customer, int.MaxValue);

            Assert.Equal("truncated at depth 0 (size guard)", expanded.ExpandNote);
        }
    }
}
