using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EcommerceApp.Backend.Models;
using EcommerceApp.Backend.Mock;

namespace EcommerceApp.Backend.Pages.Addresses
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Address Address { get; set; } = new Address();

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Address.Id = MockAddressStore.NextId;
            MockAddressStore.Addresses.Add(Address);
            return RedirectToPage("Index");
        }
    }
}
