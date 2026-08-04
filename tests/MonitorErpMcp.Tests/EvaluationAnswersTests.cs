using MonitorErpMcp.Server;
using MonitorErpMcp.Server.Tools;

namespace MonitorErpMcp.Tests
{
    /// <summary>
    /// Locks the ten answers of <c>docs/evaluation/evaluation.xml</c> against the pinned assembly
    /// (issue #29): each pair's answer was verified by reflection over <c>MonitorG5.Api</c> 26.3.11.2189,
    /// and these assertions make that verification reproducible — a catalog drift that changes any
    /// answer fails the suite. The tool handlers are invoked directly (seam B), the same surface an
    /// LLM uses over stdio.
    /// </summary>
    public class EvaluationAnswersTests
    {
        private static readonly CatalogService Catalog = new();

        // Q1 — The response of the parts list query includes exactly one field that must be unique
        // across all parts and is limited to at most 20 characters. What is that field called?
        [Fact]
        public void Pair01_UniqueMaxLength20Field_IsPartNumber()
        {
            var record = MonitorApiTools.GetRecord(Catalog, clrType: "Monitor.API.Inventory.Part");

            var uniqueMax20 = record.Fields.Where(f => f.Unique && f.MaxLength == 20).Select(f => f.Name).ToList();
            Assert.Equal(["PartNumber"], uniqueMax20);
        }

        // Q2 — ... Each location can instead name a brand-new part location that does not yet exist.
        // What is the exact documented condition under which the location's name field is mandatory?
        [Fact]
        public void Pair02_PartLocationName_MandatoryWhenNewLocation()
        {
            var record = MonitorApiTools.GetRecord(
                Catalog,
                clrType: "Monitor.API.Purchase.Commands.ArrivalReporting.ArrivalLocation");

            var name = record.Fields.Single(f => f.Name == "PartLocationName");
            Assert.True(name.Mandatory);
            Assert.Equal("If reporting to a new location.", name.MandatoryWhen);
        }

        // Q3 — Searching "upload" returns two Common commands; one transmits the file as a raw byte
        // stream over multipart/form-data. What is that command's display name?
        [Fact]
        public void Pair03_MultipartFormUploadCommand_IsUploadFileStream()
        {
            var search = MonitorApiTools.Search(Catalog, "upload");

            Assert.Equal(2, search.Total); // exactly the two Common file-upload commands
            Assert.All(search.Results, r => Assert.Equal("Common", r.Module));

            var multipart = search.Results
                .Select(r => MonitorApiTools.GetRecord(Catalog, clrType: r.ClrType))
                .Single(r => r.MultipartForm);

            Assert.Equal("UploadFileStream", multipart.Name);
        }

        // Q4 — The parts list query returns a PackagingType enum. What is the numeric value of the
        // member that denotes goods packed on European pallets?
        [Fact]
        public void Pair04_EurPalletsEnumValue_EqualsTwo()
        {
            var record = MonitorApiTools.GetRecord(Catalog, clrType: "Monitor.API.Inventory.Part");

            var packaging = record.Fields.Single(f => f.Name == "PackagingType").Enum!;
            Assert.Equal(2, packaging.Values.Single(v => v.Name == "EurPallets").Value);
        }

        // Q5 — The parts list query lists the commands that can operate on the Part entity. How many
        // such related commands are listed?
        [Fact]
        public void Pair05_PartRelatedCommandCount_EqualsSixtyThree()
        {
            var record = MonitorApiTools.GetRecord(Catalog, clrType: "Monitor.API.Inventory.Part");

            Assert.Equal(63, record.RelatedCommands.Count);
        }

        // Q6 — The catalog groups operations into eight business areas. Which area carries the most
        // command records? Answer with the module name.
        [Fact]
        public void Pair06_ModuleWithMostCommands_IsSales()
        {
            var modules = MonitorApiTools.ListModules(Catalog).Modules;

            var max = modules.MaxBy(m => m.CommandCount)!;
            Assert.Equal("Sales", max.Module);
            Assert.Equal(180, max.CommandCount);
        }

        // Q7 — Searching the catalog with the Chinese word 物料 ... What is the display name of the
        // top search result?
        [Fact]
        public void Pair07_ChineseAliasSearch_TopResultIsParts()
        {
            var result = MonitorApiTools.Search(Catalog, "物料");

            Assert.Equal("Parts", result.Results[0].Name);
        }

        // Q8 — The part list query became available in version 2.18, and the command that creates a
        // part was introduced later. What version introduced the create-part command?
        [Fact]
        public void Pair08_CreatePartAvailableSince_EqualsTwoPointTwentyNine()
        {
            Assert.Equal("2.18", MonitorApiTools.GetRecord(Catalog, clrType: "Monitor.API.Inventory.Part").AvailableSince);
            Assert.Equal(
                "2.29",
                MonitorApiTools.GetRecord(Catalog, clrType: "Monitor.API.Inventory.Commands.Parts.CreatePart").AvailableSince);
        }

        // Q9 — The ArrivalLocation DTO is referenced by two records, including one in the
        // receiving-inspection area. What is the display name of the receiving-inspection record?
        [Fact]
        public void Pair09_ArrivalLocationUsedBy_IncludesReceivingInspectionRow()
        {
            var record = MonitorApiTools.GetRecord(
                Catalog,
                clrType: "Monitor.API.Purchase.Commands.ArrivalReporting.ArrivalLocation");

            Assert.Equal(2, record.UsedBy.Count); // the arrival row and the receiving-inspection row
            var receivingInspection = record.UsedBy.Single(
                c => c.StartsWith("Monitor.API.Purchase.Commands.ReceivingInspection.", StringComparison.Ordinal));

            Assert.Equal("ReceivingInspectionRow", MonitorApiTools.GetRecord(Catalog, clrType: receivingInspection).Name);
        }

        // Q10 — When creating one or more parts ... Is the CreatePart command batchable?
        [Fact]
        public void Pair10_CreatePart_IsBatchable()
        {
            var record = MonitorApiTools.GetRecord(
                Catalog,
                clrType: "Monitor.API.Inventory.Commands.Parts.CreatePart");

            Assert.True(record.Batchable);
        }
    }
}
