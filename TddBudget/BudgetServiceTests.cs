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