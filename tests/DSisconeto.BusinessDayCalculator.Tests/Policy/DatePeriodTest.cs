using System;
using System.Linq;
using DSisconeto.BusinessDayCalculator.Policy;
using Xunit;

namespace DSisconeto.BusinessDayCalculator.Tests.Policy
{
    public class DatePeriodTest
    {

        [Fact]
        public void CountingIncludeStartDateAndEndDate()
        {
            var startAt = new DateTime(2018, 06, 01);
            var endAt = new DateTime(2018, 07, 01);

            var period = DatePeriod.Create(startAt, endAt);

            Assert.Equal(31, period.Count);
        }

        [Fact]
        public void CheckIfTheStartDateIsIncluded()
        {
            var startAt = new DateTime(2018, 06, 01);
            var endAt = new DateTime(2018, 07, 01);

            var period = DatePeriod.Create(startAt, endAt);

            Assert.Equal(period.First(), startAt);
        }


        [Fact]
        public void CheckThatTheEndDateIsIncluded()
        {

            var startAt = new DateTime(2018, 06, 01);
            var endAt = new DateTime(2018, 07, 01);

            var period = DatePeriod.Create(startAt, endAt);

            Assert.Equal(period.Last(), endAt);
        }



    }
}
