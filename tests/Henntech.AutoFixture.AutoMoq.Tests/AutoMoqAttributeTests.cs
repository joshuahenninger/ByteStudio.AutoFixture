using AutoFixture;
using AutoFixture.AutoMoq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Henntech.AutoFixture.AutoMoq.Tests
{
    [TestClass]
    public class AutoMoqAttributeTests
    {
        [AutoData]
        public void GetCustomizationShouldReturnExpectedType(AutoMoqAttribute sut)
        {
            // Arrange
            var expected = typeof(AutoMoqCustomization);

            // Act
            var actual = sut.GetCustomization();

            // Assert
            Assert.AreEqual(expected, actual.GetType());
        }

        [AutoData]
        public void GetCustomizationShouldReturnCustomizationWithExpectedValues(AutoMoqAttribute sut)
        {
            // Arrange
            var expectedConfigureMembers = true;
            var expectedGenerateDelegates = true;
            sut.ConfigureMembers = expectedConfigureMembers;
            sut.GenerateDelegates = expectedGenerateDelegates;

            // Act
            var actual = (AutoMoqCustomization)sut.GetCustomization();

            // Assert
            Assert.AreEqual(expectedConfigureMembers, actual.ConfigureMembers);
            Assert.AreEqual(expectedGenerateDelegates, actual.GenerateDelegates);
        }

        [AutoData, AutoMoq]
        [InlineData(1, 2, 3)]
        public void ShouldMoqNonInlineDataInterfaceParameters(int a, int b, int c, AutoMoqAttributeTestInterface generatedParameter)
        {
            // Arrange


            // Act


            // Assert
            Assert.IsNotNull(generatedParameter);
        }

        public interface AutoMoqAttributeTestInterface
        {

        }
    }
}
