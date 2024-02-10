namespace EmployeManagementAPI.Dto
{
    public class LeaveDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Reason { get; set; }
    }
}
