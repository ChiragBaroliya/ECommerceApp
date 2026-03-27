using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EcommerceApp.Backend.Models;
using EcommerceApp.Backend.Mock;

namespace EcommerceApp.Backend.Pages.Products
{
    [Authorize(Roles = "Admin,Vendor")]
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Product Product { get; set; } = new Product();

        public IActionResult OnGet(int id)
        {
            var product = MockProductStore.GetById(id);
            if (product == null) return RedirectToPage("Index");
            Product = product;
            return Page();
        }

        [ValidateAntiForgeryToken]
        public IActionResult OnPost()
        {
            MockProductStore.Delete(Product.Id);
            return RedirectToPage("Index");
        }
    }
}
