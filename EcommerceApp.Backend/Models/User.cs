namespace EcommerceApp.Backend.Models
{
    public class User
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty; // Admin, Customer, Vendor
    }

    public class Role
    {
        public string Name { get; set; } = string.Empty;
    }
}