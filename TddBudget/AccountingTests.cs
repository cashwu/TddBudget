using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Linq;

namespace TddBudget
{
    [TestClass]
    public class AccountingTests
    {
        private IRepository<Budgets> repository = Substitute.For<IRepository<Budgets>>();
        private Accounting accounting;

        [TestInitialize]
        public void Init()
        {
            accounting = new Accounting(repository);
        }

        [TestMethod]
        public void no_budgets()
        {
            GivenBudgets();
            Init();

            TotalBudgetsShouldBe(0, new DateTime(2018, 04, 01), new DateTime(2018, 4, 1));
        }

        [TestMethod]
        public void one_effective_day_period_inside_budgets_month()
        {
            GivenBudgets(
                new Budgets { YearOfMonth = "201804", Amount = 30 }
            );

            Init();

            TotalBudgetsShouldBe(1, new DateTime(2018, 04, 01), new DateTime(2018, 4, 1));
        }

        private void GivenBudgets(params Budgets[] budgets)
        {
            repository.GetAll().Returns(budgets.ToList());
        }

        private void TotalBudgetsShouldBe(int expected, DateTime startDate, DateTime endDate)
        {
            Assert.AreEqual(expected, accounting.TotalBudgets(startDate, endDate));
        }
    }
}