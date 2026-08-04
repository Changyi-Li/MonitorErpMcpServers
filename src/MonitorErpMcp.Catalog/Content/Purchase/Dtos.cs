namespace MonitorErpMcp.Catalog.Content.Purchase
{
    // The using-static sits inside the namespace so the imported Content(...) builder binds before
    // the enclosing MonitorErpMcp.Catalog.Content namespace in simple-name lookup.
    using static MonitorErpMcp.Catalog.Content.ContentEntryFactory;

    /// <summary>
    /// Hand-authored content for Purchase dto records: bilingual field descriptions for the request
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
                "Monitor.API.Purchase.Commands.ArrivalReporting.ArrivalLocation",
                fields: [
                    F("PartLocationId", "The existing part location to report to; give either this or PartLocationName.", "要上报的现有物料库位；本字段与 PartLocationName 二选一。"),
                    F("PartLocationName", "The name of a new part location to report to; give either this or PartLocationId.", "要上报的新物料库位名称；本字段与 PartLocationId 二选一。"),
                    F("Quantity", "The quantity reported to the location.", "上报到该库位的数量。"),
                    F("ProductRecords", "The product records (batch/serial) reported to the location; required for traceable parts.", "上报到该库位的产品记录（批次/序列号）；可追溯物料必填。"),
                ]),
            Content(
                "Monitor.API.Purchase.Commands.ArrivalReporting.ArrivalProductRecord",
                fields: [
                    F("SerialNumber", "The new serial number to create.", "要创建的新序列号。"),
                    F("BatchNumber", "The new batch number to create.", "要创建的新批次号。"),
                    F("ProductRecordId", "The existing batch/product record to report to.", "要上报的现有批次/产品记录。"),
                    F("ChargeNumber", "The charge number of the batch.", "批次的炉号。"),
                    F("Quantity", "The quantity of the product record.", "产品记录的数量。"),
                    F("BestBeforeDate", "The best-before date of the batch.", "批次的保质期。"),
                ]),
            Content(
                "Monitor.API.Purchase.Commands.ArrivalReporting.ArrivalRow",
                fields: [
                    F("PurchaseOrderRowId", "The purchase-order row the arrival concerns.", "到货所针对的采购订单行。"),
                    F("Quantity", "The arrived quantity.", "到货数量。"),
                    F("UnitId", "The unit of the arrived quantity; defaults to the standard unit on the part.", "到货数量的单位；默认为物料的标准单位。"),
                    F("DeleteFutureRest", "Whether to delete the remaining (future) rest of the row.", "是否删除行剩余的（未来）数量。"),
                    F("Locations", "The locations the goods are reported to.", "货物上报的库位。"),
                    F("GoodsLocation", "The goods location of the arrival.", "到货的货品库位。"),
                ]),
            Content(
                "Monitor.API.Purchase.Commands.BlanketOrderPurchases.BlanketOrderPurchaseRow",
                fields: [
                    F("PartId", "The part of the row.", "行的物料。"),
                    F("OrderRowType", "The type of the row (part, additional, sum, free text).", "行的类型（物料、附加、合计、自由文本）。"),
                    F("OrderedQuantity", "The ordered quantity of the row.", "行的订购数量。"),
                ]),
            Content(
                "Monitor.API.Purchase.Commands.PurchaseOrderAdvices.PurchaseOrderAdviceRowProductRecordReporting",
                fields: [
                    F("TraceabilityMode", "The traceability mode of the reporting (batch, individual, individual-only withdrawal).", "上报的追溯模式（批次、单个、仅单个领用）。"),
                    F("BatchNumber", "The batch number reported; required when the traceability mode is batch.", "上报的批次号；批次模式必填。"),
                    F("BatchQuantity", "The quantity of the batch.", "批次的数量。"),
                    F("BatchBestBeforeDate", "The best-before date of the batch.", "批次的保质期。"),
                    F("SerialNumberStart", "The first serial number of the range.", "序列号范围的起始号。"),
                    F("SerialNumberCount", "The number of serial numbers to report; required for serial-number mode.", "要上报的序列号数量；序列号模式必填。"),
                    F("ChargeNumber", "The charge number of the batch.", "批次的炉号。"),
                ]),
            Content(
                "Monitor.API.Purchase.Commands.ReceivingInspection.ReceivingInspectionRejectionRow",
                fields: [
                    F("RejectQuantity", "The rejected quantity.", "拒收数量。"),
                    F("RejectionCodeId", "The rejection code of the rejection.", "拒收的拒收代码。"),
                    F("Comment", "A comment on the rejection; required when the rejection code requires it.", "拒收的备注；拒收代码要求时必填。"),
                ]),
            Content(
                "Monitor.API.Purchase.Commands.ReceivingInspection.ReceivingInspectionRow",
                fields: [
                    F("PurchaseOrderDeliveryRowId", "The purchase-order delivery row the inspection concerns.", "检验所针对的采购订单交货行。"),
                    F("ApproveQuantity", "The approved quantity of the inspection.", "检验的合格数量。"),
                    F("UnitId", "The unit of the quantity; defaults to the standard unit on the part.", "数量的单位；默认为物料的标准单位。"),
                    F("Locations", "The locations the approved goods are put in.", "合格货物放入的库位。"),
                    F("Rejections", "The rejection rows of the inspection.", "检验的拒收行。"),
                ]),
        ];
    }
}
