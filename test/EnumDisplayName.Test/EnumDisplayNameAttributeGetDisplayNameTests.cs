using System;
using AutoFixture;
using Xunit;

namespace Enable.EnumDisplayName
{
    public class EnumDisplayNameAttributeGetDisplayNameTests
    {
        [Fact]
        public void EnumDisplayNameAttribute_ReturnsDisplayNameWhenNotNullOrEmpty()
        {
            // Arrange
            var fixture = new Fixture();
            var displayName = fixture.Create<string>();
            var attribute = new EnumDisplayNameAttribute(displayName);

            // Act
            var result = attribute.GetDisplayName();

            // Assert
            Assert.Equal(displayName, result);
        }

        [Fact]
        public void EnumDisplayNameAttribute_ThrowsWhenResourceNotFound()
        {
            // Arrange
            var fixture = new Fixture();
            var resourceName = fixture.Create<string>();
            var resourceType = fixture.Create<Type>();

            var attribute = new EnumDisplayNameAttribute(resourceName, resourceType);

            // Act
            var action = new Action(() =>
            {
                var result = attribute.GetDisplayName();
            });

            // Assert
            Assert.Throws<InvalidOperationException>(action);
        }

        [Fact]
        public void EnumDisplayNameAttribute_ThrowsWhenResourceIsInternal()
        {
            // Arrange
            var attribute = new EnumDisplayNameAttribute(MockEnumDisplayNames.EnumDisplayNameAttributeWithResource, typeof(Resources.InternalMockEnum));

            // Act
            var action = new Action(() =>
            {
                var result = attribute.GetDisplayName();
            });

            // Assert
            Assert.Throws<InvalidOperationException>(action);
        }

        [Fact]
        public void EnumDisplayNameAttribute_ReturnsResourceValue()
        {
            // Arrange
            var attribute = new EnumDisplayNameAttribute(MockEnumDisplayNames.EnumDisplayNameAttributeWithResource, typeof(Resources.MockEnum));

            // Act
            var result = attribute.GetDisplayName();

            // Assert
            Assert.Equal(Resources.MockEnum.EnumDisplayNameAttributeWithResource, result);
        }
    }
}
