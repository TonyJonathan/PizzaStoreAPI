using Microsoft.EntityFrameworkCore;
using PizzaStoreAPI.Models;

namespace PizzaStoreAPI.Data
{
    public class PizzaDbContext : DbContext
    {
        public PizzaDbContext(DbContextOptions<PizzaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pizza> Pizzas => Set<Pizza>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>()
                .Property(p => p.Price)
                .HasPrecision(10, 2);
        }
    }
}
