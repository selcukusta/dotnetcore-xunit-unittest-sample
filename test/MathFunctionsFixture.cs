using framework.extension;
using System;
using System.Collections.Generic;
using System.Globalization;
using test.poco;
using test.theory;
using Xunit;

namespace test
{
    public class MathFunctionsFixture
    {
        [Theory, ClassData(typeof(ExceptionTestTheoryData))]
        public void Divide_ShouldAssertsTrue_WhenCultureSecondValueIsZero(ExceptionTestParameter parameter)
        {
            var exceptionType = Assert.ThrowsAny<SystemException>(() => parameter.FirstValue / parameter.SecondValue);
            Assert.True(exceptionType.GetType().IsAssignableFrom(parameter.ExceptedException));
        }
    }
}
