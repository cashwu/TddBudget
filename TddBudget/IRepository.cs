using System.Collections.Generic;

namespace TddBudget
{
    public interface IRepository<T>
    {
        List<T> GetAll();
    }
}