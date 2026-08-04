using MonitorErpMcp.Catalog.Model;

namespace MonitorErpMcp.Catalog.Drift
{
    /// <summary>A structural record that has no authored content yet — it needs a T1 identity and/or T2 field descriptions.</summary>
    public sealed record NeedsContentRecord(string ClrType, RecordType Type, IReadOnlyList<FieldRecord> ImportantFields);

    /// <summary>An important field on an authored record that has no authored description yet.</summary>
    public sealed record NeedsContentField(string ClrType, string Field);

    /// <summary>An authored content entry whose <c>clrType</c> no longer exists in the assembly; the author deletes it (or remaps it).</summary>
    public sealed record OrphanedRecord(string ClrType);

    /// <summary>An authored field description whose field no longer exists on the still-present record; the author deletes it.</summary>
    public sealed record OrphanedField(string ClrType, string Field);

    /// <summary>
    /// A candidate one-time rename: an orphaned content entry whose described fields match a new
    /// record's full field set, so the author remaps the content key instead of re-authoring.
    /// </summary>
    public sealed record PossibleRename(string OldClrType, string NewClrType);

    /// <summary>
    /// The drift between the authored content baseline and the structural catalog of the current
    /// assembly. Not a CI gate — drift is expected during DLL bumps; the triage queue is this report
    /// plus the generated <c>Content/Pending.cs</c> stubs.
    /// </summary>
    public sealed record DriftReport(
        IReadOnlyList<NeedsContentRecord> NeedsContentRecords,
        IReadOnlyList<NeedsContentField> NeedsContentFields,
        IReadOnlyList<OrphanedRecord> OrphanedRecords,
        IReadOnlyList<OrphanedField> OrphanedFields,
        IReadOnlyList<PossibleRename> PossibleRenames);
}
