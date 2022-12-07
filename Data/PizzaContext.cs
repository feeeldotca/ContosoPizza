using Microsoft.EntityFrameworkCore;
using ContosoPizza.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoPizza.Data;

public class PizzaContext : DbContext
{
    public PizzaContext(DbContextOptions<PizzaContext> options) : base(options) {}
//The DbSet<T> properties correspond to tables to be created in the database.
    public DbSet<Pizza> Pizzas => Set<Pizza>();
    public DbSet<Topping> Toppings => Set<Topping>();
    public DbSet<Sauce> Sauces => Set<Sauce>();
}
