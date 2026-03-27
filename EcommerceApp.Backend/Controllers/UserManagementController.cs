using Microsoft.AspNetCore.Mvc;
using EcommerceApp.Backend.Models;
using EcommerceApp.Backend.Mock;

namespace EcommerceApp.Backend.Controllers
{
    public class UserManagementController : Controller
    {
        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var users = MockUserStore.Users;
            return View(users);
        }

        public IActionResult Details(string username)
        {
            var user = MockUserStore.Users.FirstOrDefault(u => u.Username == username);
            if (user == null) return NotFound();
            return View(user);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (MockUserStore.UserExists(user.Username))
            {
                ModelState.AddModelError("Username", "User already exists.");
                return View(user);
            }
            MockUserStore.AddUser(user);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(string username)
        {
            var user = MockUserStore.Users.FirstOrDefault(u => u.Username == username);
            if (user == null) return NotFound();
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            var existing = MockUserStore.Users.FirstOrDefault(u => u.Username == user.Username);
            if (existing == null) return NotFound();
            existing.FullName = user.FullName;
            existing.Email = user.Email;
            existing.Role = user.Role;
            // Always hash password on edit
            var hasher = new Microsoft.AspNetCore.Identity.PasswordHasher<string>();
            existing.Password = hasher.HashPassword(user.Username, user.Password);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(string username)
        {
            var user = MockUserStore.Users.FirstOrDefault(u => u.Username == username);
            if (user == null) return NotFound();
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string username)
        {
            var user = MockUserStore.Users.FirstOrDefault(u => u.Username == username);
            if (user != null) MockUserStore.Users.Remove(user);
            return RedirectToAction("Index");
        }
    }
}
