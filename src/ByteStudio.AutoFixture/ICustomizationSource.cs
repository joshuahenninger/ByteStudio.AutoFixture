namespace AutoFixture
{
    /// <summary>
    /// Source of <see cref="ICustomization"/> instances.
    /// </summary>
    public interface ICustomizationSource
    {
        /// <summary>
        /// Gets an <see cref="ICustomization"/> customization.
        /// </summary>
        ICustomization GetCustomization();
    }
}
