namespace MonitorErpMcp.Catalog.Content.Accounting
{
    // The using-static sits inside the namespace so the imported Content(...) builder binds before
    // the enclosing MonitorErpMcp.Catalog.Content namespace in simple-name lookup.
    using static MonitorErpMcp.Catalog.Content.ContentEntryFactory;

    /// <summary>
    /// Hand-authored content for Accounting dto records: bilingual field descriptions for the request
    /// inputs the agent must understand. dto records carry field descriptions only — never a record
    /// description or search aliases, because they are reached via their parents and are not searchable.
    /// Self-evident fields are skipped per the coverage tiers.
    /// </summary>
    public static class Dtos
    {
        /// <summary>Hand-authored entries for this family, merged by <c>clrType</c> onto the structural catalog.</summary>
        public static readonly ContentEntry[] Entries =
        [
            Content(
                "Monitor.API.Accounting.Commands.AccountsPayables.AddCodingEntryElement",
                fields: [
                    F("CodingDimensionId", "The coding dimension of the element.", "元素的记账维度。"),
                    F("RefencingEntityId", "The referenced entity of the element (the API spelling).", "元素所引用的实体（API 拼写）。"),
                    F("ReferencingEntityId", "The referenced entity of the element.", "元素所引用的实体。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.AccountsPayables.AddFinalBookingRow",
                fields: [
                    F("AccountId", "The account of the final booking row.", "最终记账行的科目。"),
                    F("DebitAmountInCompanyCurrency", "The debit amount in company currency.", "按公司货币计价的借方金额。"),
                    F("CreditAmountInCompanyCurrency", "The credit amount in company currency.", "按公司货币计价的贷方金额。"),
                    F("CodingEntryElements", "The coding-dimension elements of the coding entry.", "记账条目的记账维度元素。"),
                    F("CodingEntryDescription", "The description of the coding entry.", "记账条目的描述。"),
                    F("PurchaseOrderDeliveryRowId", "The purchase-order delivery row the booking row originates from, if any.", "记账行所源自的采购订单交货行（如有）。"),
                    F("BookingRowType", "The type of the booking row (accounts payable, VAT, purchase...).", "记账行的类型（应付账款、增值税、采购等）。"),
                    F("VatRateId", "The VAT rate of the booking row.", "记账行的增值税率。"),
                    F("Quantity", "The quantity of the booking row.", "记账行的数量。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.AccountsPayables.UpdateBookingRow",
                fields: [
                    F("BookingRowId", "The booking row to update.", "要更新的记账行。"),
                    F("AccountId", "The account of the booking row.", "记账行的科目。"),
                    F("DebitAmountInCompanyCurrency", "The debit amount in company currency.", "按公司货币计价的借方金额。"),
                    F("CreditAmountInCompanyCurrency", "The credit amount in company currency.", "按公司货币计价的贷方金额。"),
                    F("CodingEntryElements", "The coding-dimension elements of the coding entry.", "记账条目的记账维度元素。"),
                    F("CodingEntryDescription", "The description of the coding entry.", "记账条目的描述。"),
                    F("VatRateId", "The VAT rate of the booking row.", "记账行的增值税率。"),
                    F("Quantity", "The quantity of the booking row.", "记账行的数量。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.AccountsPayables.UpdateCodingEntryElement",
                fields: [
                    F("CodingEntryElementId", "The coding-entry element to update.", "要更新的记账条目元素。"),
                    F("RefencingEntityId", "The referenced entity of the element (the API spelling).", "元素所引用的实体（API 拼写）。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.AccountsReceivables.AddIncomingPaymentRow",
                fields: [
                    F("InvoiceId", "The invoice to pay; required when paying an invoice.", "要付款的发票；支付发票时必填。"),
                    F("CustomerId", "The customer paying; required for an on-account payment.", "付款的客户；预收付款时必填。"),
                    F("PaymentDate", "The payment date.", "付款日期。"),
                    F("PaidAmount", "The paid amount.", "实付金额。"),
                    F("PaymentMethodId", "The payment method of the payment.", "付款的付款方式。"),
                    F("ExchangeRate", "The exchange rate of the payment.", "付款的汇率。"),
                    F("WriteOffCodeId", "The write-off code; required when the payment exceeds the invoice.", "核销代码；付款超过发票金额时必填。"),
                    F("BankChargeAmount", "The bank-charge amount of the payment.", "付款的银行手续费金额。"),
                    F("InterestType", "The interest handling of the payment (interest invoice, next regular invoice, none).", "付款的利息处理方式（利息发票、下次普通发票、无）。"),
                    F("ChequeNumber", "The cheque number of the payment.", "付款的支票号。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.AccrualAccountings.AddCodingEntryElement",
                fields: [
                    F("CodingDimensionId", "The coding dimension of the element.", "元素的记账维度。"),
                    F("RefencingEntityId", "The referenced entity of the element (the API spelling).", "元素所引用的实体（API 拼写）。"),
                    F("ReferencingEntityId", "The referenced entity of the element.", "元素所引用的实体。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.AddBookingRow",
                fields: [
                    F("AccountId", "The account of the booking row.", "记账行的科目。"),
                    F("DebitAmountInCompanyCurreny", "The debit amount in company currency (the API's misspelled spelling).", "按公司货币计价的借方金额（API 拼写有误）。"),
                    F("DebitAmountInCompanyCurrency", "The debit amount in company currency.", "按公司货币计价的借方金额。"),
                    F("CreditAmountInCompanyCurrency", "The credit amount in company currency.", "按公司货币计价的贷方金额。"),
                    F("CodingEntryElements", "The coding-dimension elements of the coding entry.", "记账条目的记账维度元素。"),
                    F("Specification", "The specification text of the booking row.", "记账行的说明文本。"),
                    F("VatRateId", "The VAT rate of the booking row.", "记账行的增值税率。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.AllocationKeys.AddAllocationKeyResultRow",
                fields: [
                    F("Dimensions", "The coding-dimension values of the result row.", "结果行的记账维度值。"),
                    F("Percentage", "The percentage of the amount allocated to the row.", "分摊到该行的金额百分比。"),
                    F("ResultRowId", "The existing allocation-key result row to update, if any.", "要更新的现有分摊结果行（如有）。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.Export.AccountingExportSettings",
                fields: [
                    F("AccountingYearId", "The accounting year to export.", "要导出的会计年度。"),
                    F("BudgetTypeId", "The budget type to export budgets for.", "要导出预算的预算类型。"),
                    F("IncludePreviousYear", "Whether to include the previous year.", "是否包含上一年度。"),
                    F("ExportBlankVoucherNumbers", "Whether to export blank voucher numbers.", "是否导出空凭证编号。"),
                    F("Comment", "A comment on the export.", "导出的备注。"),
                    F("VoucherDateSelection", "The voucher-date range to export.", "要导出的凭证日期范围。"),
                    F("VoucherSeriesSelection", "The voucher-series range to export.", "要导出的凭证系列范围。"),
                    F("VoucherNumberSelection", "The voucher-number range to export.", "要导出的凭证编号范围。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.Export.VoucherDateSelection",
                fields: [
                    F("FromDate", "The first date of the export range.", "导出范围的起始日期。"),
                    F("ToDate", "The last date of the export range.", "导出范围的结束日期。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.Export.VoucherNumberSelection",
                fields: [
                    F("FromNumber", "The first voucher number of the range.", "范围的起始凭证编号。"),
                    F("ToNumber", "The last voucher number of the range.", "范围的结束凭证编号。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.Export.VoucherSeriesSelection",
                fields: [
                    F("FromSeries", "The first voucher series of the range.", "范围的起始凭证系列。"),
                    F("ToSeries", "The last voucher series of the range.", "范围的结束凭证系列。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.FixedAssets.FixedAssetPartialQuantityInformation",
                fields: [
                    F("Quantity", "The quantity of the asset being retired or sold.", "被处置或出售的资产数量。"),
                    F("PartOfAcquisitionValue", "The part of the acquisition value being written off.", "被冲销的购置价值部分。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.Shared.AddCodingEntryAccount",
                fields: [
                    F("AccountId", "The account of the coding entry.", "记账条目的科目。"),
                    F("CodingEntryDescription", "The description of the coding entry.", "记账条目的描述。"),
                    F("CodingEntryElements", "The coding-dimension elements of the coding entry.", "记账条目的记账维度元素。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.Shared.AddCodingEntryElement",
                fields: [
                    F("CodingDimensionId", "The coding dimension of the element.", "元素的记账维度。"),
                    F("ReferencingEntityId", "The referenced entity of the element.", "元素所引用的实体。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.Vouchers.AddVoucherRow",
                fields: [
                    F("CodingEntry", "The coding entry (account and dimensions) of the voucher row.", "凭证行的记账条目（科目与维度）。"),
                    F("DebitInCompanyCurrency", "The debit amount in company currency; required when no credit is provided.", "按公司货币计价的借方金额；未提供贷方时必填。"),
                    F("CreditInCompanyCurrency", "The credit amount in company currency; required when no debit is provided.", "按公司货币计价的贷方金额；未提供借方时必填。"),
                    F("OrderNumber", "The order number of the voucher row.", "凭证行的订单号。"),
                    F("ExchangeRate", "The exchange rate of the voucher row.", "凭证行的汇率。"),
                    F("Quantity", "The quantity of the voucher row.", "凭证行的数量。"),
                    F("VatRateId", "The VAT rate of the voucher row.", "凭证行的增值税率。"),
                ]),
            Content(
                "Monitor.API.Accounting.SetOffDestination",
                fields: [
                    F("AccountsReceivableId", "The receivable to set off; required for customer invoices.", "要冲抵的应收账款；客户发票必填。"),
                    F("AccountsPayableId", "The payable to set off; required for supplier invoices.", "要冲抵的应付账款；供应商发票必填。"),
                    F("SetOffAmount", "The amount to set off.", "冲抵金额。"),
                    F("WriteOffCodeId", "The write-off code; required when the payment exceeds the invoice.", "核销代码；付款超过发票金额时必填。"),
                    F("InterestType", "The interest handling of the set-off (interest invoice, next regular invoice, none).", "冲抵的利息处理方式（利息发票、下次普通发票、无）。"),
                ]),
        ];
    }
}
