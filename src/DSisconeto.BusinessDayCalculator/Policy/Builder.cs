using System;
using System.Collections.Generic;

namespace DSisconeto.BusinessDayCalculator.Policy
{
    public class Builder
    {
        private readonly HashSet<DayOfWeek> _daysOfWeek = new HashSet<DayOfWeek>();
        private readonly HashSet<DateTime> _holidays = new HashSet<DateTime>();

        private Builder()
        {
        }

        public static Builder Create()
        {
            return new Builder();
        }

        public Builder AddIgnoreDayOfWeek(params DayOfWeek[] daysOfWeek)
        {
            foreach (var dayOfWeek in daysOfWeek)
            {
                _daysOfWeek.Add(dayOfWeek);
            }

            return this;
        }

        public Builder AddHolidays(params DateTime[] holidays)
        {
            foreach (var holiday in holidays)
            {
                _holidays.Add(holiday);
            }

            return this;
        }

        public Builder AddHolidayInterval(DateTime startAt, DateTime endAt)
        {

          return  _AddHolidayInterval(startAt, endAt);
        
        }

        public Builder AddHolidayInterval(IHolidayInterval interval)
        {
            return _AddHolidayInterval(interval.GetStartAt(), interval.GetEndAt());
        }

        public IPolicy Build()
        {
            return new Policy(_daysOfWeek, _holidays);
        }



        private Builder _AddHolidayInterval(DateTime startAt, DateTime endAt)
        {
            DatePeriod.Create(
                startAt,
                endAt
            ).ForEach(holiday =>
            {
                _holidays.Add(holiday);
            });
            return this;
        }
    }
}
