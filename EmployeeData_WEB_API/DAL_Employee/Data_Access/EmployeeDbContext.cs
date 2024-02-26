﻿using DAL_Employee.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Employee.Data_Access
{
    public class EmployeeDbContext : DbContext 
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options  ) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

    }
}
