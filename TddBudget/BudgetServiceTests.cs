using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;

namespace TddBudget
{
    [TestClass]
    public class BudgetServiceTests
    {
        private IBudgetRepository budgetRepo = Substitute.For<IBudgetRepository>();
        private BudgetService budgetService;

        public BudgetServiceTests()
        {
            budgetService = new BudgetService(budgetRepo);
        }

        [TestMethod]
        public void NoBudget()
        {
            GivenBudgetRepo(new List<Budget>());

            BudgetShouldBe(0, new DateTime(2018, 02, 01), new DateTime(2018, 02, 05));
        }

        private void GivenBudgetRepo(List<Budget> budgets)
        {
            budgetRepo.GetAll().Returns(budgets);
        }

        private void BudgetShouldBe(decimal expected, DateTime startDate, DateTime dateTime)
        {
            var budget = budgetService.GetBudget(startDate, dateTime);
            Assert.AreEqual(expected, budget);
        }
    }
}