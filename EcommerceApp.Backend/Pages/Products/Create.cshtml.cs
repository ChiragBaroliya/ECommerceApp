using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EcommerceApp.Backend.Models;
using EcommerceApp.Backend.Mock;

namespace EcommerceApp.Backend.Pages.Products
{
    [Authorize(Roles = "Admin,Vendor")]
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Product Product { get; set; } = new Product();

        public void OnGet() { }

        [ValidateAntiForgeryToken]
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            MockProductStore.Add(Product);
            return RedirectToPage("Index");
        }
    }
}
