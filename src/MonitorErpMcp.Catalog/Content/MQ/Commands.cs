namespace MonitorErpMcp.Catalog.Content.MQ
{
    // The using-static sits inside the namespace so the imported Content(...) builder binds before
    // the enclosing MonitorErpMcp.Catalog.Content namespace in simple-name lookup.
    using static MonitorErpMcp.Catalog.Content.ContentEntryFactory;
    using MonitorErpMcp.Catalog.Model;

    /// <summary>
    /// Hand-authored content for MQ command records: bilingual descriptions and search aliases
    /// (en first, zh second), keyed by clrType and merged onto the structural catalog. The MQ area
    /// exposes a single command whose request inputs (UserName, Password) are self-evident strings
    /// and are skipped per the coverage tiers.
    /// </summary>
    public static class Commands
    {
        /// <summary>Hand-authored entries for this family, merged by <c>clrType</c> onto the structural catalog.</summary>
        public static readonly ContentEntry[] Entries =
        [
            Content(
                "Monitor.API.MQ.Commands.Users.CreateUser",
                "Create a user for the MQ (message queue) API.",
                "为 MQ（消息队列）API 创建用户。",
                ["create user", "create mq user", "new user", "mq user"], ["创建用户", "新建用户", "创建MQ用户", "MQ用户"]),
        ];
    }
}
