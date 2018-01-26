using System;
using System.Globalization;
using test.poco;
using Xunit;

namespace test.theory
{
    public class ExceptionTestTheoryData : TheoryData<ExceptionTestParameter>
    {
        public ExceptionTestTheoryData()
        {
            Add(new ExceptionTestParameter
            {
                FirstValue = 15,
                SecondValue = 0,
                ExceptedException = typeof(DivideByZeroException)
            });
        }
    }
}
