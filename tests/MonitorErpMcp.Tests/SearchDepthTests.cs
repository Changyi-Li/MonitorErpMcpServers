using Monitor.API.Infrastructure;
using MonitorErpMcp.Catalog.Content;
using MonitorErpMcp.Catalog.Extraction;
using MonitorErpMcp.Catalog.Model;
using MonitorErpMcp.Catalog.Search;

namespace MonitorErpMcp.Tests
{
    /// <summary>
    /// Seam A: search depth — token (multi-word) matching, bilingual alias and description matching,
    /// exact &gt; prefix &gt; substring ranking with the ADR-0001 tiebreak, case-insensitivity, and the
    /// no-fuzzy guarantee. Runs over the merged catalog exactly as CatalogService does, since aliases
    /// and descriptions are hand-authored content.
    /// </summary>
    public class SearchDepthTests
    {
        private static readonly CatalogIndex Index =
            new(ContentMerger.Apply(CatalogMapper.MapAssembly(typeof(ApiEntityAttribute).Assembly), CatalogContent.ByClrType));

        [Fact]
        public void MultiTokenKeyword_MatchesEveryToken_AcrossFields()
        {
            // "customer order" must match records that carry both tokens — CustomerOrders matches by
            // its name; a record holding only one token (e.g. the Customer master) must not match.
            var result = Index.Search("customer order");

            Assert.Contains(result.Results, r => r.ClrType == "Monitor.API.Sales.CustomerOrder");
            Assert.DoesNotContain(result.Results, r => r.ClrType == "Monitor.API.Sales.Customer");
            Assert.True(result.Total < Index.Search("customer").Total, "requiring a second token must narrow the result");
        }

        [Fact]
        public void MultiTokenKeyword_RanksTheEntityThatCarriesAllTokensFirst()
        {
            Assert.Equal("api/v1/Sales/CustomerOrders", Index.Search("customer order").Results[0].Route);
            Assert.Equal("api/v1/Sales/SalesPrices", Index.Search("sales price").Results[0].Route);
        }

        [Fact]
        public void MultiTokenChineseKeyword_MatchesAllTokens()
        {
            // "销售 价格" as separate tokens still resolves the SalesPrice record via its zh alias.
            Assert.Contains(Index.Search("销售 价格").Results, r => r.ClrType == "Monitor.API.Sales.SalesPrice");
        }

        [Fact]
        public void DescriptionOnlyKeyword_MatchesTheRecord()
        {
            // "demand-driven" appears only in the (Inventory) SalesForecast description — neither in
            // its name, aliases, route, nor any other record — proving descriptions are searchable.
            var result = Index.Search("demand-driven");
            var forecast = Assert.Single(result.Results);
            Assert.Equal(RecordType.Query, forecast.Type);
            Assert.Equal("Monitor.API.Inventory.SalesForecast", forecast.ClrType);
        }

        [Fact]
        public void AliasKeyword_Resolves_EnglishAndChinese()
        {
            Assert.Contains(Index.Search("price list").Results, r => r.ClrType == "Monitor.API.Sales.SalesPrice");
            Assert.Contains(Index.Search("销售价格").Results, r => r.ClrType == "Monitor.API.Sales.SalesPrice");
            Assert.Contains(Index.Search("物料").Results, r => r.ClrType == "Monitor.API.Inventory.Part");
        }

        [Fact]
        public void Matching_IsCaseInsensitive()
        {
            Assert.Equal(Index.Search("customer order").Total, Index.Search("CUSTOMER ORDER").Total);
            Assert.Equal(Index.Search("customer order").Total, Index.Search("Customer Order").Total);
        }

        [Fact]
        public void Ranking_ExactBeatsPrefixBeatsSubstring()
        {
            // "Parts" is the exact name of the Parts query and must surface before any prefix/substring hit.
            Assert.Equal("api/v1/Inventory/Parts", Index.Search("Parts").Results[0].Route);

            // "part": the Parts query exact-matches via its alias (score 0); compound names like
            // PartCodes match only as a name prefix (score 1) and follow, shortest name first.
            var part = Index.Search("part", limit: 50).Results;
            Assert.Equal("api/v1/Inventory/Parts", part[0].Route);
            Assert.Equal("api/v1/Inventory/PartCodes", part[1].Route);
            Assert.Equal("api/v1/Inventory/PartImages", part[2].Route);

            // "price": SalesPrice exact-matches via its alias "price" (score 0) and beats the
            // name-prefix match on PriceChangeLogs (score 1).
            Assert.Equal("api/v1/Sales/SalesPrices", Index.Search("price").Results[0].Route);
        }

        [Fact]
        public void Ranking_TiesBreak_QueriesBeforeCommands()
        {
            // "stock" scores identically (name prefix, 1) on the StockTransactions query and the
            // StockCount command, so the query wins the queries-before-commands tiebreak and ranks
            // before the tying command.
            var results = Index.Search("stock", limit: 50).Results.ToList();
            var stockTransactions = results.FindIndex(r => r.ClrType == "Monitor.API.Inventory.StockTransaction");
            var stockCount = results.FindIndex(r => r.ClrType == "Monitor.API.Inventory.Commands.Parts.StockCount");
            Assert.True(stockTransactions >= 0, "StockTransactions must match");
            Assert.True(stockCount > stockTransactions, "a command tying a query's score must rank after it");
        }

        [Fact]
        public void NoFuzzyMatching_NearMissReturnsNoMatch()
        {
            // Genuine near-misses: none is a literal substring of any searchable field.
            Assert.Equal(0, Index.Search("cstomer").Total);
            Assert.Equal(0, Index.Search("partz").Total);
            Assert.Equal(0, Index.Search("salesprce").Total);
        }

        [Fact]
        public void NoFuzzyMatching_MultiTokenNearMissReturnsNoMatch()
        {
            // One correct token does not rescue a misspelled second token.
            Assert.Equal(0, Index.Search("customer orderz").Total);
        }
    }
}
