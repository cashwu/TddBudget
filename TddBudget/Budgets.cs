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
                var daysInMonth = DateTime.DaysInMonth(FirstDay.Year, FirstDay.Month);
                return DateTime.ParseExact(YearOfMonth + daysInMonth, "yyyyMMdd", null);
            }
        }
    }
}