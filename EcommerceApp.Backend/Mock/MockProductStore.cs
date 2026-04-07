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

        static MockProductStore()
        {
            // Seed dummy products
            Products.AddRange(new[]
            {
                new Product { Id = 1, Name = "Smartphone", Description = "Latest Android smartphone", Price = 699.99m, Stock = 50, CategoryId = 1, ImagePath = "images/products/smartphone.jpg", Reviews = new List<ProductReview> { new ProductReview { Id = 1, UserName = "Alice", Rating = 5, Comment = "Amazing phone!", CreatedAt = DateTime.Now.AddDays(-10) }, new ProductReview { Id = 2, UserName = "Bob", Rating = 4, Comment = "Good value.", CreatedAt = DateTime.Now.AddDays(-5) } } },
                new Product { Id = 2, Name = "Laptop", Description = "High performance laptop", Price = 1299.99m, Stock = 20, CategoryId = 1, ImagePath = "images/products/laptop.jpg", Reviews = new List<ProductReview> { new ProductReview { Id = 3, UserName = "Charlie", Rating = 5, Comment = "Blazing fast!", CreatedAt = DateTime.Now.AddDays(-2) } } },
                new Product { Id = 3, Name = "Novel Book", Description = "Bestselling fiction novel", Price = 19.99m, Stock = 100, CategoryId = 2, ImagePath = "images/products/book.jpg" },
                new Product { Id = 4, Name = "T-Shirt", Description = "100% cotton t-shirt", Price = 9.99m, Stock = 200, CategoryId = 3, ImagePath = "images/products/tshirt.jpg" },
                new Product { Id = 5, Name = "Blender", Description = "Kitchen blender with 2L jar", Price = 49.99m, Stock = 30, CategoryId = 4, ImagePath = "images/products/blender.jpg" }
            });
        }

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
