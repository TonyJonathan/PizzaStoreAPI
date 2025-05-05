using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaStoreAPI.Data;
using PizzaStoreAPI.Services;
using PizzaStoreApp.Shared.Models;
using System.Security.Cryptography;


namespace PizzaStoreAPI.Controllers;
[ApiController]
[Route("api/[controller]")]


public class UserController : ControllerBase
{
    private readonly PizzaDbContext db;

    public UserController(PizzaDbContext context)
    {
        db = context;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAll()
    {
        return await db.Users.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetById(int id)
    {
        var user = await db.Users.FindAsync(id); 
        if (user == null) 
        {
            return NotFound(); 
        }

        return user; 
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<User>> Create(RegisterUserDto dto)
    {
        if (await db.Users.AnyAsync(u => u.Username == dto.Username))
        {
            return Conflict("Nom d'utilisateur déjà utilisé.");
        }

        if (await db.Users.AnyAsync(u => u.Email == dto.Email))
        {
            return Conflict("Adresse email déjà utilisée.");
        }

        CreatePasswordHash(dto.Password, out byte[] hash, out byte[] salt);

        var user = new User
        {
            Username = dto.Username,
            Email = dto.Email,
            PasswordHash = hash,
            PasswordSalt = salt
        };

        db.Users.Add(user);
        await db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }

    private void CreatePasswordHash(string password, out byte[] hash, out byte[] salt)
    {
        using var hmac = new HMACSHA512();
        salt = hmac.Key;
        hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginDto dto, [FromServices] JwtService jwtService)
    {
        var user = await db.Users.FirstOrDefaultAsync(u => u.Username == dto.Username);

        if (user is null)
        {
            Console.WriteLine("❌ Utilisateur introuvable");
            return Unauthorized("Utilisateur introuvable");
        }

        if (!VerifyPassword(dto.Password, user.PasswordHash, user.PasswordSalt))
        {
            Console.WriteLine("❌ Mot de passe incorrect");
            return Unauthorized("Mot de passe incorrect");
        }

        if (user is null || !VerifyPassword(dto.Password, user.PasswordHash, user.PasswordSalt))
        {
            return Unauthorized("Identifiants invalides");
        }

        var token = jwtService.GenerateToken(user);
        return Ok(new { token });
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, User user)
    {
        if(id != user.Id)
        {
            return BadRequest(); 
        }

        db.Entry(user).State = EntityState.Modified;
        await db.SaveChangesAsync();

        return NoContent(); 
    }

    [HttpDelete("{id}")]

    public async Task<IActionResult> Delete(int id)
    {
        var user = await db.Users.FindAsync(id); 
        if (user == null)
        {
            return NotFound(); 
        }

        db.Users.Remove(user);
        await db.SaveChangesAsync();

        return NoContent(); 
    }

    private bool VerifyPassword(string password, byte[] storedHash, byte[] storedSalt)
    {
        using var hmac = new HMACSHA512(storedSalt);
        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        return computedHash.SequenceEqual(storedHash);
    }
}

