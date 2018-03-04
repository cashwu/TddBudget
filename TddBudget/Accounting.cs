using System;
using System.Linq;

namespace TddBudget
{
    public class Accounting
    {
        private readonly IRepository<Budgets> repository;

        public Accounting(IRepository<Budgets> repository)
        {
            this.repository = repository;
        }

        public decimal TotalBudgets(DateTime startDate, DateTime endDate)
        {
            var budgets = repository.GetAll();
            if (budgets.Any())
            {
                return 1;
            }

            return 0;
        }
    }
}