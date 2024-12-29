namespace api.Models
{
    public class DesignationInfo
    {
        public int Id { get; set; } // Primary Key
        public string Title { get; set; }

        // Navigation property for related employees
        public List<EmployeeInfo> Employees { get; set; } = new List<EmployeeInfo>();
    }
}
