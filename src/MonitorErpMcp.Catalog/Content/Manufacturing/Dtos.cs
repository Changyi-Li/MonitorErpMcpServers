namespace MonitorErpMcp.Catalog.Content.Manufacturing
{
    // The using-static sits inside the namespace so the imported Content(...) builder binds before
    // the enclosing MonitorErpMcp.Catalog.Content namespace in simple-name lookup.
    using static MonitorErpMcp.Catalog.Content.ContentEntryFactory;

    /// <summary>
    /// Hand-authored content for Manufacturing dto records: bilingual field descriptions for the
    /// request inputs the agent must understand. dto records carry field descriptions only — never a
    /// record description or search aliases, because they are reached via their parents and are not
    /// searchable. Self-evident fields (e.g. a bare Description string) are skipped per the tiers.
    /// </summary>
    public static class Dtos
    {
        /// <summary>Hand-authored entries for this family, merged by <c>clrType</c> onto the structural catalog.</summary>
        public static readonly ContentEntry[] Entries =
        [
            Content(
                "Monitor.API.Manufacturing.Commands.MaintenanceReportings.MaintenanceReportingRowToReport",
                fields: [
                    F("MaintenanceReportingRowId", "The maintenance-reporting row to report.", "要上报的维护报告行。"),
                    F("CommentText", "The reported comment text of the row.", "该行上报的评论文本。"),
                    F("Checkbox", "The reported checkbox value of the row.", "该行上报的复选框值。"),
                    F("Number", "The reported numeric value of the row.", "该行上报的数值。"),
                    F("TextValue", "The reported text value of the row.", "该行上报的文本值。"),
                    F("DateTimeValue", "The reported date-time value of the row.", "该行上报的日期时间值。"),
                    F("RowStatus", "The reported status of the row (ok, not ok, ok with action).", "该行上报的状态（正常、异常、正常但需处理）。"),
                    F("ToolId", "The tool the row is reported against.", "该行上报所针对的工具。"),
                    F("ToolProductRecordId", "The product record of the tool the row is reported against.", "该行上报所针对的工具的产品记录。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.MaterialClearances.ClearManufacturingOrderMaterialRow",
                fields: [
                    F("ManufacturingOrderMaterialId", "The manufacturing-order material to clear.", "要清除的制造工单物料。"),
                    F("Locations", "The locations to clear the material from.", "要清除物料的库位。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.MeasuringReportings.MeasuringReportingRowToReport",
                fields: [
                    F("CommentText", "The reported comment text of the row.", "该行上报的评论文本。"),
                    F("Checkbox", "The reported checkbox value of the row.", "该行上报的复选框值。"),
                    F("Number", "The reported numeric value of the row.", "该行上报的数值。"),
                    F("TextValue", "The reported text value of the row.", "该行上报的文本值。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.MeasuringReportings.MeasuringReportingSerialNumberToReport",
                fields: [
                    F("SerialNumber", "The serial number to report measuring data for.", "要上报测量数据的序列号。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.PickingLists.ManufacturingPickingListLocationRow",
                fields: [
                    F("ProductRecordId", "The product record (serial/batch) to pick; required when the part is traceable.", "要领用的产品记录（序列号/批次）；物料可追溯时必填。"),
                    F("PartLocationId", "The part location to pick from.", "要领用的物料库位。"),
                    F("BalanceChange", "The quantity change of the picking.", "领料的数量变更。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.PickingLists.ManufacturingPickingListMaterialReporting",
                fields: [
                    F("MaterialId", "The manufacturing-order material to report as picked.", "要上报已领的制造工单物料。"),
                    F("Locations", "The locations the material was picked from.", "物料领出的库位。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.Reporting.AddLocationRow",
                fields: [
                    F("LocationName", "The name of the location to report to.", "要上报的库位名称。"),
                    F("BalanceChange", "The quantity change of the location.", "库位的数量变更。"),
                    F("SerialNumber", "The serial number reported to the location.", "上报到库位的序列号。"),
                    F("BatchNumber", "The batch number reported to the location.", "上报到库位的批次号。"),
                    F("BatchChargeNumber", "The batch charge number reported to the location.", "上报到库位的批次炉号。"),
                    F("BestBeforeDate", "The best-before date reported to the location.", "上报到库位的保质期。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.Reporting.AddRejectionRow",
                fields: [
                    F("RejectionCodeId", "The rejection code of the rejected quantity.", "拒收数量的拒收代码。"),
                    F("RejectedQuantity", "The rejected quantity.", "拒收数量。"),
                    F("Comment", "A comment on the rejection; required when the rejection code requires it.", "拒收的备注；拒收代码要求时必填。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.Reporting.AddTraceableMaterialRow",
                fields: [
                    F("ProductRecordId", "The product record (serial/batch) to report.", "要上报的产品记录（序列号/批次）。"),
                    F("PartLocationId", "The part location to report to; defaults to the first available for the record.", "要上报的物料库位；默认取该记录的第一个可用库位。"),
                    F("BalanceChange", "The quantity change of the location.", "库位的数量变更。"),
                    F("Rejections", "The rejection rows of the material.", "物料的拒收行。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.Reporting.ExistingLocationRow",
                fields: [
                    F("PartLocationId", "The existing part location to report to.", "要上报的现有物料库位。"),
                    F("ProductRecordId", "The product record (serial/batch) to report.", "要上报的产品记录（序列号/批次）。"),
                    F("BalanceChange", "The quantity change of the location.", "库位的数量变更。"),
                    F("SerialNumber", "The serial number reported to the location.", "上报到库位的序列号。"),
                    F("BatchNumber", "The batch number reported to the location.", "上报到库位的批次号。"),
                    F("BatchChargeNumber", "The batch charge number reported to the location.", "上报到库位的批次炉号。"),
                    F("BestBeforeDate", "The best-before date reported to the location.", "上报到库位的保质期。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.Tools.ToolReturn.ReturnToolRequest",
                fields: [
                    F("ProductRecordId", "The product record (tool) to return.", "要归还的产品记录（工具）。"),
                    F("BalanceChange", "The quantity change of the return.", "归还的数量变更。"),
                ]),
            Content(
                "Monitor.API.Manufacturing.Commands.Tools.ToolWithdrawal.LendToolRequest",
                fields: [
                    F("ProductRecordId", "The product record (tool) to lend.", "要借出的产品记录（工具）。"),
                    F("BalanceChange", "The quantity change of the withdrawal.", "借出的数量变更。"),
                ]),
        ];
    }
}
