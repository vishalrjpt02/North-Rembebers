using CCD_EnitityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCD_DataAccessLayer.CCD_DbContext
{
    public class CCD_InvoiceContext : DbContext
    {
        public CCD_InvoiceContext(DbContextOptions<CCD_InvoiceContext> option) :base(option)
        {
            
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
