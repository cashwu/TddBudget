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
            var period = new Period(startDate, endDate);
            if (budgets.Any())
            {
                var budget = budgets[0];

                return period.EffectiveDate(budget);
            }

            return 0;
        }
    }
}