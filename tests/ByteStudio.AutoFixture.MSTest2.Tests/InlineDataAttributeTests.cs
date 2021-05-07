using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ByteStudio.AutoFixture.MSTest2.Tests
{
    [TestClass]
    public class InlineDataAttributeTests
    {
        [AutoData]
        [InlineData(1, 2, 3)]
        public void InlineDataShouldPopulateTestMethodParametersWithExpectedValues(int a, int b, int c)
        {
            // Arrange


            // Act


            // Assert
            Assert.AreEqual(1, a);
            Assert.AreEqual(2, b);
            Assert.AreEqual(3, c);
        }

        [AutoData]
        [InlineData(1, 2, 3)]
        public void InlineDataShouldAutoGenerateNonInlineDataParameters(int a, int b, int c, string generatedParameter)
        {
            // Arrange


            // Act


            // Assert
            Assert.IsNotNull(generatedParameter);
        }

        [Ignore("There is no way to assert that an exception is thrown when a test is created by the framework, but you can run this manually to verify.")]
        [AutoData]
        [InlineData(1, 2, 3)]
        public void InlineDataShouldThrowExceptionWhenInvalidInlineDataSpecifiedForParameter(int a, int b, InlineDataAttributeTestInterface generatedParameter)
        {
            // Arrange


            // Act


            // Assert

        }

        [AutoData]
        [InlineData(1, 1)]
        [InlineData("hello", "hello")]
        public void MultipleInlineDataAttributesShouldBeAllBeExecuted(object expected, object actual)
        {
            // Arrange


            // Act


            // Assert
            Assert.AreEqual(expected, actual);
        }

        public interface InlineDataAttributeTestInterface
        {
            // Do not alter this interface in any way as it it used for tests within this test class.
            public string StringProperty { get; set; }
        }
    }
}
