using api.Models;

namespace api.DTOs.Emp
{
    public class EmployeeInfoDTO
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; }
        
        public string DeptName { get; set; }

        public string DesigName { get; set; }
    }
}
