using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;

namespace AutoFixture
{
    /// <summary>
    /// Marks a method as a MSTest method whose arguments will be auto-generated using AutoFixture during a test run.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AutoDataAttribute : DataTestMethodAttribute
    {
        /// <summary>
        /// Gets or sets the source used to create the <see cref="IFixture"/> during a test run.
        /// <para>Defaults to <see cref="TestMethodFixtureSource"/>.</para>
        /// </summary>
        protected ITestMethodFixtureSource TestMethodFixtureSource { get; set; } = new TestMethodFixtureSource();

        /// <summary>
        /// Gets or sets the resolver used to generate arguments for a test run.
        /// <para>Defaults to <see cref="TestMethodArgumentResolver"/>.</para>
        /// </summary>
        protected ITestMethodArgumentResolver TestMethodArgumentResolver { get; set; } = new TestMethodArgumentResolver();

        /// <inheritdoc />
        public override TestResult[] Execute(ITestMethod testMethod)
        {
            var dataSourceAttributes = testMethod.MethodInfo.GetCustomAttributes().OfType<ITestDataSource>().Where(dataSourceAttribute => !(dataSourceAttribute is AutoDataAttribute));
            if (dataSourceAttributes.Any())
                return base.Execute(testMethod);

            // If there are no other ITestDataSource attributes on this test method, then use AutoFixture to generate the arguments for a single test run.
            var testMethodInfo = testMethod.ToTestMethodInfo();

            var fixture = TestMethodFixtureSource.GetFixture(testMethodInfo);
            var arguments = TestMethodArgumentResolver.GetTestMethodArguments(fixture, testMethodInfo);

            return new[] { testMethod.Invoke(arguments.ToArray()) };
        }
    }
}
