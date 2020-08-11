using AutoFixture;
using Shouldly;
using Xunit;

namespace ByteStudio.AutoFixture.Xunit2.Tests
{
    public class AutoDataAttributeTests
    {
        [Theory]
        [AutoData]
        public void ExecuteShouldAutoGenerateReferenceTypeArgument(AutoDataAttribute sut)
        {
            // Arrange


            // Act


            // Assert
            sut.ShouldNotBeNull();
        }

        [Theory]
        [AutoData]
        public void ExecuteShouldAutoGenerateValueTypeArgument(int? integer)
        {
            // Arrange


            // Act


            // Assert
            integer.ShouldNotBeNull();
        }

        [Theory]
        [AutoData]
        public void ExecuteShouldAutoGenerateArgumentsOfDifferentTypes(string str, int? integer, AutoDataAttributeTests autoDataAttributeTests)
        {
            // Arrange


            // Act


            // Assert
            str.ShouldNotBeNull();
            integer.ShouldNotBeNull();
            autoDataAttributeTests.ShouldNotBeNull();
        }
    }
}
