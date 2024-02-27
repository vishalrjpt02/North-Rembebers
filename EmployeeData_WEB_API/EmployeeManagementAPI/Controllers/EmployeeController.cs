using BAL_Employee.Business_Layer;
using DAL_Employee.Interface;
using DAL_Employee.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeesBAL _employeeBal;
        private readonly IEmpRepository<Employee> _employeeDal;

        public EmployeeController(EmployeesBAL employeesBAL, IEmpRepository<Employee> empRepository)
        {
            _employeeBal = employeesBAL;
            _employeeDal = empRepository;
        }

        //Add Employee
        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee _employee)
        {
            try
            {
                Employee _employees = await _employeeBal.AddEmployee(_employee);
                if (_employee != null)
                    return _employees;
                else
                    return BadRequest();

            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server Error");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            try
            {
                if (id != 0)
                {

                    Employee _emp = _employeeBal.GetEmployeeById(id);
                    if (_emp != null)
                    {
                        return _emp;
                    }
                    return NotFound();
                }
                return BadRequest();               
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server Error \n "+ex.Message );
            }
        }

        //GET All Employees
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            try
            {
                IEnumerable<Employee> _employees = await _employeeDal.Employees();
                if(_employees != null)
                {
                    return _employees.ToList();                       
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server Error");

            }
        }
        //Delete Employee  
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteEmployee(int id)
        {
            try
            {
                if (id != 0)
                {
                    int count = await _employeeBal.DeleteEmployee(id);
                    if(count != 0)
                    {
                        return count;
                    }
                    return NotFound();
                }
                return BadRequest();
               
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server Error");
            }
        }
        //Update Employee
        [HttpPut()]
        public ActionResult<int> UpdateEmployee(Employee employee)
        {
            try
            {
                if(employee != null)
                {
                    int count = _employeeBal.UpdateEmployee(employee);
                    if(count != 0)
                    {
                        return count;
                    }
                    return NotFound();
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server Error");
            }
        }



       


    }
}
