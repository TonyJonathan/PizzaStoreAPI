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
    }
}
