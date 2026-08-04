namespace MonitorErpMcp.Catalog.Content.Accounting
{
    // The using-static sits inside the namespace so the imported Content(...) builder binds before
    // the enclosing MonitorErpMcp.Catalog.Content namespace in simple-name lookup.
    using static MonitorErpMcp.Catalog.Content.ContentEntryFactory;
    using MonitorErpMcp.Catalog.Model;

    /// <summary>
    /// Hand-authored content for Accounting command records: bilingual descriptions and search aliases
    /// (en first, zh second), keyed by clrType and merged onto the structural catalog. Important
    /// request-input fields (mandatory, mandatoryWhen, enum, reference, input wrapper, dto) carry
    /// bilingual descriptions; self-evident fields are skipped.
    /// </summary>
    public static class Commands
    {
        /// <summary>Hand-authored entries for this family, merged by <c>clrType</c> onto the structural catalog.</summary>
        public static readonly ContentEntry[] Entries =
        [
            // ---- AccountsPayables ---------------------------------------------------
            Content(
                "Monitor.API.Accounting.Commands.AccountsPayables.AddBookingRows",
                "Add booking rows to an accounts payable.",
                "为应付账款添加记账行。",
                ["add booking rows"], ["添加记账行", "添加应付记账行"],
                fields: [
                    F("AccountsPayableId", "The accounts payable to add the booking rows to.", "要添加记账行的应付账款。"),
                    F("BookingRows", "The booking rows to add.", "要添加的记账行。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.AccountsPayables.AddDeliveryRows",
                "Add purchase-order delivery rows to an accounts payable.",
                "为应付账款添加采购订单交货行。",
                ["add delivery rows", "add delivery rows to ap"], ["添加交货行", "添加应付交货行"],
                fields: [
                    F("AccountsPayableId", "The accounts payable to add the delivery rows to.", "要添加交货行的应付账款。"),
                    F("PurchaseOrderDeliveryRowIds", "The purchase-order delivery rows to add.", "要添加的采购订单交货行。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.AccountsPayables.CancelAccountsPayable",
                "Cancel an accounts payable.",
                "取消应付账款。",
                ["cancel accounts payable"], ["取消应付账款", "作废应付账款"],
                fields: [
                    F("AccountsPayableId", "The accounts payable to cancel.", "要取消的应付账款。"),
                    F("CancelCommentText", "The cancel comment text.", "取消备注文本。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.AccountsPayables.ChangeInvoiceType",
                "Change the invoice type of an accounts payable.",
                "更改应付账款的发票类型。",
                ["change invoice type"], ["更改发票类型", "更改应付发票类型"],
                fields: [
                    F("AccountsPayableId", "The accounts payable to change the invoice type for.", "要更改发票类型的应付账款。"),
                    F("InvoiceType", "The new invoice type (standard, interest, on account...).", "新的发票类型（标准、利息、挂账等）。"),
                    F("IsCredit", "Whether the change turns the invoice into a credit note.", "是否将发票改为贷项通知单。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.AccountsPayables.ChangeSupplier",
                "Change the supplier of an accounts payable.",
                "更改应付账款的供应商。",
                ["change supplier"], ["更改供应商", "更改应付供应商"],
                fields: [
                    F("AccountsPayableId", "The accounts payable to change the supplier for.", "要更改供应商的应付账款。"),
                    F("SupplierId", "The new supplier.", "新的供应商。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.AccountsPayables.CreateAccountsPayable",
                "Create an accounts payable (supplier invoice).",
                "创建应付账款（供应商发票）。",
                ["create accounts payable", "create supplier invoice"], ["创建应付账款", "创建供应商发票", "新建应付"],
                fields: [
                    F("SupplierId", "The supplier of the invoice.", "发票的供应商。"),
                    F("SuppliersInvoiceNumber", "The supplier's invoice number.", "供应商的发票号。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.AccountsPayables.FinalBook",
                "Final-book an accounts payable with its final booking rows.",
                "以最终记账行为应付账款做最终记账。",
                ["final book", "final book accounts payable", "approve invoice"], ["最终记账", "应付账款最终记账", "批准发票"],
                fields: [
                    F("AccountsPayableId", "The accounts payable to final-book.", "要最终记账的应付账款。"),
                    F("FinalBookingRows", "The final booking rows of the final booking.", "最终记账的最终记账行。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.AccountsPayables.ReplaceEimDocument",
                "Replace the EIM document of an accounts payable.",
                "更换应付账款的 EIM 单据。",
                ["replace eim document", "replace invoice image"], ["更换EIM单据", "更换发票影像"],
                fields: [
                    F("AccountsPayableId", "The accounts payable to replace the document for.", "要更换单据的应付账款。"),
                    F("Data", "The new document data.", "新的单据数据。"),
                    F("DocumentTypeId", "The document type of the new document.", "新单据的单据类型。"),
                    F("EimDocumentId", "The EIM document to replace.", "要更换的 EIM 单据。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.AccountsPayables.SetAccountsPayableReferenceNumber",
                "Set the reference number of an accounts payable.",
                "设置应付账款的参考号。",
                ["set reference number"], ["设置参考号", "设置应付参考号"],
                fields: [
                    F("AccountsPayableId", "The accounts payable to set the reference number for.", "要设置参考号的应付账款。"),
                    F("ReferenceNumber", "The reference number.", "参考号。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.AccountsPayables.SetAccountsPayableVoucherDate",
                "Set the voucher date of an accounts payable.",
                "设置应付账款的凭证日期。",
                ["set voucher date"], ["设置凭证日期", "设置应付凭证日期"],
                fields: [
                    F("AccountsPayableId", "The accounts payable to set the voucher date for.", "要设置凭证日期的应付账款。"),
                    F("VoucherDate", "The voucher date.", "凭证日期。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.AccountsPayables.SetCurrency",
                "Set the currency of an accounts payable.",
                "设置应付账款的货币。",
                ["set currency"], ["设置货币", "设置应付货币"],
                fields: [
                    F("AccountsPayableId", "The accounts payable to set the currency for.", "要设置货币的应付账款。"),
                    F("CurrencyId", "The new currency.", "新的货币。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.AccountsPayables.SetDeliveryRowCoding",
                "Set the coding of a purchase-order delivery row on an accounts payable.",
                "设置应付账款上采购订单交货行的记账信息。",
                ["set delivery row coding", "set row coding"], ["设置交货行记账", "设置行记账"],
                fields: [
                    F("PurchaseOrderDeliveryRowId", "The purchase-order delivery row to set the coding for.", "要设置记账信息的采购订单交货行。"),
                    F("CodingEntryId", "The coding entry of the row.", "行的记账条目。"),
                    F("AccountId", "The account of the row.", "行的科目。"),
                    F("CodingEntryElements", "The coding-dimension elements of the coding entry.", "记账条目的记账维度元素。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.AccountsPayables.SetDueDate",
                "Set the due date of an accounts payable.",
                "设置应付账款的到期日。",
                ["set due date"], ["设置到期日", "设置应付到期日"],
                fields: [
                    F("AccountsPayableId", "The accounts payable to set the due date for.", "要设置到期日的应付账款。"),
                    F("DueDate", "The due date.", "到期日。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.AccountsPayables.SetExchangeRate",
                "Set the exchange rate of an accounts payable.",
                "设置应付账款的汇率。",
                ["set exchange rate"], ["设置汇率", "设置应付汇率"],
                fields: [
                    F("AccountsPayableId", "The accounts payable to set the exchange rate for.", "要设置汇率的应付账款。"),
                    F("ExchangeRate", "The exchange rate.", "汇率。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.AccountsPayables.SetInvoiceAmount",
                "Set the invoice amount of an accounts payable.",
                "设置应付账款的发票金额。",
                ["set invoice amount"], ["设置发票金额", "设置应付发票金额"],
                fields: [
                    F("AccountsPayableId", "The accounts payable to set the invoice amount for.", "要设置发票金额的应付账款。"),
                    F("InvoiceAmount", "The invoice amount.", "发票金额。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.AccountsPayables.SetInvoiceDate",
                "Set the invoice date of an accounts payable.",
                "设置应付账款的发票日期。",
                ["set invoice date"], ["设置发票日期", "设置应付发票日期"],
                fields: [
                    F("AccountsPayableId", "The accounts payable to set the invoice date for.", "要设置发票日期的应付账款。"),
                    F("InvoiceDate", "The invoice date.", "发票日期。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.AccountsPayables.SetOCRNumber",
                "Set the OCR number of an accounts payable.",
                "设置应付账款的 OCR 号码。",
                ["set ocr number"], ["设置OCR号码", "设置应付OCR"],
                fields: [
                    F("AccountsPayableId", "The accounts payable to set the OCR number for.", "要设置 OCR 号码的应付账款。"),
                    F("OCRNumber", "The OCR number.", "OCR 号码。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.AccountsPayables.SetPaymentTerm",
                "Set the payment term of an accounts payable.",
                "设置应付账款的付款条款。",
                ["set payment term"], ["设置付款条款", "设置应付付款条款"],
                fields: [
                    F("AccountsPayableId", "The accounts payable to set the payment term for.", "要设置付款条款的应付账款。"),
                    F("PaymentTermId", "The new payment term.", "新的付款条款。"),
                    F("RefreshPaymentTermDays", "Whether to recompute the payment-term days from the term.", "是否按付款条款重新计算付款天数。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.AccountsPayables.SetVatGroup",
                "Set the VAT group of an accounts payable.",
                "设置应付账款的增值税组。",
                ["set vat group"], ["设置增值税组", "设置应付增值税组"],
                fields: [
                    F("AccountsPayableId", "The accounts payable to set the VAT group for.", "要设置增值税组的应付账款。"),
                    F("VatGroupId", "The new VAT group.", "新的增值税组。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.AccountsPayables.SetWithholdingTaxAmount",
                "Set the withholding-tax amount of an accounts payable.",
                "设置应付账款的预扣税金额。",
                ["set withholding tax", "set withhold tax amount"], ["设置预扣税", "设置预扣税金额"],
                fields: [
                    F("AccountsPayableId", "The accounts payable to set the withholding-tax amount for.", "要设置预扣税金额的应付账款。"),
                    F("WithholdTaxAmount", "The withholding-tax amount.", "预扣税金额。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.AccountsPayables.SetWithholdingTaxInCompanyCurrencyAmount",
                "Set the withholding-tax amount in company currency of an accounts payable.",
                "设置应付账款按公司货币计价的预扣税金额。",
                ["set withholding tax company currency", "set withhold tax amount company"], ["设置公司货币预扣税", "设置公司货币预扣税金额"],
                fields: [
                    F("AccountsPayableId", "The accounts payable to set the amount for.", "要设置金额的应付账款。"),
                    F("WithholdTaxAmountInCompanyCurrency", "The withholding-tax amount in company currency.", "按公司货币计价的预扣税金额。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.AccountsPayables.UpdateBookingRows",
                "Update the booking rows of an accounts payable.",
                "更新应付账款的记账行。",
                ["update booking rows"], ["更新记账行", "更新应付记账行"],
                fields: [
                    F("AccountsPayableId", "The accounts payable whose booking rows to update.", "要更新记账行的应付账款。"),
                    F("BookingRows", "The updated booking rows.", "更新后的记账行。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.AccountsPayables.UpdateDeliveryRow",
                "Update a delivery row of an accounts payable.",
                "更新应付账款的交货行。",
                ["update delivery row"], ["更新交货行", "更新应付交货行"],
                fields: [
                    F("PurchaseOrderDeliveryRowId", "The purchase-order delivery row to update.", "要更新的采购订单交货行。"),
                    F("Price", "The price of the row.", "行的价格。"),
                    F("SetupPrice", "The setup price of the row.", "行的准备价格。"),
                    F("VatRateId", "The VAT rate of the row.", "行的增值税率。"),
                    F("Amount", "The amount of the row.", "行的金额。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.AccountsPayables.UpdateFinalBookingRows",
                "Update the final booking rows of an accounts payable.",
                "更新应付账款的最终记账行。",
                ["update final booking rows", "update final rows"], ["更新最终记账行", "更新最终行"],
                fields: [
                    F("AccountsPayableId", "The accounts payable whose final booking rows to update.", "要更新最终记账行的应付账款。"),
                    F("BookingRows", "The updated booking rows.", "更新后的记账行。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.AccountsPayables.UpdateVatAmount",
                "Update the VAT amount of an accounts payable.",
                "更新应付账款的增值税金额。",
                ["update vat amount", "set vat amount"], ["更新增值税金额", "设置增值税金额"],
                fields: [
                    F("AccountsPayableId", "The accounts payable to update the VAT amount for.", "要更新增值税金额的应付账款。"),
                    F("VatAmount", "The VAT amount.", "增值税金额。"),
                ]),

            // ---- AccountsReceivables ------------------------------------------------
            Content(
                "Monitor.API.Accounting.Commands.AccountsReceivables.CreateAccountsReceivable",
                "Create an accounts receivable (customer invoice).",
                "创建应收账款（客户发票）。",
                ["create accounts receivable", "create customer invoice"], ["创建应收账款", "创建客户发票", "新建应收"],
                fields: [
                    F("InvoiceNumber", "The unique invoice number of the receivable.", "应收账款的唯一发票号。"),
                    F("BusinessContactId", "The customer of the receivable.", "应收账款的客户。"),
                    F("InvoiceAmount", "The invoice amount.", "发票金额。"),
                    F("VatGroupId", "The VAT group of the receivable.", "应收账款的增值税组。"),
                    F("CustomerAccountGroupId", "The customer account group of the receivable.", "应收账款的客户科目组。"),
                    F("CurrencyId", "The currency of the receivable.", "应收账款的货币。"),
                    F("BookingRows", "The booking rows of the receivable.", "应收账款的记账行。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.AccountsReceivables.CreateIncomingPayment",
                "Create an incoming payment against a receivable (or on account).",
                "创建针对应收账款（或预收）的收款。",
                ["create incoming payment", "create payment", "create receipt"], ["创建收款", "创建付款", "登记收款"],
                fields: [
                    F("InvoiceId", "The invoice to pay; required when paying an invoice.", "要付款的发票；支付发票时必填。"),
                    F("CustomerId", "The customer paying; required for an on-account payment.", "付款的客户；预收付款时必填。"),
                    F("PaymentMethodId", "The payment method of the payment.", "付款的付款方式。"),
                    F("PaidAmount", "The paid amount.", "实付金额。"),
                    F("WriteOffCodeId", "The write-off code; required when the payment exceeds the invoice.", "核销代码；付款超过发票金额时必填。"),
                    F("InterestType", "The interest handling of the payment (interest invoice, next regular invoice, none).", "付款的利息处理方式（利息发票、下次普通发票、无）。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.AccountsReceivables.CreateMultipleIncomingPayments",
                "Create multiple incoming payments in one call.",
                "一次创建多笔收款。",
                ["create multiple payments", "create multiple incoming payments", "batch payments"], ["批量创建收款", "批量登记收款"],
                fields: [
                    F("IncomingPayments", "The incoming payments to create.", "要创建的收款。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.AccountsReceivables.CreateSetOffPayment",
                "Create a set-off payment that settles receivables against payables.",
                "创建冲抵付款，将应收账款与应付账款相互冲抵。",
                ["create set off payment", "set off payment", "create setoff"], ["创建冲抵付款", "冲抵付款", "互抵付款"],
                fields: [
                    F("InvoiceId", "The receivable to set off.", "要冲抵的应收账款。"),
                    F("InterestType", "The interest handling of the payment (interest invoice, next regular invoice, none).", "付款的利息处理方式（利息发票、下次普通发票、无）。"),
                    F("SetOffDestinations", "The payables (and amounts) to set off against.", "冲抵的应付账款（及金额）。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.AccountsReceivables.SetPropertiesAccountsReceivable",
                "Set the properties of an accounts receivable (China VAT / CTC fields).",
                "设置应收账款的属性（中国增值税 / CTC 字段）。",
                ["set properties receivable", "set ctc reporting"], ["设置应收账款属性", "设置应收属性", "设置CTC上报"],
                fields: [
                    F("AccountsReceivableId", "The accounts receivable to update.", "要更新的应收账款。"),
                    F("ChineseVatInvoiceNumber", "The Chinese VAT invoice number.", "中国增值税发票号。"),
                    F("ChineseVatInvoiceDate", "The Chinese VAT invoice date.", "中国增值税发票日期。"),
                    F("DueDate", "The due date of the receivable.", "应收账款的到期日。"),
                    F("CTCReportingInvoiceNumber", "The CTC reporting invoice number.", "CTC 上报发票号。"),
                    F("CTCReportingReasonForRejection", "The reason for rejection of the CTC reporting.", "CTC 上报被拒绝的原因。"),
                    F("CTCReportingStatus", "The CTC reporting status (not sent, sent for approval, approved...).", "CTC 上报状态（未发送、待审批、已批准等）。"),
                    F("CTCReportingInvoiceDate", "The CTC reporting invoice date.", "CTC 上报发票日期。"),
                    F("CTCReportingIdentifier", "The CTC reporting identifier.", "CTC 上报标识。"),
                    F("CTCReportingElectronicConfirmationURL", "The URL of the CTC electronic confirmation.", "CTC 电子确认单的 URL。"),
                    F("CTCReportingElectronicConfirmationNumber", "The number of the CTC electronic confirmation.", "CTC 电子确认单的编号。"),
                ]),

            // ---- AccrualAccountings ------------------------------------------------
            Content(
                "Monitor.API.Accounting.Commands.AccrualAccountings.CreateAccrualAccounting",
                "Create an accrual accounting that spreads an amount over periods.",
                "创建应计会计，将金额在各期间内分摊。",
                ["create accrual accounting", "create accrual", "create prepayment"], ["创建应计会计", "创建待摊", "创建预提"],
                fields: [
                    F("AccountsPayableId", "The accounts payable the accrual relates to.", "应计所关联的应付账款。"),
                    F("AccrualAccountingType", "The type of the accrual (accounts-payable booking row, voucher row, reverse voucher...).", "应计的类型（应付账款记账行、凭证行、冲销凭证等）。"),
                    F("VoucherRowId", "The voucher row the accrual is based on.", "应计所依据的凭证行。"),
                    F("BookingRowId", "The booking row the accrual is based on.", "应计所依据的记账行。"),
                    F("StartDate", "The start date of the accrual.", "应计的开始日期。"),
                    F("Periods", "The period amounts of the accrual.", "应计的各期间金额。"),
                    F("BookingRows", "The booking rows of the accrual.", "应计的记账行。"),
                ]),

            // ---- AllocationKeys -----------------------------------------------------
            Content(
                "Monitor.API.Accounting.Commands.AllocationKeys.CreateAllocationKey",
                "Create an allocation key.",
                "创建分摊键。",
                ["create allocation key", "create allocation"], ["创建分摊键", "新建分摊键"],
                fields: [
                    F("Number", "The unique number of the allocation key.", "分摊键的唯一编号。"),
                    F("Name", "The name of the allocation key.", "分摊键的名称。"),
                    F("ResultRows", "The result rows of the allocation key.", "分摊键的结果行。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.AllocationKeys.RemoveAllocationKey",
                "Remove an allocation key.",
                "删除分摊键。",
                ["remove allocation key", "delete allocation key"], ["删除分摊键", "移除分摊键"],
                fields: [
                    F("Id", "The allocation key to remove.", "要删除的分摊键。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.AllocationKeys.UpdateAllocationKey",
                "Update an allocation key.",
                "更新分摊键。",
                ["update allocation key", "update allocation"], ["更新分摊键", "修改分摊键"],
                fields: [
                    F("Id", "The allocation key to update.", "要更新的分摊键。"),
                    F("Name", "The name of the allocation key.", "分摊键的名称。"),
                    F("ResultRows", "The result rows of the allocation key.", "分摊键的结果行。"),
                ]),

            // ---- Export -------------------------------------------------------------
            Content(
                "Monitor.API.Accounting.Commands.Export.ExportSie4E",
                "Export the accounting to the SIE4 E-format file.",
                "将会计数据导出为 SIE4 E 格式文件。",
                ["export sie4e", "sie4 e", "export sie"], ["导出SIE4E", "导出SIE", "SIE4 E导出"],
                fields: [
                    F("Settings", "The export settings (year, series, number range).", "导出设置（年度、系列、编号范围）。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.Export.ExportSie4I",
                "Export the accounting to the SIE4 I-format file.",
                "将会计数据导出为 SIE4 I 格式文件。",
                ["export sie4i", "sie4 i", "export sie"], ["导出SIE4I", "导出SIE", "SIE4 I导出"],
                fields: [
                    F("Settings", "The export settings (year, series, number range).", "导出设置（年度、系列、编号范围）。"),
                ]),

            // ---- FixedAssets --------------------------------------------------------
            Content(
                "Monitor.API.Accounting.Commands.FixedAssets.CreateFixedAsset",
                "Create a fixed asset.",
                "创建固定资产。",
                ["create fixed asset", "create asset"], ["创建固定资产", "新建固定资产"],
                fields: [
                    F("Code", "The unique code of the fixed asset.", "固定资产的唯一代码。"),
                    F("Description", "The description of the fixed asset.", "固定资产的描述。"),
                    F("GroupId", "The fixed-asset group of the asset.", "资产的固定资产组。"),
                    F("AccountsPayableId", "The accounts payable the asset was acquired through.", "购置该资产的应付账款。"),
                    F("VoucherId", "The voucher of the asset's acquisition.", "资产购置的凭证。"),
                    F("SupplierId", "The supplier the asset was bought from.", "出售该资产的供应商。"),
                    F("WorkCenterId", "The work center the asset is used at.", "使用该资产的工作中心。"),
                    F("DepartmentId", "The department the asset belongs to.", "资产所属的部门。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.FixedAssets.MakeExtraDepreciation",
                "Make an extra (manual) depreciation on a fixed asset.",
                "对固定资产做一笔额外（手动）折旧。",
                ["make extra depreciation", "extra depreciation", "manual depreciation"], ["额外折旧", "手动折旧", "追加折旧"],
                fields: [
                    F("FixedAssetId", "The fixed asset to depreciate.", "要折旧的固定资产。"),
                    F("DepreciationAmount", "The depreciation amount; required when NewResidualValue is not set.", "折旧金额；未设置新残值时必填。"),
                    F("NewResidualValue", "The new residual value; required when DepreciationAmount is not set.", "新的残值；未设置折旧金额时必填。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.FixedAssets.RetireFixedAsset",
                "Retire (scrap) a fixed asset.",
                "处置（报废）固定资产。",
                ["retire fixed asset", "scrap asset", "write off asset"], ["处置固定资产", "报废资产", "资产报废"],
                fields: [
                    F("FixedAssetId", "The fixed asset to retire.", "要处置的固定资产。"),
                    F("Date", "The retirement date.", "处置日期。"),
                    F("PartialQuantityInformation", "The partial-quantity information of the retirement, when only part of the asset is retired.", "部分处置时的数量信息（仅处置部分资产时）。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.FixedAssets.SellFixedAsset",
                "Sell a fixed asset.",
                "出售固定资产。",
                ["sell fixed asset", "sell asset"], ["出售固定资产", "出售资产"],
                fields: [
                    F("FixedAssetId", "The fixed asset to sell.", "要出售的固定资产。"),
                    F("Date", "The sale date.", "出售日期。"),
                    F("SalesPriceInCompanyCurrency", "The sales price in company currency.", "按公司货币计价的销售价格。"),
                    F("PartialQuantityInformation", "The partial-quantity information of the sale, when only part of the asset is sold.", "部分出售时的数量信息（仅出售部分资产时）。"),
                    F("AccountsReceivableId", "The accounts receivable created for the sale, if invoiced.", "出售开票时产生的应收账款（如有）。"),
                    F("CustomerId", "The customer the asset is sold to.", "购买该资产的客户。"),
                ]),

            // ---- Vouchers -----------------------------------------------------------
            Content(
                "Monitor.API.Accounting.Commands.Vouchers.CreateVoucher",
                "Create a voucher with its voucher rows.",
                "创建凭证及其凭证行。",
                ["create voucher", "create voucher entry", "book voucher"], ["创建凭证", "新建凭证", "记账凭证"],
                fields: [
                    F("SeriesId", "The voucher series of the voucher.", "凭证的凭证系列。"),
                    F("Comment", "The comment of the voucher.", "凭证的备注。"),
                    F("VoucherRows", "The rows of the voucher.", "凭证的行。"),
                ]),
            Content(
                "Monitor.API.Accounting.Commands.Vouchers.SetPropertiesVoucher",
                "Set the properties of a voucher.",
                "设置凭证的属性。",
                ["set voucher properties", "update voucher"], ["设置凭证属性", "更新凭证"],
                fields: [
                    F("Id", "The voucher to update.", "要更新的凭证。"),
                    F("VoucherDate", "The voucher date.", "凭证日期。"),
                    F("Text", "The text of the voucher.", "凭证的文本。"),
                    F("CNSeries", "The credit-note series of the voucher.", "凭证的贷项通知单系列。"),
                    F("CNNumber", "The credit-note number of the voucher.", "凭证的贷项通知单编号。"),
                ]),
        ];
    }
}
