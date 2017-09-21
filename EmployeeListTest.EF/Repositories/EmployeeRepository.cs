using System;
using System.Collections.Generic;
using System.Text;
using EmployeeListTest.DomainModel;
using EmployeeListTest.DAL.Repositories;
using System.Linq;

namespace EmployeeListTest.EF.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmployeeContext context;

        public EmployeeRepository(EmployeeContext context)
        {
            this.context = context;
        }

        public void Add(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Employee employee = Get(id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
        }

        public Employee Get(int id)
        {
            return context.Employees.Where(e => e.Id == id).FirstOrDefault();
        }

        public IEnumerable<Employee> GetAll()
        {
            return context.Employees.ToList();
        }
    }
}
