using EmployeeListTest.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using EmployeeListTest.DomainModel;
using System.Linq;

namespace EmployeeListTest.EF.Repositories
{
    public class JobRepository : IJobRepository
    {
        private EmployeeContext context;

        public JobRepository(EmployeeContext context)
        {
            this.context = context;
        }

        public Job Get(int id)
        {
            return context.Jobs.Where(j => j.Id == id).FirstOrDefault();
        }

        public IEnumerable<Job> GetAll()
        {
            return context.Jobs.ToList();
        }
    }
}
