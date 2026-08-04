namespace MonitorErpMcp.Catalog.Content.Common
{
    // The using-static sits inside the namespace so the imported Content(...) builder binds before
    // the enclosing MonitorErpMcp.Catalog.Content namespace in simple-name lookup.
    using static MonitorErpMcp.Catalog.Content.ContentEntryFactory;
    using MonitorErpMcp.Catalog.Model;

    /// <summary>
    /// Hand-authored content for Common command records: bilingual descriptions and search aliases
    /// (en first, zh second), keyed by clrType and merged onto the structural catalog. Important
    /// request-input fields (mandatory, mandatoryWhen, enum, reference, input wrapper, nested
    /// command, dto) carry bilingual descriptions; self-evident fields are skipped.
    /// </summary>
    public static class Commands
    {
        /// <summary>Hand-authored entries for this family, merged by <c>clrType</c> onto the structural catalog.</summary>
        public static readonly ContentEntry[] Entries =
        [
            // ---- Addresses ------------------------------------------------------------
            Content(
                "Monitor.API.Common.Commands.Addresses.UpdateAddress",
                "Update the properties of an address.",
                "更新地址的属性。",
                ["update address", "change address"], ["更新地址", "修改地址"],
                fields: [
                    F("AddressId", "The address to update.", "要更新的地址。"),
                    F("Addressee", "The addressee of the address.", "地址的收件人。"),
                    F("Field1", "The first address line.", "地址第一行。"),
                    F("Field2", "The second address line.", "地址第二行。"),
                    F("Field3", "The third address line.", "地址第三行。"),
                    F("Field4", "The fourth address line.", "地址第四行。"),
                    F("Field5", "The fifth address line.", "地址第五行。"),
                    F("Locality", "The locality (city) of the address.", "地址的所在地（城市）。"),
                    F("Region", "The region of the address.", "地址的地区。"),
                    F("PostalCode", "The postal code of the address.", "地址的邮政编码。"),
                    F("PostalCodeId", "The postal code record of the address.", "地址的邮政编码记录。"),
                    F("LanguageId", "The language of the address.", "地址的语言。"),
                    F("FormReportTranslationGroupId", "The form-report translation group of the address.", "地址的表单报告翻译组。"),
                    F("SetAddressCountry", "Sets the country of the address together with its format.", "连同格式一起设置地址的国家。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Addresses.UpdateDeliveryAddress",
                "Update the properties of a delivery address.",
                "更新交货地址的属性。",
                ["update delivery address", "change delivery address"], ["更新交货地址", "修改交货地址"],
                fields: [
                    F("DeliveryAddressId", "The delivery address to update.", "要更新的交货地址。"),
                    F("Address", "The nested address update for the delivery address.", "交货地址的嵌套地址更新。"),
                    F("ConsigneeReferenceId", "The consignee reference (person) for the delivery address.", "交货地址的收货人联系人。"),
                    F("ConsigneeReferenceName", "The name of the consignee reference.", "收货人联系人的姓名。"),
                    F("Destination", "The destination of the delivery.", "交货的目的地。"),
                    F("DeliveryInstruction", "Delivery instructions for the address.", "该地址的交货说明。"),
                    F("VatRateId", "The default VAT rate for the delivery address.", "交货地址的默认增值税率。"),
                    F("CustomerAccountGroupId", "The customer account group for the delivery address.", "交货地址的客户科目组。"),
                    F("SupplierAccountGroupId", "The supplier account group for the delivery address.", "交货地址的供应商科目组。"),
                    F("VatGroupId", "The VAT group for the delivery address.", "交货地址的增值税组。"),
                    F("Warehouses", "The warehouse-specific delivery settings of the address.", "该地址的仓库特定交货设置。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Addresses.UpdateDeliveryAddressWarehouseInformation",
                "Update the warehouse-specific delivery settings of a delivery address.",
                "更新交货地址的仓库特定交货设置。",
                ["update warehouse delivery information", "delivery address warehouse"], ["更新仓库交货信息"],
                fields: [
                    F("DeliveryAddressId", "The delivery address to update.", "要更新的交货地址。"),
                    F("WarehouseId", "The warehouse the delivery settings apply to.", "交货设置适用的仓库。"),
                    F("DeliveryMethodId", "The delivery method used for the warehouse.", "该仓库使用的交货方式。"),
                    F("DeliveryTermId", "The delivery term used for the warehouse.", "该仓库使用的交货条款。"),
                    F("DestinationForDeliveryTerm", "The destination used for the delivery term.", "交货条款使用的地点。"),
                    F("TransportTime", "The transport time in days from the warehouse.", "从仓库出发的运输时间（天）。"),
                    F("DeliveryWeekdays", "The weekdays on which deliveries are made.", "进行交货的工作日。"),
                ]),

            // ---- ApplicationUsers -----------------------------------------------------
            Content(
                "Monitor.API.Common.Commands.ApplicationUsers.AddApplicationUserPermissionGroup",
                "Grant a permission group to a user in a warehouse.",
                "为某仓库中的用户授予权限组。",
                ["add permission group", "grant permission"], ["添加权限组", "授予权限组"],
                fields: [
                    F("ApplicationUserId", "The user to grant the permission group to.", "被授予权限组的用户。"),
                    F("WarehouseId", "The warehouse the permission group applies in.", "权限组适用的仓库。"),
                    F("PermissionGroupId", "The permission group to grant.", "要授予的权限组。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.ApplicationUsers.CreateApplicationUser",
                "Create a new application user.",
                "创建新的应用用户。",
                ["create user", "new user"], ["新建用户", "创建用户"],
                fields: [
                    F("Username", "The login name of the new user; must be unique.", "新用户的登录名；必须唯一。"),
                    F("Description", "A description of the user.", "用户的描述。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.ApplicationUsers.GetApplicationUserLicense",
                "Get the license of an application user.",
                "获取应用用户的许可证。",
                ["get license", "user license"], ["获取许可证", "用户许可证"],
                fields: [
                    F("ApplicationUserId", "The user to get the license for; give either this or Username.", "要获取许可证的用户；本字段与 Username 二选一。"),
                    F("Username", "The login name of the user; give either this or ApplicationUserId.", "用户的登录名；本字段与 ApplicationUserId 二选一。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.ApplicationUsers.GetLoggedInUser",
                "Get the currently logged-in user.",
                "获取当前登录的用户。",
                ["logged in user", "current user", "me"], ["当前用户", "登录用户"]),
            Content(
                "Monitor.API.Common.Commands.ApplicationUsers.RemoveApplicationUser",
                "Remove an application user.",
                "删除应用用户。",
                ["remove user", "delete user"], ["删除用户", "移除用户"],
                fields: [
                    F("ApplicationUserId", "The user to remove.", "要删除的用户。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.ApplicationUsers.RemoveApplicationUserPermissionGroup",
                "Remove a permission group from a user in a warehouse.",
                "从某仓库中的用户移除权限组。",
                ["remove permission group", "revoke permission"], ["移除权限组", "撤销权限组"],
                fields: [
                    F("ApplicationUserId", "The user to remove the permission group from.", "被移除权限组的用户。"),
                    F("WarehouseId", "The warehouse the permission group applies in.", "权限组适用的仓库。"),
                    F("PermissionGroupId", "The permission group to remove.", "要移除的权限组。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.ApplicationUsers.SetApplicationUserLicense",
                "Set the license of an application user.",
                "设置应用用户的许可证。",
                ["set license", "assign license"], ["设置许可证", "分配许可证"],
                fields: [
                    F("ApplicationUserId", "The user to set the license for.", "要设置许可证的用户。"),
                    F("Scope", "The license scope (disabled, company, or system).", "许可证范围（禁用、公司或系统）。"),
                    F("Kind", "The kind of license (full, read-only, attendance recording, API...).", "许可证种类（完整、只读、考勤记录、API 等）。"),
                    F("Binding", "Whether the license is bound to the user or floating.", "许可证绑定到用户还是浮动。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.ApplicationUsers.SetApplicationUserPassword",
                "Set the password of the logged-in user.",
                "设置当前登录用户的密码。",
                ["set password", "change password"], ["设置密码", "修改密码"],
                fields: [
                    F("NewPassword", "The new password.", "新密码。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.ApplicationUsers.SetEmailPropertiesApplicationUser",
                "Set the e-mail properties of a user.",
                "设置用户的电子邮件属性。",
                ["set email properties", "email settings"], ["设置邮件属性", "邮件设置"],
                fields: [
                    F("ApplicationUserId", "The user to set the e-mail properties for.", "要设置邮件属性的用户。"),
                    F("MailMethod", "How the user sends mail (client or server based).", "用户的邮件发送方式（基于客户端或服务器）。"),
                    F("MailAddress", "The user's e-mail address.", "用户的电子邮件地址。"),
                    F("MailUsername", "The user name for the mail server.", "邮件服务器的用户名。"),
                    F("MailPassword", "The password for the mail server.", "邮件服务器的密码。"),
                    F("MailCopyMethod", "How e-mail copies are handled.", "电子邮件的抄送方式。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.ApplicationUsers.SetPropertiesApplicationUser",
                "Set the properties of an application user.",
                "设置应用用户的属性。",
                ["set user properties", "update user"], ["设置用户属性", "更新用户"],
                fields: [
                    F("ApplicationUserId", "The user to set the properties for.", "要设置属性的用户。"),
                    F("Username", "The login name of the user.", "用户的登录名。"),
                    F("Description", "A description of the user.", "用户的描述。"),
                    F("Password", "The password of the user.", "用户的密码。"),
                    F("LanguageId", "The default language of the user.", "用户的默认语言。"),
                    F("WarehouseId", "The default warehouse of the user.", "用户的默认仓库。"),
                    F("PersonId", "The person linked to the user.", "与用户关联的人员。"),
                    F("WindowsUserAccountName", "The Windows account name of the user.", "用户的 Windows 账户名。"),
                    F("CanBeSetAsResponsibleForActivity", "Whether the user can be set as responsible for an activity.", "用户是否可被设为活动负责人。"),
                    F("AllowWebAccess", "Whether the user may access MONITOR from the web.", "用户是否可从 Web 访问 MONITOR。"),
                    F("CanWriteInstructions", "Whether the user can write instructions.", "用户是否可编写说明。"),
                    F("SynchronizeActivitiesWithCalendar", "Whether the user's activities sync with a calendar.", "用户的活动是否与日历同步。"),
                    F("DefaultVoucherSeriesId", "The default voucher series of the user.", "用户的默认凭证系列。"),
                    F("UserAuthenticationMethod", "How the user authenticates (password, Windows-integrated, or OIDC).", "用户的身份验证方式（密码、Windows 集成或 OIDC）。"),
                    F("Culture", "The culture of the user.", "用户的文化区域。"),
                ]),

            // ---- AutoCompletes --------------------------------------------------------
            Content(
                "Monitor.API.Common.Commands.AutoCompletes.ExecuteAutoCompletePaging",
                "Execute an autocomplete search with paging.",
                "执行带分页的自动完成搜索。",
                ["autocomplete paging", "autocomplete page"], ["自动完成分页"],
                fields: [
                    F("PopupTypeId", "The popup type to autocomplete.", "要自动完成的弹出类型。"),
                    F("Request", "The autocomplete request with filter and paging.", "含筛选与分页的自动完成请求。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.AutoCompletes.ExecuteAutoCompleteSearch",
                "Execute an autocomplete search.",
                "执行自动完成搜索。",
                ["autocomplete search", "autocomplete"], ["自动完成搜索", "自动完成"],
                fields: [
                    F("PopupTypeId", "The popup type to autocomplete.", "要自动完成的弹出类型。"),
                    F("Request", "The autocomplete request with filter and paging.", "含筛选与分页的自动完成请求。"),
                ]),

            // ---- CategoryComponents ---------------------------------------------------
            Content(
                "Monitor.API.Common.Commands.CategoryComponent.CreateCategoryComponent",
                "Create a category component.",
                "创建类别组件。",
                ["create category component", "new category"], ["创建类别组件", "新建类别"],
                fields: [
                    F("CategoryType", "The entity type the category component applies to.", "类别组件适用的实体类型。"),
                    F("Length", "The maximum length of the category value.", "类别值的最大长度。"),
                    F("Type", "Whether the component is optional or requires a selection list.", "组件是可选的还是必须使用选项列表。"),
                    F("CategoryValue", "The selectable values of the category component.", "类别组件的可选项值。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.CategoryComponent.RemoveCategoryComponent",
                "Remove a category component.",
                "删除类别组件。",
                ["remove category component", "delete category"], ["删除类别组件", "移除类别组件"],
                fields: [
                    F("Id", "The category component to remove.", "要删除的类别组件。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.CategoryComponent.UpdateCategoryComponent",
                "Update a category component.",
                "更新类别组件。",
                ["update category component"], ["更新类别组件"],
                fields: [
                    F("Id", "The category component to update.", "要更新的类别组件。"),
                    F("CategoryType", "The entity type the category component applies to.", "类别组件适用的实体类型。"),
                    F("Length", "The maximum length of the category value.", "类别值的最大长度。"),
                    F("Type", "Whether the component is optional or requires a selection list.", "组件是可选的还是必须使用选项列表。"),
                    F("Description", "A description of the category component.", "类别组件的描述。"),
                    F("CategoryValue", "The selectable values of the category component.", "类别组件的可选项值。"),
                ]),

            // ---- Comments / FileLinks -------------------------------------------------
            Content(
                "Monitor.API.Common.Commands.Comments.AddFileToComment",
                "Add a file to a comment.",
                "为评论添加文件。",
                ["add file", "attach file"], ["添加文件", "附加文件"],
                fields: [
                    F("CommentId", "The comment to add the file to.", "要添加文件的评论。"),
                    F("FileName", "The name of the file.", "文件的名称。"),
                    F("FilePathId", "The file path the file is stored in.", "文件存储的文件路径。"),
                    F("Data", "The file content; give either this or an existing file path.", "文件内容；本字段与已有文件路径二选一。"),
                    F("IsDefault", "Whether the file is the default file.", "文件是否为默认文件。"),
                    F("AutomaticPrintOut", "Whether the file is printed automatically.", "文件是否自动打印。"),
                    F("Orientation", "The print orientation of the file.", "文件的打印方向。"),
                    F("PrinterType", "Which printer the file prints to.", "文件打印使用的打印机。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Comments.CreateComment",
                "Create a comment on an entity.",
                "在实体上创建评论。",
                ["create comment", "add comment"], ["创建评论", "添加评论"],
                fields: [
                    F("EntityId", "The entity to comment on.", "要评论的实体。"),
                    F("EntityType", "The type of entity to comment on.", "要评论的实体类型。"),
                    F("EntityCommentType", "The comment category (internal, external, block message...).", "评论类别（内部、外部、封锁消息等）。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Comments.RemoveFileLink",
                "Remove a file link.",
                "删除文件链接。",
                ["remove file link", "delete file link"], ["删除文件链接", "移除文件链接"],
                fields: [
                    F("FileLinkId", "The file link to remove.", "要删除的文件链接。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Comments.UpdateComment",
                "Update a comment.",
                "更新评论。",
                ["update comment", "edit comment"], ["更新评论", "修改评论"],
                fields: [
                    F("CommentId", "The comment to update.", "要更新的评论。"),
                    F("RootEntityId", "The root entity the comment belongs to.", "评论所属的根实体。"),
                    F("Text", "The formatted text of the comment.", "评论的格式化文本。"),
                    F("RawText", "The raw text of the comment.", "评论的原始文本。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Comments.UpdateFileLink",
                "Update a file link.",
                "更新文件链接。",
                ["update file link", "edit file link"], ["更新文件链接"],
                fields: [
                    F("FileLinkId", "The file link to update.", "要更新的文件链接。"),
                    F("AutomaticPrintOut", "Whether the file is printed automatically.", "文件是否自动打印。"),
                    F("Orientation", "The print orientation of the file.", "文件的打印方向。"),
                    F("PrinterType", "Which printer the file prints to.", "文件打印使用的打印机。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Comments.UpdateFileLinkData",
                "Update the data of a file link.",
                "更新文件链接的数据。",
                ["update file data", "file content"], ["更新文件数据"],
                fields: [
                    F("FileLinkId", "The file link to update.", "要更新的文件链接。"),
                    F("Data", "The new file content.", "新的文件内容。"),
                ]),

            // ---- Configuration / Licensing / Others -----------------------------------
            Content(
                "Monitor.API.Common.Commands.Configuration.GetMonitorConfiguration",
                "Get the MONITOR configuration.",
                "获取 MONITOR 配置。",
                ["get configuration", "monitor config"], ["获取配置", "MONITOR配置"],
                fields: [
                    F("IncludeLogoImageData", "Whether to include the logo image data.", "是否包含徽标图片数据。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Configuration.GetSystemId",
                "Get the system identifier of the installation.",
                "获取本安装的系统标识。",
                ["system id", "installation id"], ["系统ID", "系统标识"]),
            Content(
                "Monitor.API.Common.Commands.Configuration.GetSystemParameters",
                "Get system parameters of the installation.",
                "获取本安装的系统参数。",
                ["system parameters", "system settings"], ["系统参数", "系统设置"],
                fields: [
                    F("Parameters", "The parameters to return; empty or omitted returns all.", "要返回的参数；为空或省略时返回全部。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Licensing.GetAvailableLicenses",
                "Get the available licenses in the installation.",
                "获取本安装中可用的许可证。",
                ["available licenses", "license list"], ["可用许可证", "许可证列表"]),
            Content(
                "Monitor.API.Common.Commands.Others.GetLicenseInformation",
                "Get license information for the installation.",
                "获取本安装的许可证信息。",
                ["license information", "license info"], ["许可证信息"]),
            Content(
                "Monitor.API.Common.Commands.MultiFactor.GetMultiFactorDeviceSecret",
                "Get the multi-factor device secret for the logged-in user.",
                "获取当前登录用户的多因素设备密钥。",
                ["mfa secret", "multi factor secret"], ["多因素密钥", "MFA密钥"]),
            Content(
                "Monitor.API.Common.Commands.MultiFactor.SetMultiFactorAuthenticationDevice",
                "Register a multi-factor authentication device.",
                "注册多因素身份验证设备。",
                ["mfa device", "multi factor setup"], ["多因素设备", "MFA设置"],
                fields: [
                    F("Code", "The verification code from the device.", "来自设备的验证码。"),
                    F("MfaToken", "The multi-factor token.", "多因素令牌。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.NumberSeries.UsedNumberFromNumberSeries",
                "Register a number as used in a number series.",
                "将编号登记为某编号系列中已使用。",
                ["use number", "reserve number"], ["使用编号", "占用编号"],
                fields: [
                    F("Type", "The number series to use a number from.", "要使用编号的编号系列。"),
                ]),

            // ---- BusinessContactNotes / Tags / ExchangeRates -------------------------
            Content(
                "Monitor.API.Common.Commands.CreateBusinessContactNoteHistory",
                "Create a note on a business contact.",
                "在业务联系人上创建备注。",
                ["create note", "add note"], ["创建备注", "添加备注"],
                fields: [
                    F("EntityId", "The entity to create the note on.", "要创建备注的实体。"),
                    F("EntityType", "The type of entity to create the note on.", "要创建备注的实体类型。"),
                    F("CreatedByUserId", "The user who created the note.", "创建备注的用户。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.CreateTag",
                "Create a tag on an entity.",
                "在实体上创建标签。",
                ["create tag", "add tag"], ["创建标签", "添加标签"],
                fields: [
                    F("OwnerTypeId", "The type of the tagged entity.", "被打标签的实体类型。"),
                    F("OwnerId", "The tagged entity.", "被打标签的实体。"),
                    F("Name", "The name of the tag.", "标签的名称。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.CurrencyExchangeRates.SetCurrencyExchangeRate",
                "Set an exchange rate for a currency and exchange-rate type.",
                "为货币与汇率类型设置汇率。",
                ["set exchange rate", "update exchange rate"], ["设置汇率", "更新汇率"],
                fields: [
                    F("CurrencyId", "The currency to set the rate for.", "要设置汇率的货币。"),
                    F("CurrencyExchangeTypeId", "The exchange-rate type.", "汇率类型。"),
                    F("Rate", "The exchange rate.", "汇率。"),
                ]),

            // ---- CustomReports --------------------------------------------------------
            Content(
                "Monitor.API.Common.Commands.CustomReports.GetCustomReport",
                "Get the data of a custom report.",
                "获取自定义报告的数据。",
                ["get custom report", "run report"], ["获取自定义报告", "运行报告"],
                fields: [
                    F("CustomReportDisplayDefinitionId", "The display definition of the report to run.", "要运行的报告的显示定义。"),
                    F("Restrictions", "The column restrictions applied to the report.", "应用于报告的行列限制。"),
                    F("Parameters", "The parameters of the report.", "报告的参数。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.CustomReports.GetCustomReportByDisplayId",
                "Get the data of a custom report by its display id.",
                "按显示 ID 获取自定义报告的数据。",
                ["get report by display id", "run report by id"], ["按显示ID获取报告"],
                fields: [
                    F("DisplayId", "The display id of the report to run.", "要运行报告的显示 ID。"),
                    F("Restrictions", "The column restrictions applied to the report.", "应用于报告的行列限制。"),
                    F("Parameters", "The parameters of the report.", "报告的参数。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.CustomReports.PrintCustomReportByDisplayId",
                "Print a custom report by its display id.",
                "按显示 ID 打印自定义报告。",
                ["print report", "print custom report"], ["打印报告", "打印自定义报告"],
                fields: [
                    F("ServerPrinterId", "The server printer to print on.", "打印使用的服务器打印机。"),
                    F("Command", "The report command to print.", "要打印的报告命令。"),
                ]),

            // ---- DiscountCategories ---------------------------------------------------
            Content(
                "Monitor.API.Common.Commands.DiscountCategories.CreateDiscountCategoryRows",
                "Create tiered discount rows in a discount category.",
                "在折扣类别中创建阶梯折扣行。",
                ["create discount rows", "add discount tiers"], ["创建折扣行", "添加折扣档"],
                fields: [
                    F("DiscountCategoryId", "The discount category to add rows to.", "要添加行的折扣类别。"),
                    F("BoundaryType", "Whether the boundaries are by quantity or by value.", "边界是按数量还是按金额。"),
                    F("ProductGroupId", "The product group the discount applies to.", "折扣适用的产品组。"),
                    F("PartCodeId", "The part code the discount applies to.", "折扣适用的物料代码。"),
                    F("PartCategory", "The part category the discount applies to.", "折扣适用的物料类别。"),
                    F("Boundary1", "The first tier's lower boundary.", "第一档的下边界。"),
                    F("Discount1", "The discount of the first tier.", "第一档的折扣。"),
                    F("Boundary2", "The second tier's lower boundary.", "第二档的下边界。"),
                    F("Discount2", "The discount of the second tier.", "第二档的折扣。"),
                    F("Boundary3", "The third tier's lower boundary.", "第三档的下边界。"),
                    F("Discount3", "The discount of the third tier.", "第三档的折扣。"),
                    F("Boundary4", "The fourth tier's lower boundary.", "第四档的下边界。"),
                    F("Discount4", "The discount of the fourth tier.", "第四档的折扣。"),
                    F("Boundary5", "The fifth tier's lower boundary.", "第五档的下边界。"),
                    F("Discount5", "The discount of the fifth tier.", "第五档的折扣。"),
                    F("Boundary6", "The sixth tier's lower boundary.", "第六档的下边界。"),
                    F("Discount6", "The discount of the sixth tier.", "第六档的折扣。"),
                    F("Boundary7", "The seventh tier's lower boundary.", "第七档的下边界。"),
                    F("Discount7", "The discount of the seventh tier.", "第七档的折扣。"),
                    F("Boundary8", "The eighth tier's lower boundary.", "第八档的下边界。"),
                    F("Discount8", "The discount of the eighth tier.", "第八档的折扣。"),
                    F("Boundary9", "The ninth tier's lower boundary.", "第九档的下边界。"),
                    F("Discount9", "The discount of the ninth tier.", "第九档的折扣。"),
                    F("Boundary10", "The tenth tier's lower boundary.", "第十档的下边界。"),
                    F("Discount10", "The discount of the tenth tier.", "第十档的折扣。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.DiscountCategories.RemoveDiscountCategoryRows",
                "Remove a tiered discount row.",
                "删除阶梯折扣行。",
                ["remove discount row", "delete discount row"], ["删除折扣行", "移除折扣行"],
                fields: [
                    F("Id", "The discount row to remove.", "要删除的折扣行。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.DiscountCategories.UpdateDiscountCategoryRows",
                "Update a tiered discount row.",
                "更新阶梯折扣行。",
                ["update discount row", "edit discount tier"], ["更新折扣行", "修改折扣档"],
                fields: [
                    F("Id", "The discount row to update.", "要更新的折扣行。"),
                    F("BoundaryType", "Whether the boundaries are by quantity or by value.", "边界是按数量还是按金额。"),
                    F("ProductGroupId", "The product group the discount applies to.", "折扣适用的产品组。"),
                    F("PartCodeId", "The part code the discount applies to.", "折扣适用的物料代码。"),
                    F("PartCategory", "The part category the discount applies to.", "折扣适用的物料类别。"),
                    F("Boundary1", "The first tier's lower boundary.", "第一档的下边界。"),
                    F("Discount1", "The discount of the first tier.", "第一档的折扣。"),
                    F("Boundary2", "The second tier's lower boundary.", "第二档的下边界。"),
                    F("Discount2", "The discount of the second tier.", "第二档的折扣。"),
                    F("Boundary3", "The third tier's lower boundary.", "第三档的下边界。"),
                    F("Discount3", "The discount of the third tier.", "第三档的折扣。"),
                    F("Boundary4", "The fourth tier's lower boundary.", "第四档的下边界。"),
                    F("Discount4", "The discount of the fourth tier.", "第四档的折扣。"),
                    F("Boundary5", "The fifth tier's lower boundary.", "第五档的下边界。"),
                    F("Discount5", "The discount of the fifth tier.", "第五档的折扣。"),
                    F("Boundary6", "The sixth tier's lower boundary.", "第六档的下边界。"),
                    F("Discount6", "The discount of the sixth tier.", "第六档的折扣。"),
                    F("Boundary7", "The seventh tier's lower boundary.", "第七档的下边界。"),
                    F("Discount7", "The discount of the seventh tier.", "第七档的折扣。"),
                    F("Boundary8", "The eighth tier's lower boundary.", "第八档的下边界。"),
                    F("Discount8", "The discount of the eighth tier.", "第八档的折扣。"),
                    F("Boundary9", "The ninth tier's lower boundary.", "第九档的下边界。"),
                    F("Discount9", "The discount of the ninth tier.", "第九档的折扣。"),
                    F("Boundary10", "The tenth tier's lower boundary.", "第十档的下边界。"),
                    F("Discount10", "The discount of the tenth tier.", "第十档的折扣。"),
                ]),

            // ---- EdiBehaviors ---------------------------------------------------------
            Content(
                "Monitor.API.Common.Commands.EdiBehaviors.AddCustomersToEdiBehavior",
                "Add customers to an EDI behavior.",
                "将客户添加到 EDI 行为。",
                ["add edi customer", "add customer to edi"], ["添加EDI客户"],
                fields: [
                    F("EdiBehaviorId", "The EDI behavior to add customers to.", "要添加客户的 EDI 行为。"),
                    F("CustomerIds", "The customers to add.", "要添加的客户。"),
                    F("InvoiceCustomerIds", "The customers to add as invoice recipients.", "要添加为发票接收方的客户。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.EdiBehaviors.RemoveCustomersFromEdiBehavior",
                "Remove customers from an EDI behavior.",
                "从 EDI 行为中移除客户。",
                ["remove edi customer", "remove customer from edi"], ["移除EDI客户"],
                fields: [
                    F("EdiBehaviorId", "The EDI behavior to remove customers from.", "要移除客户的 EDI 行为。"),
                    F("CustomerIds", "The customers to remove.", "要移除的客户。"),
                    F("InvoiceCustomerIds", "The customers to remove as invoice recipients.", "要移除为发票接收方的客户。"),
                ]),

            // ---- Emails ---------------------------------------------------------------
            Content(
                "Monitor.API.Common.Commands.Emails.CreateEmailOnEntity",
                "Create an e-mail on an entity.",
                "在实体上创建电子邮件。",
                ["create email", "add email"], ["创建邮件", "添加邮件"],
                fields: [
                    F("EntityId", "The entity to create the e-mail on.", "要创建邮件的实体。"),
                    F("EntityType", "The type of entity to create the e-mail on.", "要创建邮件的实体类型。"),
                    F("Email", "The e-mail to create.", "要创建的电子邮件。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Emails.GetEmail",
                "Get an e-mail of an entity.",
                "获取实体的电子邮件。",
                ["get email", "read email"], ["获取邮件", "读取邮件"],
                fields: [
                    F("EntityId", "The entity the e-mail belongs to.", "邮件所属的实体。"),
                    F("EntityType", "The type of entity the e-mail belongs to.", "邮件所属的实体类型。"),
                    F("EmailId", "The e-mail to get.", "要获取的邮件。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Emails.GetEmailsForEntity",
                "Get the e-mails of an entity.",
                "获取实体的电子邮件列表。",
                ["get emails", "email list"], ["获取邮件列表", "邮件列表"],
                fields: [
                    F("EntityId", "The entity to get e-mails for.", "要获取邮件的实体。"),
                    F("EntityType", "The type of entity to get e-mails for.", "要获取邮件的实体类型。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Emails.RemoveEmailFromEntity",
                "Remove an e-mail from an entity.",
                "从实体移除电子邮件。",
                ["remove email", "delete email"], ["删除邮件", "移除邮件"],
                fields: [
                    F("EntityId", "The entity to remove the e-mail from.", "要移除邮件的实体。"),
                    F("EntityType", "The type of entity to remove the e-mail from.", "要移除邮件的实体类型。"),
                    F("EmailId", "The e-mail to remove.", "要移除的邮件。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Emails.SendSystemEmail",
                "Send a system e-mail.",
                "发送系统电子邮件。",
                ["send system email", "system mail"], ["发送系统邮件"],
                fields: [
                    F("From", "The sender address of the e-mail.", "邮件的发件人地址。"),
                    F("Contents", "The contents of the e-mail.", "邮件的内容。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Emails.SendUserEmail",
                "Send an e-mail from the logged-in user.",
                "以当前用户身份发送电子邮件。",
                ["send user email", "send email"], ["发送用户邮件", "发送邮件"],
                fields: [
                    F("Contents", "The contents of the e-mail.", "邮件的内容。"),
                ]),

            // ---- EntityBusyStates -----------------------------------------------------
            Content(
                "Monitor.API.Common.Commands.EntityBusyStates.AcquireEntityBusyState",
                "Acquire the busy state of an entity to lock it for editing.",
                "获取实体的占用状态以将其锁定进行编辑。",
                ["acquire busy state", "lock entity"], ["获取占用状态", "锁定实体"],
                fields: [
                    F("EntityTypeId", "The type of the entity to lock.", "要锁定的实体类型。"),
                    F("EntityId", "The entity to lock.", "要锁定的实体。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.EntityBusyStates.GetEntityBusyState",
                "Get the busy state of an entity.",
                "获取实体的占用状态。",
                ["get busy state", "entity lock status"], ["获取占用状态", "实体锁定状态"],
                fields: [
                    F("EntityTypeId", "The type of the entity.", "实体类型。"),
                    F("EntityId", "The entity.", "实体。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.EntityBusyStates.GetEntityBusyStatesByEntityType",
                "Get the busy states of all entities of a type.",
                "获取某类型所有实体的占用状态。",
                ["busy states by type"], ["按类型获取占用状态"],
                fields: [
                    F("EntityTypeId", "The type of the entities.", "实体类型。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.EntityBusyStates.ReleaseEntityBusyState",
                "Release the busy state of an entity.",
                "释放实体的占用状态。",
                ["release busy state", "unlock entity"], ["释放占用状态", "解锁实体"],
                fields: [
                    F("EntityTypeId", "The type of the entity to release.", "要释放的实体类型。"),
                    F("EntityId", "The entity to release.", "要释放的实体。"),
                    F("SessionId", "The session that holds the busy state.", "持有占用状态的会话。"),
                ]),

            // ---- ExtraFields ----------------------------------------------------------
            Content(
                "Monitor.API.Common.Commands.ExtraFields.AddExtraFieldOptionTemplate",
                "Add an option template to an extra-field template.",
                "为附加字段模板添加选项模板。",
                ["add option", "add extra field option"], ["添加选项模板", "添加选项"],
                fields: [
                    F("ExtraFieldTemplateId", "The extra-field template to add the option to.", "要添加选项的附加字段模板。"),
                    F("Code", "The code of the option.", "选项的代码。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.ExtraFields.AddExtraFieldTemplate",
                "Add an extra-field template to a group.",
                "向附加字段组添加附加字段模板。",
                ["add extra field", "add field template"], ["添加附加字段", "添加字段模板"],
                fields: [
                    F("ExtraFieldGroupId", "The extra-field group to add the template to.", "要添加模板的附加字段组。"),
                    F("Name", "The name of the template.", "模板的名称。"),
                    F("Type", "The value type of the extra field (string, integer, decimal, date, options...).", "附加字段的值类型（文本、整数、小数、日期、选项等）。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.ExtraFields.CreateExtraField",
                "Create an extra field on an entity.",
                "在实体上创建附加字段。",
                ["create extra field", "create custom field"], ["创建附加字段", "创建自定义字段"],
                fields: [
                    F("EntityId", "The entity to create the extra field on.", "要创建附加字段的实体。"),
                    F("EntityType", "The type of entity to create the extra field on.", "要创建附加字段的实体类型。"),
                    F("Identifier", "The identifier of the extra field.", "附加字段的标识。"),
                    F("ExtraFieldTemplateId", "The extra-field template of the field.", "附加字段的模板。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.ExtraFields.CreateExtraFieldGroup",
                "Create an extra-field group.",
                "创建附加字段组。",
                ["create extra field group", "new field group"], ["创建附加字段组", "新建字段组"],
                fields: [
                    F("Name", "The name of the group.", "组的名称。"),
                    F("EntityType", "The entity type the group is used on.", "组适用的实体类型。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.ExtraFields.RemoveExtraFieldGroup",
                "Remove an extra-field group.",
                "删除附加字段组。",
                ["remove extra field group", "delete field group"], ["删除附加字段组", "移除附加字段组"],
                fields: [
                    F("Id", "The extra-field group to remove.", "要删除的附加字段组。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.ExtraFields.RemoveExtraFieldOptionTemplate",
                "Remove an option template from an extra-field template.",
                "从附加字段模板移除选项模板。",
                ["remove option", "remove extra field option"], ["移除选项模板", "移除选项"],
                fields: [
                    F("Id", "The option template to remove.", "要移除的选项模板。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.ExtraFields.RemoveExtraFieldTemplate",
                "Remove an extra-field template.",
                "删除附加字段模板。",
                ["remove extra field template", "delete field template"], ["删除附加字段模板", "移除附加字段模板"],
                fields: [
                    F("Id", "The extra-field template to remove.", "要删除的附加字段模板。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.ExtraFields.SetExtraFieldValues",
                "Set the extra field values of an entity.",
                "设置实体的附加字段值。",
                ["set extra field values", "update extra fields"], ["设置附加字段值", "更新附加字段"],
                fields: [
                    F("EntityId", "The entity to set the extra field values for.", "要设置附加字段值的实体。"),
                    F("EntityType", "The type of entity to set the extra field values for.", "要设置附加字段值的实体类型。"),
                    F("Values", "The extra field values to set.", "要设置的附加字段值。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.ExtraFields.UpdateExtraFieldGroup",
                "Update an extra-field group.",
                "更新附加字段组。",
                ["update extra field group", "rename field group"], ["更新附加字段组", "重命名字段组"],
                fields: [
                    F("Id", "The extra-field group to update.", "要更新的附加字段组。"),
                    F("Name", "The name of the group.", "组的名称。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.ExtraFields.UpdateExtraFieldOptionTemplate",
                "Update an option template of an extra-field template.",
                "更新附加字段模板的选项模板。",
                ["update option", "update extra field option"], ["更新选项模板"],
                fields: [
                    F("Id", "The option template to update.", "要更新的选项模板。"),
                    F("Code", "The code of the option.", "选项的代码。"),
                    F("Description", "A description of the option.", "选项的描述。"),
                    F("IsActive", "Whether the option is active.", "选项是否启用。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.ExtraFields.UpdateExtraFieldTemplate",
                "Update an extra-field template.",
                "更新附加字段模板。",
                ["update extra field template", "edit field template"], ["更新附加字段模板"],
                fields: [
                    F("Id", "The extra-field template to update.", "要更新的附加字段模板。"),
                    F("Name", "The name of the template.", "模板的名称。"),
                    F("Description", "A description of the template.", "模板的描述。"),
                ]),

            // ---- FilePaths ------------------------------------------------------------
            Content(
                "Monitor.API.Common.Commands.FilePaths.CreateFilePath",
                "Create a file path.",
                "创建文件路径。",
                ["create file path", "add file path"], ["创建文件路径", "添加文件路径"],
                fields: [
                    F("Path", "The unique storage path.", "唯一的存储路径。"),
                    F("Category", "What the file path is used for (file viewer, accounting export, server printer...).", "文件路径的用途（文件查看器、会计导出、服务器打印机等）。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.FilePaths.UploadFile",
                "Upload a file to a file path.",
                "将文件上传到文件路径。",
                ["upload file", "upload"], ["上传文件", "上传"],
                fields: [
                    F("FilePathId", "The file path to upload to.", "要上传到的文件路径。"),
                    F("FileName", "The name of the file.", "文件的名称。"),
                    F("Data", "The file content.", "文件内容。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.GetCategoryComponentValue",
                "Get the values of a category component.",
                "获取类别组件的值。",
                ["get category values", "category component values"], ["获取类别值", "类别组件值"],
                fields: [
                    F("CategoryType", "The entity type of the category component.", "类别组件的实体类型。"),
                ]),

            // ---- ManageFiles ----------------------------------------------------------
            Content(
                "Monitor.API.Common.Commands.ManageFiles.Copy",
                "Copy a file or folder in a file path.",
                "在文件路径中复制文件或文件夹。",
                ["copy file", "copy folder"], ["复制文件", "复制文件夹"],
                fields: [
                    F("FilePathId", "The file path to copy within.", "要复制所处的文件路径。"),
                    F("ItemPath", "The path of the item to copy.", "要复制的项目路径。"),
                    F("TargetPath", "The destination path.", "目标路径。"),
                    F("ConflictResolution", "How to resolve a conflict at the target (overwrite, skip, or rename).", "目标处冲突的解决方式（覆盖、跳过或重命名）。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.ManageFiles.CreateFolder",
                "Create a folder in a file path.",
                "在文件路径中创建文件夹。",
                ["create folder", "new folder", "mkdir"], ["创建文件夹", "新建文件夹"],
                fields: [
                    F("FilePathId", "The file path to create the folder in.", "要创建文件夹的文件路径。"),
                    F("FolderPath", "The path of the folder to create.", "要创建的文件夹路径。"),
                    F("ConflictResolution", "How to resolve a conflict (overwrite, skip, or rename).", "冲突的解决方式（覆盖、跳过或重命名）。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.ManageFiles.Delete",
                "Delete a file or folder in a file path.",
                "删除文件路径中的文件或文件夹。",
                ["delete file", "delete folder", "remove file"], ["删除文件", "删除文件夹"],
                fields: [
                    F("FilePathId", "The file path to delete within.", "要删除所处的文件路径。"),
                    F("ItemPath", "The path of the item to delete.", "要删除的项目路径。"),
                    F("DeleteResolution", "Whether to delete the item and break its links.", "是否删除项目并断开其链接。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.ManageFiles.DownloadFile",
                "Download a file from a file path.",
                "从文件路径下载文件。",
                ["download file", "download"], ["下载文件", "下载"],
                fields: [
                    F("FilePathId", "The file path to download from.", "要下载所处的文件路径。"),
                    F("FilePath", "The path of the file to download.", "要下载的文件路径。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.ManageFiles.GetItemInFolder",
                "Get the items in a folder of a file path.",
                "获取文件路径中某文件夹的项目。",
                ["get folder items", "list folder", "folder contents"], ["获取文件夹项目", "列出文件夹"],
                fields: [
                    F("FilePathId", "The file path to list within.", "要列出的文件路径。"),
                    F("FolderPath", "The folder to list; omit for the root.", "要列出的文件夹；省略则为根目录。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.ManageFiles.Move",
                "Move a file or folder within a file path.",
                "在文件路径中移动文件或文件夹。",
                ["move file", "move folder"], ["移动文件", "移动文件夹"],
                fields: [
                    F("FilePathId", "The file path to move within.", "要移动所处的文件路径。"),
                    F("ItemPath", "The path of the item to move.", "要移动的项目路径。"),
                    F("TargetPath", "The destination path.", "目标路径。"),
                    F("ConflictResolution", "How to resolve a conflict at the target (overwrite, skip, or rename).", "目标处冲突的解决方式（覆盖、跳过或重命名）。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.ManageFiles.Rename",
                "Rename a file or folder in a file path.",
                "重命名文件路径中的文件或文件夹。",
                ["rename file", "rename folder"], ["重命名文件", "重命名文件夹"],
                fields: [
                    F("FilePathId", "The file path to rename within.", "要重命名所处的文件路径。"),
                    F("ItemPath", "The path of the item to rename.", "要重命名的项目路径。"),
                    F("NewItemName", "The new name of the item.", "项目的新名称。"),
                    F("ConflictResolution", "How to resolve a conflict (overwrite, skip, or rename).", "冲突的解决方式（覆盖、跳过或重命名）。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.ManageFiles.UploadFileStream",
                "Upload a file stream to a file path.",
                "将文件流上传到文件路径。",
                ["upload stream", "upload file stream"], ["上传文件流"],
                fields: [
                    F("FilePathId", "The file path to upload to.", "要上传到的文件路径。"),
                    F("FilePath", "The path of the file to write.", "要写入的文件路径。"),
                    F("Data", "The file content.", "文件内容。"),
                    F("ConflictResolution", "How to resolve a conflict (overwrite, skip, or rename).", "冲突的解决方式（覆盖、跳过或重命名）。"),
                ]),

            // ---- MonitoringTasks ------------------------------------------------------
            Content(
                "Monitor.API.Common.Commands.MonitoringTasks.AddArrivalReportingRow",
                "Add an arrival-reporting condition row to a monitoring task.",
                "为监控任务添加入库报告条件行。",
                ["add arrival reporting row", "arrival condition"], ["添加入库报告行"],
                fields: [
                    F("TaskId", "The monitoring task to add the row to.", "要添加行的监控任务。"),
                    F("PartId", "The part whose arrival reporting triggers the task.", "入库报告触发任务的物料。"),
                    F("ConditionType", "The condition that triggers the task.", "触发任务的条件。"),
                    F("Message", "The message sent when the condition triggers.", "条件触发时发送的消息。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.MonitoringTasks.AddBlanketOrderPurchaseActivityRow",
                "Add a blanket-order-purchase activity condition row to a monitoring task.",
                "为监控任务添加入口订单采购活动条件行。",
                ["add blanket order purchase row", "blanket order activity"], ["添加入口订单采购活动行"],
                fields: [
                    F("TaskId", "The monitoring task to add the row to.", "要添加行的监控任务。"),
                    F("BlanketOrderPurchaseActivityId", "The blanket-order-purchase activity to watch.", "要监视的入口订单采购活动。"),
                    F("ConditionType", "The condition that triggers the task.", "触发任务的条件。"),
                    F("Message", "The message sent when the condition triggers.", "条件触发时发送的消息。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.MonitoringTasks.AddBlanketOrderSalesActivityRow",
                "Add a blanket-order-sales activity condition row to a monitoring task.",
                "为监控任务添加销售框架协议活动条件行。",
                ["add blanket order sales row", "blanket order activity"], ["添加销售框架协议活动行"],
                fields: [
                    F("TaskId", "The monitoring task to add the row to.", "要添加行的监控任务。"),
                    F("BlanketOrderSalesActivityId", "The blanket-order-sales activity to watch.", "要监视的销售框架协议活动。"),
                    F("ConditionType", "The condition that triggers the task.", "触发任务的条件。"),
                    F("Message", "The message sent when the condition triggers.", "条件触发时发送的消息。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.MonitoringTasks.AddCaseEntryActivityRow",
                "Add a case-entry activity condition row to a monitoring task.",
                "为监控任务添加案例登记活动条件行。",
                ["add case activity row", "case entry condition"], ["添加案例活动行"],
                fields: [
                    F("TaskId", "The monitoring task to add the row to.", "要添加行的监控任务。"),
                    F("CaseEntryActivityId", "The case-entry activity to watch.", "要监视的案例登记活动。"),
                    F("ConditionType", "The condition that triggers the task.", "触发任务的条件。"),
                    F("Message", "The message sent when the condition triggers.", "条件触发时发送的消息。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.MonitoringTasks.AddCustomerActivityRow",
                "Add a customer-relationship-management activity condition row to a monitoring task.",
                "为监控任务添加客户管理活动条件行。",
                ["add customer activity row", "customer activity condition"], ["添加客户活动行"],
                fields: [
                    F("TaskId", "The monitoring task to add the row to.", "要添加行的监控任务。"),
                    F("CustomerRelationShipManagementActivityId", "The customer relationship management activity to watch.", "要监视的客户关系管理活动。"),
                    F("ConditionType", "The condition that triggers the task.", "触发任务的条件。"),
                    F("Message", "The message sent when the condition triggers.", "条件触发时发送的消息。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.MonitoringTasks.AddCustomerOrderActivityRow",
                "Add a customer-order activity condition row to a monitoring task.",
                "为监控任务添加客户订单活动条件行。",
                ["add customer order activity row", "customer order condition"], ["添加客户订单活动行"],
                fields: [
                    F("TaskId", "The monitoring task to add the row to.", "要添加行的监控任务。"),
                    F("CustomerOrderActivityId", "The customer-order activity to watch.", "要监视的客户订单活动。"),
                    F("ConditionType", "The condition that triggers the task.", "触发任务的条件。"),
                    F("Message", "The message sent when the condition triggers.", "条件触发时发送的消息。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.MonitoringTasks.AddInquiryActivityRow",
                "Add an inquiry-activity condition row to a monitoring task.",
                "为监控任务添加询价活动条件行。",
                ["add inquiry activity row", "inquiry condition"], ["添加询价活动行"],
                fields: [
                    F("TaskId", "The monitoring task to add the row to.", "要添加行的监控任务。"),
                    F("InquiryActivityId", "The inquiry activity to watch.", "要监视的询价活动。"),
                    F("ConditionType", "The condition that triggers the task.", "触发任务的条件。"),
                    F("Message", "The message sent when the condition triggers.", "条件触发时发送的消息。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.MonitoringTasks.AddManufacturingOrderOperationRow",
                "Add a manufacturing-order-operation condition row to a monitoring task.",
                "为监控任务添加制造工单工序条件行。",
                ["add manufacturing operation row", "operation condition"], ["添加制造工序行"],
                fields: [
                    F("TaskId", "The monitoring task to add the row to.", "要添加行的监控任务。"),
                    F("ManufacturingOrderOperationId", "The manufacturing-order operation to watch.", "要监视的制造工单工序。"),
                    F("ConditionType", "The condition that triggers the task.", "触发任务的条件。"),
                    F("Message", "The message sent when the condition triggers.", "条件触发时发送的消息。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.MonitoringTasks.AddMonitoringTaskRecipient",
                "Add a recipient to a monitoring task.",
                "为监控任务添加收件人。",
                ["add recipient", "add task recipient"], ["添加收件人", "添加任务收件人"],
                fields: [
                    F("TaskId", "The monitoring task to add the recipient to.", "要添加收件人的监控任务。"),
                    F("LanguageCodeId", "The language used for the recipient's messages.", "收件人消息使用的语言。"),
                    F("RecipientType", "How the recipient is reached (e-mail, notification, or user e-mail).", "联系收件人的方式（电子邮件、通知或用户电子邮件）。"),
                    F("Email", "The e-mail address of the recipient.", "收件人的电子邮件地址。"),
                    F("ApplicationUserId", "The user recipient, when the recipient is a user.", "收件人为用户时的用户。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.MonitoringTasks.AddOrderRowArrivalReportingRow",
                "Add a purchase-order-row arrival-reporting condition row to a monitoring task.",
                "为监控任务添加入库报告条件行（采购订单行）。",
                ["add order row arrival row", "purchase order arrival"], ["添加采购订单行入库报告"],
                fields: [
                    F("TaskId", "The monitoring task to add the row to.", "要添加行的监控任务。"),
                    F("PurchaseOrderRowId", "The purchase-order row whose arrival reporting triggers the task.", "入库报告触发任务的采购订单行。"),
                    F("ConditionType", "The condition that triggers the task.", "触发任务的条件。"),
                    F("Message", "The message sent when the condition triggers.", "条件触发时发送的消息。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.MonitoringTasks.AddPartActivityRow",
                "Add a part-activity condition row to a monitoring task.",
                "为监控任务添加物料活动条件行。",
                ["add part activity row", "part condition"], ["添加物料活动行"],
                fields: [
                    F("TaskId", "The monitoring task to add the row to.", "要添加行的监控任务。"),
                    F("PartActivityId", "The part activity to watch.", "要监视的物料活动。"),
                    F("ConditionType", "The condition that triggers the task.", "触发任务的条件。"),
                    F("Message", "The message sent when the condition triggers.", "条件触发时发送的消息。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.MonitoringTasks.AddPersonActivityRow",
                "Add a person-activity condition row to a monitoring task.",
                "为监控任务添加人员活动条件行。",
                ["add person activity row", "person condition"], ["添加人员活动行"],
                fields: [
                    F("TaskId", "The monitoring task to add the row to.", "要添加行的监控任务。"),
                    F("PersonActivityId", "The person activity to watch.", "要监视的人员活动。"),
                    F("ConditionType", "The condition that triggers the task.", "触发任务的条件。"),
                    F("Message", "The message sent when the condition triggers.", "条件触发时发送的消息。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.MonitoringTasks.AddPurchaseOrderActivityRow",
                "Add a purchase-order-activity condition row to a monitoring task.",
                "为监控任务添加采购订单活动条件行。",
                ["add purchase order activity row", "purchase order condition"], ["添加采购订单活动行"],
                fields: [
                    F("TaskId", "The monitoring task to add the row to.", "要添加行的监控任务。"),
                    F("PurchaseOrderActivityId", "The purchase-order activity to watch.", "要监视的采购订单活动。"),
                    F("ConditionType", "The condition that triggers the task.", "触发任务的条件。"),
                    F("Message", "The message sent when the condition triggers.", "条件触发时发送的消息。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.MonitoringTasks.AddQuoteActivityRow",
                "Add a quote-activity condition row to a monitoring task.",
                "为监控任务添加报价活动条件行。",
                ["add quote activity row", "quote condition"], ["添加报价活动行"],
                fields: [
                    F("TaskId", "The monitoring task to add the row to.", "要添加行的监控任务。"),
                    F("QuoteActivityId", "The quote activity to watch.", "要监视的报价活动。"),
                    F("ConditionType", "The condition that triggers the task.", "触发任务的条件。"),
                    F("Message", "The message sent when the condition triggers.", "条件触发时发送的消息。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.MonitoringTasks.AddSalesAgreementActivityRow",
                "Add a sales-agreement-activity condition row to a monitoring task.",
                "为监控任务添加销售协议活动条件行。",
                ["add sales agreement row", "sales agreement condition"], ["添加销售协议活动行"],
                fields: [
                    F("TaskId", "The monitoring task to add the row to.", "要添加行的监控任务。"),
                    F("SalesAgreementActivityId", "The sales-agreement activity to watch.", "要监视的销售协议活动。"),
                    F("ConditionType", "The condition that triggers the task.", "触发任务的条件。"),
                    F("Message", "The message sent when the condition triggers.", "条件触发时发送的消息。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.MonitoringTasks.AddStockBalanceRow",
                "Add a stock-balance condition row to a monitoring task.",
                "为监控任务添加库存余额条件行。",
                ["add stock balance row", "stock condition"], ["添加库存余额行"],
                fields: [
                    F("TaskId", "The monitoring task to add the row to.", "要添加行的监控任务。"),
                    F("PartId", "The part whose stock balance is watched.", "要监视库存余额的物料。"),
                    F("ConditionType", "The stock condition that triggers the task (equal, threshold, below safety level...).", "触发任务的库存条件（等于、阈值、低于安全库存等）。"),
                    F("Value", "The value the condition compares against.", "条件与之比较的值。"),
                    F("Message", "The message sent when the condition triggers.", "条件触发时发送的消息。"),
                    F("WarehouseIds", "The warehouses the condition applies to.", "条件适用的仓库。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.MonitoringTasks.AddSupplierActivityRow",
                "Add a supplier-relationship-management activity condition row to a monitoring task.",
                "为监控任务添加供应商管理活动条件行。",
                ["add supplier activity row", "supplier condition"], ["添加供应商活动行"],
                fields: [
                    F("TaskId", "The monitoring task to add the row to.", "要添加行的监控任务。"),
                    F("SupplierRelationshipManagementActivityId", "The supplier relationship management activity to watch.", "要监视的供应商关系管理活动。"),
                    F("ConditionType", "The condition that triggers the task.", "触发任务的条件。"),
                    F("Message", "The message sent when the condition triggers.", "条件触发时发送的消息。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.MonitoringTasks.CreateMonitoringTask",
                "Create a monitoring task.",
                "创建监控任务。",
                ["create monitoring task", "create alert", "new task"], ["创建监控任务", "新建监控任务"],
                fields: [
                    F("Number", "The unique number of the task.", "任务的唯一编号。"),
                    F("Name", "The name of the task.", "任务的名称。"),
                    F("TaskType", "The business condition the task watches (stock balance, activity, arrival...).", "任务监视的业务条件（库存余额、活动、到货等）。"),
                    F("Status", "Whether the task is active or disabled.", "任务是启用还是禁用。"),
                    F("ApplicationUserId", "The user responsible for the task.", "负责该任务的用户。"),
                    F("Comment", "A comment on the task.", "任务的备注。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.MonitoringTasks.RemoveMonitoringTask",
                "Remove a monitoring task.",
                "删除监控任务。",
                ["remove monitoring task", "delete alert"], ["删除监控任务", "移除监控任务"],
                fields: [
                    F("Id", "The monitoring task to remove.", "要删除的监控任务。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.MonitoringTasks.RemoveMonitoringTaskRecipient",
                "Remove a recipient from a monitoring task.",
                "从监控任务移除收件人。",
                ["remove recipient", "remove task recipient"], ["移除收件人", "移除任务收件人"],
                fields: [
                    F("Id", "The recipient to remove.", "要移除的收件人。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.MonitoringTasks.RemoveMonitoringTaskRow",
                "Remove a condition row from a monitoring task.",
                "从监控任务移除条件行。",
                ["remove task row", "remove condition row"], ["移除任务行", "移除条件行"],
                fields: [
                    F("Id", "The condition row to remove.", "要移除的条件行。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.MonitoringTasks.UpdateArrivalReportingRow",
                "Update an arrival-reporting condition row of a monitoring task.",
                "更新监控任务的入库报告条件行。",
                ["update arrival reporting row"], ["更新入库报告行"],
                fields: [
                    F("Id", "The condition row to update.", "要更新的条件行。"),
                    F("ConditionType", "The condition that triggers the task.", "触发任务的条件。"),
                    F("Message", "The message sent when the condition triggers.", "条件触发时发送的消息。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.MonitoringTasks.UpdateBlanketOrderPurchaseActivityRow",
                "Update a blanket-order-purchase activity condition row of a monitoring task.",
                "更新监控任务的入口订单采购活动条件行。",
                ["update blanket order purchase row"], ["更新入口订单采购活动行"],
                fields: [
                    F("Id", "The condition row to update.", "要更新的条件行。"),
                    F("ConditionType", "The condition that triggers the task.", "触发任务的条件。"),
                    F("Message", "The message sent when the condition triggers.", "条件触发时发送的消息。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.MonitoringTasks.UpdateBlanketOrderSalesActivityRow",
                "Update a blanket-order-sales activity condition row of a monitoring task.",
                "更新监控任务的销售框架协议活动条件行。",
                ["update blanket order sales row"], ["更新销售框架协议活动行"],
                fields: [
                    F("Id", "The condition row to update.", "要更新的条件行。"),
                    F("ConditionType", "The condition that triggers the task.", "触发任务的条件。"),
                    F("Message", "The message sent when the condition triggers.", "条件触发时发送的消息。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.MonitoringTasks.UpdateCaseEntryActivityRow",
                "Update a case-entry activity condition row of a monitoring task.",
                "更新监控任务的案例登记活动条件行。",
                ["update case entry row"], ["更新案例活动行"],
                fields: [
                    F("Id", "The condition row to update.", "要更新的条件行。"),
                    F("ConditionType", "The condition that triggers the task.", "触发任务的条件。"),
                    F("Message", "The message sent when the condition triggers.", "条件触发时发送的消息。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.MonitoringTasks.UpdateCustomerActivityRow",
                "Update a customer-activity condition row of a monitoring task.",
                "更新监控任务的客户活动条件行。",
                ["update customer activity row"], ["更新客户活动行"],
                fields: [
                    F("Id", "The condition row to update.", "要更新的条件行。"),
                    F("ConditionType", "The condition that triggers the task.", "触发任务的条件。"),
                    F("Message", "The message sent when the condition triggers.", "条件触发时发送的消息。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.MonitoringTasks.UpdateCustomerOrderActivityRow",
                "Update a customer-order-activity condition row of a monitoring task.",
                "更新监控任务的客户订单活动条件行。",
                ["update customer order activity row"], ["更新客户订单活动行"],
                fields: [
                    F("Id", "The condition row to update.", "要更新的条件行。"),
                    F("ConditionType", "The condition that triggers the task.", "触发任务的条件。"),
                    F("Message", "The message sent when the condition triggers.", "条件触发时发送的消息。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.MonitoringTasks.UpdateInquiryActivityRow",
                "Update an inquiry-activity condition row of a monitoring task.",
                "更新监控任务的询价活动条件行。",
                ["update inquiry activity row"], ["更新询价活动行"],
                fields: [
                    F("Id", "The condition row to update.", "要更新的条件行。"),
                    F("ConditionType", "The condition that triggers the task.", "触发任务的条件。"),
                    F("Message", "The message sent when the condition triggers.", "条件触发时发送的消息。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.MonitoringTasks.UpdateManufacturingOrderOperationRow",
                "Update a manufacturing-order-operation condition row of a monitoring task.",
                "更新监控任务的制造工单工序条件行。",
                ["update manufacturing operation row"], ["更新制造工序行"],
                fields: [
                    F("Id", "The condition row to update.", "要更新的条件行。"),
                    F("ConditionType", "The condition that triggers the task.", "触发任务的条件。"),
                    F("Message", "The message sent when the condition triggers.", "条件触发时发送的消息。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.MonitoringTasks.UpdateMonitoringTask",
                "Update a monitoring task.",
                "更新监控任务。",
                ["update monitoring task", "edit alert"], ["更新监控任务", "修改监控任务"],
                fields: [
                    F("Id", "The monitoring task to update.", "要更新的监控任务。"),
                    F("Name", "The name of the task.", "任务的名称。"),
                    F("Status", "Whether the task is active or disabled.", "任务是启用还是禁用。"),
                    F("UseSchedule", "Whether the task runs on a schedule.", "任务是否按计划运行。"),
                    F("RunOnce", "Whether the task runs once.", "任务是否只运行一次。"),
                    F("StartTime", "The start time of the schedule.", "计划的开始时间。"),
                    F("StopTime", "The stop time of the schedule.", "计划的结束时间。"),
                    F("Comment", "A comment on the task.", "任务的备注。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.MonitoringTasks.UpdateMonitoringTaskRecipient",
                "Update a recipient of a monitoring task.",
                "更新监控任务的收件人。",
                ["update recipient", "update task recipient"], ["更新收件人"],
                fields: [
                    F("Id", "The recipient to update.", "要更新的收件人。"),
                    F("LanguageCodeId", "The language used for the recipient's messages.", "收件人消息使用的语言。"),
                    F("RecipientType", "How the recipient is reached (e-mail, notification, or user e-mail).", "联系收件人的方式（电子邮件、通知或用户电子邮件）。"),
                    F("Email", "The e-mail address of the recipient.", "收件人的电子邮件地址。"),
                    F("ApplicationUserId", "The user recipient, when the recipient is a user.", "收件人为用户时的用户。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.MonitoringTasks.UpdateOrderRowArrivalReportingRow",
                "Update an order-row arrival-reporting condition row of a monitoring task.",
                "更新监控任务的订单行入库报告条件行。",
                ["update order row arrival row"], ["更新订单行入库报告行"],
                fields: [
                    F("Id", "The condition row to update.", "要更新的条件行。"),
                    F("ConditionType", "The condition that triggers the task.", "触发任务的条件。"),
                    F("Message", "The message sent when the condition triggers.", "条件触发时发送的消息。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.MonitoringTasks.UpdatePartActivityRow",
                "Update a part-activity condition row of a monitoring task.",
                "更新监控任务的物料活动条件行。",
                ["update part activity row"], ["更新物料活动行"],
                fields: [
                    F("Id", "The condition row to update.", "要更新的条件行。"),
                    F("ConditionType", "The condition that triggers the task.", "触发任务的条件。"),
                    F("Message", "The message sent when the condition triggers.", "条件触发时发送的消息。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.MonitoringTasks.UpdatePersonActivityRow",
                "Update a person-activity condition row of a monitoring task.",
                "更新监控任务的人员活动条件行。",
                ["update person activity row"], ["更新人员活动行"],
                fields: [
                    F("Id", "The condition row to update.", "要更新的条件行。"),
                    F("ConditionType", "The condition that triggers the task.", "触发任务的条件。"),
                    F("Message", "The message sent when the condition triggers.", "条件触发时发送的消息。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.MonitoringTasks.UpdatePurchaseOrderActivityRow",
                "Update a purchase-order-activity condition row of a monitoring task.",
                "更新监控任务的采购订单活动条件行。",
                ["update purchase order activity row"], ["更新采购订单活动行"],
                fields: [
                    F("Id", "The condition row to update.", "要更新的条件行。"),
                    F("ConditionType", "The condition that triggers the task.", "触发任务的条件。"),
                    F("Message", "The message sent when the condition triggers.", "条件触发时发送的消息。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.MonitoringTasks.UpdateQuoteActivityRow",
                "Update a quote-activity condition row of a monitoring task.",
                "更新监控任务的报价活动条件行。",
                ["update quote activity row"], ["更新报价活动行"],
                fields: [
                    F("Id", "The condition row to update.", "要更新的条件行。"),
                    F("ConditionType", "The condition that triggers the task.", "触发任务的条件。"),
                    F("Message", "The message sent when the condition triggers.", "条件触发时发送的消息。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.MonitoringTasks.UpdateSalesAgreementActivityRow",
                "Update a sales-agreement-activity condition row of a monitoring task.",
                "更新监控任务的销售协议活动条件行。",
                ["update sales agreement row"], ["更新销售协议活动行"],
                fields: [
                    F("Id", "The condition row to update.", "要更新的条件行。"),
                    F("ConditionType", "The condition that triggers the task.", "触发任务的条件。"),
                    F("Message", "The message sent when the condition triggers.", "条件触发时发送的消息。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.MonitoringTasks.UpdateStockBalanceRow",
                "Update a stock-balance condition row of a monitoring task.",
                "更新监控任务的库存余额条件行。",
                ["update stock balance row"], ["更新库存余额行"],
                fields: [
                    F("Id", "The condition row to update.", "要更新的条件行。"),
                    F("ConditionType", "The stock condition that triggers the task.", "触发任务的库存条件。"),
                    F("Value", "The value the condition compares against.", "条件与之比较的值。"),
                    F("Message", "The message sent when the condition triggers.", "条件触发时发送的消息。"),
                    F("WarehouseIds", "The warehouses the condition applies to.", "条件适用的仓库。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.MonitoringTasks.UpdateSupplierActivityRow",
                "Update a supplier-activity condition row of a monitoring task.",
                "更新监控任务的供应商活动条件行。",
                ["update supplier activity row"], ["更新供应商活动行"],
                fields: [
                    F("Id", "The condition row to update.", "要更新的条件行。"),
                    F("ConditionType", "The condition that triggers the task.", "触发任务的条件。"),
                    F("Message", "The message sent when the condition triggers.", "条件触发时发送的消息。"),
                ]),

            // ---- Others ---------------------------------------------------------------
            Content(
                "Monitor.API.Common.Commands.Others.AddWorkdaysToDate",
                "Add a number of workdays to a date.",
                "在日期上加上一定的工作日数。",
                ["add workdays", "workday calculation"], ["加工作日", "工作日计算"],
                fields: [
                    F("WarehouseId", "The warehouse whose calendar is used.", "使用其日历的仓库。"),
                    F("StartDate", "The start date; defaults to today.", "开始日期；默认为今天。"),
                    F("WorkdayCount", "The number of workdays to add.", "要添加的工作日数。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Others.GetEntity",
                "Get an entity by its path and id.",
                "按路径与 ID 获取实体。",
                ["get entity", "get by path"], ["获取实体", "按路径获取"],
                fields: [
                    F("Path", "The path of the entity to get.", "要获取实体的路径。"),
                    F("EntityId", "The id of the entity to get.", "要获取实体的 ID。"),
                    F("Expands", "The related entities to expand.", "要展开的关联实体。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Others.GetEntityModificationInformation",
                "Get the modification information of an entity.",
                "获取实体的修改信息。",
                ["modification information", "last modified"], ["修改信息", "最后修改"],
                fields: [
                    F("EntityTypeId", "The type of the entity.", "实体类型。"),
                    F("EntityId", "The entity.", "实体。"),
                ]),

            // ---- PartConfigurations ---------------------------------------------------
            Content(
                "Monitor.API.Common.Commands.PartConfigurations.CreateAndAddPartConfigurationFreeSelectionRow",
                "Create and add a free-selection row to a part configuration session.",
                "创建自由选择行并添加到物料配置会话。",
                ["free selection row", "config free selection"], ["添加自由选择行"],
                fields: [
                    F("SessionId", "The configuration session.", "配置会话。"),
                    F("SelectionGroupRowId", "The selection-group row to add.", "要添加的选择组行。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.PartConfigurations.CreateRemotePartConfigurationSession",
                "Create a remote part configuration session in a sales company.",
                "在销售公司创建远程物料配置会话。",
                ["remote configuration session", "remote config"], ["创建远程配置会话"],
                fields: [
                    F("PartConfigurationId", "The part configuration to use.", "要使用的物料配置。"),
                    F("CurrencyId", "The currency of the configuration.", "配置的货币。"),
                    F("CustomerId", "The customer the configuration is for.", "配置针对的客户。"),
                    F("CustomerOrderTypeId", "The customer-order type of the configuration.", "配置的客户订单类型。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.PartConfigurations.DestroyPartConfigurationSession",
                "Destroy a part configuration session.",
                "销毁物料配置会话。",
                ["destroy session", "end configuration session"], ["销毁配置会话", "结束配置会话"],
                fields: [
                    F("SessionId", "The configuration session to destroy.", "要销毁的配置会话。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.PartConfigurations.GetPartConfiguration",
                "Get the current state of a part configuration session.",
                "获取物料配置会话的当前状态。",
                ["get configuration", "get config session"], ["获取配置", "获取配置会话"],
                fields: [
                    F("SessionId", "The configuration session.", "配置会话。"),
                    F("LoadComments", "Whether to load the configuration comments.", "是否加载配置备注。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.PartConfigurations.PartConfigurationSessionExists",
                "Check whether a part configuration session exists.",
                "检查物料配置会话是否存在。",
                ["session exists", "config session exists"], ["检查配置会话是否存在"],
                fields: [
                    F("SessionId", "The configuration session to check.", "要检查的配置会话。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.PartConfigurations.PokePartConfigurationSession",
                "Extend the expiry of a part configuration session.",
                "延长物料配置会话的到期时间。",
                ["poke session", "extend session"], ["延长配置会话", "会话续期"],
                fields: [
                    F("SessionId", "The configuration session to extend.", "要延期的配置会话。"),
                    F("ExpiryTime", "The new expiry time; defaults to the current expiry.", "新的到期时间；默认为当前到期时间。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.PartConfigurations.SaveRemotePartConfigurationSession",
                "Save a remote part configuration session.",
                "保存远程物料配置会话。",
                ["save remote configuration", "save config session"], ["保存远程配置会话"],
                fields: [
                    F("SessionId", "The configuration session to save.", "要保存的配置会话。"),
                    F("WarehouseId", "The warehouse to save the configuration for.", "要保存配置的仓库。"),
                    F("PriceInfoDataRows", "The price information rows of the configuration.", "配置的价格信息行。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.PartConfigurations.UpdatePartConfiguration",
                "Update a part configuration session.",
                "更新物料配置会话。",
                ["update configuration", "change configuration"], ["更新配置", "修改配置"],
                fields: [
                    F("SessionId", "The configuration session to update.", "要更新的配置会话。"),
                    F("Instructions", "The update instructions for the configuration.", "配置的更新指令。"),
                ]),

            // ---- PaymentPlanTemplates -------------------------------------------------
            Content(
                "Monitor.API.Common.Commands.PaymentPlanTemplates.CreatePaymentPlanTemplate",
                "Create a payment plan template.",
                "创建付款计划模板。",
                ["create payment plan", "create installment template"], ["创建付款计划模板", "创建分期模板"],
                fields: [
                    F("Number", "The unique number of the template.", "模板的唯一编号。"),
                    F("Description", "A description of the template.", "模板的描述。"),
                    F("PaymentPlanTemplateType", "Whether the template is for sales, purchase, or both.", "模板用于销售、采购还是两者。"),
                    F("InvoiceTextTypes", "The text sections included on invoices generated from the plan.", "计划生成的发票上包含的文本部分。"),
                    F("Rows", "The payment plan rows of the template.", "模板的付款计划行。"),
                ]),

            // ---- Permissions ----------------------------------------------------------
            Content(
                "Monitor.API.Common.Commands.Permissions.GetPermissionHierarchy",
                "Get the permission hierarchy of the installation.",
                "获取本安装的权限层次结构。",
                ["permission hierarchy", "permission tree"], ["权限层次", "权限树"]),

            // ---- Persons --------------------------------------------------------------
            Content(
                "Monitor.API.Common.Commands.Persons.AddAttendanceRecordingAuthorizer",
                "Add an attendance-recording authorizer for a person.",
                "为人员添加考勤记录授权人。",
                ["add attendance authorizer", "authorize attendance"], ["添加考勤授权人", "考勤授权"],
                fields: [
                    F("PersonId", "The person to authorize attendance for.", "被授权考勤的人员。"),
                    F("ApplicationUserId", "The user to authorize.", "被授权的用户。"),
                    F("AttendanceRecordingAuthorizerType", "The authorization role (main or second authorizer).", "授权角色（主授权人或次授权人）。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Persons.AddPersonEmploymentPeriod",
                "Add an employment period to a person.",
                "为人员添加入职期间。",
                ["add employment period", "add employment"], ["添加入职期间", "添加入职记录"],
                fields: [
                    F("PersonId", "The person to add the employment period to.", "要添加入职期间的人员。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Persons.AddPersonRelative",
                "Add a relative to a person.",
                "为人员添加亲属。",
                ["add relative", "add family member"], ["添加亲属", "添加家属"],
                fields: [
                    F("PersonId", "The person to add the relative to.", "要添加亲属的人员。"),
                    F("Name", "The name of the relative.", "亲属的姓名。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Persons.AddPersonScheduleCycle",
                "Add a schedule cycle to a person.",
                "为人员分配排班周期。",
                ["add schedule cycle", "assign rota"], ["添加排班周期", "分配轮班"],
                fields: [
                    F("PersonId", "The person to add the schedule cycle to.", "要添加排班周期的人员。"),
                    F("WorkshopScheduleCycleId", "The workshop schedule cycle to add.", "要添加的车间排班周期。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Persons.BlockPerson",
                "Block a person.",
                "封锁人员。",
                ["block person", "deactivate person"], ["封锁人员", "停用人员"],
                fields: [
                    F("PersonId", "The person to block.", "要封锁的人员。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Persons.CreatePerson",
                "Create a new person.",
                "创建新人员。",
                ["create person", "new employee"], ["新建人员", "创建员工"],
                fields: [
                    F("EmployeeNumber", "The unique employee number of the person.", "人员唯一的员工编号。"),
                    F("FirstName", "The first name of the person.", "人员的名字。"),
                    F("LastName", "The last name of the person.", "人员的姓氏。"),
                    F("DepartmentId", "The department of the person.", "人员所在的部门。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Persons.GetPersonIdByPersonalCardNumber",
                "Get a person's id by their personal card number.",
                "按个人卡号获取人员 ID。",
                ["get person by card", "personal card number"], ["按卡号获取人员"],
                fields: [
                    F("PersonalCardNumber", "The personal card number of the person.", "人员的个人卡号。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Persons.RemoveAttendanceRecordingAuthorizer",
                "Remove an attendance-recording authorizer from a person.",
                "移除人员的考勤记录授权人。",
                ["remove attendance authorizer"], ["移除考勤授权人"],
                fields: [
                    F("Id", "The authorizer to remove.", "要移除的授权人。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Persons.RemovePerson",
                "Remove a person.",
                "删除人员。",
                ["remove person", "delete person"], ["删除人员", "移除人员"],
                fields: [
                    F("PersonId", "The person to remove.", "要删除的人员。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Persons.RemovePersonEmploymentPeriod",
                "Remove an employment period from a person.",
                "移除人员的入职期间。",
                ["remove employment period"], ["移除入职期间"],
                fields: [
                    F("EmploymentPeriodId", "The employment period to remove.", "要移除的入职期间。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Persons.RemovePersonRelative",
                "Remove a relative from a person.",
                "移除人员的亲属。",
                ["remove relative"], ["移除亲属"],
                fields: [
                    F("PersonRelativeId", "The relative to remove.", "要移除的亲属。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Persons.RemovePersonScheduleCycle",
                "Remove a schedule cycle from a person.",
                "移除人员的排班周期。",
                ["remove schedule cycle", "remove rota"], ["移除排班周期"],
                fields: [
                    F("Id", "The schedule cycle to remove.", "要移除的排班周期。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Persons.SetAvailableAsPropertiesPerson",
                "Set the roles a person is available as (reference, seller, planner...).",
                "设置人员可担任的角色（联系人、销售员、计划员等）。",
                ["set available as", "person roles"], ["设置可用角色", "人员角色"],
                fields: [
                    F("PersonId", "The person to update.", "要更新的人员。"),
                    F("IsReference", "Whether the person can be used as a reference.", "人员是否可用作联系人。"),
                    F("IsSeller", "Whether the person can be used as a seller.", "人员是否可用作销售员。"),
                    F("IsPurchaseManager", "Whether the person can be used as a purchase manager.", "人员是否可用作采购经理。"),
                    F("IsPlanner", "Whether the person can be used as a planner.", "人员是否可用作计划员。"),
                    F("IsAccountManager", "Whether the person can be used as an account manager.", "人员是否可用作客户经理。"),
                    F("IsProjectManager", "Whether the person can be used as a project manager.", "人员是否可用作项目经理。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Persons.SetContactInformationPropertiesPerson",
                "Set the contact information of a person.",
                "设置人员的联系信息。",
                ["set contact information", "update contacts"], ["设置联系信息", "更新联系方式"],
                fields: [
                    F("PersonId", "The person to update.", "要更新的人员。"),
                    F("EmailAddress", "The e-mail address of the person.", "人员的电子邮件地址。"),
                    F("PrivateEmailAddress", "The private e-mail address of the person.", "人员的私人电子邮件地址。"),
                    F("PhoneNumber", "The phone number of the person.", "人员的电话号码。"),
                    F("CellPhoneNumber", "The cell phone number of the person.", "人员的手机号码。"),
                    F("InternalPhoneNumber", "The internal phone number of the person.", "人员的内部电话号码。"),
                    F("FaxNumber", "The fax number of the person.", "人员的传真号码。"),
                    F("PrivatePhoneNumber", "The private phone number of the person.", "人员的私人电话号码。"),
                    F("PrivateCellPhoneNumber", "The private cell phone number of the person.", "人员的私人手机号码。"),
                    F("Contact", "The name of the person's contact person.", "人员联系人的姓名。"),
                    F("ContactPhoneNumber", "The phone number of the person's contact person.", "人员联系人的电话号码。"),
                    F("ContactCellPhoneNumber", "The cell phone number of the person's contact person.", "人员联系人的手机号码。"),
                    F("ContactEmailAddress", "The e-mail address of the person's contact person.", "人员联系人的电子邮件地址。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Persons.SetPropertiesPerson",
                "Set the properties of a person.",
                "设置人员的属性。",
                ["set person properties", "update person"], ["设置人员属性", "更新人员"],
                fields: [
                    F("PersonId", "The person to update.", "要更新的人员。"),
                    F("FirstName", "The first name of the person.", "人员的名字。"),
                    F("LastName", "The last name of the person.", "人员的姓氏。"),
                    F("Initials", "The initials of the person.", "人员的姓名缩写。"),
                    F("WarehouseId", "The default warehouse of the person.", "人员的默认仓库。"),
                    F("ApplicationUserId", "The user linked to the person.", "与人员关联的用户。"),
                    F("IdentityNumber", "The identity number of the person.", "人员的身份证号。"),
                    F("DepartmentId", "The department of the person.", "人员所在的部门。"),
                    F("Position", "The position of the person.", "人员的职位。"),
                    F("Category", "The category of the person.", "人员的类别。"),
                    F("Signature", "The signature image of the person.", "人员的签名图片。"),
                    F("BlockedContextType", "The context in which the person is blocked, if any.", "人员被封锁的上下文（如有）。"),
                    F("BlockedById", "The user who blocked the person.", "封锁该人员的用户。"),
                    F("BlockedFromDate", "The start of the block period.", "封锁期间的开始。"),
                    F("BlockedToDate", "The end of the block period.", "封锁期间的结束。"),
                    F("BlockedStatus", "Whether the person is blocked.", "人员是否被封锁。"),
                    F("BlockMessage", "The message shown when the person is blocked.", "人员被封锁时显示的消息。"),
                    F("EmailAddress", "The e-mail address of the person.", "人员的电子邮件地址。"),
                    F("PhoneNumber", "The phone number of the person.", "人员的电话号码。"),
                    F("CellPhoneNumber", "The cell phone number of the person.", "人员的手机号码。"),
                    F("InternalPhoneNumber", "The internal phone number of the person.", "人员的内部电话号码。"),
                    F("FaxNumber", "The fax number of the person.", "人员的传真号码。"),
                    F("PrivateEmailAddress", "The private e-mail address of the person.", "人员的私人电子邮件地址。"),
                    F("PrivatePhoneNumber", "The private phone number of the person.", "人员的私人电话号码。"),
                    F("PrivateCellPhoneNumber", "The private cell phone number of the person.", "人员的私人手机号码。"),
                    F("Comment", "A comment on the person.", "人员的备注。"),
                    F("EmployeeRecordingType", "How the employee records time (attendance and work, or work only).", "员工记录时间的方式（考勤与作业或仅作业）。"),
                    F("GroupSettingsId", "The group settings of the person.", "人员的组设置。"),
                    F("ScheduleManagementType", "How the person's schedule is managed (none or schedule cycle).", "人员排班的管理方式（无或排班周期）。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Persons.UnblockPerson",
                "Unblock a person.",
                "解除人员的封锁。",
                ["unblock person", "reactivate person"], ["解除封锁", "恢复人员"],
                fields: [
                    F("PersonId", "The person to unblock.", "要解除封锁的人员。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Persons.UpdateAttendanceRecordingAuthorizer",
                "Update an attendance-recording authorizer of a person.",
                "更新人员的考勤记录授权人。",
                ["update attendance authorizer"], ["更新考勤授权人"],
                fields: [
                    F("Id", "The authorizer to update.", "要更新的授权人。"),
                    F("ApplicationUserId", "The authorized user.", "被授权的用户。"),
                    F("AllowWorkAdjustments", "Whether the authorizer may adjust work recordings.", "授权人是否可调整作业记录。"),
                    F("AllowAttendanceAdjustments", "Whether the authorizer may adjust attendance recordings.", "授权人是否可调整考勤记录。"),
                    F("AttendanceRecordingAuthorizerType", "The authorization role (main or second authorizer).", "授权角色（主授权人或次授权人）。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Persons.UpdatePersonEmploymentPeriod",
                "Update an employment period of a person.",
                "更新人员的入职期间。",
                ["update employment period"], ["更新入职期间"],
                fields: [
                    F("EmploymentPeriodId", "The employment period to update.", "要更新的入职期间。"),
                    F("StartDate", "The start date of the period.", "期间的开始日期。"),
                    F("FinishDate", "The finish date of the period.", "期间的结束日期。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Persons.UpdatePersonRelative",
                "Update a relative of a person.",
                "更新人员的亲属。",
                ["update relative"], ["更新亲属"],
                fields: [
                    F("PersonRelativeId", "The relative to update.", "要更新的亲属。"),
                    F("Name", "The name of the relative.", "亲属的姓名。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Persons.UpdatePersonScheduleCycle",
                "Update a schedule cycle of a person.",
                "更新人员的排班周期。",
                ["update schedule cycle"], ["更新排班周期"],
                fields: [
                    F("Id", "The schedule cycle to update.", "要更新的排班周期。"),
                    F("WorkshopScheduleCycleId", "The workshop schedule cycle.", "车间排班周期。"),
                    F("UseFromDate", "The date the cycle takes effect from.", "周期生效的日期。"),
                ]),

            // ---- ProductGroups --------------------------------------------------------
            Content(
                "Monitor.API.Common.Commands.ProductGroups.GetCustomerAccountGroupCodingRequirements",
                "Get the coding requirements for a product group and customer account group.",
                "获取产品组与客户科目组的记账要求。",
                ["coding requirements", "customer account group coding"], ["获取记账要求", "客户科目组记账要求"],
                fields: [
                    F("ProductGroupId", "The product group.", "产品组。"),
                    F("CustomerAccountGroupId", "The customer account group.", "客户科目组。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.ProductGroups.GetSupplierAccountGroupCodingRequirements",
                "Get the coding requirements for a product group and supplier account group.",
                "获取产品组与供应商科目组的记账要求。",
                ["coding requirements", "supplier account group coding"], ["获取记账要求", "供应商科目组记账要求"],
                fields: [
                    F("ProductGroupId", "The product group.", "产品组。"),
                    F("SupplierAccountGroupId", "The supplier account group.", "供应商科目组。"),
                ]),

            // ---- Projects -------------------------------------------------------------
            Content(
                "Monitor.API.Common.Commands.Projects.ChangeActivityProjectCostReportingEntry",
                "Change the activity of a project cost-reporting entry.",
                "更改项目成本上报条目的活动。",
                ["change activity", "change cost reporting entry"], ["更改上报条目活动"],
                fields: [
                    F("ProjectCostReportingEntryId", "The cost-reporting entry to change.", "要更改的成本上报条目。"),
                    F("ActivityId", "The new activity of the entry.", "条目的新活动。"),
                    F("ReportedTimeInHours", "The new reported time, in hours.", "新的上报时间（小时）。"),
                    F("CostTypeId", "The new cost type of the entry.", "条目的新成本类型。"),
                    F("Amount", "The new amount of the entry.", "条目的新金额。"),
                    F("UpdateCostType", "Whether to update the cost type.", "是否更新成本类型。"),
                    F("RecalculateAmount", "Whether to recalculate the amount.", "是否重新计算金额。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Projects.CreateActivityDelegatedWorkProject",
                "Delegate a project activity to a person.",
                "将项目活动委托给人员。",
                ["create delegated work", "delegate activity"], ["创建委托工作", "委托活动"],
                fields: [
                    F("ProjectActivityId", "The project activity to delegate.", "要委托的项目活动。"),
                    F("PersonId", "The person to delegate the activity to.", "被委托该活动的人员。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Projects.CreateActivityProject",
                "Create an activity in a project phase.",
                "在项目阶段中创建活动。",
                ["create activity", "add project activity"], ["创建活动", "添加项目活动"],
                fields: [
                    F("ProjectPhaseId", "The phase to create the activity in.", "要创建活动的阶段。"),
                    F("Activity", "The activity to create.", "要创建的活动。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Projects.CreatePhaseProject",
                "Create a phase in a project.",
                "在项目中创建阶段。",
                ["create phase", "add project phase"], ["创建阶段", "添加项目阶段"],
                fields: [
                    F("ProjectId", "The project to create the phase in.", "要创建阶段的项目。"),
                    F("PhaseTypeId", "The phase type of the new phase.", "新阶段的阶段类型。"),
                    F("ResponsibleUserId", "The user responsible for the phase.", "负责该阶段的用户。"),
                    F("Activities", "The activities to create in the phase.", "要在阶段中创建的活动。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Projects.CreateProject",
                "Create a new project.",
                "创建新项目。",
                ["create project", "new project"], ["新建项目", "创建项目"],
                fields: [
                    F("Code", "The unique project number.", "唯一的项目编号。"),
                    F("Name", "The name of the project.", "项目的名称。"),
                    F("ProjectTypeId", "The project type of the project.", "项目的项目类型。"),
                    F("ProjectGroupId", "The project group of the project.", "项目的项目组。"),
                    F("ActivityTemplateId", "The activity template used for the project.", "项目使用的活动模板。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Projects.CreateProjectActivityCalendarAppointment",
                "Create a calendar appointment for a project activity.",
                "为项目活动创建日历约见。",
                ["create calendar appointment", "appointment"], ["创建日历约见", "创建约见"],
                fields: [
                    F("ProjectActivityId", "The project activity the appointment is for.", "约见针对的项目活动。"),
                    F("SenderPersonId", "The person creating the appointment.", "创建约见的人员。"),
                    F("Location", "The location of the appointment.", "约见的地点。"),
                    F("Duration", "The duration of the appointment.", "约见的时长。"),
                    F("Date", "The date of the appointment.", "约见的日期。"),
                    F("Participants", "The participants of the appointment.", "约见的参与者。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Projects.CreateProjectActivityCalendarAppointmentFromId",
                "Create a calendar appointment for a project activity from an existing appointment.",
                "基于现有约见为项目活动创建日历约见。",
                ["create appointment from id"], ["从现有约见创建"],
                fields: [
                    F("CalendarAppointmentId", "The existing appointment to base the new one on.", "新约见所依据的现有约见。"),
                    F("ProjectActivityId", "The project activity the appointment is for.", "约见针对的项目活动。"),
                    F("SenderPersonId", "The person creating the appointment.", "创建约见的人员。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Projects.CreateProjectCostReportingEntry",
                "Create a cost-reporting entry on a project.",
                "在项目上创建成本上报条目。",
                ["create cost reporting entry", "report cost"], ["创建成本上报条目", "上报成本"],
                fields: [
                    F("Number", "The number of the entry; defaults to the number series.", "条目的编号；默认使用编号系列。"),
                    F("ProjectId", "The project to report on.", "要上报的项目。"),
                    F("IsIncome", "Whether the entry is an income entry.", "条目是否为收入条目。"),
                    F("ActivityId", "The activity to report against.", "上报所针对的活动。"),
                    F("ReportedTimeInHours", "The reported time, in hours.", "上报时间（小时）。"),
                    F("CostTypeId", "The cost type to report against.", "上报所针对的成本类型。"),
                    F("Amount", "The reported amount.", "上报的金额。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Projects.CreateRootActivityProject",
                "Create a root activity in a project.",
                "在项目中创建根活动。",
                ["create root activity", "add root activity"], ["创建根活动", "添加根活动"],
                fields: [
                    F("ProjectId", "The project to create the activity in.", "要创建活动的项目。"),
                    F("Activity", "The activity to create.", "要创建的活动。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Projects.RemoveActivityDelegatedWorkProject",
                "Remove delegated work from a project activity.",
                "移除项目活动的委托工作。",
                ["remove delegated work", "undelegate activity"], ["移除委托工作"],
                fields: [
                    F("ProjectActivityId", "The project activity to remove the delegation from.", "要移除委托的项目活动。"),
                    F("PersonId", "The person to remove the delegation from.", "被移除委托的人员。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Projects.RemoveActivityProject",
                "Remove an activity from a project.",
                "从项目移除活动。",
                ["remove activity", "delete activity"], ["删除活动", "移除活动"],
                fields: [
                    F("ProjectActivityId", "The activity to remove.", "要删除的活动。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Projects.RemovePhaseProject",
                "Remove a phase from a project.",
                "从项目移除阶段。",
                ["remove phase", "delete phase"], ["删除阶段", "移除阶段"],
                fields: [
                    F("ProjectPhaseId", "The phase to remove.", "要删除的阶段。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Projects.RemoveProject",
                "Remove a project.",
                "删除项目。",
                ["remove project", "delete project"], ["删除项目", "移除项目"],
                fields: [
                    F("ProjectId", "The project to remove.", "要删除的项目。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Projects.RemoveProjectActivityCalendarAppointment",
                "Remove a calendar appointment from a project activity.",
                "移除项目活动的日历约见。",
                ["remove calendar appointment", "delete appointment"], ["删除日历约见", "移除约见"],
                fields: [
                    F("ProjectActivityCalendarAppointmentId", "The appointment to remove.", "要删除的约见。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Projects.RenameProject",
                "Rename a project.",
                "重命名项目。",
                ["rename project", "change project number"], ["重命名项目", "更改项目编号"],
                fields: [
                    F("ProjectId", "The project to rename.", "要重命名的项目。"),
                    F("NewProjectNumber", "The new project number.", "新的项目编号。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Projects.ReplanProject",
                "Replan a project with new start and end dates.",
                "以新的开始与结束日期重新计划项目。",
                ["replan project", "reschedule project"], ["重新计划项目", "重排项目"],
                fields: [
                    F("ProjectId", "The project to replan.", "要重新计划的项目。"),
                    F("StartDate", "The new start date.", "新的开始日期。"),
                    F("EndDate", "The new end date.", "新的结束日期。"),
                    F("RecalculateActivityDates", "Whether to recalculate the activity dates.", "是否重新计算活动日期。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Projects.SetPreviousActivitiesProject",
                "Set the predecessor activities of a project activity.",
                "设置项目活动的前置活动。",
                ["set previous activities", "predecessors"], ["设置前置活动"],
                fields: [
                    F("ProjectActivityId", "The activity to set predecessors for.", "要设置前置活动的活动。"),
                    F("PreviousProjectActivityIds", "The predecessor activities.", "前置活动。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Projects.SetPreviousPhasesProject",
                "Set the predecessor phases of a project phase.",
                "设置项目阶段的前置阶段。",
                ["set previous phases", "phase predecessors"], ["设置前置阶段"],
                fields: [
                    F("ProjectPhaseId", "The phase to set predecessors for.", "要设置前置阶段的阶段。"),
                    F("PreviousProjectPhaseIds", "The predecessor phases.", "前置阶段。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Projects.SetProjectProperties",
                "Set the properties of a project.",
                "设置项目的属性。",
                ["set project properties", "update project"], ["设置项目属性", "更新项目"],
                fields: [
                    F("ProjectId", "The project to update.", "要更新的项目。"),
                    F("Name", "The name of the project.", "项目的名称。"),
                    F("ProjectGroupId", "The project group of the project.", "项目的项目组。"),
                    F("ActivityTemplateId", "The activity template used for the project.", "项目使用的活动模板。"),
                    F("ProjectStatus", "The status of the project.", "项目的状态。"),
                    F("CustomerId", "The customer of the project.", "项目的客户。"),
                    F("SellerId", "The seller responsible for the project.", "负责项目的销售员。"),
                    F("OurReferenceId", "Our reference (person) for the project.", "项目的我方联系人（人员）。"),
                    F("CustomerReferenceId", "The customer's reference for the project.", "项目的客户联系人。"),
                    F("CustomerOrderId", "The customer order linked to the project.", "与项目关联的客户订单。"),
                    F("ParentProjectId", "The parent project, when the project is a sub-project.", "父项目（当项目为子项目时）。"),
                    F("ProjectManagerId", "The project manager of the project.", "项目的项目经理。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Projects.SetProjectType",
                "Set the type of a project.",
                "设置项目的类型。",
                ["set project type", "change project type"], ["设置项目类型", "更改项目类型"],
                fields: [
                    F("ProjectId", "The project to set the type for.", "要设置类型的项目。"),
                    F("ProjectTypeId", "The new project type.", "新的项目类型。"),
                    F("UpdateProjectGroup", "Whether to update the project group from the type.", "是否从类型更新项目组。"),
                    F("UpdateActivityTemplate", "Whether to update the activity template from the type.", "是否从类型更新活动模板。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Projects.UpdateActivityProject",
                "Update a project activity.",
                "更新项目活动。",
                ["update activity", "edit activity"], ["更新活动", "修改活动"],
                fields: [
                    F("ProjectActivityId", "The activity to update.", "要更新的活动。"),
                    F("Description", "The description of the activity.", "活动的描述。"),
                    F("ResponsibleUserId", "The user responsible for the activity.", "负责该活动的用户。"),
                    F("PlannedTimeInHours", "The planned time, in hours.", "计划时间（小时）。"),
                    F("PlannedStartDate", "The planned start date.", "计划开始日期。"),
                    F("PlannedCompletionDate", "The planned completion date.", "计划完成日期。"),
                    F("Status", "The status of the activity.", "活动的状态。"),
                    F("RestTimeInHours", "The remaining time, in hours.", "剩余时间（小时）。"),
                    F("CompletionDate", "The actual completion date.", "实际完成日期。"),
                    F("CompletedByUserId", "The user who completed the activity.", "完成该活动的用户。"),
                    F("LockedDelegateWork", "Whether the delegated work is locked.", "委托工作是否被锁定。"),
                    F("ShowInProjectReport", "Whether to show the activity in project reports.", "是否在项目报告中显示该活动。"),
                    F("Reminder", "Whether a reminder is created for the activity.", "是否为活动创建提醒。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Projects.UpdatePhaseProject",
                "Update a project phase.",
                "更新项目阶段。",
                ["update phase", "edit phase"], ["更新阶段", "修改阶段"],
                fields: [
                    F("ProjectPhaseId", "The phase to update.", "要更新的阶段。"),
                    F("PhaseTypeId", "The phase type of the phase.", "阶段的阶段类型。"),
                    F("Description", "The description of the phase.", "阶段的描述。"),
                    F("ResponsibleUserId", "The user responsible for the phase.", "负责该阶段的用户。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Projects.UpdateProjectActivityCalendarAppointment",
                "Update a calendar appointment of a project activity.",
                "更新项目活动的日历约见。",
                ["update calendar appointment"], ["更新日历约见"],
                fields: [
                    F("ProjectActivityCalendarAppointmentId", "The appointment to update.", "要更新的约见。"),
                    F("SenderPersonId", "The person who created the appointment.", "创建约见的人员。"),
                    F("Location", "The location of the appointment.", "约见的地点。"),
                    F("Duration", "The duration of the appointment.", "约见的时长。"),
                    F("Date", "The date of the appointment.", "约见的日期。"),
                    F("Participants", "The participants of the appointment.", "约见的参与者。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Projects.UpdateProjectCostBudget",
                "Update the cost budget of a project cost type.",
                "更新项目成本类型的成本预算。",
                ["update cost budget", "edit budget"], ["更新成本预算", "修改预算"],
                fields: [
                    F("ProjectId", "The project of the budget.", "预算所属的项目。"),
                    F("ProjectCostTypeId", "The cost type of the budget.", "预算涵盖的成本类型。"),
                    F("Hours", "The budgeted hours.", "预算工时。"),
                    F("Cost", "The budgeted cost.", "预算成本。"),
                    F("Income", "The budgeted income.", "预算收入。"),
                    F("Comment", "A comment on the budget.", "预算的备注。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Projects.UpdateProjectCostForecast",
                "Update the cost forecast of a project cost type.",
                "更新项目成本类型的成本预测。",
                ["update cost forecast", "edit forecast"], ["更新成本预测", "修改预测"],
                fields: [
                    F("ProjectId", "The project of the forecast.", "预测所属的项目。"),
                    F("ProjectCostTypeId", "The cost type of the forecast.", "预测涵盖的成本类型。"),
                    F("Hours", "The forecast hours.", "预测工时。"),
                    F("Cost", "The forecast cost.", "预测成本。"),
                    F("Income", "The forecast income.", "预测收入。"),
                    F("Comment", "A comment on the forecast.", "预测的备注。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.Projects.UpdateProjectCostReportingEntry",
                "Update a project cost-reporting entry.",
                "更新项目成本上报条目。",
                ["update cost reporting entry", "edit cost entry"], ["更新成本上报条目", "修改成本条目"],
                fields: [
                    F("ProjectCostReportingEntryId", "The cost-reporting entry to update.", "要更新的成本上报条目。"),
                    F("ReportingDate", "The reporting date of the entry.", "条目的上报日期。"),
                    F("OurReferenceId", "Our reference (person) for the entry.", "条目的我方联系人（人员）。"),
                    F("OurReferenceName", "The name of our reference.", "我方联系人的姓名。"),
                    F("EmployeeId", "The employee who reported the entry.", "上报该条目的员工。"),
                    F("WorkCenterId", "The work center the entry was reported against.", "条目上报所针对的工作中心。"),
                    F("DepartmentId", "The department the entry was reported against.", "条目上报所针对的部门。"),
                    F("Comment", "A comment on the entry.", "条目的备注。"),
                ]),

            // ---- Tags / Notes / VatRates ----------------------------------------------
            Content(
                "Monitor.API.Common.Commands.Tags.RemoveTag",
                "Remove a tag.",
                "删除标签。",
                ["remove tag", "delete tag"], ["删除标签", "移除标签"],
                fields: [
                    F("TagId", "The tag to remove.", "要删除的标签。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.UpdateBusinessContactNoteHistory",
                "Update a note on a business contact.",
                "更新业务联系人上的备注。",
                ["update note", "edit note"], ["更新备注", "修改备注"],
                fields: [
                    F("BusinessContactNoteHistoryId", "The note to update.", "要更新的备注。"),
                    F("Subject", "The subject of the note.", "备注的主题。"),
                    F("Text", "The formatted text of the note.", "备注的格式化文本。"),
                    F("RawText", "The raw text of the note.", "备注的原始文本。"),
                    F("CreatedByUserId", "The user who created the note.", "创建备注的用户。"),
                    F("CreatedTimestamp", "The timestamp of the note.", "备注的时间戳。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.VatRates.CreateVatRate",
                "Create a VAT rate.",
                "创建增值税率。",
                ["create vat rate", "create tax rate"], ["创建增值税率", "创建税率"],
                fields: [
                    F("Number", "The unique number of the VAT rate.", "增值税率的唯一编号。"),
                    F("Description", "A description of the rate.", "税率的描述。"),
                    F("CodeType", "Whether the rate is used for sales, purchase, or neither.", "税率用于销售、采购或两者皆非。"),
                    F("EcSalesType", "How EC sales are declared (goods, services, or third-party trade).", "欧盟销售的申报方式（货物、服务或第三方贸易）。"),
                    F("OutputVatAccountId", "The account used for output VAT.", "销项增值税使用的科目。"),
                    F("InputVatAccountId", "The account used for input VAT.", "进项增值税使用的科目。"),
                ]),
            Content(
                "Monitor.API.Common.Commands.VatRates.UpdateVatRate",
                "Update a VAT rate.",
                "更新增值税率。",
                ["update vat rate", "update tax rate"], ["更新增值税率", "更新税率"],
                fields: [
                    F("Id", "The VAT rate to update.", "要更新的增值税率。"),
                    F("Number", "The unique number of the VAT rate.", "增值税率的唯一编号。"),
                    F("Percentage", "The VAT percentage.", "增值税百分比。"),
                    F("Description", "A description of the rate.", "税率的描述。"),
                    F("ReversedTax", "Whether the rate is a reversed-charge tax.", "税率是否为反向征税。"),
                    F("OutputVatAccountId", "The account used for output VAT.", "销项增值税使用的科目。"),
                    F("InputVatAccountId", "The account used for input VAT.", "进项增值税使用的科目。"),
                    F("Active", "Whether the rate is active.", "税率是否启用。"),
                    F("ReversedTaxPercentage", "The reversed-charge percentage.", "反向征税的百分比。"),
                    F("ReferenceText", "The reference text on invoices using this rate.", "使用该税率的发票上的参考文本。"),
                    F("EcSalesType", "How EC sales are declared (goods, services, or third-party trade).", "欧盟销售的申报方式（货物、服务或第三方贸易）。"),
                    F("CodeType", "Whether the rate is used for sales, purchase, or neither.", "税率用于销售、采购或两者皆非。"),
                ]),
        ];
    }
}
