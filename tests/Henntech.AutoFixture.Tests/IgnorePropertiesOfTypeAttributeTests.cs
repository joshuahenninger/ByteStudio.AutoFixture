using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Henntech.AutoFixture.Tests
{
    [TestClass]
    public class IgnorePropertiesOfTypeAttributeTests
    {
        [AutoData]
        public void GetCustomizationShouldReturnExpectedType(IgnorePropertiesOfTypeAttribute sut)
        {
            // Arrange
            var expected = typeof(IgnorePropertiesOfTypeCustomization);

            // Act
            var actual = sut.GetCustomization();

            // Assert
            Assert.AreEqual(expected, actual.GetType());
        }
    }
}
