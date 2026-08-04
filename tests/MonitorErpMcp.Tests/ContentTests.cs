using Monitor.API.Infrastructure;
using MonitorErpMcp.Catalog.Content;
using MonitorErpMcp.Catalog.Extraction;
using MonitorErpMcp.Catalog.Model;
using MonitorErpMcp.Catalog.Search;

namespace MonitorErpMcp.Tests
{
    /// <summary>
    /// Seam A: the content layer — clrType-keyed merge onto the structural catalog, bilingual
    /// descriptions/aliases, zh-alias search, and the rule that dto records carry field descriptions
    /// only. Builds the merged catalog exactly as CatalogService does.
    /// </summary>
    public class ContentTests
    {
        private static readonly IReadOnlyList<CatalogRecord> Raw =
            CatalogMapper.MapAssembly(typeof(ApiEntityAttribute).Assembly);

        private static readonly CatalogIndex Merged =
            new(ContentMerger.Apply(Raw, CatalogContent.ByClrType));

        [Fact]
        public void EveryEntry_KeysAResolvableRecord()
        {
            // No orphaned content: each authored clrType must exist structurally, so a stale key
            // (surviving a rename or removal) is caught here rather than silently ignored.
            Assert.All(CatalogContent.Entries, e =>
            {
                Assert.NotNull(Raw.FirstOrDefault(r => r.ClrType == e.ClrType));
                Assert.NotNull(Merged.GetByClrType(e.ClrType));
            });
        }

        [Fact]
        public void NoDuplicateClrTypeKeys()
        {
            // A duplicate key would make CatalogContent.ByClrType throw; assert the content is clean.
            var keys = CatalogContent.Entries.Select(e => e.ClrType).ToList();
            Assert.Equal(keys.Count, keys.Distinct(StringComparer.OrdinalIgnoreCase).Count());
        }

        [Fact]
        public void EveryCoveredModuleRecord_HasBilingualIdentity()
        {
            // T1 coverage: every searchable record in a covered module (the pilots plus Common,
            // Manufacturing, and Purchase) carries a bilingual description and non-empty search aliases.
            foreach (var module in new[] { "Inventory", "Sales", "Common", "Manufacturing", "Purchase", "Accounting", "TimeRecording" })
            {
                Assert.All(
                    Merged.Records.Where(r => r.Module == module && r.Type != RecordType.Dto),
                    r =>
                    {
                        Assert.False(string.IsNullOrWhiteSpace(r.Description.En), $"{r.ClrType} en");
                        Assert.False(string.IsNullOrWhiteSpace(r.Description.Zh), $"{r.ClrType} zh");
                        Assert.NotEmpty(r.Aliases.En);
                        Assert.NotEmpty(r.Aliases.Zh);
                    });
            }
        }

        [Fact]
        public void Records_WithoutAuthoredContent_KeepEmptyDescription()
        {
            // Content is applied by clrType key, never by module: a record with no authored entry
            // (e.g. the time-recording Persons records, whose clrType lives under Common.Commands)
            // keeps its structural empty description — content never leaks onto uncovered records.
            Assert.All(
                Merged.Records.Where(r => r.Type != RecordType.Dto && !CatalogContent.ByClrType.ContainsKey(r.ClrType)),
                r => Assert.Equal(string.Empty, r.Description.En));
        }

        [Fact]
        public void EveryFieldDescriptionKey_LandsOnARealField()
        {
            foreach (var entry in CatalogContent.Entries)
            {
                var record = Raw.First(r => r.ClrType == entry.ClrType);
                Assert.All(entry.FieldDescriptions.Keys, fieldName =>
                    Assert.Contains(record.Fields, f => f.Name == fieldName));
            }
        }

        [Fact]
        public void PartsQuery_ReceivesAuthoredBilingualDescriptionAndAliases()
        {
            var part = Merged.GetByClrType("Monitor.API.Inventory.Part")!;

            Assert.Equal("The part master record — a material, component, or spare part held in inventory, with its stock, pricing, and planning information.", part.Description.En);
            Assert.Equal("物料主记录 —— 库存中管理的物料、组件或备件，含库存、价格与计划信息。", part.Description.Zh);
            Assert.Contains("component", part.Aliases.En);
            Assert.Contains("物料", part.Aliases.Zh);
            Assert.Contains("组件", part.Aliases.Zh);
        }

        [Fact]
        public void CreatePartCommand_ReceivesAuthoredContent()
        {
            var create = Merged.GetByClrType("Monitor.API.Inventory.Commands.Parts.CreatePart")!;

            Assert.Equal("Create a new part in inventory.", create.Description.En);
            Assert.Equal("在库存中创建新物料。", create.Description.Zh);
            Assert.Contains("新建物料", create.Aliases.Zh);
        }

        [Fact]
        public void Search_MatchesChineseAliases()
        {
            // Discovery must work for Chinese-language prompts (acceptance criterion).
            Assert.Equal(
                "api/v1/Inventory/Parts",
                Merged.Search("物料").Results[0].Route);
            Assert.Equal(
                "api/v1/Inventory/Parts",
                Merged.Search("组件").Results[0].Route);

            // And the corresponding English alias resolves too.
            Assert.Contains(Merged.Search("component").Results, r => r.Route == "api/v1/Inventory/Parts");
        }

        [Fact]
        public void Search_MatchesASalesChineseAlias()
        {
            var quote = Merged.Search("报价单");
            Assert.Contains(quote.Results, r => r.ClrType == "Monitor.API.Sales.Quote");

            var customer = Merged.Search("客户");
            Assert.Contains(customer.Results, r => r.ClrType == "Monitor.API.Sales.Customer");
        }

        [Fact]
        public void CommonQuery_ReceivesAuthoredBilingualDescriptionAndAliases()
        {
            var project = Merged.GetByClrType("Monitor.API.Common.Project")!;

            Assert.Contains("phases", project.Description.En);
            Assert.Contains("阶段", project.Description.Zh);
            Assert.Contains("project", project.Aliases.En);
            Assert.Contains("项目", project.Aliases.Zh);
        }

        [Fact]
        public void CommonCommand_ReceivesAuthoredContent()
        {
            var create = Merged.GetByClrType("Monitor.API.Common.Commands.Projects.CreateProject")!;

            Assert.Equal("Create a new project.", create.Description.En);
            Assert.Equal("创建新项目。", create.Description.Zh);
            Assert.Contains("新建项目", create.Aliases.Zh);

            // T2: a mandatory request-input field carries its authored description.
            var code = create.Fields.Single(f => f.Name == "Code");
            Assert.Equal("The unique project number.", code.Description.En);
            Assert.Equal("唯一的项目编号。", code.Description.Zh);
        }

        [Fact]
        public void CommonSearch_MatchesChineseAliases()
        {
            // Discovery must work for Chinese-language prompts in the Common area too.
            Assert.Contains(Merged.Search("项目").Results, r => r.ClrType == "Monitor.API.Common.Project");
            Assert.Contains(Merged.Search("员工").Results, r => r.ClrType == "Monitor.API.Common.Person");
            Assert.Contains(Merged.Search("货币").Results, r => r.ClrType == "Monitor.API.Common.Currency");
        }

        [Fact]
        public void CommonDto_CarriesFieldDescriptionsOnly()
        {
            var comment = Merged.GetByClrType("Monitor.API.Common.Commands.Shared.SetComment")!;

            // dto records are not searchable: no record description, no aliases.
            Assert.Equal(string.Empty, comment.Description.En);
            Assert.Empty(comment.Aliases.En);

            // ... but their request-input fields carry the authored descriptions.
            var text = comment.Fields.Single(f => f.Name == "Text");
            Assert.Equal("The formatted text of the comment.", text.Description.En);
            Assert.Equal("评论的格式化文本。", text.Description.Zh);
        }

        [Fact]
        public void ManufacturingQuery_ReceivesAuthoredBilingualDescriptionAndAliases()
        {
            var order = Merged.GetByClrType("Monitor.API.Manufacturing.ManufacturingOrder")!;

            Assert.Contains("operations", order.Description.En);
            Assert.Contains("工序", order.Description.Zh);
            Assert.Contains("manufacturing order", order.Aliases.En);
            Assert.Contains("制造工单", order.Aliases.Zh);
        }

        [Fact]
        public void ManufacturingCommand_ReceivesAuthoredContent()
        {
            var create = Merged.GetByClrType("Monitor.API.Manufacturing.Commands.ManufacturingOrders.CreateManufacturingOrder")!;

            Assert.Equal("Create a manufacturing order.", create.Description.En);
            Assert.Equal("创建制造工单。", create.Description.Zh);
            Assert.Contains("新建工单", create.Aliases.Zh);

            // T2: a mandatory request-input field carries its authored description.
            var quantity = create.Fields.Single(f => f.Name == "Quantity");
            Assert.Equal("The quantity to manufacture.", quantity.Description.En);
            Assert.Equal("要制造的数量。", quantity.Description.Zh);
        }

        [Fact]
        public void ManufacturingSearch_MatchesChineseAliases()
        {
            // Discovery must work for Chinese-language prompts in the Manufacturing area too.
            Assert.Contains(Merged.Search("工单").Results, r => r.ClrType == "Monitor.API.Manufacturing.ManufacturingOrder");
            Assert.Contains(Merged.Search("工作中心").Results, r => r.ClrType == "Monitor.API.Manufacturing.WorkCenter");
            Assert.Contains(Merged.Search("图纸").Results, r => r.ClrType == "Monitor.API.Manufacturing.Drawing");
        }

        [Fact]
        public void ManufacturingDto_CarriesFieldDescriptionsOnly()
        {
            var rejection = Merged.GetByClrType("Monitor.API.Manufacturing.Commands.Reporting.AddRejectionRow")!;

            // dto records are not searchable: no record description, no aliases.
            Assert.Equal(string.Empty, rejection.Description.En);
            Assert.Empty(rejection.Aliases.En);

            // ... but their request-input fields carry the authored descriptions.
            var quantity = rejection.Fields.Single(f => f.Name == "RejectedQuantity");
            Assert.Equal("The rejected quantity.", quantity.Description.En);
            Assert.Equal("拒收数量。", quantity.Description.Zh);
        }

        [Fact]
        public void PurchaseQuery_ReceivesAuthoredBilingualDescriptionAndAliases()
        {
            var order = Merged.GetByClrType("Monitor.API.Purchase.PurchaseOrder")!;

            Assert.Contains("supplier", order.Description.En);
            Assert.Contains("供应商", order.Description.Zh);
            Assert.Contains("purchase order", order.Aliases.En);
            Assert.Contains("采购订单", order.Aliases.Zh);
        }

        [Fact]
        public void PurchaseCommand_ReceivesAuthoredContent()
        {
            var create = Merged.GetByClrType("Monitor.API.Purchase.Commands.PurchaseOrders.CreatePurchaseOrder")!;

            Assert.Equal("Create a purchase order.", create.Description.En);
            Assert.Equal("创建采购订单。", create.Description.Zh);
            Assert.Contains("新建采购订单", create.Aliases.Zh);

            // T2: a mandatory request-input field carries its authored description.
            var rows = create.Fields.Single(f => f.Name == "Rows");
            Assert.Equal("The rows of the purchase order.", rows.Description.En);
            Assert.Equal("采购订单的行。", rows.Description.Zh);
        }

        [Fact]
        public void PurchaseSearch_MatchesChineseAliases()
        {
            // Discovery must work for Chinese-language prompts in the Purchase area too.
            Assert.Contains(Merged.Search("供应商").Results, r => r.ClrType == "Monitor.API.Purchase.Supplier");
            Assert.Contains(Merged.Search("询价单").Results, r => r.ClrType == "Monitor.API.Purchase.Inquiry");
            Assert.Contains(Merged.Search("采购订单").Results, r => r.ClrType == "Monitor.API.Purchase.PurchaseOrder");
        }

        [Fact]
        public void PurchaseDto_CarriesFieldDescriptionsOnly()
        {
            var arrivalRow = Merged.GetByClrType("Monitor.API.Purchase.Commands.ArrivalReporting.ArrivalRow")!;

            // dto records are not searchable: no record description, no aliases.
            Assert.Equal(string.Empty, arrivalRow.Description.En);
            Assert.Empty(arrivalRow.Aliases.En);

            // ... but their request-input fields carry the authored descriptions.
            var quantity = arrivalRow.Fields.Single(f => f.Name == "Quantity");
            Assert.Equal("The arrived quantity.", quantity.Description.En);
            Assert.Equal("到货数量。", quantity.Description.Zh);
        }

        [Fact]
        public void DtoRecord_CarriesFieldDescriptionsOnly()
        {
            var deliveryLocation = Merged.GetByClrType("Monitor.API.Sales.Commands.DeliveryReporting.DeliveryReportingLocation")!;

            // dto records are not searchable: no record description, no aliases.
            Assert.Equal(string.Empty, deliveryLocation.Description.En);
            Assert.Equal(string.Empty, deliveryLocation.Description.Zh);
            Assert.Empty(deliveryLocation.Aliases.En);
            Assert.Empty(deliveryLocation.Aliases.Zh);

            // ... but their request-input fields carry the authored descriptions.
            var quantity = deliveryLocation.Fields.Single(f => f.Name == "Quantity");
            Assert.Equal("The quantity to report delivered at this location.", quantity.Description.En);
            Assert.Equal("在该库位报交货的数量。", quantity.Description.Zh);
        }

        [Fact]
        public void DtoRecord_UnauthoredField_KeepsEmptyDescription()
        {
            // Only authored fields are touched; the rest stay structurally empty. The activity dto's
            // bare Description and Comment fields are deliberately skipped as self-evident.
            var activity = Merged.GetByClrType("Monitor.API.Inventory.Commands.CaseEntries.AddActivityCaseEntry")!;
            var description = activity.Fields.Single(f => f.Name == "Description");
            Assert.Equal(string.Empty, description.Description.En);
        }

        [Fact]
        public void DtoRecord_FieldDescription_FlowsToExpandedInlineFields()
        {
            // When a command expands a dto inline, the dto's field descriptions ride along.
            var reportDelivery = Merged.GetByClrType("Monitor.API.Sales.Commands.DeliveryReporting.ReportDelivery")!;
            var expanded = Merged.Expand(reportDelivery, int.MaxValue);

            var rows = expanded.Fields.Single(f => f.Name == "Rows");
            var locations = rows.Inline!.Single(f => f.Name == "Locations");
            var quantity = locations.Inline!.Single(f => f.Name == "Quantity");
            Assert.Equal("The quantity to report delivered at this location.", quantity.Description.En);
        }

        [Fact]
        public void MergedRecord_StillCarriesStructuralIdentity()
        {
            // Merging replaces only the descriptive half; structure is untouched.
            var part = Merged.GetByClrType("Monitor.API.Inventory.Part")!;
            Assert.Equal(137, part.Fields.Count);
            Assert.Equal("2.18", part.AvailableSince);
            Assert.Equal(63, part.RelatedCommands.Count);
        }

        [Fact]
        public void AccountingQuery_ReceivesAuthoredBilingualDescriptionAndAliases()
        {
            var payable = Merged.GetByClrType("Monitor.API.Accounting.AccountsPayable")!;

            Assert.Contains("supplier invoice", payable.Description.En);
            Assert.Contains("应付账款", payable.Description.Zh);
            Assert.Contains("accounts payable", payable.Aliases.En);
            Assert.Contains("应付账款", payable.Aliases.Zh);

            // T2: a reference field carries its authored description.
            var supplier = payable.Fields.Single(f => f.Name == "BusinessContactId");
            Assert.Equal("The supplier of the accounts payable.", supplier.Description.En);
            Assert.Equal("应付账款的供应商。", supplier.Description.Zh);
        }

        [Fact]
        public void AccountingCommand_ReceivesAuthoredContent()
        {
            var create = Merged.GetByClrType("Monitor.API.Accounting.Commands.AccountsPayables.CreateAccountsPayable")!;

            Assert.Equal("Create an accounts payable (supplier invoice).", create.Description.En);
            Assert.Equal("创建应付账款（供应商发票）。", create.Description.Zh);
            Assert.Contains("创建应付账款", create.Aliases.Zh);

            // T2: a mandatory request-input field carries its authored description.
            var invoiceNumber = create.Fields.Single(f => f.Name == "SuppliersInvoiceNumber");
            Assert.Equal("The supplier's invoice number.", invoiceNumber.Description.En);
            Assert.Equal("供应商的发票号。", invoiceNumber.Description.Zh);
        }

        [Fact]
        public void AccountingSearch_MatchesChineseAliases()
        {
            // Discovery must work for Chinese-language prompts in the Accounting area too.
            Assert.Contains(Merged.Search("应付账款").Results, r => r.ClrType == "Monitor.API.Accounting.AccountsPayable");
            Assert.Contains(Merged.Search("凭证").Results, r => r.ClrType == "Monitor.API.Accounting.Voucher");
            Assert.Contains(Merged.Search("收款").Results, r => r.ClrType == "Monitor.API.Accounting.IncomingPayment");
        }

        [Fact]
        public void AccountingDto_CarriesFieldDescriptionsOnly()
        {
            var voucherRow = Merged.GetByClrType("Monitor.API.Accounting.Commands.Vouchers.AddVoucherRow")!;

            // dto records are not searchable: no record description, no aliases.
            Assert.Equal(string.Empty, voucherRow.Description.En);
            Assert.Empty(voucherRow.Aliases.En);

            // ... but their request-input fields carry the authored descriptions.
            var codingEntry = voucherRow.Fields.Single(f => f.Name == "CodingEntry");
            Assert.Equal("The coding entry (account and dimensions) of the voucher row.", codingEntry.Description.En);
            Assert.Equal("凭证行的记账条目（科目与维度）。", codingEntry.Description.Zh);
        }

        [Fact]
        public void TimeRecordingQuery_ReceivesAuthoredBilingualDescriptionAndAliases()
        {
            var recordingDay = Merged.GetByClrType("Monitor.API.TimeRecording.RecordingDay")!;

            Assert.Contains("recording day", recordingDay.Description.En);
            Assert.Contains("记录日", recordingDay.Description.Zh);
            Assert.Contains("time recording day", recordingDay.Aliases.En);
            Assert.Contains("记录日", recordingDay.Aliases.Zh);

            // T2: an expandable field carries its authored description.
            var workIntervals = recordingDay.Fields.Single(f => f.Name == "WorkIntervals");
            Assert.Equal("The work intervals of the day.", workIntervals.Description.En);
            Assert.Equal("当日的工作区间。", workIntervals.Description.Zh);
        }

        [Fact]
        public void TimeRecordingCommand_ReceivesAuthoredContent()
        {
            var clockIn = Merged.GetByClrType("Monitor.API.TimeRecording.Commands.Recording.ClockIn")!;

            Assert.Equal("Clock in an employee at the attendance terminal.", clockIn.Description.En);
            Assert.Equal("在考勤终端为员工打卡上班。", clockIn.Description.Zh);
            Assert.Contains("打卡上班", clockIn.Aliases.Zh);

            // T2: a mandatory request-input field carries its authored description.
            var employee = clockIn.Fields.Single(f => f.Name == "EmployeeId");
            Assert.Equal("The employee to clock in.", employee.Description.En);
            Assert.Equal("要打卡上班的员工。", employee.Description.Zh);
        }

        [Fact]
        public void TimeRecordingSearch_MatchesChineseAliases()
        {
            // Discovery must work for Chinese-language prompts in the TimeRecording area too.
            Assert.Contains(Merged.Search("记录日").Results, r => r.ClrType == "Monitor.API.TimeRecording.RecordingDay");
            Assert.Contains(Merged.Search("加班").Results, r => r.ClrType == "Monitor.API.TimeRecording.OvertimeType");
            Assert.Contains(Merged.Search("排班").Results, r => r.ClrType == "Monitor.API.TimeRecording.Schedule");
            Assert.Contains(Merged.Search("打卡").Results, r => r.ClrType == "Monitor.API.TimeRecording.Commands.Recording.ClockIn");
        }

        [Fact]
        public void TimeRecordingDto_CarriesFieldDescriptionsOnly()
        {
            var absencePeriod = Merged.GetByClrType("Monitor.API.TimeRecording.Commands.Recording.AbsencePeriod")!;

            // dto records are not searchable: no record description, no aliases.
            Assert.Equal(string.Empty, absencePeriod.Description.En);
            Assert.Empty(absencePeriod.Aliases.En);

            // ... but their request-input fields carry the authored descriptions.
            var requirementType = absencePeriod.Fields.Single(f => f.Name == "RequirementType");
            Assert.Equal("Whether the period is required, optional, or optional at schedule end.", requirementType.Description.En);
            Assert.Equal("期间是否为必需、可选或排班结束时可选。", requirementType.Description.Zh);
        }

        [Fact]
        public void ContentBuilder_OneLiner_SuppliesDefaults()
        {
            // A record without examples (and without aliases) is a one-liner with all defaults.
            var entry = ContentEntryFactory.Content("Monitor.API.Sales.Customer", "A customer.", "客户。");
            Assert.Equal("A customer.", entry.Description!.En);
            Assert.Null(entry.Aliases);
            Assert.Empty(entry.FieldDescriptions);
        }
    }
}
