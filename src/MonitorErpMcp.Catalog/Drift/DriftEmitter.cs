namespace MonitorErpMcp.Catalog.Drift
{
    /// <summary>
    /// Writes the drift pipeline's only two file outputs — the drift report and the generated
    /// <c>Content/Pending.cs</c>. The authored per-module content files are never written here, so a
    /// generation run leaves them byte-identical by construction.
    /// </summary>
    public static class DriftEmitter
    {
        /// <summary>Writes <paramref name="reportText"/> and <paramref name="pendingText"/> to the two given paths.</summary>
        public static async Task WriteAsync(string reportText, string pendingText, string reportPath, string pendingPath)
        {
            await WriteFileAsync(reportPath, reportText);
            await WriteFileAsync(pendingPath, pendingText);
        }

        private static async Task WriteFileAsync(string path, string text)
        {
            var directory = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }

            await File.WriteAllTextAsync(path, text);
        }
    }
}
