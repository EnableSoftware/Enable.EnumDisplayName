using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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
                    var customAttributes = field.GetCustomAttributes(false);
                    var enumDisplayNameAttribute = customAttributes.OfType<EnumDisplayNameAttribute>().FirstOrDefault();

                    if (enumDisplayNameAttribute != null)
                    {
                        return enumDisplayNameAttribute.GetDisplayName();
                    }

                    var displayNameAttribute = customAttributes.OfType<DisplayAttribute>().FirstOrDefault();

                    if (displayNameAttribute != null)
                    {
                        return displayNameAttribute.GetName();
                    }

                    return fieldName;
                }
            }

            return string.Empty;
        }
    }
}
