using DAL_Employee.Data_Access;
using DAL_Employee.Interface;
using DAL_Employee.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Employee.Repository
{
    public class EmployeeRepository : IEmpRepository<Employee>
    {
        EmployeeDbContext _dbContext;
        public EmployeeRepository(EmployeeDbContext dbContext)
        {
                _dbContext = dbContext;
        }

        public async Task<Employee> AddEmployee(Employee _employee)
        {
            var obj = await _dbContext.Employees.AddAsync(_employee);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public async Task<int> DeleteEmployee(int id)
        {
            var _employee = await _dbContext.Employees.FindAsync(id);
            if (_employee != null)
            {
                _dbContext.Remove(_employee);
                return _dbContext.SaveChanges();
            }  
            return 0;
        }

        public async Task<IEnumerable<Employee>> Employees()
        {
            try
            {
                IEnumerable<Employee> _allEmployees = await _dbContext.Employees.ToListAsync();
                return _allEmployees;
            }
            catch (Exception )
            {
                throw ;
            }
            
        }

        public Employee GetEmployeeById(int id)
        {
            try
            {
                Employee _emp = _dbContext.Employees.Find(id);
                if( _emp != null )
                {
                    return _emp;
                }
                return null;
            }
            catch (Exception )
            {
                throw ;
            }
        }

        //public Employee GetEmployeeById(string id)
        //{
        //    throw new NotImplementedException();
        //}

        public int UpdateEmployee(Employee _employee)
        {
            try
            { 
            
                _dbContext.Employees.Update(_employee);
                return _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
