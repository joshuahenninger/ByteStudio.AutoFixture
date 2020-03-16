using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoFixture
{
    /// <summary>
    /// Contains extension methods for <see cref="ITestMethod"/>.
    /// </summary>
    public static class TestMethodExtensions
    {
        /// <summary>
        /// Converts to an instance of <see cref="ITestMethodInfo"/>.
        /// </summary>
        /// <param name="source">The <see cref="ITestMethod"/> instance to convert.</param>
        /// <returns>The converted <see cref="ITestMethodInfo"/>.</returns>
        public static ITestMethodInfo ToTestMethodInfo(this ITestMethod source)
        {
            return new TestMethodInfoAdapter(source);
        }
    }
}
