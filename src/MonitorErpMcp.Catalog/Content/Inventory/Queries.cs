namespace MonitorErpMcp.Catalog.Content.Inventory
{
    // The using-static sits inside the namespace so the imported Content(...) builder binds before
    // the enclosing MonitorErpMcp.Catalog.Content namespace in simple-name lookup.
    using static MonitorErpMcp.Catalog.Content.ContentEntryFactory;
    using MonitorErpMcp.Catalog.Model;

    /// <summary>
    /// Hand-authored content for Inventory query records: bilingual descriptions and search aliases
    /// (en first, zh second), keyed by clrType and merged onto the structural catalog.
    /// </summary>
    public static class Queries
    {
        /// <summary>Hand-authored entries for this family, merged by <c>clrType</c> onto the structural catalog.</summary>
        public static readonly ContentEntry[] Entries =
        [
            Content(
                "Monitor.API.Inventory.AbcCode",
                "The ABC classification codes used to categorize parts by value and demand.",
                "按价值和需求对物料进行分类的 ABC 分类代码。",
                ["abc code", "abc classification"], ["ABC分类", "ABC代码"]),
            Content(
                "Monitor.API.Inventory.AdditionalIdsRecord",
                "The additional identifiers a part or product record can carry, alongside the main identity.",
                "物料或产品记录除主标识外可携带的附加标识。",
                ["additional id", "extra identifier"], ["附加标识", "附加ID"]),
            Content(
                "Monitor.API.Inventory.AlloyQuantity",
                "The alloy quantity declared for a part, used in alloy-aware cost and stock calculations.",
                "物料申报的合金用量，用于考虑合金的成本与库存计算。",
                ["alloy quantity"], ["合金用量"]),
            Content(
                "Monitor.API.Inventory.Alloy",
                "The alloy definitions used to declare alloy content on parts and deliveries.",
                "用于在物料和交货上申报合金含量的合金定义。",
                ["alloy", "metal content"], ["合金", "合金成分"]),
            Content(
                "Monitor.API.Inventory.CaseEntry",
                "A case entry — a structured record of a service or repair job, with its phases, activities, and costs.",
                "案例登记 —— 服务或维修作业的结构化记录，含阶段、活动与成本。",
                ["case entry", "case", "service job", "repair job"], ["案例", "案例登记", "维修作业"]),
            Content(
                "Monitor.API.Inventory.CaseEntryActivity",
                "The activities logged against a case entry, with planned and reported time.",
                "针对案例登记记录的活动，含计划与实际时间。",
                ["case entry activity", "case activity"], ["案例活动", "案例登记活动"]),
            Content(
                "Monitor.API.Inventory.CaseEntryAdditionalCost",
                "Additional costs posted against a case entry beyond its planned activities.",
                "超出计划活动之外记入案例登记的附加成本。",
                ["case additional cost", "extra cost"], ["案例附加成本"]),
            Content(
                "Monitor.API.Inventory.CaseEntryLink",
                "Links between a case entry and other records, such as a customer or an order.",
                "案例登记与其他记录（如客户或订单）之间的链接。",
                ["case entry link", "case link"], ["案例链接", "案例登记链接"]),
            Content(
                "Monitor.API.Inventory.CasePartLink",
                "The parts (materials) linked to a case entry for the job at hand.",
                "为当前作业链接到案例登记的物料。",
                ["case part link", "case material"], ["案例物料链接"]),
            Content(
                "Monitor.API.Inventory.CaseEntryPhase",
                "The phases of a case entry, e.g. inquiry, work, and follow-up.",
                "案例登记的阶段，如询价、作业与跟进。",
                ["case entry phase", "case phase"], ["案例阶段", "案例登记阶段"]),
            Content(
                "Monitor.API.Inventory.CaseManagementActivity",
                "Activities defined for case management, reused by case entries.",
                "案例管理中定义的活动，供案例登记复用。",
                ["case management activity"], ["案例管理活动"]),
            Content(
                "Monitor.API.Inventory.CaseManagementCost",
                "Costs defined for case management, reused by case entries.",
                "案例管理中定义的成本，供案例登记复用。",
                ["case management cost"], ["案例管理成本"]),
            Content(
                "Monitor.API.Inventory.CaseManagementPhase",
                "Phases defined for case management, reused by case entries.",
                "案例管理中定义的阶段，供案例登记复用。",
                ["case management phase"], ["案例管理阶段"]),
            Content(
                "Monitor.API.Inventory.CaseManagementTemplateCost",
                "Costs defined on a case management template.",
                "在案例管理模板上定义的成本。",
                ["template cost"], ["模板成本", "案例模板成本"]),
            Content(
                "Monitor.API.Inventory.CaseManagementTemplateNode",
                "Nodes (steps) in a case management template.",
                "案例管理模板中的节点（步骤）。",
                ["template node", "template step"], ["模板节点", "案例模板节点"]),
            Content(
                "Monitor.API.Inventory.CaseManagementTemplate",
                "Templates for case management that predefine the phases and activities of a case entry.",
                "案例管理模板，预定义案例登记的阶段与活动。",
                ["case management template", "case template"], ["案例管理模板", "案例模板"]),
            Content(
                "Monitor.API.Inventory.CaseManagementType",
                "The types a case entry can take in case management.",
                "案例管理中案例登记可采用的类型。",
                ["case type"], ["案例类型", "案例登记类型"]),
            Content(
                "Monitor.API.Inventory.GoodsType",
                "The goods types that classify items for customs and trade declarations.",
                "用于海关与贸易申报对货品进行分类的货物类型。",
                ["goods type", "goods"], ["货物类型", "货品类型"]),
            Content(
                "Monitor.API.Inventory.HyperLink",
                "Hyperlinks attached to a part, pointing to external documents or web resources.",
                "附加到物料上、指向外部文档或网页资源的超链接。",
                ["hyperlink", "link", "url"], ["超链接", "链接"]),
            Content(
                "Monitor.API.Inventory.Location",
                "A warehouse location where stock is stored, with its blocking and dimension information.",
                "存放库存的仓库库位，含封锁与尺寸信息。",
                ["location", "warehouse location", "bin"], ["库位", "仓库库位", "仓位"]),
            Content(
                "Monitor.API.Inventory.OrderQuantityTemplate",
                "Templates for suggested order quantities, used by replenishment planning.",
                "用于补货计划建议订购数量的模板。",
                ["order quantity template", "reorder template"], ["订购数量模板", "订货模板"]),
            Content(
                "Monitor.API.Inventory.PackageType",
                "The package types used to describe how parts are packed and shipped.",
                "用于描述物料包装与发运方式的包装类型。",
                ["package type", "packaging"], ["包装类型", "包装方式"]),
            Content(
                "Monitor.API.Inventory.PartActivity",
                "Activities logged against a part, such as stock counts or valuation changes.",
                "针对物料记录的活动，如库存盘点或估价变更。",
                ["part activity"], ["物料活动"]),
            Content(
                "Monitor.API.Inventory.PartActivityType",
                "The types a part activity can take.",
                "物料活动可采用的类型。",
                ["part activity type"], ["物料活动类型"]),
            Content(
                "Monitor.API.Inventory.PartCode",
                "The codes a part is known by, in addition to its part number.",
                "物料除物料编号外的其他代码。",
                ["part code", "part number"], ["物料代码", "物料编号"]),
            Content(
                "Monitor.API.Inventory.PartDefaultTransportLabel",
                "The default transport labels printed for a part.",
                "为物料默认打印的运输标签。",
                ["transport label", "shipping label"], ["运输标签", "默认运输标签"]),
            Content(
                "Monitor.API.Inventory.PartIdentityType",
                "The identity types (e.g. GTIN, serial number) a part or product record can carry.",
                "物料或产品记录可携带的标识类型（如 GTIN、序列号）。",
                ["identity type", "gtin"], ["标识类型", "身份类型"]),
            Content(
                "Monitor.API.Inventory.PartImage",
                "Images attached to a part record.",
                "附加到物料记录的图片。",
                ["part image", "photo"], ["物料图片"]),
            Content(
                "Monitor.API.Inventory.PartLocationProductRecord",
                "The product records (serial/batch) stored at a specific part location.",
                "存储在特定物料库位的产品记录（序列号/批次）。",
                ["location product record", "location serial"], ["库位产品记录"]),
            Content(
                "Monitor.API.Inventory.PartLocation",
                "The location of a part in a warehouse: quantity, pallet, and blocking status.",
                "物料在仓库中的库位：数量、托盘与封锁状态。",
                ["part location", "stock location"], ["物料库位", "库存库位"]),
            Content(
                "Monitor.API.Inventory.PartOtherIdentity",
                "Alternative identities of a part, such as supplier or customer part numbers.",
                "物料的其他标识，如供应商或客户的物料编号。",
                ["other identity", "customer part number", "supplier part number"], ["其他标识", "供应商物料编号", "客户物料编号"]),
            Content(
                "Monitor.API.Inventory.PartPlanningInformation",
                "Planning data for a part per warehouse: lot sizing, safety stock, and ordering rules.",
                "物料在各仓库的计划数据：批量规则、安全库存与订购规则。",
                ["planning information", "planning data"], ["计划信息", "计划数据"]),
            Content(
                "Monitor.API.Inventory.PartPurchaseExpenseValues",
                "The purchase expense values recorded for a part.",
                "物料记录的采购费用值。",
                ["purchase expense"], ["采购费用"]),
            Content(
                "Monitor.API.Inventory.PartTemplate",
                "Templates that predefine settings for creating new parts.",
                "用于创建新物料时预定义设置的物料模板。",
                ["part template", "template"], ["物料模板"]),
            Content(
                "Monitor.API.Inventory.Part",
                "The part master record — a material, component, or spare part held in inventory, with its stock, pricing, and planning information.",
                "物料主记录 —— 库存中管理的物料、组件或备件，含库存、价格与计划信息。",
                ["part", "component", "item", "material", "article", "spare part"], ["物料", "零件", "组件", "材料", "物品", "备件"],
                examples: [
                    Example(ExampleKind.Query,
                        "List parts", "查询物料",
                        "Lists the parts in inventory; use the OData query options to filter and page.",
                        "列出库存中的物料；可使用 OData 查询选项筛选和分页。",
                        "api/v1/Inventory/Parts", "GET",
                        query: "$filter=PartNumber eq 'PART-1000'",
                        response: new { value = new[] { new { Id = 1000, PartNumber = "PART-1000", Description = "Example part" } } }),
                ]),
            Content(
                "Monitor.API.Inventory.PhysicalInventoryList",
                "Lists for physical inventory (stock count) rounds, with their status.",
                "用于实物盘点（库存盘点）的清单，含状态。",
                ["physical inventory", "stock count list", "inventory list"], ["实物盘点", "库存盘点清单"]),
            Content(
                "Monitor.API.Inventory.PhysicalInventoryRow",
                "Rows of a physical inventory list, one per counted part and location.",
                "实物盘点清单的行，每个被盘点的物料与库位一行。",
                ["physical inventory row", "stock count row"], ["实物盘点行", "盘点行"]),
            Content(
                "Monitor.API.Inventory.PriceChangeLog",
                "The logged price changes for parts, with old and new values.",
                "物料的价格变更日志，含新旧值。",
                ["price change", "price history"], ["价格变更", "价格变更日志"]),
            Content(
                "Monitor.API.Inventory.ProductRecordOperationReporting",
                "Operation reports against a product record (serial/batch tracked product).",
                "针对产品记录（序列号/批次追溯产品）的作业报告。",
                ["operation reporting", "operation report"], ["作业报告", "工序报告"]),
            Content(
                "Monitor.API.Inventory.ProductRecord",
                "A product record — a uniquely identified, serial- or batch-tracked instance of a part.",
                "产品记录 —— 物料的一个唯一标识、按序列号或批次追溯的实例。",
                ["product record", "serial", "batch", "traceability"], ["产品记录", "序列号", "批次", "追溯"]),
            Content(
                "Monitor.API.Inventory.ProfitMarkup",
                "The profit markup templates applied to cost prices.",
                "应用于成本价的利润加成模板。",
                ["profit markup", "margin"], ["利润加成", "利润率"]),
            Content(
                "Monitor.API.Inventory.QuantityChange",
                "Quantity changes to stock, with the reason and resulting balance.",
                "库存数量变更，含原因与变更后的余额。",
                ["quantity change", "stock change"], ["数量变更", "库存数量变更"]),
            Content(
                "Monitor.API.Inventory.SalesForecastRow",
                "Rows of a sales forecast: the forecasted quantity per part and period.",
                "销售预测的行：每个物料与期间的预测数量。",
                ["sales forecast row", "forecast row"], ["销售预测行", "预测行"]),
            Content(
                "Monitor.API.Inventory.SalesForecast",
                "Sales forecasts used to drive demand-driven replenishment planning.",
                "用于驱动需求驱动补货计划的销售预测。",
                ["sales forecast", "forecast", "demand forecast"], ["销售预测", "需求预测", "预测"]),
            Content(
                "Monitor.API.Inventory.SalesOverheadMarkup",
                "The sales overhead markup templates applied to parts.",
                "应用于物料的销售间接费用加成模板。",
                ["sales overhead markup", "sales overhead"], ["销售间接费用加成"]),
            Content(
                "Monitor.API.Inventory.StockBalanceChange",
                "Changes to the stock balance of a part at a location.",
                "物料在某库位库存余额的变更。",
                ["stock balance change", "balance change"], ["库存余额变更"]),
            Content(
                "Monitor.API.Inventory.StockTransaction",
                "Stock transactions — the movement of quantities in and out of stock.",
                "库存交易 —— 库存数量的入库与出库移动。",
                ["stock transaction", "stock movement", "inventory transaction"], ["库存交易", "库存移动", "库存事务"]),
            Content(
                "Monitor.API.Inventory.StorageOverheadMarkup",
                "The storage overhead markup templates applied to parts.",
                "应用于物料的存储间接费用加成模板。",
                ["storage overhead markup", "storage overhead"], ["存储间接费用加成"]),
            Content(
                "Monitor.API.Inventory.UnplannedStockMovementReasonCode",
                "Reason codes for unplanned stock movements, e.g. corrections and adjustments.",
                "计划外库存移动（如更正与调整）的原因代码。",
                ["reason code", "unplanned movement"], ["原因代码", "计划外移动原因"]),
        ];
    }
}
