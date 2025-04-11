using Microsoft.AspNetCore.Mvc;
using PizzaStoreAPI.Models;
using PizzaStoreAPI.Data; 
using Microsoft.EntityFrameworkCore;

namespace PizzaStoreAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class PizzaController : ControllerBase
{
    private readonly PizzaDbContext _context; 
    public PizzaController(PizzaDbContext context)
    {
        _context = context; 
    }

    [HttpGet]
    public async Task<ActionResult<List<Pizza>>> GetAll()
    {
        var pizzas = await _context.Pizzas.ToListAsync(); 

        if (pizzas == null || pizzas.Count == 0)
        {
            return NotFound("Aucune pizza trouvée"); 
        }

        return pizzas; 

    }


    [HttpGet("{id}")]

    public async Task<ActionResult<Pizza>> Get(int id)
    {
        var pizza = await _context.Pizzas.FindAsync(id);

        if (pizza == null) return NotFound();

        return pizza; 
    }

    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {
        PizzaService.Add(pizza);
        return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza); 
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        if (id != pizza.Id) return BadRequest();

        var existingPizza = PizzaService.Get(id); 
        if(existingPizza is null) return NotFound();

        PizzaService.Update(pizza);
        return NoContent(); 
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pizza = PizzaService.Get(id);

        if (pizza is null)
            return NotFound();

        PizzaService.Delete(id);

        return NoContent();
    }
}