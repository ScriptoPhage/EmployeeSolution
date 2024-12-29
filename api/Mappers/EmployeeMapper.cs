using api.DTOs.Emp;
using api.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace api.Mappers
{
    public static class EmployeeMapper
    {
        //These are extension methods. So when calling, it's the parameters of these methods, that call these methods
        //like employeeInfo.ToEmployeeDTO()
        public static EmployeeInfoDTO ToEmployeeDTO(this EmployeeInfo employeeInfoModel)
        {
            return new EmployeeInfoDTO
            {
                Id = employeeInfoModel.Id,
                Name = employeeInfoModel.Name,
                DeptName = employeeInfoModel.Department?.Name ?? "Unknown",
                DesigName = employeeInfoModel.Designation?.Title ?? "Unknown"
            };
        }

        public static EmployeeInfo ToEmployeeInfoFromCreateDTO(this CreateEmployeeDTO employeeDTO)
        {
            return new EmployeeInfo
            {
                Name = employeeDTO.Name,
                DepartmentId = employeeDTO.DepartmentId,
                DesignationId = employeeDTO.DesignationId
            };
        }

    }
}
