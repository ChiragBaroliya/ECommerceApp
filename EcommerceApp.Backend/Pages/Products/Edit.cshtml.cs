using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EcommerceApp.Backend.Models;
using EcommerceApp.Backend.Mock;

namespace EcommerceApp.Backend.Pages.Products
{
    [Authorize(Roles = "Admin,Vendor")]
    public class EditModel : PageModel
    {
        [BindProperty]
        public Product Product { get; set; } = new Product();

        public IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> CategoryOptions { get; set; }

        public IActionResult OnGet(int id)
        {
            var product = MockProductStore.GetById(id);
            if (product == null) return RedirectToPage("Index");
            Product = product;
            CategoryOptions = EcommerceApp.Backend.Mock.MockCategoryStore.Categories
                .Select(c => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = c.Id.ToString(), Text = c.Name });
            return Page();
        }

        [BindProperty]
        public IFormFile? ProductImage { get; set; }


        [ValidateAntiForgeryToken]

        public IActionResult OnPost()
        {
            CategoryOptions = EcommerceApp.Backend.Mock.MockCategoryStore.Categories
                .Select(c => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = c.Id.ToString(), Text = c.Name });

            if (!ModelState.IsValid)
                return Page();

            // Handle image upload
            if (ProductImage != null && ProductImage.Length > 0)
            {
                var ext = System.IO.Path.GetExtension(ProductImage.FileName).ToLowerInvariant();
                var allowed = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                if (!allowed.Contains(ext) || ProductImage.Length > 2 * 1024 * 1024) // 2MB limit
                {
                    ModelState.AddModelError("ProductImage", "Invalid image file (jpg, png, gif, max 2MB)");
                    return Page();
                }
                var fileName = $"product_{Guid.NewGuid()}{ext}";
                var savePath = System.IO.Path.Combine("wwwroot/images/products", fileName);
                using (var stream = System.IO.File.Create(savePath))
                {
                    ProductImage.CopyTo(stream);
                }
                Product.ImagePath = $"images/products/{fileName}";
            }

            MockProductStore.Update(Product);
            return RedirectToPage("Index");
        }
    }
}
