using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;

namespace TddBudget
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void NoBudgets()
        {
            IBudgetRepository budgetRepository = Substitute.For<IBudgetRepository>();
            budgetRepository.GetAll().Returns(new List<Budget>());
            var budgetService = new BudgetService(budgetRepository);

            Assert.AreEqual(0, budgetService.CalBudgets(new DateTime(2018, 4, 1), new DateTime(2018, 4, 5)));
        }
    }
}