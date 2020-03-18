using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ByteStudio.AutoFixture.Tests
{
    [TestClass]
    public class RecursionDepthAttributeTests
    {
        [AutoData]
        public void GetCustomizationShouldReturnExpectedType(RecursionDepthAttribute sut)
        {
            // Arrange
            var expected = typeof(RecursionDepthCustomization);

            // Act
            var actual = sut.GetCustomization();

            // Assert
            Assert.AreEqual(expected, actual.GetType());
        }
    }
}
