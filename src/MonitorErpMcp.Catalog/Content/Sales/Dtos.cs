namespace MonitorErpMcp.Catalog.Content.Sales
{
    // The using-static sits inside the namespace so the imported Content(...) builder binds before
    // the enclosing MonitorErpMcp.Catalog.Content namespace in simple-name lookup.
    using static MonitorErpMcp.Catalog.Content.ContentEntryFactory;

    /// <summary>
    /// Hand-authored content for Sales dto records: bilingual field descriptions for the request
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
                "Monitor.API.Sales.Commands.CustomerOrderInvoices.InvoiceLocation",
                fields: [
                    F("ProductRecordId", "The product record (serial/batch) to split to, when traceability is batch or serial.", "可追溯模式为批次或序列号时，拆分到的产品记录。"),
                    F("PartLocationId", "The part location to split to, when traceability is none.", "可追溯模式为无时，拆分到的物料库位。"),
                    F("Quantity", "The quantity to split to this location.", "拆分到该库位的数量。"),
                ]),
            Content(
                "Monitor.API.Sales.Commands.CustomerOrders.SetRemotePartConfigurationRow",
                fields: [
                    F("IsMainPartRow", "Whether this is the main part row of the configuration.", "是否为配置的主物料行。"),
                    F("SelectionGroupRowStateId", "The state of the row in the selection group; required when not the main part row.", "选择组中该行的状态；非主物料行时必填。"),
                    F("CloneId", "The existing configuration to clone as the starting point.", "作为起点的现有配置，用于克隆。"),
                    F("PartId", "The part to configure.", "要配置的物料。"),
                    F("ManualPriceOrDiscount", "Whether the price or discount is entered manually.", "价格或折扣是否为手动输入。"),
                    F("PriceEach", "The price per unit.", "单价。"),
                    F("Discount", "The discount.", "折扣。"),
                    F("RemoteResultId", "The result id returned by the remote configuration service.", "远程配置服务返回的结果 id。"),
                ]),
            Content(
                "Monitor.API.Sales.Commands.DeliveryReporting.DeliveryReportingLocation",
                fields: [
                    F("Quantity", "The quantity to report delivered at this location.", "在该库位报交货的数量。"),
                    F("PartLocationId", "The part location to report the delivery against.", "报交货的物料库位。"),
                    F("NewSerialNumber", "A new serial number to register at this location.", "在该库位登记的新序列号。"),
                    F("ProductRecordId", "The product record (serial/batch) to report delivered, when traceable.", "可追溯时要报交货的产品记录（序列号/批次）。"),
                ]),
            Content(
                "Monitor.API.Sales.Commands.DeliveryReporting.DeliveryRow",
                fields: [
                    F("CustomerOrderRowId", "The customer order row being delivered.", "要交货的客户订单行。"),
                    F("Quantity", "The quantity to report delivered.", "要上报交货的数量。"),
                    F("UnitId", "The unit of measure of the quantity.", "数量的计量单位。"),
                    F("DeleteFutureRest", "Whether to delete the future rest of the row after delivery.", "交货后是否删除该行的未来剩余部分。"),
                    F("Locations", "The locations where the delivery is reported.", "上报交货的库位。"),
                ]),
            Content(
                "Monitor.API.Sales.Commands.SalesPickingLists.PackageRowAddInfo",
                fields: [
                    F("PackagingPartId", "The packaging part; give either this or the delivery row.", "包装物料；与交货行二选一。"),
                    F("CustomerOrderDeliveryRowId", "The delivery row; give either this or the packaging part.", "交货行；与包装物料二选一。"),
                    F("BalanceChange", "The stock balance change caused by the package.", "该包装引起的库存余额变化。"),
                    F("ChildRows", "The child package rows within this package.", "该包装内的子包装行。"),
                    F("ContainerNumber", "The container number of the package.", "包装的集装箱号。"),
                    F("SealNumber", "The seal number of the package.", "包装的封条号。"),
                    F("PackageNumber", "The package number.", "包装编号。"),
                    F("ExternalPackageId", "An external package id, when the package is tracked externally.", "外部包装 id（当包装在外部跟踪时）。"),
                    F("TemplateCode", "The template code for the package.", "包装的模板代码。"),
                    F("Length", "The length of the package.", "包装的长度。"),
                    F("Width", "The width of the package.", "包装的宽度。"),
                    F("Height", "The height of the package.", "包装的高度。"),
                    F("Volume", "The volume of the package.", "包装的体积。"),
                    F("GrossWeight", "The gross weight of the package.", "包装的毛重。"),
                ]),
            Content(
                "Monitor.API.Sales.Commands.SalesPickingLists.PackageRowPartLocationInfo",
                fields: [
                    F("PartLocationId", "The part location of the package row.", "包装行的物料库位。"),
                    F("ProductRecordId", "The product record (serial/batch) of the package row, when traceable.", "可追溯时包装行的产品记录（序列号/批次）。"),
                    F("BalanceChange", "The stock balance change caused by the package row.", "该包装行引起的库存余额变化。"),
                ]),
            Content(
                "Monitor.API.Sales.Commands.SalesPickingLists.SalesPickingListRow",
                fields: [
                    F("CustomerOrderDeliveryRowId", "The delivery row the picking list row relates to.", "拣货单行对应的交货行。"),
                    F("Locations", "The locations of the picking list row; required when the part is traceable.", "拣货单行的库位；物料可追溯时必填。"),
                ]),
            Content(
                "Monitor.API.Sales.Commands.Shared.SumRowDetail",
                fields: [
                    F("NoOfRowsToInclude", "The number of rows to include in the sum.", "要计入合计的行数。"),
                    F("Price", "The price per row; give either this or the discount.", "每行的价格；与折扣二选一。"),
                    F("Discount", "The discount per row; give either this or the price.", "每行的折扣；与价格二选一。"),
                ]),
            Content(
                "Monitor.API.Sales.Commands.Shared.ValidateCoding.SalesRowValidationTemplate",
                fields: [
                    F("RowIdentifier", "The identifier of the row to validate.", "要校验的行的标识。"),
                    F("OrderRowType", "The order row type.", "订单行类型。"),
                    F("PartId", "The part, when the row is a part row.", "物料；当行类型为物料行时必填。"),
                    F("WarehouseId", "The warehouse of the row.", "行的仓库。"),
                    F("IncludeSetupCost", "Whether to include setup cost in the validation.", "校验时是否包含准备成本。"),
                ]),
            Content(
                "Monitor.API.Sales.Commands.Shipments.CustomerOrderShipmentInformation",
                fields: [
                    F("CustomerOrderId", "The customer order to add to the shipment.", "要添加到装运的客户订单。"),
                    F("CustomerOrderInvoiceId", "The invoice to add, when referencing a delivery.", "引用交货时，要添加的发票。"),
                ]),
        ];
    }
}
