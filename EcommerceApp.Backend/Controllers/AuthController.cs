using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using EcommerceApp.Backend.Models;
using EcommerceApp.Backend.Mock;
using EcommerceApp.Backend.Auth;

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
        public IActionResult Login(User input)
        {
            var user = MockUserStore.GetUser(input.Username, input.Password);
            if (user == null)
            {
                ViewBag.Message = "Invalid credentials.";
                return View();
            }
            // Optionally, set authentication cookie or session here
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
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
