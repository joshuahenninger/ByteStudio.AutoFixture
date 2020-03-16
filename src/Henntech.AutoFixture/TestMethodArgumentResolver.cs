
using AutoFixture.Kernel;
using System.Collections.Generic;
using System.Linq;

namespace AutoFixture
{
    /// <inheritdoc />
    public class TestMethodArgumentResolver : ITestMethodArgumentResolver
    {
        /// <summary>
        /// Generates the arguments to execute a test method.
        /// </summary>
        /// <param name="fixture">The customized fixture from which to generate arguments.</param>
        /// <param name="testMethodInfo">The test method being executed.</param>
        /// <returns>The arguments to execute a test method.</returns>
        public IEnumerable<object> GetTestMethodArguments(IFixture fixture, ITestMethodInfo testMethodInfo)
        {
            return GetTestMethodArgumentsIterator(fixture, testMethodInfo);
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
