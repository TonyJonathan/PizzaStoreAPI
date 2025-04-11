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
    public async Task<IActionResult> Create(Pizza pizza)
    {
        _context.Pizzas.Add(pizza);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza); 
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Pizza pizza)
    {
        if (id != pizza.Id) return BadRequest();

        var exist = await _context.Pizzas.AnyAsync(p => p.Id == id);
        if (!exist) return NotFound();

        _context.Entry(pizza).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return Ok(pizza); 
    }

    [HttpDelete("{id}")]
   public async Task<IActionResult> Delete(int id)
    {
        var pizza = await _context.Pizzas.FindAsync(id);
        if (pizza == null) return NotFound();

        _context.Pizzas.Remove(pizza);
        await _context.SaveChangesAsync();

        return NoContent(); 
    }
}