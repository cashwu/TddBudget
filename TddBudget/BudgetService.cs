using System;

namespace TddBudget
{
    internal class BudgetService
    {
        private readonly IBudgetRepository budgetRepo;

        public BudgetService(IBudgetRepository budgetRepo)
        {
            this.budgetRepo = budgetRepo;
        }

        public decimal GetBudget(DateTime startDate, DateTime endDate)
        {
            var budgets = budgetRepo.GetAll();

            decimal totalAmount = 0;
            foreach (var budget in budgets)
            {
                var budgetDate = Convert.ToDateTime(budget.YearOfMonth);

                if (IsBudgetOverlap(startDate, endDate, budgetDate))
                {
                    totalAmount += CalcBudget(startDate, endDate, budget, budgetDate);
                }
            }

            return totalAmount;
        }

        private decimal CalcBudget(DateTime startDate, DateTime endDate, Budget budget, DateTime budgetDate)
        {
            return budget.Amount / BudgetDateInMonth(budgetDate) * DaysInBudget(startDate, endDate, budgetDate);
        }

        private static bool IsBudgetOverlap(DateTime startDate, DateTime endDate, DateTime budgetDate)
        {
            return budgetDate.AddMonths(1).AddDays(-1) >= startDate
                   && budgetDate <= endDate;
        }

        private static int DaysInBudget(DateTime startDate, DateTime endDate, DateTime budgetDate)
        {
            var startDateInBudget = budgetDate > startDate
                ? new DateTime(budgetDate.Year, budgetDate.Month, 1)
                : startDate;

            var endDateInBudget = budgetDate.AddMonths(1).AddDays(-1) < endDate
                ? new DateTime(budgetDate.Year, budgetDate.Month, budgetDate.AddMonths(1).AddDays(-1).Day)
                : endDate;

            return ((endDateInBudget - startDateInBudget).Days + 1);
        }

        private static int BudgetDateInMonth(DateTime budgetDate)
        {
            return DateTime.DaysInMonth(budgetDate.Year, budgetDate.Month);
        }
    }

    internal class Period
    {
        private readonly DateTime startDate;
        private readonly DateTime endDate;

        public Period(DateTime startDate, DateTime endDate)
        {
            this.startDate = startDate;
            this.endDate = endDate;
        }

        public bool IsBudgetOverlap(string budgetYearOfMonth)
        {
            throw new NotImplementedException();
        }
    }
}