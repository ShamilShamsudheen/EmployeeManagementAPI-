namespace EmployeManagementAPI.Dto
{
    public class LeaveDto
    {
        public int LeaveID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Reason { get; set; }
    }
}
