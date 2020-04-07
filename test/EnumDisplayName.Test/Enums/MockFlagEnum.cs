using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Enable.EnumDisplayName
{
    [Flags]
    public enum MockFlagEnum
    {
        [EnumDisplayName(MockEnumDisplayNames.EnumDisplayNameAttribute)]
        EnumDisplayNameAttribute = 1,

        [EnumDisplayName(MockEnumDisplayNames.EnumDisplayNameAttributeWithResource, typeof(Resources.MockEnum))]
        EnumDisplayNameAttributeWithResource = 2,

        [Display(Name = MockEnumDisplayNames.DisplayAttribute)]
        DisplayAttribute = 4,

        NoAttribute = 8,

        [SpecialName]
        [EnumDisplayName(MockEnumDisplayNames.SpecialName)]
        SpecialName = 16
    }
}
