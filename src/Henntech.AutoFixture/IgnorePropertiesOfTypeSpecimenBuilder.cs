using AutoFixture.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoFixture
{
    /// <summary>
    /// Omits generating properties of certain types.
    /// </summary>
    public class IgnorePropertiesOfTypeSpecimenBuilder : ISpecimenBuilder
    {
        /// <summary>
        /// Gets or sets the property types to ignore during dependency generation.
        /// </summary>
        public IEnumerable<Type> Types { get; set; } = Enumerable.Empty<Type>();
        
        /// <inheritdoc />
        public object Create(object request, ISpecimenContext context)
        {
            if (request is PropertyInfo propertyInfo && Types?.Contains(propertyInfo.PropertyType) == true)
                return new OmitSpecimen();

            return new NoSpecimen();
        }
    }
}
