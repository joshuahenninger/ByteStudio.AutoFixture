using AutoFixture;
using AutoFixture.Kernel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ByteStudio.AutoFixture.Tests
{
    [TestClass]
    public class TestMethodArgumentResolverTests
    {
        [TestMethod]
        public void GetTestMethodArgumentsShouldReturnEmptyCollectionGivenTestMethodInfoHasNoParameters()
        {
            // Arrange
            var fixtureMock = new Mock<IFixture>();
            var testMethodInfoMock = new Mock<ITestMethodInfo>();
            testMethodInfoMock.SetupGet(m => m.ParameterTypes)
                              .Returns(Enumerable.Empty<ParameterInfo>());
            var sut = new TestMethodArgumentResolver();

            // Act
            var actual = sut.GetTestMethodArguments(fixtureMock.Object, testMethodInfoMock.Object).ToList();

            // Assert
            Assert.AreEqual(0, actual.Count);
        }

        [TestMethod]
        public void GetTestMethodArgumentsShouldReturnOneArgumentGivenTestMethodInfoHasOneParameter()
        {
            // Arrange
            var parameters = typeof(TestMethodArgumentResolverTests).GetMethod(nameof(TestMethodWithOneParameter)).GetParameters();
            var fixtureMock = new Mock<IFixture>();
            fixtureMock.Setup(m => m.Create(It.IsAny<object>(), It.IsAny<ISpecimenContext>()))
                       .Returns("hello");
            var testMethodInfoMock = new Mock<ITestMethodInfo>();
            testMethodInfoMock.SetupGet(m => m.ParameterTypes)
                              .Returns(new []{ parameters[0] });
            var sut = new TestMethodArgumentResolver();

            // Act
            var actual = sut.GetTestMethodArguments(fixtureMock.Object, testMethodInfoMock.Object).ToList();

            // Assert
            Assert.AreEqual(1, actual.Count);
        }

        [TestMethod]
        public void GetTestMethodArgumentsShouldReturnTwoArgumentGivenTestMethodInfoHasTwoParameters()
        {
            // Arrange
            var parameters = typeof(TestMethodArgumentResolverTests).GetMethod(nameof(TestMethodWithOneParameter)).GetParameters();
            var fixtureMock = new Mock<IFixture>();
            fixtureMock.Setup(m => m.Create(It.IsAny<object>(), It.IsAny<ISpecimenContext>()))
                       .Returns("hello");
            var testMethodInfoMock = new Mock<ITestMethodInfo>();
            testMethodInfoMock.SetupGet(m => m.ParameterTypes)
                              .Returns(parameters);
            var sut = new TestMethodArgumentResolver();

            // Act
            var actual = sut.GetTestMethodArguments(fixtureMock.Object, testMethodInfoMock.Object).ToList();

            // Assert
            Assert.AreEqual(2, actual.Count);
        }

        public void TestMethodWithOneParameter(string parameterOne, int parameterTwo)
        {
            // Do not delete or modify any portion of this method. It's used for unit tests within this class.
        }

        private IEnumerable<object> GetTestMethodArgumentsIterator(IFixture fixture, ITestMethodInfo testMethodInfo)
        {
            var parameterTypes = testMethodInfo.ParameterTypes;
            if (parameterTypes?.Any() != true)
                yield break;

            var specimenContext = new SpecimenContext(fixture);

            foreach (var parameterType in parameterTypes)
                yield return specimenContext.Resolve(parameterType);
        }
    }
}
