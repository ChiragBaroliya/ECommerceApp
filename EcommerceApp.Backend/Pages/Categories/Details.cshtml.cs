using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EcommerceApp.Backend.Models;
using EcommerceApp.Backend.Mock;

namespace EcommerceApp.Backend.Pages.Categories
{
    public class DetailsModel : PageModel
    {
        public Category Category { get; set; } = new Category();
        public IActionResult OnGet(int id)
        {
            var category = MockCategoryStore.GetById(id);
            if (category == null) return RedirectToPage("Index");
            Category = category;
            return Page();
        }
    }
}
