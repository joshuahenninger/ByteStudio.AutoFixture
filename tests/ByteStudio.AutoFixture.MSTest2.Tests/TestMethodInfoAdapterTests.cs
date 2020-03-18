using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ByteStudio.AutoFixture.MSTest2.Tests
{
    [TestClass]
    public class TestMethodInfoAdapterTests
    {
        [TestMethod]
        public void MethodInfoShouldReturnWrappedTestMethodMethodInfo()
        {
            // Arrange
            var methodInfo = typeof(TestMethodInfoAdapterTests).GetMethod(nameof(TestMethod));
            var testMethodMock = new Mock<ITestMethod>();
            testMethodMock.SetupGet(m => m.MethodInfo)
                          .Returns(methodInfo);
            var sut = new TestMethodInfoAdapter(testMethodMock.Object);

            // Act
            var actual = sut.MethodInfo;

            // Assert
            Assert.AreEqual(methodInfo, actual);
        }

        [TestMethod]
        public void ParameterTypesShouldReturnWrappedTestMethodParameterTypes()
        {
            // Arrange
            var parameterTypes = typeof(TestMethodInfoAdapterTests).GetMethod(nameof(TestMethod)).GetParameters();
            var testMethodMock = new Mock<ITestMethod>();
            testMethodMock.SetupGet(m => m.ParameterTypes)
                          .Returns(parameterTypes);
            var sut = new TestMethodInfoAdapter(testMethodMock.Object);

            // Act
            var actual = sut.ParameterTypes;

            // Assert
            Assert.AreEqual(parameterTypes, actual);
        }

        public void TestMethod(string parameterOne, int parameterTwo)
        {
            // Do not alter this method. It is used by tests within this test class.
        }
    }
}
