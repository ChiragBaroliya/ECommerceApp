namespace EcommerceApp.Backend.Models
{
using System.ComponentModel.DataAnnotations;
public class Address
{
    public int Id { get; set; }

    [Required]
    [StringLength(32)]
    public string UserName { get; set; } = string.Empty;

    [Required]
    [StringLength(128)]
    public string Street { get; set; } = string.Empty;

    [Required]
    [StringLength(64)]
    public string City { get; set; } = string.Empty;

    [Required]
    [StringLength(64)]
    public string State { get; set; } = string.Empty;

    [Required]
    [StringLength(16)]
    public string Zip { get; set; } = string.Empty;

    [Required]
    [StringLength(64)]
    public string Country { get; set; } = string.Empty;
}
}