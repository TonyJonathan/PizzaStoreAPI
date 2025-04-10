using Microsoft.AspNetCore.Mvc;

namespace PizzaStockAPI.Controllers;

[ApiController]
[Route("api/pizzas")]
public class PizzaController : ControllerBase
{
    private static readonly List<string> Pizzas = new()
    {
        "Margherita", "Pepperoni", "Reine", "Végétarienne", "4 Fromages"
    };

    [HttpGet]
    public IEnumerable<string> GetAll()
    {
        return Pizzas;
    }
}

