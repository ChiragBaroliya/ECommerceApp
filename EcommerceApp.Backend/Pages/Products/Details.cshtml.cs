using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EcommerceApp.Backend.Models;
using EcommerceApp.Backend.Mock;

namespace EcommerceApp.Backend.Pages.Products
{
    [AllowAnonymous]
    public class DetailsModel : PageModel
    {
        public Product Product { get; set; } = new Product();
        
        [BindProperty]
        public string NewReviewUserName { get; set; } = string.Empty;
        [BindProperty]
        public int NewReviewRating { get; set; }
        [BindProperty]
        public string NewReviewComment { get; set; } = string.Empty;

        public IActionResult OnGet(int id)
        {
            var product = MockProductStore.GetById(id);
            if (product == null) return RedirectToPage("Index");
            Product = product;
            return Page();
        }

        public IActionResult OnPostAddReview(int id)
        {
            var product = MockProductStore.GetById(id);
            if (product == null) return RedirectToPage("Index");

            if (string.IsNullOrWhiteSpace(NewReviewUserName) || NewReviewRating < 1 || NewReviewRating > 5)
            {
                ModelState.AddModelError("", "Please provide a valid name and rating.");
                Product = product;
                return Page();
            }

            var review = new ProductReview
            {
                Id = product.Reviews.Count + 1,
                ProductId = id,
                UserName = NewReviewUserName,
                Rating = NewReviewRating,
                Comment = NewReviewComment,
                CreatedAt = DateTime.Now
            };

            product.Reviews.Add(review);
            return RedirectToPage(new { id = id });
        }
    }
}
