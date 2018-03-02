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
            return 0;
        }
    }
}