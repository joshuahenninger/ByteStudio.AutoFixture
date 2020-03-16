using System.Reflection;

namespace AutoFixture
{
    /// <summary>
    /// Contains extensions for <see cref="MethodInfo"/> instances.
    /// </summary>
    public static class MethodInfoExtensions
    {
        /// <summary>
        /// Converts a <see cref="MethodInfo"/> instance into an instance of <see cref="ITestMethodInfo"/>.
        /// </summary>
        /// <param name="source">The <see cref="MethodInfo"/> to convert.</param>
        /// <returns>An instance of <see cref="ITestMethodInfo"/>.</returns>
        public static ITestMethodInfo ToTestMethodInfo(this MethodInfo source)
        {
            return new MethodInfoAdapter(source);
        }
    }
}
