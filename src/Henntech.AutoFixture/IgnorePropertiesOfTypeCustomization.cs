using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoFixture
{
    /// <summary>
    /// Customizes AutoFixture to omit generating properties of certain types.
    /// </summary>
    public class IgnorePropertiesOfTypeCustomization : ICustomization
    {
        /// <summary>
        /// Gets or sets the property types to ignore during dependency generation.
        /// </summary>
        public IEnumerable<Type> Types { get; set; } = Enumerable.Empty<Type>();

        /// <inheritdoc />
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(new IgnorePropertiesOfTypeSpecimenBuilder { Types = Types });
        }
    }
}
