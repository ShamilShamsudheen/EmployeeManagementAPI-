using EmployeManagementAPI.Dto;
using EmployeManagementAPI.Models;

namespace EmployeManagementAPI.Data
{
    public class EmployeeData
    {
        private List<Employee> _employees;
        private List<Leave> _leaves;
        public EmployeeData()
        {
            _leaves = new List<Leave>();
            _employees = new List<Employee>();
            _employees.AddRange(new[]
{
    new Employee { EmployeeID = 1, Designation = "super admin", Role = "admin" },
    new Employee { EmployeeID = 2, Designation = "manager", Role = "manager", ReportOwnerID = 1 },
    new Employee { EmployeeID = 3, Designation = "employee", Role = "employee", ReportOwnerID = 2 }
});
        }
        //function to add employee

        public Employee AddEmployee(Employee employee)
        {
            _employees.Add(employee);
            return _employees.FirstOrDefault((e) => e.EmployeeID == employee.EmployeeID);
        }
        // function to get employee by employeeid
        public Employee GetEmpByID(int empID ,string designation ) 
        {
            return _employees.FirstOrDefault((e) => e.EmployeeID == empID && e.Designation == designation);
        }
        public Leave AppyLeave(Leave leave)
        {
            _leaves.Add(leave);
            return _leaves.FirstOrDefault((l) => l.LeaveID == leave.LeaveID);
        }
        public Employee GetEmpByIDAddLeaveId(int leaveId,int employeeId)
        {
            var findEmployee = _employees.FirstOrDefault((e) => e.EmployeeID == employeeId);
            findEmployee.LeaveReqID = leaveId;
            return findEmployee;

        }
        public Leave GetEmployeeLeaves(int empId) 
        {
            var findEmployee = _employees.FirstOrDefault((e)=>e.EmployeeID == empId);
            var EmployeeLeaveDetails = _leaves.Find((l)=> l.LeaveID == findEmployee.LeaveReqID);
            return EmployeeLeaveDetails;
        }
        public Leave GetAllLeaves(int empId)
        {
            return _leaves.Find((l) => l.ReportOwnerID == empId); 
        }

    }
}
