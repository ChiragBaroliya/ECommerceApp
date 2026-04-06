using System.Collections.Generic;
using System.Linq;
using EcommerceApp.Backend.Models;

namespace EcommerceApp.Backend.Mock
{
    public static class MockUserStore
    {
        // Use ASP.NET Core's PasswordHasher for demonstration
        private static readonly Microsoft.AspNetCore.Identity.PasswordHasher<string> hasher = new();
        public static List<User> Users = new List<User>
        {
            new User { Username = "admin", Password = hasher.HashPassword("admin", "admin123456"), Role = "Admin" },
            new User { Username = "customer", Password = hasher.HashPassword("customer", "cust123456"), Role = "Customer" },
            new User { Username = "vendor", Password = hasher.HashPassword("vendor", "vend123456"), Role = "Vendor" }
        };

        public static User? GetUser(string username, string password)
        {
            var user = Users.FirstOrDefault(u => u.Username == username);
            if (user == null) return null;
            var result = hasher.VerifyHashedPassword(username, user.Password, password);
            return result == Microsoft.AspNetCore.Identity.PasswordVerificationResult.Success ? user : null;
        }

        public static bool UserExists(string username)
        {
            return Users.Any(u => u.Username == username);
        }

        public static void AddUser(User user)
        {
            // Hash password before storing
            user.Password = hasher.HashPassword(user.Username, user.Password);
            Users.Add(user);
        }
    }
}
