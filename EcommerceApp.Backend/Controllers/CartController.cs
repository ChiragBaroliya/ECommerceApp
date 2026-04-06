using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using EcommerceApp.Backend.Models;
using EcommerceApp.Backend.Mock;

namespace EcommerceApp.Backend.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            var username = User.Identity?.Name ?? "guest";
            var cart = MockCartStore.GetCart(username);
            return View(cart);
        }

        [HttpPost]
        public IActionResult Add(int productId, int quantity = 1)
        {
            var product = MockProductStore.GetById(productId);
            if (product == null)
            {
                return NotFound();
            }

            var username = User.Identity?.Name ?? "guest";
            MockCartStore.AddToCart(username, product, quantity);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(int productId, int quantity)
        {
            var username = User.Identity?.Name ?? "guest";
            MockCartStore.UpdateQuantity(username, productId, quantity);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remove(int productId)
        {
            var username = User.Identity?.Name ?? "guest";
            MockCartStore.RemoveFromCart(username, productId);

            return RedirectToAction("Index");
        }
    }
}
