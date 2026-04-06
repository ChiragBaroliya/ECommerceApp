using System.Collections.Generic;
using System.Linq;
using EcommerceApp.Backend.Models;

namespace EcommerceApp.Backend.Mock
{
    public static class MockCartStore
    {
        private static readonly Dictionary<string, List<CartItem>> UserCarts = new Dictionary<string, List<CartItem>>();

        public static List<CartItem> GetCart(string username)
        {
            if (!UserCarts.ContainsKey(username))
            {
                UserCarts[username] = new List<CartItem>();
            }
            return UserCarts[username];
        }

        public static void AddToCart(string username, Product product, int quantity)
        {
            var cart = GetCart(username);
            var existingItem = cart.FirstOrDefault(i => i.ProductId == product.Id);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                cart.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    UnitPrice = product.Price,
                    Quantity = quantity
                });
            }
        }

        public static void UpdateQuantity(string username, int productId, int quantity)
        {
            var cart = GetCart(username);
            var item = cart.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                item.Quantity = quantity;
                if (item.Quantity <= 0)
                {
                    cart.Remove(item);
                }
            }
        }

        public static void RemoveFromCart(string username, int productId)
        {
            var cart = GetCart(username);
            var item = cart.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                cart.Remove(item);
            }
        }

        public static void ClearCart(string username)
        {
            if (UserCarts.ContainsKey(username))
            {
                UserCarts[username].Clear();
            }
        }
    }
}
