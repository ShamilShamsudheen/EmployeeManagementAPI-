﻿namespace EmployeManagementAPI.Models
{
    public class Leave
    {
        public int LeaveID { get; set; }
        public int EmployeeID { get; set; }
        public int ReportOwnerID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Reason { get; set; }
        public bool? IsApproved { get; set; }
    }
}
