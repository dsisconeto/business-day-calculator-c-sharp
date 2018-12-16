using System;
using DSisconeto.BusinessDayCalculator.Policy;
using Xunit;

namespace DSisconeto.BusinessDayCalculator.Tests.Policy
{
    public class PolicyTest
    {
        [Fact]
        public void IsNotBusinessDayOnSaturday()
        {
            var policy = Builder.Create()
                .AddIgnoreDayOfWeek(DayOfWeek.Saturday)
                .Build();

            var saturday = new DateTime(2018, 12, 15);

            Assert.False(policy.IsBusinessDay(saturday));
        }

        [Fact]
        public void IsNotBusinessDayOnSunday()
        {
            var policy = Builder.Create()
            .AddIgnoreDayOfWeek(DayOfWeek.Sunday)
            .Build();

            var sunday = new DateTime(2018, 12, 16);

            Assert.False(policy.IsBusinessDay(sunday));
        }

        [Fact]
        public void IsNotBusinessDayOnWeekends()
        {
            var policy = Builder.Create()
            .AddIgnoreDayOfWeek(DayOfWeek.Sunday, DayOfWeek.Saturday)
            .Build();

            var saturday = new DateTime(2018, 12, 15);
            var sunday = new DateTime(2018, 12, 16);

            Assert.False(policy.IsBusinessDay(saturday));
            Assert.False(policy.IsBusinessDay(sunday));
        }

        [Fact]
        public void IsBusinessDayOnSunday()
        {
            var policy = Builder.Create()
            .Build();

            var sunday = new DateTime(2018, 12, 16);
            Assert.True(policy.IsBusinessDay(sunday));
        }

        [Fact]
        public void IsBusinessDayOnSaturday()
        {
            var policy = Builder.Create()
            .Build();

            var saturday = new DateTime(2018, 12, 15);
            Assert.True(policy.IsBusinessDay(saturday));
        }


        [Fact]
        public void IsBusinessDayOnMonday()
        {
            var policy = Builder.Create()
            .AddIgnoreDayOfWeek(DayOfWeek.Sunday, DayOfWeek.Saturday)
            .Build();

            var monday = new DateTime(2018, 12, 17);
            Assert.True(policy.IsBusinessDay(monday));
        }

        [Fact]
        public void IsNotBusinessDayOnHolidayInterval()
        {
            var startAt = new DateTime(2018, 06, 1);
            var endAt = new DateTime(2018, 07, 1);
            var policy = Builder.Create()
           .AddHolidayInterval(new HolidayInterval(startAt, endAt))
           .Build();


            DatePeriod.Create(startAt, endAt)
                .ForEach(holiday =>
              {
                  Assert.False(policy.IsBusinessDay(holiday), $"The date {holiday} should be a holiday");
              });

        }

        [Fact]
        public void IsNotBusinessDayOnStartAtAndEndAt()
        {
            var startAt = new DateTime(2018, 06, 1);
            var endAt = new DateTime(2018, 07, 1);
            var policy = Builder.Create()
                .AddHolidayInterval(startAt, endAt)
                .Build();


            DatePeriod.Create(startAt, endAt)
                .ForEach(holiday =>
                {
                    Assert.False(policy.IsBusinessDay(holiday), $"The date {holiday} should be a holiday");
                });

        }


        [Fact]
        public void IsNotBusinessDayOnNatal()
        {
            var natal = new DateTime(2018, 12, 25);
            var policy = Builder.Create()
                .AddHolidays(natal)
                .Build();

            Assert.False(policy.IsBusinessDay(natal), $"The natal {natal} should be a holiday");
        }

        [Fact]
        public void IstBusinessDayOnNatal()
        {
            var natal = new DateTime(2018, 12, 25);
            var policy = Builder.Create()
                .Build();
            Assert.True(policy.IsBusinessDay(natal), $"The natal {natal} should be a holiday");
        }
    }
}
