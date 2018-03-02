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
                var budget = budgets.FirstOrDefault(b => b.YearMonth == startDate.ToString("yyyyMM"));

                return budget.Amount / DateTime.DaysInMonth(startDate.Year, startDate.Month) * ((endDate - startDate).Days + 1);
            }

            return 0;
        }
    }
}