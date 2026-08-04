using Monitor.API.Infrastructure;
using MonitorErpMcp.Catalog.Extraction;
using MonitorErpMcp.Catalog.Model;

namespace MonitorErpMcp.Tests
{
    /// <summary>
    /// Seam A: mapping correctness of the reflection boundary over the pinned MonitorG5.Api assembly.
    /// </summary>
    public class CatalogMapperTests
    {
        private static readonly IReadOnlyList<CatalogRecord> Records =
            CatalogMapper.MapAssembly(typeof(ApiEntityAttribute).Assembly);

        [Fact]
        public void Census_Matches_FixedQueryAndCommandCounts()
        {
            Assert.Equal(348, Records.Count(r => r.Type == RecordType.Query));
            Assert.Equal(716, Records.Count(r => r.Type == RecordType.Command));
            // The dto set is derived from the assembly (not hand-pinned); the pinned assembly derives 93.
            Assert.Equal(93, Records.Count(r => r.Type == RecordType.Dto));
            Assert.Equal(1157, Records.Count);
        }

        [Fact]
        public void NoRecordCarriesTheInternalModule()
        {
            Assert.DoesNotContain(Records, r => r.Module == "Internal");
        }

        [Fact]
        public void InventoryPartsQuery_CarriesItsDerivedIdentity()
        {
            var part = Assert.Single(Records, r => r.Type == RecordType.Query && r.Module == "Inventory" && r.Name == "Parts");
            Assert.Equal("Monitor.API.Inventory.Part", part.ClrType);
            Assert.Equal("api/v1/Inventory/Parts", part.Route);
            Assert.Equal("GET", part.Method);
            Assert.Null(part.FullPath);
            Assert.NotNull(part.Description);
            Assert.Equal(string.Empty, part.Description.En);
            Assert.Equal(string.Empty, part.Description.Zh);
        }

        [Fact]
        public void CreatePartCommand_CarriesFullPathAndPostRoute()
        {
            var create = Assert.Single(Records, r => r.Type == RecordType.Command && r.FullPath == "Inventory/Parts/Create");
            Assert.Equal("Monitor.API.Inventory.Commands.Parts.CreatePart", create.ClrType);
            Assert.Equal("api/v1/Inventory/Parts/Create", create.Route);
            Assert.Equal("POST", create.Method);
            Assert.Equal("Create", create.Name);
        }

        [Fact]
        public void EveryRecord_CarriesIdentityFields()
        {
            Assert.All(Records, r =>
            {
                Assert.False(string.IsNullOrWhiteSpace(r.ClrType));
                Assert.False(string.IsNullOrWhiteSpace(r.Name), $"name of {r.ClrType}");
                Assert.StartsWith("https://api.monitor.se/api/", r.HelpUrl);
                Assert.NotNull(r.Description);
            });
        }

        [Fact]
        public void QueryAndCommandRecords_CarryHttpSurface_ButDtosDoNot()
        {
            Assert.All(
                Records.Where(r => r.Type != RecordType.Dto),
                r =>
                {
                    Assert.False(string.IsNullOrWhiteSpace(r.Module), $"module of {r.ClrType}");
                    Assert.StartsWith("api/v1/", r.Route);
                    Assert.NotNull(r.Method);
                });

            Assert.All(
                Records.Where(r => r.Type == RecordType.Dto),
                r =>
                {
                    Assert.Null(r.Module);
                    Assert.Null(r.Route);
                    Assert.Null(r.Method);
                });
        }

        [Fact]
        public void PartsQuery_Fields_CarryWireTypesAndConstraints()
        {
            var part = Assert.Single(Records, r => r.Type == RecordType.Query && r.Module == "Inventory" && r.Name == "Parts");

            Assert.Equal(137, part.Fields.Count);

            var id = part.Fields.Single(f => f.Name == "Id");
            Assert.Equal("System.Int64", id.ClrType);
            Assert.Equal("string", id.JsonType);
            Assert.Equal("int64", id.Format);

            var partNumber = part.Fields.Single(f => f.Name == "PartNumber");
            Assert.Equal("string", partNumber.JsonType);
            Assert.Null(partNumber.Format);
            Assert.True(partNumber.NotNull);
            Assert.Equal(20, partNumber.MaxLength);
            Assert.True(partNumber.Unique);

            var length = part.Fields.Single(f => f.Name == "Length");
            Assert.Equal("System.Decimal", length.ClrType);
            Assert.Equal("number", length.JsonType);
            Assert.Equal("decimal", length.Format);

            var useRandomLocationStorage = part.Fields.Single(f => f.Name == "UseRandomLocationStorage");
            Assert.Equal("boolean", useRandomLocationStorage.JsonType);

            var packagingType = part.Fields.Single(f => f.Name == "PackagingType");
            Assert.Equal("integer", packagingType.JsonType);
            Assert.Equal("int32", packagingType.Format);

            var planningInformations = part.Fields.Single(f => f.Name == "PartPlanningInformations");
            Assert.Equal("array", planningInformations.JsonType);
            Assert.True(planningInformations.Expandable);

            var daysToAdd = part.Fields.Single(f => f.Name == "DaysToAddToBestBeforeDate");
            Assert.Equal("integer", daysToAdd.JsonType);
            Assert.Equal("int32", daysToAdd.Format);
        }

        [Fact]
        public void DtoField_WiresAsObject()
        {
            var part = Assert.Single(Records, r => r.Type == RecordType.Query && r.Name == "Parts");

            var packageType = part.Fields.Single(f => f.Name == "PackageType");
            Assert.Equal("object", packageType.JsonType);
            Assert.True(packageType.Expandable);
        }

        [Fact]
        public void WireTypeTable_MapsSpecialScalars()
        {
            // DateTimeOffset -> string/date-time
            var interval = Assert.Single(Records, r => r.Type == RecordType.Query && r.ClrType == "Monitor.API.TimeRecording.AttendanceInterval");
            var intervalStart = interval.Fields.Single(f => f.Name == "IntervalStart");
            Assert.Equal("string", intervalStart.JsonType);
            Assert.Equal("date-time", intervalStart.Format);

            // TimeSpan -> string/timespan
            var forecast = Assert.Single(Records, r => r.Type == RecordType.Query && r.ClrType == "Monitor.API.Inventory.SalesForecast");
            var timeSpan = forecast.Fields.Single(f => f.Name == "TimeSpan");
            Assert.Equal("string", timeSpan.JsonType);
            Assert.Equal("timespan", timeSpan.Format);

            // Guid -> string/uuid
            var standbyWork = Assert.Single(Records, r => r.Type == RecordType.Query && r.ClrType == "Monitor.API.TimeRecording.StandbyWork");
            var bundleId = standbyWork.Fields.Single(f => f.Name == "BundleId");
            Assert.Equal("string", bundleId.JsonType);
            Assert.Equal("uuid", bundleId.Format);
        }

        [Fact]
        public void CreatePartCommand_Fields_CarryRequestInputSemantics()
        {
            var create = Assert.Single(Records, r => r.Type == RecordType.Command && r.FullPath == "Inventory/Parts/Create");

            Assert.Equal(6, create.Fields.Count);

            var partNumber = create.Fields.Single(f => f.Name == "PartNumber");
            Assert.True(partNumber.NotNull);
            Assert.Equal(20, partNumber.MaxLength);
            Assert.True(partNumber.Unique);

            var standardUnitId = create.Fields.Single(f => f.Name == "StandardUnitId");
            Assert.True(standardUnitId.NotNull);
            Assert.Equal("string", standardUnitId.JsonType);
            Assert.Equal("int64", standardUnitId.Format);

            var type = create.Fields.Single(f => f.Name == "Type");
            Assert.Equal("integer", type.JsonType);
            Assert.Equal("int32", type.Format);

            var partTemplateId = create.Fields.Single(f => f.Name == "PartTemplateId");
            Assert.Equal("Template marked as preset.", partTemplateId.Default);
            Assert.Equal("23.1", partTemplateId.AvailableSince);
        }

        [Fact]
        public void QueryFields_AreResponseMembers_WithoutMandatorySemantics()
        {
            var part = Assert.Single(Records, r => r.Type == RecordType.Query && r.Name == "Parts");

            // A query's fields are API response members: constraints are informational data-model
            // facts and never carry request-only mandatory/default semantics.
            Assert.All(part.Fields, f => Assert.False(f.Mandatory));
            Assert.All(part.Fields, f => Assert.Null(f.MandatoryWhen));
            Assert.All(part.Fields, f => Assert.Null(f.Default));
        }

        [Fact]
        public void NoQueryField_Anywhere_CarriesRequestInputSemantics()
        {
            // Field direction is implied by family, never stored: the mapper enforces that a query's
            // fields are response members and never carry mandatory/mandatoryWhen/default, even where
            // the fixture happens to carry the attributes.
            Assert.All(
                Records.Where(r => r.Type == RecordType.Query).SelectMany(r => r.Fields),
                f =>
                {
                    Assert.False(f.Mandatory, $"query field {f.Name} must not be mandatory");
                    Assert.Null(f.MandatoryWhen);
                    Assert.Null(f.Default);
                });
        }

        [Fact]
        public void CommandFields_CarryMandatoryAndMandatoryWhen()
        {
            // mandatoryWhen is the MandatoryAttribute stipulation, e.g. PartLocationName is mandatory
            // when reporting to a new location (that field lives on the ArrivalLocation dto record and
            // lands when #15 adds dto records); here the same pattern on a command's direct fields.
            var cmd = Assert.Single(Records, r => r.Type == RecordType.Command && r.FullPath == "Sales/Shipments/AddPackageRowInformation");

            var shipmentId = cmd.Fields.Single(f => f.Name == "ShipmentId");
            Assert.True(shipmentId.Mandatory);
            Assert.Equal("If not part of a create command", shipmentId.MandatoryWhen);

            var count = cmd.Fields.Single(f => f.Name == "Count");
            Assert.True(count.Mandatory);
            Assert.Equal(">0", count.MandatoryWhen);

            var volume = cmd.Fields.Single(f => f.Name == "Volume");
            Assert.True(volume.Mandatory);
            Assert.Null(volume.MandatoryWhen);
        }

        [Fact]
        public void FieldAvailability_IsExtracted()
        {
            var customerOrder = Assert.Single(Records, r => r.Type == RecordType.Query && r.ClrType == "Monitor.API.Sales.CustomerOrder");

            var printoutTimeStamp = customerOrder.Fields.Single(f => f.Name == "PrintoutTimeStamp");
            Assert.Equal("string", printoutTimeStamp.JsonType);
            Assert.Equal("date-time", printoutTimeStamp.Format);
            Assert.Equal("2.35", printoutTimeStamp.ObsoleteSince);

            var customer = Assert.Single(Records, r => r.Type == RecordType.Query && r.ClrType == "Monitor.API.Sales.Customer");
            var ediCode = customer.Fields.Single(f => f.Name == "EdiCode");
            Assert.Equal("2.32", ediCode.ObsoleteSince);
        }

        [Fact]
        public void RecordAvailability_IsExtracted()
        {
            var part = Assert.Single(Records, r => r.Type == RecordType.Query && r.Name == "Parts");
            Assert.Equal("2.18", part.AvailableSince);
            Assert.Null(part.ObsoleteSince);

            var obsolete = Assert.Single(Records, r => r.FullPath == "Sales/SalesPrices/GetPriceInfo");
            Assert.Equal(RecordType.Command, obsolete.Type);
            Assert.Equal("22.6", obsolete.AvailableSince);
            Assert.Equal("25.5", obsolete.ObsoleteSince);
        }

        [Fact]
        public void MinLength_IsExtracted()
        {
            var forecast = Assert.Single(Records, r => r.Type == RecordType.Query && r.ClrType == "Monitor.API.Inventory.SalesForecast");
            var code = forecast.Fields.Single(f => f.Name == "ForecastCode");
            Assert.Equal(1, code.MinLength);
        }

        [Fact]
        public void EveryField_CarriesIdentityAndWireType()
        {
            Assert.All(Records.SelectMany(r => r.Fields), f =>
            {
                Assert.False(string.IsNullOrWhiteSpace(f.Name));
                Assert.False(string.IsNullOrWhiteSpace(f.ClrType));
                Assert.False(string.IsNullOrWhiteSpace(f.JsonType));
                Assert.NotNull(f.Description);
            });
        }

        [Fact]
        public void FieldClassification_DirectEnum_CarriesValues()
        {
            var part = Assert.Single(Records, r => r.Type == RecordType.Query && r.ClrType == "Monitor.API.Inventory.Part");

            var packagingType = part.Fields.Single(f => f.Name == "PackagingType");
            Assert.Equal(FieldKind.Enum, packagingType.Kind);
            Assert.Equal("integer", packagingType.JsonType);
            Assert.NotNull(packagingType.Enum);
            Assert.Equal("Monitor.API.Inventory.PackagingType", packagingType.Enum!.ClrType);
            Assert.NotEmpty(packagingType.Enum.Values);
        }

        [Fact]
        public void FieldClassification_FlagsEnum_CarriesAllMinusOne()
        {
            var saveAs = Assert.Single(Records, r => r.Type == RecordType.Command && r.FullPath == "Inventory/Parts/SaveAs");

            var state = saveAs.Fields.Single(f => f.Name == "State");
            Assert.Equal(FieldKind.Enum, state.Kind);
            Assert.NotNull(state.Enum);
            Assert.Equal("Monitor.API.Inventory.Commands.Parts.PartSaveAsStates", state.Enum!.ClrType);

            var values = state.Enum.Values;
            Assert.Equal(23, values.Count);
            Assert.Equal((0, "None"), ((values[0].Value, values[0].Name)));
            Assert.Contains(values, v => v.Name == "All" && v.Value == -1);
            Assert.Contains(values, v => v.Name == "CopyRevisions" && v.Value == 1048576);
            Assert.Equal(-1, values[^1].Value);
        }

        [Fact]
        public void FieldClassification_SuppressedEnum_CarriesNoValues()
        {
            var configuration = Assert.Single(
                Records,
                r => r.Type == RecordType.Query && r.ClrType == "Monitor.API.Common.FormReportConfiguration");

            var type = configuration.Fields.Single(f => f.Name == "Type");
            Assert.Equal(FieldKind.Enum, type.Kind);
            Assert.Null(type.Enum); // suppressed from documentation
        }

        [Fact]
        public void FieldClassification_EnumInputWrapper_CarriesEnumValues()
        {
            var setProperties = Assert.Single(
                Records,
                r => r.Type == RecordType.Command && r.FullPath == "Inventory/Parts/SetProperties");

            var packagingType = setProperties.Fields.Single(f => f.Name == "PackagingType");
            Assert.Equal(FieldKind.InputWrapper, packagingType.Kind);
            Assert.Equal("object", packagingType.JsonType);
            Assert.NotNull(packagingType.Enum);
            Assert.Equal("Monitor.API.Inventory.PackagingType", packagingType.Enum!.ClrType);
            Assert.NotEmpty(packagingType.Enum.Values);
        }

        [Fact]
        public void FieldClassification_Reference_ResolvesSimpleClrName()
        {
            var part = Assert.Single(Records, r => r.Type == RecordType.Query && r.ClrType == "Monitor.API.Inventory.Part");

            var productGroupId = part.Fields.Single(f => f.Name == "ProductGroupId");
            Assert.Equal(FieldKind.Reference, productGroupId.Kind);
            Assert.Equal("ProductGroup", productGroupId.References);
            Assert.Equal("Monitor.API.Common.ProductGroup", productGroupId.RefClrType);
        }

        [Fact]
        public void FieldClassification_StringFormReference_KeptVerbatim()
        {
            var customer = Assert.Single(Records, r => r.Type == RecordType.Query && r.ClrType == "Monitor.API.Sales.Customer");

            var rootId = customer.Fields.Single(f => f.Name == "RootId");
            Assert.Equal(FieldKind.Reference, rootId.Kind);
            Assert.Equal("CustomerRoot", rootId.References);
            Assert.Null(rootId.RefClrType);
        }

        [Fact]
        public void References_Census_OnQueryAndCommandFields()
        {
            var typeForm = 0;
            var stringForm = 0;
            foreach (var record in Records.Where(r => r.Type != RecordType.Dto))
            {
                foreach (var field in record.Fields.Where(f => f.References is not null))
                {
                    if (field.RefClrType is null)
                    {
                        stringForm++;
                    }
                    else
                    {
                        typeForm++;
                    }
                }
            }

            Assert.Equal(1457, typeForm);
            Assert.Equal(42, stringForm);
        }

        [Fact]
        public void FieldClassification_InputWrapper_IsDistinguished()
        {
            var addRow = Assert.Single(
                Records,
                r => r.Type == RecordType.Command && r.FullPath == "Sales/Shipments/AddPackageRowInformation");

            var packageTypeId = addRow.Fields.Single(f => f.Name == "PackageTypeId");
            Assert.Equal(FieldKind.InputWrapper, packageTypeId.Kind);
            Assert.Equal("object", packageTypeId.JsonType);
        }

        [Fact]
        public void FieldClassification_NestedCommand_IdentifiesInputType()
        {
            var create = Assert.Single(Records, r => r.Type == RecordType.Command && r.FullPath == "Inventory/Parts/Create");

            var update = create.Fields.Single(f => f.Name == "Update");
            Assert.Equal(FieldKind.NestedCommand, update.Kind);
            Assert.Equal("Monitor.API.Inventory.Commands.Parts.SetPropertiesPart", update.RefClrType);
        }

        [Fact]
        public void FieldClassification_Expandable_NamesTheEntity()
        {
            var part = Assert.Single(Records, r => r.Type == RecordType.Query && r.ClrType == "Monitor.API.Inventory.Part");

            var productGroup = part.Fields.Single(f => f.Name == "ProductGroup");
            Assert.Equal(FieldKind.Expandable, productGroup.Kind);
            Assert.True(productGroup.Expandable);
            Assert.Equal("Monitor.API.Common.ProductGroup", productGroup.RefClrType);
        }

        [Fact]
        public void FieldClassification_DtoField_CarriesRefClrType()
        {
            var reportArrival = Assert.Single(
                Records,
                r => r.Type == RecordType.Command && r.FullPath == "Purchase/PurchaseOrders/ReportArrivals");

            var rows = reportArrival.Fields.Single(f => f.Name == "Rows");
            Assert.Equal(FieldKind.Dto, rows.Kind);
            Assert.Equal("array", rows.JsonType);
            Assert.Equal("Monitor.API.Purchase.Commands.ArrivalReporting.ArrivalRow", rows.RefClrType);
        }

        [Fact]
        public void DtoRecords_AreDerivedAndCarryUsedBy()
        {
            var arrivalLocation = Assert.Single(
                Records,
                r => r.Type == RecordType.Dto && r.ClrType == "Monitor.API.Purchase.Commands.ArrivalReporting.ArrivalLocation");

            Assert.Equal("ArrivalLocation", arrivalLocation.Name);
            Assert.Null(arrivalLocation.Module);
            Assert.Null(arrivalLocation.Route);
            Assert.Null(arrivalLocation.Method);
            Assert.Equal("2.36", arrivalLocation.AvailableSince);
            Assert.Equal(
                [
                    "Monitor.API.Purchase.Commands.ArrivalReporting.ArrivalRow",
                    "Monitor.API.Purchase.Commands.ReceivingInspection.ReceivingInspectionRow",
                ],
                arrivalLocation.UsedBy);
        }

        [Fact]
        public void DtoRecordField_CarriesMandatoryWhen()
        {
            // The spec's canonical mandatoryWhen example lives here on a dto record.
            var arrivalLocation = Assert.Single(
                Records,
                r => r.Type == RecordType.Dto && r.ClrType == "Monitor.API.Purchase.Commands.ArrivalReporting.ArrivalLocation");

            var partLocationName = arrivalLocation.Fields.Single(f => f.Name == "PartLocationName");
            Assert.Equal(FieldKind.Raw, partLocationName.Kind);
            Assert.True(partLocationName.Mandatory);
            Assert.Equal("If reporting to a new location.", partLocationName.MandatoryWhen);
        }

        [Fact]
        public void Query_RelatedCommands_AreDerivedByJoin()
        {
            var part = Assert.Single(Records, r => r.Type == RecordType.Query && r.ClrType == "Monitor.API.Inventory.Part");

            Assert.Equal(63, part.RelatedCommands.Count);
            Assert.Contains("Monitor.API.Inventory.Commands.Parts.CreatePart", part.RelatedCommands);
            Assert.Contains("Monitor.API.Inventory.Commands.Parts.SetPropertiesPart", part.RelatedCommands);
        }

        [Fact]
        public void Query_QueryOptions_AreTheStandardSix()
        {
            var part = Assert.Single(Records, r => r.Type == RecordType.Query && r.ClrType == "Monitor.API.Inventory.Part");

            Assert.Equal(["filter", "select", "expand", "orderby", "top", "skip"], part.QueryOptions);

            // Every query carries the same six.
            Assert.All(
                Records.Where(r => r.Type == RecordType.Query),
                r => Assert.Equal(["filter", "select", "expand", "orderby", "top", "skip"], r.QueryOptions));
        }

        [Fact]
        public void Command_Batchable_CensusHolds()
        {
            var commands = Records.Where(r => r.Type == RecordType.Command).ToList();
            Assert.Equal(710, commands.Count(c => c.Batchable));

            Assert.True(Assert.Single(commands, c => c.FullPath == "Inventory/Parts/Create").Batchable);
            Assert.False(Assert.Single(commands, c => c.FullPath == "Purchase/PurchaseOrders/ReportArrivals").Batchable);
        }

        [Fact]
        public void Command_MultipartForm_IsDistinguished()
        {
            // Exactly one command takes multipart/form-data: UploadFileStream.
            var multipart = Records.Where(r => r.Type == RecordType.Command && r.MultipartForm).ToList();
            var upload = Assert.Single(multipart);
            Assert.Equal("Common/ManageFiles/UploadFileStream", upload.FullPath);

            var create = Assert.Single(Records, r => r.Type == RecordType.Command && r.FullPath == "Inventory/Parts/Create");
            Assert.False(create.MultipartForm);
        }

        [Fact]
        public void Command_Output_DefaultsToEntityCommandResponse()
        {
            Assert.All(
                Records.Where(r => r.Type == RecordType.Command),
                c => Assert.Equal("EntityCommandResponse", c.Output));
        }

        [Fact]
        public void DtoRecords_CarryNoDerivedEdges()
        {
            Assert.All(
                Records.Where(r => r.Type == RecordType.Dto),
                r =>
                {
                    Assert.Empty(r.QueryOptions);
                    Assert.Empty(r.RelatedCommands);
                    Assert.False(r.Batchable);
                    Assert.Null(r.Output);
                });
        }
    }
}
