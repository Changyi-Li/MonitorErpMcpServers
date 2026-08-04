namespace MonitorErpMcp.Catalog.Content.Accounting
{
    // The using-static sits inside the namespace so the imported Content(...) builder binds before
    // the enclosing MonitorErpMcp.Catalog.Content namespace in simple-name lookup.
    using static MonitorErpMcp.Catalog.Content.ContentEntryFactory;
    using MonitorErpMcp.Catalog.Model;

    /// <summary>
    /// Hand-authored content for Accounting query records: bilingual descriptions and search aliases
    /// (en first, zh second), keyed by clrType and merged onto the structural catalog. Important
    /// fields (enum, reference, expandable, unique) carry bilingual descriptions; self-evident
    /// fields such as a bare Id are skipped per the coverage tiers.
    /// </summary>
    public static class Queries
    {
        /// <summary>Hand-authored entries for this family, merged by <c>clrType</c> onto the structural catalog.</summary>
        public static readonly ContentEntry[] Entries =
        [
            // ---- Accounts ------------------------------------------------------------
            Content(
                "Monitor.API.Accounting.Account",
                "A chart-of-accounts entry — an account with a number and a type, the base unit of bookkeeping.",
                "会计科目 —— 带有编号与类型的科目，是记账的基本单位。",
                ["account", "chart of accounts", "gl account", "ledger account"], ["科目", "会计科目", "总账科目"],
                fields: [
                    F("Type", "The type of the account (asset, liability, equity, income, cost, internal...).", "科目的类型（资产、负债、权益、收入、成本、内部等）。"),
                ]),

            // ---- AccountingBudgets --------------------------------------------------
            Content(
                "Monitor.API.Accounting.AccountingBudget",
                "An accounting budget — planned amounts per account-year setting, linked to a balance, chart, and budget type.",
                "会计预算 —— 按科目年度设置的计划金额，关联余额、预算图与预算类型。",
                ["accounting budget", "budget", "planned amount"], ["会计预算", "预算", "计划金额"],
                fields: [
                    F("AccountYearSettingId", "The account-year setting the budget belongs to.", "预算所属的科目年度设置。"),
                    F("AccountingYearId", "The accounting year of the budget.", "预算的会计年度。"),
                    F("BalanceId", "The balance the budget applies to.", "预算适用的余额。"),
                    F("BudgetChartId", "The budget chart of the budget.", "预算的预算图。"),
                    F("BudgetTypeId", "The budget type of the budget.", "预算的预算类型。"),
                    F("CodingEntryId", "The coding entry of the budget.", "预算的记账条目。"),
                    F("CodingEntry", "The coding entry of the budget.", "预算的记账条目。"),
                    F("Periods", "The period amounts of the budget.", "预算的各期间金额。"),
                ]),
            Content(
                "Monitor.API.Accounting.AccountingBudgetPeriod",
                "A period amount within an accounting budget.",
                "会计预算中的一个期间金额。",
                ["budget period", "accounting budget period"], ["预算期间", "预算周期"],
                fields: [
                    F("BudgetId", "The accounting budget the period belongs to.", "该期间所属的会计预算。"),
                    F("PeriodId", "The accounting-year period of the budget amount.", "预算金额所属的会计期间。"),
                ]),
            Content(
                "Monitor.API.Accounting.AccountingBudgetType",
                "A budget type used to classify accounting budgets.",
                "用于对会计预算进行分类的预算类型。",
                ["budget type", "accounting budget type"], ["预算类型", "会计预算类型"],
                fields: [
                    F("Number", "The unique number of the budget type.", "预算类型的唯一编号。"),
                ]),
            Content(
                "Monitor.API.Accounting.BudgetChart",
                "A budget chart — a set of accounts whose planned amounts form a budget.",
                "预算图 —— 一组科目，其计划金额构成预算。",
                ["budget chart", "chart of budget"], ["预算图", "预算表"],
                fields: [
                    F("Code", "The unique code of the budget chart.", "预算图的唯一代码。"),
                ]),

            // ---- AccountingYears ----------------------------------------------------
            Content(
                "Monitor.API.Accounting.AccountingYear",
                "An accounting (fiscal) year with its periods and bookkeeping status.",
                "会计（财政）年度，含期间与记账状态。",
                ["accounting year", "fiscal year", "financial year"], ["会计年度", "财政年度", "财务年度"],
                fields: [
                    F("Status", "The status of the accounting year (active, previous, historical, future...).", "会计年度的状态（当前、上一年、历史、未来等）。"),
                ]),
            Content(
                "Monitor.API.Accounting.AccountingYearPeriod",
                "A period within an accounting year, with open/closed bookkeeping state.",
                "会计年度内的一个期间，含开账/关账状态。",
                ["accounting year period", "fiscal period", "accounting period"], ["会计期间", "财政期间", "账期"],
                fields: [
                    F("Status", "The status of the period (open, closed, locked).", "期间的状态（开启、关闭、锁定）。"),
                    F("AccountingYearId", "The accounting year the period belongs to.", "该期间所属的会计年度。"),
                    F("AccountingYear", "The accounting year the period belongs to.", "该期间所属的会计年度。"),
                ]),

            // ---- AccountsPayables ---------------------------------------------------
            Content(
                "Monitor.API.Accounting.AccountsPayable",
                "A supplier invoice / accounts-payable record — what is owed to a supplier, with its amounts, status, and payment terms.",
                "供应商发票/应付账款记录 —— 应付供应商的款项，含金额、状态与付款条款。",
                ["accounts payable", "supplier invoice", "payable"], ["应付账款", "供应商发票", "应付"],
                fields: [
                    F("CancelCommentId", "The cancel comment of the accounts payable.", "应付账款的取消备注。"),
                    F("CancelComment", "The cancel comment of the accounts payable.", "应付账款的取消备注。"),
                    F("PaymentMethodId", "The payment method of the accounts payable.", "应付账款的付款方式。"),
                    F("LanguageId", "The language of the accounts payable.", "应付账款的语言。"),
                    F("Language", "The language of the accounts payable.", "应付账款的语言。"),
                    F("InvoiceType", "The invoice type of the supplier invoice (standard, interest, on account...).", "供应商发票的类型（标准、利息、挂账等）。"),
                    F("PurchaseOrderId", "The purchase order the accounts payable is based on.", "应付账款所依据的采购订单。"),
                    F("WarehouseId", "The warehouse of the accounts payable.", "应付账款的仓库。"),
                    F("SupplierAccountGroupId", "The supplier account group of the accounts payable.", "应付账款的供应商科目组。"),
                    F("CountryId", "The country of the supplier invoice.", "供应商发票的国家。"),
                    F("Status", "The status of the accounts payable (registered, preliminary, final, cancelled).", "应付账款的状态（已登记、临时、最终、已取消）。"),
                    F("BlockMessage", "The block message of the accounts payable.", "应付账款的封锁消息。"),
                    F("CreditedAccountsPayableId", "The accounts payable this record is a credit note against.", "该应付账款所冲抵的应付账款。"),
                    F("BlockedById", "The user who blocked the accounts payable.", "封锁该应付账款的用户。"),
                    F("BlockedBy", "The user who blocked the accounts payable.", "封锁该应付账款的用户。"),
                    F("BlockedStatus", "The block status of the accounts payable (none, message, blocked).", "应付账款的封锁状态（无、消息、封锁）。"),
                    F("BlockedContextType", "The context in which the accounts payable is blocked (none, payment).", "应付账款被封锁的上下文（无、付款）。"),
                    F("EimInvoiceStatus", "The EIM invoice status (none, hold, for authorization, approved, rejected, final booked).", "EIM 发票状态（无、保留、待授权、已批准、已拒绝、已最终记账）。"),
                    F("InvoiceAmountCurrencyId", "The currency of the invoice amount.", "发票金额的货币。"),
                    F("InvoiceAmountInCompanyCurrencyCurrencyId", "The currency of the invoice amount in company currency.", "按公司货币计价的发票金额的货币。"),
                    F("VatAmountCurrencyId", "The currency of the VAT amount.", "增值税金额的货币。"),
                    F("VatAmountInCompanyCurrencyCurrencyId", "The currency of the VAT amount in company currency.", "按公司货币计价的增值税金额的货币。"),
                    F("RestAmountCurrencyId", "The currency of the rest (outstanding) amount.", "剩余（未付）金额的货币。"),
                    F("RestAmountInCompanyCurrencyCurrencyId", "The currency of the rest amount in company currency.", "按公司货币计价的剩余金额的货币。"),
                    F("OrderedRestAmountCurrencyId", "The currency of the ordered rest amount.", "已订购剩余金额的货币。"),
                    F("CurrencyId", "The currency of the accounts payable.", "应付账款的货币。"),
                    F("CommentId", "The comment of the accounts payable.", "应付账款的备注。"),
                    F("Comment", "The comment of the accounts payable.", "应付账款的备注。"),
                    F("VatGroupId", "The VAT group of the accounts payable.", "应付账款的增值税组。"),
                    F("PaymentTermId", "The payment term of the accounts payable.", "应付账款的付款条款。"),
                    F("PaymentTerm", "The payment term of the accounts payable.", "应付账款的付款条款。"),
                    F("BusinessContactId", "The supplier of the accounts payable.", "应付账款的供应商。"),
                    F("CurrencyExchangeTypeId", "The exchange-rate type of the accounts payable.", "应付账款的汇率类型。"),
                    F("Payments", "The outgoing payments against the accounts payable.", "针对该应付账款的付款。"),
                    F("WithholdTaxAmountCurrencyId", "The currency of the withholding-tax amount.", "预扣税金额的货币。"),
                    F("WithholdTaxAmountInCompanyCurrencyCurrencyId", "The currency of the withholding-tax amount in company currency.", "按公司货币计价的预扣税金额的货币。"),
                ]),
            Content(
                "Monitor.API.Accounting.AccountsPayableCashDiscountLevel",
                "A cash-discount level of an accounts-payable record — a discount rate and date.",
                "应付账款记录的现金折扣级别 —— 折扣率与折扣日期。",
                ["cash discount level", "payable cash discount"], ["现金折扣级别", "应付账款现金折扣"],
                fields: [
                    F("ParentId", "The accounts payable the discount level belongs to.", "折扣级别所属的应付账款。"),
                ]),

            // ---- AccountsReceivables ------------------------------------------------
            Content(
                "Monitor.API.Accounting.AccountsReceivable",
                "A customer invoice / accounts-receivable record — what a customer owes, with its amounts, status, and collection details.",
                "客户发票/应收账款记录 —— 客户应付的款项，含金额、状态与收款信息。",
                ["accounts receivable", "customer invoice", "receivable"], ["应收账款", "客户发票", "应收"],
                fields: [
                    F("Booking", "The booking (journal entry) of the receivable.", "应收账款的记账（分录）。"),
                    F("InvoiceType", "The invoice type of the receivable (standard, internal, cash receipt, interest...).", "应收账款的发票类型（标准、内部、现金收款、利息等）。"),
                    F("InterestType", "The interest handling of the receivable (interest invoice, next regular invoice, none).", "应收账款的利息处理方式（利息发票、下次普通发票、无）。"),
                    F("PartialInvoiceType", "The partial-invoice type of the receivable (in advance, delivery, in arrears...).", "应收账款的分期发票类型（预付、交货、后付等）。"),
                    F("CustomerAccountGroup", "The customer account group of the receivable.", "应收账款的客户科目组。"),
                    F("Status", "The status of the receivable (approved, printed, cancelled).", "应收账款的状态（已批准、已打印、已取消）。"),
                    F("CancelComment", "The cancel comment of the receivable.", "应收账款的取消备注。"),
                    F("CancelBooking", "The booking that cancels the receivable.", "取消该应收账款的记账。"),
                    F("InvoiceNumber", "The unique invoice number of the receivable.", "应收账款的唯一发票号。"),
                    F("Comment", "The comment of the receivable.", "应收账款的备注。"),
                    F("CurrencyExchangeTypeId", "The exchange-rate type of the receivable.", "应收账款的汇率类型。"),
                    F("CTCReportingStatus", "The China tax-control (CTC) reporting status (not sent, sent for approval, approved...).", "中国税务控制（CTC）上报状态（未发送、待审批、已批准等）。"),
                ]),
            Content(
                "Monitor.API.Accounting.AccountsReceivableCashDiscountLevel",
                "A cash-discount level of an accounts-receivable record — a discount rate and date.",
                "应收账款记录的现金折扣级别 —— 折扣率与折扣日期。",
                ["cash discount level", "receivable cash discount"], ["现金折扣级别", "应收账款现金折扣"],
                fields: [
                    F("ParentId", "The accounts receivable the discount level belongs to.", "折扣级别所属的应收账款。"),
                ]),

            // ---- AccountYearSettings ------------------------------------------------
            Content(
                "Monitor.API.Accounting.AccountYearSetting",
                "Per-account settings for an accounting year — VAT type, debit/credit direction, and coding dimensions.",
                "科目在某会计年度的设置 —— 增值税类型、借贷方向与记账维度。",
                ["account year setting", "account setting", "year setting"], ["科目年度设置", "科目设置", "年度设置"],
                fields: [
                    F("DebitOrCreditType", "The debit/credit direction of the account (debit, credit).", "科目的借贷方向（借方、贷方）。"),
                    F("VatType", "The VAT type of the account (none, sales, purchase, input VAT, output VAT).", "科目的增值税类型（无、销售、采购、进项税、销项税）。"),
                    F("Account", "The account the setting belongs to.", "设置所属的科目。"),
                    F("AccountCodingDimensions", "The coding-dimension availabilities of the account.", "科目的记账维度可用性。"),
                ]),
            Content(
                "Monitor.API.Accounting.AccountYearSettingCodingDimensionAvailability",
                "Whether a coding dimension is allowed, mandatory, or disallowed for an account-year setting.",
                "科目年度设置对某个记账维度的可用性（允许、必填或禁止）。",
                ["coding dimension availability", "dimension availability", "account dimension"], ["记账维度可用性", "维度可用性", "科目维度"],
                fields: [
                    F("CodingDimension", "The coding dimension the availability applies to.", "可用性所适用的记账维度。"),
                    F("CodingDimensionAvailability", "The availability of the dimension (not allowed, allowed, mandatory).", "维度的可用性（禁止、允许、必填）。"),
                ]),

            // ---- AccrualAccountings ------------------------------------------------
            Content(
                "Monitor.API.Accounting.AccrualAccounting",
                "An accrual accounting record that spreads a booked cost or income over periods.",
                "应计会计记录 —— 将已记账的成本或收入在各期间内分摊。",
                ["accrual accounting", "accrual", "prepayment", "periodization"], ["应计会计", "待摊", "预提", "期间分摊"],
                fields: [
                    F("Type", "The type of the accrual (accounts-payable booking row, voucher row, reverse voucher, free booking...).", "应计的类型（应付账款记账行、凭证行、冲销凭证、自由记账等）。"),
                    F("Comment", "The comment of the accrual accounting.", "应计会计的备注。"),
                    F("CancelComment", "The cancel comment of the accrual accounting.", "应计会计的取消备注。"),
                    F("Rows", "The period rows of the accrual accounting.", "应计会计的各期间行。"),
                    F("BookingRows", "The booking rows of the accrual accounting.", "应计会计的记账行。"),
                    F("AccountsPayableBookingRow", "The accounts-payable booking row the accrual originates from.", "应计所源自的应付账款记账行。"),
                ]),
            Content(
                "Monitor.API.Accounting.AccrualAccountingLedger",
                "A ledger entry created when an accrual accounting is released.",
                "应计会计释放时产生的分类账条目。",
                ["accrual accounting ledger", "accrual ledger"], ["应计分类账", "应计会计分类账"]),
            Content(
                "Monitor.API.Accounting.AccrualAccountingRow",
                "A period row of an accrual accounting — the amount released for one period.",
                "应计会计的期间行 —— 在某个期间释放的金额。",
                ["accrual accounting row", "accrual row", "accrual period"], ["应计行", "分摊行", "应计期间行"],
                fields: [
                    F("Period", "The accounting-year period the row releases to.", "该行释放到的会计期间。"),
                    F("Ledger", "The accrual-accounting ledger entry of the row.", "该行的应计分类账条目。"),
                    F("BookingRows", "The booking rows of the row.", "该行的记账行。"),
                ]),

            // ---- AllocationKeys -----------------------------------------------------
            Content(
                "Monitor.API.Accounting.AllocationKey",
                "An allocation key that distributes a cost across accounts and coding dimensions by percentage.",
                "分摊键 —— 按百分比将成本分摊到科目与记账维度。",
                ["allocation key", "allocation", "distribution key"], ["分摊键", "分摊关键", "分配键"],
                fields: [
                    F("Number", "The unique number of the allocation key.", "分摊键的唯一编号。"),
                    F("AllocationKeyResultRow", "The result rows of the allocation key.", "分摊键的结果行。"),
                ]),
            Content(
                "Monitor.API.Accounting.AllocationKeyResultRow",
                "A result row of an allocation key — one coding entry and percentage.",
                "分摊键的结果行 —— 一个记账条目与分摊百分比。",
                ["allocation result row", "allocation row", "allocation percentage"], ["分摊结果行", "分摊行", "分摊百分比"],
                fields: [
                    F("AllocationKeyId", "The allocation key the result row belongs to.", "结果行所属的分摊键。"),
                    F("CodingEntryId", "The coding entry the amount is allocated to.", "金额分摊到的记账条目。"),
                ]),

            // ---- AutoAllocations ----------------------------------------------------
            Content(
                "Monitor.API.Accounting.AutoAllocation",
                "An automatic allocation rule that runs an allocation key on booking automatically.",
                "自动分摊规则 —— 记账时自动执行分摊键。",
                ["auto allocation", "automatic allocation", "auto coding"], ["自动分摊", "自动分配", "自动记账"],
                fields: [
                    F("Number", "The unique number of the auto-allocation rule.", "自动分摊规则的唯一编号。"),
                    F("Type", "The type of the rule (direct, period balance, accumulated balance).", "规则的类型（直接、期间余额、累计余额）。"),
                    F("AllocationKeyId", "The allocation key the rule runs.", "规则执行的分摊键。"),
                ]),

            // ---- Balances -----------------------------------------------------------
            Content(
                "Monitor.API.Accounting.Balance",
                "An account balance for an accounting year — the accumulated debit/credit position.",
                "科目在会计年度的余额 —— 累计的借贷余额。",
                ["balance", "account balance", "balance row"], ["余额", "科目余额", "余额行"],
                fields: [
                    F("AccountingYearId", "The accounting year of the balance.", "余额的会计年度。"),
                    F("CodingEntryId", "The coding entry of the balance.", "余额的记账条目。"),
                    F("OpeningBalanceId", "The opening balance the balance derives from.", "余额所源自的期初余额。"),
                ]),
            Content(
                "Monitor.API.Accounting.BalanceRowDay",
                "A daily balance row — the debit/credit movement of a balance for one date.",
                "日余额行 —— 某个余额在某日的借贷变动。",
                ["balance row day", "daily balance", "day balance"], ["日余额行", "每日余额", "日结余额"],
                fields: [
                    F("BalanceId", "The balance the daily row belongs to.", "日行所属的余额。"),
                ]),

            // ---- BankAccounts -------------------------------------------------------
            Content(
                "Monitor.API.Accounting.BankAccount",
                "A bank account used for incoming and outgoing payments.",
                "用于收付款的银行账户。",
                ["bank account", "bank"], ["银行账户", "银行账号"],
                fields: [
                    F("Code", "The unique code of the bank account.", "银行账户的唯一代码。"),
                    F("Type", "The bank-account format (IBAN, BBAN, UPIC, miscellaneous).", "银行账户的格式（IBAN、BBAN、UPIC 或其他）。"),
                    F("CurrencyId", "The currency of the bank account.", "银行账户的货币。"),
                    F("AccountingAccountId", "The accounting account the bank account is coded to.", "银行账户对应的会计科目。"),
                    F("BankAddressId", "The address of the bank.", "银行的地址。"),
                ]),

            // ---- Bookings -----------------------------------------------------------
            Content(
                "Monitor.API.Accounting.Booking",
                "A bookkeeping entry (journal entry) with its booking rows.",
                "记账（分录），含其记账行。",
                ["booking", "journal entry", "bookkeeping entry", "ledger entry"], ["记账", "分录", "会计分录"],
                fields: [
                    F("Rows", "The booking rows of the booking.", "记账的行。"),
                ]),
            Content(
                "Monitor.API.Accounting.BookingRow",
                "A row of a booking — the debit or credit to an account.",
                "记账的行 —— 对某个科目的借方或贷方。",
                ["booking row", "journal row", "booking line"], ["记账行", "分录行", "记账行条目"],
                fields: [
                    F("Type", "The type of the booking row (accounts payable, accounts receivable, VAT, purchase, sales...).", "记账行的类型（应付账款、应收账款、增值税、采购、销售等）。"),
                    F("PurchaseOrderDeliveryRowId", "The purchase-order delivery row the booking row originates from.", "记账行所源自的采购订单交货行。"),
                    F("BookingId", "The booking the row belongs to.", "该行所属的记账。"),
                    F("VatRateId", "The VAT rate of the booking row.", "记账行的增值税率。"),
                    F("AccrualAccountingId", "The accrual accounting the booking row is part of.", "记账行所属的应计会计。"),
                    F("DebitInCompanyCurrencyCurrencyId", "The currency of the debit in company currency.", "按公司货币计价的借方的货币。"),
                    F("CreditInCompanyCurrencyCurrencyId", "The currency of the credit in company currency.", "按公司货币计价的贷方的货币。"),
                    F("DebitCurrencyId", "The currency of the debit.", "借方的货币。"),
                    F("CreditCurrencyId", "The currency of the credit.", "贷方的货币。"),
                    F("CodingEntryId", "The coding entry of the booking row.", "记账行的记账条目。"),
                    F("NetAmountBookingRowId", "The net-amount booking row of the row.", "该行的净额记账行。"),
                ]),

            // ---- Codings ------------------------------------------------------------
            Content(
                "Monitor.API.Accounting.Coding",
                "A coding structure — the set of coding rows used to attribute a booking.",
                "记账结构 —— 用于归属记账的一组记账行。",
                ["coding", "coding structure", "coding rows"], ["记账结构", "编码"],
                fields: [
                    F("CodingRows", "The coding rows of the coding.", "记账结构的记账行。"),
                ]),
            Content(
                "Monitor.API.Accounting.CodingDimension",
                "A coding dimension — a way to attribute bookkeeping, e.g. by project, part, or department.",
                "记账维度 —— 记账的归属方式，如按项目、物料或部门。",
                ["coding dimension", "dimension"], ["记账维度", "维度"],
                fields: [
                    F("ReferenceEntityType", "The entity the dimension codes (none, project, part, department, work center...).", "维度所编码的实体（无、项目、物料、部门、工作中心等）。"),
                    F("CodingElements", "The coding elements (values) of the dimension.", "维度的记账元素（值）。"),
                ]),
            Content(
                "Monitor.API.Accounting.CodingElement",
                "A coding element — one value within a coding dimension.",
                "记账元素 —— 记账维度中的一个值。",
                ["coding element", "dimension value", "coding value"], ["记账元素", "维度值", "编码值"]),
            Content(
                "Monitor.API.Accounting.CodingEntry",
                "A coding entry — an account combined with its coding-dimension elements.",
                "记账条目 —— 科目及其记账维度元素的组合。",
                ["coding entry", "coding", "posting"], ["记账条目", "过账"],
                fields: [
                    F("Account", "The account of the coding entry.", "记账条目的科目。"),
                    F("CodingEntryElements", "The coding-dimension elements of the coding entry.", "记账条目的记账维度元素。"),
                ]),
            Content(
                "Monitor.API.Accounting.CodingEntryElement",
                "An element of a coding entry — the dimension value coded for one dimension.",
                "记账条目的元素 —— 为某个维度编码的维度值。",
                ["coding entry element", "entry element"], ["记账条目元素", "条目元素"],
                fields: [
                    F("CodingDimension", "The coding dimension of the element.", "元素的记账维度。"),
                ]),
            Content(
                "Monitor.API.Accounting.CodingRow",
                "A coding row within a coding — one account coding of a type.",
                "记账结构中的记账行 —— 某种类型的科目记账。",
                ["coding row", "coding line"], ["记账行", "编码行"],
                fields: [
                    F("Type", "The type of the coding row (standard, setup, material, inventory, price difference, cost).", "记账行的类型（标准、准备、物料、库存、价格差异、成本）。"),
                ]),

            // ---- FixedAssets --------------------------------------------------------
            Content(
                "Monitor.API.Accounting.FixedAsset",
                "A fixed asset with its acquisition, depreciation, and sale information.",
                "固定资产，含购置、折旧与处置信息。",
                ["fixed asset", "asset", "capital asset"], ["固定资产", "资产", "资本性资产"],
                fields: [
                    F("Code", "The unique code of the fixed asset.", "固定资产的唯一代码。"),
                    F("GroupId", "The fixed-asset group of the asset.", "资产的固定资产组。"),
                    F("Group", "The fixed-asset group of the asset.", "资产的固定资产组。"),
                    F("AccountsPayableId", "The accounts payable the asset was acquired through.", "购置该资产的应付账款。"),
                    F("VoucherId", "The voucher of the asset's acquisition.", "资产购置的凭证。"),
                    F("SupplierId", "The supplier the asset was bought from.", "出售该资产的供应商。"),
                    F("WorkCenterId", "The work center the asset is used at.", "使用该资产的工作中心。"),
                    F("DepartmentId", "The department the asset belongs to.", "资产所属的部门。"),
                    F("Sales", "The sales and retirements of the asset.", "资产的出售与处置记录。"),
                ]),
            Content(
                "Monitor.API.Accounting.FixedAssetDepreciation",
                "A depreciation entry of a fixed asset.",
                "固定资产的折旧条目。",
                ["depreciation", "fixed asset depreciation", "depreciation entry"], ["折旧", "固定资产折旧", "折旧条目"],
                fields: [
                    F("ParentId", "The fixed asset the depreciation belongs to.", "折旧所属的固定资产。"),
                ]),
            Content(
                "Monitor.API.Accounting.FixedAssetGroup",
                "A fixed-asset group defining the depreciation profile of its assets.",
                "固定资产组 —— 定义其下资产的折旧方案。",
                ["fixed asset group", "asset group"], ["固定资产组", "资产组"],
                fields: [
                    F("Code", "The unique code of the fixed-asset group.", "固定资产组的唯一代码。"),
                ]),
            Content(
                "Monitor.API.Accounting.FixedAssetSale",
                "A sale or retirement of a fixed asset.",
                "固定资产的出售或处置。",
                ["fixed asset sale", "asset sale", "asset retirement", "scrapping"], ["固定资产出售", "资产出售", "资产处置"],
                fields: [
                    F("Type", "The type of the transaction (sale, retirement).", "交易的类型（出售、处置）。"),
                    F("AccountsReceivableId", "The accounts receivable created for the sale, if invoiced.", "出售开票时产生的应收账款（如有）。"),
                    F("CustomerId", "The customer the asset was sold to.", "购买该资产的客户。"),
                    F("CommentId", "The comment of the sale.", "出售的备注。"),
                    F("Comment", "The comment of the sale.", "出售的备注。"),
                    F("BookingId", "The booking of the sale.", "出售的记账。"),
                ]),

            // ---- IncomingPayments ---------------------------------------------------
            Content(
                "Monitor.API.Accounting.IncomingPayment",
                "A payment received from a customer against receivables.",
                "从客户收到的针对应收账款的付款。",
                ["incoming payment", "payment received", "customer payment", "receipt"], ["收款", "收到的付款", "客户付款", "收据"],
                fields: [
                    F("BankChargeAmountCurrencyId", "The currency of the bank-charge amount.", "银行手续费金额的货币。"),
                    F("BookingId", "The booking of the incoming payment.", "收款的记账。"),
                    F("CancelledByUserId", "The user who cancelled the payment.", "取消该付款的用户。"),
                    F("InterestType", "The interest handling of the payment (interest invoice, next regular invoice, none).", "付款的利息处理方式（利息发票、下次普通发票、无）。"),
                    F("PaidAmountCurrencyId", "The currency of the paid amount.", "实付金额的货币。"),
                    F("PaidAmountInCompanyCurrencyCurrencyId", "The currency of the paid amount in company currency.", "按公司货币计价的实付金额的货币。"),
                    F("PaidVatAmountCurrencyId", "The currency of the paid VAT amount.", "已付增值税金额的货币。"),
                    F("ParentId", "The accounts receivable the payment is applied to.", "付款所冲抵的应收账款。"),
                    F("PaymentMethodId", "The payment method of the payment.", "付款的付款方式。"),
                    F("WriteOffAmountCurrencyId", "The currency of the write-off amount.", "核销金额的货币。"),
                    F("WriteOffAmountInCompanyCurrencyCurrencyId", "The currency of the write-off amount in company currency.", "按公司货币计价的核销金额的货币。"),
                    F("WriteOffCodeId", "The write-off code of the payment.", "付款的核销代码。"),
                    F("InterestInvoicingStatus", "The interest-invoicing status (no interest, interest, interest invoiced).", "利息开票状态（无利息、有利息、已开利息发票）。"),
                ]),

            // ---- OpeningBalances ----------------------------------------------------
            Content(
                "Monitor.API.Accounting.OpeningBalance",
                "An opening balance for an account at the start of an accounting year.",
                "科目在某会计年度年初的期初余额。",
                ["opening balance", "opening balance row"], ["期初余额", "期初余额行"],
                fields: [
                    F("AccountingYearId", "The accounting year of the opening balance.", "期初余额的会计年度。"),
                    F("CodingEntryId", "The coding entry of the opening balance.", "期初余额的记账条目。"),
                    F("CreditCurrencyId", "The currency of the credit.", "贷方的货币。"),
                    F("CreditInCompanyCurrencyCurrencyId", "The currency of the credit in company currency.", "按公司货币计价的贷方的货币。"),
                    F("DebitCurrencyId", "The currency of the debit.", "借方的货币。"),
                    F("DebitInCompanyCurrencyCurrencyId", "The currency of the debit in company currency.", "按公司货币计价的借方的货币。"),
                ]),

            // ---- OutgoingPayments ---------------------------------------------------
            Content(
                "Monitor.API.Accounting.OutgoingPayment",
                "A payment to a supplier against accounts payable.",
                "向供应商支付的针对应付账款的付款。",
                ["outgoing payment", "payment to supplier", "supplier payment", "disbursement"], ["付款", "向供应商付款", "供应商付款", "支出"],
                fields: [
                    F("AccountsPayableId", "The accounts payable the payment settles.", "付款所结清的应付账款。"),
                    F("SupplierId", "The supplier the payment is made to.", "付款的收款供应商。"),
                    F("PaymentMethodId", "The payment method of the payment.", "付款的付款方式。"),
                    F("PaidAmountCurrencyId", "The currency of the paid amount.", "实付金额的货币。"),
                    F("PaidAmountInCompanyCurrencyCurrencyId", "The currency of the paid amount in company currency.", "按公司货币计价的实付金额的货币。"),
                    F("PaidVatAmountCurrencyId", "The currency of the paid VAT amount.", "已付增值税金额的货币。"),
                    F("BankChargeAmountCurrencyId", "The currency of the bank-charge amount.", "银行手续费金额的货币。"),
                    F("CancelledByUserId", "The user who cancelled the payment.", "取消该付款的用户。"),
                    F("ReceivingBankAccountId", "The supplier bank account receiving the payment.", "接收付款的供应商银行账户。"),
                    F("SendingBankAccountId", "The company bank account the payment is sent from.", "付款所用的公司银行账户。"),
                    F("SetOffIncomingPaymentId", "The incoming payment the payment is set off against.", "与该付款冲抵的收款。"),
                    F("BookingId", "The booking of the outgoing payment.", "付款的记账。"),
                    F("WriteOffCodeId", "The write-off code of the payment.", "付款的核销代码。"),
                    F("WriteOffAmountCurrencyId", "The currency of the write-off amount.", "核销金额的货币。"),
                    F("WriteOffAmountInCompanyCurrencyCurrencyId", "The currency of the write-off amount in company currency.", "按公司货币计价的核销金额的货币。"),
                ]),

            // ---- StandardAccounts ---------------------------------------------------
            Content(
                "Monitor.API.Accounting.StandardAccount",
                "A standard account used by automatic coding to map a transaction type to an account.",
                "自动记账使用的标准科目 —— 将交易类型映射到科目。",
                ["standard account", "default account", "auto account"], ["标准科目", "默认科目", "自动记账科目"],
                fields: [
                    F("AccountType", "The transaction type the account is used for (accounts receivable, accounts payable, VAT...).", "该科目用于的交易类型（应收账款、应付账款、增值税等）。"),
                    F("CodingEntryId", "The coding entry of the standard account.", "标准科目的记账条目。"),
                    F("StandardAccountCategory", "The category of the standard account (sales, purchase, accounting).", "标准科目的类别（销售、采购、会计）。"),
                ]),

            // ---- Vouchers -----------------------------------------------------------
            Content(
                "Monitor.API.Accounting.Voucher",
                "A voucher (verification) in the general ledger with its rows and connections.",
                "总账中的记账凭证，含行与关联。",
                ["voucher", "verification", "journal voucher", "voucher entry"], ["凭证", "记账凭证", "凭单"],
                fields: [
                    F("ConnectionType", "How the voucher connects to its parent (none, correction, copy).", "凭证与其父凭证的连接方式（无、更正、复制）。"),
                    F("ReverseConnectionType", "How the voucher connects to its reverse voucher (none, correction, copy).", "凭证与其冲销凭证的连接方式（无、更正、复制）。"),
                    F("Comment", "The comment of the voucher.", "凭证的备注。"),
                    F("Rows", "The rows of the voucher.", "凭证的行。"),
                    F("AccountsPayable", "The accounts payable the voucher belongs to, if any.", "凭证所属的应付账款（如有）。"),
                ]),
            Content(
                "Monitor.API.Accounting.VoucherRow",
                "A row of a voucher — the debit or credit to an account.",
                "凭证的行 —— 对某个科目的借方或贷方。",
                ["voucher row", "voucher line", "voucher entry row"], ["凭证行", "凭证明细行"],
                fields: [
                    F("VoucherId", "The voucher the row belongs to.", "该行所属的凭证。"),
                    F("VatRateId", "The VAT rate of the voucher row.", "凭证行的增值税率。"),
                    F("BalanceId", "The balance the voucher row posts to.", "凭证行过账到的余额。"),
                    F("AccrualAccountingId", "The accrual accounting the voucher row is part of.", "凭证行所属的应计会计。"),
                    F("DebitInCompanyCurrencyCurrencyId", "The currency of the debit in company currency.", "按公司货币计价的借方的货币。"),
                    F("CreditInCompanyCurrencyCurrencyId", "The currency of the credit in company currency.", "按公司货币计价的贷方的货币。"),
                    F("DebitCurrencyId", "The currency of the debit.", "借方的货币。"),
                    F("CreditCurrencyId", "The currency of the credit.", "贷方的货币。"),
                    F("CodingEntryId", "The coding entry of the voucher row.", "凭证行的记账条目。"),
                    F("AccountsPayableId", "The accounts payable the voucher row settles.", "凭证行所结清的应付账款。"),
                    F("AccountsReceivableId", "The accounts receivable the voucher row settles.", "凭证行所结清的应收账款。"),
                    F("NetAmountVoucherRowId", "The net-amount voucher row of the row.", "该行的净额凭证行。"),
                ]),
            Content(
                "Monitor.API.Accounting.VoucherSeries",
                "A voucher series defining the numbering of vouchers.",
                "定义凭证编号方式的凭证系列。",
                ["voucher series"], ["凭证系列"]),
            Content(
                "Monitor.API.VoucherNumberSeries",
                "The per-accounting-year number series for vouchers, linking a series to a year.",
                "凭证按会计年度的编号系列 —— 将凭证系列关联到会计年度。",
                ["voucher number series", "number series", "voucher numbering"], ["凭证号系列", "编号系列", "凭证编号"],
                fields: [
                    F("VoucherSeries", "The voucher series of the number series.", "编号系列的凭证系列。"),
                    F("AccountingYear", "The accounting year of the number series.", "编号系列的会计年度。"),
                ]),
        ];
    }
}
