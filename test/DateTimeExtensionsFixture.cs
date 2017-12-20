using framework.extension;
using System;
using System.Collections.Generic;
using System.Globalization;
using test.poco;
using test.theory;
using Xunit;

namespace test
{
    public class DateTimeExtensionsFixture
    {
        public static List<CultureTestParameter[]> StaticParameter => new List<CultureTestParameter[]>
        {
            new CultureTestParameter[]
            {
                new CultureTestParameter
                {
                    Culture = CultureInfo.CreateSpecificCulture("it-IT"),
                    Actual = new DateTime(1988, 06, 05),
                    Expected = "05 giugno 1988"
                }
            }
        };

        [Fact]
        public void ToPrettyDate_ShouldArgumentNullException_WhenCultureIsNull()
        {
            var result = Record.Exception(() => DateTime.Now.ToPrettyDate(null));
            Assert.NotNull(result);
            var exception = Assert.IsType<ArgumentNullException>(result);
            var actual = exception.ParamName;
            const string expected = "culture";
            Assert.Equal(expected, actual);
        }

        [Theory, InlineData(new object[] { "de-DE", "2017.12.19", "19 Dezember 2017" })]
        public void ToPrettyDate_ShouldAssertTrue_WhenCultureIsGerman(string cultureCode, string textDate, string expected)
        {
            var culture = CultureInfo.CreateSpecificCulture(cultureCode);
            var date = DateTime.ParseExact(textDate, "yyyy.MM.dd", culture);
            var actual = date.ToPrettyDate(culture);
            Assert.Equal(expected, actual);
        }

        [Theory, ClassData(typeof(CultureTestTheoryData))]
        public void ToPrettyDate_ShouldAssertsTrue_WhenCultureIsDefined(CultureTestParameter parameter)
        {
            var actual = parameter.Actual.ToPrettyDate(parameter.Culture);
            var expected = parameter.Expected;
            Assert.Equal(expected, actual);
        }

        [Theory, MemberData(nameof(StaticParameter))]
        public void ToPrettyDate_ShouldAssertTrue_WhenCultureIsItalian(CultureTestParameter parameter)
        {
            var actual = parameter.Actual.ToPrettyDate(parameter.Culture);
            var expected = parameter.Expected;
            Assert.Equal(expected, actual);
        }
    }
}
