using System;
using System.Linq;

namespace TddBudget
{
    public class BudgetService
    {
        private readonly IBudgetRepository _budgetRepository;

        public BudgetService(IBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }

        public decimal CalBudgets(DateTime startDate, DateTime endDate)
        {
            var budgets = _budgetRepository.GetAll();

            if (budgets.Any())
            {
                var budget = budgets.First();

                return budget.Amount / DaysInMonth(startDate) * BudgetDaysInMonth(startDate, endDate);
            }

            return 0;
        }

        private static int BudgetDaysInMonth(DateTime startDate, DateTime endDate)
        {
            return ((endDate - startDate).Days + 1);
        }

        private int DaysInMonth(DateTime date)
        {
            return DateTime.DaysInMonth(date.Year, date.Month);
        }
    }
}