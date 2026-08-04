using Microsoft.Extensions.DependencyInjection;
using ModelContextProtocol;
using ModelContextProtocol.Protocol;
using ModelContextProtocol.Server;
using Moq;
using MonitorErpMcp.Catalog.Model;
using MonitorErpMcp.Server;
using MonitorErpMcp.Server.Tools;
using System.Reflection;
using System.Text.Json;

namespace MonitorErpMcp.Tests
{
    /// <summary>
    /// Seam B: the MCP-visible tool contract — envelopes, defaults, filters, read-only-ness, and the
    /// structured-content-plus-JSON-text-fallback shape. Tool handlers are invoked directly (no transport).
    /// </summary>
    public class MonitorApiToolsTests
    {
        private static readonly CatalogService Catalog = new();
        private static readonly ServiceProvider Services =
            new ServiceCollection().AddSingleton(Catalog).BuildServiceProvider();

        private static McpServerTool CreateTool(string methodName) =>
            McpServerTool.Create(
                typeof(MonitorApiTools).GetMethod(methodName, BindingFlags.Public | BindingFlags.Static)!,
                options: new McpServerToolCreateOptions { Services = Services });

        private static async Task<CallToolResult> CallAsync(McpServerTool tool, params (string Key, object? Value)[] args)
        {
            var jsonArgs = args.ToDictionary(a => a.Key, a => JsonSerializer.SerializeToElement(a.Value));
            var request = new RequestContext<CallToolRequestParams>(
                new Mock<McpServer>().Object,
                new JsonRpcRequest { Id = new RequestId("test"), Method = "tools/call" },
                new CallToolRequestParams { Name = tool.ProtocolTool.Name, Arguments = jsonArgs })
            {
                Services = Services,
            };
            return await tool.InvokeAsync(request, CancellationToken.None);
        }

        [Fact]
        public void Search_ReturnsEnvelopeWithDefaults()
        {
            var result = MonitorApiTools.Search(Catalog, "part");

            Assert.Equal(114, result.Total);
            Assert.Equal(0, result.Offset);
            Assert.Equal(10, result.Limit);
            Assert.Equal(10, result.Results.Count);
        }

        [Fact]
        public void Search_Part_ReturnsTheInventoryPartsQuery()
        {
            var result = MonitorApiTools.Search(Catalog, "part");

            Assert.Contains(result.Results, r =>
                r.Type == "query"
                && r.Module == "Inventory"
                && r.Name == "Parts"
                && r.Route == "api/v1/Inventory/Parts"
                && r.Method == "GET"
                && r.FullPath is null);
        }

        [Fact]
        public void Search_RespectsLimitAndOffset()
        {
            var result = MonitorApiTools.Search(Catalog, "part", limit: 5, offset: 10);

            Assert.Equal(114, result.Total);
            Assert.Equal(10, result.Offset);
            Assert.Equal(5, result.Limit);
            Assert.Equal(5, result.Results.Count);
        }

        [Fact]
        public void Search_OutOfRangeLimit_ThrowsMcpException()
        {
            Assert.Throws<McpException>(() => MonitorApiTools.Search(Catalog, "part", limit: 0));
            Assert.Throws<McpException>(() => MonitorApiTools.Search(Catalog, "part", limit: 51));
            Assert.Throws<McpException>(() => MonitorApiTools.Search(Catalog, "part", offset: -1));
        }

        [Fact]
        public void Search_TypeAndModuleFilters_NarrowResults()
        {
            var result = MonitorApiTools.Search(Catalog, "parts", type: "query", module: "Inventory");

            Assert.Equal(1, result.Total);
            var part = Assert.Single(result.Results);
            Assert.Equal("query", part.Type);
            Assert.Equal("Inventory", part.Module);
        }

        [Fact]
        public void Search_EachHitCarriesFullIdentity()
        {
            var result = MonitorApiTools.Search(Catalog, "create", type: "command", module: "Inventory");

            var create = Assert.Single(result.Results, r => r.FullPath == "Inventory/Parts/Create");
            Assert.Equal("command", create.Type);
            Assert.Equal("Inventory", create.Module);
            Assert.Equal("Monitor.API.Inventory.Commands.Parts.CreatePart", create.ClrType);
            Assert.Equal("Create", create.Name);
            Assert.Equal("api/v1/Inventory/Parts/Create", create.Route);
            Assert.Equal("POST", create.Method);
            Assert.Equal("Inventory/Parts/Create", create.FullPath);
            Assert.Equal(string.Empty, create.Description.En);
            Assert.Equal(string.Empty, create.Description.Zh);
        }

        [Fact]
        public void Search_InvalidTypeFilter_ThrowsMcpException()
        {
            var ex = Assert.Throws<McpException>(() => MonitorApiTools.Search(Catalog, "part", type: "dto"));
            Assert.Contains("query", ex.Message);
            Assert.Contains("command", ex.Message);
        }

        [Fact]
        public void ListModules_ReturnsAllEightAreasWithoutInternal()
        {
            var result = MonitorApiTools.ListModules(Catalog);

            Assert.Equal(8, result.Modules.Count);
            Assert.Equal(
                ["Common", "Sales", "Purchase", "Inventory", "Manufacturing", "Accounting", "TimeRecording", "MQ"],
                result.Modules.Select(m => m.Module));
            Assert.DoesNotContain(result.Modules, m => m.Module == "Internal");
            Assert.Equal(113, result.Modules[0].QueryCount);
            Assert.Equal(173, result.Modules[0].CommandCount);
        }

        [Fact]
        public void BothTools_AreReadOnly()
        {
            Assert.True(CreateTool(nameof(MonitorApiTools.Search)).ProtocolTool.Annotations?.ReadOnlyHint);
            Assert.True(CreateTool(nameof(MonitorApiTools.ListModules)).ProtocolTool.Annotations?.ReadOnlyHint);
        }

        [Fact]
        public void Search_AdvertisesOutputSchemaAndRequiredKeyword()
        {
            var tool = CreateTool(nameof(MonitorApiTools.Search));

            Assert.NotNull(tool.ProtocolTool.OutputSchema);
            var inputSchema = tool.ProtocolTool.InputSchema;
            Assert.Contains("keyword", inputSchema.GetProperty("required").EnumerateArray().Select(e => e.GetString()));
            Assert.Contains("limit", inputSchema.GetProperty("properties").EnumerateObject().Select(p => p.Name));
            Assert.Contains("offset", inputSchema.GetProperty("properties").EnumerateObject().Select(p => p.Name));
        }

        [Fact]
        public async Task Search_ReturnsStructuredContentAndJsonTextFallback()
        {
            var tool = CreateTool(nameof(MonitorApiTools.Search));
            var call = await CallAsync(tool, ("keyword", "part"));

            Assert.NotNull(call.StructuredContent);
            var text = Assert.Single(call.Content, c => c.Type == "text");
            var payload = JsonSerializer.Deserialize<MonitorApiSearchResponse>(
                ((TextContentBlock)text).Text,
                new JsonSerializerOptions(JsonSerializerDefaults.Web));
            Assert.Equal(114, payload!.Total);
            Assert.Equal(10, payload.Results.Count);
        }

        [Fact]
        public async Task ListModules_ReturnsStructuredContentAndJsonTextFallback()
        {
            var tool = CreateTool(nameof(MonitorApiTools.ListModules));
            var call = await CallAsync(tool);

            Assert.NotNull(call.StructuredContent);
            Assert.Single(call.Content, c => c.Type == "text");
        }
    }
}
