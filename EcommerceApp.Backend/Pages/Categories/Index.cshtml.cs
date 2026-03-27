using Microsoft.AspNetCore.Mvc.RazorPages;
using EcommerceApp.Backend.Models;
using EcommerceApp.Backend.Mock;
using System.Collections.Generic;

namespace EcommerceApp.Backend.Pages.Categories
{
    public class IndexModel : PageModel
    {
        public List<Category> Categories { get; set; } = new();
        public void OnGet()
        {
            Categories = MockCategoryStore.Categories;
        }
    }
}
