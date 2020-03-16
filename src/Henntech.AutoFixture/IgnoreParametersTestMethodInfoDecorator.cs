using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoFixture
{
    /// <summary>
    /// Adds behavior to an <see cref="ITestMethodInfo"/> instance that skips a specified number of parameters.
    /// <para>This is useful when certain parameters need to be ignored by the AutoFixture.</para>
    /// </summary>
    public class IgnoreParametersTestMethodInfoDecorator : ITestMethodInfo
    {
        private readonly ITestMethodInfo _testMethodInfoToDecorate;

        /// <summary>
        /// Gets or sets the number of parameters that should be ignored when <see cref="ParameterTypes"/> is called.
        /// </summary>
        public int NumberOfParametersToIgnore { get; set; }

        /// <inheritdoc />
        public MethodInfo MethodInfo => _testMethodInfoToDecorate.MethodInfo;

        /// <inheritdoc />
        public IEnumerable<ParameterInfo> ParameterTypes => _testMethodInfoToDecorate.ParameterTypes.Skip(NumberOfParametersToIgnore);

        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreParametersTestMethodInfoDecorator"/> class.
        /// </summary>
        /// <param name="testMethodInfoToDecorate">The <see cref="ITestMethodInfo"/> to decorate.</param>
        public IgnoreParametersTestMethodInfoDecorator(ITestMethodInfo testMethodInfoToDecorate)
            : this(testMethodInfoToDecorate, 0)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreParametersTestMethodInfoDecorator"/> class.
        /// </summary>
        /// <param name="testMethodInfoToDecorate">The <see cref="ITestMethodInfo"/> to decorate.</param>
        /// <param name="numberOfParametersToIgnore">The number of parameters that should be ignored when <see cref="ParameterTypes"/> is called.</param>
        public IgnoreParametersTestMethodInfoDecorator(ITestMethodInfo testMethodInfoToDecorate, int numberOfParametersToIgnore)
        {
            _testMethodInfoToDecorate = testMethodInfoToDecorate;
            NumberOfParametersToIgnore = numberOfParametersToIgnore;
        }
    }
}
