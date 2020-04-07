using System;
using Xunit;

namespace Enable.EnumDisplayName
{
    public class EnumExtensionsGetFlagsDisplayNameTests
    {
        [Fact]
        public void GetFlagsDisplayName_ReturnsEmptyStringWhenSourceIsNull()
        {
            // Arrange
            Enum source = null;

            // Act
            var result = source.GetFlagsDisplayName();

            // Assert
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void GetFlagsDisplayName_ReturnsEnumDisplayNameAttributeDisplayName()
        {
            // Act
            var result = MockFlagEnum.EnumDisplayNameAttribute.GetFlagsDisplayName();

            // Assert
            Assert.Equal(MockEnumDisplayNames.EnumDisplayNameAttribute, result);
        }

        [Fact]
        public void GetFlagsDisplayName_ReturnsEnumDisplayNameAttributeWithResourceDisplayName()
        {
            // Act
            var result = MockFlagEnum.EnumDisplayNameAttributeWithResource.GetFlagsDisplayName();

            // Assert
            Assert.Equal(Resources.MockEnum.EnumDisplayNameAttributeWithResource, result);
        }

        [Fact]
        public void GetFlagsDisplayName_ReturnsDisplayAttributeDisplayName()
        {
            // Act
            var result = MockFlagEnum.DisplayAttribute.GetFlagsDisplayName();

            // Assert
            Assert.Equal(MockEnumDisplayNames.DisplayAttribute, result);
        }

        [Fact]
        public void GetFlagsDisplayName_ReturnsFieldName()
        {
            // Act
            var result = MockFlagEnum.NoAttribute.GetFlagsDisplayName();

            // Assert
            Assert.Equal(MockEnumDisplayNames.NoAttribute, result);
        }

        [Fact]
        public void GetFlagsDisplayName_ReturnsEmptyStringWithSpecialNameAttribute()
        {
            // Act
            var result = MockFlagEnum.SpecialName.GetFlagsDisplayName();

            // Assert
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void GetFlagsDisplayName_ReturnsCommaSeperatedStringForFlagValues()
        {
            // Arrange
            var sut = MockFlagEnum.DisplayAttribute | MockFlagEnum.EnumDisplayNameAttribute;

            // Act
            var result = sut.GetFlagsDisplayName();

            // Assert
            var expected = $"{MockEnumDisplayNames.EnumDisplayNameAttribute},{MockEnumDisplayNames.DisplayAttribute}";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetFlagsDisplayName_ReturnsCommaSeperatedStringForFlagValues_ExceptSpecialNameAttributes()
        {
            // Arrange
            var sut = MockFlagEnum.DisplayAttribute | MockFlagEnum.SpecialName;

            // Act
            var result = sut.GetFlagsDisplayName();

            // Assert
            var expected = $"{MockEnumDisplayNames.DisplayAttribute}";
            Assert.Equal(expected, result);
        }
    }
}
