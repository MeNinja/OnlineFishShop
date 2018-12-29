using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineFishShop.Services.Contracts;
using OnlineFishShop.Web.Models;

namespace OnlineFishShop.Web.Infrastructure.WebServices
{
    public class ShoppingCartManager : IShoppingCartManager
    {
        private readonly ConcurrentDictionary<string, ShoppingCart> carts;

        public ShoppingCartManager()
        {
            this.carts = new ConcurrentDictionary<string, ShoppingCart>();
        }

        public void AddToCart(string shoppingCartId, int productId, int quantity = 1)
        {
            var shoppingCart = this.GetShoppingCart(shoppingCartId);

            shoppingCart.AddToCart(productId, quantity);
        }

        public void RemoveFromCart(string shoppingCartId, int productId)
        {
            var shoppingCart = this.GetShoppingCart(shoppingCartId);
            shoppingCart.RemoveFromCart(productId);
        }

        public IEnumerable<CartItem> GetCartItems(string shoppingCartId)
        {
            var shoppingCart = this.GetShoppingCart(shoppingCartId);

            return new List<CartItem>(shoppingCart.CartItems);
        }

        public CartItem GetCartItem(string shoppingCartId, int productId)
        {
            return this.GetCartItems(shoppingCartId).SingleOrDefault(x => x.ProductId == productId);
        }

        public bool HasItem(string shoppingCartId, int productId)
        {
            return this.GetCartItem(shoppingCartId, productId) != null;
        }

        private ShoppingCart GetShoppingCart(string shoppingCartId)
        {
            return this.carts.GetOrAdd(shoppingCartId, new ShoppingCart());
        }
    }
}
