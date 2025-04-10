using PizzaStoreAPI.Models;
using PizzaStoreAPI.Services;
using Microsoft.AspNetCore.Mvc; 

namespace PizzaStockAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class PizzaController : ControllerBase
{
    public PizzaController()
    {

    }

    [HttpGet]
    public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

    [HttpGet("{id}")]

    public ActionResult<Pizza> Get(int id)
    {
        var pizza = PizzaService.Get(id);

        if (pizza == null) return NotFound();

        return pizza; 
    }

    //post action

    //put action

    //delete action
}