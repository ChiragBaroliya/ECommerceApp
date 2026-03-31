using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EcommerceApp.Backend.Models;
using EcommerceApp.Backend.Mock;
using System.Collections.Generic;

namespace EcommerceApp.Backend.Pages.Products
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        public List<Product> Products { get; set; } = new();

        [Microsoft.AspNetCore.Mvc.BindProperty(SupportsGet = true)]
        public string? Search { get; set; }
        [Microsoft.AspNetCore.Mvc.BindProperty(SupportsGet = true)]
        public int? CategoryId { get; set; }
        [Microsoft.AspNetCore.Mvc.BindProperty(SupportsGet = true)]
        public string? Sort { get; set; }

        public void OnGet()
        {
            var products = MockProductStore.Products.AsQueryable();
            if (!string.IsNullOrWhiteSpace(Search))
            {
                var searchLower = Search.ToLowerInvariant();
                products = products.Where(p => (p.Name != null && p.Name.ToLower().Contains(searchLower)) || (p.Description != null && p.Description.ToLower().Contains(searchLower)));
            }
            if (CategoryId.HasValue && CategoryId.Value > 0)
            {
                products = products.Where(p => p.CategoryId == CategoryId.Value);
            }
            switch (Sort)
            {
                case "name_asc":
                    products = products.OrderBy(p => p.Name);
                    break;
                case "name_desc":
                    products = products.OrderByDescending(p => p.Name);
                    break;
                case "price_asc":
                    products = products.OrderBy(p => p.Price);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(p => p.Price);
                    break;
            }
            Products = products.ToList();
        }
    }
}
