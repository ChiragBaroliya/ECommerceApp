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

        public IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> CategoryOptions { get; set; }

        public void OnGet()
        {
            CategoryOptions = EcommerceApp.Backend.Mock.MockCategoryStore.Categories
                .Select(c => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = c.Id.ToString(), Text = c.Name });
        }

        [BindProperty]
        public List<IFormFile> ProductImages { get; set; } = new();

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            // Handle image uploads
            if (ProductImages != null && ProductImages.Any())
            {
                foreach (var image in ProductImages)
                {
                    if (image.Length > 0)
                    {
                        var ext = System.IO.Path.GetExtension(image.FileName).ToLowerInvariant();
                        var allowed = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                        if (!allowed.Contains(ext) || image.Length > 2 * 1024 * 1024) // 2MB limit
                        {
                            ModelState.AddModelError("ProductImages", $"Invalid image file {image.FileName} (jpg, png, gif, max 2MB)");
                            continue;
                        }
                        var fileName = $"product_{Guid.NewGuid()}{ext}";
                        var savePath = System.IO.Path.Combine("wwwroot/images/products", fileName);
                        
                        // Ensure directory exists
                        var dir = System.IO.Path.GetDirectoryName(savePath);
                        if (!System.IO.Directory.Exists(dir)) System.IO.Directory.CreateDirectory(dir);

                        using (var stream = System.IO.File.Create(savePath))
                        {
                            image.CopyTo(stream);
                        }

                        var relativePath = $"images/products/{fileName}";
                        if (string.IsNullOrEmpty(Product.ImagePath))
                        {
                            Product.ImagePath = relativePath;
                        }
                        else
                        {
                            Product.GalleryImages.Add(relativePath);
                        }
                    }
                }
            }

            MockProductStore.Add(Product);
            return RedirectToPage("Index");
        }
    }
}
