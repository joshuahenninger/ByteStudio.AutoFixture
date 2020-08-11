using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit.Sdk;

namespace AutoFixture
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AutoDataAttribute : DataAttribute
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

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            // TODO JMH Is this needed?
            //var dataSourceAttributes = testMethod.GetCustomAttributes().OfType<ITestDataSource>().Where(dataSourceAttribute => !(dataSourceAttribute is AutoDataAttribute));
            //if (dataSourceAttributes.Any())
            //    return base.Execute(testMethod);

            // If there are no other ITestDataSource attributes on this test method, then use AutoFixture to generate the arguments for a single test run.
            var testMethodInfo = testMethod.ToTestMethodInfo();

            var fixture = TestMethodFixtureSource.GetFixture(testMethodInfo);
            var arguments = TestMethodArgumentResolver.GetTestMethodArguments(fixture, testMethodInfo);

            return new[] { arguments.ToArray() };
        }
    }
}
