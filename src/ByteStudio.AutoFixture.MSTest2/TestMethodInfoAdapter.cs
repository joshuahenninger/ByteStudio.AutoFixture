using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Reflection;

namespace AutoFixture
{
    /// <summary>
    /// Adapts an <see cref="ITestMethod"/> instance to an <see cref="ITestMethodInfo"/> instance.
    /// </summary>
    public class TestMethodInfoAdapter : ITestMethodInfo
    {
        private readonly ITestMethod _testMethod;

        /// <inheritdoc />
        public MethodInfo MethodInfo => _testMethod.MethodInfo;

        /// <inheritdoc />
        public IEnumerable<ParameterInfo> ParameterTypes => _testMethod.ParameterTypes;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestMethodInfoAdapter"/> class.
        /// </summary>
        /// <param name="testMethod">The MSTest test method info to adapt to an <see cref="ITestMethodInfo"/> instance.</param>
        public TestMethodInfoAdapter(ITestMethod testMethod)
        {
            _testMethod = testMethod;
        }
    }
}
