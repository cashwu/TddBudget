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

        [TestMethod]
        public void BudgetInOneMonth()
        {
            GivenBudgetRepo(new List<Budget>
            {
                new Budget{ YearOfMonth = "2018/02", Amount = 28}
            });

            BudgetShouldBe(5, new DateTime(2018, 02, 01), new DateTime(2018, 02, 05));
        }

        [TestMethod]
        public void 只有一個月有預算_查詢兩個月_只有後面一個月有交集()
        {
            GivenBudgetRepo(new List<Budget>
            {
                new Budget{ YearOfMonth = "2018/02", Amount = 28}
            });

            BudgetShouldBe(10, new DateTime(2018, 01, 15), new DateTime(2018, 02, 10));
        }

        [TestMethod]
        public void 只有一個月有預算_查詢兩個月_只有前面一個月有交集()
        {
            GivenBudgetRepo(new List<Budget>
            {
                new Budget{ YearOfMonth = "2018/02", Amount = 28}
            });

            BudgetShouldBe(14, new DateTime(2018, 02, 15), new DateTime(2018, 03, 10));
        }

        [TestMethod]
        public void 只有一個月有預算_查詢三個月_只有中間一個月有交集()
        {
            GivenBudgetRepo(new List<Budget>
            {
                new Budget{ YearOfMonth = "2018/02", Amount = 28}
            });

            BudgetShouldBe(28, new DateTime(2018, 01, 15), new DateTime(2018, 03, 10));
        }

        [TestMethod]
        public void 有三個月有預算_查詢三個月()
        {
            GivenBudgetRepo(new List<Budget>
            {
                new Budget{ YearOfMonth = "2018/01", Amount = 31},
                new Budget{ YearOfMonth = "2018/02", Amount = 28},
                new Budget{ YearOfMonth = "2018/03", Amount = 31}
            });

            BudgetShouldBe(55, new DateTime(2018, 01, 15), new DateTime(2018, 03, 10));
        }

        [TestMethod]
        public void 有三個月有預算_查詢三個月_修改金額()
        {
            GivenBudgetRepo(new List<Budget>
            {
                new Budget{ YearOfMonth = "2018/01", Amount = 310},
                new Budget{ YearOfMonth = "2018/02", Amount = 28},
                new Budget{ YearOfMonth = "2018/03", Amount = 31}
            });

            BudgetShouldBe(208, new DateTime(2018, 01, 15), new DateTime(2018, 03, 10));
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