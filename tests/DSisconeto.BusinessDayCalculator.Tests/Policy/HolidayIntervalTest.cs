using System;
using DSisconeto.BusinessDayCalculator.Policy;
using Xunit;

namespace DSisconeto.BusinessDayCalculator.Tests.Policy
{
    public class HolidayIntervalTest
    {
        [Fact]
        public void StartAt()
        {
            var startAt = new DateTime(2018, 06, 01);
            var endAt = new DateTime(2018, 07, 01);
            var interval = new HolidayInterval(startAt, endAt);

            Assert.Equal(startAt, interval.GetStartAt());
        }

        [Fact]
        public void EndAt()
        {
            var startAt = new DateTime(2018, 06, 01);
            var endAt = new DateTime(2018, 07, 01);
            var interval = new HolidayInterval(startAt, endAt);

            Assert.Equal(endAt, interval.GetEndAt());
        }


    }
}
