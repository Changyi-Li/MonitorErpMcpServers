using System.Collections;
using System.Reflection;
using Monitor.API.Infrastructure;
using MonitorErpMcp.Catalog.Model;

namespace MonitorErpMcp.Catalog.Extraction
{
    /// <summary>
    /// Maps the pinned <c>Monitor.API</c> assembly into catalog records by reflection: every
    /// <c>[ApiEntity]</c> type becomes a query record, every <c>[ApiCommand]</c> type becomes a command
    /// record, and every plain class reached through a field becomes a dto record. Each record carries
    /// its fields with generic wire types, constraints, and a <see cref="FieldKind"/> classification.
    /// </summary>
    public static class CatalogMapper
    {
        private const string QueryMethod = "GET";
        private const string CommandMethod = "POST";
        private const string RoutePrefix = "api/v1/";

        // The pinned assembly exposes the referenced type only through private fields; type-form
        // resolution is a spec requirement (census 1,457 type-form references), so the bypass is intended.
#pragma warning disable S3011 // Accessibility bypass: reading the referenced type from private fields is the only way.
        private static readonly FieldInfo ReferencesTypeField =
            typeof(ReferencesAttribute).GetField("type", BindingFlags.Instance | BindingFlags.NonPublic)!;

        private static readonly FieldInfo ReferencesTypeNameField =
            typeof(ReferencesAttribute).GetField("typeName", BindingFlags.Instance | BindingFlags.NonPublic)!;
#pragma warning restore S3011

        /// <summary>
        /// Extracts every query (<c>[ApiEntity]</c>), command (<c>[ApiCommand]</c>), and dto record from
        /// the assembly. Dto records are derived (never hand-pinned): the plain classes reached through
        /// fields, transitively closed, excluding enums, entities, commands, and input wrappers.
        /// </summary>
        public static IReadOnlyList<CatalogRecord> MapAssembly(Assembly assembly)
        {
            ArgumentNullException.ThrowIfNull(assembly);

            var types = assembly.GetTypes();
            var queryTypes = types.Where(t => t.GetCustomAttribute<ApiEntityAttribute>() is not null).ToList();
            var commandTypes = types.Where(t => t.GetCustomAttribute<ApiCommandAttribute>() is not null).ToList();
            var dtoTypes = DeriveDtoTypes(queryTypes.Concat(commandTypes));
            var usedBy = ComputeUsedBy(dtoTypes, queryTypes.Concat(commandTypes));

            var records = new List<CatalogRecord>(queryTypes.Count + commandTypes.Count + dtoTypes.Count);
            foreach (var type in queryTypes)
            {
                records.Add(MapQuery(type, type.GetCustomAttribute<ApiEntityAttribute>()!));
            }

            foreach (var type in commandTypes)
            {
                records.Add(MapCommand(type, type.GetCustomAttribute<ApiCommandAttribute>()!));
            }

            foreach (var type in dtoTypes)
            {
                records.Add(MapDto(type, usedBy[type]));
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

        private static CatalogRecord MapDto(Type type, IReadOnlyList<string> usedBy)
        {
            return new CatalogRecord
            {
                Type = RecordType.Dto,
                Module = null,
                ClrType = type.FullName ?? type.Name,
                Name = type.Name,
                Route = null,
                Method = null,
                FullPath = null,
                UsedBy = usedBy,
                AvailableSince = type.GetCustomAttribute<AvailableSinceAttribute>()?.Version,
                ObsoleteSince = type.GetCustomAttribute<ObsoleteSinceAttribute>()?.Version,
                Fields = MapFields(type, RecordType.Dto),
                Description = new BilingualText(),
            };
        }

        /// <summary>Maps every public property of a record type into a field, in metadata (declaration) order.</summary>
        private static IReadOnlyList<FieldRecord> MapFields(Type type, RecordType recordType) =>
            type.GetProperties().Select(p => MapField(p, recordType)).ToList();

        private static FieldRecord MapField(PropertyInfo property, RecordType recordType)
        {
            var (jsonType, format) = WireType.Map(property.PropertyType);
            var effectiveType = EffectiveType(property.PropertyType);
            var kind = ClassifyKind(property, effectiveType);
            var reference = property.GetCustomAttribute<ReferencesAttribute>();
            var mandatory = property.GetCustomAttribute<MandatoryAttribute>();

            return new FieldRecord
            {
                Name = property.Name,
                ClrType = (Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType).ToString(),
                JsonType = jsonType,
                Format = format,
                Kind = kind,
                // The reference info is attribute-driven and independent of kind: a LongInput wrapper
                // marked [References(typeof(X))] is an inputWrapper that still names entity X.
                References = reference is not null ? ResolveReferenceName(reference) : null,
                RefClrType = RefClrTypeFor(kind, effectiveType, reference),
                Enum = EnumFor(property, kind, effectiveType),
                // Field direction is implied by family, never stored: query fields are API response
                // members, so request-only semantics (mandatory/mandatoryWhen/default) are dropped even
                // if the fixture carries the attributes; command and dto fields are request-body inputs.
                Mandatory = recordType != RecordType.Query && mandatory is not null,
                MandatoryWhen = recordType != RecordType.Query && mandatory?.Stipulation is { Length: > 0 } ? mandatory.Stipulation : null,
                Default = recordType != RecordType.Query ? property.GetCustomAttribute<DefaultAttribute>()?.Value : null,
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

        /// <summary>
        /// Classifies a field by its attributes and effective CLR type, most specific first:
        /// input wrapper (wire shape) &gt; enum &gt; nested command &gt; reference &gt; expandable &gt; dto &gt; raw.
        /// </summary>
        private static FieldKind ClassifyKind(PropertyInfo property, Type effectiveType)
        {
            if (IsInputWrapper(effectiveType))
            {
                return FieldKind.InputWrapper;
            }

            if (effectiveType.IsEnum)
            {
                return FieldKind.Enum;
            }

            if (effectiveType.GetCustomAttribute<ApiCommandAttribute>() is not null)
            {
                return FieldKind.NestedCommand;
            }

            if (property.GetCustomAttribute<ReferencesAttribute>() is not null)
            {
                return FieldKind.Reference;
            }

            if (property.GetCustomAttribute<ExpandableAttribute>() is not null)
            {
                return FieldKind.Expandable;
            }

            if (IsDtoCandidate(effectiveType))
            {
                return FieldKind.Dto;
            }

            return FieldKind.Raw;
        }

        /// <summary>
        /// The numeric value vocabulary for an enum field (kind <see cref="FieldKind.Enum"/>) or an
        /// enum-valued input wrapper (kind <see cref="FieldKind.InputWrapper"/> marked
        /// <c>[EnumInput(typeof(T))]</c>). <c>null</c> when suppressed from documentation.
        /// </summary>
        private static FieldEnum? EnumFor(PropertyInfo property, FieldKind kind, Type effectiveType)
        {
            if (property.GetCustomAttribute<SuppressEnumerationInDocumentationAttribute>() is not null)
            {
                return null;
            }

            var enumType = kind switch
            {
                FieldKind.Enum => effectiveType,
                FieldKind.InputWrapper => property.GetCustomAttribute<EnumInputAttribute>()?.Type,
                _ => null,
            };

            if (enumType is null)
            {
                return null;
            }

            var names = Enum.GetNames(enumType);
            var values = Enum.GetValues(enumType);
            return new FieldEnum
            {
                ClrType = enumType.FullName ?? enumType.Name,
                Values = names
                    .Select((name, index) => new FieldEnumValue { Name = name, Value = Convert.ToInt64(values.GetValue(index)) })
                    .ToList(),
            };
        }

        /// <summary>
        /// The referenced type's full CLR name for fields that point at another record: dto/nested
        /// command/expandable fields use the effective (element) type; a type-form <c>[References]</c>
        /// uses the referenced type's full name (string-form references carry no type).
        /// </summary>
        private static string? RefClrTypeFor(FieldKind kind, Type effectiveType, ReferencesAttribute? reference) => kind switch
        {
            FieldKind.Dto or FieldKind.NestedCommand or FieldKind.Expandable => effectiveType.FullName ?? effectiveType.Name,
            _ => reference is null ? null : ReferencedType(reference)?.FullName,
        };

        /// <summary>Resolves <c>[References]</c> to the referenced entity's simple CLR name; string-form references are kept verbatim.</summary>
        private static string? ResolveReferenceName(ReferencesAttribute attribute)
        {
            var referencedType = ReferencedType(attribute);
            if (referencedType is not null)
            {
                return referencedType.Name;
            }

            var typeName = ReferencedTypeName(attribute);
            return string.IsNullOrEmpty(typeName) ? null : typeName;
        }

        private static Type? ReferencedType(ReferencesAttribute? attribute) =>
            attribute is null ? null : ReferencesTypeField.GetValue(attribute) as Type;

        private static string? ReferencedTypeName(ReferencesAttribute attribute) =>
            ReferencesTypeNameField.GetValue(attribute) as string;

        /// <summary>
        /// Derives the dto record set by breadth-first traversal of field-referenced classes, excluding
        /// queries, commands, enums, input wrappers, attributes, collections, and infrastructure types.
        /// </summary>
        private static List<Type> DeriveDtoTypes(IEnumerable<Type> seedTypes)
        {
            var dtos = new HashSet<Type>();
            var queue = new Queue<Type>();

            foreach (var type in seedTypes)
            {
                foreach (var property in type.GetProperties())
                {
                    EnqueueCandidate(EffectiveType(property.PropertyType));
                }
            }

            while (queue.Count > 0)
            {
                var dto = queue.Dequeue();
                foreach (var property in dto.GetProperties())
                {
                    EnqueueCandidate(EffectiveType(property.PropertyType));
                }
            }

            return dtos.OrderBy(t => t.FullName, StringComparer.Ordinal).ToList();

            void EnqueueCandidate(Type type)
            {
                if (IsDtoCandidate(type) && dtos.Add(type))
                {
                    queue.Enqueue(type);
                }
            }
        }

        /// <summary>
        /// The reverse-reference for each dto: the clrTypes of the records (query/command/dto) whose
        /// fields directly reference it, sorted for a stable catalog.
        /// </summary>
        private static Dictionary<Type, List<string>> ComputeUsedBy(
            IEnumerable<Type> dtoTypes,
            IEnumerable<Type> allRecordTypes)
        {
            var dtoSet = dtoTypes.ToHashSet();
            var usedBy = dtoTypes.ToDictionary(t => t, _ => new SortedSet<string>(StringComparer.Ordinal));

            foreach (var type in allRecordTypes.Concat(dtoTypes))
            {
                foreach (var property in type.GetProperties())
                {
                    var effective = EffectiveType(property.PropertyType);
                    if (dtoSet.Contains(effective))
                    {
                        usedBy[effective].Add(type.FullName ?? type.Name);
                    }
                }
            }

            return usedBy.ToDictionary(kv => kv.Key, kv => kv.Value.ToList());
        }

        /// <summary>
        /// A class that qualifies as a dto record: a plain, non-entity, non-command, non-wrapper,
        /// non-collection class in the assembly (e.g. <c>ArrivalLocation</c>).
        /// </summary>
        private static bool IsDtoCandidate(Type type)
        {
            if (!type.IsClass || type == typeof(object))
            {
                return false;
            }

            if (type.GetCustomAttribute<ApiEntityAttribute>() is not null
                || type.GetCustomAttribute<ApiCommandAttribute>() is not null)
            {
                return false;
            }

            if (IsInputWrapper(type)
                || type.Namespace?.StartsWith("Monitor.API.Infrastructure", StringComparison.Ordinal) == true
                || typeof(Attribute).IsAssignableFrom(type)
                || typeof(IEnumerable).IsAssignableFrom(type))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// The type that a field's value carries on the wire: unwraps <c>Nullable&lt;T&gt;</c> and the
        /// element of a collection (<c>T[]</c> or <c>IEnumerable&lt;T&gt;</c>), which is what classification
        /// and the dto graph operate on.
        /// </summary>
        private static Type EffectiveType(Type fieldType)
        {
            var type = Nullable.GetUnderlyingType(fieldType) ?? fieldType;
            if (type.IsArray)
            {
                return type.GetElementType()!;
            }

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                return type.GetGenericArguments()[0];
            }

            return type;
        }

        /// <summary>A <c>*Input</c> wrapper derives from <c>CommandInput&lt;T&gt;</c> (e.g. <c>NotNullLongInput</c>).</summary>
        private static bool IsInputWrapper(Type type) =>
            type.BaseType is { IsGenericType: true } baseType
            && baseType.GetGenericTypeDefinition() == typeof(CommandInput<>);
    }
}
