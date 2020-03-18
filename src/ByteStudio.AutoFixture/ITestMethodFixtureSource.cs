namespace AutoFixture
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITestMethodFixtureSource
    {
        /// <summary>
        /// Gets an instance of <see cref="IFixture"/> using the specified <paramref name="testMethodInfo"/>.
        /// </summary>
        /// <param name="testMethodInfo">The test method information used to get an <see cref="IFixture"/> instance.</param>
        /// <returns>An <see cref="IFixture"/> instance.</returns>
        IFixture GetFixture(ITestMethodInfo testMethodInfo);
    }
}
