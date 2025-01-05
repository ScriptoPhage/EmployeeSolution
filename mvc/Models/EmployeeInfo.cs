using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace mvc.Models
{
    public class EmployeeInfo
    {
        public int Id { get; set; } // Primary Key
        [Required]
        [DisplayName("Employee Name")]
        public string Name { get; set; }
        [DisplayName("Department")]
        public DepartmentInfo Department { get; set; }
        [DisplayName("Designation")]
        public DesignationInfo Designation { get; set; }
    }
}
