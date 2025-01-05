using api.DTOs.Dept;
using api.DTOs.Desig;

namespace api.DTOs.Emp
{
    public class EmployeeInfoDetailedDTO
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; }

        public DepartmentInfoDTO Department { get; set; }

        public DesignationInfoDTO Designation { get; set; }
    }
}
