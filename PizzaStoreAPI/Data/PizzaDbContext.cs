using Microsoft.EntityFrameworkCore;
using PizzaStoreApp.Shared.Models; 

namespace PizzaStoreAPI.Data
{
    public class PizzaDbContext : DbContext
    {
        public PizzaDbContext(DbContextOptions<PizzaDbContext> options) : base(options) { }

        public DbSet<Pizza> Pizzas => Set<Pizza>();
        public DbSet<User> Users => Set<User>();  


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity
                .HasIndex(u => u.Username)
                .IsUnique();

                entity
                    .HasMany(u => u.Pizzas)
                    .WithOne(p => p.User)
                    .HasForeignKey(p => p.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Pizza>()
                .Property(p => p.Price)
                .HasPrecision(10, 2); 
                
        }
    }
}
