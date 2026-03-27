using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhoneNumbers;

namespace EcommerceApp.Backend.Pages.Account
{
    public class SettingsModel : PageModel
    {
        [BindProperty]
        public MockUser User { get; set; }
        public string? Message { get; set; }

        public void OnGet()
        {
            // Mock data
            User = new MockUser
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                Phone = "123-456-7890"
            };
        }

        [ValidateAntiForgeryToken]
        public IActionResult OnPost()
        {
        
            if (!ModelState.IsValid)
            {
                return Page();
            }
            // Simulate save
            Message = "Account settings updated (mock).";
            return Page();
        }

        public class MockUser
        {
        // WARNING: This class is for mock/demo purposes only. Do NOT use in production.
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.StringLength(64)]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.EmailAddress]
        public string Email { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.StringLength(20)]
        [System.ComponentModel.DataAnnotations.CustomValidation(typeof(MockUser), nameof(ValidatePhoneNumber))]
        public string Phone { get; set; }

        public static System.ComponentModel.DataAnnotations.ValidationResult ValidatePhoneNumber(string phone, System.ComponentModel.DataAnnotations.ValidationContext context)
        {
            try
            {
                var phoneUtil = PhoneNumberUtil.GetInstance();
                var parsed = phoneUtil.Parse(phone, "US"); // Optionally, use user's country
                if (phoneUtil.IsValidNumber(parsed))
                    return System.ComponentModel.DataAnnotations.ValidationResult.Success;
            }
            catch { }
            return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid phone number format.");
        }
        }
    }
}
