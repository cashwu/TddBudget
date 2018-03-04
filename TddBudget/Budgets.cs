using System;

namespace TddBudget
{
    public class Budgets
    {
        public decimal Amount { get; set; }
        public string YearOfMonth { get; set; }

        private DateTime FirstDay
        {
            get
            {
                return DateTime.ParseExact(YearOfMonth + "01", "yyyyMMdd", null);
            }
        }

        private DateTime LastDay
        {
            get
            {
                return DateTime.ParseExact(YearOfMonth + TotalDays, "yyyyMMdd", null);
            }
        }

        private int TotalDays
        {
            get
            {
                return DateTime.DaysInMonth(FirstDay.Year, FirstDay.Month);
            }
        }

        private decimal DailyAmount()
        {
            return (Amount / TotalDays);
        }

        public decimal TotalBudgets(Period period)
        {
            return DailyAmount() * period.EffectiveDate(new Period(FirstDay, LastDay));
        }
    }
}