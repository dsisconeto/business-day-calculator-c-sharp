using System;
using DSisconeto.BusinessDayCalculator.Policy;
using Xunit;

namespace DSisconeto.BusinessDayCalculator.Tests
{
    public class CalculatorTest
    {
        [Fact]
        public void NextBusinessDay()
        {
            var friday = new DateTime(2018, 11, 02);
            var policy = Builder.Create()
                .AddIgnoreDayOfWeek(DayOfWeek.Saturday, DayOfWeek.Sunday)
                .AddHolidays(friday)
                .Build();


            var calculator = new Calculator(policy);
            var nextBusinessDay = calculator.NextBusinessDay(friday);
            
            Assert.Equal(new DateTime(2018,11,05), nextBusinessDay);
        }

    }
}
