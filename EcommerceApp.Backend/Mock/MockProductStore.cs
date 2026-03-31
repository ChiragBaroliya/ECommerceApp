using System.Collections.Generic;
using System.Linq;
using EcommerceApp.Backend.Models;

namespace EcommerceApp.Backend.Mock
{
    public static class MockProductStore
    {
        public static List<Product> Products = new List<Product>();
        public static int NextId => Products.Count == 0 ? 1 : Products.Max(p => p.Id) + 1;

        public static Product? GetById(int id) => Products.FirstOrDefault(p => p.Id == id);
        public static void Add(Product product)
        {
            product.Id = NextId;
            Products.Add(product);
        }
        public static void Update(Product product)
        {
            var existing = GetById(product.Id);
            if (existing != null)
            {
                existing.Name = product.Name;
                existing.Description = product.Description;
                existing.Price = product.Price;
                existing.Stock = product.Stock;
                if (!string.IsNullOrEmpty(product.ImagePath))
                {
                    existing.ImagePath = product.ImagePath;
                }
            }
        }
        public static void Delete(int id)
        {
            var product = GetById(id);
            if (product != null) Products.Remove(product);
        }
    }
}
