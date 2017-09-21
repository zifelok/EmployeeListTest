using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeListTest.DomainModel
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(32)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(32)]
        public string LastName { get; set; }
        public DateTime EmploymentDate { get; set; }
        public decimal Rate { get; set; }
        public int JobId { get; set; }
        public virtual Job Job { get; set; }
    }
}
