namespace api.DTOs.Emp
{
    public class UpdateEmployeeDTO
    {
        public string Name { get; set; }
        public int? DepartmentId { get; set; } // Foreign Key
        public int? DesignationId { get; set; } // Foreign Key
    }
}
