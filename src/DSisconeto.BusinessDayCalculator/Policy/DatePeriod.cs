using System;
using System.Collections.Generic;

namespace DSisconeto.BusinessDayCalculator.Policy
{
    public class DatePeriod
    {
        private readonly DateTime _startAt;
        private readonly DateTime _endAt;
        private readonly List<DateTime> _dates = new List<DateTime>();

        private DatePeriod(DateTime startAt, DateTime endAt)
        {
            _startAt = startAt;
            _endAt = endAt;
            Calculate();
        }

        public static List<DateTime> Create(DateTime startAt, DateTime endAt)
        {
            return new DatePeriod(startAt, endAt).ToList();
        }


        public List<DateTime> ToList()
        {

            return _dates;
        }


        private void Calculate()
        {
            var interval = _endAt - _startAt;   
            for (var daysLate = 0; daysLate <= interval.TotalDays; daysLate++)
            {
                _dates.Add(_startAt.AddDays(daysLate));
            }
        }
    }
}
