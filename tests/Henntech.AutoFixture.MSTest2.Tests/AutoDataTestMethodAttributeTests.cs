using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Henntech.AutoFixture.MSTest2.Tests
{
    [TestClass]
    public class AutoDataTestMethodAttributeTests
    {
        [AutoData]
        public void ExecuteShouldAutoGenerateReferenceTypeArgument(AutoDataAttribute sut)
        {
            // Arrange


            // Act


            // Assert
            Assert.IsNotNull(sut);
        }

        [AutoData]
        public void ExecuteShouldAutoGenerateValueTypeArgument(int? integer)
        {
            // Arrange


            // Act


            // Assert
            Assert.IsNotNull(integer);
        }

        [AutoData]
        public void ExecuteShouldAutoGenerateArgumentsOfDifferentTypes(string str, int? integer, AutoDataTestMethodAttributeTests autoDataTestMethodAttributeTests)
        {
            // Arrange


            // Act


            // Assert
            Assert.IsNotNull(str);
            Assert.IsNotNull(integer);
            Assert.IsNotNull(autoDataTestMethodAttributeTests);
        }
    }
}
