namespace MonitorErpMcp.Catalog.Content.Manufacturing
{
    // The using-static sits inside the namespace so the imported Content(...) builder binds before
    // the enclosing MonitorErpMcp.Catalog.Content namespace in simple-name lookup.
    using static MonitorErpMcp.Catalog.Content.ContentEntryFactory;
    using MonitorErpMcp.Catalog.Model;

    /// <summary>
    /// Hand-authored content for Manufacturing command records: bilingual descriptions and search
    /// aliases (en first, zh second), keyed by clrType and merged onto the structural catalog.
    /// Important request-input fields (mandatory, mandatoryWhen, enum, reference, input wrapper,
    /// nested command, dto) carry bilingual descriptions; self-evident fields are skipped.
    /// </summary>
    public static class Commands
    {
        /// <summary>Hand-authored entries for this family, merged by <c>clrType</c> onto the structural catalog.</summary>
        public static readonly ContentEntry[] Entries =
        [
            // ---- ManufacturingOrderMaterialReportings --------------------------------
            Content(
                "Monitor.API.Inventory.Commands.ManufacturingOrderMaterialReportings.UpdateManufacturingOrderMaterialReporting",
                "Update the reported price of a manufacturing-order material reporting.",
                "更新制造工单物料上报的上报价格。",
                ["update material reporting", "update reported price"], ["更新物料上报", "更新上报价格"],
                fields: [
                    F("Id", "The material reporting to update.", "要更新的物料上报。"),
                    F("Price", "The reported price of the material.", "物料的上报价格。"),
                ]),
            Content(
                "Monitor.API.Inventory.Commands.ManufacturingOrderMaterialReportings.UpdateManufacturingOrderOperationReporting",
                "Update the reported cost factors of a manufacturing-order operation reporting.",
                "更新制造工单工序上报的上报成本因子。",
                ["update operation reporting", "update cost factors"], ["更新工序上报", "更新成本因子"],
                fields: [
                    F("Id", "The operation reporting to update.", "要更新的工序上报。"),
                    F("UnitCostFactor1", "The first unit-cost factor.", "第一个单位成本因子。"),
                    F("UnitCostFactor2", "The second unit-cost factor.", "第二个单位成本因子。"),
                    F("UnitCostFactor3", "The third unit-cost factor.", "第三个单位成本因子。"),
                    F("SetupCostFactor1", "The first setup-cost factor.", "第一个设置成本因子。"),
                    F("SetupCostFactor2", "The second setup-cost factor.", "第二个设置成本因子。"),
                    F("SetupCostFactor3", "The third setup-cost factor.", "第三个设置成本因子。"),
                ]),

            // ---- MaintenanceReportings -----------------------------------------------
            Content(
                "Monitor.API.Manufacturing.Commands.MaintenanceReportings.CreateMaintenanceReporting",
                "Create a maintenance report for a tool or product record.",
                "为工具或产品记录创建维护报告。",
                ["create maintenance reporting", "create maintenance report"], ["创建维护报告", "新建保养报告"],
                fields: [
                    F("SerialNumber", "The serial number of the report; defaults to the number series.", "报告的唯一序号；默认使用编号系列。"),
                    F("MaintenanceStatus", "The result of the maintenance (ok, not ok, ok with action).", "维护结果（正常、异常、正常但需处理）。"),
                    F("Status", "The approval status of the maintained item.", "被维护物品的审批状态。"),
                    F("ReportedById", "The person who reported the maintenance.", "上报维护的人员。"),
                    F("Comment", "A comment on the report.", "报告的备注。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.MaintenanceReportings.UpdateMaintenanceReporting",
                "Update a maintenance report.",
                "更新维护报告。",
                ["update maintenance reporting", "update maintenance report"], ["更新维护报告", "修改保养报告"],
                fields: [
                    F("Id", "The maintenance report to update.", "要更新的维护报告。"),
                    F("MaintenanceStatus", "The result of the maintenance (ok, not ok, ok with action).", "维护结果（正常、异常、正常但需处理）。"),
                    F("Status", "The approval status of the maintained item.", "被维护物品的审批状态。"),
                    F("ReportedById", "The person who reported the maintenance.", "上报维护的人员。"),
                    F("ShortComment", "A short comment on the report.", "报告的简短备注。"),
                    F("Comment", "A comment on the report.", "报告的备注。"),
                    F("Rows", "The reporting rows of the maintenance report.", "维护报告的上报行。"),
                ]),

            // ---- ManufacturingOrderMaterials -----------------------------------------
            Content(
                "Monitor.API.Manufacturing.Commands.ManufacturingOrderMaterials.ConnectPurchaseOrderRowToMaterial",
                "Connect a purchase-order row to a manufacturing-order material.",
                "将采购订单行连接到制造工单物料。",
                ["connect purchase order row", "link purchase order"], ["连接采购订单行", "关联采购订单行"],
                fields: [
                    F("MaterialId", "The manufacturing-order material to connect.", "要连接的制造工单物料。"),
                    F("PurchaseOrderRowId", "The purchase-order row to connect.", "要连接的采购订单行。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.ManufacturingOrderMaterials.DisconnectPurchaseOrderRowFromMaterial",
                "Disconnect a purchase-order row from a manufacturing-order material.",
                "断开制造工单物料与采购订单行的连接。",
                ["disconnect purchase order row", "unlink purchase order"], ["断开采购订单行", "取消关联采购订单行"],
                fields: [
                    F("MaterialId", "The manufacturing-order material to disconnect.", "要断开的制造工单物料。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.ManufacturingOrderMaterials.UpdateManufacturingOrderMaterial",
                "Update a manufacturing-order material.",
                "更新制造工单物料。",
                ["update order material", "update material"], ["更新工单物料", "更新制造物料"],
                fields: [
                    F("ManufacturingOrderMaterialId", "The manufacturing-order material to update.", "要更新的制造工单物料。"),
                    F("ToOperation", "The operation the material is moved to.", "物料移到的工序。"),
                    F("Position", "The position of the material within the operation.", "物料在工序中的位置。"),
                    F("RevisionId", "The part revision of the material.", "物料的物料修订版。"),
                    F("ReservationDate", "The reservation date of the material.", "物料的预留日期。"),
                    F("SetupQuantity", "The setup quantity of the material.", "物料的准备数量。"),
                ]),

            // ---- ManufacturingOrderNodes ---------------------------------------------
            Content(
                "Monitor.API.Manufacturing.Commands.ManufacturingOrderNodes.AddDrawing",
                "Add a drawing to a manufacturing-order node.",
                "为制造工单节点添加图纸。",
                ["add drawing", "attach drawing"], ["添加图纸", "附加图纸"],
                fields: [
                    F("ManufacturingOrderNodeId", "The node to add the drawing to.", "要添加图纸的节点。"),
                    F("DrawingNumber", "The unique number of the drawing to add.", "要添加图纸的唯一编号。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.ManufacturingOrderNodes.AddDrawingRevision",
                "Add a revision to a node drawing.",
                "为节点图纸添加修订版。",
                ["add drawing revision", "add revision"], ["添加图纸修订", "添加图纸版本"],
                fields: [
                    F("DrawingId", "The drawing to add the revision to.", "要添加修订版的图纸。"),
                    F("Number", "The unique number of the revision.", "修订版的唯一编号。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.ManufacturingOrderNodes.RemoveDrawing",
                "Remove a drawing from a manufacturing-order node.",
                "从制造工单节点移除图纸。",
                ["remove drawing", "detach drawing"], ["移除图纸", "删除图纸"],
                fields: [
                    F("DrawingId", "The drawing to remove.", "要移除的图纸。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.ManufacturingOrderNodes.RemoveDrawingRevision",
                "Remove a revision from a node drawing.",
                "从节点图纸移除修订版。",
                ["remove drawing revision", "remove revision"], ["移除图纸修订"],
                fields: [
                    F("DrawingRevisionId", "The drawing revision to remove.", "要移除的图纸修订版。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.ManufacturingOrderNodes.SetActiveDrawingRevision",
                "Set the active revision of a node drawing.",
                "设置节点图纸的活动修订版。",
                ["set active drawing revision", "active revision"], ["设置活动图纸修订"],
                fields: [
                    F("DrawingRevisionId", "The drawing revision to set as active.", "要设为活动的图纸修订版。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.ManufacturingOrderNodes.StepToManufacturingOrderNodeStatus",
                "Step a manufacturing-order node to a status.",
                "将制造工单节点推进到某状态。",
                ["step to status", "change node status"], ["推进节点状态", "更改节点状态"],
                fields: [
                    F("ManufacturingOrderNodeId", "The node to step.", "要推进的节点。"),
                    F("Status", "The status to step the node to.", "节点要推进到的状态。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.ManufacturingOrderNodes.UpdateDrawing",
                "Update a node drawing.",
                "更新节点图纸。",
                ["update drawing", "edit drawing"], ["更新图纸", "修改图纸"],
                fields: [
                    F("DrawingId", "The drawing to update.", "要更新的图纸。"),
                    F("DrawingNumber", "The unique number of the drawing.", "图纸的唯一编号。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.ManufacturingOrderNodes.UpdateDrawingRevision",
                "Update a node drawing revision.",
                "更新节点图纸修订版。",
                ["update drawing revision", "edit revision"], ["更新图纸修订"],
                fields: [
                    F("DrawingRevisionId", "The drawing revision to update.", "要更新的图纸修订版。"),
                    F("Number", "The unique number of the revision.", "修订版的唯一编号。"),
                ]),

            // ---- ManufacturingOrderOperations ----------------------------------------
            Content(
                "Monitor.API.Manufacturing.Commands.ManufacturingOrderOperations.BundleOperations",
                "Bundle manufacturing-order operations into a bundle.",
                "将制造工单工序捆绑为一个工序束。",
                ["bundle operations", "group operations"], ["捆绑工序", "工序组合"],
                fields: [
                    F("ManufacturingOrderOperationIds", "The operations to bundle.", "要捆绑的工序。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.ManufacturingOrderOperations.RemoveBundle",
                "Remove a bundle of manufacturing-order operations.",
                "移除制造工单工序束。",
                ["remove bundle", "ungroup operations"], ["移除工序束", "解除捆绑"],
                fields: [
                    F("BundleId", "The bundle to remove.", "要移除的工序束。"),
                ]),

            // ---- ManufacturingOrders -------------------------------------------------
            Content(
                "Monitor.API.Manufacturing.Commands.ManufacturingOrders.AddManufacturingOrderMaterial",
                "Add a material to a manufacturing-order operation.",
                "为制造工单工序添加物料。",
                ["add material", "add order material"], ["添加物料", "添加工单物料"],
                fields: [
                    F("ManufacturingOrderOperationId", "The operation to add the material to.", "要添加物料的工序。"),
                    F("PartId", "The part to add as a material.", "要添加为物料的物料。"),
                    F("PlannedQuantity", "The planned quantity of the material.", "物料的计划数量。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.ManufacturingOrders.AddManufacturingOrderOperation",
                "Add an operation to a manufacturing-order node.",
                "为制造工单节点添加工序。",
                ["add operation", "add work step"], ["添加工序", "添加作业步骤"],
                fields: [
                    F("ManufacturingOrderNodeId", "The node to add the operation to.", "要添加工序的节点。"),
                    F("WorkCenterId", "The work center of the operation.", "工序的工作中心。"),
                    F("PlannedQuantity", "The planned quantity of the operation.", "工序的计划数量。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.ManufacturingOrders.CreateManufacturingOrder",
                "Create a manufacturing order.",
                "创建制造工单。",
                ["create manufacturing order", "create work order", "new order"], ["创建制造工单", "新建工单", "创建生产工单"],
                fields: [
                    F("PartId", "The part to manufacture.", "要制造的物料。"),
                    F("Quantity", "The quantity to manufacture.", "要制造的数量。"),
                    F("OrderNumber", "The order number; defaults to the number series.", "工单编号；默认使用编号系列。"),
                    F("CustomerId", "The customer of the order.", "工单的客户。"),
                    F("ProjectId", "The project of the order.", "工单的项目。"),
                    F("Comment", "A comment on the order.", "工单的备注。"),
                    F("VariantCode", "The variant code of the order.", "工单的变体代码。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.ManufacturingOrders.CreateManufacturingOrderFromCustomerOrderRow",
                "Create a manufacturing order from a customer-order row.",
                "根据客户订单行创建制造工单。",
                ["create order from customer order", "create from row"], ["按客户订单行创建工单"],
                fields: [
                    F("CustomerOrderRowId", "The customer-order row to create the order from.", "用于创建工单的客户订单行。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.ManufacturingOrders.RemoveManufacturingOrder",
                "Remove a manufacturing order.",
                "删除制造工单。",
                ["remove manufacturing order", "delete work order"], ["删除制造工单", "移除工单"],
                fields: [
                    F("ManufacturingOrderId", "The manufacturing order to remove.", "要删除的制造工单。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.ManufacturingOrders.RemoveManufacturingOrderMaterial",
                "Remove a material from a manufacturing order.",
                "从制造工单移除物料。",
                ["remove material", "remove order material"], ["移除物料", "删除工单物料"],
                fields: [
                    F("ManufacturingOrderMaterialId", "The manufacturing-order material to remove.", "要移除的制造工单物料。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.ManufacturingOrders.RemoveManufacturingOrderOperation",
                "Remove an operation from a manufacturing order.",
                "从制造工单移除工序。",
                ["remove operation", "remove work step"], ["移除工序", "删除工序"],
                fields: [
                    F("ManufacturingOrderOperationId", "The operation to remove.", "要移除的工序。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.ManufacturingOrders.RenameManufacturingOrder",
                "Rename a manufacturing order.",
                "重命名制造工单。",
                ["rename manufacturing order", "change order number"], ["重命名制造工单", "更改工单编号"],
                fields: [
                    F("ManufacturingOrderId", "The manufacturing order to rename.", "要重命名的制造工单。"),
                    F("NewManufacturingOrderNumber", "The new order number.", "新的工单编号。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.ManufacturingOrders.ReplanManufacturingOrder",
                "Replan a manufacturing order with new start and finish dates.",
                "以新的开始与结束日期重新计划制造工单。",
                ["replan manufacturing order", "reschedule order"], ["重新计划工单", "重排工单"],
                fields: [
                    F("Id", "The manufacturing order to replan.", "要重新计划的制造工单。"),
                    F("StartDate", "The new start date.", "新的开始日期。"),
                    F("FinishDate", "The new finish date.", "新的结束日期。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.ManufacturingOrders.ReplanManufacturingOrderOperation",
                "Replan a manufacturing-order operation with new dates.",
                "以新的日期重新计划制造工单工序。",
                ["replan operation", "reschedule operation"], ["重新计划工序", "重排工序"],
                fields: [
                    F("ManufacturingOrderOperationId", "The operation to replan.", "要重新计划的工序。"),
                    F("StartDate", "The new start date.", "新的开始日期。"),
                    F("FinishDate", "The new finish date.", "新的结束日期。"),
                    F("RestrictToOrderBounds", "Whether to restrict the operation within the order's dates.", "是否将工序限制在工单日期范围内。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.ManufacturingOrders.ReplanManufacturingOrderQuantity",
                "Replan the quantity of a manufacturing order.",
                "重新计划制造工单的数量。",
                ["replan quantity", "change order quantity"], ["重新计划数量", "更改工单数量"],
                fields: [
                    F("ManufacturingOrderId", "The manufacturing order to replan.", "要重新计划的制造工单。"),
                    F("ManufacturingOrderNodeId", "The node to replan; defaults to the main node.", "要重新计划的节点；默认为主节点。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.ManufacturingOrders.ReplanPinnedManufacturingOrderOperation",
                "Replan a pinned manufacturing-order operation to a finish date.",
                "将已固定的制造工单工序重新计划到结束日期。",
                ["replan pinned operation", "pinned operation"], ["重新计划固定工序"],
                fields: [
                    F("ManufacturingOrderOperationId", "The pinned operation to replan.", "要重新计划的固定工序。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.ManufacturingOrders.SetManufacturingOrderOperationSupplier",
                "Set the supplier of a manufacturing-order operation.",
                "设置制造工单工序的供应商。",
                ["set operation supplier", "operation supplier"], ["设置工序供应商"],
                fields: [
                    F("ManufacturingOrderOperationId", "The operation to set the supplier for.", "要设置供应商的工序。"),
                    F("SupplierId", "The supplier of the operation.", "工序的供应商。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.ManufacturingOrders.SetManufacturingOrderOperationWorkCenter",
                "Set the work center of a manufacturing-order operation.",
                "设置制造工单工序的工作中心。",
                ["set operation work center", "operation work center"], ["设置工序工作中心"],
                fields: [
                    F("ManufacturingOrderOperationId", "The operation to set the work center for.", "要设置工作中心的工序。"),
                    F("WorkCenterId", "The work center of the operation.", "工序的工作中心。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.ManufacturingOrders.SetPropertiesManufacturingOrder",
                "Set the properties of a manufacturing order.",
                "设置制造工单的属性。",
                ["set order properties", "update manufacturing order"], ["设置工单属性", "更新制造工单"],
                fields: [
                    F("ManufacturingOrderId", "The manufacturing order to update.", "要更新的制造工单。"),
                    F("VariantCode", "The variant code of the order.", "工单的变体代码。"),
                    F("CategoryString", "The category string of the order.", "工单的类别字符串。"),
                    F("ProjectId", "The project of the order.", "工单的项目。"),
                    F("CustomerId", "The customer of the order.", "工单的客户。"),
                    F("InitialFinishDate", "The initial finish date of the order.", "工单的初始结束日期。"),
                    F("Priority", "The priority of the order.", "工单的优先级。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.ManufacturingOrders.UpdateManufacturingOrderMaterialQuantity",
                "Update the planned quantity of a manufacturing-order material.",
                "更新制造工单物料的计划数量。",
                ["update material quantity", "change planned quantity"], ["更新物料数量", "更改计划数量"],
                fields: [
                    F("ManufacturingOrderMaterialId", "The manufacturing-order material to update.", "要更新的制造工单物料。"),
                    F("PlannedQuantity", "The new planned quantity.", "新的计划数量。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.ManufacturingOrders.UpdateManufacturingOrderOperation",
                "Update a manufacturing-order operation.",
                "更新制造工单工序。",
                ["update operation", "edit work step"], ["更新工序", "修改工序"],
                fields: [
                    F("ManufacturingOrderOperationId", "The operation to update.", "要更新的工序。"),
                    F("Priority", "The priority of the operation.", "工序的优先级。"),
                    F("PlannedQuantity", "The planned quantity of the operation.", "工序的计划数量。"),
                    F("WipLocation", "The WIP location of the operation.", "工序的在制品库位。"),
                    F("PlannedUnitTime", "The planned unit time of the operation.", "工序的计划单位时间。"),
                    F("PlannedSetupTime", "The planned setup time of the operation.", "工序的计划准备时间。"),
                    F("PlannedUnitCostInCompanyCurrency", "The planned unit cost in company currency.", "按公司货币计价的计划单位成本。"),
                    F("PlannedSetupCostInCompanyCurrency", "The planned setup cost in company currency.", "按公司货币计价的计划准备成本。"),
                    F("Description", "The description of the operation.", "工序的描述。"),
                    F("ManualOperationStatusId", "The manual status of the operation.", "工序的手动状态。"),
                    F("PlannedStartDate", "The planned start date of the operation.", "工序的计划开始日期。"),
                    F("PlannedFinishDate", "The planned finish date of the operation.", "工序的计划结束日期。"),
                    F("FixedLeadTime", "The fixed lead time of the operation.", "工序的固定前置时间。"),
                    F("UnitStaffingFactor", "The unit staffing factor of the operation.", "工序的单位人员因子。"),
                    F("SetupStaffingFactor", "The setup staffing factor of the operation.", "工序的准备人员因子。"),
                ]),

            // ---- MaterialClearances --------------------------------------------------
            Content(
                "Monitor.API.Manufacturing.Commands.MaterialClearances.ClearManufacturingOrderMaterial",
                "Clear manufacturing-order materials for reporting.",
                "为上报清除制造工单物料。",
                ["clear material", "clear order material"], ["清除物料", "清除工单物料"],
                fields: [
                    F("Rows", "The material rows to clear.", "要清除的物料行。"),
                    F("Level", "How strictly the clearing is applied (all-or-nothing, partial set, partial row).", "清除的严格程度（全有或全无、允许部分组、允许部分行）。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.MaterialClearances.UndoClearManufacturingOrderMaterial",
                "Undo the clearing of a manufacturing-order material.",
                "撤销对制造工单物料的清除。",
                ["undo clear", "unclear material"], ["撤销清除", "取消清除物料"],
                fields: [
                    F("ManufacturingOrderMaterialId", "The manufacturing-order material to un-clear.", "要撤销清除的制造工单物料。"),
                ]),

            // ---- MaterialRows --------------------------------------------------------
            Content(
                "Monitor.API.Manufacturing.Commands.MaterialRows.RemoveMaterialRow",
                "Remove a material row from a preparation.",
                "从准备资料移除物料行。",
                ["remove material row", "delete material row"], ["移除物料行", "删除物料行"],
                fields: [
                    F("MaterialRowId", "The material row to remove.", "要移除的物料行。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.MaterialRows.SetMaterialRowPart",
                "Set the part of a material row.",
                "设置物料行的物料。",
                ["set material part", "change material part"], ["设置物料行物料", "更改物料行物料"],
                fields: [
                    F("MaterialRowId", "The material row to update.", "要更新的物料行。"),
                    F("PartId", "The part of the material row.", "物料行的物料。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.MaterialRows.UpdateMaterialRow",
                "Update a material row of a preparation.",
                "更新准备资料的物料行。",
                ["update material row", "edit material row"], ["更新物料行", "修改物料行"],
                fields: [
                    F("MaterialRowId", "The material row to update.", "要更新的物料行。"),
                    F("ToOperation", "The operation the material is used in.", "物料使用的工序。"),
                    F("Position", "The position of the material within the operation.", "物料在工序中的位置。"),
                    F("Quantity", "The quantity of the material.", "物料的数量。"),
                    F("SetupQuantity", "The setup quantity of the material.", "物料的准备数量。"),
                    F("ExtraPercent", "The extra percentage of the material.", "物料的额外百分比。"),
                    F("IsForCalculationOnly", "Whether the material row is for calculation only.", "物料行是否仅供计算。"),
                    F("UnitId", "The unit of the material.", "物料的单位。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.MaterialRows.UpdateMaterialRowPreparationTerm",
                "Update the preparation term of a material row.",
                "更新物料行的准备条款。",
                ["update preparation term", "preparation term"], ["更新准备条款", "准备条款"],
                fields: [
                    F("MaterialRowId", "The material row to update.", "要更新的物料行。"),
                    F("TermCode", "The preparation term (add, replace, or remove based on a value).", "准备条款（按某值添加、替换或移除）。"),
                    F("FromValue", "The value the term matches from.", "条款匹配的起始值。"),
                    F("ToValue", "The value the term matches to.", "条款匹配的结束值。"),
                ]),

            // ---- MeasuringReportings ------------------------------------------------
            Content(
                "Monitor.API.Manufacturing.Commands.MeasuringReportings.GetMeasuringReportingInfo",
                "Get the measuring-reporting information for a report number.",
                "获取某报告编号的测量上报信息。",
                ["get measuring info", "measuring reporting info"], ["获取测量上报信息"],
                fields: [
                    F("ReportNumber", "The report number to get information for.", "要获取信息的报告编号。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.MeasuringReportings.ReportMeasuring",
                "Report measuring data against a manufacturing order.",
                "针对制造工单上报测量数据。",
                ["report measuring", "report measurement"], ["上报测量数据", "测量上报"],
                fields: [
                    F("ReportNumber", "The report number of the measuring reporting.", "测量上报的报告编号。"),
                    F("ReportedById", "The person who reported the measuring data.", "上报测量数据的人员。"),
                    F("Reporting", "The measuring data to report (forms, serial numbers, batch numbers).", "要上报的测量数据（表单、序列号、批次号）。"),
                ]),

            // ---- OperationRows -------------------------------------------------------
            Content(
                "Monitor.API.Manufacturing.Commands.OperationRows.CreateOperationRowControlDataRow",
                "Create a control-data row on an operation row.",
                "在工序行上创建控制数据行。",
                ["create control data row", "add measuring row"], ["创建控制数据行", "添加测量行"],
                fields: [
                    F("OperationRowId", "The operation row to add the control-data row to.", "要添加控制数据行的工序行。"),
                    F("MeasuringTemplateId", "The measuring template of the control-data row.", "控制数据行的测量模板。"),
                    F("OverriddenFormTemplateId", "The form template overriding the template's form.", "覆盖模板表单的表单模板。"),
                    F("OverriddenFrequencyText", "The overridden measuring frequency text.", "覆盖的测量频率文本。"),
                    F("OverriddenIntervalAmount", "The overridden interval amount.", "覆盖的间隔数值。"),
                    F("OverriddenInterval", "The overridden interval.", "覆盖的间隔。"),
                    F("WorkCenterId", "The work center the control data applies to.", "控制数据适用的工作中心。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.OperationRows.RemoveOperationRow",
                "Remove an operation row from a preparation.",
                "从准备资料移除工序行。",
                ["remove operation row", "delete operation row"], ["移除工序行", "删除工序行"],
                fields: [
                    F("OperationRowId", "The operation row to remove.", "要移除的工序行。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.OperationRows.RemoveOperationRowControlDataRow",
                "Remove a control-data row from an operation row.",
                "从工序行移除控制数据行。",
                ["remove control data row", "remove measuring row"], ["移除控制数据行"],
                fields: [
                    F("Id", "The control-data row to remove.", "要移除的控制数据行。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.OperationRows.SetOperationRowSupplier",
                "Set the supplier of an operation row.",
                "设置工序行的供应商。",
                ["set operation row supplier"], ["设置工序行供应商"],
                fields: [
                    F("OperationRowId", "The operation row to set the supplier for.", "要设置供应商的工序行。"),
                    F("SupplierId", "The supplier of the operation row.", "工序行的供应商。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.OperationRows.SetOperationRowWorkCenter",
                "Set the work center of an operation row.",
                "设置工序行的工作中心。",
                ["set operation row work center"], ["设置工序行工作中心"],
                fields: [
                    F("OperationRowId", "The operation row to set the work center for.", "要设置工作中心的工序行。"),
                    F("WorkCenterId", "The work center of the operation row.", "工序行的工作中心。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.OperationRows.UpdateOperationRow",
                "Update an operation row of a preparation.",
                "更新准备资料的工序行。",
                ["update operation row", "edit operation row"], ["更新工序行", "修改工序行"],
                fields: [
                    F("OperationRowId", "The operation row to update.", "要更新的工序行。"),
                    F("OperationNumber", "The operation number of the row.", "工序行的工序号。"),
                    F("Description", "The description of the operation row.", "工序行的描述。"),
                    F("ExtraQuantityPercent", "The extra quantity percentage of the row.", "工序行的额外数量百分比。"),
                    F("IsForCalculationOnly", "Whether the row is for calculation only.", "该行是否仅供计算。"),
                    F("NumberOfFlows", "The number of flows of the row.", "工序行的流数量。"),
                    F("OverlapPercent", "The overlap percentage of the row.", "工序行的重叠百分比。"),
                    F("SetupQuantity", "The setup quantity of the row.", "工序行的准备数量。"),
                    F("SetupStaffingFactor", "The setup staffing factor of the row.", "工序行的准备人员因子。"),
                    F("TimeCode", "How the time was set (not initialized, calculated, studied).", "时间的设定方式（未初始化、计算、实测）。"),
                    F("TimeUnit", "The time unit of the row (hours, minutes, seconds, quantity per hour...).", "工序行的时间单位（小时、分钟、秒、每小时数量等）。"),
                    F("SetupTime", "The setup time of the row.", "工序行的准备时间。"),
                    F("UnitTime", "The unit time of the row.", "工序行的单位时间。"),
                    F("QueueTime", "The queue time of the row.", "工序行的排队时间。"),
                    F("FixedLeadTime", "The fixed lead time of the row.", "工序行的固定前置时间。"),
                    F("UseQueueTimeWholeDayRoundOf", "Whether queue time rounds to whole days.", "排队时间是否取整天。"),
                    F("UnitStaffingFactor", "The unit staffing factor of the row.", "工序行的单位人员因子。"),
                    F("CurrencyId", "The currency of the row costs.", "工序行成本的货币。"),
                    F("UnitCost", "The unit cost of the row.", "工序行的单位成本。"),
                    F("SetupCost", "The setup cost of the row.", "工序行的准备成本。"),
                    F("UnitCostFactorId", "The unit-cost factor of the row.", "工序行的单位成本因子。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.OperationRows.UpdateOperationRowControlDataRow",
                "Update a control-data row of an operation row.",
                "更新工序行的控制数据行。",
                ["update control data row", "update measuring row"], ["更新控制数据行"],
                fields: [
                    F("Id", "The control-data row to update.", "要更新的控制数据行。"),
                    F("MeasuringTemplateId", "The measuring template of the row.", "该行的测量模板。"),
                    F("OverriddenFormTemplateId", "The form template overriding the template's form.", "覆盖模板表单的表单模板。"),
                    F("OverriddenFrequencyText", "The overridden measuring frequency text.", "覆盖的测量频率文本。"),
                    F("OverriddenIntervalAmount", "The overridden interval amount.", "覆盖的间隔数值。"),
                    F("OverriddenInterval", "The overridden interval.", "覆盖的间隔。"),
                    F("WorkCenterId", "The work center the control data applies to.", "控制数据适用的工作中心。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.OperationRows.UpdateOperationRowPreparationTerm",
                "Update the preparation term of an operation row.",
                "更新工序行的准备条款。",
                ["update preparation term"], ["更新工序行准备条款"],
                fields: [
                    F("OperationRowId", "The operation row to update.", "要更新的工序行。"),
                    F("TermCode", "The preparation term (add, replace, or remove based on a value).", "准备条款（按某值添加、替换或移除）。"),
                    F("FromValue", "The value the term matches from.", "条款匹配的起始值。"),
                    F("ToValue", "The value the term matches to.", "条款匹配的结束值。"),
                ]),

            // ---- PickingLists --------------------------------------------------------
            Content(
                "Monitor.API.Manufacturing.Commands.PickingLists.CreateManufacturingPickingList",
                "Create a manufacturing picking list.",
                "创建制造领料单。",
                ["create picking list", "create picking"], ["创建领料单", "新建领料单"],
                fields: [
                    F("CreatedByPersonId", "The person who created the picking list.", "创建领料单的人员。"),
                    F("Grouping", "How the picking list is grouped (by order, by material, or not grouped).", "领料单的分组方式（按工单、按物料或不分组）。"),
                    F("Sorting", "How the picking list is sorted (by location, part number...).", "领料单的排序方式（按库位、物料编号等）。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.PickingLists.DeleteManufacturingPickingList",
                "Delete a manufacturing picking list.",
                "删除制造领料单。",
                ["delete picking list", "remove picking list"], ["删除领料单", "移除领料单"],
                fields: [
                    F("PickingListId", "The picking list to delete.", "要删除的领料单。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.PickingLists.ReportManufacturingPickingList",
                "Report a manufacturing picking list as picked.",
                "上报制造领料单已领料。",
                ["report picking list", "confirm picking"], ["上报领料单", "确认领料"],
                fields: [
                    F("PersonId", "The person who performed the picking.", "执行领料的人员。"),
                    F("Materials", "The picked materials with their locations.", "已领物料及其库位。"),
                ]),

            // ---- Preparation ---------------------------------------------------------
            Content(
                "Monitor.API.Manufacturing.Commands.Preparation.AddMaterialRow",
                "Add a material row to a preparation.",
                "为准备资料添加物料行。",
                ["add material row", "add preparation material"], ["添加物料行", "添加准备物料"],
                fields: [
                    F("OwnerPartId", "The part the preparation belongs to.", "准备资料所属的物料。"),
                    F("PartId", "The part to add as a material.", "要添加为物料的物料。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.Preparation.AddOperationRow",
                "Add an operation row to a preparation.",
                "为准备资料添加工序行。",
                ["add operation row", "add preparation operation"], ["添加工序行", "添加准备工序"],
                fields: [
                    F("OwnerPartId", "The part the preparation belongs to.", "准备资料所属的物料。"),
                    F("WorkcenterId", "The work center of the operation row.", "工序行的工作中心。"),
                    F("Materials", "The material rows of the operation row.", "工序行的物料行。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.Preparation.CreatePreparation",
                "Create a preparation for a part.",
                "为物料创建准备资料。",
                ["create preparation", "create routing"], ["创建准备资料", "创建工艺路线"],
                fields: [
                    F("PartDescription", "The description of the new part.", "新物料的描述。"),
                    F("PartType", "The type of the new part (purchased, manufactured, fictitious, service, subcontract).", "新物料的类型（采购、制造、虚拟、服务、外协）。"),
                    F("Operations", "The operation rows of the preparation.", "准备资料的工序行。"),
                    F("Materials", "The material rows of the preparation.", "准备资料的物料行。"),
                ]),

            // ---- Printing ------------------------------------------------------------
            Content(
                "Monitor.API.Manufacturing.Commands.Printing.PrintDefaultShopPacket",
                "Print the default shop packet for a manufacturing-order operation.",
                "打印制造工单工序的默认车间工艺卡。",
                ["print default shop packet", "print shop packet"], ["打印默认车间工艺卡", "打印工艺卡"],
                fields: [
                    F("OperationId", "The operation to print the shop packet for.", "要打印车间工艺卡的工序。"),
                    F("ServerPrinterId", "The server printer to print on.", "打印使用的服务器打印机。"),
                    F("ReportingWorkcenterId", "The work center used for reporting; defaults to the operation's work center.", "用于上报的工作中心；默认为工序的工作中心。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.Printing.PrintShopPacket",
                "Print a shop packet for a manufacturing-order operation with custom print settings.",
                "按自定义打印设置为制造工单工序打印车间工艺卡。",
                ["print shop packet", "custom shop packet"], ["打印车间工艺卡", "打印自定义工艺卡"],
                fields: [
                    F("OperationId", "The operation to print the shop packet for.", "要打印车间工艺卡的工序。"),
                    F("PrintSettings", "The print settings of the shop packet.", "车间工艺卡的打印设置。"),
                ]),

            // ---- Reporting -----------------------------------------------------------
            Content(
                "Monitor.API.Manufacturing.Commands.Reporting.CreateManufacturingTransportLabel",
                "Create a manufacturing transport label.",
                "创建制造运输标签。",
                ["create transport label", "manufacturing label"], ["创建运输标签", "制造运输标签"],
                fields: [
                    F("EntityType", "What the label is created for (node to stock, rejection, operation in progress...).", "标签针对的对象（节点入库、拒收、工序进行中等）。"),
                    F("EntityId", "The entity the label is created for.", "标签针对的实体。"),
                    F("LabelType", "The type of label (transport label, label, small label...).", "标签的类型（运输标签、标签、小标签等）。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.Reporting.CreateManufacturingTraveler",
                "Create a manufacturing traveler document.",
                "创建制造随行单。",
                ["create traveler", "manufacturing traveler"], ["创建随行单", "制造随行单"],
                fields: [
                    F("ManufacturingOrderId", "The manufacturing order the traveler is for.", "随行单针对的制造工单。"),
                    F("ManufacturingOrderNodeId", "The node to include; defaults to all nodes.", "要包含的节点；默认为所有节点。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.Reporting.GetTraceabilityDataForReportManufacturingOrderOperation",
                "Get the traceability data required to report a manufacturing-order operation.",
                "获取上报制造工单工序所需的追溯数据。",
                ["get traceability data", "traceability for reporting"], ["获取追溯数据", "上报追溯数据"],
                fields: [
                    F("ReportManufacturingOrderOperation", "The operation reporting to get traceability data for.", "要获取追溯数据的工序上报。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.Reporting.PrintManufacturingTransportLabel",
                "Print a manufacturing transport label.",
                "打印制造运输标签。",
                ["print transport label", "print label"], ["打印运输标签", "打印标签"],
                fields: [
                    F("Command", "The label command to print.", "要打印的标签命令。"),
                    F("ServerPrinterId", "The server printer to print on.", "打印使用的服务器打印机。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.Reporting.ReportManufacturingOrderMaterial",
                "Report the material withdrawal of a manufacturing-order operation.",
                "上报制造工单工序的物料领用。",
                ["report material", "report material withdrawal", "material reporting"], ["上报物料", "上报物料领用"],
                fields: [
                    F("ReportNumber", "The report number of the material reporting.", "物料上报的报告编号。"),
                    F("ReportedQuantity", "The reported quantity of the material.", "物料的上报数量。"),
                    F("MaterialRows", "The reported material rows with their locations.", "已上报的物料行及其库位。"),
                    F("PartId", "The part to report; give either this or the operation.", "要上报的物料；本字段与工序二选一。"),
                    F("ManufacturingOrderOperationId", "The operation to report against; required when PartId is set.", "上报所针对的工序；设置 PartId 时必填。"),
                    F("UnitId", "The unit of the reported quantity.", "上报数量的单位。"),
                    F("ReportingEmployeeId", "The employee who made the reporting.", "进行上报的员工。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.Reporting.ReportManufacturingOrderOperation",
                "Report a manufacturing-order operation: quantity, time, and locations.",
                "上报制造工单工序：数量、时间与库位。",
                ["report operation", "report manufacturing operation", "operation reporting"], ["上报工序", "上报制造工序"],
                fields: [
                    F("ReportNumber", "The report number of the operation reporting.", "工序上报的报告编号。"),
                    F("ReportedQuantity", "The reported quantity of the operation.", "工序的上报数量。"),
                    F("TimeUnit", "The unit of the reported time.", "上报时间的单位。"),
                    F("ReportedTime", "The reported unit time.", "上报的单位时间。"),
                    F("ReportedSetupTime", "The reported setup time.", "上报的准备时间。"),
                    F("ReportingEmployeeId", "The employee who made the reporting.", "进行上报的员工。"),
                    F("ReportingWorkCenterId", "The work center used for reporting; defaults to the operation's work center.", "用于上报的工作中心；默认为工序的工作中心。"),
                    F("Rejections", "The rejection rows of the reporting.", "上报的拒收行。"),
                    F("Locations", "The new locations the reported quantity is put in.", "上报数量放入的新库位。"),
                    F("ExistingLocations", "The existing locations the reported quantity is put in.", "上报数量放入的现有库位。"),
                    F("TraceabilityData", "The traceability data of the operation; required when the operation requires it.", "工序的追溯数据；工序要求时必填。"),
                    F("AutomaticMaterialWithdrawal", "Whether materials are withdrawn automatically with the reporting.", "上报时是否自动领用物料。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.Reporting.ReportTraceableManufacturingOrderMaterial",
                "Report the withdrawal of a traceable (serial/batch) manufacturing-order material.",
                "上报可追溯（序列号/批次）制造工单物料的领用。",
                ["report traceable material", "traceable material reporting"], ["上报可追溯物料", "追溯物料上报"],
                fields: [
                    F("ReportNumber", "The report number of the material reporting.", "物料上报的报告编号。"),
                    F("ReportedQuantity", "The reported quantity of the material.", "物料的上报数量。"),
                    F("MaterialRows", "The traceable material rows with their product records.", "已上报的可追溯物料行及其产品记录。"),
                    F("PartId", "The part to report; give either this or the operation.", "要上报的物料；本字段与工序二选一。"),
                    F("ManufacturingOrderOperationId", "The operation to report against; required when PartId is set.", "上报所针对的工序；设置 PartId 时必填。"),
                    F("UnitId", "The unit of the reported quantity.", "上报数量的单位。"),
                    F("ReportingEmployeeId", "The employee who made the reporting.", "进行上报的员工。"),
                ]),

            // ---- ScheduleCycles ------------------------------------------------------
            Content(
                "Monitor.API.Manufacturing.Commands.ScheduleCycles.IsWithinScheduleCycle",
                "Check whether a timestamp falls within a schedule cycle.",
                "检查时间戳是否落在某排班周期内。",
                ["is within schedule", "schedule check"], ["检查排班", "是否在排班周期内"],
                fields: [
                    F("ScheduleCycleId", "The schedule cycle to check.", "要检查的排班周期。"),
                    F("Timestamp", "The timestamp to check.", "要检查的时间戳。"),
                ]),

            // ---- Tools ---------------------------------------------------------------
            Content(
                "Monitor.API.Manufacturing.Commands.Tools.ToolReturn.CreateToolReturn",
                "Register the return of lent tools.",
                "登记归还借出的工具。",
                ["create tool return", "return tools"], ["创建工具归还", "归还工具"],
                fields: [
                    F("WarehouseId", "The warehouse the tools are returned to.", "工具归还的仓库。"),
                    F("ReportingPersonId", "The person reporting the return.", "上报归还的人员。"),
                    F("ReasonCodeId", "The reason code of the return.", "归还的原因代码。"),
                    F("ExpectedReturnDate", "The expected return date of the tools.", "工具的预计归还日期。"),
                    F("ReturnToolRequests", "The tools to return.", "要归还的工具。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.Tools.ToolWithdrawal.CreateToolWithdrawal",
                "Register the withdrawal of tools.",
                "登记借出工具。",
                ["create tool withdrawal", "withdraw tools", "lend tools"], ["创建工具借出", "借出工具"],
                fields: [
                    F("WarehouseId", "The warehouse the tools are withdrawn from.", "工具借出的仓库。"),
                    F("ReportingPersonId", "The person reporting the withdrawal.", "上报借出的人员。"),
                    F("ReasonCodeId", "The reason code of the withdrawal.", "借出的原因代码。"),
                    F("ExpectedReturnDate", "The expected return date of the tools.", "工具的预计归还日期。"),
                    F("LendToolRequests", "The tools to lend.", "要借出的工具。"),
                ]),

            // ---- WorkCenters ---------------------------------------------------------
            Content(
                "Monitor.API.Manufacturing.Commands.WorkCenters.CreateWorkCenterCostFactorGroup",
                "Create a cost factor group on a work center.",
                "在工作中心上创建成本因子组。",
                ["create cost factor group"], ["创建成本因子组"],
                fields: [
                    F("WorkCenterId", "The work center to create the group on.", "要创建成本因子组的工作中心。"),
                    F("Description", "A description of the cost factor group.", "成本因子组的描述。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.WorkCenters.GetWorkCenterCapacityAndLoading",
                "Get the capacity and loading of a work center in a period.",
                "获取某期间内工作中心的产能与负荷。",
                ["get capacity", "work center loading"], ["获取产能", "工作中心负荷"],
                fields: [
                    F("WorkCenterId", "The work center to get capacity for.", "要获取产能的工作中心。"),
                    F("ToDate", "The end of the period.", "期间的结束日期。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.WorkCenters.SetWorkCenterCostFactorGroupTypes",
                "Set the cost-factor types of a work-center cost factor group.",
                "设置工作中心成本因子组的成本因子类型。",
                ["set cost factor types"], ["设置成本因子类型"],
                fields: [
                    F("WorkCenterCostFactorGroupId", "The cost factor group to update.", "要更新的成本因子组。"),
                    F("Type", "The cost type the group applies to (setup cost or unit cost).", "组适用的成本类型（设置成本或单位成本）。"),
                    F("SetAsDefaultFor", "The cost type to set the group as default for.", "将组设为默认的成本类型。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.WorkCenters.UpdateWorkCenterCostFactorGroup",
                "Update the cost factors of a work-center cost factor group.",
                "更新工作中心成本因子组的成本因子。",
                ["update cost factor group", "edit cost factors"], ["更新成本因子组", "修改成本因子"],
                fields: [
                    F("WorkCenterCostFactorGroupId", "The cost factor group to update.", "要更新的成本因子组。"),
                    F("CostFactor1", "The first cost factor.", "第一个成本因子。"),
                    F("CostFactor2", "The second cost factor.", "第二个成本因子。"),
                    F("CostFactor3", "The third cost factor.", "第三个成本因子。"),
                    F("FutureCostFactor1", "The first future cost factor.", "第一个未来成本因子。"),
                    F("FutureCostFactor2", "The second future cost factor.", "第二个未来成本因子。"),
                    F("FutureCostFactor3", "The third future cost factor.", "第三个未来成本因子。"),
                ]),
        ];
    }
}
