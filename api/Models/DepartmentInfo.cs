namespace api.Models
{
    public class DepartmentInfo
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; }

        // Navigation property for related employees
        public List<EmployeeInfo> Employees { get; set; } = new List<EmployeeInfo>();
    }
}
 