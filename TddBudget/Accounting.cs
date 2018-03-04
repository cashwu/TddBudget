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
            var period = new Period(startDate, endDate);
            return repository.GetAll().Sum(a => a.TotalBudgets(period));
        }
    }
}