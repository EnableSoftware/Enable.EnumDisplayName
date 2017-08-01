using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Enable.EnumDisplayName
{
    public enum MockEnum
    {
        [EnumDisplayName(MockEnumDisplayNames.EnumDisplayNameAttribute)]
        EnumDisplayNameAttribute,

        [EnumDisplayName(MockEnumDisplayNames.EnumDisplayNameAttributeWithResource, typeof(Resources.MockEnum))]
        EnumDisplayNameAttributeWithResource,

        [Display(Name = MockEnumDisplayNames.DisplayAttribute)]
        DisplayAttribute,

        NoAttribute,

        [SpecialName]
        [EnumDisplayName(MockEnumDisplayNames.SpecialName)]
        SpecialName
    }
}
