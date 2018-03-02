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

            foreach (var budget in budgets)
            {
                var budgetDate = Convert.ToDateTime(budget.YearMonth);

                //不在當月
                if (startDate.Month != budgetDate.Month && endDate.Month != budgetDate.Month)
                {
                    return 0;
                }

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