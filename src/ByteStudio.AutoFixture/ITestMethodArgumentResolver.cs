using System.Collections.Generic;

namespace AutoFixture
{
    /// <summary>
    /// Resolves arguments for a test method.
    /// </summary>
    public interface ITestMethodArgumentResolver
    {
        /// <summary>
        /// Generates the arguments to execute a test method.
        /// </summary>
        /// <param name="fixture">The customized fixture from which to generate arguments.</param>
        /// <param name="testMethodInfo">The test method being executed.</param>
        /// <returns>The arguments to execute a test method.</returns>
        IEnumerable<object> GetTestMethodArguments(IFixture fixture, ITestMethodInfo testMethodInfo);
    }
}
