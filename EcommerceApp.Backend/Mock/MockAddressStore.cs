using System.Collections.Generic;
using System.Linq;
using EcommerceApp.Backend.Models;

namespace EcommerceApp.Backend.Mock
{
    public static class MockAddressStore
    {
        public static List<Address> Addresses = new List<Address>
        {
            new Address { Id = 1, UserName = "admin", Street = "123 Main St", City = "CityA", State = "StateA", Zip = "11111", Country = "CountryA" },
            new Address { Id = 2, UserName = "customer", Street = "456 Elm St", City = "CityB", State = "StateB", Zip = "22222", Country = "CountryB" }
        };

        public static int NextId => Addresses.Count == 0 ? 1 : Addresses.Max(a => a.Id) + 1;
    }
}