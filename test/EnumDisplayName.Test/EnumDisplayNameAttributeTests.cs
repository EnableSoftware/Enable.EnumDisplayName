using System;
using AutoFixture;
using Xunit;

namespace Enable.EnumDisplayName
{
    public class EnumDisplayNameAttributeTests
    {
        [Fact]
        public void EnumDisplayNameAttribute_ThrowsWhenDisplayNameIsNull()
        {
            // Act
            var action = new Action(() =>
            {
                var result = new EnumDisplayNameAttribute(null);
            });

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void EnumDisplayNameAttribute_ThrowsWhenDisplayNameIsEmpty()
        {
            // Act
            var action = new Action(() =>
            {
                var result = new EnumDisplayNameAttribute(string.Empty);
            });

            // Assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void EnumDisplayNameAttribute_ThrowsWhenResourceNameIsNull()
        {
            // Arrange
            var fixture = new Fixture();
            var resourceType = fixture.Create<Type>();

            // Act
            var action = new Action(() =>
            {
                var result = new EnumDisplayNameAttribute(null, resourceType);
            });

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void EnumDisplayNameAttribute_ThrowsWhenResourceNameIsEmpty()
        {
            // Arrange
            var fixture = new Fixture();
            var resourceType = fixture.Create<Type>();

            // Act
            var action = new Action(() =>
            {
                var result = new EnumDisplayNameAttribute(string.Empty, resourceType);
            });

            // Assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void EnumDisplayNameAttribute_ThrowsWhenResourceTypeIsNull()
        {
            // Arrange
            var fixture = new Fixture();
            var resourceName = fixture.Create<string>();

            // Act
            var action = new Action(() =>
            {
                var result = new EnumDisplayNameAttribute(resourceName, null);
            });

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void EnumDisplayNameAttribute_SetsDisplayName()
        {
            // Arrange
            var fixture = new Fixture();
            var displayName = fixture.Create<string>();

            // Act
            var result = new EnumDisplayNameAttribute(displayName);

            // Assert
            Assert.Equal(displayName, result.DisplayNameText);
            Assert.Null(result.ResourceName);
            Assert.Null(result.ResourceType);
        }

        [Fact]
        public void EnumDisplayNameAttribute_SetsResourceNameAndType()
        {
            // Arrange
            var fixture = new Fixture();
            var resourceName = fixture.Create<string>();
            var resourceType = fixture.Create<Type>();

            // Act
            var result = new EnumDisplayNameAttribute(resourceName, resourceType);

            // Assert
            Assert.Equal(resourceName, result.ResourceName);
            Assert.Equal(resourceType, result.ResourceType);
            Assert.Null(result.DisplayNameText);
        }
    }
}
