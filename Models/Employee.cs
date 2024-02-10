namespace EmployeManagementAPI.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string? Role {  get; set; }
        public string? Designation { get; set; }
        public int ReportOwnerID { get; set; }
        public int LeaveReqID { get; set; }
    }
}
