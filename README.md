# EnumDisplayName

C# attribute and extensions for setting and retrieving enum display names.

[![Build status](https://ci.appveyor.com/api/projects/status/xmequ026wc2gptxl?svg=true)](https://ci.appveyor.com/project/EnableSoftware/enable-enumdisplayname)

## EnumDisplayNameAttribute

A custom attribute which can be used to set the display name on enum and field attribute targets.

The constructor has 2 overloads. A string can be passed in and used as the display name:

```c#
public enum Enum
{
    [EnumDisplayName("Display name")]
    EnumValue
}
```

Or the name and type of a resource can be passed in to get a localised display name:

```c#
public enum Enum
{
    [EnumDisplayName("Resource name", typeof(Resource.Enums))]
    EnumValue
}
```

### GetDisplayName()

This method returns the display name set for the EnumDisplayNameAttribute target.

```c#
var attribute = new EnumDisplayNameAttribute("Display name");
var displayName = attribute.GetDisplayName();
```

## EnumExtensions.GetDisplayName()

If the EnumDisplayNameAttribute had been applied to an enum this method returns the display name set using this attribute.

If the System.ComponentModel.DataAnnotations.DisplayAttribute has been applied to an enum, and the EnumDisplayNameAttribute has not been applied, this method returns the display name set using this attribute.

Otherwise the method will return the field name of the enum.

```c#
var displayName = Enum.EnumValue.GetDisplayName();
```
