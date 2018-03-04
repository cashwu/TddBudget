using System;

namespace TddBudget
{
    public class Period
    {
        public Period(DateTime startDate, DateTime endDate)
        {
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

            return (EndDate - EffectiveStartDate(budget)).Days + 1;
        }

        public DateTime EffectiveStartDate(Budgets budget)
        {
            return budget.FirstDay > StartDate
                ? budget.FirstDay
                : StartDate;
        }
    }
}