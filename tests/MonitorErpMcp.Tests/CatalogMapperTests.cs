using Monitor.API.Infrastructure;
using MonitorErpMcp.Catalog.Extraction;
using MonitorErpMcp.Catalog.Model;

namespace MonitorErpMcp.Tests
{
    /// <summary>
    /// Seam A: mapping correctness of the reflection boundary over the pinned MonitorG5.Api assembly.
    /// </summary>
    public class CatalogMapperTests
    {
        private static readonly IReadOnlyList<CatalogRecord> Records =
            CatalogMapper.MapAssembly(typeof(ApiEntityAttribute).Assembly);

        [Fact]
        public void Census_Matches_FixedQueryAndCommandCounts()
        {
            Assert.Equal(348, Records.Count(r => r.Type == RecordType.Query));
            Assert.Equal(716, Records.Count(r => r.Type == RecordType.Command));
            Assert.Equal(1064, Records.Count);
        }

        [Fact]
        public void NoRecordCarriesTheInternalModule()
        {
            Assert.DoesNotContain(Records, r => r.Module == "Internal");
        }

        [Fact]
        public void InventoryPartsQuery_CarriesItsDerivedIdentity()
        {
            var part = Assert.Single(Records, r => r.Type == RecordType.Query && r.Module == "Inventory" && r.Name == "Parts");
            Assert.Equal("Monitor.API.Inventory.Part", part.ClrType);
            Assert.Equal("api/v1/Inventory/Parts", part.Route);
            Assert.Equal("GET", part.Method);
            Assert.Null(part.FullPath);
            Assert.NotNull(part.Description);
            Assert.Equal(string.Empty, part.Description.En);
            Assert.Equal(string.Empty, part.Description.Zh);
        }

        [Fact]
        public void CreatePartCommand_CarriesFullPathAndPostRoute()
        {
            var create = Assert.Single(Records, r => r.Type == RecordType.Command && r.FullPath == "Inventory/Parts/Create");
            Assert.Equal("Monitor.API.Inventory.Commands.Parts.CreatePart", create.ClrType);
            Assert.Equal("api/v1/Inventory/Parts/Create", create.Route);
            Assert.Equal("POST", create.Method);
            Assert.Equal("Create", create.Name);
        }

        [Fact]
        public void EveryRecord_CarriesIdentityFields()
        {
            Assert.All(Records, r =>
            {
                Assert.False(string.IsNullOrWhiteSpace(r.Module), $"module of {r.ClrType}");
                Assert.False(string.IsNullOrWhiteSpace(r.ClrType));
                Assert.False(string.IsNullOrWhiteSpace(r.Name), $"name of {r.ClrType}");
                Assert.StartsWith("api/v1/", r.Route);
                Assert.NotNull(r.Description);
            });
        }
    }
}
