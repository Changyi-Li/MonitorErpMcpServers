namespace MonitorErpMcp.Catalog.Content.Sales
{
    // The using-static sits inside the namespace so the imported Content(...) builder binds before
    // the enclosing MonitorErpMcp.Catalog.Content namespace in simple-name lookup.
    using static MonitorErpMcp.Catalog.Content.ContentEntryFactory;

    /// <summary>
    /// Hand-authored content for Sales query records: bilingual descriptions and search aliases
    /// (en first, zh second), keyed by clrType and merged onto the structural catalog.
    /// </summary>
    public static class Queries
    {
        /// <summary>Hand-authored entries for this family, merged by <c>clrType</c> onto the structural catalog.</summary>
        public static readonly ContentEntry[] Entries =
        [
            Content(
                "Monitor.API.Sales.BlanketOrderSales",
                "Blanket (framework) sales orders — long-term agreements covering repeated deliveries.",
                "总括（框架）销售订单 —— 覆盖重复交货的长期协议。",
                ["blanket order", "framework order", "frame order"], ["总括订单", "框架订单", "总括销售订单"]),
            Content(
                "Monitor.API.Sales.BlanketOrderSalesRow",
                "Rows of a blanket sales order.",
                "总括销售订单的行。",
                ["blanket order row"], ["总括订单行"]),
            Content(
                "Monitor.API.Sales.BlanketOrderSalesType",
                "The types a blanket sales order can take.",
                "总括销售订单可采用的类型。",
                ["blanket order type"], ["总括订单类型"]),
            Content(
                "Monitor.API.Sales.BusinessOpportunity",
                "A business opportunity — a tracked sales lead or deal in the sales process.",
                "商机 —— 销售流程中跟踪的销售线索或交易。",
                ["business opportunity", "opportunity", "deal", "lead"], ["商机", "销售机会", "线索"]),
            Content(
                "Monitor.API.Sales.BusinessOpportunityActivity",
                "Activities logged against a business opportunity.",
                "针对商机记录的活动。",
                ["opportunity activity"], ["商机活动"]),
            Content(
                "Monitor.API.Sales.BusinessOpportunityActivityTemplateRow",
                "Rows of a business opportunity activity template.",
                "商机活动模板的行。",
                ["opportunity activity template row"], ["商机活动模板行"]),
            Content(
                "Monitor.API.Sales.BusinessOpportunityActivityTemplate",
                "Templates that predefine activities for a business opportunity.",
                "为商机预定义活动的模板。",
                ["opportunity activity template"], ["商机活动模板"]),
            Content(
                "Monitor.API.Sales.BusinessOpportunityGroup",
                "Groups that classify business opportunities.",
                "对商机进行分类的商机组。",
                ["opportunity group"], ["商机组"]),
            Content(
                "Monitor.API.Sales.BusinessOpportunityReference",
                "References attached to a business opportunity, e.g. to customers or documents.",
                "附加到商机的参考，如客户或单据。",
                ["opportunity reference"], ["商机参考"]),
            Content(
                "Monitor.API.Sales.BusinessOpportunitySalesProcessStep",
                "The steps of the sales process applied to business opportunities.",
                "应用于商机的销售流程步骤。",
                ["sales process step"], ["销售流程步骤", "销售阶段"]),
            Content(
                "Monitor.API.Sales.BusinessOpportunityType",
                "The types a business opportunity can take.",
                "商机可采用的类型。",
                ["opportunity type"], ["商机类型"]),
            Content(
                "Monitor.API.Sales.CountryDocumentSettings",
                "Document settings per country, e.g. invoice and delivery terms.",
                "按国家设置的单据参数，如开票与交货条款。",
                ["country settings", "document settings"], ["国家单据设置"]),
            Content(
                "Monitor.API.Sales.CustomerAccountGroup",
                "The account groups that determine how a customer is posted in accounting.",
                "决定客户在财务中过账方式的科目组。",
                ["account group"], ["客户科目组", "科目组"]),
            Content(
                "Monitor.API.Sales.CustomerCountryDocumentSettings",
                "Document settings for a specific customer, overriding the country defaults.",
                "针对特定客户的单据设置，覆盖国家默认值。",
                ["customer country settings"], ["客户国家单据设置"]),
            Content(
                "Monitor.API.Sales.CustomerDistrict",
                "Customer districts used for statistics and sales reporting.",
                "用于统计与销售报表的客户区域。",
                ["customer district", "district"], ["客户区域", "区域"]),
            Content(
                "Monitor.API.Sales.CustomerEmployeeSpan",
                "The number of employees a customer has, used for classification.",
                "客户拥有的员工人数，用于分类。",
                ["employee span", "employee count"], ["员工人数"]),
            Content(
                "Monitor.API.Sales.CustomerOrderActivity",
                "Activities logged against a customer order.",
                "针对客户订单记录的活动。",
                ["order activity"], ["订单活动", "客户订单活动"]),
            Content(
                "Monitor.API.Sales.CustomerOrderDeliveryRow",
                "The delivery rows of a customer order — planned deliveries per order row.",
                "客户订单的交货行 —— 每个订单行的计划交货。",
                ["delivery row", "planned delivery"], ["交货行", "计划交货"]),
            Content(
                "Monitor.API.Sales.CustomerOrderInvoiceOrderRowDiscount",
                "The order-row discounts on a customer order invoice.",
                "客户订单发票上的订单行折扣。",
                ["order row discount"], ["订单行折扣"]),
            Content(
                "Monitor.API.Sales.CustomerOrderInvoiceRow",
                "Rows of a customer order invoice.",
                "客户订单发票的行。",
                ["invoice row"], ["发票行"]),
            Content(
                "Monitor.API.Sales.CustomerOrderInvoice",
                "A customer order invoice — the invoiced and delivered rows of a customer order.",
                "客户订单发票 —— 客户订单已开票、已交货的行。",
                ["invoice", "customer invoice", "sales invoice"], ["发票", "客户发票", "销售发票"]),
            Content(
                "Monitor.API.Sales.CustomerOrderOrderRowDiscount",
                "The discounts on a customer order's rows.",
                "客户订单行的折扣。",
                ["order discount"], ["订单折扣"]),
            Content(
                "Monitor.API.Sales.CustomerOrderPaymentPlanRow",
                "The payment plan rows of a customer order.",
                "客户订单的付款计划行。",
                ["payment plan row"], ["付款计划行"]),
            Content(
                "Monitor.API.Sales.CustomerOrderRowInflow",
                "The inflows into a customer order row, e.g. from forecasts or purchase orders.",
                "客户订单行的流入，如来自预测或采购订单。",
                ["row inflow"], ["订单行流入"]),
            Content(
                "Monitor.API.Sales.CustomerOrderRow",
                "A row of a customer order — the part, quantity, price, and delivery of one line.",
                "客户订单的行 —— 一行的物料、数量、价格与交货。",
                ["order row", "customer order line"], ["订单行", "客户订单行"]),
            Content(
                "Monitor.API.Sales.CustomerOrderShippingInformationRow",
                "Shipping information rows of a customer order.",
                "客户订单的装运信息行。",
                ["shipping information"], ["装运信息行"]),
            Content(
                "Monitor.API.Sales.CustomerOrderType",
                "The types a customer order can take.",
                "客户订单可采用的类型。",
                ["order type"], ["订单类型"]),
            Content(
                "Monitor.API.Sales.CustomerOrder",
                "A customer order — the commercial agreement to deliver parts to a customer.",
                "客户订单 —— 向客户交付物料的商业协议。",
                ["customer order", "sales order", "order"], ["客户订单", "销售订单", "订单"]),
            Content(
                "Monitor.API.Sales.CustomerPartLink",
                "The link between a customer and the parts it buys.",
                "客户与其采购物料之间的链接。",
                ["customer part link"], ["客户物料链接"]),
            Content(
                "Monitor.API.Sales.CustomerRelationshipActivityType",
                "The activity types used in customer relationship management.",
                "客户关系管理中使用的活动类型。",
                ["relationship activity type", "crm activity"], ["客户关系活动类型"]),
            Content(
                "Monitor.API.Sales.CustomerRelationshipManagementActivity",
                "Activities in customer relationship management, e.g. calls and meetings.",
                "客户关系管理中的活动，如电话与会议。",
                ["crm activity", "relationship activity"], ["客户关系管理活动"]),
            Content(
                "Monitor.API.Sales.CustomerStatus",
                "The statuses a customer can have, e.g. active or blocked.",
                "客户可具有的状态，如活动或封锁。",
                ["customer status"], ["客户状态"]),
            Content(
                "Monitor.API.Sales.CustomerType",
                "The types a customer can be classified as.",
                "客户可被分类的类型。",
                ["customer type"], ["客户类型"]),
            Content(
                "Monitor.API.Sales.Customer",
                "The customer master record with invoicing, delivery, and contact information.",
                "客户主记录，含开票、交货与联系信息。",
                ["customer", "client", "account", "debtor"], ["客户", "顾客", "客户主数据"]),
            Content(
                "Monitor.API.Sales.InvoiceLog",
                "The log of invoices created and printed.",
                "已创建与已打印发票的日志。",
                ["invoice log"], ["发票日志"]),
            Content(
                "Monitor.API.Sales.OrderQuantityCustomerOrder",
                "The order quantities suggested for customer order rows.",
                "客户订单行建议的订购数量。",
                ["order quantity"], ["订购数量"]),
            Content(
                "Monitor.API.Sales.OtherCustomerNumber",
                "Alternative numbers a customer is known by, e.g. from another system.",
                "客户的其他编号，如来自其他系统。",
                ["other customer number"], ["其他客户编号"]),
            Content(
                "Monitor.API.Sales.PackageRowPartLocation",
                "The part locations of a package row on a sales picking list.",
                "销售拣货单上包装行的物料库位。",
                ["package row location"], ["包装行库位"]),
            Content(
                "Monitor.API.Sales.PackageRow",
                "The package rows of a sales picking list — how the picked parts are packed.",
                "销售拣货单的包装行 —— 拣出物料的包装方式。",
                ["package row", "packing"], ["包装行"]),
            Content(
                "Monitor.API.Sales.QuoteActivity",
                "Activities logged against a quote.",
                "针对报价记录的活动。",
                ["quote activity"], ["报价活动"]),
            Content(
                "Monitor.API.Sales.QuoteOrderRowDiscount",
                "The order-row discounts on a quote.",
                "报价上的订单行折扣。",
                ["quote discount"], ["报价行折扣"]),
            Content(
                "Monitor.API.Sales.QuoteRow",
                "A row of a quote — the part, quantity, price, and delivery of one line.",
                "报价的行 —— 一行的物料、数量、价格与交货。",
                ["quote row", "quote line"], ["报价行", "报价明细"]),
            Content(
                "Monitor.API.Sales.QuoteType",
                "The types a quote can take.",
                "报价可采用的类型。",
                ["quote type"], ["报价类型"]),
            Content(
                "Monitor.API.Sales.Quote",
                "A quote — the offered price and delivery of parts to a customer before an order.",
                "报价 —— 在订单之前向客户提供的物料价格与交货。",
                ["quote", "quotation", "offer"], ["报价", "报价单"]),
            Content(
                "Monitor.API.Sales.ReasonCodeLostQuote",
                "Reason codes recorded when a quote is lost.",
                "报价丢失时记录的原因代码。",
                ["lost quote reason"], ["报价丢失原因"]),
            Content(
                "Monitor.API.Sales.RelatedQuoteEntry",
                "Entries linking quotes to each other.",
                "将报价相互链接的条目。",
                ["related quote entry"], ["关联报价条目"]),
            Content(
                "Monitor.API.Sales.RelatedQuote",
                "Quotes related to a quote, e.g. alternatives or sub-quotes.",
                "与某报价相关的报价，如替代方案或子报价。",
                ["related quote"], ["关联报价"]),
            Content(
                "Monitor.API.Sales.SalesAgreementRow",
                "Rows of a sales agreement — the agreed parts, prices, and quantities.",
                "销售协议的行 —— 约定的物料、价格与数量。",
                ["sales agreement row"], ["销售协议行"]),
            Content(
                "Monitor.API.Sales.SalesAgreementType",
                "The types a sales agreement can take.",
                "销售协议可采用的类型。",
                ["sales agreement type"], ["销售协议类型"]),
            Content(
                "Monitor.API.Sales.SalesAgreement",
                "A sales agreement — the agreed terms for supplying parts over time.",
                "销售协议 —— 在一段时间内供应物料的约定条款。",
                ["sales agreement", "agreement"], ["销售协议", "协议"]),
            Content(
                "Monitor.API.Sales.SalesPickingListRowQuantity",
                "The row quantities of a sales picking list.",
                "销售拣货单的行数量。",
                ["picking row quantity"], ["拣货单行数量"]),
            Content(
                "Monitor.API.Sales.SalesPickingList",
                "A sales picking list — the parts picked and packed for a set of deliveries.",
                "销售拣货单 —— 为一组交货拣选与包装的物料。",
                ["picking list", "pick list"], ["拣货单", "销售拣货单"]),
            Content(
                "Monitor.API.Sales.SalesPrice",
                "The sales prices of parts, including price lists and staggered prices.",
                "物料的销售价格，含价目表与阶梯价格。",
                ["sales price", "price list", "price"], ["销售价格", "价格表", "价目表"]),
            Content(
                "Monitor.API.Sales.SalesProcessStep",
                "The steps of a sales process applied to business opportunities.",
                "应用于商机的销售流程步骤。",
                ["sales step", "process step"], ["销售流程步骤", "销售步骤"]),
            Content(
                "Monitor.API.Sales.SalesProcessTemplateRow",
                "Rows of a sales process template.",
                "销售流程模板的行。",
                ["process template row"], ["销售流程模板行"]),
            Content(
                "Monitor.API.Sales.SalesProcessTemplate",
                "Templates that predefine the steps of a sales process.",
                "预定义销售流程步骤的模板。",
                ["process template"], ["销售流程模板"]),
            Content(
                "Monitor.API.Sales.SellerGroup",
                "The groups of sellers used for statistics and responsibility.",
                "用于统计与责任划分的销售员组。",
                ["seller group"], ["销售员组"]),
            Content(
                "Monitor.API.Sales.ShipmentInformationSource",
                "The sources a shipment's information can come from.",
                "装运信息的来源。",
                ["shipment source"], ["装运信息来源"]),
            Content(
                "Monitor.API.Sales.ShipmentPackageInformationPackageNumber",
                "The package numbers of a shipment's package information.",
                "装运包装信息的包装编号。",
                ["package number"], ["包装编号"]),
            Content(
                "Monitor.API.Sales.ShipmentPackageInformation",
                "The package information of a shipment — the packages and their contents.",
                "装运的包装信息 —— 包装及其内容。",
                ["shipment package"], ["装运包装信息"]),
            Content(
                "Monitor.API.Sales.Shipment",
                "A shipment — the delivery of goods to a customer, with its packages and tracking.",
                "装运 —— 向客户交付货物，含包装与跟踪。",
                ["shipment", "delivery", "dispatch"], ["装运", "发货", "交运"]),
            Content(
                "Monitor.API.Sales.ShippingService",
                "The shipping services (carriers) used for shipments.",
                "用于装运的货运服务（承运商）。",
                ["shipping service", "carrier"], ["货运服务", "承运商"]),
            Content(
                "Monitor.API.Sales.ShippingTemplate",
                "Templates that predefine shipping information for shipments.",
                "预定义装运信息的装运模板。",
                ["shipping template"], ["装运模板"]),
            Content(
                "Monitor.API.Sales.ValidityTime",
                "The validity periods used for prices and agreements.",
                "用于价格与协议的有效期。",
                ["validity time", "validity period"], ["有效期"]),
        ];
    }
}
