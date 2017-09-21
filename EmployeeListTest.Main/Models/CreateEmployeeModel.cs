using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeListTest.Main.Models
{
    public class CreateEmployeeModel
    {
        [Required]
        [MaxLength(32)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(32)]
        public string LastName { get; set; }
        public DateTime EmploymentDate { get; set; }
        public decimal Rate { get; set; }
        public int JobId { get; set; }
    }
}
