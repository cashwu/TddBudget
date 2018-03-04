using System;
using System.Linq;

namespace TddBudget
{
    public class Period
    {
        public Period(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
    }

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
                return EffectiveDays(new Period(startDate, endDate));
            }

            return 0;
        }

        private static decimal EffectiveDays(Period period)
        {
            return (period.EndDate - period.StartDate).Days + 1;
        }
    }
}