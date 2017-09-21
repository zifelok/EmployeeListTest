using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeListTest.DAL.Repositories
{
    public interface IRepository<T, K> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(K id);
    }
}
