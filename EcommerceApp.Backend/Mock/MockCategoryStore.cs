using System.Collections.Generic;
using System.Linq;
using EcommerceApp.Backend.Models;

namespace EcommerceApp.Backend.Mock
{
    public static class MockCategoryStore
    {
        public static List<Category> Categories = new List<Category>();
        public static int NextId => Categories.Count == 0 ? 1 : Categories.Max(c => c.Id) + 1;

        public static Category? GetById(int id) => Categories.FirstOrDefault(c => c.Id == id);
        public static void Add(Category category)
        {
            category.Id = NextId;
            Categories.Add(category);
        }
        public static void Update(Category category)
        {
            var existing = GetById(category.Id);
            if (existing != null)
            {
                existing.Name = category.Name;
                existing.Description = category.Description;
            }
        }
    }
}
