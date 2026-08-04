using MonitorErpMcp.Catalog.Model;

namespace MonitorErpMcp.Catalog.Extraction
{
    /// <summary>
    /// Scaffolds the <c>many</c> example for a batchable command: the command's route with the
    /// <c>/Many</c> suffix, a request body wrapped in an array (one element per invocation, element 2
    /// varied so the two elements differ), and an array-shaped response. The same scaffold is applied
    /// by the content merger to every batchable command that has no authored many example; an author
    /// overrides it by authoring one in the content files. A command with no request inputs honestly
    /// yields two empty elements — there is nothing to vary.
    /// </summary>
    public static class ManyExampleScaffolder
    {
        /// <summary>
        /// Derives the scaffolded many example for <paramref name="command"/> (a batchable command).
        /// When a curated command example exists, its request is reused as element 1 so the derived
        /// many shows realistic values; otherwise element 1 is scaffolded from the command's fields.
        /// </summary>
        public static CatalogExample Derive(CatalogRecord command, object? curatedRequest = null)
        {
            var element1 = curatedRequest ?? BuildBody(command.Fields, vary: false);
            var element2 = BuildBody(command.Fields, vary: true);
            return new CatalogExample
            {
                Kind = ExampleKind.Many,
                Title = new BilingualText { En = $"{command.Name} (many)", Zh = $"{command.Name}（批量）" },
                Explanation = new BilingualText
                {
                    En = "Repeat this command N times via the /Many route; each array element is one invocation.",
                    Zh = "通过 /Many 路由重复此命令 N 次；数组的每个元素为一次调用。",
                },
                Route = command.Route + "/Many",
                Method = "POST",
                Request = new[] { element1, element2 },
                Response = Array.Empty<object>(),
            };
        }

        private static Dictionary<string, object?> BuildBody(IReadOnlyList<FieldRecord> fields, bool vary)
        {
            var body = new Dictionary<string, object?>(StringComparer.Ordinal);
            foreach (var field in fields)
            {
                body[field.Name] = Placeholder(field.JsonType, vary);
            }

            return body;
        }

        private static object? Placeholder(string jsonType, bool vary) => jsonType switch
        {
            "string" => vary ? "value 2" : "value",
            "integer" => vary ? 1 : 0,
            "number" => vary ? 1 : 0,
            "boolean" => vary,
            "array" => vary
                ? new object[] { new Dictionary<string, object?>(StringComparer.Ordinal) }
                : Array.Empty<object>(),
            // Object-shaped fields (input wrappers and dtos) scaffold as the Monitor input-wrapper
            // wire shape { "Value": ... }; the empty element-1 form keeps the example honest.
            _ => vary
                ? new Dictionary<string, object?>(StringComparer.Ordinal) { ["Value"] = "value 2" }
                : new Dictionary<string, object?>(StringComparer.Ordinal),
        };
    }
}
