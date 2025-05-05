using System.ComponentModel.DataAnnotations;

namespace PizzaStoreApp.Shared.Models;

public class RegisterUserDto
{
    [Required]
    public string Username { get; set; } = string.Empty;

    [Required]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]{2,4}$", ErrorMessage = "Email invalide")]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}


