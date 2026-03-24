using Microsoft.AspNetCore.Mvc.RazorPages;
using EcommerceApp.Backend.Models;
using EcommerceApp.Backend.Mock;
using System.Collections.Generic;

namespace EcommerceApp.Backend.Pages.Addresses
{
    public class IndexModel : PageModel
    {
        public List<Address> Addresses { get; set; } = new();

        public void OnGet()
        {
            Addresses = MockAddressStore.Addresses;
        }
    }
}
