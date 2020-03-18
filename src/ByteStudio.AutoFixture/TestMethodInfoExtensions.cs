namespace AutoFixture
{
    /// <summary>
    /// Contains extension method for <see cref="ITestMethodInfo"/>.
    /// </summary>
    public static class TestMethodInfoExtensions
    {
        /// <summary>
        /// Returns a new <see cref="ITestMethodInfo"/> instance which contains a subset of parameters from the source <paramref name="testMethodInfo"/> instance.
        /// </summary>
        /// <param name="testMethodInfo">The source <see cref="ITestMethodInfo"/> instance.</param>
        /// <param name="numberOfParametersToIgnore">The number of parameters to ignore from the <paramref name="testMethodInfo"/> instance.</param>
        /// <returns>A new <see cref="ITestMethodInfo"/> instance which contains a subset of parameters from the source <paramref name="testMethodInfo"/> instance.</returns>
        public static ITestMethodInfo IgnoreParameters(this ITestMethodInfo testMethodInfo, int numberOfParametersToIgnore)
        {
            return new IgnoreParametersTestMethodInfoDecorator(testMethodInfo, numberOfParametersToIgnore);
        }
    }
}
