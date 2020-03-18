using AutoFixture;
using AutoFixture.Kernel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ByteStudio.AutoFixture.Tests
{
    [TestClass]
    public class IgnorePropertiesOfTypeSpecimenBuilderTests
    {
        [AutoData]
        [AutoMoq]
        public void CreateShouldReturnNoSpecimenGivenObjectOfTypeOtherThanPropertyInfoPassedIn(string request,
                                                                                               ISpecimenContext specimenContext,
                                                                                               IgnorePropertiesOfTypeSpecimenBuilder sut)
        {
            // Arrange
            sut.Types = Enumerable.Empty<Type>();

            // Act
            var actual = sut.Create(request, specimenContext);

            // Assert
            Assert.AreEqual(typeof(NoSpecimen), actual.GetType());
        }

        [AutoData]
        [AutoMoq]
        public void CreateShouldReturnNoSpecimenGivenObjectOfTypePropertyInfoPassedInButPropertyTypeIsNotOmitted(ISpecimenContext specimenContext,
                                                                                                                 IgnorePropertiesOfTypeSpecimenBuilder sut)
        {
            // Arrange
            sut.Types = new [] { typeof(int) };
            var request = typeof(TestClassWithStringProperty).GetProperty(nameof(TestClassWithStringProperty.StringProperty));

            // Act
            var actual = sut.Create(request, specimenContext);

            // Assert
            Assert.AreEqual(typeof(NoSpecimen), actual.GetType());
        }

        [AutoData]
        [AutoMoq]
        public void CreateShouldReturnOmitSpecimenGivenObjectOfTypePropertyInfoPassedInAndPropertyTypeIsOmitted(ISpecimenContext specimenContext,
                                                                                                                IgnorePropertiesOfTypeSpecimenBuilder sut)
        {
            // Arrange
            sut.Types = new [] { typeof(string) };
            var request = typeof(TestClassWithStringProperty).GetProperty(nameof(TestClassWithStringProperty.StringProperty));

            // Act
            var actual = sut.Create(request, specimenContext);

            // Assert
            Assert.AreEqual(typeof(OmitSpecimen), actual.GetType());
        }

        private class TestClassWithStringProperty
        {
            public string StringProperty { get; set; }
        }
    }
}
