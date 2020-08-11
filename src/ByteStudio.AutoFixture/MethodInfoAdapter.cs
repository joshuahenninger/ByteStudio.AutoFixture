using System.Collections.Generic;
using System.Reflection;

namespace AutoFixture
{
    /// <summary>
    /// Adapts a <see cref="MethodInfo"/> instance into a <see cref="ITestMethodInfo"/> instance.
    /// </summary>
    public class MethodInfoAdapter : ITestMethodInfo
    {
        /// <inheritdoc />
        public MethodInfo MethodInfo { get; }

        /// <inheritdoc />
        public IEnumerable<ParameterInfo> ParameterTypes => MethodInfo.GetParameters();

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodInfoAdapter"/> class.
        /// </summary>
        /// <param name="methodInfo">The <see cref="MethodInfo"/> to adapt.</param>
        public MethodInfoAdapter(MethodInfo methodInfo)
        {
            MethodInfo = methodInfo;
        }
    }
}
