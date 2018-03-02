using System;
using System.Linq;

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

            if (!budgets.Any())
            {
                return 0;
            }

            var budget = budgets.FirstOrDefault();

            var budgetDate = Convert.ToDateTime(budget.YearOfMonth);

            if (IsBudgetOverlap(startDate, endDate, budgetDate))
            {
                return budget.Amount / BudgetDateInMonth(budgetDate) * DaysInBudget(startDate, endDate);
            }

            return 0;
        }

        private static bool IsBudgetOverlap(DateTime startDate, DateTime endDate, DateTime budgetDate)
        {
            return budgetDate >= startDate && budgetDate <= endDate;
        }

        private static int DaysInBudget(DateTime startDate, DateTime endDate)
        {
            return ((endDate - startDate).Days + 1);
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