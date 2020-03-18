using System.Collections.Generic;
using System.Reflection;

namespace AutoFixture
{
    /// <summary>
    /// Test method information.
    /// </summary>
    public interface ITestMethodInfo
    {
        /// <summary>
        /// Gets the <see cref="MethodInfo"/> for the test method.
        /// </summary>
        MethodInfo MethodInfo { get; }

        /// <summary>
        /// Gets the parameters of the test method.
        /// </summary>
        IEnumerable<ParameterInfo> ParameterTypes { get; }
    }
}
