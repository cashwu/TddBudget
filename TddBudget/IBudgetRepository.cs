using System.Collections.Generic;

namespace TddBudget
{
    public interface IBudgetRepository
    {
        IEnumerable<Budget> GetAll();
    }
}