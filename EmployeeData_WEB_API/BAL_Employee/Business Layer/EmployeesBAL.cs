using DAL_Employee.Interface;
using DAL_Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_Employee.Business_Layer
{
    public class EmployeesBAL
    {
        private readonly IEmpRepository<Employee> _dalEmployee;

        public EmployeesBAL(IEmpRepository<Employee> _employee)
        {
            _dalEmployee = _employee;

        }

        public Employee GetEmployeeById(int id)
        {
            return _dalEmployee.GetEmployeeById(id);
        }
        public Task<IEnumerable<Employee>> Employees()
        {
            return _dalEmployee.Employees();
        }
        public Task<Employee> AddEmployee(Employee _employee)
        {
            return _dalEmployee.AddEmployee(_employee);
        }
        public int UpdateEmployee(Employee employee)
        {
            return _dalEmployee.UpdateEmployee(employee);
        }
        public Task<int> DeleteEmployee(int id)
        {
            return (_dalEmployee.DeleteEmployee(id));
        }
    }
}
