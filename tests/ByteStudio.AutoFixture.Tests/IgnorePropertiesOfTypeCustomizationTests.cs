using AutoFixture;
using AutoFixture.Kernel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace ByteStudio.AutoFixture.Tests
{
    [TestClass]
    public class IgnorePropertiesOfTypeCustomizationTests
    {
        [AutoData]
        public void CustomizeShouldAddExactlyOneCustomizationToFixture(Mock<IFixture> fixtureMock,
                                                                       IgnorePropertiesOfTypeCustomization sut)
        {
            // Arrange
            sut.Types = new Type[] { typeof(string), typeof(int) };
            var customizations = new List<ISpecimenBuilder>();
            fixtureMock.SetupGet(m => m.Customizations)
                       .Returns(customizations);

            // Act
            sut.Customize(fixtureMock.Object);

            // Assert
            Assert.AreEqual(1, customizations.Count);
        }

        [AutoData]
        public void CustomizeShouldAddExpectedCustomizationToFixture(Mock<IFixture> fixtureMock,
                                                                     IgnorePropertiesOfTypeCustomization sut)
        {
            // Arrange
            sut.Types = new Type[] { typeof(string), typeof(int) };
            var customizations = new List<ISpecimenBuilder>();
            fixtureMock.SetupGet(m => m.Customizations)
                       .Returns(customizations);

            // Act
            sut.Customize(fixtureMock.Object);

            // Assert
            var customization = customizations[0];
            Assert.AreEqual(typeof(IgnorePropertiesOfTypeSpecimenBuilder), customization.GetType());
        }
    }
}
