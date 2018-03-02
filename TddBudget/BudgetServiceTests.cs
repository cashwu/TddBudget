using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;

namespace TddBudget
{
    [TestClass]
    public class BudgetServiceTests
    {
        private IBudgetRepository budgetRepository = Substitute.For<IBudgetRepository>();
        private BudgetService budgetService;

        public BudgetServiceTests()
        {
            budgetService = new BudgetService(budgetRepository);
        }

        [TestMethod]
        public void NoBudgets()
        {
            GivenBudget(new List<Budget>());

            BudgetsShouldBe(0, new DateTime(2018, 4, 1), new DateTime(2018, 4, 5));
        }

        [TestMethod]
        public void BudgetInSameMonth()
        {
            GivenBudget(new List<Budget>
            {
                new Budget { YearMonth = "201802", Amount = 28}
            });

            BudgetsShouldBe(15, new DateTime(2018, 2, 1), new DateTime(2018, 2, 15));
        }

        [TestMethod]
        public void 跨有預算的月份()
        {
            GivenBudget(new List<Budget>
            {
                new Budget { YearMonth = "201802", Amount = 28},
                new Budget { YearMonth = "201803", Amount = 310}
            });

            BudgetsShouldBe(63, new DateTime(2018, 2, 15), new DateTime(2018, 3, 5));
        }

        private void BudgetsShouldBe(decimal expected, DateTime startDate, DateTime endDate)
        {
            Assert.AreEqual(expected, budgetService.CalBudgets(startDate, endDate));
        }

        private void GivenBudget(List<Budget> budgets)
        {
            budgetRepository.GetAll().Returns(budgets);
        }
    }
}