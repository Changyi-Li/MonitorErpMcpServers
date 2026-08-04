namespace MonitorErpMcp.Catalog.Content.TimeRecording
{
    // The using-static sits inside the namespace so the imported Content(...) builder binds before
    // the enclosing MonitorErpMcp.Catalog.Content namespace in simple-name lookup.
    using static MonitorErpMcp.Catalog.Content.ContentEntryFactory;
    using MonitorErpMcp.Catalog.Model;

    /// <summary>
    /// Hand-authored content for TimeRecording command records: bilingual descriptions and search aliases
    /// (en first, zh second), keyed by clrType and merged onto the structural catalog. Important
    /// request-input fields (mandatory, mandatoryWhen, enum, reference, input wrapper, dto, nested
    /// command) carry bilingual descriptions; self-evident fields are skipped. The
    /// <c>Common.Commands.Persons.*</c> commands whose Module is TimeRecording are already authored in
    /// the Common content and are deliberately not re-authored here (duplicate keys would throw).
    /// </summary>
    public static class Commands
    {
        /// <summary>Hand-authored entries for this family, merged by <c>clrType</c> onto the structural catalog.</summary>
        public static readonly ContentEntry[] Entries =
        [
            // ---- AttendanceGroupSetting --------------------------------------------
            Content(
                "Monitor.API.TimeRecording.Commands.AttendanceGroupSetting.UpdateAttendanceGroupSettings",
                "Update the attendance group settings.",
                "更新考勤组设置。",
                ["update attendance group settings", "update attendance settings"], ["更新考勤组设置", "更新考勤设置"],
                fields: [
                    F("AttendanceGroupSettingId", "The attendance group settings to update.", "要更新的考勤组设置。"),
                    F("NonRegulatedWorkinghours", "Whether non-regulated working hours are allowed.", "是否允许非受控工时。"),
                ]),

            // ---- Persons -----------------------------------------------------------
            Content(
                "Monitor.API.TimeRecording.Commands.Persons.CloseActiveWorkRecordings",
                "Close all active work recordings of an employee.",
                "关闭员工所有进行中的工作记录。",
                ["close active recordings", "close work recordings"], ["关闭进行中记录", "关闭工作记录"],
                fields: [
                    F("EmployeeId", "The employee whose active recordings to close.", "要关闭进行中记录的员工。"),
                ]),
            Content(
                "Monitor.API.TimeRecording.Commands.Persons.CreatePlannedAbsence",
                "Create a planned absence for a person.",
                "为人员创建计划缺勤。",
                ["create planned absence", "plan absence", "create leave"], ["创建计划缺勤", "计划缺勤", "创建请假"],
                fields: [
                    F("PersonId", "The person to create the absence for.", "要创建缺勤的人员。"),
                    F("AbsenceFrom", "The start of the absence.", "缺勤的开始。"),
                    F("AbsenceTo", "The end of the absence.", "缺勤的结束。"),
                    F("AbsenceCodeId", "The absence code of the absence.", "缺勤的缺勤代码。"),
                    F("Status", "The status of the planned absence (applied for, approved, denied).", "计划缺勤的状态（已申请、已批准、已拒绝）。"),
                ]),
            Content(
                "Monitor.API.TimeRecording.Commands.Persons.RemovePlannedAbsence",
                "Remove a planned absence.",
                "删除计划缺勤。",
                ["remove planned absence", "delete planned absence"], ["删除计划缺勤", "移除计划缺勤"],
                fields: [
                    F("PlannedAbsenceId", "The planned absence to remove.", "要删除的计划缺勤。"),
                ]),
            Content(
                "Monitor.API.TimeRecording.Commands.Persons.UpdatePlannedAbsence",
                "Update a planned absence.",
                "更新计划缺勤。",
                ["update planned absence", "update absence"], ["更新计划缺勤", "修改缺勤"],
                fields: [
                    F("PlannedAbsenceId", "The planned absence to update.", "要更新的计划缺勤。"),
                    F("AbsenceFrom", "The start of the absence.", "缺勤的开始。"),
                    F("AbsenceTo", "The end of the absence.", "缺勤的结束。"),
                    F("AbsenceCodeId", "The absence code of the absence.", "缺勤的缺勤代码。"),
                    F("Approved", "Whether the absence is approved.", "缺勤是否已批准。"),
                    F("Status", "The status of the planned absence (applied for, approved, denied).", "计划缺勤的状态（已申请、已批准、已拒绝）。"),
                ]),

            // ---- PersonWorkCenter --------------------------------------------------
            Content(
                "Monitor.API.TimeRecording.Commands.PersonWorkCenter.CreatePersonWorkCenter",
                "Create a person-work-center link.",
                "创建人员工作中心关联。",
                ["create person work center", "link person to work center"], ["创建人员工作中心", "关联人员工作中心"],
                fields: [
                    F("PersonId", "The person of the link.", "关联的人员。"),
                    F("WorkCenterId", "The work center of the link.", "关联的工作中心。"),
                ]),
            Content(
                "Monitor.API.TimeRecording.Commands.PersonWorkCenter.RemovePersonWorkCenter",
                "Remove a person-work-center link.",
                "删除人员工作中心关联。",
                ["remove person work center", "unlink person work center"], ["删除人员工作中心", "移除人员工作中心"],
                fields: [
                    F("Id", "The person-work-center link to remove.", "要删除的人员工作中心关联。"),
                ]),
            Content(
                "Monitor.API.TimeRecording.Commands.PersonWorkCenter.UpdatePersonWorkCenter",
                "Update a person-work-center link.",
                "更新人员工作中心关联。",
                ["update person work center"], ["更新人员工作中心"],
                fields: [
                    F("Id", "The person-work-center link to update.", "要更新的人员工作中心关联。"),
                    F("WorkCenterId", "The work center of the link.", "关联的工作中心。"),
                    F("IsDefault", "Whether the link is the person's default.", "该关联是否为人员的默认关联。"),
                    F("IsCapacityWorkCenter", "Whether the person is a capacity resource at the work center.", "该人员是否为工作中心的能力资源。"),
                    F("ShowOnPriorityPlan", "Whether the person is shown on the priority plan.", "该人员是否显示在优先级计划上。"),
                ]),

            // ---- Recording ---------------------------------------------------------
            Content(
                "Monitor.API.TimeRecording.Commands.Recording.AddNewIndirectWorkRecording",
                "Record a new indirect-work interval (e.g. a meeting or break) for an employee.",
                "为员工记录一段新的间接工作（如会议或休息）。",
                ["add indirect work", "record indirect work", "add indirect recording"], ["添加间接工作", "记录间接工作", "添加间接记录"],
                fields: [
                    F("EmployeeId", "The employee who did the work.", "进行工作的员工。"),
                    F("RecordingDate", "The recording day of the work.", "工作的记录日。"),
                    F("StartTime", "The start time of the work.", "工作的开始时间。"),
                    F("EndTime", "The end time of the work.", "工作的结束时间。"),
                    F("IndirectWorkCodeId", "The indirect-work code of the work.", "工作的间接工作代码。"),
                    F("Comment", "The comment; required when the indirect-work code demands it.", "备注；间接工作代码要求时必填。"),
                ]),
            Content(
                "Monitor.API.TimeRecording.Commands.Recording.AddNewOrderBoundRecording",
                "Record a new order-bound work interval against a manufacturing operation.",
                "针对制造工序记录一段新的订单绑定工作。",
                ["add order bound work", "record order bound work", "report operation work"], ["添加订单绑定工作", "记录订单工作", "上报工序工作"],
                fields: [
                    F("EmployeeId", "The employee who did the work.", "进行工作的员工。"),
                    F("RecordingDate", "The recording day of the work.", "工作的记录日。"),
                    F("StartTime", "The start time of the work.", "工作的开始时间。"),
                    F("EndTime", "The end time of the work.", "工作的结束时间。"),
                    F("IsSetupTime", "Whether the work is setup time.", "该工作是否为准备时间。"),
                    F("OperationId", "The manufacturing operation the work is reported on.", "上报工作的制造工序。"),
                    F("Rejections", "The rejected quantities of the work.", "工作的拒收数量。"),
                    F("Locations", "The locations the reported quantity is put into; required when the operation is last and manages stock.", "上报数量放入的库位；末道工序且管理库存时必填。"),
                    F("Comment", "The comment of the work.", "工作的备注。"),
                    F("ExistingLocations", "The existing locations the quantity is added to; required when the operation is last and manages stock.", "数量加入的现有库位；末道工序且管理库存时必填。"),
                    F("ManufacturingOrderMaterialReportings", "The material reportings of the operation.", "工序的材料上报。"),
                    F("TraceableManufacturingOrderMaterialReportings", "The traceable-material reportings of the operation.", "工序的可追溯材料上报。"),
                    F("TraceabilityData", "The traceability data; required when the operation demands it.", "追溯数据；工序要求时必填。"),
                ]),
            Content(
                "Monitor.API.TimeRecording.Commands.Recording.AddStandbyWork",
                "Add a standby work to an employee's current recording.",
                "为员工的当前记录添加待命工作。",
                ["add standby work", "standby"], ["添加待命工作", "待命"],
                fields: [
                    F("EmployeeId", "The employee of the standby work.", "待命工作的员工。"),
                    F("WorkRecordingType", "The type of the work (indirect, operation setup, operation unit, project activity).", "工作的类型（间接、工序准备、工序单位、项目活动）。"),
                    F("IndirectWorkCodeId", "The indirect-work code; required when the type is indirect.", "间接工作代码；类型为间接时必填。"),
                    F("OperationId", "The operation; required when the type is operation setup or operation unit.", "工序；类型为工序准备或工序单位时必填。"),
                    F("ActivityId", "The project activity; required when the type is project activity.", "项目活动；类型为项目活动时必填。"),
                ]),
            Content(
                "Monitor.API.TimeRecording.Commands.Recording.AdjustExistingIndirectWorkRecording",
                "Adjust an existing indirect-work recording.",
                "调整现有间接工作记录。",
                ["adjust indirect work", "adjust indirect recording"], ["调整间接工作", "调整间接记录"],
                fields: [
                    F("WorkIntervalId", "The work interval to adjust.", "要调整的工作区间。"),
                    F("NewStartTime", "The new start time.", "新的开始时间。"),
                    F("NewEndTime", "The new end time.", "新的结束时间。"),
                    F("NewIndirectWorkCodeId", "The new indirect-work code.", "新的间接工作代码。"),
                    F("Comment", "The comment of the work.", "工作的备注。"),
                    F("SigningEmployeeId", "The employee signing the adjustment.", "签署调整的员工。"),
                ]),
            Content(
                "Monitor.API.TimeRecording.Commands.Recording.AdjustOrderBoundWork",
                "Adjust an existing order-bound work recording.",
                "调整现有订单绑定工作记录。",
                ["adjust order bound work", "adjust order work"], ["调整订单绑定工作", "调整订单工作"],
                fields: [
                    F("WorkRecordingIntervalId", "The work interval to adjust.", "要调整的工作区间。"),
                    F("NewStartDate", "The new start date.", "新的开始日期。"),
                    F("NewEndDate", "The new end date.", "新的结束日期。"),
                    F("Locations", "The locations the quantity is put into; required when the operation is last and manages stock.", "数量放入的库位；末道工序且管理库存时必填。"),
                    F("ExistingLocations", "The existing locations the quantity is added to; required when the operation is last and manages stock.", "数量加入的现有库位；末道工序且管理库存时必填。"),
                    F("TraceabilityData", "The traceability data; required when the operation demands it.", "追溯数据；工序要求时必填。"),
                    F("Rejections", "The rejected quantities of the work.", "工作的拒收数量。"),
                    F("WipLocation", "The WIP location of the work.", "工作的在制库位。"),
                    F("ReportedQuantity", "The reported quantity of the work.", "工作的上报数量。"),
                    F("Comment", "The comment of the work.", "工作的备注。"),
                    F("ManufacturingOrderMaterialReportings", "The material reportings of the operation.", "工序的材料上报。"),
                    F("TraceableManufacturingOrderMaterialReportings", "The traceable-material reportings of the operation.", "工序的可追溯材料上报。"),
                ]),
            Content(
                "Monitor.API.TimeRecording.Commands.Recording.AdjustProjectActivityReporting",
                "Adjust a project-activity work recording.",
                "调整项目活动工作记录。",
                ["adjust project activity", "adjust activity reporting"], ["调整项目活动", "调整活动上报"],
                fields: [
                    F("WorkRecordingIntervalId", "The work interval to adjust.", "要调整的工作区间。"),
                    F("NewStartDate", "The new start date.", "新的开始日期。"),
                    F("NewEndDate", "The new end date.", "新的结束日期。"),
                    F("Comment", "The comment of the work.", "工作的备注。"),
                ]),
            Content(
                "Monitor.API.TimeRecording.Commands.Recording.AdjustRecordingDay",
                "Adjust the attendance intervals of a person's recording day.",
                "调整人员记录日的考勤区间。",
                ["adjust recording day", "adjust attendance day"], ["调整记录日", "调整考勤日"],
                fields: [
                    F("PersonId", "The person whose recording day to adjust.", "要调整记录日的人员。"),
                    F("AttendanceAdjustments", "The attendance adjustments of the day.", "当日的考勤调整。"),
                ]),
            Content(
                "Monitor.API.TimeRecording.Commands.Recording.AppendRecordingDayMessage",
                "Append a message to a recording day.",
                "向记录日追加消息。",
                ["append message", "add recording day message"], ["追加消息", "添加记录日消息"],
                fields: [
                    F("RecordingDayId", "The recording day to append the message to.", "要追加消息的记录日。"),
                    F("Message", "The message to append.", "要追加的消息。"),
                ]),
            Content(
                "Monitor.API.TimeRecording.Commands.Recording.CalculateWorkTime",
                "Calculate the work time of an employee between two dates.",
                "计算员工在两个日期之间的工作时间。",
                ["calculate work time", "work time calculation"], ["计算工作时间", "工时计算"],
                fields: [
                    F("EmployeeId", "The employee to calculate for.", "要计算的员工。"),
                    F("Start", "The start of the period.", "期间的开始。"),
                    F("End", "The end of the period.", "期间的结束。"),
                ]),
            Content(
                "Monitor.API.TimeRecording.Commands.Recording.CalculateWorkTimePerDay",
                "Calculate the work time of an employee, broken down per day.",
                "逐日计算员工的工作时间。",
                ["calculate work time per day", "daily work time"], ["逐日计算工时", "每日工时"],
                fields: [
                    F("EmployeeId", "The employee to calculate for.", "要计算的员工。"),
                    F("Start", "The start of the period.", "期间的开始。"),
                    F("End", "The end of the period.", "期间的结束。"),
                ]),
            Content(
                "Monitor.API.TimeRecording.Commands.Recording.ClearStandbyWork",
                "Clear the standby work of an employee.",
                "清除员工的待命工作。",
                ["clear standby work", "clear standby"], ["清除待命工作", "清除待命"],
                fields: [
                    F("EmployeeId", "The employee whose standby work to clear.", "要清除待命工作的员工。"),
                ]),
            Content(
                "Monitor.API.TimeRecording.Commands.Recording.ClockIn",
                "Clock in an employee at the attendance terminal.",
                "在考勤终端为员工打卡上班。",
                ["clock in", "punch in", "attendance clock in"], ["打卡上班", "上班打卡", "签到"],
                fields: [
                    F("EmployeeId", "The employee to clock in.", "要打卡上班的员工。"),
                    F("AbsencePeriods", "The absence periods of the clock-in; required when the system demands them.", "打卡时的缺勤期间；系统要求时必填。"),
                ]),
            Content(
                "Monitor.API.TimeRecording.Commands.Recording.ClockOut",
                "Clock out an employee at the attendance terminal.",
                "在考勤终端为员工打卡下班。",
                ["clock out", "punch out", "attendance clock out"], ["打卡下班", "下班打卡", "签退"],
                fields: [
                    F("EmployeeId", "The employee to clock out.", "要打卡下班的员工。"),
                    F("AbsenceCodeId", "The absence code of the clock-out; required when clocking out within schedule and absence check is enabled.", "打卡下班的缺勤代码；在排班内打卡且启用缺勤检查时必填。"),
                ]),
            Content(
                "Monitor.API.TimeRecording.Commands.Recording.CreateAdditionRecording",
                "Create an addition recording on a recording day.",
                "在记录日创建附加记录。",
                ["create addition recording", "add addition"], ["创建附加记录", "添加附加"],
                fields: [
                    F("RecordingDayId", "The recording day of the addition.", "附加的记录日。"),
                    F("AttendanceAdditionId", "The attendance addition of the addition.", "附加的考勤附加。"),
                    F("ProjectId", "The project the addition is charged to.", "附加计入的项目。"),
                    F("TimeBankId", "The time bank the addition is booked to.", "附加记账到的时间银行。"),
                    F("Comment", "The comment of the addition.", "附加的备注。"),
                ]),
            Content(
                "Monitor.API.TimeRecording.Commands.Recording.CreateProjectActivityReporting",
                "Create a project-activity work reporting.",
                "创建项目活动工作上报。",
                ["create project activity reporting", "report project activity"], ["创建项目活动上报", "上报项目活动"],
                fields: [
                    F("PersonId", "The person who did the work.", "进行工作的人员。"),
                    F("ActivityId", "The project activity of the work.", "工作的项目活动。"),
                    F("Comment", "The comment of the reporting.", "上报的备注。"),
                ]),
            Content(
                "Monitor.API.TimeRecording.Commands.Recording.DeleteAdditionRecording",
                "Delete an addition recording.",
                "删除附加记录。",
                ["delete addition recording", "remove addition"], ["删除附加记录", "移除附加"],
                fields: [
                    F("AdditionRecordingId", "The addition recording to delete.", "要删除的附加记录。"),
                ]),
            Content(
                "Monitor.API.TimeRecording.Commands.Recording.DeleteRecordingInterval",
                "Delete an attendance interval of a recording day.",
                "删除记录日的考勤区间。",
                ["delete recording interval", "delete attendance interval"], ["删除记录区间", "删除考勤区间"],
                fields: [
                    F("IntervalId", "The attendance interval to delete.", "要删除的考勤区间。"),
                ]),
            Content(
                "Monitor.API.TimeRecording.Commands.Recording.DeleteStandbyWork",
                "Delete a standby work.",
                "删除待命工作。",
                ["delete standby work", "remove standby"], ["删除待命工作", "移除待命"],
                fields: [
                    F("StandbyWorkId", "The standby work to delete.", "要删除的待命工作。"),
                ]),
            Content(
                "Monitor.API.TimeRecording.Commands.Recording.DeleteWorkRecordingInterval",
                "Delete a work interval of a recording day.",
                "删除记录日的工作区间。",
                ["delete work interval", "delete work recording"], ["删除工作区间", "删除工作记录"],
                fields: [
                    F("WorkRecordingIntervalId", "The work interval to delete.", "要删除的工作区间。"),
                ]),
            Content(
                "Monitor.API.TimeRecording.Commands.Recording.GetAttendanceRecordingTemplate",
                "Get the attendance-recording template (e.g. the planned intervals) of an employee.",
                "获取员工的考勤记录模板（如计划区间）。",
                ["get attendance template", "attendance recording template"], ["获取考勤模板", "考勤记录模板"],
                fields: [
                    F("EmployeeId", "The employee to get the template for.", "要获取模板的员工。"),
                ]),
            Content(
                "Monitor.API.TimeRecording.Commands.Recording.GetTraceabilityDataForReportOrderBoundWork",
                "Get the traceability data required for a report-order-bound-work call.",
                "获取订单绑定工作上报告所需的追溯数据。",
                ["get traceability data", "traceability for order work"], ["获取追溯数据", "订单工作追溯数据"],
                fields: [
                    F("ReportOrderBoundWork", "The report-order-bound-work draft to get traceability data for.", "要获取追溯数据的订单绑定工作上报草稿。"),
                ]),
            Content(
                "Monitor.API.TimeRecording.Commands.Recording.ReportOrderBoundWork",
                "Report order-bound work on a manufacturing operation.",
                "上报制造工序上的订单绑定工作。",
                ["report order bound work", "report order work", "report operation"], ["上报订单绑定工作", "上报订单工作", "上报工序工作"],
                fields: [
                    F("EmployeeId", "The employee who did the work.", "进行工作的员工。"),
                    F("PutOnStandby", "Whether to put the remaining work on standby.", "是否将剩余工作置为待命。"),
                    F("BundleId", "The bundle of the work.", "工作的批次。"),
                    F("IsSetupTime", "Whether the work is setup time.", "该工作是否为准备时间。"),
                    F("OperationId", "The manufacturing operation the work is reported on.", "上报工作的制造工序。"),
                    F("Rejections", "The rejected quantities of the work.", "工作的拒收数量。"),
                    F("Locations", "The locations the reported quantity is put into; required when the operation is last and manages stock.", "上报数量放入的库位；末道工序且管理库存时必填。"),
                    F("Comment", "The comment of the work.", "工作的备注。"),
                    F("ExistingLocations", "The existing locations the quantity is added to; required when the operation is last and manages stock.", "数量加入的现有库位；末道工序且管理库存时必填。"),
                    F("TraceabilityData", "The traceability data; required when the operation demands it.", "追溯数据；工序要求时必填。"),
                ]),
            Content(
                "Monitor.API.TimeRecording.Commands.Recording.SetApproveRecordingDay",
                "Approve or unapprove a recording day.",
                "批准或取消批准记录日。",
                ["approve recording day", "set approve recording day"], ["批准记录日", "设置记录日批准"],
                fields: [
                    F("RecordingDayId", "The recording day to approve.", "要批准的记录日。"),
                    F("Approve", "Whether to approve the recording day.", "是否批准记录日。"),
                ]),
            Content(
                "Monitor.API.TimeRecording.Commands.Recording.SetSchedule",
                "Set the schedule of a recording day.",
                "设置记录日的排班。",
                ["set schedule", "set recording day schedule"], ["设置排班", "设置记录日排班"],
                fields: [
                    F("RecordingDayId", "The recording day to set the schedule for.", "要设置排班的记录日。"),
                    F("ScheduleId", "The schedule of the day.", "当日的排班。"),
                    F("OvertimeScheduleId", "The overtime schedule of the day.", "当日的加班排班。"),
                ]),
            Content(
                "Monitor.API.TimeRecording.Commands.Recording.StartIndirectWork",
                "Start an indirect-work interval for an employee.",
                "为员工开始一段间接工作。",
                ["start indirect work", "begin indirect work"], ["开始间接工作", "开启间接工作"],
                fields: [
                    F("EmployeeId", "The employee starting the work.", "开始工作的员工。"),
                    F("IndirectWorkId", "The indirect-work code of the work.", "工作的间接工作代码。"),
                ]),
            Content(
                "Monitor.API.TimeRecording.Commands.Recording.StartOrderBoundWork",
                "Start an order-bound work interval for an employee.",
                "为员工开始一段订单绑定工作。",
                ["start order bound work", "start order work"], ["开始订单绑定工作", "开始订单工作"],
                fields: [
                    F("EmployeeId", "The employee starting the work.", "开始工作的员工。"),
                    F("OperationId", "The manufacturing operation of the work.", "工作的制造工序。"),
                    F("IsSetupTime", "Whether the work is setup time.", "该工作是否为准备时间。"),
                    F("AddToExistingBundle", "Whether to add the work to an existing bundle.", "是否将工作加入现有批次。"),
                ]),
            Content(
                "Monitor.API.TimeRecording.Commands.Recording.StartStandbyWork",
                "Start a standby work for an employee.",
                "为员工开始待命工作。",
                ["start standby work", "start standby"], ["开始待命工作", "开始待命"],
                fields: [
                    F("EmployeeId", "The employee starting the standby work.", "开始待命工作的员工。"),
                ]),
            Content(
                "Monitor.API.TimeRecording.Commands.Recording.StopIndirectWork",
                "Stop an indirect-work interval of an employee.",
                "停止员工的间接工作区间。",
                ["stop indirect work", "end indirect work"], ["停止间接工作", "结束间接工作"],
                fields: [
                    F("EmployeeId", "The employee stopping the work.", "停止工作的员工。"),
                    F("IndirectWorkId", "The indirect-work code of the work.", "工作的间接工作代码。"),
                    F("Comment", "The comment; required when the indirect-work code demands it.", "备注；间接工作代码要求时必填。"),
                ]),
        ];
    }
}
