using System;
using Xunit;

namespace Enable.EnumDisplayName
{
    public class EnumExtensionsGetDisplayNameTests
    {
        [Fact]
        public void GetDisplayName_ReturnsEmptyStringWhenSourceIsNull()
        {
            // Arrange
            Enum source = null;

            // Act
            var result = source.GetDisplayName();

            // Assert
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void GetDisplayName_ReturnsEnumDisplayNameAttributeDisplayName()
        {
            // Act
            var result = MockEnum.EnumDisplayNameAttribute.GetDisplayName();

            // Assert
            Assert.Equal(MockEnumDisplayNames.EnumDisplayNameAttribute, result);
        }

        [Fact]
        public void GetDisplayName_ReturnsEnumDisplayNameAttributeWithResourceDisplayName()
        {
            // Act
            var result = MockEnum.EnumDisplayNameAttributeWithResource.GetDisplayName();

            // Assert
            Assert.Equal(Resources.MockEnum.EnumDisplayNameAttributeWithResource, result);
        }

        [Fact]
        public void GetDisplayName_ReturnsDisplayAttributeDisplayName()
        {
            // Act
            var result = MockEnum.DisplayAttribute.GetDisplayName();

            // Assert
            Assert.Equal(MockEnumDisplayNames.DisplayAttribute, result);
        }

        [Fact]
        public void GetDisplayName_ReturnsFieldName()
        {
            // Act
            var result = MockEnum.NoAttribute.GetDisplayName();

            // Assert
            Assert.Equal(MockEnumDisplayNames.NoAttribute, result);
        }

        [Fact]
        public void GetDisplayName_ReturnsEmptyStringWithSpecialNameAttribute()
        {
            // Act
            var result = MockEnum.SpecialName.GetDisplayName();

            // Assert
            Assert.Equal(string.Empty, result);
        }
    }
}
