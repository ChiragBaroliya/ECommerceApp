using System.Collections.Generic;
using System.Linq;
using EcommerceApp.Backend.Models;

namespace EcommerceApp.Backend.Mock
{
    public static class MockProductStore
    {
        public static List<Product> Products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Description = "High-performance laptop", Price = 1200.00m, Stock = 10, CategoryId = 1 },
            new Product { Id = 2, Name = "Smartphone", Description = "Latest smartphone", Price = 800.00m, Stock = 20, CategoryId = 1 },
            new Product { Id = 3, Name = "Headphones", Description = "Noise-canceling headphones", Price = 150.00m, Stock = 50, CategoryId = 2 }
        };
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
                existing.CategoryId = product.CategoryId;
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
