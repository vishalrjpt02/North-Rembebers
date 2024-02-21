using Microsoft.EntityFrameworkCore;
using BankTransections.Models;


namespace BankTransections.Models
{
    public class TransectionDBContext : DbContext
    {
        public TransectionDBContext(DbContextOptions<TransectionDBContext> options) : base(options)
        {
                
        }

        public DbSet<Transection> Trasections { get; set; }

    }
}
