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
        public void OnGet()
        {
            Products = MockProductStore.Products;
        }
    }
}
