using System;
using System.Reflection;

namespace AutoFixture
{
    /// <summary>
    /// Freezes the type to a single value for all AutoFixture-generated instances.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
    public class FrozenAttribute : Attribute, IParameterCustomizationSource
    {
        /// <inheritdoc />
        public ICustomization GetCustomization(ParameterInfo parameter)
        {
            return new FreezeOnMatchCustomization(parameter.ParameterType);
        }
    }
}
