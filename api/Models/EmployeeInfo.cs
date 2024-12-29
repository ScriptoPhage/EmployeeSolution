namespace api.Models
{
    public class EmployeeInfo
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; }
        public int DepartmentId { get; set; } // Foreign Key
        public int DesignationId { get; set; } // Foreign Key

        // Navigation properties
        public DepartmentInfo Department { get; set; }
        public DesignationInfo Designation { get; set; }
    }
}
