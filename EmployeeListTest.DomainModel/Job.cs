using System.ComponentModel.DataAnnotations;

namespace EmployeeListTest.DomainModel
{
    public class Job
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(32)]
        public string Title { get; set; }
    }
}
