using EmployeeListTest.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace EmployeeListTest.EF
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Job> Jobs { get; set; }
    }
}
