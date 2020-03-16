using AutoFixture.AutoMoq;
using System;

namespace AutoFixture
{
    /// <summary>
    /// Adds an AutoFixture customization that automatically generates mocked dependencies.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AutoMoqAttribute : Attribute, ICustomizationSource
    {
        /// <summary>
        ///  Specifies whether members of a mock will be automatically setup to retrieve the return values from a fixture.
        /// </summary>
        public bool ConfigureMembers { get; set; } = true;

        /// <summary>
        /// If value is true, delegate requests are intercepted and created by Moq.
        /// <para>Otherwise, if value is false, delegates are created by the AutoFixture kernel.</para>
        /// </summary>
        public bool GenerateDelegates { get; set; } = false;
        
        /// <inheritdoc />
        public ICustomization GetCustomization()
        {
            return new AutoMoqCustomization
            {
                ConfigureMembers = ConfigureMembers,
                GenerateDelegates = GenerateDelegates,
            };
        }
    }
}
