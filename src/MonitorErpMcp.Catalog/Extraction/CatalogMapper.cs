using System.Reflection;
using Monitor.API.Infrastructure;
using MonitorErpMcp.Catalog.Model;

namespace MonitorErpMcp.Catalog.Extraction
{
    /// <summary>
    /// Maps the pinned <c>Monitor.API</c> assembly into catalog records by reflection:
    /// every <c>[ApiEntity]</c> type becomes a query record and every <c>[ApiCommand]</c> type
    /// becomes a command record, each carrying its fields with generic wire types and constraints.
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
                AvailableSince = type.GetCustomAttribute<AvailableSinceAttribute>()?.Version,
                ObsoleteSince = type.GetCustomAttribute<ObsoleteSinceAttribute>()?.Version,
                Fields = MapFields(type, RecordType.Query),
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
                AvailableSince = type.GetCustomAttribute<AvailableSinceAttribute>()?.Version,
                ObsoleteSince = type.GetCustomAttribute<ObsoleteSinceAttribute>()?.Version,
                Fields = MapFields(type, RecordType.Command),
                Description = new BilingualText(),
            };
        }

        /// <summary>Maps every public property of a record type into a field, in metadata (declaration) order.</summary>
        private static IReadOnlyList<FieldRecord> MapFields(Type type, RecordType recordType) =>
            type.GetProperties().Select(p => MapField(p, recordType)).ToList();

        private static FieldRecord MapField(PropertyInfo property, RecordType recordType)
        {
            var (jsonType, format) = WireType.Map(property.PropertyType);
            var mandatory = property.GetCustomAttribute<MandatoryAttribute>();
            var isQuery = recordType == RecordType.Query;

            return new FieldRecord
            {
                Name = property.Name,
                ClrType = (Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType).ToString(),
                JsonType = jsonType,
                Format = format,
                // Field direction is implied by family, never stored: query fields are API response
                // members, so request-only semantics (mandatory/mandatoryWhen/default) are dropped even
                // if the fixture carries the attributes; command fields are request-body inputs.
                Mandatory = !isQuery && mandatory is not null,
                MandatoryWhen = !isQuery && mandatory?.Stipulation is { Length: > 0 } ? mandatory.Stipulation : null,
                Default = !isQuery ? property.GetCustomAttribute<DefaultAttribute>()?.Value : null,
                NotNull = property.GetCustomAttribute<NotNullAttribute>() is not null,
                MaxLength = property.GetCustomAttribute<MaxLengthAttribute>()?.MaxLength,
                MinLength = property.GetCustomAttribute<MinLengthAttribute>()?.MinLength,
                Unique = property.GetCustomAttribute<UniqueAttribute>() is not null,
                Expandable = property.GetCustomAttribute<ExpandableAttribute>() is not null,
                AvailableSince = property.GetCustomAttribute<AvailableSinceAttribute>()?.Version,
                ObsoleteSince = property.GetCustomAttribute<ObsoleteSinceAttribute>()?.Version,
                Description = new BilingualText(),
            };
        }
    }
}
