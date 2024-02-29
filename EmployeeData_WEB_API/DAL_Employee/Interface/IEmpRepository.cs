using DAL_Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Employee.Interface
{
    public interface IEmpRepository<T>
    {
        public Employee GetEmployeeById(int id);
        //public Employee GetEmployeeById(string id);
        public Task<IEnumerable<Employee>> Employees();
        public Task<Employee> AddEmployee(Employee _employee);
        public int UpdateEmployee(Employee employee);
        public Task<int> DeleteEmployee(int id);


    }
}
