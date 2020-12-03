using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

#if NETSTANDARD1_3
using System.Reflection;
#endif

namespace Enable.EnumDisplayName
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Returns the display name of an enum field as specified by the EnumDisplayNameAttribute
        /// declared on the enum field. If no EnumDisplayNameAttribute is declared on the enum field
        /// then the name of the enum field is returned.
        /// </summary>
        public static string GetDisplayName(this Enum enumValue)
        {
            if (enumValue == null)
            {
                return string.Empty;
            }

            var enumType = enumValue.GetType();
            var fieldName = Enum.GetName(enumType, enumValue);
            var fields = enumType.GetFields();

            foreach (var field in fields)
            {
                if (field.IsSpecialName)
                {
                    continue;
                }

                if (string.Compare(fieldName, field.Name, StringComparison.Ordinal) == 0)
                {
                    var fieldAttributes = field
                        .GetCustomAttributes(false)
                        .Cast<Attribute>();

                    return GetNameFromEnumField(enumValue, fieldAttributes);
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Returns the display names of a flag enum as a comma seperated string as specified by the
        /// EnumDisplayNameAttribute declared on the enum field. If no EnumDisplayNameAttribute is
        /// declared on the enum field then the name of the enum field is returned.
        /// </summary>
        public static string GetFlagsDisplayName(this Enum enumValue)
        {
            if (enumValue == null)
            {
                return string.Empty;
            }

            var enumType = enumValue.GetType();
            var fieldNames = Enum.GetNames(enumType);
            var fields = enumType.GetFields()
                .Where(o => fieldNames.Contains(o.Name, StringComparer.OrdinalIgnoreCase))
                .ToArray();

            var fieldPosition = 0;
            var result = new StringBuilder();
            foreach (Enum currentValue in Enum.GetValues(enumType))
            {
                if (enumValue.HasFlag(currentValue))
                {
                    var currentField = fields[fieldPosition];
                    if (currentField.IsSpecialName)
                    {
                        fieldPosition += 1;
                        continue;
                    }

                    var fieldAttributes = currentField
                        .GetCustomAttributes(false)
                        .Cast<Attribute>();

                    var fieldName = GetNameFromEnumField(enumValue, fieldAttributes);

                    var resultPartToAdd = result.Length == 0 ? fieldName : "," + fieldName;
                    result.Append(resultPartToAdd);
                }

                fieldPosition += 1;
            }

            return result.ToString();
        }

        private static string GetNameFromEnumField(Enum enumValue, IEnumerable<Attribute> fieldAttributes)
        {
            var enumType = enumValue.GetType();
            var fieldName = Enum.GetName(enumType, enumValue);
            var enumDisplayNameAttribute = fieldAttributes
                .OfType<EnumDisplayNameAttribute>()
                .FirstOrDefault();

            if (enumDisplayNameAttribute != null)
            {
                return enumDisplayNameAttribute.GetDisplayName();
            }

            var displayNameAttribute = fieldAttributes
                .OfType<DisplayAttribute>()
                .FirstOrDefault();

            if (displayNameAttribute != null)
            {
                return displayNameAttribute.GetName();
            }

            return fieldName;
        }
    }
}
