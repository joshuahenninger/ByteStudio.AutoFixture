using AutoFixture;
using Shouldly;
using Xunit;

namespace ByteStudio.AutoFixture.Xunit2.IntegrationTests
{
    public class IntegrationTests
    {
        [Theory]
        [AutoData, AutoMoq]
        public void InterfaceDependencyShouldBeMocked(IIntegrationTests test)
        {
            test.ShouldNotBeNull();
        }

        [Theory]
        [AutoData, AutoMoq]
        public void FrozenDepedencyShouldBeSameAsSubsequentDependencies([Frozen] IIntegrationTests test1, IIntegrationTests test2)
        {
            test1.ShouldBeSameAs(test2);
        }

        [Theory]
        [AutoData, AutoMoq]
        [IgnorePropertiesOfType(typeof(string))]
        public void IgnoredPropertiesShouldNotBeSetInGeneratedDependencies(IIntegrationTests test)
        {
            test.SomeString.ShouldBeNull();
        }

        [Theory]
        [AutoData, AutoMoq]
        [RecursionDepth]
        public void DefaultRecursionDepthShouldNotSetDirectRecursiveChildProperty(IIntegrationTestRecursiveDependency test)
        {
            test.Test.ShouldBeNull();
        }

        [Theory]
        [AutoData, AutoMoq]
        [RecursionDepth(2)]
        public void RecursionDepthOf2ShouldOnlySetImmediateRecursiveChildProperty(IIntegrationTestRecursiveDependency test)
        {
            test.Test.ShouldNotBeNull();
            test.Test.Test.ShouldBeNull();
        }

        public interface IIntegrationTests
        {
            public string SomeString { get; set; }
        }

        public interface IIntegrationTestRecursiveDependency
        {
            public IIntegrationTestRecursiveDependency Test { get; set; }
        }
    }
}
