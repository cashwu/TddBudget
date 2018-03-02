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
                return 15;
            }

            return 0;
        }
    }
}