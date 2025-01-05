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

        public static EmployeeInfoDetailedDTO ToEmployeeDetailedDTO(this EmployeeInfo employeeInfoModel)
        {
            return new EmployeeInfoDetailedDTO
            {
                Id = employeeInfoModel.Id,
                Name = employeeInfoModel.Name,
                Department = employeeInfoModel.Department == null ? null : new DTOs.Dept.DepartmentInfoDTO
                {
                    Id = employeeInfoModel.Department.Id,
                    Name = employeeInfoModel.Department.Name
                },
                Designation = employeeInfoModel.Designation == null ? null : new DTOs.Desig.DesignationInfoDTO
                {
                    Id = employeeInfoModel.Designation.Id,
                    Title = employeeInfoModel.Designation.Title
                },

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
