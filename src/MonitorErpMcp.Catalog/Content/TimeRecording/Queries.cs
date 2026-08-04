namespace MonitorErpMcp.Catalog.Content.TimeRecording
{
    // The using-static sits inside the namespace so the imported Content(...) builder binds before
    // the enclosing MonitorErpMcp.Catalog.Content namespace in simple-name lookup.
    using static MonitorErpMcp.Catalog.Content.ContentEntryFactory;
    using MonitorErpMcp.Catalog.Model;

    /// <summary>
    /// Hand-authored content for TimeRecording query records: bilingual descriptions and search aliases
    /// (en first, zh second), keyed by clrType and merged onto the structural catalog. Important
    /// fields (enum, reference, expandable, unique) carry bilingual descriptions; self-evident
    /// fields such as a bare Code or Description are skipped per the coverage tiers. The
    /// <c>Common.Commands.Persons.*</c> queries whose Module is TimeRecording are already authored in
    /// the Common content and are deliberately not re-authored here (duplicate keys would throw).
    /// </summary>
    public static class Queries
    {
        /// <summary>Hand-authored entries for this family, merged by <c>clrType</c> onto the structural catalog.</summary>
        public static readonly ContentEntry[] Entries =
        [
            // ---- AbsenceCodes ------------------------------------------------------
            Content(
                "Monitor.API.TimeRecording.AbsenceCode",
                "An absence code used to classify absences such as vacation, sickness, and leave.",
                "用于对休假、病假、请假等缺勤进行分类的缺勤代码。",
                ["absence code", "absence", "absence reason"], ["缺勤代码", "缺勤", "缺勤原因"]),

            // ---- Additions ---------------------------------------------------------
            Content(
                "Monitor.API.TimeRecording.AdditionRecording",
                "A recorded addition (e.g. a time-bank adjustment) on a recording day.",
                "在某记录日登记的附加（如时间银行调整）。",
                ["addition recording", "recorded addition"], ["附加记录", "已记录附加"],
                fields: [
                    F("AdditionType", "The type of the addition (standard, system time-bank adjustment).", "附加的类型（标准、系统时间银行调整）。"),
                    F("AttendanceAdditionId", "The attendance addition the recording is based on.", "记录所依据的考勤附加。"),
                    F("AttendanceAddition", "The attendance addition the recording is based on.", "记录所依据的考勤附加。"),
                    F("TimeBankId", "The time bank the addition is booked to.", "附加记账到的时间银行。"),
                    F("TimeBank", "The time bank the addition is booked to.", "附加记账到的时间银行。"),
                    F("TimeBankTransaction", "Whether the addition increases or decreases the time bank.", "附加是增加还是减少时间银行。"),
                    F("Comment", "The comment of the addition.", "附加的备注。"),
                    F("CostCurrencyId", "The currency of the cost.", "成本的货币。"),
                    F("ProjectId", "The project the addition is charged to.", "附加计入的项目。"),
                ]),
            Content(
                "Monitor.API.TimeRecording.AttendanceAddition",
                "An attendance addition type — a configurable addition (e.g. a time-bank adjustment) that can be recorded on a recording day.",
                "考勤附加类型 —— 可在记录日登记的附加（如时间银行调整）。",
                ["attendance addition", "addition type", "attendance addition type"], ["考勤附加", "附加类型", "考勤附加类型"],
                fields: [
                    F("AdditionType", "The type of the addition (standard, system time-bank adjustment).", "附加的类型（标准、系统时间银行调整）。"),
                    F("LinkToProjectType", "How the addition links to a project (none, optional, mandatory).", "附加与项目的关联方式（无、可选、必填）。"),
                    F("TimeBankId", "The time bank the addition is booked to.", "附加记账到的时间银行。"),
                    F("TimeBank", "The time bank the addition is booked to.", "附加记账到的时间银行。"),
                    F("TimeBankTransaction", "Whether the addition increases or decreases the time bank.", "附加是增加还是减少时间银行。"),
                    F("CostCurrencyId", "The currency of the cost.", "成本的货币。"),
                    F("SalaryTypes", "The salary types of the addition.", "附加的工资类型。"),
                    F("CostTypeId", "The cost type of the addition.", "附加的成本类型。"),
                    F("CostType", "The cost type of the addition.", "附加的成本类型。"),
                    F("CostVisibility", "Whether the cost is shown and editable (no, yes, editable).", "成本是否显示且可编辑（否、是、可编辑）。"),
                ]),

            // ---- AttendanceChart ---------------------------------------------------
            Content(
                "Monitor.API.TimeRecording.AttendanceChart",
                "An attendance-chart row — an employee's attendance and absence intervals for a date.",
                "考勤图行 —— 员工某日的考勤与缺勤区间。",
                ["attendance chart", "attendance view", "attendance overview"], ["考勤图", "考勤视图", "考勤概览"]),

            // ---- AttendanceGroupSettings --------------------------------------------
            Content(
                "Monitor.API.TimeRecording.AttendanceGroupSettings",
                "The attendance group settings — the rules governing a group of employees' time recording, overtime, and flextime.",
                "考勤组设置 —— 管理员工组的工时记录、加班与弹性时间的规则。",
                ["attendance group settings", "attendance settings", "attendance group"], ["考勤组设置", "考勤设置", "考勤组"],
                fields: [
                    F("AddRoundOffOvertimeToTimeBank", "Whether and how round-off overtime is added to the time bank (no, all time, time within flex zone).", "是否以及如何将舍入加班计入时间银行（否、全部时间、弹性区内时间）。"),
                    F("Name", "The unique name of the attendance group settings.", "考勤组设置的唯一名称。"),
                    F("CalculationBase", "The base of the day's calculation (day, hour, according to schedule).", "日计算的基础（日、小时、按排班）。"),
                    F("CalculateOvertime", "How overtime is calculated (all recorded overtime, after fulfilled daily hours).", "加班计算方式（所有记录加班、完成日工时后）。"),
                    F("SalaryTypeForPositiveFlex", "The salary type for positive flex.", "正弹性时间的工资类型。"),
                    F("SalaryTypeForNegativeFlex", "The salary type for negative flex.", "负弹性时间的工资类型。"),
                    F("CalculateFlextime", "How flextime is calculated (all recorded flex, after fulfilled daily hours).", "弹性时间计算方式（所有记录弹性、完成日工时后）。"),
                    F("SalaryTypeForScheduleLessRecording", "The salary type for recordings without a schedule.", "无排班记录的工资类型。"),
                    F("RoundOffOvertimeTimebankId", "The time bank round-off overtime is added to.", "舍入加班计入的时间银行。"),
                    F("ShorterWorkingHoursTimeBankId", "The time bank for shorter working hours.", "缩短工时的时间银行。"),
                    F("UnavailableAbsenceCodes", "The absence codes that cannot be recorded in this group.", "该组中不可记录的缺勤代码。"),
                    F("OvertimeTypes", "The overtime types allowed in this group.", "该组允许的加班类型。"),
                    F("IndirectWorkCodeId", "The indirect-work code used when the group's employees record indirectly.", "该组员工进行间接记录时使用的间接工作代码。"),
                ]),

            // ---- AttendanceIntervals ------------------------------------------------
            Content(
                "Monitor.API.TimeRecording.AttendanceInterval",
                "An attendance interval of a recording day — the time an employee was absent, with its absence kind.",
                "记录日的考勤区间 —— 员工缺勤的时间段及其缺勤类型。",
                ["attendance interval", "absence interval", "attendance period"], ["考勤区间", "缺勤区间", "考勤时段"],
                fields: [
                    F("AbsenceKind", "The kind of the absence (default, planned, approved, time card, not continue).", "缺勤的类型（默认、计划、已批准、时间卡、不连续）。"),
                ]),

            // ---- IndirectWorkCodes -------------------------------------------------
            Content(
                "Monitor.API.TimeRecording.IndirectWorkCode",
                "An indirect-work code — the reason recorded for indirect (non-order) work such as meetings, breaks, or cleaning.",
                "间接工作代码 —— 记录会议、休息、清洁等间接（非订单）工作的原因。",
                ["indirect work code", "indirect work", "indirect activity"], ["间接工作代码", "间接工作", "间接活动"],
                fields: [
                    F("CommentInputType", "Whether a comment is required (none, optional, mandatory).", "是否需要备注（无、可选、必填）。"),
                    F("AffectsOrder", "Whether and how the work affects the order (no, unit time, setup time).", "该工作是否以及如何影响订单（否、单位时间、准备时间）。"),
                ]),

            // ---- OvertimeTypes -----------------------------------------------------
            Content(
                "Monitor.API.TimeRecording.OvertimeType",
                "An overtime type used to classify overtime recording.",
                "用于对加班记录进行分类的加班类型。",
                ["overtime type", "overtime"], ["加班类型", "加班"]),

            // ---- PersonTimeBanks ---------------------------------------------------
            Content(
                "Monitor.API.TimeRecording.PersonTimeBank",
                "A person's balance in a time bank.",
                "人员在某时间银行中的余额。",
                ["person time bank", "time bank balance", "person time balance"], ["人员时间银行", "时间银行余额", "人员时间余额"],
                fields: [
                    F("PersonId", "The person the time-bank balance belongs to.", "时间银行余额所属的人员。"),
                    F("TimeBankId", "The time bank of the balance.", "余额所属的时间银行。"),
                ]),

            // ---- PersonWorkCenters -------------------------------------------------
            Content(
                "Monitor.API.TimeRecording.PersonWorkCenter",
                "A link between a person and a work center, with the person's availability and role at the center.",
                "人员与工作中心的关联，含该人员在工作中心的可用性与角色。",
                ["person work center", "person workcenter", "person machine"], ["人员工作中心", "人员工作中心关联", "人员设备"],
                fields: [
                    F("WorkCenterId", "The work center of the link.", "关联的工作中心。"),
                    F("PersonId", "The person of the link.", "关联的人员。"),
                ]),

            // ---- PlannedAbsences ---------------------------------------------------
            Content(
                "Monitor.API.TimeRecording.PlannedAbsence",
                "A planned absence (e.g. vacation) of a person, with its application status.",
                "人员的计划缺勤（如休假），含申请状态。",
                ["planned absence", "planned leave", "absence plan", "leave application"], ["计划缺勤", "计划休假", "请假申请"],
                fields: [
                    F("Status", "The status of the planned absence (applied for, approved, denied).", "计划缺勤的状态（已申请、已批准、已拒绝）。"),
                ]),

            // ---- RecordingDays -----------------------------------------------------
            Content(
                "Monitor.API.TimeRecording.RecordingDay",
                "A person's recording day — the attendance, work, and addition intervals recorded for one date.",
                "人员的记录日 —— 某日记录的考勤、工作与附加区间。",
                ["recording day", "time recording day", "work day"], ["记录日", "工时记录日", "出勤日"],
                fields: [
                    F("AttendanceIntervals", "The attendance intervals of the day.", "当日的考勤区间。"),
                    F("WorkIntervals", "The work intervals of the day.", "当日的工作区间。"),
                    F("Additions", "The additions of the day.", "当日的附加。"),
                ]),

            // ---- SalaryTypes -------------------------------------------------------
            Content(
                "Monitor.API.TimeRecording.SalaryType",
                "A salary type used to link time recording to payroll.",
                "将工时记录关联到薪酬的工资类型。",
                ["salary type", "salary code", "payroll type"], ["工资类型", "薪资类型", "薪酬类型"]),

            // ---- Schedules ---------------------------------------------------------
            Content(
                "Monitor.API.TimeRecording.Schedule",
                "A work schedule — the planned start, end, and flex times of a workday.",
                "工作排班 —— 工作日的计划开始、结束与弹性时间。",
                ["schedule", "work schedule", "shift"], ["排班", "工作排班", "班次"],
                fields: [
                    F("OvertimeScheduleId", "The overtime schedule of the schedule.", "排班的加班排班。"),
                    F("Type", "The type of the schedule (not initialized, ordinary, overtime).", "排班的类型（未初始化、普通、加班）。"),
                    F("BlockedContextType", "The context in which the schedule is blocked (none, register schedule cycle, create recording).", "排班被封锁的上下文（无、登记排班周期、创建记录）。"),
                    F("BlockedStatus", "The block status of the schedule (none, message, blocked).", "排班的封锁状态（无、消息、封锁）。"),
                    F("BlockMessage", "The block message of the schedule.", "排班的封锁消息。"),
                ]),
            Content(
                "Monitor.API.TimeRecording.Schedule_Obsolete",
                "An obsolete legacy schedule record — use the Schedule record instead.",
                "已废弃的旧版排班记录 —— 请改用 Schedule 记录。",
                ["schedule obsolete", "legacy schedule", "old schedule"], ["旧版排班", "废弃排班", "旧排班"]),

            // ---- StandbyWorks ------------------------------------------------------
            Content(
                "Monitor.API.TimeRecording.StandbyWork",
                "A standby work — work on standby (indirect or order-bound) that is recorded but not yet reported.",
                "待命工作 —— 已记录但尚未上报的待命（间接或订单绑定）工作。",
                ["standby work", "standby", "work on hold"], ["待命工作", "待命", "暂存工作"],
                fields: [
                    F("WorkRecordingType", "The type of the work (indirect, operation setup, operation unit, project activity).", "工作的类型（间接、工序准备、工序单位、项目活动）。"),
                    F("IndirectWorkCode", "The indirect-work code of a standby indirect work.", "待命间接工作的间接工作代码。"),
                    F("Operation", "The operation of a standby order-bound work.", "待命订单绑定工作的工序。"),
                ]),

            // ---- TimeBanks ---------------------------------------------------------
            Content(
                "Monitor.API.TimeRecording.TimeBank",
                "A time bank — a balance of time (e.g. flex or overtime) tracked for employees.",
                "时间银行 —— 为员工跟踪的时间余额（如弹性或加班时间）。",
                ["time bank", "time account"], ["时间银行", "时间账户"]),

            // ---- WorkIntervals -----------------------------------------------------
            Content(
                "Monitor.API.TimeRecording.WorkInterval",
                "A work interval of a recording day — a period of recorded work (indirect or order-bound).",
                "记录日的工作区间 —— 一段已记录的（间接或订单绑定）工作时间。",
                ["work interval", "work period", "work recording"], ["工作区间", "工作时间段", "工时记录"],
                fields: [
                    F("WorkRecordingType", "The type of the work (indirect, operation setup, operation unit, project activity).", "工作的类型（间接、工序准备、工序单位、项目活动）。"),
                    F("IndirectWorkCodeId", "The indirect-work code of an indirect work interval.", "间接工作区间的间接工作代码。"),
                    F("OperationId", "The operation of an order-bound work interval.", "订单绑定工作区间的工序。"),
                    F("TimeCalculationType", "How the time is calculated (recorded time, pre-calculated time, bundle distributed recorded time).", "时间的计算方式（记录时间、预计算时间、捆绑分摊记录时间）。"),
                    F("ReportingEmployeeId", "The employee who reported the work.", "上报该工作的员工。"),
                    F("WorkCenterId", "The work center the work was reported at.", "上报该工作的工作中心。"),
                    F("ActivityId", "The project activity of a project-activity work interval.", "项目活动工作区间的项目活动。"),
                    F("Comment", "The comment of the work interval.", "工作区间的备注。"),
                ]),

            // ---- WorkshopScheduleBreaks --------------------------------------------
            Content(
                "Monitor.API.TimeRecording.WorkshopScheduleBreak",
                "A break defined in a workshop schedule.",
                "车间排班中定义的休息。",
                ["workshop schedule break", "schedule break"], ["车间排班休息", "排班休息"]),

            // ---- WorkshopScheduleSalaryTypes ----------------------------------------
            Content(
                "Monitor.API.TimeRecording.WorkshopScheduleSalaryType",
                "A salary-type rule of a workshop schedule — the salary types that apply to overtime within a time range.",
                "车间排班的工资类型规则 —— 某时间段内的加班适用的工资类型。",
                ["workshop schedule salary type", "schedule salary type"], ["车间排班工资类型", "排班工资类型"],
                fields: [
                    F("WorkshopScheduleSalaryTypeRowId", "The row (time range) the salary-type rule belongs to.", "工资类型规则所属的行（时间段）。"),
                    F("OvertimeTypeId", "The overtime type the rule applies to.", "规则适用的加班类型。"),
                    F("SalaryTypes", "The salary types of the rule.", "规则的工资类型。"),
                ]),
            Content(
                "Monitor.API.TimeRecording.WorkshopScheduleSalaryTypeRow",
                "A time range of a workshop schedule for which salary types apply.",
                "车间排班中适用工资类型的时间段。",
                ["workshop schedule salary type row", "schedule salary row"], ["车间排班工资类型行", "排班工资类型行"],
                fields: [
                    F("ScheduleId", "The schedule the row belongs to.", "该行所属的排班。"),
                ]),
        ];
    }
}
