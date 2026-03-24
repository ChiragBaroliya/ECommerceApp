using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EcommerceApp.Backend.Models;
using EcommerceApp.Backend.Mock;
using System.Linq;

namespace EcommerceApp.Backend.Pages.Addresses
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Address Address { get; set; } = new Address();

        public IActionResult OnGet(int id)
        {
            var address = MockAddressStore.Addresses.FirstOrDefault(a => a.Id == id);
            if (address == null)
            {
                return RedirectToPage("Index");
            }
            Address = address;
            return Page();
        }

        public IActionResult OnPost()
        {
            var address = MockAddressStore.Addresses.FirstOrDefault(a => a.Id == Address.Id);
            if (address != null)
            {
                MockAddressStore.Addresses.Remove(address);
            }
            return RedirectToPage("Index");
        }
    }
}
