using System;
using System.Reflection;

namespace AutoFixture
{
    // TODO JMH Add tests for this.
    /// <inheritdoc />
    public class TestMethodFixtureSource : ITestMethodFixtureSource
    {
        /// <inheritdoc />
        public IFixture GetFixture(ITestMethodInfo testMethodInfo)
        {
            var fixture = new Fixture();

            CustomizeFixture(fixture, testMethodInfo);

            return fixture;
        }

        /// <summary>
        /// Customizes a fixture for test method execution.
        /// <para>Override to change how the generated <paramref name="fixture"/> is customized.</para>
        /// </summary>
        /// <param name="fixture">The fixture to customize.</param>
        /// <param name="testMethodInfo">The test method being executed.</param>
        protected virtual void CustomizeFixture(IFixture fixture, ITestMethodInfo testMethodInfo)
        {
            CustomizeFixtureByMethod(fixture, testMethodInfo);
            CustomizeFixtureByParameters(fixture, testMethodInfo);
        }

        /// <summary>
        /// Customizes a fixture in the order that the test method attributes are defined.
        /// <para>Override to change how the generated <paramref name="fixture"/> is customized from the test method attributes.</para>
        /// </summary>
        /// <param name="fixture">The fixture being customized.</param>
        /// <param name="testMethodInfo">The test method being executed.</param>
        protected virtual void CustomizeFixtureByMethod(IFixture fixture, ITestMethodInfo testMethodInfo)
        {
            var attributes = testMethodInfo.MethodInfo.GetCustomAttributes(typeof(Attribute), false);
            foreach (var attribute in attributes)
            {
                if (attribute is ICustomization customization)
                    customization.Customize(fixture);
                else if (attribute is ICustomizationSource customizationSource)
                    customizationSource.GetCustomization().Customize(fixture);
            }
        }

        /// <summary>
        /// Customizes a fixture in the order that the test method parameters are defined and in the order that each of the parameter attributes are defined.
        /// <para>Override to change how the generated <paramref name="fixture"/> is customized from the test method parameter attributes.</para>
        /// </summary>
        /// <param name="fixture">The fixture to customize.</param>
        /// <param name="testMethodInfo">The test method being executed.</param>
        protected virtual void CustomizeFixtureByParameters(IFixture fixture, ITestMethodInfo testMethodInfo)
        {
            foreach (var parameterType in testMethodInfo.ParameterTypes)
            {
                var attributes = parameterType.GetCustomAttributes(typeof(Attribute), false);
                foreach (var attribute in attributes)
                {
                    if (attribute is IParameterCustomizationSource parameterCustomizationSource)
                        parameterCustomizationSource.GetCustomization(parameterType).Customize(fixture);
                }
            }
        }
    }
}
