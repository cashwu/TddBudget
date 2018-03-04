using System;

namespace TddBudget
{
    public class Period
    {
        public Period(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                throw new ArgumentException();
            }
            StartDate = startDate;
            EndDate = endDate;
        }

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public int EffectiveDate(Budgets budget)
        {
            if (StartDate > budget.LastDay)
            {
                return 0;
            }

            if (EndDate < budget.FirstDay)
            {
                return 0;
            }

            var effectiveEndDate = budget.LastDay < EndDate
                ? budget.LastDay
                : EndDate;

            var effectiveStartDate = budget.FirstDay > StartDate
                ? budget.FirstDay
                : StartDate;

            return (effectiveEndDate - effectiveStartDate).Days + 1;
        }
    }
}