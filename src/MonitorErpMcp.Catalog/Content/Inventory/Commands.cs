namespace MonitorErpMcp.Catalog.Content.Inventory
{
    // The using-static sits inside the namespace so the imported Content(...) builder binds before
    // the enclosing MonitorErpMcp.Catalog.Content namespace in simple-name lookup.
    using static MonitorErpMcp.Catalog.Content.ContentEntryFactory;

    /// <summary>
    /// Hand-authored content for Inventory command records: bilingual descriptions and search aliases
    /// (en first, zh second), keyed by clrType and merged onto the structural catalog.
    /// </summary>
    public static class Commands
    {
        /// <summary>Hand-authored entries for this family, merged by <c>clrType</c> onto the structural catalog.</summary>
        public static readonly ContentEntry[] Entries =
        [
            // ---- CaseEntries -------------------------------------------------------------
            Content(
                "Monitor.API.Inventory.Commands.CaseEntries.CalculateCaseEntryCost",
                "Calculate the cost of a case entry.",
                "计算案例登记的成本。",
                ["calculate cost", "case costing"], ["计算成本", "案例成本计算"]),
            Content(
                "Monitor.API.Inventory.Commands.CaseEntries.CreateActivityCaseEntry",
                "Create an activity on a case entry.",
                "在案例登记上创建活动。",
                ["create activity"], ["创建活动", "新建活动"]),
            Content(
                "Monitor.API.Inventory.Commands.CaseEntries.CreatePhaseCaseEntry",
                "Create a phase on a case entry.",
                "在案例登记上创建阶段。",
                ["create phase"], ["创建阶段", "新建阶段"]),
            Content(
                "Monitor.API.Inventory.Commands.CaseEntries.RemoveActivityCaseEntry",
                "Remove an activity from a case entry.",
                "从案例登记移除活动。",
                ["remove activity"], ["移除活动", "删除活动"]),
            Content(
                "Monitor.API.Inventory.Commands.CaseEntries.RemovePhaseCaseEntry",
                "Remove a phase from a case entry.",
                "从案例登记移除阶段。",
                ["remove phase"], ["移除阶段", "删除阶段"]),
            Content(
                "Monitor.API.Inventory.Commands.CaseEntries.SetCaseEntryReplacementDelivery",
                "Set the replacement delivery on a case entry.",
                "设置案例登记的替换交货。",
                ["replacement delivery"], ["替换交货"]),
            Content(
                "Monitor.API.Inventory.Commands.CaseEntries.UpdateActivityCaseEntry",
                "Update an activity on a case entry.",
                "更新案例登记上的活动。",
                ["update activity"], ["更新活动"]),
            Content(
                "Monitor.API.Inventory.Commands.CaseEntries.UpdatePhaseCaseEntry",
                "Update a phase on a case entry.",
                "更新案例登记上的阶段。",
                ["update phase"], ["更新阶段"]),
            Content(
                "Monitor.API.Inventory.Commands.CaseEntries.AddCommunicationAddressCaseEntry",
                "Add a communication address to a case entry.",
                "为案例登记添加通信地址。",
                ["add address", "communication address"], ["添加地址", "通信地址"]),
            Content(
                "Monitor.API.Inventory.Commands.CaseEntries.ChangeCaseEntryNumber",
                "Change the number of a case entry.",
                "更改案例登记的编号。",
                ["change number"], ["更改编号"]),
            Content(
                "Monitor.API.Inventory.Commands.CaseEntries.CreateCaseEntry",
                "Create a new case entry.",
                "创建新的案例登记。",
                ["create case", "new case entry"], ["新建案例", "创建案例登记"]),
            Content(
                "Monitor.API.Inventory.Commands.CaseEntries.CreateCaseEntryFormReport",
                "Create a form report for a case entry.",
                "为案例登记创建表单报告。",
                ["case form report"], ["案例表单报告"]),
            Content(
                "Monitor.API.Inventory.Commands.CaseEntries.RemoveCaseEntry",
                "Remove a case entry.",
                "删除案例登记。",
                ["remove case"], ["删除案例"]),
            Content(
                "Monitor.API.Inventory.Commands.CaseEntries.RemoveCommunicationAddressCaseEntry",
                "Remove a communication address from a case entry.",
                "从案例登记移除通信地址。",
                ["remove address"], ["移除地址"]),
            Content(
                "Monitor.API.Inventory.Commands.CaseEntries.UpdateCaseEntry",
                "Set the properties of a case entry.",
                "设置案例登记的属性。",
                ["set properties", "update case"], ["设置属性", "更新案例"]),
            Content(
                "Monitor.API.Inventory.Commands.CaseEntries.UpdateCommunicationAddressCaseEntry",
                "Update a communication address on a case entry.",
                "更新案例登记上的通信地址。",
                ["update address"], ["更新地址"]),
            Content(
                "Monitor.API.Inventory.Commands.CaseEntries.CreateCaseEntryAdditionalCost",
                "Create an additional cost on a case entry.",
                "在案例登记上创建附加成本。",
                ["create additional cost"], ["创建附加成本"]),
            Content(
                "Monitor.API.Inventory.Commands.CaseEntries.RemoveCaseEntryAdditionalCost",
                "Remove an additional cost from a case entry.",
                "从案例登记移除附加成本。",
                ["remove additional cost"], ["移除附加成本"]),
            Content(
                "Monitor.API.Inventory.Commands.CaseEntries.UpdateCaseEntryAdditionalCost",
                "Update an additional cost on a case entry.",
                "更新案例登记上的附加成本。",
                ["update additional cost"], ["更新附加成本"]),
            Content(
                "Monitor.API.Inventory.Commands.CaseEntries.CreateCaseEntryLink",
                "Create a link between a case entry and another record.",
                "创建案例登记与其他记录的链接。",
                ["create case link"], ["创建案例链接"]),
            Content(
                "Monitor.API.Inventory.Commands.CaseEntries.RemoveCaseEntryLink",
                "Remove a link from a case entry.",
                "移除案例登记的链接。",
                ["remove case link"], ["移除案例链接"]),
            Content(
                "Monitor.API.Inventory.Commands.CaseEntries.UpdateCaseEntryLink",
                "Update a link on a case entry.",
                "更新案例登记上的链接。",
                ["update case link"], ["更新案例链接"]),
            Content(
                "Monitor.API.Inventory.Commands.CaseEntries.CreateCasePartLink",
                "Link a part (material) to a case entry.",
                "将物料链接到案例登记。",
                ["create case part link"], ["创建案例物料链接"]),
            Content(
                "Monitor.API.Inventory.Commands.CaseEntries.RemoveCasePartLink",
                "Remove a part link from a case entry.",
                "移除案例登记的物料链接。",
                ["remove case part link"], ["移除案例物料链接"]),
            Content(
                "Monitor.API.Inventory.Commands.CaseEntries.UpdateCasePartLink",
                "Update a part link on a case entry.",
                "更新案例登记上的物料链接。",
                ["update case part link"], ["更新案例物料链接"]),
            Content(
                "Monitor.API.Inventory.Commands.CaseEntries.SetCaseEntryManufacturingOrder",
                "Set the manufacturing order on a case entry.",
                "设置案例登记的制造工单。",
                ["manufacturing order"], ["制造工单", "生产工单"]),
            Content(
                "Monitor.API.Inventory.Commands.CaseEntries.SetCaseEntryPart",
                "Set the part on a case entry.",
                "设置案例登记的物料。",
                ["set part"], ["设置物料"]),
            Content(
                "Monitor.API.Inventory.Commands.CaseEntries.SetCaseEntryProductRecord",
                "Set the product record (serial/batch) on a case entry.",
                "设置案例登记的产品记录（序列号/批次）。",
                ["set product record"], ["设置产品记录"]),

            // ---- Locations --------------------------------------------------------------
            Content(
                "Monitor.API.Inventory.Commands.Locations.AddStockPackage",
                "Add a stock package (pallet) to a location.",
                "向库位添加库存包装（托盘）。",
                ["add package", "stock package", "pallet"], ["添加库存包装", "添加托盘"]),
            Content(
                "Monitor.API.Inventory.Commands.Locations.GetLocationContents",
                "Get the contents of a location.",
                "获取库位的内容。",
                ["location contents", "location content"], ["库位内容"]),
            Content(
                "Monitor.API.Inventory.Commands.Locations.MoveStockPackage",
                "Move a stock package (pallet) between locations.",
                "在库位之间移动库存包装（托盘）。",
                ["move package", "move pallet"], ["移动库存包装", "移动托盘"]),
            Content(
                "Monitor.API.Inventory.Commands.Locations.RemoveStockPackage",
                "Remove a stock package (pallet) from a location.",
                "从库位移除库存包装（托盘）。",
                ["remove package"], ["移除库存包装", "移除托盘"]),
            Content(
                "Monitor.API.Inventory.Commands.Locations.SetLocationBlockedStatus",
                "Set whether a location is blocked.",
                "设置库位是否被封锁。",
                ["block location", "blocked status"], ["封锁库位", "库位封锁状态"]),

            // ---- Parts ------------------------------------------------------------------
            Content(
                "Monitor.API.Inventory.Commands.Parts.CreatePartDefaultTransportLabel",
                "Create the default transport label for a part.",
                "为物料创建默认运输标签。",
                ["create transport label"], ["创建运输标签"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.RemovePartDefaultTransportLabel",
                "Remove the default transport label from a part.",
                "移除物料的默认运输标签。",
                ["remove transport label"], ["移除运输标签"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.AddPartActivity",
                "Log an activity against a part.",
                "为物料记录一项活动。",
                ["add activity", "log activity"], ["添加活动", "记录活动"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.AddCustomerPartLink",
                "Link a customer to a part.",
                "将客户链接到物料。",
                ["customer part link", "link customer"], ["客户物料链接"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.AddDrawing",
                "Add a drawing to a part.",
                "为物料添加图纸。",
                ["add drawing"], ["添加图纸"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.AddDrawingRevision",
                "Add a drawing revision to a part.",
                "为物料添加图纸修订版。",
                ["add drawing revision"], ["添加图纸修订"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.AddPartUnitUsage",
                "Add a unit usage record for a part.",
                "为物料添加单位用量记录。",
                ["unit usage"], ["单位用量"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.AddRevision",
                "Add a revision to a part.",
                "为物料添加修订版。",
                ["add revision"], ["添加修订"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.AddStaggeredCustomerPartLinkPrice",
                "Add a staggered price for a customer-part link.",
                "为客户物料链接添加阶梯价格。",
                ["staggered price", "customer price"], ["阶梯价格", "客户价格"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.AddStaggeredSupplierPartLinkPrice",
                "Add a staggered price for a supplier-part link.",
                "为供应商物料链接添加阶梯价格。",
                ["staggered price", "supplier price"], ["阶梯价格", "供应商价格"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.AddSupplierPartLink",
                "Link a supplier to a part.",
                "将供应商链接到物料。",
                ["supplier part link", "link supplier"], ["供应商物料链接"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.ApplyPartTemplate",
                "Apply a part template to an existing part.",
                "将物料模板应用到现有物料。",
                ["apply template"], ["应用模板", "套用模板"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.ChangePartDefaultUnit",
                "Change the default unit of a part.",
                "更改物料的默认单位。",
                ["change unit", "default unit"], ["更改单位", "默认单位"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.CheckDeliveryTime",
                "Check the delivery time for a part and quantity.",
                "检查物料与数量的交货时间。",
                ["check delivery time", "delivery time"], ["检查交货时间", "交货时间"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.CreatePart",
                "Create a new part in inventory.",
                "在库存中创建新物料。",
                ["create part", "new part"], ["新建物料", "创建物料"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.CreateHyperLink",
                "Create a hyperlink on a part.",
                "为物料创建超链接。",
                ["create link", "create hyperlink"], ["创建超链接"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.CreatePartLocation",
                "Create a location record for a part.",
                "为物料创建库位记录。",
                ["create location", "new location"], ["创建库位", "新建库位"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.CreatePartOtherIdentity",
                "Create an alternative identity for a part.",
                "为物料创建其他标识。",
                ["create other identity"], ["创建其他标识"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.GetFromPartLocations",
                "Get the from-locations registered for a part, for stock transfers.",
                "获取物料注册的源库位，用于库存转移。",
                ["from locations", "transfer from"], ["源库位", "转出库位"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.GetPartBalanceInfo",
                "Get the stock balance information for a part.",
                "获取物料的库存余额信息。",
                ["balance info", "stock balance"], ["库存余额信息"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.GetPartLocationReservations",
                "Get the reservations against a part's locations.",
                "获取物料库位的预留信息。",
                ["reservations", "location reservation"], ["库位预留"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.GetToPartLocations",
                "Get the to-locations registered for a part, for stock transfers.",
                "获取物料注册的目的库位，用于库存转移。",
                ["to locations", "transfer to"], ["目的库位", "转入库位"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.InactivatePart",
                "Inactivate a part so it can no longer be used.",
                "停用物料，使其不再可用。",
                ["inactivate", "deactivate part"], ["停用物料", "禁用物料"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.MoveStockBalance",
                "Move stock balance between locations for a part.",
                "在物料的不同库位之间移动库存余额。",
                ["move stock", "transfer stock"], ["移动库存", "转移库存"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.ReactivatePart",
                "Reactivate an inactivated part.",
                "重新启用已停用的物料。",
                ["reactivate"], ["重新启用物料", "恢复物料"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.RefillPickLocation",
                "Refill a pick location with stock from another location.",
                "用其他库位的库存补满拣货库位。",
                ["refill", "pick location"], ["补货", "拣货库位补货"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.RemovePart",
                "Remove a part from inventory.",
                "从库存中删除物料。",
                ["remove part", "delete part"], ["删除物料"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.RemovePartActivity",
                "Remove an activity from a part.",
                "从物料移除活动。",
                ["remove activity"], ["移除活动"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.RemoveCustomerPartLink",
                "Remove the link between a customer and a part.",
                "移除客户与物料的链接。",
                ["remove customer link"], ["移除客户物料链接"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.RemoveDrawing",
                "Remove a drawing from a part.",
                "移除物料的图纸。",
                ["remove drawing"], ["移除图纸"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.RemoveDrawingRevision",
                "Remove a drawing revision from a part.",
                "移除物料的图纸修订版。",
                ["remove drawing revision"], ["移除图纸修订"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.RemoveHyperLink",
                "Remove a hyperlink from a part.",
                "移除物料的超链接。",
                ["remove link"], ["移除超链接"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.RemovePartLocation",
                "Remove a location record from a part.",
                "移除物料的库位记录。",
                ["remove location"], ["移除库位"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.RemovePartOtherIdentity",
                "Remove an alternative identity from a part.",
                "移除物料的其他标识。",
                ["remove other identity"], ["移除其他标识"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.RemovePartUnitUsage",
                "Remove a unit usage record from a part.",
                "移除物料的单位用量记录。",
                ["remove unit usage"], ["移除单位用量"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.RemoveRevision",
                "Remove a revision from a part.",
                "移除物料的修订版。",
                ["remove revision"], ["移除修订"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.RemoveStaggeredCustomerPartLinkPrice",
                "Remove a staggered price from a customer-part link.",
                "移除客户物料链接的阶梯价格。",
                ["remove staggered price"], ["移除阶梯价格"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.RemoveStaggeredSupplierPartLinkPrice",
                "Remove a staggered price from a supplier-part link.",
                "移除供应商物料链接的阶梯价格。",
                ["remove staggered price"], ["移除阶梯价格"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.RemoveSupplierPartLink",
                "Remove the link between a supplier and a part.",
                "移除供应商与物料的链接。",
                ["remove supplier link"], ["移除供应商物料链接"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.ReportStockCount",
                "Report a stock count result for a part. Obsoleted in 25.8 — use StockCount.",
                "上报物料库存盘点结果。25.8 版已弃用 —— 请改用 StockCount。",
                ["report stock count"], ["上报盘点", "上报库存盘点"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.SavePartAs",
                "Save an existing part as a new part (copy).",
                "将现有物料另存为新物料（复制）。",
                ["save as", "copy part"], ["另存为", "复制物料"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.SetActiveDrawingRevision",
                "Set the active drawing revision of a part.",
                "设置物料的活动图纸修订版。",
                ["active drawing revision"], ["设置活动图纸修订"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.SetActiveRevision",
                "Set the active revision of a part.",
                "设置物料的活动修订版。",
                ["active revision"], ["设置活动修订"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.SetActiveSupplierPartLink",
                "Set the active supplier-part link of a part.",
                "设置物料的活动的供应商物料链接。",
                ["active supplier link"], ["设置活动供应商链接"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.SetPropertiesPart",
                "Set the properties of an existing part.",
                "设置现有物料的属性。",
                ["set properties", "update part"], ["设置属性", "更新物料"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.StockCount",
                "Report the result of a physical stock count for a part.",
                "上报物料的实物盘点结果。",
                ["stock count"], ["库存盘点", "实物盘点"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.UnplannedArrivalStockMovement",
                "Register an unplanned arrival (inbound) stock movement for a part.",
                "为物料登记计划外的入库库存移动。",
                ["unplanned arrival", "inbound movement"], ["计划外入库", "计划外收货"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.UnplannedWithdrawalStockMovement",
                "Register an unplanned withdrawal (outbound) stock movement for a part.",
                "为物料登记计划外的出库库存移动。",
                ["unplanned withdrawal", "outbound movement"], ["计划外出库", "计划外领料"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.UpdatePartActivity",
                "Update an activity on a part.",
                "更新物料上的活动。",
                ["update activity"], ["更新活动"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.UpdateAlloyQuantity",
                "Update the alloy quantity declared for a part.",
                "更新物料申报的合金用量。",
                ["update alloy"], ["更新合金用量"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.UpdateCustomerPartLink",
                "Update a customer-part link.",
                "更新客户物料链接。",
                ["update customer link"], ["更新客户物料链接"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.UpdatePartDescription",
                "Update the description of a part.",
                "更新物料的描述。",
                ["update description"], ["更新物料描述"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.UpdateDrawing",
                "Update a drawing on a part.",
                "更新物料上的图纸。",
                ["update drawing"], ["更新图纸"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.UpdateDrawingRevision",
                "Update a drawing revision on a part.",
                "更新物料上的图纸修订版。",
                ["update drawing revision"], ["更新图纸修订"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.UpdateHyperLink",
                "Update a hyperlink on a part.",
                "更新物料上的超链接。",
                ["update link"], ["更新超链接"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.UpdatePartLocation",
                "Update a location record for a part.",
                "更新物料的库位记录。",
                ["update location"], ["更新库位"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.UpdatePartBlockedStatus",
                "Set whether a part is blocked.",
                "设置物料是否被封锁。",
                ["block part", "blocked status"], ["封锁物料", "物料封锁状态"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.UpdatePartOtherIdentity",
                "Update an alternative identity of a part.",
                "更新物料的其他标识。",
                ["update other identity"], ["更新其他标识"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.UpdatePartPlanningInformation",
                "Update the planning information of a part.",
                "更新物料的计划信息。",
                ["update planning"], ["更新计划信息"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.UpdatePartPurchaseExpenseValues",
                "Update the purchase expense values of a part.",
                "更新物料的采购费用值。",
                ["update purchase expense"], ["更新采购费用"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.UpdatePartUnitUsage",
                "Update a unit usage record for a part.",
                "更新物料的单位用量记录。",
                ["update unit usage"], ["更新单位用量"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.UpdateRevision",
                "Update a revision of a part.",
                "更新物料的修订版。",
                ["update revision"], ["更新修订"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.UpdateStaggeredCustomerPartLinkPrice",
                "Update a staggered price on a customer-part link.",
                "更新客户物料链接的阶梯价格。",
                ["update staggered price"], ["更新阶梯价格"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.UpdateStaggeredSupplierPartLinkPrice",
                "Update a staggered price on a supplier-part link.",
                "更新供应商物料链接的阶梯价格。",
                ["update staggered price"], ["更新阶梯价格"]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.UpdateSupplierPartLink",
                "Update a supplier-part link.",
                "更新供应商物料链接。",
                ["update supplier link"], ["更新供应商物料链接"]),

            // ---- PhysicalInventoryLists -------------------------------------------------
            Content(
                "Monitor.API.Inventory.Commands.PhysicalInventoryLists.ReportPhysicalInventoryRow",
                "Report the counted quantity for a row of a physical inventory list.",
                "上报实物盘点清单中一行的盘点数量。",
                ["report row", "count result"], ["上报盘点行", "上报盘点结果"]),

            // ---- PriceChangeLogs --------------------------------------------------------
            Content(
                "Monitor.API.Inventory.Commands.PriceChangeLogs.UpdatePriceChangeLog",
                "Update a price change log entry.",
                "更新价格变更日志条目。",
                ["update price change"], ["更新价格变更"]),
            Content(
                "Monitor.API.Inventory.Commands.PriceChangeLogs.UpdatePriceChangeLogBalancePerWarehouse",
                "Update the per-warehouse balance of a price change log entry.",
                "更新价格变更日志条目的分仓库余额。",
                ["price change balance"], ["价格变更余额"]),

            // ---- ProductRecords ---------------------------------------------------------
            Content(
                "Monitor.API.Inventory.Commands.ProductRecords.ChangeOwnerProductRecord",
                "Change the owner of a product record.",
                "更改产品记录的所有者。",
                ["change owner"], ["更改所有者"]),
            Content(
                "Monitor.API.Inventory.Commands.ProductRecords.CreateProductRecord",
                "Create a new product record (serial/batch tracked product).",
                "创建新的产品记录（序列号/批次追溯产品）。",
                ["create product record", "new serial"], ["新建产品记录", "创建产品记录"]),
            Content(
                "Monitor.API.Inventory.Commands.ProductRecords.CreateAdditionalIDs",
                "Create additional identifiers for a product record.",
                "为产品记录创建附加标识。",
                ["create additional id"], ["创建附加标识"]),
            Content(
                "Monitor.API.Inventory.Commands.ProductRecords.CreateOrUpdateProductRecordWithExtraFieldValues",
                "Create or update a product record together with its extra field values.",
                "创建或更新产品记录及其附加字段值。",
                ["extra field values", "upsert product record"], ["创建或更新产品记录"]),
            Content(
                "Monitor.API.Inventory.Commands.ProductRecords.GetManufacturingProductRecordStructure",
                "Get the manufacturing structure of a product record.",
                "获取产品记录的制造结构。",
                ["manufacturing structure"], ["制造结构"]),
            Content(
                "Monitor.API.Inventory.Commands.ProductRecords.GetProductRecordPartLocations",
                "Get the part locations where a product record is stored.",
                "获取产品记录存放的物料库位。",
                ["part locations"], ["产品记录库位"]),
            Content(
                "Monitor.API.Inventory.Commands.ProductRecords.GetProductRecords",
                "Get product records matching a filter.",
                "获取符合筛选条件的产品记录。",
                ["get product records", "find product records"], ["获取产品记录"]),
            Content(
                "Monitor.API.Inventory.Commands.ProductRecords.GetProductRecordStructure",
                "Get the structure of a product record.",
                "获取产品记录的结构。",
                ["product structure"], ["产品结构"]),
            Content(
                "Monitor.API.Inventory.Commands.ProductRecords.GetTraceabilityNodeStructure",
                "Get the traceability node structure of a product record.",
                "获取产品记录的追溯节点结构。",
                ["traceability structure"], ["追溯结构"]),
            Content(
                "Monitor.API.Inventory.Commands.ProductRecords.RenameProductRecord",
                "Rename a product record.",
                "重命名产品记录。",
                ["rename"], ["重命名"]),
            Content(
                "Monitor.API.Inventory.Commands.ProductRecords.ReportProductRecordReading",
                "Report a reading against a product record.",
                "上报针对产品记录的读取。",
                ["report reading"], ["上报读取"]),
            Content(
                "Monitor.API.Inventory.Commands.ProductRecords.SetProductRecordLifeCycle",
                "Set the lifecycle state of a product record.",
                "设置产品记录的生命周期状态。",
                ["life cycle", "lifecycle"], ["生命周期"]),
            Content(
                "Monitor.API.Inventory.Commands.ProductRecords.SetProductRecordManufacturingOrder",
                "Set the manufacturing order on a product record.",
                "设置产品记录的制造工单。",
                ["manufacturing order"], ["制造工单"]),
            Content(
                "Monitor.API.Inventory.Commands.ProductRecords.SetPropertiesProductRecord",
                "Set the properties of a product record.",
                "设置产品记录的属性。",
                ["set properties", "update product record"], ["设置属性", "更新产品记录"]),
            Content(
                "Monitor.API.Inventory.Commands.ProductRecords.UpdateDeliveryAddressProductRecord",
                "Update the delivery address of a product record.",
                "更新产品记录的交货地址。",
                ["delivery address"], ["交货地址"]),
            Content(
                "Monitor.API.Inventory.Commands.ProductRecords.UpdateTraceabilityStructure",
                "Update the traceability structure of a product record.",
                "更新产品记录的追溯结构。",
                ["update traceability"], ["更新追溯结构"]),

            // ---- Putaways --------------------------------------------------------------
            Content(
                "Monitor.API.Inventory.Commands.Putaway.GetPutawayLocationSuggestions",
                "Get suggested putaway locations for incoming stock.",
                "获取入库库存的上架库位建议。",
                ["putaway", "put away"], ["上架", "上架建议"]),

            // ---- SalesForecasts --------------------------------------------------------
            Content(
                "Monitor.API.Inventory.Commands.SalesForecasts.AddSalesForecastRow",
                "Add a row to a sales forecast.",
                "为销售预测添加行。",
                ["add forecast row"], ["添加预测行"]),
            Content(
                "Monitor.API.Inventory.Commands.SalesForecasts.CreateSalesForecast",
                "Create a new sales forecast.",
                "创建新的销售预测。",
                ["create forecast", "new forecast"], ["新建销售预测", "创建预测"]),
            Content(
                "Monitor.API.Inventory.Commands.SalesForecasts.RemoveSalesForecast",
                "Remove a sales forecast.",
                "删除销售预测。",
                ["remove forecast"], ["删除销售预测"]),
            Content(
                "Monitor.API.Inventory.Commands.SalesForecasts.RemoveSalesForecastRow",
                "Remove a row from a sales forecast.",
                "从销售预测移除行。",
                ["remove forecast row"], ["移除预测行"]),
            Content(
                "Monitor.API.Inventory.Commands.SalesForecasts.SetPropertiesSalesForecast",
                "Set the properties of a sales forecast.",
                "设置销售预测的属性。",
                ["set properties", "update forecast"], ["设置属性", "更新销售预测"]),
            Content(
                "Monitor.API.Inventory.Commands.SalesForecasts.UpdateSalesForecastRow",
                "Update a row in a sales forecast.",
                "更新销售预测中的行。",
                ["update forecast row"], ["更新预测行"]),

            // ---- StockTransactions -----------------------------------------------------
            Content(
                "Monitor.API.Inventory.Commands.ProductRecords.UpdateStocktransaction",
                "Update a stock transaction.",
                "更新库存交易。",
                ["update stock transaction", "update stock movement"], ["更新库存交易"]),
        ];
    }
}
