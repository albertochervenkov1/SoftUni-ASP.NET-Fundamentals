using Microsoft.EntityFrameworkCore;
using ShoppingListApp.Data.Models;

namespace ShoppingListApp.Data
{
    public class ShoppiListDbContext:DbContext
    {
        

        public ShoppiListDbContext
            (DbContextOptions<ShoppiListDbContext> options)
            : base(options)
            => this.Database.EnsureCreated();

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductNote> ProductNotes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            


            builder.Entity<Product>()
                .HasMany(p => p.ProductNotes)
                .WithOne(r => r.Product);
        }

    }
}
