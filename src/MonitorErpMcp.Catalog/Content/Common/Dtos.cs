namespace MonitorErpMcp.Catalog.Content.Common
{
    // The using-static sits inside the namespace so the imported Content(...) builder binds before
    // the enclosing MonitorErpMcp.Catalog.Content namespace in simple-name lookup.
    using static MonitorErpMcp.Catalog.Content.ContentEntryFactory;

    /// <summary>
    /// Hand-authored content for Common dto records: bilingual field descriptions for the request
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
                "Monitor.API.Common.Commands.AutoCompletes.AutoCompleteRequest",
                fields: [
                    F("SortOrder", "Whether results sort ascending or descending.", "结果按升序还是降序排列。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.CategoryComponent.AddCategoryComponentValue",
                fields: [
                    F("Description", "A description of the category value.", "类别值的描述。"),
                    F("Value", "The category value.", "类别值。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.CategoryComponent.UpdateCategoryComponentValue",
                fields: [
                    F("Id", "The category value to update.", "要更新的类别值。"),
                    F("Description", "A description of the category value.", "类别值的描述。"),
                    F("Value", "The category value.", "类别值。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.CustomReports.AddCustomReportParameter",
                fields: [
                    F("Name", "The name of the report parameter.", "报告参数的名称。"),
                    F("EntityId", "The entity the parameter references, when applicable.", "参数引用的实体（如适用）。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.CustomReports.AddCustomReportRestriction",
                fields: [
                    F("Column", "The column the restriction applies to.", "限制适用的列。"),
                    F("From", "The lower bound of the restriction.", "限制的下界。"),
                    F("To", "The upper bound of the restriction.", "限制的上界。"),
                    F("Exclude", "Whether the range is excluded instead of included.", "是否排除该范围。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Emails.AddEmailAttachment",
                fields: [
                    F("FilePathId", "The file path of an existing file; give either this or Data.", "已有文件的文件路径；本字段与 Data 二选一。"),
                    F("FileName", "The name of the attachment.", "附件的名称。"),
                    F("Data", "The file content; give either this or FilePathId.", "文件内容；本字段与 FilePathId 二选一。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Emails.EntityEmails.EmailAttachmentInformation",
                fields: [
                    F("FilePathId", "The file path of an existing file; give either this or Data.", "已有文件的文件路径；本字段与 Data 二选一。"),
                    F("FileName", "The name of the attachment.", "附件的名称。"),
                    F("Data", "The file content; give either this or FilePathId.", "文件内容；本字段与 FilePathId 二选一。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Emails.EntityEmails.EmailInformation",
                fields: [
                    F("Status", "Whether the e-mail is incoming or outgoing.", "邮件是接收还是发送。"),
                    F("Sender", "The sender address of the e-mail.", "邮件的发件人地址。"),
                    F("To", "The recipient address; required when no CC or BCC is given.", "收件人地址；未提供抄送或密送时必填。"),
                    F("Attachments", "The attachments of the e-mail.", "邮件的附件。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Emails.SetEmailContents",
                fields: [
                    F("To", "The primary recipients.", "主要收件人。"),
                    F("CarbonCopies", "The carbon-copy recipients.", "抄送收件人。"),
                    F("BlindCarbonCopies", "The blind-carbon-copy recipients.", "密送收件人。"),
                    F("Subject", "The subject of the e-mail.", "邮件的主题。"),
                    F("Attachments", "The attachments of the e-mail.", "邮件的附件。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.PartConfigurations.Dto.ConfigurationCommentUpdate",
                fields: [
                    F("SelectionCommentDocumentOverrides", "The documents the selection comment overrides (customer order, manufacturing order, purchase order).", "选择备注覆盖的单据（客户订单、制造工单、采购订单）。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.PartConfigurations.Dto.SelectionGroupRowUpdate",
                fields: [
                    F("SelectionGroupRowId", "The selection-group row to update.", "要更新的选择组行。"),
                    F("CloneId", "The row to clone the update from; the original is 0.", "从其克隆更新的行；原行为 0。"),
                    F("SelectionLocking", "Whether the selection is locked, unlocked, or unchanged.", "选择是锁定、解锁还是不变。"),
                    F("PartId", "The part selected in the row.", "该行选中的物料。"),
                    F("Selected", "Whether the row is selected.", "该行是否被选中。"),
                    F("Quantity", "The selected quantity.", "已选数量。"),
                    F("Position", "The position of the row.", "该行的位置。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.PartConfigurations.Dto.UpdatePartConfigurationInstruction",
                fields: [
                    F("Type", "The kind of instruction (variable, selection-group row, or main part).", "指令的种类（变量、选择组行或主物料）。"),
                    F("Variable", "The variable update; required for variable-type instructions.", "变量更新；变量类型指令必填。"),
                    F("SelectionGroupRow", "The selection-group-row update; required for that instruction type.", "选择组行更新；该类型指令必填。"),
                    F("MainPart", "The main-part update; required for that instruction type.", "主物料更新；该类型指令必填。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.PartConfigurations.Dto.VariableUpdate",
                fields: [
                    F("VariableId", "The variable to update.", "要更新的变量。"),
                    F("Value", "The new value of the variable.", "变量的新值。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.PartConfigurations.Dto.VariableValue",
                fields: [
                    F("Type", "The value type (string, numeric, boolean, date).", "值类型（文本、数值、布尔、日期）。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.PartConfigurations.RemotePartConfigurationPriceCommentDataRow",
                fields: [
                    F("OptionDescription", "The description of the selected option.", "所选选项的描述。"),
                    F("PartNumber", "The part number of the option.", "选项的物料编号。"),
                    F("PriceEach", "The unit price of the option.", "选项的单价。"),
                    F("Discount", "The discount on the option.", "选项的折扣。"),
                    F("CurrencyCode", "The currency of the price.", "价格的货币。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.PaymentPlanTemplates.AddPaymentPlanTemplateRow",
                fields: [
                    F("PartialInvoiceType", "When the installment is invoiced (in advance, at delivery, in arrears...).", "分期开票的时点（预付、交货时、欠款等）。"),
                    F("PartId", "The part the installment refers to, when partial.", "分期涉及的物料（如为部分）。"),
                    F("OverrideDescription", "An override of the installment description.", "分期描述的覆盖文本。"),
                    F("FractionOfTotal", "The fraction of the total invoiced in this installment.", "本期开票占总金额的比例。"),
                    F("PaymentTermId", "The payment term of the installment.", "分期的付款条款。"),
                    F("UnpaidAdvanceWarningType", "How a missing advance payment is handled (none, warning, or block delivery).", "未收到预付款时的处理方式（不处理、警告或阻止交货）。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Projects.AddActivityProject",
                fields: [
                    F("ActivityTypeId", "The activity type of the activity.", "活动的活动类型。"),
                    F("Description", "The description of the activity; defaults to the activity type.", "活动的描述；默认取自活动类型。"),
                    F("ResponsibleUserId", "The user responsible for the activity.", "负责该活动的用户。"),
                    F("PlannedTimeInHours", "The planned time, in hours.", "计划时间（小时）。"),
                    F("PlannedStartDate", "The planned start date.", "计划开始日期。"),
                    F("PlannedCompletionDate", "The planned completion date.", "计划完成日期。"),
                    F("Status", "The status of the activity (registered, in progress, history).", "活动状态（已登记、进行中、历史）。"),
                    F("RestTimeInHours", "The remaining time, in hours.", "剩余时间（小时）。"),
                    F("CompletionDate", "The actual completion date.", "实际完成日期。"),
                    F("CompletedByUserId", "The user who completed the activity.", "完成该活动的用户。"),
                    F("LockedDelegateWork", "Whether the delegated work is locked.", "委托工作是否被锁定。"),
                    F("ShowInProjectReport", "Whether to show the activity in project reports.", "是否在项目报告中显示该活动。"),
                    F("Reminder", "Whether a reminder is created for the activity.", "是否为活动创建提醒。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Shared.AddStaggeredPrice",
                fields: [
                    F("LowerBoundaryQuantity", "The lower-boundary quantity of the price tier.", "价格档的下边界数量。"),
                    F("Price", "The price of the tier.", "该档的价格。"),
                    F("FuturePrice", "The future price of the tier.", "该档的未来价格。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Shared.PartialQuantityValue",
                fields: [
                    F("PackagePartId", "The package part of the partial quantity.", "零头数量对应的包装物料。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Shared.Reporting.SetManufacturingOrderMaterialReportingTraceabilityData",
                fields: [
                    F("ManufacturingOrderMaterialId", "The manufacturing-order material to report.", "要上报的制造工单物料。"),
                    F("TraceabilityMode", "The traceability mode (none, batch, individual, individual-only withdrawal).", "追溯模式（无、批次、单个、仅单个领用）。"),
                    F("ProductRecordId", "The product record (batch/serial) to report; required when traceable.", "要上报的产品记录（批次/序列号）；可追溯时必填。"),
                    F("SerialNumber", "The serial number; required for serial-only withdrawal.", "序列号；仅序列号领用模式必填。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Shared.Reporting.SetManufacturingOrderOperationReportingTraceabilityData",
                fields: [
                    F("ManufacturingOrderOperationId", "The manufacturing-order operation to report.", "要上报的制造工单工序。"),
                    F("ProductRecordId", "The product record (batch/serial) to report.", "要上报的产品记录（批次/序列号）。"),
                    F("Materials", "The traceability data of the operation's materials.", "工序物料的追溯数据。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Shared.SerialNumberOrderRowInformation",
                fields: [
                    F("FirstNumberInRange", "The first serial number of the range.", "序列号范围的起始号。"),
                    F("SerialNumber", "The single serial number to generate.", "要生成的单个序列号。"),
                    F("NumberOfSerialNumbers", "The number of serial numbers to generate.", "要生成的序列号数量。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Shared.SetAddressCountry",
                fields: [
                    F("AddressFormatType", "The address format type; defaults to the country's format.", "地址格式类型；默认取自国家。"),
                    F("LanguageId", "The language of the address.", "地址的语言。"),
                    F("CountryId", "The country of the address.", "地址的国家。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Shared.SetBlobData",
                fields: [
                    F("MediaType", "The media type of the blob (text, image, audio, video...).", "二进制数据的媒体类型（文本、图像、音频、视频等）。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Shared.SetCodingDimension",
                fields: [
                    F("CodingDimensionId", "The coding dimension to set.", "要设置的记账维度。"),
                    F("ReferencingEntityId", "The entity the dimension references, when applicable.", "维度引用的实体（如适用）。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Shared.SetComment",
                fields: [
                    F("Text", "The formatted text of the comment.", "评论的格式化文本。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Shared.SetProductGroupCodingRow",
                fields: [
                    F("ProductGroupCodingType", "The coding type of the row (standard, setup, material, inventory...).", "行的记账类型（标准、设置、物料、库存等）。"),
                    F("Dimensions", "The coding dimensions of the row.", "记账行的记账维度。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Shared.UpdateStaggeredPrice",
                fields: [
                    F("StaggeredPriceId", "The staggered price to update.", "要更新的阶梯价格。"),
                    F("LowerBoundaryQuantity", "The lower-boundary quantity of the price tier.", "价格档的下边界数量。"),
                    F("Price", "The price of the tier.", "该档的价格。"),
                    F("FuturePrice", "The future price of the tier.", "该档的未来价格。"),
                ]),
            Content(
                "Monitor.API.Common.FileLink",
                fields: [
                    F("Orientation", "The print orientation of the linked file.", "链接文件的打印方向。"),
                    F("PrinterType", "Which printer the linked file prints to.", "链接文件打印使用的打印机。"),
                ]),
        ];
    }
}
