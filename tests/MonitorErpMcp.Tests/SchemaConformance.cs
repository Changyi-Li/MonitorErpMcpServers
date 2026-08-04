using System.Text.Json;
using Xunit;

namespace MonitorErpMcp.Tests
{
    /// <summary>
    /// Minimal JSON Schema conformance check: asserts every property an output schema marks
    /// <c>required</c> is present in the matching response value, recursively. This mirrors the
    /// validation MCP clients apply to structured content against the advertised output schema — the
    /// contract that rejected <c>monitor_api_search</c> when a query result omitted the commands-only
    /// <c>fullPath</c>.
    /// </summary>
    internal static class SchemaConformance
    {
        public static void AssertConforms(JsonElement schema, JsonElement value, string path = "$")
        {
            if (schema.ValueKind != JsonValueKind.Object)
            {
                return; // boolean schemas impose nothing
            }

            if (schema.TryGetProperty("required", out JsonElement required) && required.ValueKind == JsonValueKind.Array)
            {
                foreach (var name in required.EnumerateArray().Select(r => r.GetString()!))
                {
                    Assert.True(
                        value.ValueKind == JsonValueKind.Object && value.TryGetProperty(name, out _),
                        $"{path} is missing required property '{name}', which the advertised output schema requires; " +
                        "a null-valued property was omitted instead of emitted.");
                }
            }

            if (value.ValueKind != JsonValueKind.Object
                || !schema.TryGetProperty("properties", out JsonElement properties)
                || properties.ValueKind != JsonValueKind.Object)
            {
                return;
            }

            foreach (var prop in properties.EnumerateObject())
            {
                if (value.TryGetProperty(prop.Name, out JsonElement child))
                {
                    AssertConforms(prop.Value, child, $"{path}.{prop.Name}");
                }
                // An absent optional property is fine — it is not in `required`.
            }
        }
    }
}
