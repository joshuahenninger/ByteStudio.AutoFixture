using AutoFixture;
using Shouldly;
using Xunit;

namespace ByteStudio.AutoFixture.Xunit2.Tests
{
    public class InlineDataAttributeTests
    {
        [Theory]
        [InlineAutoData(1, 2, 3)]
        public void InlineDataShouldPopulateTestMethodParametersWithExpectedValues(int a, int b, int c)
        {
            // Arrange


            // Act


            // Assert
            a.ShouldBe(1);
            b.ShouldBe(2);
            c.ShouldBe(3);
        }

        [Theory]
        [InlineAutoData(1, 2, 3)]
        public void InlineDataShouldAutoGenerateNonInlineDataParameters(int a, int b, int c, string generatedParameter)
        {
            // Arrange


            // Act


            // Assert
            generatedParameter.ShouldNotBeNull();
        }

        [Theory]
        [InlineAutoData(1, 1)]
        [InlineAutoData(2, 2)]
        [InlineAutoData(3, 3)]
        public void InlineDataShouldRunTestForEachDecoratedAttribute(int actual, int expected)
        {
            // Arrange


            // Act


            // Assert
            actual.ShouldBe(expected);
        }

        [Theory(Skip = "There is no way to assert that an exception is thrown when a test is created by the framework, but you can run this manually to verify.")]
        [InlineAutoData(1, 2, 3)]
        public void InlineAutoDataShouldThrowExceptionWhenInvalidInlineDataSpecifiedForParameter(int a, int b, InlineAutoDataAttributeTestInterface generatedParameter)
        {
            // Arrange


            // Act


            // Assert

        }

        public interface InlineAutoDataAttributeTestInterface
        {
            // Do not alter this interface in any way as it it used for tests within this test class.
            public string StringProperty { get; set; }
        }
    }
}
