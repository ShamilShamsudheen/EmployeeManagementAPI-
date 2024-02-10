using EmployeManagementAPI.Data;
using EmployeManagementAPI.Dto;
using EmployeManagementAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        
        private readonly EmployeeData _employee;
        public EmployeesController(EmployeeData employeeData) 
        {
            _employee = employeeData;
        }
        [HttpPost("employee")]
        [Authorize(Roles = "admin,manager")]
        public async Task<IActionResult> AddEmployee(EmployeeDto employeeDto)
        {
            var empID = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "EMPID")?.Value);
            var newEmployee = new Employee
            {
                Designation = employeeDto.Designation,
                Role = employeeDto.Role,
                EmployeeID = employeeDto.EmployeeID,
                ReportOwnerID = empID,
            };
            var addedEmployeeData = _employee.AddEmployee(newEmployee);

            return Ok(addedEmployeeData);
        }
        [HttpPost("{employeeId}/Leave")]
        [Authorize(Roles ="employee")]
        public async Task<IActionResult> ApplyLeave( int employeeId ,LeaveDto leaveDto)
        {
            var checkEmployee = _employee.GetEmpByIDAddLeaveId(employeeId,leaveDto.LeaveID);

            if (checkEmployee != null)
            {

                var newLeave = new Leave
                {
                    EmployeeID = checkEmployee.EmployeeID,
                    EndDate = leaveDto.EndDate,
                    LeaveID = leaveDto.LeaveID,
                    Reason = leaveDto.Reason,
                    StartDate = leaveDto.StartDate,
                    ReportOwnerID= checkEmployee.ReportOwnerID,
                };
                var appliedLeave = _employee.AppyLeave(newLeave);
                return Ok(checkEmployee);

            }
            else
            {
                return NotFound("NOT FOUND THE EMPLOYEEID");
            }
        }
        [HttpGet("{employeeId}/Leaves")]
        [Authorize(Roles ="employee")]
        public async Task<IActionResult> GetAllLeaves(int employeeId)
        {
           var Leaves =  _employee.GetEmployeeLeaves(employeeId);
            if(Leaves != null)
            {
                return Ok(Leaves);
            }
            else
            {
                return Ok("There is no leave take");
            }
        }
        [HttpPut("{employeeId}/Leaves")]
        [Authorize(Roles ="admin,manager")]
        public async Task<IActionResult> RequstedLeaves(int employeeId)
        {
            var requestLeaves = _employee.GetAllLeaves(employeeId);
            return Ok(requestLeaves);
        }
    }
}
