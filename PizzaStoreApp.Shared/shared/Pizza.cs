using Microsoft.EntityFrameworkCore;
using PizzaStoreApp.Shared.shared;


namespace PizzaStoreApp.Shared.Models;

[Index(nameof(Name), IsUnique = true)]
public class Pizza
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal? Price { get; set; }
    public bool IsGlutenFree { get; set; }

    public int UserId { get; set; } 
    public User? User { get; set; }
}