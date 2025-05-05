using System.ComponentModel.DataAnnotations;

namespace PizzaStoreApp.Shared.Models;

public class RegisterUserDto
{
    [Required(ErrorMessage = "Le nom d'utilisateur est requis.")]
    [RegularExpression("^[a-zA-Z0-9_-]+$", ErrorMessage = "Le nom d'utilisateur ne doit contenir que des lettres, chiffres, tirets ou underscores.")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "L'adresse email est requise.")]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]{2,4}$", ErrorMessage = "Format d'email invalide.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Le mot de passe est requis.")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
        ErrorMessage = "Le mot de passe doit contenir au moins 8 caractères, une majuscule, une minuscule, un chiffre et un caractère spécial.")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "La confirmation du mot de passe est requise.")]
    [Compare("Password", ErrorMessage = "Les mots de passe ne correspondent pas.")]
    public string ConfirmPassword { get; set; } = string.Empty;
}

