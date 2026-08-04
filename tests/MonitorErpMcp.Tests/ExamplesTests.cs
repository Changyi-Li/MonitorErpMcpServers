using Monitor.API.Infrastructure;
using MonitorErpMcp.Catalog.Content;
using MonitorErpMcp.Catalog.Extraction;
using MonitorErpMcp.Catalog.Model;
using MonitorErpMcp.Catalog.Search;
using MonitorErpMcp.Server;
using MonitorErpMcp.Server.Tools;
using System.Collections;
using System.Text.Json;

namespace MonitorErpMcp.Tests
{
    /// <summary>
    /// Seam A + B: the examples tier — a derived or authored many example on every batchable command,
    /// curated query/command examples with the correct kind, and the canonical CreateCustomer batch
    /// chain, all surfaced through monitor_api_get_record.
    /// </summary>
    public class ExamplesTests
    {
        private static readonly CatalogIndex Merged =
            new(ContentMerger.Apply(CatalogMapper.MapAssembly(typeof(ApiEntityAttribute).Assembly), CatalogContent.ByClrType));

        private static readonly CatalogService Catalog = new();

        [Fact]
        public void EveryBatchableCommand_CarriesAManyExample_WithDistinctElementsAndBilingualExplanation()
        {
            var batchable = Merged.Records.Where(r => r.Type == RecordType.Command && r.Batchable).ToList();
            Assert.NotEmpty(batchable);

            Assert.All(batchable, command =>
            {
                var many = Assert.Single(command.Examples, e => e.Kind == ExampleKind.Many);
                Assert.Equal(ExampleKind.Many, many.Kind);
                Assert.False(string.IsNullOrWhiteSpace(many.Explanation.En), $"{command.ClrType} many en");
                Assert.False(string.IsNullOrWhiteSpace(many.Explanation.Zh), $"{command.ClrType} many zh");
                Assert.StartsWith("api/v1/", many.Route);
                Assert.EndsWith("/Many", many.Route, StringComparison.Ordinal);

                if (command.Fields.Count == 0)
                {
                    // A command with no request inputs honestly repeats two empty bodies; nothing to vary.
                    var empty = (object[])many.Request!;
                    Assert.Equal(2, empty.Length);
                    Assert.All(empty, e => Assert.Equal("{}", JsonSerializer.Serialize(e)));
                }
                else
                {
                    Assert.True(HasDistinctElements(many), $"{command.ClrType} many elements must differ");
                }
            });
        }

        [Fact]
        public void NonBatchableCommands_DoNotCarryAManyExample()
        {
            Assert.All(
                Merged.Records.Where(r => r.Type == RecordType.Command && !r.Batchable),
                c => Assert.DoesNotContain(c.Examples, e => e.Kind == ExampleKind.Many));
        }

        [Fact]
        public void QueriesAndDtos_CarryNoManyOrBatchExamples()
        {
            Assert.All(Merged.Records.Where(r => r.Type == RecordType.Query), q =>
                Assert.DoesNotContain(q.Examples, e => e.Kind is ExampleKind.Many or ExampleKind.Batch));
            Assert.All(Merged.Records.Where(r => r.Type == RecordType.Dto), d => Assert.Empty(d.Examples));
        }

        [Fact]
        public void CuratedExamples_CarryTheCorrectKind()
        {
            // A query record carries a query example; a command record carries command examples.
            var parts = Merged.GetByClrType("Monitor.API.Inventory.Part")!;
            Assert.Contains(parts.Examples, e => e.Kind == ExampleKind.Query);
            Assert.DoesNotContain(parts.Examples, e => e.Kind == ExampleKind.Command);

            var createPart = Merged.GetByClrType("Monitor.API.Inventory.Commands.Parts.CreatePart")!;
            Assert.Contains(createPart.Examples, e => e.Kind == ExampleKind.Command);
        }

        [Fact]
        public void AuthoredManyExample_OverridesTheDerivedScaffold()
        {
            var createPart = Merged.GetByClrType("Monitor.API.Inventory.Commands.Parts.CreatePart")!;

            var many = Assert.Single(createPart.Examples, e => e.Kind == ExampleKind.Many);
            // The authored title and route are used, not the generic derived scaffold's.
            Assert.Equal("Create several parts", many.Title.En);
            Assert.Equal("api/v1/Inventory/Parts/Create/Many", many.Route);
            Assert.True(HasDistinctElements(many));
        }

        [Fact]
        public void CreateCustomer_CarriesTheCanonicalBatchChainExample()
        {
            var createCustomer = Merged.GetByClrType("Monitor.API.Sales.Commands.Customers.CreateCustomer")!;

            var batch = Assert.Single(createCustomer.Examples, e => e.Kind == ExampleKind.Batch);
            Assert.Equal(4, batch.Steps!.Count);
            Assert.Equal(
                ["api/v1/Sales/Customers/Create", "api/v1/Sales/Customers/AddReference", "api/v1/Sales/Customers/SetProperties", "api/v1/Sales/Customers"],
                batch.Steps.Select(s => s.Route));
            Assert.Contains("RootEntityId", batch.Explanation.En);
            Assert.Contains("RootEntityId", batch.Explanation.Zh);
        }

        [Fact]
        public void GetRecord_SurfacesExamples_AtSeamB()
        {
            var result = MonitorApiTools.GetRecord(Catalog, clrType: "Monitor.API.Sales.Commands.Customers.CreateCustomer");

            Assert.NotEmpty(result.Examples);
            var batch = Assert.Single(result.Examples, e => e.Kind == "batch");
            Assert.Equal(4, batch.Steps!.Count);

            var part = MonitorApiTools.GetRecord(Catalog, clrType: "Monitor.API.Inventory.Part");
            var query = Assert.Single(part.Examples, e => e.Kind == "query");
            Assert.Equal("GET", query.Method);
            Assert.Equal("api/v1/Inventory/Parts", query.Route);
            Assert.Contains("$filter", query.Query);
        }

        [Fact]
        public void GetRecord_ExposesDerivedManyExample_AtSeamB()
        {
            // A batchable command with a curated command example but no authored many carries the
            // derived "many" example on the wire.
            var result = MonitorApiTools.GetRecord(Catalog, clrType: "Monitor.API.Inventory.Commands.Parts.MoveStockBalance");

            var many = Assert.Single(result.Examples, e => e.Kind == "many");
            Assert.EndsWith("/Many", many.Route, StringComparison.Ordinal);
            Assert.Equal("POST", many.Method);
        }

        [Fact]
        public void DerivedMany_ReusesTheCuratedCommandRequestAsElement1()
        {
            // MoveStockBalance has a curated command example but no authored many: the derived many's
            // element 1 is the curated request (only the fields it set), not the full scaffold.
            var move = Merged.GetByClrType("Monitor.API.Inventory.Commands.Parts.MoveStockBalance")!;
            var many = Assert.Single(move.Examples, e => e.Kind == ExampleKind.Many);

            var element1 = PropertyNames(((object[])many.Request!)[0]).ToList();
            Assert.Contains("PartId", element1);
            Assert.DoesNotContain("UnitId", element1); // curated request omitted this optional field
        }

        [Fact]
        public void CuratedExampleFields_ExistOnTheRecord()
        {
            // The catalog's examples are verifiable by reflection, so every field an example sets
            // must be a real field of the record it calls — an invented field would mislead the agent.
            foreach (var record in Merged.Records)
            {
                var fieldNames = record.Fields.Select(f => f.Name).ToHashSet(StringComparer.Ordinal);
                foreach (var example in record.Examples)
                {
                    switch (example.Kind)
                    {
                        case ExampleKind.Command:
                            AssertBodyKeys(record.ClrType, fieldNames, example.Request);
                            break;
                        case ExampleKind.Query:
                            AssertQueryResponseKeys(record.ClrType, fieldNames, example.Response);
                            break;
                        case ExampleKind.Batch:
                            Assert.All(example.Steps!, step =>
                            {
                                var target = Merged.GetByPath(step.Route);
                                Assert.NotNull(target);
                                AssertBodyKeys(step.Route, target.Fields.Select(f => f.Name).ToHashSet(StringComparer.Ordinal), step.Request);
                            });
                            break;
                    }
                }
            }
        }

        private static void AssertBodyKeys(string label, ISet<string> fieldNames, object? request)
        {
            foreach (var key in PropertyNames(request))
            {
                Assert.True(fieldNames.Contains(key), $"{label} example uses unknown field '{key}'");
            }
        }

        private static void AssertQueryResponseKeys(string label, ISet<string> fieldNames, object? response)
        {
            // A query response is the OData envelope { value: [ ... ] }; check the first element.
            var value = response?.GetType().GetProperty("value")?.GetValue(response) as IEnumerable;
            AssertBodyKeys(label, fieldNames, value?.Cast<object>().FirstOrDefault());
        }

        /// <summary>The top-level property names of an example request/response body (anonymous object or dictionary).</summary>
        private static IEnumerable<string> PropertyNames(object? value)
        {
            if (value is null)
            {
                return [];
            }

            if (value is IDictionary dictionary)
            {
                return dictionary.Keys.Cast<object>().Select(k => k.ToString()!);
            }

            return value.GetType().GetProperties().Select(p => p.Name);
        }

        /// <summary>A many example's request is an array whose two elements serialize differently.</summary>
        private static bool HasDistinctElements(CatalogExample many)
        {
            var request = (object[])many.Request!;
            return request.Length >= 2
                && JsonSerializer.Serialize(request[0]) != JsonSerializer.Serialize(request[1]);
        }
    }
}
