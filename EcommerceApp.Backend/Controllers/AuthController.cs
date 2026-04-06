using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using EcommerceApp.Backend.Models;
using EcommerceApp.Backend.Mock;
using EcommerceApp.Backend.Auth;
using Microsoft.AspNetCore.Authentication;

namespace EcommerceApp.Backend.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(User input)
        {
        
            var user = MockUserStore.GetUser(input.Username, input.Password);
            if (user == null)
            {
                ViewBag.Message = "Invalid credentials.";
                return View();
            }

            // Sign in with cookie authentication
            var claims = new List<System.Security.Claims.Claim>
            {
                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, user.Username),
                new System.Security.Claims.Claim("FullName", user.FullName ?? user.Username),
                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Role, user.Role ?? "")
            };
            var identity = new System.Security.Claims.ClaimsIdentity(claims, "Cookies");
            var principal = new System.Security.Claims.ClaimsPrincipal(identity);
            HttpContext.SignInAsync("Cookies", principal).Wait();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User user)
        {
        
            if (MockUserStore.UserExists(user.Username))
            {
                ViewBag.Message = "User already exists.";
                return View();
            }
            MockUserStore.AddUser(user);
            // Optionally, show success message or redirect to login
            return RedirectToAction("Login");
        }
    }
}
