namespace MonitorErpMcp.Catalog.Content.Common
{
    // The using-static sits inside the namespace so the imported Content(...) builder binds before
    // the enclosing MonitorErpMcp.Catalog.Content namespace in simple-name lookup.
    using static MonitorErpMcp.Catalog.Content.ContentEntryFactory;
    using MonitorErpMcp.Catalog.Model;

    /// <summary>
    /// Hand-authored content for Common query records: bilingual descriptions and search aliases
    /// (en first, zh second), keyed by clrType and merged onto the structural catalog. Important
    /// fields (enum, reference, expandable, unique) carry bilingual descriptions; self-evident
    /// fields such as a bare Description string are skipped per the coverage tiers.
    /// </summary>
    public static class Queries
    {
        /// <summary>Hand-authored entries for this family, merged by <c>clrType</c> onto the structural catalog.</summary>
        public static readonly ContentEntry[] Entries =
        [
            // ---- Addresses ---------------------------------------------------------------
            Content(
                "Monitor.API.Common.Address",
                "A postal address used by companies, customers, suppliers, and persons, with its country-specific field layout.",
                "供公司、客户、供应商及人员使用的邮政地址，含国家特定字段布局。",
                ["address", "postal address", "mailing address"], ["地址", "邮政地址", "通讯地址"],
                fields: [
                    F("AddressFormatType", "The country-specific layout of the address fields.", "国家特定的地址字段排布方式。"),
                ]),

            // ---- ApplicationUsers -------------------------------------------------------
            Content(
                "Monitor.API.Common.ApplicationUser",
                "A MONITOR system user — the login account with its roles, warehouses, printers, and e-mail settings.",
                "MONITOR 系统用户 —— 登录账号，含角色、仓库、打印机与电子邮件设置。",
                ["user", "application user", "login", "login account"], ["用户", "应用用户", "登录用户"],
                fields: [
                    F("Username", "The login name of the user; must be unique.", "用户的登录名；必须唯一。"),
                    F("DefaultVoucherSeriesId", "The default voucher series used for this user's accounting entries.", "该用户记账时使用的默认凭证系列。"),
                    F("MailMethod", "The e-mail method used for outgoing mail (e.g. client-based Outlook or server-based SMTP/Exchange).", "发送邮件使用的邮件方式（如基于客户端的 Outlook 或服务器端 SMTP/Exchange）。"),
                    F("Printers", "The printers assigned to the user.", "分配给该用户的打印机。"),
                    F("PrintoutFormatForParcel", "The default printout format for parcel transport labels.", "包裹运输标签的默认打印格式。"),
                    F("WarehousePermissions", "The warehouse-scoped permissions granted to the user.", "授予该用户的仓库级权限。"),
                    F("UserAuthenticationMethod", "How the user authenticates (password, Windows-integrated, or OIDC).", "用户的身份验证方式（密码、Windows 集成或 OIDC）。"),
                ]),
            Content(
                "Monitor.API.Common.ApplicationUserPrinter",
                "The printer assignment for a user and a document type.",
                "用户针对某单据类型的打印机分配。",
                ["user printer", "printer assignment"], ["用户打印机", "打印机分配"],
                fields: [
                    F("ApplicationUserId", "The user the printer is assigned to.", "被分配打印机的用户。"),
                    F("NormalizedFormReportType", "The document type that prints on this printer.", "在该打印机上打印的单据类型。"),
                    F("ServerPrinterId", "The server printer used for the document type.", "该单据类型使用的服务器打印机。"),
                    F("FormDocumentType", "Whether the assignment covers a document or an adapted report.", "分配针对的是单据还是改制报告。"),
                ]),

            // ---- AutoCompletes / Blobs --------------------------------------------------
            Content(
                "Monitor.API.Common.AutoCompleteConfiguration",
                "A configuration that drives the autocomplete popups of a field.",
                "驱动字段自动完成弹出窗口的配置。",
                ["autocomplete", "autocomplete configuration", "auto complete"], ["自动完成", "自动完成配置"]),
            Content(
                "Monitor.API.Common.BlobData",
                "Binary large object data (e.g. an image or document) stored on a record.",
                "存储在记录上的二进制大对象数据（如图片或文档）。",
                ["blob", "binary data", "attachment"], ["二进制数据", "大对象数据"],
                fields: [
                    F("MediaType", "The media type of the blob (text, image, audio, video, application...).", "二进制数据的媒体类型（文本、图像、音频、视频、应用程序等）。"),
                ]),

            // ---- BusinessContacts ------------------------------------------------------
            Content(
                "Monitor.API.Common.BusinessContactBankAccount",
                "A bank account registered for a business contact, with clearing and bank codes.",
                "为业务联系人注册的银行账户，含清算号与银行代码。",
                ["bank account", "business contact bank account"], ["银行账户", "业务联系人银行账户"],
                fields: [
                    F("Type", "The bank account format (IBAN, BBAN, UPIC, or miscellaneous).", "银行账户格式（IBAN、BBAN、UPIC 或其他）。"),
                    F("Country", "The country of the bank account.", "银行账户所在国家。"),
                    F("CentralBankCode", "The central bank code of the bank.", "银行的中央银行代码。"),
                    F("Currency", "The currency of the bank account.", "银行账户的货币。"),
                    F("BankAddress", "The address of the bank.", "银行的地址。"),
                ]),
            Content(
                "Monitor.API.Common.BusinessContactNoteHistory",
                "Notes logged against a business contact, e.g. a customer or supplier.",
                "针对业务联系人（如客户或供应商）记录的备注。",
                ["note", "note history", "business contact note"], ["备注", "备注历史", "业务联系人备注"],
                fields: [
                    F("CreatedByUserId", "The user who created the note.", "创建备注的用户。"),
                    F("Body", "The note body content.", "备注正文内容。"),
                ]),
            Content(
                "Monitor.API.Common.BusinessContactReference",
                "A reference person or contact point on a business contact, with its communication details.",
                "业务联系人的联系人（参照），含通信方式详情。",
                ["reference", "contact", "contact person"], ["联系人", "参照", "联系点"],
                fields: [
                    F("Comment", "A comment attached to the reference.", "附加到联系人的备注。"),
                ]),

            // ---- Calendars -------------------------------------------------------------
            Content(
                "Monitor.API.Common.Calendar",
                "A working-days calendar with its country-specific holidays, used for delivery and planning calculations.",
                "含国家特定节假日的日历，用于交货与计划计算。",
                ["calendar", "working days", "holidays"], ["日历", "工作日历", "节假日"],
                fields: [
                    F("CalendarType", "The country or holiday pattern the calendar follows.", "日历采用的国家或假日模式。"),
                    F("HolidayType", "Which days count as holidays (none, weekends, or all).", "哪些天数计为假日（无、仅周末或全部）。"),
                    F("Code", "The unique code of the calendar.", "日历的唯一代码。"),
                ]),
            Content(
                "Monitor.API.Common.CentralBankCode",
                "The central bank codes used to identify banks for payments and bank accounts.",
                "用于识别银行以便支付和银行账户的中央银行代码。",
                ["central bank code", "bank code"], ["中央银行代码", "银行代码"]),

            // ---- CategoryComponents ----------------------------------------------------
            Content(
                "Monitor.API.Common.Commands.CategoryComponent.CategoryComponent",
                "A category component — a free or selection-based category field used on entities such as parts and customers.",
                "类别组件 —— 用于物料、客户等实体的自由填写或按选项选择的类别字段。",
                ["category component", "category field", "category"], ["类别组件", "类别字段", "类别"],
                fields: [
                    F("CategoryType", "The entity type the category component applies to.", "类别组件适用的实体类型。"),
                    F("Type", "Whether the component is optional or requires a selection list.", "组件是可选的还是必须使用选项列表。"),
                    F("CategoryValue", "The selectable values of the category component.", "类别组件的可选项值。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Shared.CategoryComponentValue",
                "A single selectable value of a category component.",
                "类别组件的单个可选值。",
                ["category value", "category component value"], ["类别值", "类别组件值"]),

            // ---- Comments --------------------------------------------------------------
            Content(
                "Monitor.API.Common.Comment",
                "A comment or note attached to a record, with optional file links.",
                "附加到记录上的评论或备注，可含文件链接。",
                ["comment", "note", "remark"], ["评论", "备注", "批注"],
                fields: [
                    F("FileLinks", "The files linked to the comment.", "链接到该评论的文件。"),
                ]),

            // ---- CommunicationAddresses ------------------------------------------------
            Content(
                "Monitor.API.Common.CommunicationAddress",
                "A communication address (phone, fax, e-mail, cell phone) of an entity, and which documents it receives.",
                "实体的通信地址（电话、传真、电子邮件、手机）及其接收的单据。",
                ["communication address", "contact address", "contact channel"], ["通信地址", "联系方式", "联系渠道"],
                fields: [
                    F("Type", "The communication channel (phone, fax, e-mail, or cell phone).", "通信渠道（电话、传真、电子邮件或手机）。"),
                    F("RecipientOf", "The document types this address receives.", "该地址接收的单据类型。"),
                ]),

            // ---- Companies -------------------------------------------------------------
            Content(
                "Monitor.API.Common.Company",
                "The company that owns the MONITOR installation, with its currency, language, and warehouses.",
                "MONITOR 系统所属的公司，含货币、语言与仓库。",
                ["company", "company settings"], ["公司", "公司设置"],
                fields: [
                    F("CurrencyId", "The base currency of the company.", "公司的基础货币。"),
                    F("Currency", "The base currency of the company.", "公司的基础货币。"),
                    F("LanguageId", "The default language of the company.", "公司的默认语言。"),
                    F("Language", "The default language of the company.", "公司的默认语言。"),
                    F("Image", "The company logo image.", "公司的徽标图片。"),
                    F("Warehouses", "The warehouses of the company.", "公司的仓库。"),
                ]),
            Content(
                "Monitor.API.Common.CompanyEmissionDetail",
                "A reported sustainability emission figure for the company, with its unit and origin.",
                "公司上报的可持续发展排放数据，含单位与来源。",
                ["emission", "sustainability", "co2", "company emission"], ["排放", "排放明细", "可持续发展"],
                fields: [
                    F("Unit", "The unit the emission value is reported in.", "排放值上报使用的单位。"),
                ]),
            Content(
                "Monitor.API.Inventory.Commands.EmissionFactor",
                "An emission factor used to calculate sustainability emissions from a measured quantity.",
                "用于根据测量数量计算可持续发展排放量的排放因子。",
                ["emission factor", "co2 factor", "sustainability factor"], ["排放因子", "二氧化碳因子"]),
            Content(
                "Monitor.API.Common.CompanyOverheadType",
                "The company overhead types used to classify overhead costs.",
                "用于归类间接费用的公司间接费用类型。",
                ["overhead type", "company overhead"], ["间接费用类型", "公司间接费用"]),
            Content(
                "Monitor.API.Common.ConnectionProfile",
                "A connection profile linking this installation to a remote MONITOR company for transfers.",
                "用于将本安装连接到远程 MONITOR 公司以进行传输的连接配置文件。",
                ["connection profile", "connection", "remote connection"], ["连接配置", "连接配置文件", "远程连接"],
                fields: [
                    F("Number", "The unique number of the connection profile.", "连接配置的唯一编号。"),
                    F("TargetRole", "Whether the profile connects to a manufacturing or a sales company.", "配置文件连接的是制造公司还是销售公司。"),
                ]),

            // ---- Countries -------------------------------------------------------------
            Content(
                "Monitor.API.Common.Country",
                "A country with its currency, language, VAT, and address-format settings.",
                "国家，含货币、语言、增值税与地址格式设置。",
                ["country", "nation"], ["国家", "国家设置"]),

            // ---- Currencies ------------------------------------------------------------
            Content(
                "Monitor.API.Common.Currency",
                "A currency with its exchange rates, used for pricing and accounting.",
                "货币，含汇率，用于定价与会计。",
                ["currency", "exchange rate", "money"], ["货币", "币种", "汇率"],
                fields: [
                    F("Code", "The unique ISO code of the currency (e.g. EUR).", "货币的唯一 ISO 代码（如 EUR）。"),
                    F("ExchangeRates", "The exchange rates of the currency.", "该货币的汇率。"),
                    F("ExchangeRatesChangeLog", "The logged changes to the currency's exchange rates.", "该货币汇率的变更日志。"),
                ]),
            Content(
                "Monitor.API.Common.CurrencyExchangeRate",
                "An exchange rate for a currency exchange type.",
                "某货币兑换类型的汇率。",
                ["exchange rate"], ["汇率"],
                fields: [
                    F("CurrencyExchangeTypeId", "The exchange-rate type the rate belongs to.", "该汇率所属的汇率类型。"),
                ]),
            Content(
                "Monitor.API.Common.CurrencyExchangeRateChangeLog",
                "A logged change to a currency exchange rate, with its validity end date.",
                "货币汇率的变更日志，含有效截止日期。",
                ["exchange rate change", "exchange rate history"], ["汇率变更", "汇率历史"],
                fields: [
                    F("CurrencyExchangeTypeId", "The exchange-rate type the change belongs to.", "变更所属的汇率类型。"),
                    F("CurrencyId", "The currency the change belongs to.", "变更所属的货币。"),
                ]),
            Content(
                "Monitor.API.Common.CurrencyExchangeType",
                "The exchange-rate types (e.g. default AFS rate) a currency can carry.",
                "货币可携带的汇率类型（如默认 AFS 汇率）。",
                ["exchange rate type", "exchange type"], ["汇率类型", "兑换类型"]),

            // ---- CustomReports ---------------------------------------------------------
            Content(
                "Monitor.API.Common.CustomReportDefinition",
                "A custom report definition grouping its display definitions.",
                "自定义报告定义，对其显示定义进行分组。",
                ["custom report", "report definition"], ["自定义报告", "报告定义"],
                fields: [
                    F("ReportNumber", "The unique number of the report definition.", "报告定义的唯一编号。"),
                    F("DisplayDefinitions", "The display variants of the report.", "报告的显示变体。"),
                ]),
            Content(
                "Monitor.API.Common.CustomReportDisplayDefinition",
                "A display definition of a custom report — a grid or report view over a query.",
                "自定义报告的显示定义 —— 基于查询的网格或报告视图。",
                ["display definition", "report view", "custom report display"], ["显示定义", "报告视图", "自定义报告显示"],
                fields: [
                    F("ReportType", "Whether the display is a grid, report, or sub-report.", "显示是网格、报告还是子报告。"),
                ]),

            // ---- DelegatedWork ---------------------------------------------------------
            Content(
                "Monitor.API.Common.DelegatedWork",
                "Work delegated to another employee, e.g. a project activity or operation.",
                "委托给其他员工的工作，如项目活动或工序。",
                ["delegated work", "delegation"], ["委托工作", "委派工作"],
                fields: [
                    F("WorkRecordingType", "The type of work recording the delegation covers.", "委托涵盖的作业记录类型。"),
                    F("DelegatedBy", "The user who delegated the work.", "委托该工作的用户。"),
                    F("EmployeeId", "The employee the work was delegated to.", "被委托该工作的员工。"),
                    F("ActivityId", "The project activity the delegation covers.", "委托涵盖的项目活动。"),
                    F("OperationId", "The manufacturing operation the delegation covers.", "委托涵盖的制造工序。"),
                ]),

            // ---- Delivery --------------------------------------------------------------
            Content(
                "Monitor.API.Common.DeliveryAddress",
                "A delivery address used on customer orders, purchase orders, and shipments.",
                "用于客户订单、采购订单与发货的交货地址。",
                ["delivery address", "shipping address"], ["交货地址", "送货地址"],
                fields: [
                    F("DeliveryWeekdays", "The weekdays on which deliveries are made to this address.", "向该地址交货的工作日。"),
                    F("Warehouses", "The warehouse-specific delivery information for this address.", "该地址的仓库特定交货信息。"),
                ]),
            Content(
                "Monitor.API.Common.DeliveryAddressWarehouseInformation",
                "The warehouse-specific delivery settings of a delivery address: method, term, and lead time.",
                "交货地址的仓库特定交货设置：方式、条款与交期。",
                ["delivery address warehouse", "warehouse delivery information"], ["交货地址仓库信息", "仓库交货信息"],
                fields: [
                    F("WarehouseId", "The warehouse the delivery settings apply to.", "交货设置适用的仓库。"),
                    F("DeliveryMethodId", "The delivery method used for this warehouse.", "该仓库使用的交货方式。"),
                    F("DeliveryTermId", "The delivery term used for this warehouse.", "该仓库使用的交货条款。"),
                    F("DeliveryWeekdays", "The weekdays on which deliveries are made.", "进行交货的工作日。"),
                    F("ParentId", "The delivery address these settings belong to.", "这些设置所属的交货地址。"),
                ]),
            Content(
                "Monitor.API.Common.DeliveryMethod",
                "The delivery methods (e.g. freight carrier) used when shipping goods.",
                "发货时使用的交货方式（如货运承运商）。",
                ["delivery method", "shipping method", "freight method"], ["交货方式", "发货方式"]),
            Content(
                "Monitor.API.Common.DeliveryTerm",
                "A delivery term (e.g. Incoterms) with its payer and destination.",
                "交货条款（如 Incoterms），含付款方与目的地。",
                ["delivery term", "incoterm", "term"], ["交货条款", "贸易条款", "INCOTERM"],
                fields: [
                    F("Payer", "Who pays for the delivery (buyer, seller, other, or Incoterms).", "交货费用的承担方（买方、卖方、其他或按 Incoterms）。"),
                ]),
            Content(
                "Monitor.API.Common.DeliveryTime",
                "The delivery times used to calculate promised delivery dates.",
                "用于计算承诺交货日期的交货时间。",
                ["delivery time", "lead time"], ["交货时间", "交付时间"]),

            // ---- Departments -----------------------------------------------------------
            Content(
                "Monitor.API.Common.Department",
                "A department that employees and cost-reporting entries belong to.",
                "员工与成本上报条目所属的部门。",
                ["department", "division"], ["部门", "科室"],
                fields: [
                    F("Code", "The unique code of the department.", "部门的唯一代码。"),
                ]),

            // ---- Discounts -------------------------------------------------------------
            Content(
                "Monitor.API.Common.Discount",
                "A discount rule with its type, calculation, and priority.",
                "折扣规则，含类型、计算方式与优先级。",
                ["discount", "discount rule"], ["折扣", "折扣规则"],
                fields: [
                    F("DiscountForModule", "The module the discount applies to.", "折扣适用的模块。"),
                    F("DiscountType", "The kind of discount (order, row, project, manual...).", "折扣种类（订单、行、项目、手工等）。"),
                    F("DiscountCalculationType", "Whether the discount is a percentage or a fixed amount.", "折扣是按百分比还是固定金额计算。"),
                ]),
            Content(
                "Monitor.API.Common.DiscountCategory",
                "A discount category grouping tiered discount rows.",
                "对阶梯折扣行进行分组的折扣类别。",
                ["discount category", "discount class"], ["折扣类别", "折扣分类"],
                fields: [
                    F("Number", "The unique number of the discount category.", "折扣类别的唯一编号。"),
                    F("Rows", "The tiered discount rows of the category.", "折扣类别的阶梯折扣行。"),
                ]),
            Content(
                "Monitor.API.Common.DiscountCategoryRow",
                "A tiered discount row: boundaries and discounts by quantity or value.",
                "阶梯折扣行：按数量或金额的边界与折扣。",
                ["discount row", "tiered discount"], ["折扣行", "阶梯折扣"],
                fields: [
                    F("BoundaryType", "Whether the boundaries are by quantity or by value.", "边界是按数量还是按金额。"),
                    F("DiscountCategoryId", "The discount category the row belongs to.", "该行所属的折扣类别。"),
                    F("ProductGroupId", "The product group the discount applies to.", "折扣适用的产品组。"),
                    F("PartCodeId", "The part code the discount applies to.", "折扣适用的物料代码。"),
                ]),

            // ---- EDI -------------------------------------------------------------------
            Content(
                "Monitor.API.Common.EdiBehavior",
                "An EDI behavior defining how electronic business documents are exchanged with customers.",
                "定义与客户进行电子业务单据交换方式的 EDI 行为。",
                ["edi", "edi behavior", "electronic data interchange"], ["EDI", "EDI行为", "电子数据交换"],
                fields: [
                    F("Name", "The unique name of the EDI behavior.", "EDI 行为的唯一名称。"),
                    F("Module", "Whether the behavior covers sales or purchase documents.", "行为涵盖销售还是采购单据。"),
                    F("EdiChannelConfigurations", "The configured EDI channels of the behavior.", "该行为的已配置 EDI 渠道。"),
                    F("Customers", "The customers using this EDI behavior.", "使用该 EDI 行为的客户。"),
                    F("InvoiceCustomers", "The customers that receive invoices via this EDI behavior.", "通过该 EDI 行为接收发票的客户。"),
                    F("WarehouseId", "The warehouse the EDI behavior is limited to.", "EDI 行为限定的仓库。"),
                    F("Warehouse", "The warehouse the EDI behavior is limited to.", "EDI 行为限定的仓库。"),
                ]),
            Content(
                "Monitor.API.Common.EdiChannelConfiguration",
                "A configured channel of an EDI configuration, with its active/notification state.",
                "EDI 配置的已配置渠道，含启用与通知状态。",
                ["edi channel", "channel configuration"], ["EDI渠道", "渠道配置"],
                fields: [
                    F("ParentId", "The EDI configuration the channel belongs to.", "渠道所属的 EDI 配置。"),
                    F("ChannelId", "The EDI channel used.", "使用的 EDI 渠道。"),
                ]),

            // ---- EmploymentPeriods -----------------------------------------------------
            Content(
                "Monitor.API.Common.EmploymentPeriod",
                "An employment period of a person, with its start and finish dates.",
                "人员的受雇期间，含起止日期。",
                ["employment period", "employment"], ["受雇期间", "任职期间"],
                fields: [
                    F("PersonId", "The person the employment period belongs to.", "受雇期间所属的人员。"),
                    F("CommentId", "A comment on the employment period.", "受雇期间的备注。"),
                    F("Comment", "A comment on the employment period.", "受雇期间的备注。"),
                ]),

            // ---- ChangeLogs ------------------------------------------------------------
            Content(
                "Monitor.API.Common.EntityChangeLog",
                "A logged change (create, update, delete) to an entity, with the changed properties.",
                "实体变更（创建、更新、删除）的日志，含变更的属性。",
                ["change log", "audit log", "entity change"], ["变更日志", "审计日志", "实体变更"],
                fields: [
                    F("ChangeType", "Whether the change was an update, create, or delete.", "变更类型是更新、创建还是删除。"),
                ]),
            Content(
                "Monitor.API.Common.EntityPropertyChange",
                "The old and new value of a single property changed on an entity.",
                "实体上单个属性变更前的旧值和新值。",
                ["property change", "field change", "property history"], ["属性变更", "字段变更"],
                fields: [
                    F("ChangeType", "Whether the change was an update, create, or delete.", "变更类型是更新、创建还是删除。"),
                ]),

            // ---- ExtraFields -----------------------------------------------------------
            Content(
                "Monitor.API.Common.ExtraField",
                "An extra field value on an entity, defined by a template and typed by its value kind.",
                "实体上的附加字段值，由模板定义并按值类型区分。",
                ["extra field", "custom field", "user defined field"], ["附加字段", "自定义字段", "扩展字段"],
                fields: [
                    F("SelectedOption", "The selected option of an options-type extra field.", "选项型附加字段选中的选项。"),
                    F("SelectedOptions", "The selected options of a multi-options extra field.", "多选项附加字段选中的选项。"),
                    F("Comment", "A comment attached to the extra field.", "附加字段上的备注。"),
                ]),
            Content(
                "Monitor.API.Common.ExtraFieldGroup",
                "A group of extra-field templates shown together on an entity.",
                "在实体上一起显示的附加字段模板组。",
                ["extra field group", "field group"], ["附加字段组", "字段组"],
                fields: [
                    F("Templates", "The extra-field templates in the group.", "组内的附加字段模板。"),
                ]),
            Content(
                "Monitor.API.Common.ExtraFieldOptionTemplate",
                "A selectable option of an options-type extra-field template.",
                "选项型附加字段模板的可选选项。",
                ["extra field option", "option template"], ["附加字段选项", "选项模板"],
                fields: [
                    F("ExtraFieldTemplateId", "The extra-field template the option belongs to.", "选项所属的附加字段模板。"),
                ]),
            Content(
                "Monitor.API.Common.ExtraFieldTemplate",
                "A template defining an extra field: its type, options, and value kind.",
                "定义附加字段的模板：类型、选项与值种类。",
                ["extra field template", "field template", "custom field template"], ["附加字段模板", "字段模板", "自定义字段模板"],
                fields: [
                    F("Type", "The value type of the extra field (string, integer, decimal, date, options...).", "附加字段的值类型（文本、整数、小数、日期、选项等）。"),
                    F("ParentId", "The extra-field group the template belongs to.", "模板所属的附加字段组。"),
                    F("OptionTemplates", "The selectable options of the template.", "模板的可选选项。"),
                ]),

            // ---- Files ----------------------------------------------------------------
            Content(
                "Monitor.API.Common.FilePath",
                "A configured file path or storage location used for documents and file links.",
                "用于文档与文件链接的已配置文件路径或存储位置。",
                ["file path", "file storage", "sharepoint"], ["文件路径", "文件存储"],
                fields: [
                    F("Path", "The unique storage path.", "唯一的存储路径。"),
                    F("Category", "What the file path is used for (file viewer, accounting export, server printer...).", "文件路径的用途（文件查看器、会计导出、服务器打印机等）。"),
                    F("FileType", "Whether the path is a file system or SharePoint location.", "路径是文件系统还是 SharePoint 位置。"),
                    F("PathType", "How the path is accessed (local drive, UNC share, SharePoint...).", "路径的访问方式（本地驱动器、UNC 共享、SharePoint 等）。"),
                ]),

            // ---- Forms ----------------------------------------------------------------
            Content(
                "Monitor.API.Common.FormReportConfiguration",
                "A configuration of a form report type, such as a default or adapted layout.",
                "表单报告类型的配置，如默认或改制布局。",
                ["form report", "form configuration", "report configuration"], ["表单报告", "表单配置", "报告配置"],
                fields: [
                    F("Type", "The form report type the configuration applies to.", "配置适用的表单报告类型。"),
                ]),
            Content(
                "Monitor.API.Common.FormReportTranslation",
                "A translated phrase within a form-report translation group.",
                "表单报告翻译组中的一条翻译短语。",
                ["translation", "phrase translation"], ["翻译", "短语翻译"],
                fields: [
                    F("FormReportTranslationGroupId", "The translation group the phrase belongs to.", "短语所属的翻译组。"),
                ]),
            Content(
                "Monitor.API.Common.FormReportTranslationGroup",
                "A group of phrase translations used to render form reports in a language.",
                "用于以某种语言渲染表单报告的短语翻译组。",
                ["translation group", "form translation"], ["翻译组", "表单翻译"],
                fields: [
                    F("Code", "The unique code of the translation group.", "翻译组的唯一代码。"),
                    F("DocumentFont", "The document font used by the translation group.", "翻译组使用的单据字体。"),
                ]),
            Content(
                "Monitor.API.Common.FormTemplate",
                "A form template with rows of data fields, used for inspections and measuring data.",
                "含数据字段行的表单模板，用于检验与测量数据。",
                ["form template", "inspection template", "form"], ["表单模板", "检验模板"],
                fields: [
                    F("Code", "The unique code of the form template.", "表单模板的唯一代码。"),
                    F("Type", "Whether the form is used for manufacturing or purchase.", "表单用于制造还是采购。"),
                    F("ControlDataType", "Whether the template holds maintenance or measuring data.", "模板保存的是维护数据还是测量数据。"),
                    F("CommentId", "A comment on the form template.", "表单模板的备注。"),
                    F("Comment", "A comment on the form template.", "表单模板的备注。"),
                ]),
            Content(
                "Monitor.API.Common.FormTemplateRow",
                "A row of a form template: a data field with its type, boundaries, and unit.",
                "表单模板的行：数据字段，含类型、边界与单位。",
                ["form row", "template row"], ["表单行", "模板行"],
                fields: [
                    F("Type", "The value type of the row (decimal, text, checkbox, date).", "行的值类型（小数、文本、复选框、日期）。"),
                    F("FormTemplateSelectionRowId", "The selection row this row belongs to.", "该行所属的选择行。"),
                    F("MasterToolId", "The master tool (part) the row is measured against.", "该行测量所依据的主工具（物料）。"),
                    F("UnitId", "The unit of the row value.", "行值的单位。"),
                    F("CommentId", "A comment on the row.", "该行的备注。"),
                    F("Comment", "A comment on the row.", "该行的备注。"),
                ]),
            Content(
                "Monitor.API.Common.FormTemplateSelectionRow",
                "A selection row in a form template that groups data rows.",
                "表单模板中对数据行进行分组的选择行。",
                ["selection row", "form selection"], ["选择行", "表单选择行"],
                fields: [
                    F("Code", "The unique code of the selection row.", "选择行的唯一代码。"),
                    F("FormTemplateId", "The form template the selection row belongs to.", "选择行所属的表单模板。"),
                    F("CommentId", "A comment on the selection row.", "选择行的备注。"),
                    F("Comment", "A comment on the selection row.", "选择行的备注。"),
                ]),

            // ---- LanguageCodes ---------------------------------------------------------
            Content(
                "Monitor.API.Common.LanguageCode",
                "A language code used for user, customer, and document language settings.",
                "用于用户、客户与单据语言设置的语言代码。",
                ["language", "language code", "locale"], ["语言", "语言代码", "语言设置"],
                fields: [
                    F("Code", "The unique language code.", "唯一的语言代码。"),
                ]),

            // ---- MeasuringTemplates ----------------------------------------------------
            Content(
                "Monitor.API.Common.MeasuringTemplate",
                "A measuring-data template defining how and when measurements are taken.",
                "定义测量方式与测量时机的测量数据模板。",
                ["measuring template", "measurement template"], ["测量模板", "测量数据模板"],
                fields: [
                    F("Code", "The unique code of the measuring template.", "测量模板的唯一代码。"),
                    F("FormTemplateId", "The form template the measuring template is based on.", "测量模板所依据的表单模板。"),
                    F("MeasuringFrequency", "How often measurements are taken (first, last, all, sample...).", "测量的频率（首件、末件、全部、抽样等）。"),
                    F("Type", "Whether the template is used for manufacturing or purchase.", "模板用于制造还是采购。"),
                ]),

            // ---- MonitoringTasks -------------------------------------------------------
            Content(
                "Monitor.API.Common.MonitoringTask",
                "A monitoring task that watches a business condition and alerts recipients when it triggers.",
                "监视业务条件并在触发时提醒收件人的监控任务。",
                ["monitoring task", "alert", "notification task"], ["监控任务", "监视任务", "提醒任务"],
                fields: [
                    F("Number", "The unique number of the monitoring task.", "监控任务的唯一编号。"),
                    F("TaskType", "The business condition the task watches (stock balance, activity, arrival...).", "任务监视的业务条件（库存余额、活动、到货等）。"),
                    F("Status", "Whether the task is active or disabled.", "任务是启用还是禁用。"),
                    F("ApplicationUserId", "The user responsible for the task.", "负责该任务的用户。"),
                    F("ApplicationUser", "The user responsible for the task.", "负责该任务的用户。"),
                    F("CommentId", "A comment on the task.", "任务的备注。"),
                    F("Comment", "A comment on the task.", "任务的备注。"),
                ]),
            Content(
                "Monitor.API.Common.MonitoringTaskRecipient",
                "A recipient of a monitoring task's alerts, as an e-mail or notification recipient.",
                "监控任务告警的收件人，可为电子邮件或通知收件人。",
                ["task recipient", "monitoring recipient"], ["任务收件人", "监控收件人"],
                fields: [
                    F("TaskId", "The monitoring task the recipient belongs to.", "收件人所属的监控任务。"),
                    F("LanguageCodeId", "The language used for the recipient's messages.", "收件人消息使用的语言。"),
                    F("RecipientType", "How the recipient is reached (e-mail, notification, or user e-mail).", "联系收件人的方式（电子邮件、通知或用户电子邮件）。"),
                    F("ApplicationUserId", "The user recipient, when the recipient is a user.", "收件人为用户时的用户。"),
                ]),
            Content(
                "Monitor.API.Common.MonitoringTaskRow",
                "A condition row of a monitoring task: what entity and condition to watch.",
                "监控任务的条件行：监视的实体与条件。",
                ["task row", "monitoring condition"], ["任务行", "监控条件"],
                fields: [
                    F("TaskId", "The monitoring task the row belongs to.", "该行所属的监控任务。"),
                    F("Warehouses", "The warehouses the condition applies to.", "条件适用的仓库。"),
                ]),

            // ---- OrderTransferSettings -------------------------------------------------
            Content(
                "Monitor.API.Common.OrderTransferSetting",
                "The settings used when transferring orders between manufacturing and sales companies.",
                "在制造公司与销售公司之间传输订单时使用的设置。",
                ["order transfer", "transfer settings"], ["订单传输", "传输设置"]),

            // ---- PartConfigurations ----------------------------------------------------
            Content(
                "Monitor.API.Common.PartConfiguration",
                "A saved configuration of a part built from a configuration session.",
                "从配置会话保存的物料配置。",
                ["part configuration", "configurator"], ["物料配置", "配置器"],
                fields: [
                    F("ResultId", "The configuration result of the part.", "物料的配置结果。"),
                    F("CommentId", "A comment on the configuration.", "配置的备注。"),
                    F("Comment", "A comment on the configuration.", "配置的备注。"),
                ]),
            Content(
                "Monitor.API.Common.PartConfigurationPreset",
                "A saved preset of a part configuration, for reusing configuration settings.",
                "物料配置的已保存预设，用于复用配置设置。",
                ["configuration preset", "config preset"], ["配置预设", "配置预置"],
                fields: [
                    F("PartConfigurationId", "The part configuration the preset is based on.", "预设所依据的物料配置。"),
                    F("ChangedBy", "The user who last changed the preset.", "最后更改预设的用户。"),
                    F("CreatedBy", "The user who created the preset.", "创建预设的用户。"),
                    F("Type", "Whether the preset is normal or temporary.", "预设是普通还是临时。"),
                ]),
            Content(
                "Monitor.API.Common.PartConfigurationResult",
                "The result of configuring a part: the selected configuration with its price.",
                "物料配置的结果：所选配置及其价格。",
                ["configuration result", "config result"], ["配置结果", "物料配置结果"],
                fields: [
                    F("TemplateId", "The configuration template used.", "使用的配置模板。"),
                    F("MainPartId", "The main part being configured.", "正在配置的主物料。"),
                    F("UnitPriceCurrencyId", "The currency of the unit price.", "单价的货币。"),
                    F("StandardPriceCurrencyId", "The currency of the standard price.", "标准价格的货币。"),
                    F("UnitPriceInCompanyCurrencyCurrencyId", "The currency of the unit price in company currency.", "按公司货币计价的单价的货币。"),
                    F("SnapshotId", "The template snapshot the result was based on.", "结果所依据的模板快照。"),
                    F("PartConfigurationId", "The part configuration the result belongs to.", "结果所属的物料配置。"),
                    F("PartCalculationId", "The part calculation the result belongs to.", "结果所属的物料计算。"),
                ]),
            Content(
                "Monitor.API.Common.PartConfigurationSelectionGroupResult",
                "The selected quantity of a selection group row in a part configuration result.",
                "物料配置结果中某选择组行的已选数量。",
                ["selection group result", "config selection"], ["选择组结果", "配置选择结果"]),
            Content(
                "Monitor.API.Common.PartConfigurationTemplate",
                "A template defining the variables and selection groups of a part configuration.",
                "定义物料配置变量与选择组的模板。",
                ["configuration template", "config template"], ["配置模板", "物料配置模板"],
                fields: [
                    F("CommentId", "A comment on the template.", "模板的备注。"),
                    F("Comment", "A comment on the template.", "模板的备注。"),
                ]),

            // ---- PartUnits ------------------------------------------------------------
            Content(
                "Monitor.API.Common.PartUnitUsage",
                "The usage of a unit for a part: where the unit applies and its conversion factor.",
                "物料单位的用途：单位适用的场景及其换算系数。",
                ["unit usage", "part unit"], ["单位用途", "物料单位"],
                fields: [
                    F("UsageType", "Where the unit is used (material withdrawal, purchase, arrival, delivery...).", "单位的使用场景（物料领用、采购、到货、交货等）。"),
                ]),
            Content(
                "Monitor.API.Common.PartialQuantity",
                "A partial quantity of a package part: quantity and number of items.",
                "包装物料的零头数量：数量与件数。",
                ["partial quantity", "fractional quantity"], ["零头数量", "部分数量"],
                fields: [
                    F("PackagePartId", "The package part the partial quantity refers to.", "零头数量对应的包装物料。"),
                ]),

            // ---- Payments -------------------------------------------------------------
            Content(
                "Monitor.API.Common.PaymentMethod",
                "A payment method defining how incoming and outgoing payments are handled.",
                "定义收款与付款处理方式的付款方式。",
                ["payment method", "payment", "bank payment"], ["付款方式", "支付方式"],
                fields: [
                    F("Code", "The unique code of the payment method.", "付款方式的唯一代码。"),
                    F("PaymentType", "How the payment is made (manual, electronic, cash, bank integration...).", "付款方式（手工、电子、现金、银行集成等）。"),
                    F("CodingAccountCodingEntry", "The coding entry used when coding the payment account.", "为付款账户记账时使用的记账条目。"),
                    F("BankingFeeCodingEntry", "The coding entry used for banking fees.", "银行手续费使用的记账条目。"),
                    F("ReceivingBankAccountValidation", "Whether a missing receiving bank account warns or blocks.", "缺少收款银行账户时是警告还是阻止。"),
                    F("ReceivingGiroAccountValidation", "Whether a missing receiving giro account warns or blocks.", "缺少收款转账户时是警告还是阻止。"),
                ]),
            Content(
                "Monitor.API.Common.PaymentPlanTemplate",
                "A payment plan template with its rows, used to create installment plans.",
                "含行的付款计划模板，用于创建分期付款计划。",
                ["payment plan", "installment template", "payment template"], ["付款计划", "分期付款模板"],
                fields: [
                    F("Number", "The unique number of the payment plan template.", "付款计划模板的唯一编号。"),
                    F("PaymentPlanTemplateType", "Whether the template is for sales, purchase, or both.", "模板用于销售、采购还是两者。"),
                    F("InvoiceTextTypes", "The text sections included on invoices generated from the plan.", "计划生成的发票上包含的文本部分。"),
                    F("PaymentPlanTemplateRows", "The payment plan rows of the template.", "模板的付款计划行。"),
                ]),
            Content(
                "Monitor.API.Common.PaymentPlanTemplateRow",
                "A row of a payment plan template: an installment with its fraction and term.",
                "付款计划模板的行：一期分期及其比例与条款。",
                ["payment plan row", "installment row"], ["付款计划行", "分期行"],
                fields: [
                    F("PartialInvoiceType", "When the installment is invoiced (in advance, at delivery, in arrears...).", "分期开票的时点（预付、交货时、欠款等）。"),
                    F("Part", "The part the installment refers to, when partial.", "分期涉及的物料（如为部分）。"),
                    F("PaymentTerm", "The payment term of the installment.", "分期的付款条款。"),
                    F("UnpaidAdvanceWarningType", "How a missing advance payment is handled (none, warning, or block delivery).", "未收到预付款时的处理方式（不处理、警告或阻止交货）。"),
                ]),
            Content(
                "Monitor.API.Common.PaymentTerm",
                "A payment term defining when payment is due, with its grace period and method.",
                "定义到期付款时间的付款条款，含宽限期与方式。",
                ["payment term", "terms of payment", "credit terms"], ["付款条款", "付款条件"],
                fields: [
                    F("Method", "How the due date is calculated (days, free delivery month, end of month).", "到期日的计算方式（天数、免运费月份、月末）。"),
                    F("InvoiceType", "The invoice type the payment term is used for.", "付款条款适用的发票类型。"),
                ]),

            // ---- Permissions -----------------------------------------------------------
            Content(
                "Monitor.API.Common.Permission",
                "A permission on an entity or role, with its allow/deny state.",
                "实体或角色上的权限，含允许/拒绝状态。",
                ["permission", "access right"], ["权限", "访问权限"]),
            Content(
                "Monitor.API.Common.PermissionGroup",
                "A group of permissions that can be granted to a user.",
                "可授予用户的一组权限。",
                ["permission group", "permission set"], ["权限组", "权限集"],
                fields: [
                    F("Permissions", "The permissions in the group.", "组内的权限。"),
                ]),

            // ---- Persons --------------------------------------------------------------
            Content(
                "Monitor.API.Common.Person",
                "A person in MONITOR — an employee with contact details, employment, and access settings.",
                "MONITOR 中的人员 —— 员工，含联系方式、任职与访问设置。",
                ["person", "employee", "staff", "contact person"], ["人员", "员工", "职员", "联系人"],
                fields: [
                    F("EmployeeNumber", "The unique employee number of the person.", "人员唯一的员工编号。"),
                    F("BlockedContextType", "The context in which the person is blocked, if any.", "人员被封锁的上下文（如有）。"),
                    F("Comment", "A comment on the person.", "人员的备注。"),
                    F("Address", "The address of the person.", "人员的地址。"),
                    F("EmployeeRecordingType", "How the employee records time (attendance and work, or work only).", "员工记录时间的方式（考勤与作业或仅作业）。"),
                    F("ScheduleManagementType", "How the person's schedule is managed (none or schedule cycle).", "人员排班的管理方式（无或排班周期）。"),
                    F("WorkMethod", "How the person reports work (only changes or free start/finish).", "人员上报作业的方式（仅变更或自由起止）。"),
                    F("Signature", "The signature image of the person.", "人员的签名图片。"),
                    F("ManufacturingPrintSettings", "The manufacturing print settings of the person.", "人员的制造打印设置。"),
                    F("PlannedAbsences", "The planned absences of the person.", "人员的计划缺勤。"),
                    F("TimeBanks", "The time bank balances of the person.", "人员的工时银行余额。"),
                    F("Relatives", "The relatives of the person.", "人员的亲属。"),
                    F("EmploymentPeriods", "The employment periods of the person.", "人员的受雇期间。"),
                    F("ExtraFields", "The extra field values of the person.", "人员的附加字段值。"),
                    F("AvailableWorkshopSchedules", "The workshop schedules available to the person.", "人员可用的车间排班。"),
                    F("AvailableWorkCenters", "The work centers available to the person.", "人员可用的工作中心。"),
                    F("PersonScheduleCycles", "The schedule cycles assigned to the person.", "分配给人员的排班周期。"),
                    F("AttendanceRecordingAuthorizers", "The users authorized to record attendance for the person.", "被授权为人员记录考勤的用户。"),
                ]),
            Content(
                "Monitor.API.Common.PersonManufacturingPrintSettings",
                "The manufacturing document print settings of a person.",
                "人员的制造单据打印设置。",
                ["manufacturing print settings", "print settings"], ["制造打印设置", "打印设置"]),
            Content(
                "Monitor.API.Manufacturing.WorkCenterManufacturingPrintSettings",
                "The manufacturing document print settings of a work center.",
                "工作中心的制造单据打印设置。",
                ["work center print settings", "manufacturing print settings"], ["工作中心打印设置", "制造打印设置"]),
            Content(
                "Monitor.API.Common.PersonRelative",
                "A relative of a person.",
                "人员的亲属。",
                ["relative", "family member"], ["亲属", "家属"]),
            Content(
                "Monitor.API.Common.Commands.Persons.AttendanceRecordingAuthorizer",
                "A user authorized to record or adjust attendance for a person.",
                "被授权为人员记录或调整考勤的用户。",
                ["attendance authorizer", "attendance recording"], ["考勤授权人", "考勤记录授权"],
                fields: [
                    F("ApplicationUser", "The authorized user.", "被授权的用户。"),
                    F("AuthorizationType", "The authorization role (not allowed, main, or second authorizer).", "授权角色（不允许、主授权人或次授权人）。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Persons.PersonScheduleCycle",
                "A schedule cycle assigned to a person, with its start date.",
                "分配给人员的排班周期，含开始日期。",
                ["person schedule", "schedule cycle", "rota"], ["人员排班", "排班周期", "轮班"],
                fields: [
                    F("WorkshopScheduleCycle", "The workshop schedule cycle assigned.", "分配的车间排班周期。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Persons.WorkshopScheduleCycle",
                "A workshop schedule cycle defining a recurring work schedule.",
                "定义重复工作排班的车间排班周期。",
                ["workshop schedule", "work schedule cycle"], ["车间排班", "工作排班周期"]),

            // ---- Pricing --------------------------------------------------------------
            Content(
                "Monitor.API.Common.PriceList",
                "A price list defining how prices are derived, with its basis and currency.",
                "定义价格推导方式的价目表，含基准与货币。",
                ["price list", "pricelist"], ["价目表", "价格表"],
                fields: [
                    F("PriceListBasis", "The basis of the prices (parent price list or standard price).", "价格的基准（父价目表或标准价格）。"),
                ]),
            Content(
                "Monitor.API.Common.Probability",
                "The probability percentages used for business opportunities.",
                "用于商机的成功概率百分比。",
                ["probability", "win probability"], ["成功概率", "概率"]),
            Content(
                "Monitor.API.Common.ProductGroup",
                "A product group used to classify parts and drive pricing, VAT, and coding.",
                "用于对物料分类并驱动定价、增值税与记账的产品组。",
                ["product group", "product class", "commodity group"], ["产品组", "产品类别", "商品组"],
                fields: [
                    F("Number", "The unique number of the product group.", "产品组的唯一编号。"),
                ]),
            Content(
                "Monitor.API.Common.StaggeredPrice",
                "A tiered price for a part or link, with its lower-boundary quantity.",
                "物料或链接的阶梯价格，含下边界数量。",
                ["staggered price", "tiered price", "price scale"], ["阶梯价格", "分级价格"]),

            // ---- Projects -------------------------------------------------------------
            Content(
                "Monitor.API.Common.Project",
                "A project with its phases, activities, costs, and reporting, used for planning and follow-up.",
                "项目，含阶段、活动、成本与上报，用于计划与跟进。",
                ["project", "project number"], ["项目", "项目编号"],
                fields: [
                    F("Status", "The status of the project (registered, in progress, finished, standby, history).", "项目状态（已登记、进行中、已完成、待命、历史）。"),
                    F("CustomerId", "The customer the project belongs to.", "项目所属的客户。"),
                    F("CustomerOrderId", "The customer order the project is linked to.", "与项目关联的客户订单。"),
                    F("CustomerOrder", "The customer order the project is linked to.", "与项目关联的客户订单。"),
                    F("SellerId", "The seller responsible for the project.", "负责项目的销售员。"),
                    F("Seller", "The seller responsible for the project.", "负责项目的销售员。"),
                    F("OurReferenceId", "Our reference (person) for the project.", "项目的我方联系人（人员）。"),
                    F("OurReference", "Our reference (person) for the project.", "项目的我方联系人（人员）。"),
                    F("CustomerReferenceId", "The customer's reference for the project.", "项目的客户联系人。"),
                    F("CustomerReference", "The customer's reference for the project.", "项目的客户联系人。"),
                    F("InternalComment", "The internal comment of the project.", "项目的内部备注。"),
                    F("ExternalCommentId", "The external comment of the project.", "项目的外部备注。"),
                    F("ExternalComment", "The external comment of the project.", "项目的外部备注。"),
                    F("ExtraFields", "The extra field values of the project.", "项目的附加字段值。"),
                    F("Phases", "The phases of the project.", "项目的阶段。"),
                    F("ProjectTypeId", "The project type of the project.", "项目的项目类型。"),
                    F("ProjectType", "The project type of the project.", "项目的项目类型。"),
                    F("ProjectGroupId", "The project group of the project.", "项目的项目组。"),
                    F("ProjectGroup", "The project group of the project.", "项目的项目组。"),
                    F("ProjectCostBudgets", "The cost budgets of the project.", "项目的成本预算。"),
                    F("ProjectCostForecasts", "The cost forecasts of the project.", "项目的成本预测。"),
                    F("ProjectAggregates", "The cost aggregates of the project.", "项目的成本汇总。"),
                    F("ParentProjectId", "The parent project, when the project is a sub-project.", "父项目（当项目为子项目时）。"),
                    F("ProjectManagerId", "The project manager of the project.", "项目的项目经理。"),
                ]),
            Content(
                "Monitor.API.Common.ProjectActivity",
                "An activity within a project phase, with its planned and reported time.",
                "项目阶段内的活动，含计划与实际时间。",
                ["project activity", "activity"], ["项目活动", "活动"],
                fields: [
                    F("Status", "The status of the activity (registered, in progress, history).", "活动状态（已登记、进行中、历史）。"),
                    F("ActivityType", "The activity type the activity is based on.", "活动所依据的活动类型。"),
                    F("Comment", "A comment on the activity.", "活动的备注。"),
                ]),
            Content(
                "Monitor.API.Common.ProjectActivityCalendarAppointment",
                "A calendar appointment linked to a project activity.",
                "与项目活动关联的日历约见。",
                ["calendar appointment", "activity appointment"], ["日历约见", "活动约见"],
                fields: [
                    F("ProjectActivityId", "The project activity the appointment belongs to.", "约见所属的项目活动。"),
                    F("SenderPersonId", "The person who created the appointment.", "创建约见的人员。"),
                ]),
            Content(
                "Monitor.API.Common.ProjectActivityRelation",
                "A dependency between project activities: when the dependent activity must start.",
                "项目活动之间的依赖关系：被依赖活动必须的开始条件。",
                ["activity relation", "activity dependency", "predecessor"], ["活动关系", "活动依赖", "前置活动"],
                fields: [
                    F("ParentId", "The activity that depends on the other.", "依赖其他活动的活动。"),
                    F("DependentOnEntityId", "The activity the parent depends on.", "父活动所依赖的活动。"),
                    F("Type", "Whether the dependency is on finished-before-start or started-before-start.", "依赖条件是完成后开始还是开始后开始。"),
                ]),
            Content(
                "Monitor.API.Common.ProjectActivityType",
                "An activity type defining defaults for project activities, such as time and reporting.",
                "为项目活动定义时间与上报等默认值的活动类型。",
                ["activity type", "project activity type"], ["活动类型", "项目活动类型"],
                fields: [
                    F("Code", "The unique code of the activity type.", "活动类型的唯一代码。"),
                    F("Comment", "A comment on the activity type.", "活动类型的备注。"),
                ]),
            Content(
                "Monitor.API.Common.ProjectAggregate",
                "The expected and actual result of a project cost type: time, cost, and income.",
                "项目成本类型的预期与实际结果：时间、成本与收入。",
                ["project aggregate", "project result"], ["项目汇总", "项目结果"],
                fields: [
                    F("ProjectId", "The project the aggregate belongs to.", "汇总所属的项目。"),
                    F("CostTypeId", "The cost type the aggregate covers.", "汇总涵盖的成本类型。"),
                ]),
            Content(
                "Monitor.API.Common.ProjectCostBudget",
                "The budgeted hours, cost, and income of a project cost type.",
                "项目成本类型的预算工时、成本与收入。",
                ["cost budget", "project budget"], ["成本预算", "项目预算"],
                fields: [
                    F("ProjectId", "The project the budget belongs to.", "预算所属的项目。"),
                    F("CostTypeId", "The cost type the budget covers.", "预算涵盖的成本类型。"),
                    F("CommentId", "A comment on the budget.", "预算的备注。"),
                    F("Comment", "A comment on the budget.", "预算的备注。"),
                ]),
            Content(
                "Monitor.API.Common.ProjectCostForecast",
                "The forecast hours, cost, and income of a project cost type.",
                "项目成本类型的预测工时、成本与收入。",
                ["cost forecast", "project forecast"], ["成本预测", "项目预测"],
                fields: [
                    F("ProjectId", "The project the forecast belongs to.", "预测所属的项目。"),
                    F("CostTypeId", "The cost type the forecast covers.", "预测涵盖的成本类型。"),
                    F("CommentId", "A comment on the forecast.", "预测的备注。"),
                    F("Comment", "A comment on the forecast.", "预测的备注。"),
                ]),
            Content(
                "Monitor.API.Common.ProjectCostReportingEntry",
                "A cost-reporting entry on a project: reported time or amount against a cost type.",
                "项目上的成本上报条目：针对某成本类型上报的时间或金额。",
                ["cost reporting", "cost entry", "project reporting"], ["成本上报", "成本条目", "项目上报"],
                fields: [
                    F("ProjectId", "The project the entry belongs to.", "条目所属的项目。"),
                    F("ActivityId", "The activity the entry is reported against.", "条目上报所针对的活动。"),
                    F("CostTypeId", "The cost type the entry is reported against.", "条目上报所针对的成本类型。"),
                    F("EmployeeId", "The employee who reported the entry.", "上报该条目的员工。"),
                    F("WorkCenterId", "The work center the entry was reported against.", "条目上报所针对的工作中心。"),
                    F("DepartmentId", "The department the entry was reported against.", "条目上报所针对的部门。"),
                    F("OurReferenceId", "Our reference (person) for the entry.", "条目的我方联系人（人员）。"),
                    F("CommentId", "A comment on the entry.", "条目的备注。"),
                    F("Comment", "A comment on the entry.", "条目的备注。"),
                ]),
            Content(
                "Monitor.API.Common.ProjectCostType",
                "A project cost type, classified as cost or income.",
                "项目成本类型，分为成本或收入。",
                ["cost type", "project cost type"], ["成本类型", "项目成本类型"],
                fields: [
                    F("Number", "The unique number of the cost type.", "成本类型的唯一编号。"),
                    F("Type", "Whether the type is a cost or income type.", "类型是成本还是收入。"),
                ]),
            Content(
                "Monitor.API.Common.ProjectGroup",
                "A group of projects, used for follow-up and aggregation.",
                "项目组，用于跟进与汇总。",
                ["project group", "project collection"], ["项目组", "项目分组"],
                fields: [
                    F("Number", "The unique number of the project group.", "项目组的唯一编号。"),
                ]),
            Content(
                "Monitor.API.Common.ProjectPhase",
                "A phase of a project, grouping its activities.",
                "项目的阶段，对其活动进行分组。",
                ["project phase", "phase"], ["项目阶段", "阶段"],
                fields: [
                    F("PhaseType", "The phase type the phase is based on.", "阶段所依据的阶段类型。"),
                    F("Activities", "The activities of the phase.", "阶段的各项活动。"),
                ]),
            Content(
                "Monitor.API.Common.ProjectPhaseType",
                "A phase type defining defaults for project phases.",
                "为项目阶段定义默认值的阶段类型。",
                ["phase type", "project phase type"], ["阶段类型", "项目阶段类型"]),
            Content(
                "Monitor.API.Common.ProjectType",
                "A project type defining defaults for new projects.",
                "为新项目定义默认值的项目类型。",
                ["project type"], ["项目类型"]),

            // ---- ReasonCodes / RejectionCodes -----------------------------------------
            Content(
                "Monitor.API.Common.ReasonCode",
                "The reason codes used for stock movements and adjustments.",
                "用于库存移动与调整的原因代码。",
                ["reason code", "adjustment reason", "stock reason"], ["原因代码", "调整原因", "库存原因"],
                fields: [
                    F("Code", "The unique code of the reason.", "原因的唯一代码。"),
                    F("Type", "Which document types the reason applies to (purchase order, manufacturing order).", "原因适用的单据类型（采购订单、制造订单）。"),
                ]),
            Content(
                "Monitor.API.Common.ReasonCodeDebitNote",
                "The reason codes used for debit notes.",
                "用于借项通知单的原因代码。",
                ["debit note reason", "reason code debit note"], ["借项原因", "借项通知单原因"],
                fields: [
                    F("Code", "The unique code of the reason.", "原因的唯一代码。"),
                ]),
            Content(
                "Monitor.API.Common.RejectionCodeItem",
                "The rejection codes used when reporting nonconformities in manufacturing and purchasing.",
                "在制造与采购上报不合格品时使用的拒收代码。",
                ["rejection code", "nonconformity code", "scrap code"], ["拒收代码", "不合格代码", "报废代码"],
                fields: [
                    F("Code", "The unique code of the rejection.", "拒收的唯一代码。"),
                    F("Type", "The nonconformity contexts the code applies to.", "代码适用的不合格情境。"),
                ]),

            // ---- RemotePartConfigurations ----------------------------------------------
            Content(
                "Monitor.API.Common.RemotePartConfiguration",
                "A part configuration held in a remote (sales) company.",
                "保存在远程（销售）公司的物料配置。",
                ["remote part configuration", "remote configuration"], ["远程物料配置", "远程配置"],
                fields: [
                    F("PartConfigurationIdInRemoteCompany", "The part configuration in the remote company.", "远程公司中的物料配置。"),
                    F("Rows", "The price rows of the remote configuration.", "远程配置的价格行。"),
                ]),
            Content(
                "Monitor.API.Common.RemotePartConfigurationRow",
                "A price row of a remote part configuration, with its price and discount.",
                "远程物料配置的价格行，含价格与折扣。",
                ["remote configuration row", "remote price row"], ["远程配置行", "远程价格行"]),

            // ---- Resellers ------------------------------------------------------------
            Content(
                "Monitor.API.Common.Reseller",
                "A reseller that distributes the company's products, with its provision.",
                "经销公司产品的经销商，含佣金比例。",
                ["reseller", "dealer", "distributor"], ["经销商", "分销商", "代理"],
                fields: [
                    F("Code", "The unique code of the reseller.", "经销商的唯一代码。"),
                ]),

            // ---- Revisions ------------------------------------------------------------
            Content(
                "Monitor.API.Common.Revision",
                "A revision of a part, with its validity start date.",
                "物料的修订版，含生效起始日期。",
                ["revision"], ["修订", "修订版", "物料修订"],
                fields: [
                    F("Number", "The unique revision number.", "唯一的修订号。"),
                    F("Comment", "A comment on the revision.", "修订的备注。"),
                ]),

            // ---- Roles ----------------------------------------------------------------
            Content(
                "Monitor.API.Common.Role",
                "A user role grouping permissions.",
                "对权限进行分组的用户角色。",
                ["role", "user role"], ["角色", "用户角色"]),

            // ---- ServerPrinters -------------------------------------------------------
            Content(
                "Monitor.API.Common.ServerPrinter",
                "A server printer available to MONITOR for printing documents.",
                "MONITOR 用于打印单据的服务器打印机。",
                ["server printer", "printer"], ["服务器打印机", "打印机"],
                fields: [
                    F("Number", "The unique number of the printer.", "打印机的唯一编号。"),
                    F("Orientation", "The default print orientation.", "默认打印方向。"),
                    F("DuplexMode", "The duplex printing mode.", "双面打印模式。"),
                    F("PaperSize", "The paper size used for printing.", "打印使用的纸张尺寸。"),
                    F("ColorMode", "Whether the printer prints in color or black and white.", "打印机是彩色还是黑白打印。"),
                ]),

            // ---- StatisticalGoodsCodes ------------------------------------------------
            Content(
                "Monitor.API.Common.StatisticalGoodsCode",
                "The statistical goods codes used for customs and intrastat declarations.",
                "用于海关与欧盟内贸易统计申报的统计货物代码。",
                ["statistical code", "intrastat code", "customs code"], ["统计代码", "统计货物代码"],
                fields: [
                    F("Code", "The unique statistical goods code.", "唯一的统计货物代码。"),
                    F("DeclarationType", "How the goods are declared (weight, other quantity, or both).", "货物申报的方式（重量、其他数量或两者）。"),
                ]),

            // ---- Tags -----------------------------------------------------------------
            Content(
                "Monitor.API.Common.Tag",
                "A tag attached to a record, used for grouping and search.",
                "附加到记录上的标签，用于分组与搜索。",
                ["tag", "label"], ["标签", "标记"]),

            // ---- TariffAndServiceCodes ------------------------------------------------
            Content(
                "Monitor.API.Common.TariffAndServiceCode",
                "The tariff and service codes used to classify sales, services, and purchases.",
                "用于对销售、服务与采购进行分类的关税与服务代码。",
                ["tariff code", "service code", "hs code"], ["关税代码", "服务代码", "HS编码"],
                fields: [
                    F("Code", "The unique tariff or service code.", "唯一的关税或服务代码。"),
                    F("Type", "Whether the code is used for sales, services, or purchase.", "代码用于销售、服务还是采购。"),
                ]),

            // ---- TransactionTypeIntrastat ---------------------------------------------
            Content(
                "Monitor.API.Common.TransactionTypeIntrastat",
                "The intrastat transaction types used in EU trade declarations.",
                "欧盟内贸易统计申报使用的交易类型。",
                ["intrastat transaction type", "transaction type"], ["欧盟贸易交易类型", "交易类型"],
                fields: [
                    F("Number", "The unique number of the transaction type.", "交易类型的唯一编号。"),
                ]),

            // ---- TransferProfiles -----------------------------------------------------
            Content(
                "Monitor.API.Common.TransferProfile",
                "A transfer profile linking a manufacturing company to a sales company for order and part transfers.",
                "连接制造公司与销售公司以传输订单和物料的传输配置文件。",
                ["transfer profile", "transfer"], ["传输配置文件", "传输配置"],
                fields: [
                    F("Number", "The unique number of the transfer profile.", "传输配置文件的唯一编号。"),
                    F("Usages", "What the profile transfers (customer order, part synchronization, part information).", "配置文件传输的内容（客户订单、物料同步、物料信息）。"),
                    F("TargetRole", "The role of the target company (manufacturing or sales).", "目标公司的角色（制造或销售）。"),
                    F("ConnectionProfileId", "The connection profile used for the transfer.", "传输使用的连接配置文件。"),
                    F("RemoteWarehouseId", "The remote warehouse the profile maps to.", "配置文件映射到的远程仓库。"),
                    F("OrderTransferSettingsId", "The order transfer settings used by the profile.", "配置文件使用的订单传输设置。"),
                    F("SupplierId", "The supplier used for the transfer, when applicable.", "传输使用的供应商（如适用）。"),
                ]),

            // ---- Units ----------------------------------------------------------------
            Content(
                "Monitor.API.Common.Unit",
                "A unit of measure used for parts, quantities, and reporting.",
                "用于物料、数量与上报的计量单位。",
                ["unit", "unit of measure", "uom"], ["单位", "计量单位", "度量单位"]),

            // ---- VAT ------------------------------------------------------------------
            Content(
                "Monitor.API.Common.VatGroup",
                "A VAT group linking default VAT rates for purchase and sales.",
                "关联采购与销售默认增值税率的增值税组。",
                ["vat group", "tax group"], ["增值税组", "税务组"],
                fields: [
                    F("Number", "The unique number of the VAT group.", "增值税组的唯一编号。"),
                ]),
            Content(
                "Monitor.API.Common.VatRate",
                "A VAT rate with its percentage, accounts, and EC sales type.",
                "增值税率，含百分比、科目与欧盟销售类型。",
                ["vat rate", "tax rate", "vat", "tax"], ["增值税率", "税率", "增值税"],
                fields: [
                    F("Number", "The unique number of the VAT rate.", "增值税率的唯一编号。"),
                    F("OutputVatAccountId", "The account used for output VAT.", "销项增值税使用的科目。"),
                    F("InputVatAccountId", "The account used for input VAT.", "进项增值税使用的科目。"),
                    F("EcSalesType", "How EC sales are declared (goods, services, or third-party trade).", "欧盟销售的申报方式（货物、服务或第三方贸易）。"),
                    F("CodeType", "Whether the rate is used for sales, purchase, or neither.", "税率用于销售、采购或两者皆非。"),
                    F("ReferenceText", "The reference text on invoices using this rate.", "使用该税率的发票上的参考文本。"),
                ]),

            // ---- Warehouses -----------------------------------------------------------
            Content(
                "Monitor.API.Common.Warehouse",
                "A warehouse where stock is held, with its language, calendar, and delivery addresses.",
                "存放库存的仓库，含语言、日历与交货地址。",
                ["warehouse", "storage", "plant"], ["仓库", "库房", "工厂"],
                fields: [
                    F("Code", "The unique code of the warehouse.", "仓库的唯一代码。"),
                    F("Calendar", "The working-days calendar of the warehouse.", "仓库的工作日历。"),
                    F("DeliveryAddresses", "The delivery addresses of the warehouse.", "仓库的交货地址。"),
                ]),
            Content(
                "Monitor.API.Common.WarehousePermission",
                "The permissions a user has in a warehouse.",
                "用户在某仓库中的权限。",
                ["warehouse permission", "warehouse access"], ["仓库权限", "仓库访问权限"],
                fields: [
                    F("PermissionGroups", "The permission groups granted in the warehouse.", "在该仓库中授予的权限组。"),
                    F("Roles", "The roles granted in the warehouse.", "在该仓库中授予的角色。"),
                    F("Permissions", "The permissions granted in the warehouse.", "在该仓库中授予的权限。"),
                ]),

            // ---- WriteOffCodes --------------------------------------------------------
            Content(
                "Monitor.API.Common.WriteOffCode",
                "The write-off codes used when coding incoming and outgoing payments.",
                "为收付款记账时使用的核销代码。",
                ["write off code", "writeoff code", "write-off"], ["核销代码", "核销码"],
                fields: [
                    F("Code", "The unique code of the write-off.", "核销的唯一代码。"),
                    F("IncomingPaymentCodingEntryId", "The coding entry used for incoming payments.", "收款使用的记账条目。"),
                    F("IncomingPaymentCodingEntry", "The coding entry used for incoming payments.", "收款使用的记账条目。"),
                    F("OutgoingPaymentCodingEntryId", "The coding entry used for outgoing payments.", "付款使用的记账条目。"),
                    F("OutgoingPaymentCodingEntry", "The coding entry used for outgoing payments.", "付款使用的记账条目。"),
                ]),
        ];
    }
}
