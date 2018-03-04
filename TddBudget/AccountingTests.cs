using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
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

            TotalBudgetsShouldBe(0);
        }

        private void GivenBudgets(params Budgets[] budgets)
        {
            repository.GetAll().Returns(budgets.ToList());
        }

        private void TotalBudgetsShouldBe(int expected)
        {
            Assert.AreEqual(expected, accounting.TotalBudgets());
        }
    }
}