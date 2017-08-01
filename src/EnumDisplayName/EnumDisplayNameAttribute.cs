using System;
using System.Reflection;
using Enable.Common;

namespace Enable.EnumDisplayName
{
    /// <summary>
    /// Specifies the display name for an field. The display name itself is stored within a resource
    /// file and extracted at runtime.
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field)]
    public class EnumDisplayNameAttribute : Attribute
    {
        private string _displayName;

        public EnumDisplayNameAttribute(string resourceName, Type resourceType)
        {
            Argument.IsNotNullOrEmpty(resourceName, "resourceName");
            Argument.IsNotNull(resourceType, "resourceType");

            ResourceName = resourceName;
            ResourceType = resourceType;
        }

        public EnumDisplayNameAttribute(string displayName)
        {
            Argument.IsNotNullOrEmpty(displayName, "displayName");

            DisplayNameText = displayName;
        }

        public string DisplayNameText { get; private set; }

        public string ResourceName { get; private set; }

        public Type ResourceType { get; private set; }

        public string GetDisplayName()
        {
            if (_displayName == null)
            {
                if (!string.IsNullOrEmpty(DisplayNameText))
                {
                    _displayName = DisplayNameText;
                }
                else
                {
                    if (ResourceName == null)
                    {
                        throw new ArgumentNullException(nameof(ResourceName));
                    }

                    if (ResourceType == null)
                    {
                        throw new ArgumentNullException(nameof(ResourceType));
                    }

                    PropertyInfo property = ResourceType.GetProperty(ResourceName, BindingFlags.Public | BindingFlags.Static);

                    if (property == null)
                    {
                        throw new InvalidOperationException(
                            $"The resource type '{ResourceType.FullName}' does not have a publicly visible static property named '{ResourceName}'.");
                    }

                    if (property.PropertyType != typeof(string))
                    {
                        throw new InvalidOperationException(
                            $"The property '{ResourceName}' on resource type '{ResourceType.FullName}' is not a string type.");
                    }

                    _displayName = (string)property.GetValue(null, null);
                }
            }

            return _displayName;
        }
    }
}
