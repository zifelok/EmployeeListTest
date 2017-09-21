using EmployeeListTest.DomainModel;

namespace EmployeeListTest.DAL.Repositories
{
    public interface IEmployeeRepository: IRepository<Employee, int>
    {
        void Delete(int id);
        void Add(Employee employee);
    }
}