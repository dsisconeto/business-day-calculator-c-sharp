using System;
using System.Collections.Generic;

namespace DSisconeto.BusinessDayCalculator.Policy
{
    public class Policy : IPolicy
    {
        private readonly HashSet<DayOfWeek> _ignoreDaysOfWeek;
        private readonly HashSet<DateTime> _holidays;

        public Policy(HashSet<DayOfWeek> ignoreDaysOfWeek, HashSet<DateTime> holidays)
        {
            _ignoreDaysOfWeek = ignoreDaysOfWeek;
            _holidays = holidays;
        }

        public bool IsBusinessDay(DateTime day)
        {

            return IsNotIgnoreDayOfWeek(day) && IsNotHoliday(day);
        }

        private bool IsNotIgnoreDayOfWeek(DateTime day)
        {

            return !_ignoreDaysOfWeek.Contains(day.DayOfWeek);
        }

        private bool IsNotHoliday(DateTime day)
        {

            return !_holidays.Contains(day);
        }

    }
}