using System.Collections;

namespace MonitorErpMcp.Catalog.Extraction
{
    /// <summary>
    /// Maps CLR field types to the generic JSON wire-type vocabulary (<c>jsonType</c> + optional
    /// <c>format</c>) per the catalog spec's wire-type table. <c>clrType</c> stays the identity key;
    /// this mapping is what lets an agent produce correct JSON in any target language without knowing C#.
    /// </summary>
    internal static class WireType
    {
        /// <summary>Maps a CLR type to its generic JSON wire type and optional format.</summary>
        public static (string JsonType, string? Format) Map(Type type)
        {
            type = Nullable.GetUnderlyingType(type) ?? type;

            // Enum values ride the wire as their integer codes.
            if (type.IsEnum)
            {
                return ("integer", "int32");
            }

            if (type == typeof(string))
            {
                return ("string", null);
            }

            if (type == typeof(bool))
            {
                return ("boolean", null);
            }

            if (type == typeof(char))
            {
                return ("string", null);
            }

            // All 32-bit-or-narrower integral types share the int32 wire format. The pinned assembly
            // only uses int, but the mapping stays exhaustive so a future assembly bump can't silently
            // mislabel a numeric field as an object.
            if (type == typeof(int) || type == typeof(uint)
                || type == typeof(short) || type == typeof(ushort)
                || type == typeof(byte) || type == typeof(sbyte))
            {
                return ("integer", "int32");
            }

            if (type == typeof(long))
            {
                // 64-bit integers ride the wire as JSON strings so no precision is lost above 2^53.
                return ("string", "int64");
            }

            if (type == typeof(ulong))
            {
                return ("string", "int64");
            }

            if (type == typeof(decimal))
            {
                return ("number", "decimal");
            }

            if (type == typeof(double))
            {
                return ("number", "double");
            }

            if (type == typeof(float))
            {
                return ("number", "float");
            }

            if (type == typeof(DateTimeOffset) || type == typeof(DateTime))
            {
                return ("string", "date-time");
            }

            if (type == typeof(Guid))
            {
                return ("string", "uuid");
            }

            if (type == typeof(TimeSpan))
            {
                return ("string", "timespan");
            }

            // IEnumerable<T> and T[] both surface as JSON arrays; string is excluded above.
            if (typeof(IEnumerable).IsAssignableFrom(type))
            {
                return ("array", null);
            }

            // Any other class type (nested DTOs, input wrappers) is an object on the wire.
            return ("object", null);
        }
    }
}
