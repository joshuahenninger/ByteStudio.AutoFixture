using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using System.Reflection;

namespace ByteStudio.AutoFixture.Tests
{
    [TestClass]
    public class IgnoreParametersTestMethodInfoDecoratorTests
    {
        [AutoData, AutoMoq]
        public void MethodInfoShouldReturnTheSameInstanceAsTheDecoratedObject([Frozen] ITestMethodInfo testMethodInfo,
                                                                              IgnoreParametersTestMethodInfoDecorator sut)
        {
            // Arrange


            // Act
            var actual = sut.MethodInfo;

            // Assert
            Assert.AreSame(testMethodInfo.MethodInfo, actual);
        }

        [AutoData, AutoMoq]
        public void GetParametersShouldReturnTheASubsetOfParametersAsTheDecoratedObject([Frozen] Mock<ITestMethodInfo> testMethodInfo,
                                                                                        IgnoreParametersTestMethodInfoDecorator sut)
        {
            // Arrange
            var parameterTypes = typeof(IgnoreParametersTestMethodInfoDecoratorTests).GetMethod(nameof(TestMethod)).GetParameters();
            var expected = parameterTypes.Skip(1).ToList();
            testMethodInfo.SetupGet(m => m.ParameterTypes)
                          .Returns(parameterTypes);
            sut.NumberOfParametersToIgnore = 1;

            // Act
            var actual = sut.ParameterTypes;

            // Assert
            Assert.AreEqual(2, actual.Count());
            Assert.AreEqual(expected[0], actual.ElementAt(0));
            Assert.AreEqual(expected[1], actual.ElementAt(1));
        }

        public void TestMethod(string a, int b, double c)
        { }
    }
}