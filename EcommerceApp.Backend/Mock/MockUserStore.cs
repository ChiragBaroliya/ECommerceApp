using System.Collections.Generic;
using System.Linq;
using EcommerceApp.Backend.Models;

namespace EcommerceApp.Backend.Mock
{
    public static class MockUserStore
    {
        public static List<User> Users = new List<User>
        {
            new User { Username = "admin", Password = "admin123", Role = "Admin" },
            new User { Username = "customer", Password = "cust123", Role = "Customer" },
            new User { Username = "vendor", Password = "vend123", Role = "Vendor" }
        };

        public static User? GetUser(string username, string password)
        {
            return Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public static bool UserExists(string username)
        {
            return Users.Any(u => u.Username == username);
        }

        public static void AddUser(User user)
        {
            Users.Add(user);
        }
    }
}
