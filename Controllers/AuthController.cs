using EmployeManagementAPI.Data;
using EmployeManagementAPI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EmployeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly EmployeeData _employeeData;
        public AuthController(EmployeeData employeeData)
        {
            _employeeData = employeeData;
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login(int username, string password)
        {
            var checkEmployee = _employeeData.GetEmpByID(username,password);
            if(checkEmployee != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role,checkEmployee.Role),
                    new Claim("EMPID",checkEmployee.EmployeeID.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims,CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity)
                    );
                return Ok(checkEmployee);
            }
            else
            {
                return NotFound("NOT FOUND");
            }
            
        }
        
        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
        CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok("Logout Successfully!");
        }
    }
}
