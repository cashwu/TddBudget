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

        public int EffectiveDate(Period period)
        {
            if (StartDate > period.EndDate)
            {
                return 0;
            }

            if (EndDate < period.StartDate)
            {
                return 0;
            }

            var effectiveEndDate = period.EndDate < EndDate
                ? period.EndDate
                : EndDate;

            var effectiveStartDate = period.StartDate > StartDate
                ? period.StartDate
                : StartDate;

            return (effectiveEndDate - effectiveStartDate).Days + 1;
        }
    }
}