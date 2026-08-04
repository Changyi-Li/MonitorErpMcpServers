namespace MonitorErpMcp.Catalog.Content.TimeRecording
{
    // The using-static sits inside the namespace so the imported Content(...) builder binds before
    // the enclosing MonitorErpMcp.Catalog.Content namespace in simple-name lookup.
    using static MonitorErpMcp.Catalog.Content.ContentEntryFactory;

    /// <summary>
    /// Hand-authored content for TimeRecording dto records: bilingual field descriptions for the request
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
                "Monitor.API.TimeRecording.Commands.Recording.AbsencePeriod",
                fields: [
                    F("Start", "The start of the absence period.", "缺勤期间的开始。"),
                    F("End", "The end of the absence period.", "缺勤期间的结束。"),
                    F("AbsenceCodeId", "The absence code of the period.", "期间的缺勤代码。"),
                    F("RequirementType", "Whether the period is required, optional, or optional at schedule end.", "期间是否为必需、可选或排班结束时可选。"),
                ]),
            Content(
                "Monitor.API.TimeRecording.Commands.Recording.AttendanceAdjustment",
                fields: [
                    F("IntervalId", "The attendance interval to adjust.", "要调整的考勤区间。"),
                    F("NewStart", "The new start of the interval.", "区间的新开始。"),
                    F("NewEnd", "The new end of the interval.", "区间的新结束。"),
                    F("AbsenceCodeId", "The new absence code of the interval.", "区间的新缺勤代码。"),
                    F("AbsenceKind", "The new absence kind (default, planned, approved, time card, not continue).", "区间的新缺勤类型（默认、计划、已批准、时间卡、不连续）。"),
                    F("OvertimeTypeIdBefore", "The overtime type before the interval.", "区间前的加班类型。"),
                    F("OvertimeTypeIdAfter", "The overtime type after the interval.", "区间后的加班类型。"),
                    F("IsBreak", "Whether the interval is a break.", "区间是否为休息。"),
                    F("DeductedIfDailyHoursNotFulfilled", "Whether the interval is deducted when daily hours are not fulfilled.", "当日工时未完成时是否扣除该区间。"),
                ]),
        ];
    }
}
