using System;

namespace DSisconeto.BusinessDayCalculator.Policy
{
    public class HolidayInterval : IHolidayInterval
    {
        private readonly DateTime _startAt;
        private readonly DateTime _endAt;

        public HolidayInterval(DateTime startAt, DateTime endAt)
        {
            _startAt = startAt;
            _endAt = endAt;
        }

        public DateTime GetEndAt()
        {
            return _endAt;
        }

        public DateTime GetStartAt()
        {
            return _startAt;
        }
    }
}
