using System;

namespace DSisconeto.BusinessDayCalculator.Policy
{
    public interface IPolicy
    {
        bool IsBusinessDay(DateTime day);
    }
}
