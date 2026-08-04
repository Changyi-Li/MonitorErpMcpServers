namespace MonitorErpMcp.Catalog.Content.Manufacturing
{
    // The using-static sits inside the namespace so the imported Content(...) builder binds before
    // the enclosing MonitorErpMcp.Catalog.Content namespace in simple-name lookup.
    using static MonitorErpMcp.Catalog.Content.ContentEntryFactory;
    using MonitorErpMcp.Catalog.Model;

    /// <summary>
    /// Hand-authored content for Manufacturing query records: bilingual descriptions and search
    /// aliases (en first, zh second), keyed by clrType and merged onto the structural catalog.
    /// Important fields (enum, reference, expandable, unique) carry bilingual descriptions;
    /// self-evident fields such as a bare Description string are skipped per the coverage tiers.
    /// </summary>
    public static class Queries
    {
        /// <summary>Hand-authored entries for this family, merged by <c>clrType</c> onto the structural catalog.</summary>
        public static readonly ContentEntry[] Entries =
        [
            // ---- Drawings ------------------------------------------------------------
            Content(
                "Monitor.API.Manufacturing.Drawing",
                "A drawing attached to a part or manufacturing-order node, with its revisions.",
                "附加到物料或制造工单节点上的图纸，含其修订版。",
                ["drawing", "drawing document", "blueprint"], ["图纸", "图样", "图纸文档"],
                fields: [
                    F("DrawingNumber", "The unique number of the drawing.", "图纸的唯一编号。"),
                    F("Revisions", "The revisions of the drawing.", "图纸的修订版。"),
                    F("ActiveDrawingRevisionId", "The currently active revision of the drawing.", "图纸当前活动的修订版。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.DrawingRevision",
                "A revision of a drawing.",
                "图纸的修订版。",
                ["drawing revision", "revision"], ["图纸修订", "图纸版本"],
                fields: [
                    F("Number", "The unique number of the revision.", "修订版的唯一编号。"),
                    F("RevisionComment", "A comment on the revision.", "修订版的备注。"),
                ]),

            // ---- MaintenanceReportings -----------------------------------------------
            Content(
                "Monitor.API.Manufacturing.MaintenanceReporting",
                "A maintenance report for a tool or product record, with its status and rows.",
                "工具或产品记录的维护报告，含状态与行。",
                ["maintenance reporting", "maintenance report", "service report"], ["维护报告", "保养报告", "维修报告"],
                fields: [
                    F("SerialNumber", "The unique serial number of the maintenance report.", "维护报告的唯一条码/序号。"),
                    F("ManufacturingOrderId", "The manufacturing order the report is linked to, if any.", "报告关联的制造工单（如有）。"),
                    F("ManufacturingOrder", "The manufacturing order the report is linked to, if any.", "报告关联的制造工单（如有）。"),
                    F("ProductRecord", "The product record (serial/batch) the report is for.", "报告针对的产品记录（序列号/批次）。"),
                    F("MaintenanceStatus", "The result of the maintenance (ok, not ok, ok with action).", "维护结果（正常、异常、正常但需处理）。"),
                    F("ReportedById", "The person who reported the maintenance.", "上报维护的人员。"),
                    F("ReportedBy", "The person who reported the maintenance.", "上报维护的人员。"),
                    F("ReportingStatus", "The progress of the report (new, in progress, finished).", "报告的进度（新建、进行中、已完成）。"),
                    F("Status", "The approval status of the maintained item.", "被维护物品的审批状态。"),
                    F("CommentId", "A comment on the report.", "报告的备注。"),
                    F("Comment", "A comment on the report.", "报告的备注。"),
                    F("Instruction", "The maintenance instruction of the report.", "报告的维护说明。"),
                    F("MaintenanceReportingSelectionRows", "The selection rows of the maintenance report.", "维护报告的选择行。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.MaintenanceReportingRow",
                "A row of a maintenance report: a checked measurement or inspection result.",
                "维护报告的行：被检查的测量或检验结果。",
                ["maintenance row", "maintenance reporting row"], ["维护行", "维护报告行"],
                fields: [
                    F("Code", "The code of the maintenance row.", "维护行的代码。"),
                    F("Type", "The value type of the row (decimal, text, checkbox, date).", "行的值类型（小数、文本、复选框、日期）。"),
                    F("ReportingStatus", "The result of the row (ok, not ok, ok with action).", "行的结果（正常、异常、正常但需处理）。"),
                    F("MasterToolId", "The master tool (part) the row is checked against.", "该行检查所依据的主工具（物料）。"),
                    F("MasterToolProductRecordId", "The product record of the master tool.", "主工具的产品记录。"),
                    F("UnitId", "The unit of the row value.", "行值的单位。"),
                    F("MaintenanceReportingSelectionRowId", "The selection row this row belongs to.", "该行所属的选择行。"),
                    F("CommentId", "A comment on the row.", "该行的备注。"),
                    F("Comment", "A comment on the row.", "该行的备注。"),
                    F("Instruction", "The instruction of the row.", "该行的说明。"),
                    F("InstructionId", "The instruction of the row.", "该行的说明。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.MaintenanceReportingSelectionRow",
                "A selection row of a maintenance report that groups its reporting rows.",
                "对维护报告行进行分组的维护报告选择行。",
                ["maintenance selection row"], ["维护选择行", "维护报告选择行"],
                fields: [
                    F("Code", "The unique code of the selection row.", "选择行的唯一代码。"),
                    F("MaintenanceReportingId", "The maintenance report the selection row belongs to.", "选择行所属的维护报告。"),
                    F("MaintenanceReportingRows", "The reporting rows of the selection row.", "选择行的报告行。"),
                    F("CommentId", "A comment on the selection row.", "选择行的备注。"),
                    F("Comment", "A comment on the selection row.", "选择行的备注。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.ManualOperationStatus",
                "The manual operation statuses that can be set on a manufacturing-order operation.",
                "可在制造工单工序上设置的手动工序状态。",
                ["manual operation status", "operation status"], ["手动工序状态", "工序状态"],
                fields: [
                    F("Code", "The unique code of the status.", "状态的唯一代码。"),
                ]),

            // ---- ManufacturingOrders ------------------------------------------------
            Content(
                "Monitor.API.Manufacturing.ManufacturingOrder",
                "A manufacturing order — a planned and tracked production order for a part, with its operations, materials, and nodes.",
                "制造工单 —— 物料的已计划并跟踪的生产订单，含工序、物料与节点。",
                ["manufacturing order", "work order", "production order", "job", "manufacturing order number"], ["制造工单", "生产工单", "加工单", "工单"],
                fields: [
                    F("OrderNumber", "The unique number of the manufacturing order.", "制造工单的唯一编号。"),
                    F("Status", "The status of the order (registered, printed, started, finished...).", "工单的状态（已登记、已打印、已开始、已完成等）。"),
                    F("Part", "The part being manufactured.", "正在制造的物料。"),
                    F("CustomerId", "The customer of the order, when customer-order controlled.", "工单的客户（客户订单控制时）。"),
                    F("CustomerOrder", "The customer order the manufacturing order is linked to.", "与制造工单关联的客户订单。"),
                    F("Operations", "The operations of the order.", "工单的工序。"),
                    F("Materials", "The materials of the order.", "工单的物料。"),
                    F("Nodes", "The nodes of the order.", "工单的节点。"),
                    F("Project", "The project the order is linked to.", "工单关联的项目。"),
                    F("PartConfigurationId", "The part configuration used for the order.", "工单使用的物料配置。"),
                    F("OrderQuantityId", "The order quantity (with partial quantities) of the order.", "工单的订单数量（含零头数量）。"),
                    F("OrderQuantity", "The order quantity (with partial quantities) of the order.", "工单的订单数量（含零头数量）。"),
                    F("OrderTypeId", "The manufacturing order type of the order.", "工单的制造工单类型。"),
                    F("OrderType", "The manufacturing order type of the order.", "工单的制造工单类型。"),
                    F("Comment", "A comment on the order.", "工单的备注。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.ManufacturingOrderMaterial",
                "A material row of a manufacturing order — the part consumed by an operation, with planned and reported quantity.",
                "制造工单的物料行 —— 工序消耗的物料，含计划与上报数量。",
                ["manufacturing order material", "order material", "manufacturing material"], ["制造工单物料", "工单物料", "制造物料"],
                fields: [
                    F("Part", "The part consumed by the material row.", "物料行消耗的物料。"),
                    F("EditedStatus", "Whether the material row has been edited from its origin (not edited, edited, synchronized).", "物料行是否已相对来源修改（未修改、已修改、已同步）。"),
                    F("InstructionComment", "The instruction comment of the material row.", "物料行的说明备注。"),
                    F("InstructionCommentId", "The instruction comment of the material row.", "物料行的说明备注。"),
                    F("LinkedPurchaseOrderRowId", "The purchase-order row linked to the material, when the material is purchased.", "物料关联的采购订单行（物料为采购时）。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.ManufacturingOrderNode",
                "A node of a manufacturing order — a sub-order within the order structure, with its drawings and status.",
                "制造工单的节点 —— 工单结构中的子订单，含图纸与状态。",
                ["manufacturing order node", "order node", "node"], ["制造工单节点", "工单节点", "节点"],
                fields: [
                    F("Status", "The status of the node.", "节点的状态。"),
                    F("Drawings", "The drawings attached to the node.", "附加到节点的图纸。"),
                    F("Revision", "The part revision of the node.", "节点的物料修订版。"),
                    F("SerialNumberProductRecords", "The serial-numbered product records of the node.", "节点的序列号产品记录。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.ManufacturingOrderNodeDrawing",
                "A drawing attached to a manufacturing-order node, with its revisions.",
                "附加到制造工单节点的图纸，含其修订版。",
                ["node drawing", "order node drawing"], ["节点图纸", "工单节点图纸"],
                fields: [
                    F("Revisions", "The revisions of the node drawing.", "节点图纸的修订版。"),
                    F("ActiveDrawingRevisionId", "The currently active revision of the node drawing.", "节点图纸当前活动的修订版。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.ManufacturingOrderNodeDrawingRevision",
                "A revision of a manufacturing-order node drawing.",
                "制造工单节点图纸的修订版。",
                ["node drawing revision"], ["节点图纸修订"],
                fields: [
                    F("Number", "The unique number of the revision.", "修订版的唯一编号。"),
                    F("RevisionComment", "A comment on the revision.", "修订版的备注。"),
                ]),

            // ---- Operations ----------------------------------------------------------
            Content(
                "Monitor.API.Manufacturing.ManufacturingOrderOperation",
                "An operation of a manufacturing order — a work step with its planned time, quantity, and reporting.",
                "制造工单的工序 —— 作业步骤，含计划时间、数量与上报。",
                ["manufacturing order operation", "operation", "work step", "process step"], ["制造工单工序", "工序", "作业步骤"],
                fields: [
                    F("Part", "The part of the operation.", "工序的物料。"),
                    F("Status", "The shipping/reporting status of the operation.", "工序的发货/上报状态。"),
                    F("WorkshopOperationStatus", "The workshop status of the operation (in progress, clocked out, interrupted...).", "工序的车间状态（进行中、已刷卡、中断等）。"),
                    F("OperationRowId", "The operation row the operation is based on.", "工序所依据的工序行。"),
                    F("OperationRow", "The operation row the operation is based on.", "工序所依据的工序行。"),
                    F("OrderQuantityId", "The order quantity (with partial quantities) of the operation.", "工序的订单数量（含零头数量）。"),
                    F("OrderQuantity", "The order quantity (with partial quantities) of the operation.", "工序的订单数量（含零头数量）。"),
                    F("Materials", "The materials consumed by the operation.", "工序消耗的物料。"),
                    F("ControlDataRows", "The control-data rows (measuring) of the operation.", "工序的控制数据行（测量）。"),
                    F("InstructionComment", "The instruction comment of the operation.", "工序的说明备注。"),
                    F("ManualOperationStatusId", "The manual status set on the operation.", "工序上设置的手动状态。"),
                    F("ManualOperationStatus", "The manual status set on the operation.", "工序上设置的手动状态。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.ManufacturingOrderOperationControlDataRow",
                "A control-data row of a manufacturing-order operation: measuring data per work center.",
                "制造工单工序的控制数据行：按工作中心的测量数据。",
                ["operation control data", "control data row", "measuring row"], ["工序控制数据行", "控制数据行"],
                fields: [
                    F("ManufacturingOrderOperationId", "The operation the control-data row belongs to.", "控制数据行所属的工序。"),
                    F("MeasuringTemplateId", "The measuring template of the row.", "该行的测量模板。"),
                    F("OverridenFormTemplateId", "The form template overriding the template's form.", "覆盖模板表单的表单模板。"),
                    F("WorkCenterId", "The work center the control data applies to.", "控制数据适用的工作中心。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.ManufacturingOrderOperationReporting",
                "A reported quantity and time against a manufacturing-order operation.",
                "针对制造工单工序上报的数量与时间。",
                ["operation reporting", "reporting", "operation report"], ["工序上报", "工序报告", "作业上报"],
                fields: [
                    F("OperationId", "The operation the reporting concerns.", "上报所针对的工序。"),
                    F("Type", "The type of reporting (regular, subcontractor, recording terminal...).", "上报的类型（常规、外协、记录终端等）。"),
                    F("WorkCenterId", "The work center the reporting was made against.", "上报所针对的工作中心。"),
                    F("EmployeeId", "The employee the reporting was made for.", "上报所针对的员工。"),
                    F("ReportingEmployeeId", "The employee who made the reporting.", "进行上报的员工。"),
                    F("WarehouseId", "The warehouse of the reporting.", "上报的仓库。"),
                    F("PreviousNodeStatus", "The node status before the reporting.", "上报前节点的状态。"),
                    F("PurchaseOrderDeliveryRowId", "The purchase-order delivery row linked to the reporting.", "与上报关联的采购订单交货行。"),
                    F("ReasonCodeTimeConsumptionId", "The time-consumption reason code of the reporting.", "上报的工时消耗原因代码。"),
                    F("ReasonCodeTimeConsumption", "The time-consumption reason code of the reporting.", "上报的工时消耗原因代码。"),
                    F("CommentId", "A comment on the reporting.", "上报的备注。"),
                    F("Comment", "A comment on the reporting.", "上报的备注。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.ManufacturingOrderType",
                "A manufacturing order type defining how orders are numbered and controlled.",
                "定义工单编号与控制方式的制造工单类型。",
                ["manufacturing order type", "order type"], ["制造工单类型", "工单类型"],
                fields: [
                    F("BaseType", "Whether orders are inventory, customer-order, or maintenance controlled.", "工单是库存控制、客户订单控制还是维护控制。"),
                ]),

            // ---- PickingLists --------------------------------------------------------
            Content(
                "Monitor.API.Manufacturing.ManufacturingPickingList",
                "A manufacturing picking list — a list of materials to pick for manufacturing, with its status.",
                "制造领料单 —— 制造所需领用的物料清单，含状态。",
                ["manufacturing picking list", "picking list"], ["制造领料单", "领料单", "配料单"],
                fields: [
                    F("Status", "The status of the picking list (registered, printed, reported, history).", "领料单的状态（已登记、已打印、已上报、历史）。"),
                    F("Grouping", "How the picking list is grouped (by order, by material, or not grouped).", "领料单的分组方式（按工单、按物料或不分组）。"),
                    F("Sorting", "How the picking list is sorted (by location, part number...).", "领料单的排序方式（按库位、物料编号等）。"),
                    F("Type", "Whether the picking list is regular or for equipment.", "领料单是常规还是设备领用。"),
                    F("WarehouseId", "The warehouse the picking list applies to.", "领料单适用的仓库。"),
                    F("CreatedByApplicationUserId", "The user who created the picking list.", "创建领料单的用户。"),
                    F("CreatedByPersonId", "The person who created the picking list.", "创建领料单的人员。"),
                    F("PrintedByApplicationUserId", "The user who printed the picking list.", "打印领料单的用户。"),
                    F("PrintedByPersonId", "The person who printed the picking list.", "打印领料单的人员。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.ManufacturingPickingListMaterial",
                "A material of a manufacturing picking list, with its quantity change.",
                "制造领料单的物料，含其数量变更。",
                ["picking list material", "picking material"], ["领料单物料", "领料物料"],
                fields: [
                    F("MaterialId", "The manufacturing-order material on the picking list.", "领料单上的制造工单物料。"),
                    F("Material", "The manufacturing-order material on the picking list.", "领料单上的制造工单物料。"),
                    F("QuantityChangeId", "The stock quantity change caused by the picking.", "领料引起的库存数量变更。"),
                    F("QuantityChange", "The stock quantity change caused by the picking.", "领料引起的库存数量变更。"),
                ]),

            // ---- Rows ----------------------------------------------------------------
            Content(
                "Monitor.API.Manufacturing.MaterialRow",
                "A material row of a preparation — a part consumed by an operation with its quantity.",
                "准备资料的物料行 —— 工序消耗的物料及其数量。",
                ["material row", "preparation material", "bill of material row"], ["物料行", "准备物料行", "物料清单行"],
                fields: [
                    F("Comment", "A comment on the material row.", "物料行的备注。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.OperationRow",
                "An operation row of a preparation — a work step with its time, cost, and work center.",
                "准备资料的工序行 —— 作业步骤，含时间、成本与工作中心。",
                ["operation row", "preparation operation"], ["工序行", "准备工序行"],
                fields: [
                    F("TimeCode", "How the operation time was set (not initialized, calculated, studied).", "工序时间的设定方式（未初始化、计算、实测）。"),
                    F("TimeUnit", "The unit of the operation time (hours, minutes, seconds, quantity per hour...).", "工序时间的单位（小时、分钟、秒、每小时数量等）。"),
                    F("ControlDataRows", "The control-data rows (measuring) of the operation row.", "工序行的控制数据行（测量）。"),
                    F("ExtraFields", "The extra field values of the operation row.", "工序行的附加字段值。"),
                    F("Comment", "A comment on the operation row.", "工序行的备注。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.OperationRowControlDataRow",
                "A control-data row of an operation row: measuring data per work center.",
                "工序行的控制数据行：按工作中心的测量数据。",
                ["operation row control data"], ["工序行控制数据行"],
                fields: [
                    F("OperationRowId", "The operation row the control-data row belongs to.", "控制数据行所属的工序行。"),
                    F("MeasuringTemplateId", "The measuring template of the row.", "该行的测量模板。"),
                    F("OverriddenFormTemplateId", "The form template overriding the template's form.", "覆盖模板表单的表单模板。"),
                    F("WorkCenterId", "The work center the control data applies to.", "控制数据适用的工作中心。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.OrderQuantityManufacturingOrder",
                "The order quantity of a manufacturing order, including its partial quantities.",
                "制造工单的订单数量，含零头数量。",
                ["order quantity", "manufacturing order quantity"], ["订单数量", "工单数量"],
                fields: [
                    F("PartialQuantities", "The partial quantities of the order quantity.", "订单数量的零头数量。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.OrderQuantityManufacturingOrderOperation",
                "The order quantity of a manufacturing-order operation, including its partial quantities.",
                "制造工单工序的订单数量，含零头数量。",
                ["operation order quantity"], ["工序订单数量", "工序数量"],
                fields: [
                    F("PartialQuantities", "The partial quantities of the order quantity.", "订单数量的零头数量。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Preparation",
                "A preparation — a reusable set of material and operation rows for manufacturing a part.",
                "准备资料 —— 制造物料时可复用的物料行与工序行集合。",
                ["preparation", "manufacturing preparation", "routing"], ["准备资料", "制造准备", "工艺路线"],
                fields: [
                    F("PartNumber", "The unique part number of the preparation.", "准备资料的唯一物料编号。"),
                    F("Materials", "The material rows of the preparation.", "准备资料的物料行。"),
                    F("Operations", "The operation rows of the preparation.", "准备资料的工序行。"),
                    F("VariantXAxis", "The X-axis variant dimension of the preparation.", "准备资料的 X 轴变体维度。"),
                    F("VariantYAxis", "The Y-axis variant dimension of the preparation.", "准备资料的 Y 轴变体维度。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.ProductionCalendarException",
                "An exception to the production calendar of a work center on a specific date.",
                "工作中心在某特定日期对生产日历的例外。",
                ["production calendar exception", "calendar exception"], ["生产日历例外", "日历例外"],
                fields: [
                    F("WorkCenterId", "The work center the exception applies to.", "例外适用的工作中心。"),
                    F("ScheduleId", "The schedule the exception applies to.", "例外适用的排班。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.ReasonCodeTimeConsumption",
                "The reason codes for time consumption on operation reporting, as time loss or gain.",
                "工序上报中工时消耗的原因代码，分为工时损失或工时增加。",
                ["time consumption reason", "time reason code"], ["工时消耗原因", "工时原因代码"],
                fields: [
                    F("Code", "The unique code of the reason.", "原因的唯一代码。"),
                    F("TimeConsumptionType", "Whether the reason is a time loss or a time gain.", "原因是工时损失还是工时增加。"),
                ]),

            // ---- WorkCenters ---------------------------------------------------------
            Content(
                "Monitor.API.Manufacturing.WorkCenter",
                "A work center where operations are performed, with its capacity, cost factor groups, and employees.",
                "执行工序的工作中心，含产能、成本因子组与员工。",
                ["work center", "work centre", "machine", "resource"], ["工作中心", "机台", "加工中心"],
                fields: [
                    F("Number", "The unique number of the work center.", "工作中心的唯一编号。"),
                    F("Type", "The type of work center (machine, manual work, subcontract, pool, pick).", "工作中心的类型（机器、手工、外协、组、拣选）。"),
                    F("Warehouse", "The warehouse of the work center.", "工作中心的仓库。"),
                    F("TimePrecision", "The time precision of the work center (day, schedule, hourly).", "工作中心的时间精度（日、班次、小时）。"),
                    F("Comment", "A comment on the work center.", "工作中心的备注。"),
                    F("ManufacturingPrintSettings", "The manufacturing print settings of the work center.", "工作中心的制造打印设置。"),
                    F("CostFactorGroups", "The cost factor groups of the work center.", "工作中心的成本因子组。"),
                    F("Employees", "The employees of the work center.", "工作中心的员工。"),
                    F("ProductionCalendarExceptions", "The production calendar exceptions of the work center.", "工作中心的生产日历例外。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.WorkCenterCostFactorGroup",
                "A cost factor group of a work center — factors applied to setup and unit costs.",
                "工作中心的成本因子组 —— 应用于设置与单位成本的因子。",
                ["cost factor group", "cost factor"], ["成本因子组", "成本因子"],
                fields: [
                    F("Type", "Whether the group applies to setup cost, unit cost, or neither.", "组适用于设置成本、单位成本或两者皆非。"),
                    F("ParentId", "The work center the group belongs to.", "组所属的工作中心。"),
                ]),
        ];
    }
}
