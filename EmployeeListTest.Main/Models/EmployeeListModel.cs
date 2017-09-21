using System;

namespace EmployeeListTest.Main.Models
{
    public class EmployeeListModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EmploymentDate { get; set; }
        public decimal Rate { get; set; }
        public int JobId { get; set; }
    }
}
