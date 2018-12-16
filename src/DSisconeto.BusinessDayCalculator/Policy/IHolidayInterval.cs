
using System;

namespace DSisconeto.BusinessDayCalculator.Policy
{
    public interface IHolidayInterval
    {
        DateTime GetStartAt();

        DateTime GetEndAt();
    }
}
