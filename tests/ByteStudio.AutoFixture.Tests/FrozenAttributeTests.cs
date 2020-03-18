using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ByteStudio.AutoFixture.Tests
{
    [TestClass]
    public class FrozenAttributeTests
    {
        [AutoData]
        public void GetCustomizationShouldReturnExpectedCustomizationType(FrozenAttribute sut)
        {
            // Arrange
            var parameterInfo = typeof(FrozenAttributeTests).GetMethod(nameof(TestMethodWithParameter)).GetParameters()[0];

            // Act
            var actual = sut.GetCustomization(parameterInfo);

            // Assert
            Assert.AreEqual(typeof(FreezeOnMatchCustomization), actual.GetType());
        }

        [AutoData]
        public void GetCustomizationShouldReturnCustomizationWithExpectedParameterType(FrozenAttribute sut)
        {
            // Arrange
            var parameterInfo = typeof(FrozenAttributeTests).GetMethod(nameof(TestMethodWithParameter)).GetParameters()[0];
            var expectedType = parameterInfo.ParameterType;

            // Act
            var actual = (FreezeOnMatchCustomization)sut.GetCustomization(parameterInfo);

            // Assert
            Assert.AreEqual(expectedType, actual.Request);
        }

        [AutoData, AutoMoq]
        public void FrozenAttributeAppliedToTestParameterShouldUseThatInstanceForAllGeneratedInstancesOfThatType([Frozen] ITestInterface singleton,
                                                                                                                 TestClassWithTwoInterfaceDependencies sut)
        {
            // Arrange


            // Act
            
            // Assert
            Assert.AreSame(singleton, sut.Property1);
            Assert.AreSame(singleton, sut.Property2);
        }

        [AutoData, AutoMoq]
        [InlineData("hello")]
        public void ShouldNotUseFrozenInlineDataWhenGeneratingMoqParameter([Frozen] string stringParam,
                                                                           TestClassWithTwoInterfaceDependencies generatedParameter)
        {
            // Arrange


            // Act


            // Assert
            Assert.AreNotEqual("hello", generatedParameter.StringProperty);
        }

        public void TestMethodWithParameter(string parameter)
        {
            // Do not alter this method in any way. It is being used by tests within this test class.
        }

        public interface ITestInterface
        { }

        public class TestClassWithTwoInterfaceDependencies
        {
            public ITestInterface Property1 { get; set; }
            public ITestInterface Property2 { get; set; }
            public string StringProperty { get; set; }
        }
    }
}
