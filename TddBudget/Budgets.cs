using System;

namespace TddBudget
{
    public class Budgets
    {
        public decimal Amount { get; set; }
        public string YearOfMonth { get; set; }

        public DateTime FirstDay
        {
            get
            {
                return DateTime.ParseExact(YearOfMonth + "01", "yyyyMMdd", null);
            }
        }

        public DateTime LastDay
        {
            get
            {
                return DateTime.ParseExact(YearOfMonth + TotalDays, "yyyyMMdd", null);
            }
        }

        public int TotalDays
        {
            get
            {
                return DateTime.DaysInMonth(FirstDay.Year, FirstDay.Month);
            }
        }

        public decimal DailyAmount()
        {
            return (Amount / TotalDays);
        }

        public decimal TotalBudgets(Period period)
        {
            return DailyAmount() * period.EffectiveDate(this);
        }
    }
}