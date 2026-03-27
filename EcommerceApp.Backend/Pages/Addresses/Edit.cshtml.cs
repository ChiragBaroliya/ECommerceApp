using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EcommerceApp.Backend.Models;
using EcommerceApp.Backend.Mock;
using System.Linq;

namespace EcommerceApp.Backend.Pages.Addresses
{
    public class EditModel : PageModel
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
            // IDOR Mitigation: Only allow editing if the address belongs to the current user (mocked check)
            var currentUser = User.Identity?.Name ?? "";
            if (!string.IsNullOrEmpty(address.UserName) && !string.IsNullOrEmpty(currentUser) && address.UserName != currentUser)
            {
                // Unauthorized access attempt
                return Forbid();
            }
            Address = new Address
            {
                Id = address.Id,
                UserName = address.UserName,
                Street = address.Street,
                City = address.City,
                State = address.State,
                Zip = address.Zip,
                Country = address.Country
            };
            return Page();
        }

        [ValidateAntiForgeryToken]
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var address = MockAddressStore.Addresses.FirstOrDefault(a => a.Id == Address.Id);
            if (address == null)
            {
                return RedirectToPage("Index");
            }
            address.UserName = Address.UserName;
            address.Street = Address.Street;
            address.City = Address.City;
            address.State = Address.State;
            address.Zip = Address.Zip;
            address.Country = Address.Country;
            return RedirectToPage("Index");
        }
    }
}
