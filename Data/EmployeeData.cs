using EmployeManagementAPI.Models;

namespace EmployeManagementAPI.Data
{
    public class EmployeeData
    {
        private List<Employee> _employees;
        public EmployeeData()
        {
            _employees = new List<Employee>();
            _employees.Add(new Employee
            {
                EmployeeID = 001,
                Designation = "Super Admin",
                Role = "Admin"   
            });
        }
        //function to add employee

        public List<Employee> AddEmployee(Employee employee)
        {

            _employees.Add()
            return _employees;
        }
        public Employee GetEmpByID(int empID ,string designation) 
        {
            return _employees.Where((e) => e.EmployeeID == empID && e.Designation == designation).ToList().FirstOrDefault();
        }

    }
}
