using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace AutoFixture
{
    /// <summary>
    /// Defines inline data for a unit test marked with <see cref="AutoDataAttribute"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class InlineDataAttribute : Attribute, ITestDataSource
    {
        /// <summary>
        /// Gets or sets the custom display name for the test.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets data for calling test method.
        /// </summary>
        public object[] Data { get; }

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

        /// <summary>
        /// Initializes a new instance of the <see cref="InlineDataAttribute"/> class.
        /// </summary>
        /// <param name="data1"> The data object. </param>
        public InlineDataAttribute(object data1)
        {
            // Need to have this constructor explicitly to fix a CLS compliance error.
            Data = new object[] { data1 };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InlineDataAttribute"/> class which takes in an array of arguments.
        /// </summary>
        /// <param name="data1"> A data object. </param>
        /// <param name="moreData"> More data. </param>
        public InlineDataAttribute(object data1, params object[] moreData)
        {

            if (moreData == null)
            {
                // This actually means that the user wants to pass in a 'null' value to the test method.
                moreData = new object[] { null };
            }

            Data = new object[moreData.Length + 1];
            Data[0] = data1;
            Array.Copy(moreData, 0, Data, 1, moreData.Length);
        }

        /// <inheritdoc />
        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            var numberOfInlineData = Data.Length;
            var parameters = methodInfo.GetParameters();
            var numberOfParameters = parameters.Length;
            var numberToAutoGenerate = numberOfParameters - numberOfInlineData;

            if (numberToAutoGenerate <= 0)
                return new[] { Data };

            var arguments = new List<object>(Data);
            var testMethodInfo = methodInfo.ToTestMethodInfo().IgnoreParameters(numberOfInlineData);
            var fixture = TestMethodFixtureSource.GetFixture(testMethodInfo);
            arguments.AddRange(TestMethodArgumentResolver.GetTestMethodArguments(fixture, testMethodInfo));
            return new[] { arguments.ToArray() };
        }

        /// <inheritdoc />
        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            if (!string.IsNullOrWhiteSpace(DisplayName))
            {
                return DisplayName;
            }
            else
            {
                if (data != null)
                {
                    return string.Format(CultureInfo.CurrentCulture, "{0} (Data Row {1})", methodInfo.Name, string.Join(",", data.AsEnumerable()));
                }
            }

            return null;
        }
    }
}
