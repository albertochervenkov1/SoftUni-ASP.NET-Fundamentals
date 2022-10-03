using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RazorPizzeria.Models;

namespace RazorPizzeria.Data
{
    public class PizzeriaDbContext:DbContext
    {
        public PizzeriaDbContext(DbContextOptions<PizzeriaDbContext> options)
            :base(options)
        {
            
        }
        public DbSet<PizzaOrder> PizzaOrders { get; set; }

        

    }
}
