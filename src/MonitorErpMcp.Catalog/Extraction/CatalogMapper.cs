using System.Reflection;
using Monitor.API.Infrastructure;
using MonitorErpMcp.Catalog.Model;

namespace MonitorErpMcp.Catalog.Extraction
{
    /// <summary>
    /// Maps the pinned <c>Monitor.API</c> assembly into identity catalog records by reflection:
    /// every <c>[ApiEntity]</c> type becomes a query record and every <c>[ApiCommand]</c> type
    /// becomes a command record.
    /// </summary>
    public static class CatalogMapper
    {
        private const string QueryMethod = "GET";
        private const string CommandMethod = "POST";
        private const string RoutePrefix = "api/v1/";

        /// <summary>
        /// Extracts every query (<c>[ApiEntity]</c>) and command (<c>[ApiCommand]</c>) record from the assembly.
        /// </summary>
        public static IReadOnlyList<CatalogRecord> MapAssembly(Assembly assembly)
        {
            ArgumentNullException.ThrowIfNull(assembly);

            var records = new List<CatalogRecord>();
            foreach (var type in assembly.GetTypes())
            {
                if (type.GetCustomAttribute<ApiEntityAttribute>() is { } entity)
                {
                    records.Add(MapQuery(type, entity));
                }

                if (type.GetCustomAttribute<ApiCommandAttribute>() is { } command)
                {
                    records.Add(MapCommand(type, command));
                }
            }

            return records;
        }

        private static CatalogRecord MapQuery(Type type, ApiEntityAttribute entity)
        {
            var module = entity.Category.ToString();
            return new CatalogRecord
            {
                Type = RecordType.Query,
                Module = module,
                ClrType = type.FullName ?? type.Name,
                Name = entity.Name,
                Route = RoutePrefix + module + "/" + entity.Name,
                Method = QueryMethod,
                FullPath = null,
                Description = new BilingualText(),
            };
        }

        private static CatalogRecord MapCommand(Type type, ApiCommandAttribute command)
        {
            var module = command.Category.ToString();
            var fullPath = command.GetFullName();
            return new CatalogRecord
            {
                Type = RecordType.Command,
                Module = module,
                ClrType = type.FullName ?? type.Name,
                Name = command.CommandName,
                Route = RoutePrefix + fullPath,
                Method = CommandMethod,
                FullPath = fullPath,
                Description = new BilingualText(),
            };
        }
    }
}
