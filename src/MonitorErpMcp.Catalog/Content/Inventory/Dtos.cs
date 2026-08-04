namespace MonitorErpMcp.Catalog.Content.Inventory
{
    // The using-static sits inside the namespace so the imported Content(...) builder binds before
    // the enclosing MonitorErpMcp.Catalog.Content namespace in simple-name lookup.
    using static MonitorErpMcp.Catalog.Content.ContentEntryFactory;

    /// <summary>
    /// Hand-authored content for Inventory dto records: bilingual field descriptions for the request
    /// inputs the agent must understand. dto records carry field descriptions only — never a record
    /// description or search aliases, because they are reached via their parents and are not searchable.
    /// Self-evident fields (e.g. a bare Description string) are skipped per the coverage tiers.
    /// </summary>
    public static class Dtos
    {
        /// <summary>Hand-authored entries for this family, merged by <c>clrType</c> onto the structural catalog.</summary>
        public static readonly ContentEntry[] Entries =
        [
            Content(
                "Monitor.API.Inventory.Commands.CaseEntries.AddActivityCaseEntry",
                fields: [
                    F("CaseManagementActivityId", "The case management activity to add.", "要添加的案例管理活动。"),
                    F("ResponsibleUserId", "The user responsible for the activity.", "负责该活动的用户。"),
                    F("CostPerHour", "The hourly cost of the activity.", "该活动的小时成本。"),
                    F("PlannedTimeInHours", "The planned time for the activity, in hours.", "该活动的计划时间（小时）。"),
                    F("PlannedStartDate", "The planned start date of the activity.", "活动的计划开始日期。"),
                    F("PlannedCompletionDate", "The planned completion date of the activity.", "活动的计划完成日期。"),
                    F("Status", "The activity status.", "活动状态。"),
                    F("ReportedTimeInHours", "The reported time for the activity, in hours.", "该活动的已上报时间（小时）。"),
                    F("CompletionDate", "The actual completion date of the activity.", "活动的实际完成日期。"),
                    F("CompletedByUserId", "The user who completed the activity.", "完成该活动的用户。"),
                    F("ShowOnDocument", "Whether to show the activity on documents.", "是否在单据上显示该活动。"),
                    F("Reminder", "Whether to create a reminder for the activity.", "是否为该活动创建提醒。"),
                    F("Chargeable", "Whether the activity is chargeable.", "该活动是否可收费。"),
                ]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.MoveStockBalance+AddPartLocationRows",
                fields: [
                    F("Key", "The part location or product record to move from; give either Key or Name.", "要移出的物料库位或产品记录；Key 与 Name 二选一。"),
                    F("Name", "The location name to move from; give either Name or Key.", "要移出的库位名称；Name 与 Key 二选一。"),
                    F("Amount", "The quantity to move.", "要移动的数量。"),
                ]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.PartLocationInfoKey",
                fields: [
                    F("PartLocationId", "The part location to report against.", "要报到的物料库位。"),
                    F("ProductRecordId", "The product record (serial/batch) to report against, when traceable.", "可追溯时要报到的产品记录（序列号/批次）。"),
                ]),
            Content(
                "Monitor.API.Inventory.Commands.Parts.SetReason",
                fields: [
                    F("ReasonCodeId", "The reason code for the unplanned stock movement.", "计划外库存移动的原因代码。"),
                    F("Comment", "A comment, when the reason code requires one.", "原因代码要求时填写的备注。"),
                ]),
            Content(
                "Monitor.API.Inventory.Commands.ProductRecords.TraceabilityIdentifierGeneratorProperties",
                fields: [
                    F("Revision", "The revision of the product record.", "产品记录的修订版。"),
                    F("OrderNumber", "The order number used to generate the traceability identifier.", "用于生成追溯标识的订单号。"),
                    F("Position", "The position in the structure to trace.", "要追溯的结构位置。"),
                    F("Node", "The node in the structure to trace.", "要追溯的结构节点。"),
                ]),
        ];
    }
}
