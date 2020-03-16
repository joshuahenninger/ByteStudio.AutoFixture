using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoFixture
{
    /// <summary>
    /// Prevents AutoFixture from generating properties of certain types.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class IgnorePropertiesOfTypeAttribute : Attribute, ICustomizationSource
    {
        /// <summary>
        /// Gets or sets the property types to ignore during dependency generation.
        /// </summary>
        public IEnumerable<Type> Types { get; set; } = Enumerable.Empty<Type>();

        /// <summary>
        /// Initializes a new instance of the <see cref="IgnorePropertiesOfTypeAttribute"/> class.
        /// </summary>
        /// <param name="types">The property types to ignore during dependency generation.</param>
        public IgnorePropertiesOfTypeAttribute(params Type[] types)
        {
            Types = types;
        }

        /// <inheritdoc />
        public ICustomization GetCustomization()
        {
            return new IgnorePropertiesOfTypeCustomization { Types = Types };
        }
    }
}
