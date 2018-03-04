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

        public decimal EffectiveDays()
        {
            return (EndDate - StartDate).Days + 1;
        }
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
                var period = new Period(startDate, endDate);
                var budget = budgets[0];
                if (period.EndDate < budget.FirstDay)
                {
                    return 0;
                }

                return period.EffectiveDays();
            }

            return 0;
        }
    }
}