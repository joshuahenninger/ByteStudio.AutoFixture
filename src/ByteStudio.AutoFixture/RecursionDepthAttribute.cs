using System;

namespace AutoFixture
{
    /// <summary>
    /// Limits the recursion depth of generated circular dependencies.
    /// <para>Depth &gt;= 1 where:
    /// <list type="bullet">
    /// <item>1 will only generate the root object of the circular dependency.<code>var thing = new RecursiveThing()</code></item>
    /// <item>2 will generate the root object and one recursive child.
    /// <code>
    /// var thing = new RecursiveThing 
    /// { 
    ///     Thing = new RecursiveThing() 
    /// }
    /// </code>
    /// </item>
    /// <item>...</item>
    /// <item>n will generate the root object and n-1 recursive children.</item>
    /// </list>
    /// </para>
    /// </summary>
    public class RecursionDepthAttribute : Attribute, ICustomizationSource
    {
        private readonly int _recursionDepth;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecursionDepthAttribute"/> class.
        /// </summary>
        /// <param name="recursionDepth"></param>
        public RecursionDepthAttribute(int recursionDepth = 1)
        {
            _recursionDepth = recursionDepth;
        }

        /// <inheritdoc />
        public ICustomization GetCustomization()
        {
            return new RecursionDepthCustomization(_recursionDepth);
        }
    }
}
