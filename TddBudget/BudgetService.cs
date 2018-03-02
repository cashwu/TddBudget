using System;

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
            var totalAmount = 0m;
            foreach (var budget in budgets)
            {
                totalAmount += BudgetInMonth(startDate, endDate, budget);
            }

            return totalAmount;
        }

        private decimal BudgetInMonth(DateTime startDate, DateTime endDate, Budget budget)
        {
            var budgetDate = Convert.ToDateTime(budget.YearMonth);

            if (startDate <= budgetDate && budgetDate.AddMonths(1).AddDays(-1) <= endDate)
            {
                return budget.Amount;
            }

            if (startDate >= budgetDate && budgetDate.Month == startDate.Month)
            {
                var date = endDate.Month == budgetDate.Month
                    ? endDate
                    : budgetDate.AddMonths(1).AddDays(-1);

                return budget.Amount / DaysInMonth(startDate) * BudgetDaysInMonth(startDate, date);
            }

            if (endDate <= budgetDate.AddMonths(1).AddDays(-1) && endDate.Month == budgetDate.Month)
            {
                return budget.Amount / DaysInMonth(endDate) * BudgetDaysInMonth(budgetDate, endDate);
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