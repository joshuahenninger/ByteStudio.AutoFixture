using AutoFixture;
using AutoFixture.Kernel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Henntech.AutoFixture.Tests
{
    [TestClass]
    public class RecursionDepthCustomizationTests
    {
        [AutoData]
        public void CustomizeShouldAddExactlyOneCustomizationToFixture(Mock<IFixture> fixtureMock,
                                                                       RecursionDepthCustomization sut)
        {
            // Arrange
            var behaviors = new List<ISpecimenBuilderTransformation>();
            fixtureMock.SetupGet(m => m.Behaviors)
                       .Returns(behaviors);

            // Act
            sut.Customize(fixtureMock.Object);

            // Assert
            Assert.AreEqual(1, behaviors.Count);
        }

        [AutoData]
        public void CustomizeShouldAddExpectedBehaviorToFixture(Mock<IFixture> fixtureMock,
                                                                RecursionDepthCustomization sut)
        {
            // Arrange
            var behaviors = new List<ISpecimenBuilderTransformation>();
            fixtureMock.SetupGet(m => m.Behaviors)
                       .Returns(behaviors);

            // Act
            sut.Customize(fixtureMock.Object);

            // Assert
            var behavior = behaviors[0];
            Assert.AreEqual(typeof(OmitOnRecursionBehavior), behavior.GetType());
        }

        [AutoData]
        public void CustomizeShouldRemoveBehaviorsOfTypeThrowingRecursionBehaviorFromFixture(Mock<IFixture> fixtureMock,
                                                                                             RecursionDepthCustomization sut)
        {
            // Arrange
            var behaviors = new List<ISpecimenBuilderTransformation>
            {
                new ThrowingRecursionBehavior()
            };
            fixtureMock.SetupGet(m => m.Behaviors)
                       .Returns(behaviors);

            // Act
            sut.Customize(fixtureMock.Object);

            // Assert
            Assert.IsFalse(behaviors.OfType<ThrowingRecursionBehavior>().Any());
        }
    }
}
