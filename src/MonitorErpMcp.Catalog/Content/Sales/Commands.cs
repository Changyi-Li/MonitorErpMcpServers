namespace MonitorErpMcp.Catalog.Content.Sales
{
    // The using-static sits inside the namespace so the imported Content(...) builder binds before
    // the enclosing MonitorErpMcp.Catalog.Content namespace in simple-name lookup.
    using static MonitorErpMcp.Catalog.Content.ContentEntryFactory;
    using MonitorErpMcp.Catalog.Model;

    /// <summary>
    /// Hand-authored content for Sales command records: bilingual descriptions and search aliases
    /// (en first, zh second), keyed by clrType and merged onto the structural catalog.
    /// </summary>
    public static class Commands
    {
        /// <summary>Hand-authored entries for this family, merged by <c>clrType</c> onto the structural catalog.</summary>
        public static readonly ContentEntry[] Entries =
        [
            // ---- BlanketOrderSales -----------------------------------------------------
            Content(
                "Monitor.API.Sales.Commands.BlanketOrderSale.AddBlanketOrderSalesRow",
                "Add a row to a blanket sales order.",
                "为总括销售订单添加行。",
                ["add row", "add blanket row"], ["添加总括订单行"]),
            Content(
                "Monitor.API.Sales.Commands.BlanketOrderSale.ChangeCustomerBlanketOrderSales",
                "Change the customer of a blanket sales order.",
                "更改总括销售订单的客户。",
                ["change customer"], ["更改客户"]),
            Content(
                "Monitor.API.Sales.Commands.BlanketOrderSale.ChangeOrderTypeBlanketOrderSales",
                "Change the order type of a blanket sales order.",
                "更改总括销售订单的订单类型。",
                ["change order type"], ["更改订单类型"]),
            Content(
                "Monitor.API.Sales.Commands.BlanketOrderSale.CreateBlanketOrderSales",
                "Create a new blanket sales order.",
                "创建新的总括销售订单。",
                ["create blanket order"], ["新建总括订单", "创建总括订单"]),
            Content(
                "Monitor.API.Sales.Commands.BlanketOrderSale.RemoveBlanketOrderSales",
                "Remove a blanket sales order.",
                "删除总括销售订单。",
                ["remove blanket order"], ["删除总括订单"]),
            Content(
                "Monitor.API.Sales.Commands.BlanketOrderSale.RemoveBlanketOrderSalesRow",
                "Remove a row from a blanket sales order.",
                "从总括销售订单移除行。",
                ["remove row"], ["移除总括订单行"]),
            Content(
                "Monitor.API.Sales.Commands.BlanketOrderSale.SetPropertiesBlanketOrderSales",
                "Set the properties of a blanket sales order.",
                "设置总括销售订单的属性。",
                ["set properties", "update blanket order"], ["设置属性", "更新总括订单"]),
            Content(
                "Monitor.API.Sales.Commands.BlanketOrderSale.UpdateBlanketOrderSalesRow",
                "Update a row in a blanket sales order.",
                "更新总括销售订单中的行。",
                ["update row"], ["更新总括订单行"]),

            // ---- BusinessOpportunities -------------------------------------------------
            Content(
                "Monitor.API.Sales.Commands.BusinessOpportunities.AddBusinessOpportunityActivity",
                "Add an activity to a business opportunity.",
                "为商机添加活动。",
                ["add activity"], ["添加活动"]),
            Content(
                "Monitor.API.Sales.Commands.BusinessOpportunities.RemoveBusinessOpportunityActivity",
                "Remove an activity from a business opportunity.",
                "从商机移除活动。",
                ["remove activity"], ["移除活动"]),
            Content(
                "Monitor.API.Sales.Commands.BusinessOpportunities.UpdateBusinessOpportunityActivity",
                "Update an activity on a business opportunity.",
                "更新商机上的活动。",
                ["update activity"], ["更新活动"]),

            // ---- CustomerEmployeeSpans --------------------------------------------------
            Content(
                "Monitor.API.Sales.CreateCustomerEmployeeSpan",
                "Create an employee span for a customer.",
                "为客户创建员工人数跨度记录。",
                ["employee span"], ["员工人数"]),

            // ---- CustomerOrderInvoices -------------------------------------------------
            Content(
                "Monitor.API.Sales.Commands.CustomerOrderInvoices.AddInvoiceRow",
                "Add a row to a customer order invoice.",
                "为客户订单发票添加行。",
                ["add invoice row"], ["添加发票行"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrderInvoices.ChangeCustomerCustomerOrderInvoice",
                "Change the customer of a customer order invoice.",
                "更改客户订单发票的客户。",
                ["change customer"], ["更改客户"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrderInvoices.ChangeOrderAmountCustomerOrderInvoice",
                "Change the order amount of a customer order invoice.",
                "更改客户订单发票的订单金额。",
                ["change order amount"], ["更改订单金额"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrderInvoices.CreateInvoice",
                "Create a new customer order invoice.",
                "创建新的客户订单发票。",
                ["create invoice", "new invoice"], ["新建发票", "创建发票"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrderInvoices.RemoveInvoice",
                "Remove a customer order invoice.",
                "删除客户订单发票。",
                ["remove invoice"], ["删除发票"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrderInvoices.RemoveInvoiceRow",
                "Remove a row from a customer order invoice.",
                "从客户订单发票移除行。",
                ["remove invoice row"], ["移除发票行"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrderInvoices.SetAftermarketProductRecordCustomerOrderInvoice",
                "Set the aftermarket product record on a customer order invoice.",
                "设置客户订单发票的售后产品记录。",
                ["aftermarket product record"], ["售后产品记录"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrderInvoices.SetCauseCode",
                "Set the cause code on a customer order invoice.",
                "设置客户订单发票的原因代码。",
                ["cause code"], ["原因代码"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrderInvoices.SetPropertiesCustomerOrderInvoice",
                "Set the properties of a customer order invoice.",
                "设置客户订单发票的属性。",
                ["set properties", "update invoice"], ["设置属性", "更新发票"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrderInvoices.SetCustomerOrderInvoiceRowCoding",
                "Set the coding on a customer order invoice row.",
                "设置客户订单发票行的编码。",
                ["row coding"], ["行编码"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrderInvoices.SplitInvoiceRow",
                "Split an invoice row into two rows.",
                "将发票行拆分为两行。",
                ["split row"], ["拆分行", "拆分发票行"]),
            Content(
                "Monitor.API.Sales.Commands.DeliveryReporting.UndoDeliveryForCustomerOrderInvoice",
                "Undo the delivery registered for a customer order invoice.",
                "撤销已为客户订单发票登记的交货。",
                ["undo delivery"], ["撤销交货"]),
            Content(
                "Monitor.API.Sales.Commands.DeliveryReporting.UndoDeliveryForCustomerOrderDeliveryRow",
                "Undo the delivery registered for a customer order delivery row.",
                "撤销已为客户订单交货行登记的交货。",
                ["undo delivery row"], ["撤销交货行"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrderInvoices.UpdateInvoiceRow",
                "Update a row in a customer order invoice.",
                "更新客户订单发票中的行。",
                ["update invoice row"], ["更新发票行"]),

            // ---- CustomerOrders --------------------------------------------------------
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.AddCustomerOrderActivity",
                "Add an activity to a customer order.",
                "为客户订单添加活动。",
                ["add activity"], ["添加活动"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.AddCommunicationAddressCustomerOrder",
                "Add a communication address to a customer order.",
                "为客户订单添加通信地址。",
                ["add address"], ["添加地址"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.AddCustomerOrderRow",
                "Add a row to a customer order.",
                "为客户订单添加行。",
                ["add order row"], ["添加订单行"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.AddSerialNumberInformationToCustomerOrderRow",
                "Add serial number information to a customer order row.",
                "为客户订单行添加序列号信息。",
                ["serial number", "add serial"], ["添加序列号信息"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.ChangeAccountGroupCustomerOrder",
                "Change the account group of a customer order.",
                "更改客户订单的科目组。",
                ["change account group"], ["更改科目组"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.ChangeCurrencyCustomerOrder",
                "Change the currency of a customer order.",
                "更改客户订单的币种。",
                ["change currency"], ["更改币种"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.ChangeCustomerCustomerOrder",
                "Change the customer of a customer order.",
                "更改客户订单的客户。",
                ["change customer"], ["更改客户"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.ChangeOrderAmountCustomerOrder",
                "Change the order amount of a customer order.",
                "更改客户订单的订单金额。",
                ["change order amount"], ["更改订单金额"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.ChangeOrderTypeCustomerOrder",
                "Change the order type of a customer order.",
                "更改客户订单的订单类型。",
                ["change order type"], ["更改订单类型"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.ChangeVatGroupCustomerOrder",
                "Change the VAT group of a customer order.",
                "更改客户订单的增值税组。",
                ["change vat group"], ["更改增值税组"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.ConfigureCustomerOrderRow",
                "Configure a customer order row (configurable parts).",
                "配置客户订单行（可配置物料）。",
                ["configure row", "configuration"], ["配置订单行"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.CreateCustomerOrder",
                "Create a new customer order.",
                "创建新的客户订单。",
                ["create order", "new customer order"], ["新建客户订单", "创建订单"],
                examples: [
                    Example(ExampleKind.Command,
                        "Create a customer order", "创建客户订单",
                        "Creates a new customer order with its rows.",
                        "创建带行的新客户订单。",
                        "api/v1/Sales/CustomerOrders/Create", "POST",
                        request: new { CustomerId = 1000, OrderNumber = "SO-5000", Rows = new[] { new { PartId = 1, Quantity = 10m, PriceEach = 12.5m } } },
                        response: new { RootEntityId = 5000 }),
                ]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.CreatePurchaseOrderFromCustomerOrderRow",
                "Create a purchase order from a customer order row.",
                "根据客户订单行创建采购订单。",
                ["create purchase order"], ["创建采购订单"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.GetAvailibleBlanketOrderRows",
                "Get the blanket order rows available for a customer order row.",
                "获取客户订单行可用的总括订单行。",
                ["blanket order rows"], ["可用总括订单行"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.GetSalesPriceInfo",
                "Get the sales price information for a customer order row.",
                "获取客户订单行的销售价格信息。",
                ["sales price info"], ["销售价格信息"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.GetQuantityChanges",
                "Get the quantity changes for a customer order row.",
                "获取客户订单行的数量变更。",
                ["quantity changes"], ["数量变更"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.GetRecipientOfTypeCustomerOrder",
                "Get the recipient of a given type on a customer order.",
                "获取客户订单上指定类型的收件人。",
                ["recipient"], ["收件人"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.ReleasePaymentPlanRow",
                "Release a payment plan row on a customer order.",
                "释放客户订单上的付款计划行。",
                ["release payment plan"], ["释放付款计划"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.RemoveCustomerOrder",
                "Remove a customer order.",
                "删除客户订单。",
                ["remove order"], ["删除客户订单"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.RemoveCustomerOrderActivity",
                "Remove an activity from a customer order.",
                "从客户订单移除活动。",
                ["remove activity"], ["移除活动"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.RemoveCommunicationAddressCustomerOrder",
                "Remove a communication address from a customer order.",
                "从客户订单移除通信地址。",
                ["remove address"], ["移除地址"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.RemoveLinkedManufacturingOrderOnCustomerOrderRow",
                "Remove a linked manufacturing order from a customer order row.",
                "从客户订单行移除关联的制造工单。",
                ["remove manufacturing order"], ["移除制造工单"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.RemoveLinkedPurchaseOrderRow",
                "Remove a linked purchase order row from a customer order row.",
                "从客户订单行移除关联的采购订单行。",
                ["remove purchase order row"], ["移除采购订单行"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.RemoveCustomerOrderRow",
                "Remove a row from a customer order.",
                "从客户订单移除行。",
                ["remove order row"], ["移除订单行"]),
            Content(
                "Monitor.API.Sales.Commands.DeliveryReporting.ReportDelivery",
                "Report a delivery against a customer order.",
                "针对客户订单上报交货。",
                ["report delivery", "deliver"], ["上报交货", "交货"],
                examples: [
                    Example(ExampleKind.Command,
                        "Report a delivery", "上报交货",
                        "Reports a delivered quantity for a customer order row.",
                        "上报客户订单行已交货的数量。",
                        "api/v1/Sales/CustomerOrders/ReportDeliveries", "POST",
                        request: new { DeliveryDate = "2026-08-04T00:00:00Z", Rows = new[] { new { CustomerOrderRowId = 5000, Quantity = 10m, DeleteFutureRest = true } } },
                        response: new { RootEntityId = 5000 }),
                ]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.SetAftermarketProductRecord",
                "Set the aftermarket product record on a customer order row.",
                "设置客户订单行的售后产品记录。",
                ["aftermarket product record"], ["售后产品记录"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.SetLinkedManufacturingOrderOnCustomerOrderRow",
                "Link a manufacturing order to a customer order row.",
                "将制造工单链接到客户订单行。",
                ["link manufacturing order"], ["关联制造工单"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.SetLinkedPurchaseOrderRowOnCustomerOrderRow",
                "Link a purchase order row to a customer order row.",
                "将采购订单行链接到客户订单行。",
                ["link purchase order"], ["关联采购订单行"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.SetPropertiesCustomerOrder",
                "Set the properties of a customer order.",
                "设置客户订单的属性。",
                ["set properties", "update customer order"], ["设置属性", "更新客户订单"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.SetCustomerOrderRowBlanketOrder",
                "Set the blanket order for a customer order row.",
                "为客户订单行设置总括订单。",
                ["blanket order row"], ["设置总括订单行"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.SetCustomerOrderRowCoding",
                "Set the coding on a customer order row.",
                "设置客户订单行的编码。",
                ["row coding"], ["行编码"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.SetCustomerOrderRowComparativePrice",
                "Set the comparative price on a customer order row.",
                "设置客户订单行的比较价格。",
                ["comparative price"], ["比较价格"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.SetCustomerOrderRowTransferProfile",
                "Set the transfer profile on a customer order row.",
                "设置客户订单行的转移配置文件。",
                ["transfer profile"], ["转移配置文件"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.UpdateCustomerOrderActivity",
                "Update an activity on a customer order.",
                "更新客户订单上的活动。",
                ["update activity"], ["更新活动"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.UpdateCommunicationAddressCustomerOrder",
                "Update a communication address on a customer order.",
                "更新客户订单上的通信地址。",
                ["update address"], ["更新地址"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.UpdateDeliveryAddressCustomerOrder",
                "Update the delivery address of a customer order.",
                "更新客户订单的交货地址。",
                ["delivery address"], ["交货地址"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.UpdateInvoiceAddressCustomerOrder",
                "Update the invoice address of a customer order.",
                "更新客户订单的开票地址。",
                ["invoice address"], ["开票地址"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.UpdateMailingAddressCustomerOrder",
                "Update the mailing address of a customer order.",
                "更新客户订单的邮寄地址。",
                ["mailing address"], ["邮寄地址"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.UpdateCustomerOrderPaymentPlan",
                "Update the payment plan of a customer order.",
                "更新客户订单的付款计划。",
                ["payment plan"], ["付款计划"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.UpdateCustomerOrderPaymentPlanRow",
                "Update a payment plan row of a customer order.",
                "更新客户订单的付款计划行。",
                ["payment plan row"], ["付款计划行"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.UpdateCustomerOrderRow",
                "Update a row in a customer order.",
                "更新客户订单中的行。",
                ["update order row"], ["更新订单行"]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.ValidateCustomerOrderCoding",
                "Validate the coding of a customer order.",
                "校验客户订单的编码。",
                ["validate coding"], ["校验编码"]),

            // ---- Customers -------------------------------------------------------------
            Content(
                "Monitor.API.Sales.Commands.Customers.AddCustomerActivity",
                "Add an activity to a customer.",
                "为客户添加活动。",
                ["add activity"], ["添加活动"]),
            Content(
                "Monitor.API.Sales.Commands.Customers.AddCommunicationAddressCustomer",
                "Add a communication address to a customer.",
                "为客户添加通信地址。",
                ["add address"], ["添加地址"]),
            Content(
                "Monitor.API.Sales.Commands.Customers.AddCustomerDeliveryAddress",
                "Add a delivery address to a customer.",
                "为客户添加交货地址。",
                ["add delivery address"], ["添加交货地址"]),
            Content(
                "Monitor.API.Sales.Commands.Customers.AddCustomerReference",
                "Add a reference to a customer.",
                "为客户添加参考。",
                ["add reference"], ["添加参考"]),
            Content(
                "Monitor.API.Sales.Commands.Customers.CreateCustomer",
                "Create a new customer master record.",
                "创建新的客户主记录。",
                ["create customer", "new customer"], ["新建客户", "创建客户"],
                examples: [
                    Example(ExampleKind.Command,
                        "Create a customer", "创建客户",
                        "Creates a new customer master record and returns its id.",
                        "创建新的客户主记录并返回其 id。",
                        "api/v1/Sales/Customers/Create", "POST",
                        request: new { Name = "Example AB", Code = "C-1000" },
                        response: new { RootEntityId = 1000 }),
                    Example(ExampleKind.Many,
                        "Create several customers", "批量创建客户",
                        "Creates multiple customers in one request via the /Many route; each array element is one customer.",
                        "通过 /Many 路由在一次请求中创建多个客户；数组的每个元素为一个客户。",
                        "api/v1/Sales/Customers/Create/Many", "POST",
                        request: new object[]
                        {
                            new { Name = "Example AB", Code = "C-1000" },
                            new { Name = "Example CD", Code = "C-1001" },
                        },
                        response: new object[0]),
                    Example(ExampleKind.Batch,
                        "Create a customer with references and properties", "创建客户并添加引用与属性",
                        "Creates a customer, adds a reference, sets properties, then reads it back — one /api/v1/Batch request, forwarding RootEntityId between steps.",
                        "在一次 /api/v1/Batch 请求中创建客户、添加引用、设置属性，然后回读；步骤之间传递 RootEntityId。",
                        steps: [
                            Step("api/v1/Sales/Customers/Create", "POST",
                                new { Name = "Example AB", Code = "C-1000" },
                                "Creates the customer; its RootEntityId feeds the next steps.", "创建客户；其 RootEntityId 供后续步骤使用。"),
                            Step("api/v1/Sales/Customers/AddReference", "POST",
                                new { CustomerId = 1000, Name = "Phone: 070-123 45 67", Note = "Primary contact" },
                                "Adds a reference to the new customer, forwarding RootEntityId into CustomerId.", "为新客户添加引用，将 RootEntityId 传递为 CustomerId。"),
                            Step("api/v1/Sales/Customers/SetProperties", "POST",
                                new { CustomerId = 1000, CreditLimit = new { Value = 10000m } },
                                "Sets properties on the new customer.", "为新客户设置属性。"),
                            Step("api/v1/Sales/Customers", "GET",
                                new { Id = 1000 },
                                "Reads the customer back to confirm.", "回读客户以确认。"),
                        ]),
                ]),
            Content(
                "Monitor.API.Sales.Commands.Customers.CreateInvoiceAddressCustomer",
                "Create an invoice address for a customer.",
                "为客户创建开票地址。",
                ["invoice address"], ["开票地址"]),
            Content(
                "Monitor.API.Sales.Commands.Customers.CreateVisitingAddressCustomer",
                "Create a visiting address for a customer.",
                "为客户创建访问地址。",
                ["visiting address"], ["访问地址"]),
            Content(
                "Monitor.API.Sales.Commands.Customers.RemoveCustomer",
                "Remove a customer.",
                "删除客户。",
                ["remove customer"], ["删除客户"]),
            Content(
                "Monitor.API.Sales.Commands.Customers.RemoveCustomerActivity",
                "Remove an activity from a customer.",
                "从客户移除活动。",
                ["remove activity"], ["移除活动"]),
            Content(
                "Monitor.API.Sales.Commands.Customers.RemoveCommunicationAddressCustomer",
                "Remove a communication address from a customer.",
                "从客户移除通信地址。",
                ["remove address"], ["移除地址"]),
            Content(
                "Monitor.API.Sales.Commands.Customers.RemoveCustomerDeliveryAddress",
                "Remove a delivery address from a customer.",
                "从客户移除交货地址。",
                ["remove delivery address"], ["移除交货地址"]),
            Content(
                "Monitor.API.Sales.Commands.Customers.RemoveInvoiceAddressCustomer",
                "Remove an invoice address from a customer.",
                "从客户移除开票地址。",
                ["remove invoice address"], ["移除开票地址"]),
            Content(
                "Monitor.API.Sales.Commands.Customers.RemoveCustomerReference",
                "Remove a reference from a customer.",
                "从客户移除参考。",
                ["remove reference"], ["移除参考"]),
            Content(
                "Monitor.API.Sales.Commands.Customers.RemoveVisitingAddressCustomer",
                "Remove a visiting address from a customer.",
                "从客户移除访问地址。",
                ["remove visiting address"], ["移除访问地址"]),
            Content(
                "Monitor.API.Sales.Commands.Customers.ResetToCountryDocumentSettings",
                "Reset a customer's document settings to the country defaults.",
                "将客户的单据设置重置为国家默认值。",
                ["reset document settings"], ["重置单据设置"]),
            Content(
                "Monitor.API.Sales.Commands.Customers.SetCustomerBlockedStatus",
                "Set whether a customer is blocked.",
                "设置客户是否被封锁。",
                ["block customer", "blocked status"], ["封锁客户", "客户封锁状态"]),
            Content(
                "Monitor.API.Sales.Commands.Customers.SetCustomerCountryDocumentSettings",
                "Set the country document settings for a customer.",
                "为客户设置国家单据设置。",
                ["country document settings"], ["国家单据设置"]),
            Content(
                "Monitor.API.Sales.Commands.Customers.SetPropertiesCustomer",
                "Set the properties of a customer.",
                "设置客户的属性。",
                ["set properties", "update customer"], ["设置属性", "更新客户"]),
            Content(
                "Monitor.API.Sales.Commands.Customers.UpdateCustomerActivity",
                "Update an activity on a customer.",
                "更新客户上的活动。",
                ["update activity"], ["更新活动"]),
            Content(
                "Monitor.API.Sales.Commands.Customers.UpdateCommunicationAddressCustomer",
                "Update a communication address on a customer.",
                "更新客户上的通信地址。",
                ["update address"], ["更新地址"]),
            Content(
                "Monitor.API.Sales.Commands.Customers.UpdateCustomerDeliveryAddress",
                "Update the delivery address of a customer.",
                "更新客户的交货地址。",
                ["update delivery address"], ["更新交货地址"]),
            Content(
                "Monitor.API.Sales.Commands.Customers.UpdateCustomerInvoiceAddress",
                "Update the invoice address of a customer.",
                "更新客户的开票地址。",
                ["update invoice address"], ["更新开票地址"]),
            Content(
                "Monitor.API.Sales.Commands.Customers.UpdateCustomerMailingAddress",
                "Update the mailing address of a customer.",
                "更新客户的邮寄地址。",
                ["update mailing address"], ["更新邮寄地址"]),
            Content(
                "Monitor.API.Sales.Commands.Customers.UpdateCustomerReference",
                "Update a reference on a customer.",
                "更新客户上的参考。",
                ["update reference"], ["更新参考"]),
            Content(
                "Monitor.API.Sales.Commands.Customers.UpdateCustomerVisitingAddress",
                "Update the visiting address of a customer.",
                "更新客户的访问地址。",
                ["update visiting address"], ["更新访问地址"]),

            // ---- FormReports -----------------------------------------------------------
            Content(
                "Monitor.API.Sales.Commands.FormReports.CreateAcknowledgement",
                "Create an acknowledgement (order confirmation) document.",
                "创建订单确认（回执）单据。",
                ["acknowledgement", "order confirmation"], ["订单确认", "回执"]),
            Content(
                "Monitor.API.Sales.Commands.FormReports.CreateDeliveryNoteCollectionDelivered",
                "Create a delivery note for a delivered collection.",
                "为已交货的汇总创建交货单。",
                ["delivery note", "collection delivered"], ["交货单"]),
            Content(
                "Monitor.API.Sales.Commands.FormReports.CreateDeliveryNoteDelivered",
                "Create a delivery note for delivered goods.",
                "为已交货的货物创建交货单。",
                ["delivery note"], ["交货单"]),
            Content(
                "Monitor.API.Sales.Commands.FormReports.CreateQuote",
                "Create a quote document.",
                "创建报价单据。",
                ["quote document"], ["报价单据"]),
            Content(
                "Monitor.API.Sales.Commands.FormReports.CreateSalesAgreement",
                "Create a sales agreement document.",
                "创建销售协议单据。",
                ["sales agreement document"], ["销售协议单据"]),
            Content(
                "Monitor.API.Sales.Commands.FormReports.CreateSalesInvoice",
                "Create a sales invoice document.",
                "创建销售发票单据。",
                ["sales invoice document"], ["销售发票单据"]),
            Content(
                "Monitor.API.Sales.Commands.FormReports.CreateSalesPickingList",
                "Create a sales picking list document.",
                "创建销售拣货单单据。",
                ["picking list document"], ["拣货单单据"]),
            Content(
                "Monitor.API.Sales.Commands.FormReports.CreateSalesTransportLabel",
                "Create a sales transport label document.",
                "创建销售运输标签单据。",
                ["transport label"], ["运输标签"]),
            Content(
                "Monitor.API.Sales.Commands.FormReports.CreateTraceabilityProtocol",
                "Create a traceability protocol document.",
                "创建追溯协议（追溯报告）单据。",
                ["traceability protocol"], ["追溯报告"]),
            Content(
                "Monitor.API.Sales.Commands.FormReports.PrintAcknowledgement",
                "Print an acknowledgement (order confirmation) document.",
                "打印订单确认（回执）单据。",
                ["print acknowledgement"], ["打印订单确认"]),
            Content(
                "Monitor.API.Sales.Commands.FormReports.PrintDeliveryNoteCollectionDelivered",
                "Print a delivery note for a delivered collection.",
                "打印已交货汇总的交货单。",
                ["print delivery note"], ["打印交货单"]),
            Content(
                "Monitor.API.Sales.Commands.FormReports.PrintDeliveryNoteDelivered",
                "Print a delivery note for delivered goods.",
                "打印已交货货物的交货单。",
                ["print delivery note"], ["打印交货单"]),
            Content(
                "Monitor.API.Sales.Commands.FormReports.PrintQuote",
                "Print a quote document.",
                "打印报价单据。",
                ["print quote"], ["打印报价"]),
            Content(
                "Monitor.API.Sales.Commands.FormReports.PrintSalesAgreement",
                "Print a sales agreement document.",
                "打印销售协议单据。",
                ["print sales agreement"], ["打印销售协议"]),
            Content(
                "Monitor.API.Sales.Commands.FormReports.PrintSalesInvoice",
                "Print a sales invoice document.",
                "打印销售发票单据。",
                ["print invoice"], ["打印发票"]),
            Content(
                "Monitor.API.Sales.Commands.FormReports.PrintSalesPickingList",
                "Print a sales picking list document.",
                "打印销售拣货单单据。",
                ["print picking list"], ["打印拣货单"]),
            Content(
                "Monitor.API.Sales.Commands.FormReports.PrintSalesTransportLabel",
                "Print a sales transport label document.",
                "打印销售运输标签单据。",
                ["print transport label"], ["打印运输标签"]),
            Content(
                "Monitor.API.Sales.Commands.FormReports.PrintTraceabilityProtocol",
                "Print a traceability protocol document.",
                "打印追溯协议（追溯报告）单据。",
                ["print traceability"], ["打印追溯报告"]),

            // ---- InvoiceLogs -----------------------------------------------------------
            Content(
                "Monitor.API.Inventory.Commands.Sales.InvoiceLogs.UpdateInvoiceLog",
                "Update an invoice log entry.",
                "更新发票日志条目。",
                ["update invoice log"], ["更新发票日志"]),

            // ---- PartConfigurations ----------------------------------------------------
            Content(
                "Monitor.API.Sales.Commands.PartConfigurations.ClonePartConfigurationForCustomerOrder",
                "Clone a part configuration for a customer order.",
                "为客户订单克隆物料配置。",
                ["clone configuration"], ["克隆物料配置"]),
            Content(
                "Monitor.API.Sales.Commands.PartConfigurations.ClonePartConfigurationForQuote",
                "Clone a part configuration for a quote.",
                "为报价克隆物料配置。",
                ["clone configuration"], ["克隆物料配置"]),
            Content(
                "Monitor.API.Sales.Commands.PartConfigurations.CreatePartConfigurationForCustomerOrder",
                "Create a part configuration for a customer order.",
                "为客户订单创建物料配置。",
                ["part configuration"], ["物料配置"]),
            Content(
                "Monitor.API.Sales.Commands.PartConfigurations.CreatePartConfigurationForCustomerOrderRow",
                "Create a part configuration for a customer order row.",
                "为客户订单行创建物料配置。",
                ["part configuration"], ["物料配置"]),
            Content(
                "Monitor.API.Sales.Commands.PartConfigurations.CreatePartConfigurationForQuote",
                "Create a part configuration for a quote.",
                "为报价创建物料配置。",
                ["part configuration"], ["物料配置"]),
            Content(
                "Monitor.API.Sales.Commands.PartConfigurations.CreatePartConfigurationForQuoteRow",
                "Create a part configuration for a quote row.",
                "为报价行创建物料配置。",
                ["part configuration"], ["物料配置"]),

            // ---- Quotes ----------------------------------------------------------------
            Content(
                "Monitor.API.Sales.Commands.Quotes.AddQuoteActivity",
                "Add an activity to a quote.",
                "为报价添加活动。",
                ["add activity"], ["添加活动"]),
            Content(
                "Monitor.API.Sales.Commands.Quotes.AddCommunicationAddressQuote",
                "Add a communication address to a quote.",
                "为报价添加通信地址。",
                ["add address"], ["添加地址"]),
            Content(
                "Monitor.API.Sales.Commands.Quotes.AddRelatedQuote",
                "Add a related quote to a quote.",
                "为报价添加关联报价。",
                ["related quote"], ["关联报价"]),
            Content(
                "Monitor.API.Sales.Commands.Quotes.AddQuoteRow",
                "Add a row to a quote.",
                "为报价添加行。",
                ["add quote row"], ["添加报价行"]),
            Content(
                "Monitor.API.Sales.Commands.Quotes.ChangeAccountGroupQuote",
                "Change the account group of a quote.",
                "更改报价的科目组。",
                ["change account group"], ["更改科目组"]),
            Content(
                "Monitor.API.Sales.Commands.Quotes.ChangeCurrencyQuote",
                "Change the currency of a quote.",
                "更改报价的币种。",
                ["change currency"], ["更改币种"]),
            Content(
                "Monitor.API.Sales.Commands.Quotes.ChangeCustomerQuote",
                "Change the customer of a quote.",
                "更改报价的客户。",
                ["change customer"], ["更改客户"]),
            Content(
                "Monitor.API.Sales.Commands.Quotes.ChangeOrderAmountQuote",
                "Change the order amount of a quote.",
                "更改报价的订单金额。",
                ["change order amount"], ["更改订单金额"]),
            Content(
                "Monitor.API.Sales.Commands.Quotes.ChangeQuoteTypeQuote",
                "Change the quote type.",
                "更改报价类型。",
                ["quote type"], ["更改报价类型"]),
            Content(
                "Monitor.API.Sales.Commands.Quotes.ChangeVatGroupQuote",
                "Change the VAT group of a quote.",
                "更改报价的增值税组。",
                ["change vat group"], ["更改增值税组"]),
            Content(
                "Monitor.API.Sales.Commands.Quotes.ConfigureQuoteRow",
                "Configure a quote row (configurable parts).",
                "配置报价行（可配置物料）。",
                ["configure row"], ["配置报价行"]),
            Content(
                "Monitor.API.Sales.Commands.Quotes.CreateQuote",
                "Create a new quote.",
                "创建新的报价。",
                ["create quote", "new quote"], ["新建报价", "创建报价"],
                examples: [
                    Example(ExampleKind.Command,
                        "Create a quote", "创建报价",
                        "Creates a new quote with its rows.",
                        "创建带行的新报价。",
                        "api/v1/Sales/Quotes/Create", "POST",
                        request: new { CustomerId = 1000, QuoteNumber = "Q-1000", Rows = new[] { new { PartId = 1, Quantity = 10m, PriceEach = 12.5m } } },
                        response: new { RootEntityId = 7000 }),
                ]),
            Content(
                "Monitor.API.Sales.Commands.Quotes.CreateOrderFromQuote",
                "Create a customer order from a quote.",
                "根据报价创建客户订单。",
                ["order from quote"], ["报价转订单"]),
            Content(
                "Monitor.API.Sales.Commands.Quotes.GetRecipientOfTypeQuote",
                "Get the recipient of a given type on a quote.",
                "获取报价上指定类型的收件人。",
                ["recipient"], ["收件人"]),
            Content(
                "Monitor.API.Sales.Commands.Quotes.RemoveQuote",
                "Remove a quote.",
                "删除报价。",
                ["remove quote"], ["删除报价"]),
            Content(
                "Monitor.API.Sales.Commands.Quotes.RemoveQuoteActivity",
                "Remove an activity from a quote.",
                "从报价移除活动。",
                ["remove activity"], ["移除活动"]),
            Content(
                "Monitor.API.Sales.Commands.Quotes.RemoveCommunicationAddressQuote",
                "Remove a communication address from a quote.",
                "从报价移除通信地址。",
                ["remove address"], ["移除地址"]),
            Content(
                "Monitor.API.Sales.Commands.Quotes.RemoveQuoteRow",
                "Remove a row from a quote.",
                "从报价移除行。",
                ["remove quote row"], ["移除报价行"]),
            Content(
                "Monitor.API.Sales.Commands.Quotes.RemoveRelatedQuote",
                "Remove a related quote from a quote.",
                "从报价移除关联报价。",
                ["remove related quote"], ["移除关联报价"]),
            Content(
                "Monitor.API.Sales.Commands.Quotes.SaveQuoteAs",
                "Save an existing quote as a new quote (copy).",
                "将现有报价另存为新报价（复制）。",
                ["save as", "copy quote"], ["另存为", "复制报价"]),
            Content(
                "Monitor.API.Sales.Commands.Quotes.SetPrimaryRelatedQuote",
                "Set the primary related quote on a quote.",
                "设置报价的主关联报价。",
                ["primary related quote"], ["主关联报价"]),
            Content(
                "Monitor.API.Sales.Commands.Quotes.SetPropertiesQuote",
                "Set the properties of a quote.",
                "设置报价的属性。",
                ["set properties", "update quote"], ["设置属性", "更新报价"]),
            Content(
                "Monitor.API.Sales.Commands.Quotes.SetQuoteRowCoding",
                "Set the coding on a quote row.",
                "设置报价行的编码。",
                ["row coding"], ["行编码"]),
            Content(
                "Monitor.API.Sales.Commands.Quotes.UpdateQuoteActivity",
                "Update an activity on a quote.",
                "更新报价上的活动。",
                ["update activity"], ["更新活动"]),
            Content(
                "Monitor.API.Sales.Commands.Quotes.UpdateCommunicationAddressQuote",
                "Update a communication address on a quote.",
                "更新报价上的通信地址。",
                ["update address"], ["更新地址"]),
            Content(
                "Monitor.API.Sales.Commands.Quotes.UpdateDeliveryAddressQuote",
                "Update the delivery address of a quote.",
                "更新报价的交货地址。",
                ["delivery address"], ["交货地址"]),
            Content(
                "Monitor.API.Sales.Commands.Quotes.UpdateMailingAddressQuote",
                "Update the mailing address of a quote.",
                "更新报价的邮寄地址。",
                ["mailing address"], ["邮寄地址"]),
            Content(
                "Monitor.API.Sales.Commands.Quotes.UpdateQuoteRow",
                "Update a row in a quote.",
                "更新报价中的行。",
                ["update quote row"], ["更新报价行"]),
            Content(
                "Monitor.API.Sales.Commands.Quotes.ValidateQuoteCoding",
                "Validate the coding of a quote.",
                "校验报价的编码。",
                ["validate coding"], ["校验编码"]),

            // ---- SalesAgreements -------------------------------------------------------
            Content(
                "Monitor.API.Sales.Commands.SalesAgreements.AddSalesAgreementRow",
                "Add a row to a sales agreement.",
                "为销售协议添加行。",
                ["add agreement row"], ["添加销售协议行"]),
            Content(
                "Monitor.API.Sales.Commands.SalesAgreements.CanCreateSalesAgreementUpwardAdjustmentRow",
                "Check whether an upward adjustment row can be created on a sales agreement.",
                "检查是否可在销售协议上创建上向调整行。",
                ["upward adjustment"], ["上向调整行"]),
            Content(
                "Monitor.API.Sales.Commands.SalesAgreements.CreateSalesAgreement",
                "Create a new sales agreement.",
                "创建新的销售协议。",
                ["create agreement"], ["新建销售协议", "创建协议"]),
            Content(
                "Monitor.API.Sales.Commands.SalesAgreements.CreateSalesAgreementUpwardAdjustmentRow",
                "Create an upward adjustment row on a sales agreement.",
                "在销售协议上创建上向调整行。",
                ["upward adjustment row"], ["创建调整行"]),
            Content(
                "Monitor.API.Sales.Commands.SalesAgreements.SetPropertiesSalesAgreement",
                "Set the properties of a sales agreement.",
                "设置销售协议的属性。",
                ["set properties", "update agreement"], ["设置属性", "更新销售协议"]),
            Content(
                "Monitor.API.Sales.Commands.SalesAgreements.UpdateSalesAgreementRow",
                "Update a row in a sales agreement.",
                "更新销售协议中的行。",
                ["update agreement row"], ["更新销售协议行"]),

            // ---- SalesPickingListRowQuantities -----------------------------------------
            Content(
                "Monitor.API.Sales.Commands.SalesPickingListRowQuantities.SetSalesPickingListRowQuantity",
                "Set the quantity of a sales picking list row.",
                "设置销售拣货单行的数量。",
                ["row quantity"], ["行数量"]),

            // ---- SalesPickingLists -----------------------------------------------------
            Content(
                "Monitor.API.Sales.Commands.SalesPickingLists.AddPackageRowToSalesPickingList",
                "Add a package row to a sales picking list.",
                "为销售拣货单添加包装行。",
                ["add package row"], ["添加包装行"]),
            Content(
                "Monitor.API.Sales.Commands.SalesPickingLists.ClearPackageRowOnPickingList",
                "Clear a package row on a sales picking list.",
                "清除销售拣货单上的包装行。",
                ["clear package row"], ["清除包装行"]),
            Content(
                "Monitor.API.Sales.Commands.SalesPickingLists.CompletePackageRowOnPickingList",
                "Complete a package row on a sales picking list.",
                "完成销售拣货单上的包装行。",
                ["complete package row"], ["完成包装行"]),
            Content(
                "Monitor.API.Sales.Commands.SalesPickingLists.ConfirmSalesPickingList",
                "Confirm a sales picking list.",
                "确认销售拣货单。",
                ["confirm picking list"], ["确认拣货单"]),
            Content(
                "Monitor.API.Sales.CreateSalesPickingList",
                "Create a new sales picking list.",
                "创建新的销售拣货单。",
                ["create picking list", "new picking list"], ["新建拣货单", "创建拣货单"]),
            Content(
                "Monitor.API.Sales.GetWithdrawalInformation",
                "Get the withdrawal information for a sales picking list.",
                "获取销售拣货单的领料信息。",
                ["withdrawal information"], ["领料信息"]),
            Content(
                "Monitor.API.Sales.Commands.SalesPickingLists.ReleaseSalesPickingList",
                "Release a sales picking list for picking.",
                "释放销售拣货单以进行拣选。",
                ["release picking list"], ["释放拣货单"]),
            Content(
                "Monitor.API.Sales.RemoveSalesPickingList",
                "Remove a sales picking list.",
                "删除销售拣货单。",
                ["remove picking list"], ["删除拣货单"]),
            Content(
                "Monitor.API.Sales.Commands.SalesPickingLists.RemovePackageRowFromPickingList",
                "Remove a package row from a sales picking list.",
                "从销售拣货单移除包装行。",
                ["remove package row"], ["移除包装行"]),
            Content(
                "Monitor.API.Sales.Commands.SalesPickingLists.UpdatePackageRowOnPickingList",
                "Update a package row on a sales picking list.",
                "更新销售拣货单上的包装行。",
                ["update package row"], ["更新包装行"]),

            // ---- SalesPrice ------------------------------------------------------------
            Content(
                "Monitor.API.Sales.Commands.SalesPrice.AddStaggeredSalesPrice",
                "Add a staggered sales price.",
                "添加阶梯销售价格。",
                ["staggered price"], ["阶梯价格"]),
            Content(
                "Monitor.API.Sales.Commands.SalesPrice.ClearStaggeredSalesPrices",
                "Clear all staggered sales prices.",
                "清除所有阶梯销售价格。",
                ["clear prices"], ["清除阶梯价格"]),
            Content(
                "Monitor.API.Sales.Commands.SalesPrice.CreateSalesPrice",
                "Create a new sales price.",
                "创建新的销售价格。",
                ["create sales price", "new price"], ["新建销售价格", "创建价格"]),
            Content(
                "Monitor.API.Sales.Commands.SalesPrice.GetCustomerPrice",
                "Get the price for a customer.",
                "获取客户的价格。",
                ["customer price"], ["客户价格"]),
            Content(
                "Monitor.API.Sales.Commands.SalesPrice.GetPriceListPriceInfo",
                "Get price list price information. Obsoleted in 25.5 — use GetPriceListPrice.",
                "获取价目表价格信息。25.5 版已弃用 —— 请改用 GetPriceListPrice。",
                ["price list price info"], ["价目表价格信息"]),
            Content(
                "Monitor.API.Sales.Commands.SalesPrice.GetPriceListPrice",
                "Get a price from the price list.",
                "从价目表获取价格。",
                ["price list price"], ["价目表价格"]),
            Content(
                "Monitor.API.Sales.Commands.SalesPrice.RemoveStaggeredSalesPrice",
                "Remove a staggered sales price.",
                "移除阶梯销售价格。",
                ["remove staggered price"], ["移除阶梯价格"]),
            Content(
                "Monitor.API.Sales.Commands.SalesPrice.SetPropertiesSalesPrice",
                "Set the properties of a sales price.",
                "设置销售价格的属性。",
                ["set properties", "update price"], ["设置属性", "更新价格"]),
            Content(
                "Monitor.API.Sales.Commands.SalesPrice.UpdateStaggeredSalesPrice",
                "Update a staggered sales price.",
                "更新阶梯销售价格。",
                ["update staggered price"], ["更新阶梯价格"]),

            // ---- Shipments -------------------------------------------------------------
            Content(
                "Monitor.API.Sales.Commands.Shipments.AddCustomerOrderSourceToShipment",
                "Add a customer order as a source to a shipment.",
                "将客户订单作为来源添加到装运。",
                ["customer order source"], ["客户订单来源"]),
            Content(
                "Monitor.API.Sales.Commands.Shipments.AddShipmentPackageRowInformation",
                "Add package row information to a shipment.",
                "为装运添加包装行信息。",
                ["package row information"], ["包装行信息"]),
            Content(
                "Monitor.API.Sales.Commands.Shipments.CreateCustomerOrderShipment",
                "Create a shipment from a customer order.",
                "根据客户订单创建装运。",
                ["create shipment"], ["新建装运", "创建装运"]),
            Content(
                "Monitor.API.Sales.Commands.Shipments.GetShipmentTrackingLink",
                "Get the tracking link for a shipment.",
                "获取装运的跟踪链接。",
                ["tracking link", "tracking"], ["跟踪链接", "物流跟踪"]),
            Content(
                "Monitor.API.Sales.Commands.Shipments.SetPropertiesShipment",
                "Set the properties of a shipment.",
                "设置装运的属性。",
                ["set properties", "update shipment"], ["设置属性", "更新装运"]),
            Content(
                "Monitor.API.Sales.Commands.Shipments.UpdateShipmentPackageInformation",
                "Update the package information of a shipment.",
                "更新装运的包装信息。",
                ["package information"], ["更新包装信息"]),

            // ---- ShippingInformations --------------------------------------------------
            Content(
                "Monitor.API.Sales.Commands.ShippingInformations.UpdateCustomerOrderShippingInformationRow",
                "Update a shipping information row of a customer order.",
                "更新客户订单的装运信息行。",
                ["shipping information"], ["装运信息"]),
        ];
    }
}
