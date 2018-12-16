using System;
using System.Collections.Generic;
using System.Linq;
using DSisconeto.BusinessDayCalculator.Policy;

namespace DSisconeto.BusinessDayCalculator
{
    public class Calculator
    {
        private readonly IPolicy _policy;

        public Calculator(IPolicy policy)
        {
            _policy = policy;
        }

        public List<DateTime> FromDays(DateTime startAt, int days, bool extendable)
        {
            var endAt = startAt.AddDays(days);

            return Calculate(startAt, endAt, extendable);
        }

        public List<DateTime> FromInterval(DateTime startAt, DateTime endAt, bool extendable)
        {
        
            return Calculate(startAt, endAt, extendable);
        }

        public DateTime NextBusinessDay(DateTime startAt)
        {
            var endAt = startAt.AddDays(1);

            return Calculate(startAt, endAt, true).First();
        }

        private List<DateTime> Calculate(DateTime startAt, DateTime endAt, bool extendable)
        {
            var period = DatePeriod.Create(startAt, endAt);

            if (extendable)
            {
                return CalculateExtendingDate(period);
            }

            return FilterDate(period);
        }


        private List<DateTime> CalculateExtendingDate(List<DateTime> dates)
        {
            while (true)
            {
                var additionalDates = CalculateAdditionalDates(dates);
                var filteredDates = FilterDate(dates);

                filteredDates.AddRange(additionalDates);

                dates = filteredDates;

                if (additionalDates.Count != 0)
                {
                    continue;
                }

                return dates;
            }
        }

        private List<DateTime> CalculateAdditionalDates(IReadOnlyCollection<DateTime> dates)
        {

            var additionalDates = new List<DateTime>();

            foreach (var date in dates)
            {
                if (_policy.IsBusinessDay(date))
                {
                    continue;
                }
                additionalDates.Add(NextAdditionalDate(additionalDates, dates));
            }

            return additionalDates;

        }

        private static DateTime NextAdditionalDate(IReadOnlyCollection<DateTime> additionalDates, IEnumerable<DateTime> dates)
        {
            return additionalDates.Count == 0 ? dates.Last().AddDays(1) : additionalDates.Last().AddDays(1);
        }


        private List<DateTime> FilterDate(IEnumerable<DateTime> dates)
        {
            return dates.Where(date => _policy.IsBusinessDay(date)).ToList();
        }
    }
}
