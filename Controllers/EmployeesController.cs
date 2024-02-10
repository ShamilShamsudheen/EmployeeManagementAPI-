using EmployeManagementAPI.Data;
using EmployeManagementAPI.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EmployeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        
        private readonly EmployeeData _employee;
        public EmployeesController(EmployeeData employee) 
        {
            _employee = employee;
        }
        [HttpPost("/employee")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeDto employeeDto)
        {
            var empID = User.Claims.FirstOrDefault(c => c.Type == "EMPID")?.Value;
            await Console.Out.WriteLineAsync(empID);

            return Ok(employeeDto);
        }
    }
}
