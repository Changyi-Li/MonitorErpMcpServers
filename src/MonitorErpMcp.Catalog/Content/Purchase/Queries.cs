namespace MonitorErpMcp.Catalog.Content.Purchase
{
    // The using-static sits inside the namespace so the imported Content(...) builder binds before
    // the enclosing MonitorErpMcp.Catalog.Content namespace in simple-name lookup.
    using static MonitorErpMcp.Catalog.Content.ContentEntryFactory;
    using MonitorErpMcp.Catalog.Model;

    /// <summary>
    /// Hand-authored content for Purchase query records: bilingual descriptions and search aliases
    /// (en first, zh second), keyed by clrType and merged onto the structural catalog. Important
    /// fields (enum, reference, expandable, unique) carry bilingual descriptions; self-evident
    /// fields such as a bare Description string are skipped per the coverage tiers.
    /// </summary>
    public static class Queries
    {
        /// <summary>Hand-authored entries for this family, merged by <c>clrType</c> onto the structural catalog.</summary>
        public static readonly ContentEntry[] Entries =
        [
            // ---- BlanketOrderPurchases ----------------------------------------------
            Content(
                "Monitor.API.Purchase.BlanketOrderPurchase",
                "A blanket purchase order — a frame agreement with a supplier that purchase orders are called off against.",
                "采购框架协议 —— 与供应商的框架协议，采购订单据此分批执行。",
                ["blanket order", "blanket order purchase", "frame agreement", "call-off"], ["采购框架协议", "框架订单", "总协议"],
                fields: [
                    F("OrderNumber", "The unique number of the blanket order.", "采购框架协议的唯一编号。"),
                    F("LifeCycleState", "The lifecycle state of the blanket order (transient, persistent, history...).", "采购框架协议的生命周期状态（临时、持久、历史等）。"),
                    F("OrderTypeId", "The blanket-order type of the order.", "协议的单据类型。"),
                    F("BusinessContactId", "The supplier of the blanket order.", "协议的供应商。"),
                    F("BusinessContactReferenceId", "The supplier reference for the blanket order.", "协议的供应商联系人。"),
                    F("BusinessContactReference", "The supplier reference for the blanket order.", "协议的供应商联系人。"),
                    F("OurReferenceId", "Our reference (person) for the blanket order.", "协议的我方联系人（人员）。"),
                    F("OurReference", "Our reference (person) for the blanket order.", "协议的我方联系人（人员）。"),
                    F("ValidationPeriod", "Whether the agreement is validated by order or delivery date.", "协议按订单日期还是交货日期校验。"),
                    F("Status", "The status of the blanket order (registered, printed, called off, history).", "协议的状态（已登记、已打印、已执行、历史）。"),
                    F("CurrencyId", "The currency of the blanket order.", "协议的货币。"),
                    F("Currency", "The currency of the blanket order.", "协议的货币。"),
                    F("DefaultOrderPrintoutVia", "How orders called off are printed (printer, e-mail, EDI).", "订单打印/发送的方式（打印机、电子邮件、EDI）。"),
                    F("MailingAddressId", "The mailing address of the blanket order.", "协议的邮寄地址。"),
                    F("MailingAddress", "The mailing address of the blanket order.", "协议的邮寄地址。"),
                    F("InternalCommentId", "The internal comment of the blanket order.", "协议的内部备注。"),
                    F("InternalComment", "The internal comment of the blanket order.", "协议的内部备注。"),
                    F("ExternalCommentId", "The external comment of the blanket order.", "协议的外部备注。"),
                    F("ExternalComment", "The external comment of the blanket order.", "协议的外部备注。"),
                    F("CurrencyExchangeTypeId", "The exchange-rate type of the blanket order.", "协议的汇率类型。"),
                    F("CurrencyExchangeType", "The exchange-rate type of the blanket order.", "协议的汇率类型。"),
                    F("Rows", "The rows of the blanket order.", "协议的行。"),
                ]),
            Content(
                "Monitor.API.Purchase.BlanketOrderPurchaseRow",
                "A row of a blanket purchase order — a part and quantity agreed with a supplier.",
                "采购框架协议的行 —— 与供应商约定的物料与数量。",
                ["blanket order row", "blanket row"], ["框架协议行", "协议行"],
                fields: [
                    F("LifeCycleState", "The lifecycle state of the row.", "行的生命周期状态。"),
                    F("ParentOrderId", "The blanket order the row belongs to.", "该行所属的采购框架协议。"),
                    F("ParentRowId", "The parent row of the row.", "该行的父行。"),
                    F("OrderRowType", "The type of the row (part, additional, sum, free text).", "行的类型（物料、附加、合计、自由文本）。"),
                    F("PartId", "The part of the row.", "行的物料。"),
                    F("Part", "The part of the row.", "行的物料。"),
                    F("PartRowType", "The role of the part row (regular, sub-part, setup price, alloy cost...).", "物料行的角色（常规、子物料、准备价格、合金成本等）。"),
                    F("UnitId", "The unit of the row quantity.", "行数量的单位。"),
                    F("Unit", "The unit of the row quantity.", "行数量的单位。"),
                    F("PriceCurrencyId", "The currency of the row price.", "行价格的货币。"),
                    F("PriceCurrency", "The currency of the row price.", "行价格的货币。"),
                    F("PriceOriginPriceListId", "The price list the price originates from.", "价格来源的价目表。"),
                    F("PriceInCompanyCurrencyCurrencyId", "The currency of the price in company currency.", "按公司货币计价的价格的货币。"),
                    F("PriceInCompanyCurrencyCurrency", "The currency of the price in company currency.", "按公司货币计价的价格的货币。"),
                    F("SetupPriceCurrencyId", "The currency of the setup price.", "准备价格的货币。"),
                    F("SetupPriceCurrency", "The currency of the setup price.", "准备价格的货币。"),
                    F("VatRateId", "The VAT rate of the row.", "行的增值税率。"),
                    F("VatRate", "The VAT rate of the row.", "行的增值税率。"),
                    F("ShowFreeTextIn", "Where the free text is shown (internal, inquiry, order, delivery schedule).", "自由文本显示的位置（内部、询价、订单、交货计划）。"),
                    F("RevisionId", "The part revision of the row.", "行的物料修订版。"),
                    F("Revision", "The part revision of the row.", "行的物料修订版。"),
                ]),
            Content(
                "Monitor.API.Purchase.BlanketOrderPurchaseType",
                "A blanket-purchase-order type defining how orders are numbered and controlled.",
                "定义采购框架协议编号与控制方式的协议类型。",
                ["blanket order type", "blanket order purchase type"], ["采购框架协议类型", "框架订单类型"],
                fields: [
                    F("Number", "The unique number of the type.", "类型的唯一编号。"),
                    F("BaseType", "The base type of the blanket order.", "协议的基础类型。"),
                    F("BlanketOrderPurchaseActivityTemplateId", "The activity template used for blanket-order activities.", "协议活动使用的活动模板。"),
                    F("RateTypeSetting", "Whether the exchange rate comes from the supplier or the order type.", "汇率取自供应商还是单据类型。"),
                    F("CurrencyExchangeTypeId", "The exchange-rate type of the blanket order type.", "协议类型的汇率类型。"),
                ]),

            // ---- EimDocuments --------------------------------------------------------
            Content(
                "Monitor.API.Purchase.EimDocument",
                "An EIM document attached to an accounts-payable record, e.g. an imported invoice image.",
                "附加到应付账款记录上的 EIM 单据，如导入的发票影像。",
                ["eim document", "eim", "imported invoice", "invoice image"], ["EIM单据", "发票影像", "导入发票"],
                fields: [
                    F("AccountsPayableId", "The accounts-payable record the document belongs to.", "单据所属的应付账款记录。"),
                    F("BlobDataId", "The binary data of the document.", "单据的二进制数据。"),
                    F("DocumentTypeId", "The document type of the EIM document.", "EIM 单据的单据类型。"),
                ]),
            Content(
                "Monitor.API.Purchase.EimDocumentType",
                "The EIM document types used to classify imported documents.",
                "用于对导入单据进行分类的 EIM 单据类型。",
                ["eim document type", "eim type"], ["EIM单据类型", "EIM类型"],
                fields: [
                    F("Number", "The unique number of the document type.", "单据类型的唯一编号。"),
                ]),

            // ---- Inquiries -----------------------------------------------------------
            Content(
                "Monitor.API.Purchase.Inquiry",
                "An inquiry to a supplier for pricing and delivery of goods, with its rows and status.",
                "向供应商发出的询价单，含行与状态。",
                ["inquiry", "purchase inquiry", "rfq", "request for quotation"], ["询价单", "询价", "采购询价"],
                fields: [
                    F("LifeCycleState", "The lifecycle state of the inquiry.", "询价单的生命周期状态。"),
                    F("Status", "The status of the inquiry (registered, printed, responded, ordered...).", "询价单的状态（已登记、已打印、已回复、已下单等）。"),
                    F("OrderType", "The inquiry type of the inquiry.", "询价单的类型。"),
                    F("PaymentTerm", "The payment term of the inquiry.", "询价单的付款条款。"),
                    F("SendMethod", "How the inquiry is sent (printer, e-mail, EDI).", "询价单的发送方式（打印机、电子邮件、EDI）。"),
                    F("DeliveryAddress", "The delivery address of the inquiry.", "询价单的交货地址。"),
                    F("MailingAddress", "The mailing address of the inquiry.", "询价单的邮寄地址。"),
                    F("Rows", "The rows of the inquiry.", "询价单的行。"),
                    F("InternalComment", "The internal comment of the inquiry.", "询价单的内部备注。"),
                    F("ExternalComment", "The external comment of the inquiry.", "询价单的外部备注。"),
                    F("CurrencyExchangeTypeId", "The exchange-rate type of the inquiry.", "询价单的汇率类型。"),
                    F("CommunicationAddresses", "The communication addresses of the inquiry.", "询价单的通信地址。"),
                ]),
            Content(
                "Monitor.API.Purchase.InquiryRow",
                "A row of an inquiry — a part and quantity quoted by a supplier.",
                "询价单的行 —— 供应商报价的物料与数量。",
                ["inquiry row", "inquiry line"], ["询价行", "询价单行"],
                fields: [
                    F("OrderRowType", "The type of the row (part, additional, sum, free text).", "行的类型（物料、附加、合计、自由文本）。"),
                    F("PartRowType", "The role of the part row (regular, sub-part, setup price...).", "物料行的角色（常规、子物料、准备价格等）。"),
                    F("PartStatus", "The part status of the row (quote, prototype, new, normal...).", "行的物料状态（报价、原型、新建、正常等）。"),
                    F("Revision", "The part revision of the row.", "行的物料修订版。"),
                    F("Unit", "The unit of the row quantity.", "行数量的单位。"),
                    F("ShowFreeTextIn", "Where the free text is shown (internal, inquiry, order, delivery schedule).", "自由文本显示的位置（内部、询价、订单、交货计划）。"),
                    F("Coding", "The coding of the row.", "行的记账信息。"),
                    F("LifeCycleState", "The lifecycle state of the row.", "行的生命周期状态。"),
                ]),
            Content(
                "Monitor.API.Purchase.InquiryType",
                "An inquiry type defining how inquiries are numbered and controlled.",
                "定义询价单编号与控制方式的询价单类型。",
                ["inquiry type", "rfq type"], ["询价单类型", "询价类型"],
                fields: [
                    F("BaseType", "The base type of the inquiry.", "询价单的基础类型。"),
                    F("RateTypeSetting", "Whether the exchange rate comes from the supplier or the inquiry type.", "汇率取自供应商还是询价单类型。"),
                    F("CurrencyExchangeTypeId", "The exchange-rate type of the inquiry type.", "询价单类型的汇率类型。"),
                ]),

            // ---- PurchaseOrders ------------------------------------------------------
            Content(
                "Monitor.API.Purchase.OrderQuantityPurchaseOrder",
                "The order quantity of a purchase-order row, including its partial quantities.",
                "采购订单行的订单数量，含零头数量。",
                ["order quantity", "purchase order quantity"], ["订单数量", "采购订单数量"],
                fields: [
                    F("PartialQuantities", "The partial quantities of the order quantity.", "订单数量的零头数量。"),
                ]),
            Content(
                "Monitor.API.Purchase.PurchaseOrder",
                "A purchase order to a supplier for goods, with its rows, deliveries, and invoices.",
                "向供应商采购货物的采购订单，含行、交货与发票。",
                ["purchase order", "purchase order number", "buy order"], ["采购订单", "采购单"],
                fields: [
                    F("OrderNumber", "The unique number of the purchase order.", "采购订单的唯一编号。"),
                    F("LifeCycleState", "The lifecycle state of the purchase order.", "采购订单的生命周期状态。"),
                    F("Status", "The status of the purchase order (registered, printed, delivered, history...).", "采购订单的状态（已登记、已打印、已交货、历史等）。"),
                    F("OrderType", "The purchase-order type of the order.", "采购订单的单据类型。"),
                    F("BusinessContactId", "The supplier of the purchase order.", "采购订单的供应商。"),
                    F("AccountGroup", "The supplier account group of the purchase order.", "采购订单的供应商科目组。"),
                    F("BusinessContactReference", "The supplier reference of the purchase order.", "采购订单的供应商联系人。"),
                    F("OurReference", "Our reference (person) for the purchase order.", "采购订单的我方联系人（人员）。"),
                    F("PaymentTerm", "The payment term of the purchase order.", "采购订单的付款条款。"),
                    F("DeliveryTerm", "The delivery term of the purchase order.", "采购订单的交货条款。"),
                    F("DeliveryMethod", "The delivery method of the purchase order.", "采购订单的交货方式。"),
                    F("PackingTerm", "The packing term of the purchase order.", "采购订单的包装条款。"),
                    F("ShipmentPayer", "Who pays for the shipment (buyer, seller, other, Incoterms).", "运费承担方（买方、卖方、其他、Incoterms）。"),
                    F("SendMethod", "How the order is sent (printer, e-mail, EDI).", "订单的发送方式（打印机、电子邮件、EDI）。"),
                    F("InvoicePrintoutMethod", "How the invoice is printed (printer, e-mail, EDI).", "发票的打印方式（打印机、电子邮件、EDI）。"),
                    F("Warehouse", "The warehouse of the purchase order.", "采购订单的仓库。"),
                    F("Currency", "The currency of the purchase order.", "采购订单的货币。"),
                    F("VatGroup", "The VAT group of the purchase order.", "采购订单的增值税组。"),
                    F("CurrencyExchangeTypeId", "The exchange-rate type of the purchase order.", "采购订单的汇率类型。"),
                    F("Rows", "The rows of the purchase order.", "采购订单的行。"),
                    F("DeliveryAddress", "The delivery address of the purchase order.", "采购订单的交货地址。"),
                    F("MailingAddress", "The mailing address of the purchase order.", "采购订单的邮寄地址。"),
                    F("SourceOfAlternativeDeliveryAddresses", "Where the alternative delivery address comes from (customer, supplier, company...).", "备选交货地址的来源（客户、供应商、公司等）。"),
                    F("InternalComment", "The internal comment of the purchase order.", "采购订单的内部备注。"),
                    F("ExternalComment", "The external comment of the purchase order.", "采购订单的外部备注。"),
                    F("CommunicationAddresses", "The communication addresses of the purchase order.", "采购订单的通信地址。"),
                ]),
            Content(
                "Monitor.API.Purchase.PurchaseOrderRow",
                "A row of a purchase order — a part and quantity ordered from a supplier.",
                "采购订单的行 —— 向供应商订购的物料与数量。",
                ["purchase order row", "purchase order line", "order row"], ["采购订单行", "采购行", "订单行"],
                fields: [
                    F("OrderRowType", "The type of the row (part, additional, sum, free text).", "行的类型（物料、附加、合计、自由文本）。"),
                    F("Part", "The part of the row.", "行的物料。"),
                    F("PartRowType", "The role of the part row (regular, sub-part, setup price, alloy cost...).", "物料行的角色（常规、子物料、准备价格、合金成本等）。"),
                    F("PartStatus", "The part status of the row (quote, prototype, new, normal...).", "行的物料状态（报价、原型、新建、正常等）。"),
                    F("Revision", "The part revision of the row.", "行的物料修订版。"),
                    F("Unit", "The unit of the row quantity.", "行数量的单位。"),
                    F("PriceCurrency", "The currency of the row price.", "行价格的货币。"),
                    F("PriceOrigin", "Where the price originates from (price list, staggered price, standard price...).", "价格的来源（价目表、阶梯价格、标准价格等）。"),
                    F("StandardPriceCurrency", "The currency of the standard price.", "标准价格的货币。"),
                    F("SetupPriceCurrency", "The currency of the setup price.", "准备价格的货币。"),
                    F("VatRate", "The VAT rate of the row.", "行的增值税率。"),
                    F("Warehouse", "The warehouse of the row.", "行的仓库。"),
                    F("ShowFreeTextIn", "Where the free text is shown (internal, inquiry, order, delivery schedule).", "自由文本显示的位置（内部、询价、订单、交货计划）。"),
                    F("LifeCycleState", "The lifecycle state of the row.", "行的生命周期状态。"),
                    F("RowStatus", "The status of the row (registered, printed, delivered, history).", "行的状态（已登记、已打印、已交货、历史）。"),
                    F("CreationContext", "How the row was created (order registration, delivery reporting, invoicing...).", "行的创建方式（订单登记、交货上报、开票等）。"),
                    F("ReceivingInspectionType", "The receiving-inspection type of the row (none, always, variable).", "行的收货检验类型（无、始终、变动）。"),
                    F("ReceivingInspectionInstruction", "The receiving-inspection instruction of the row.", "行的收货检验说明。"),
                    F("ReceivingMessage", "The receiving message of the row.", "行的收货消息。"),
                    F("DelayReason", "The delay reason of the row.", "行的延迟原因。"),
                    F("DelayComment", "The delay comment of the row.", "行的延迟备注。"),
                    F("Coding", "The coding of the row.", "行的记账信息。"),
                    F("StatisticalGoodsCode", "The statistical goods code of the row.", "行的统计货物代码。"),
                    F("TariffAndServiceCode", "The tariff or service code of the row.", "行的关税或服务代码。"),
                    F("IntrastatTransactionType", "The intrastat transaction type of the row.", "行的欧盟贸易交易类型。"),
                    F("CausingTransType", "The transaction that caused the row (stock balance, customer order, manufacture order...).", "产生该行的事务（库存、客户订单、制造工单等）。"),
                    F("OrderQuantityId", "The order quantity (with partial quantities) of the row.", "行的订单数量（含零头数量）。"),
                    F("OrderQuantity", "The order quantity (with partial quantities) of the row.", "行的订单数量（含零头数量）。"),
                    F("BlanketOrderPurchaseRowId", "The blanket-order row the row is called off from.", "该行所依据的采购框架协议行。"),
                ]),
            Content(
                "Monitor.API.Purchase.PurchaseOrderType",
                "A purchase-order type defining how orders are numbered and controlled.",
                "定义采购订单编号与控制方式的采购订单类型。",
                ["purchase order type", "order type"], ["采购订单类型", "订单类型"],
                fields: [
                    F("BaseType", "The base type of the order (acquisition, subcontract, stock, return).", "订单的基础类型（采购、外协、库存、退货）。"),
                    F("RateTypeSetting", "Whether the exchange rate comes from the supplier or the order type.", "汇率取自供应商还是订单类型。"),
                    F("CurrencyExchangeTypeId", "The exchange-rate type of the order type.", "订单类型的汇率类型。"),
                ]),
            Content(
                "Monitor.API.Purchase.PurchaseOrderAdvice",
                "A purchase-order advice — the supplier's dispatch advice for a delivery.",
                "采购订单发货通知 —— 供应商对某次交货的发货通知。",
                ["purchase order advice", "dispatch advice", "delivery advice"], ["采购订单发货通知", "发货通知", "交货通知"],
                fields: [
                    F("SupplierId", "The supplier of the advice.", "发货通知的供应商。"),
                    F("Status", "The status of the advice (registered, partially delivered, history).", "发货通知的状态（已登记、部分交货、历史）。"),
                ]),
            Content(
                "Monitor.API.Purchase.PurchaseOrderAdviceRow",
                "A row of a purchase-order advice — the advised quantity for a purchase-order row.",
                "采购订单发货通知的行 —— 针对采购订单行的通知数量。",
                ["purchase order advice row", "advice row"], ["发货通知行", "采购订单通知行"],
                fields: [
                    F("PurchaseOrderRowId", "The purchase-order row the advice concerns.", "通知所针对的采购订单行。"),
                    F("ParentId", "The purchase-order advice the row belongs to.", "该行所属的发货通知。"),
                    F("ParentRowId", "The parent row of the row.", "该行的父行。"),
                    F("Status", "The status of the row (registered, partially delivered, history).", "行的状态（已登记、部分交货、历史）。"),
                    F("UnitId", "The unit of the advised quantity.", "通知数量的单位。"),
                ]),
            Content(
                "Monitor.API.Purchase.PurchaseOrderAdviceRowProductRecord",
                "A product record (batch/serial) reported on a purchase-order advice row.",
                "采购订单发货通知行上上报的产品记录（批次/序列号）。",
                ["advice product record", "advice serial", "advice batch"], ["发货通知产品记录", "通知序列号"],
                fields: [
                    F("ParentId", "The purchase-order advice row the product record belongs to.", "产品记录所属的发货通知行。"),
                    F("TraceabilityMode", "The traceability mode (batch, individual, individual-only withdrawal).", "追溯模式（批次、单个、仅单个领用）。"),
                ]),
            Content(
                "Monitor.API.Purchase.PurchaseOrderDelivery",
                "A delivery against a purchase order, with its confirmation and arrival details.",
                "针对采购订单的交货，含确认与到货信息。",
                ["purchase order delivery", "delivery note"], ["采购交货", "到货通知"],
                fields: [
                    F("Rows", "The delivery rows of the delivery.", "交货的行。"),
                ]),
            Content(
                "Monitor.API.Purchase.PurchaseOrderDeliveryRow",
                "A delivery row of a purchase-order delivery — the delivered quantity for a purchase-order row.",
                "采购交货的行 —— 针对采购订单行的已交货数量。",
                ["delivery row", "purchase delivery row"], ["交货行", "采购交货行"],
                fields: [
                    F("PurchaseOrderRow", "The purchase-order row the delivery concerns.", "交货所针对的采购订单行。"),
                    F("AccountsPayableId", "The accounts-payable record created from the delivery, if any.", "由交货创建的应付账款记录（如有）。"),
                ]),
            Content(
                "Monitor.API.Purchase.PurchaseOrderInvoice",
                "An invoice against a purchase order, with its rows and payment term.",
                "针对采购订单的发票，含行与付款条款。",
                ["purchase invoice", "purchase order invoice", "supplier invoice"], ["采购发票", "采购订单发票", "供应商发票"],
                fields: [
                    F("ShipmentPayer", "Who pays for the shipment (buyer, seller, other, Incoterms).", "运费承担方（买方、卖方、其他、Incoterms）。"),
                    F("PaymentTerm", "The payment term of the invoice.", "发票的付款条款。"),
                    F("Rows", "The rows of the invoice.", "发票的行。"),
                ]),
            Content(
                "Monitor.API.Purchase.PurchaseOrderInvoiceRow",
                "A row of a purchase-order invoice — the invoiced price for a delivery row.",
                "采购发票的行 —— 针对交货行的开票价格。",
                ["purchase invoice row", "invoice row"], ["采购发票行", "发票行"],
                fields: [
                    F("Coding", "The coding of the row.", "行的记账信息。"),
                    F("LedgerId", "The accounts-payable ledger entry of the row.", "行的应付账款分类账条目。"),
                    F("Comment", "A comment on the row.", "行的备注。"),
                ]),

            // ---- OtherSupplierNumbers ------------------------------------------------
            Content(
                "Monitor.API.Purchase.OtherSupplierNumber",
                "An additional number a supplier is known by, besides the main supplier number.",
                "供应商除主编号外的其他编号。",
                ["other supplier number", "supplier number", "alternative number"], ["供应商其他编号", "供应商其他号码"]),

            // ---- PackingTerms / ResponseTimes ----------------------------------------
            Content(
                "Monitor.API.Purchase.PackingTerm",
                "The packing terms used on purchase orders.",
                "采购订单使用的包装条款。",
                ["packing term", "packing"], ["包装条款", "包装方式"]),
            Content(
                "Monitor.API.Purchase.ResponseTime",
                "The response times used to define how quickly suppliers must respond to inquiries.",
                "定义供应商回复询价时限的响应时间。",
                ["response time", "lead time"], ["响应时间", "回复时限"]),

            // ---- Suppliers -----------------------------------------------------------
            Content(
                "Monitor.API.Purchase.Supplier",
                "A supplier — a business contact that supplies goods, with its addresses, accounts, and terms.",
                "供应商 —— 供货的业务联系人，含地址、科目与条款。",
                ["supplier", "vendor", "seller", "business contact"], ["供应商", "厂商", "卖方"],
                fields: [
                    F("Role", "The role of the supplier (material supplier, subcontractor, shipping agent...).", "供应商的角色（物料供应商、外协、货运代理等）。"),
                    F("Status", "The status of the supplier.", "供应商的状态。"),
                    F("Type", "The type of the supplier.", "供应商的类型。"),
                    F("District", "The district of the supplier.", "供应商的地区。"),
                    F("MailingAddress", "The mailing address of the supplier.", "供应商的邮寄地址。"),
                    F("VisitingAddress", "The visiting address of the supplier.", "供应商的来访地址。"),
                    F("DeliveryAddress", "The default delivery address of the supplier.", "供应商的默认交货地址。"),
                    F("DeliveryAddresses", "The delivery addresses of the supplier.", "供应商的交货地址。"),
                    F("PaymentTerm", "The payment term of the supplier.", "供应商的付款条款。"),
                    F("PaymentMethod", "The payment method of the supplier.", "供应商的付款方式。"),
                    F("PackingTerm", "The packing term of the supplier.", "供应商的包装条款。"),
                    F("ResponseTime", "The response time of the supplier.", "供应商的响应时间。"),
                    F("Currency", "The currency of the supplier.", "供应商的货币。"),
                    F("Language", "The language of the supplier.", "供应商的语言。"),
                    F("CurrencyExchangeTypeId", "The exchange-rate type of the supplier.", "供应商的汇率类型。"),
                    F("BlockedStatus", "The block status of the supplier (none, message, blocked).", "供应商的封锁状态（无、消息、封锁）。"),
                    F("BlockedContextType", "The context in which the supplier is blocked (register, report, invoices, payments).", "供应商被封锁的上下文（登记、上报、发票、付款）。"),
                    F("BlockedBy", "The user who blocked the supplier.", "封锁该供应商的用户。"),
                    F("BlockedById", "The user who blocked the supplier.", "封锁该供应商的用户。"),
                    F("BlockMessage", "The message shown when the supplier is blocked.", "供应商被封锁时显示的消息。"),
                    F("Comment", "A comment on the supplier.", "供应商的备注。"),
                    F("PurchaseManager", "The purchase manager of the supplier.", "供应商的采购经理。"),
                    F("AuthorizedSignerPerson", "The authorized signer of the supplier.", "供应商的授权签字人。"),
                    F("DefaultReference", "The default reference of the supplier.", "供应商的默认联系人。"),
                    F("References", "The references of the supplier.", "供应商的联系人。"),
                    F("DefaultBusinessContactBankAccount", "The default bank account of the supplier.", "供应商的默认银行账户。"),
                    F("AllBusinessContactBankAccountOfSupplier", "The bank accounts of the supplier.", "供应商的银行账户。"),
                    F("DiscountCategory", "The discount category of the supplier.", "供应商的折扣类别。"),
                    F("ArrivalReportingInstruction", "The arrival-reporting instruction of the supplier.", "供应商的到货上报说明。"),
                    F("ReceivingInspectionType", "The receiving-inspection type of the supplier (none, always, variable).", "供应商的收货检验类型（无、始终、变动）。"),
                    F("ShippingAgentType", "The shipping agent type of the supplier (DHL, Schenker, PostNord...).", "供应商的货运代理类型（DHL、Schenker、PostNord 等）。"),
                    F("ShipmentPrintSetting", "How shipments are printed (waybill and parcel, waybill, parcel).", "发货打印方式（运单与包裹、运单、包裹）。"),
                    F("DefaultOrderPrintoutVia", "How orders are printed (printer, e-mail, EDI).", "订单打印/发送的方式（打印机、电子邮件、EDI）。"),
                    F("SupplierAccountGroupId", "The supplier account group of the supplier.", "供应商的供应商科目组。"),
                    F("PurchaseAccount", "The purchase account of the supplier.", "供应商的采购科目。"),
                    F("PurchaseAccountId", "The purchase account of the supplier.", "供应商的采购科目。"),
                    F("AccrualAccountingReverseAccount", "The accrual-accounting reverse account of the supplier.", "供应商的应计会计冲销科目。"),
                    F("AccrualAccountingReverseAccountId", "The accrual-accounting reverse account of the supplier.", "供应商的应计会计冲销科目。"),
                    F("OutgoingPaymentsAccount", "The outgoing-payments account of the supplier.", "供应商的付款科目。"),
                    F("OutgoingPaymentsAccountId", "The outgoing-payments account of the supplier.", "供应商的付款科目。"),
                    F("SupplierAccounts", "The supplier accounts of the supplier.", "供应商的供应商科目。"),
                    F("SupplierPartLinks", "The supplier-part links of the supplier.", "供应商的供应商物料链接。"),
                    F("CaseEntries", "The case entries of the supplier.", "供应商的案例登记。"),
                    F("OtherSupplierNumbers", "The other numbers of the supplier.", "供应商的其他编号。"),
                    F("CommunicationAddresses", "The communication addresses of the supplier.", "供应商的通信地址。"),
                    F("ExtraFields", "The extra field values of the supplier.", "供应商的附加字段值。"),
                    F("RootId", "The supplier root the supplier belongs to.", "供应商所属的供应商根记录。"),
                ]),
            Content(
                "Monitor.API.Purchase.SupplierAccount",
                "A supplier account linking a supplier to standard accounts and coding.",
                "将供应商关联到标准科目与记账的供应商科目。",
                ["supplier account", "supplier coding"], ["供应商科目", "供应商记账"],
                fields: [
                    F("SupplierId", "The supplier the account belongs to.", "科目所属的供应商。"),
                    F("StandardAccountId", "The standard account of the supplier.", "供应商的标准科目。"),
                    F("StandardAccount", "The standard account of the supplier.", "供应商的标准科目。"),
                    F("CodingEntryId", "The coding entry of the supplier account.", "供应商科目的记账条目。"),
                ]),
            Content(
                "Monitor.API.Purchase.SupplierAccountGroup",
                "A group of suppliers sharing the same accounting setup.",
                "共享相同会计设置的供应商组。",
                ["supplier account group", "supplier group"], ["供应商科目组", "供应商组"]),
            Content(
                "Monitor.API.Purchase.SupplierDistrict",
                "A supplier district used to classify suppliers by region.",
                "按地区对供应商进行分类的供应商地区。",
                ["supplier district", "district"], ["供应商地区", "地区"],
                fields: [
                    F("Code", "The unique code of the district.", "地区的唯一代码。"),
                ]),
            Content(
                "Monitor.API.Purchase.SupplierPartLink",
                "A link between a supplier and a part, with the supplier's price, lead time, and comments.",
                "供应商与物料的链接，含供应商价格、交期与备注。",
                ["supplier part link", "supplier part", "part supplier"], ["供应商物料链接", "供应商物料", "物料供应商"],
                fields: [
                    F("Unit", "The unit the price applies to.", "价格适用的单位。"),
                    F("PriceCurrency", "The currency of the price.", "价格的货币。"),
                    F("PurchaseCommentShowInForms", "Where the purchase comment is shown (internal, inquiry, order...).", "采购备注显示的位置（内部、询价、订单等）。"),
                    F("OverridePurchaseComment", "The override purchase comment of the link.", "链接的覆盖采购备注。"),
                    F("PriceComment", "The price comment of the link.", "链接的价格备注。"),
                ]),
            Content(
                "Monitor.API.Purchase.SupplierStatus",
                "The statuses a supplier can have.",
                "供应商可具有的状态。",
                ["supplier status"], ["供应商状态"],
                fields: [
                    F("Code", "The unique code of the status.", "状态的唯一代码。"),
                ]),
            Content(
                "Monitor.API.Purchase.SupplierType",
                "The types a supplier can have.",
                "供应商可具有的类型。",
                ["supplier type"], ["供应商类型"],
                fields: [
                    F("Code", "The unique code of the type.", "类型的唯一代码。"),
                ]),
        ];
    }
}
