namespace EcommerceApp.Backend.Models
{
using System.ComponentModel.DataAnnotations;
public class User
{
    [Required]
    [StringLength(32, MinimumLength = 3)]
    public string Username { get; set; } = string.Empty;

    [Required]
    [StringLength(32, MinimumLength = 10, ErrorMessage = "Password must be at least 10 characters.")]
    // TODO: Consider using a more complex password policy (uppercase, numbers, symbols, etc.)
    public string Password { get; set; } = string.Empty;

    [Required]
    public string Role { get; set; } = string.Empty; // Admin, Customer, Vendor

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [StringLength(64)]
    public string FullName { get; set; } = string.Empty;
}

    public class Role
    {
        public string Name { get; set; } = string.Empty;
    }
}