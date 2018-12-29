using System;
using System.Collections.Generic;
using System.Text;
using OnlineFishShop.Web.Models;

namespace OnlineFishShop.Services.Contracts
{
    public interface IShoppingCartManager
    {
        void AddToCart(string shoppingCartId, int productId, int quantity);
        void RemoveFromCart(string shoppingCartId, int productId);
        bool HasItem(string shoppingCartId, int productId);

        IEnumerable<CartItem> GetCartItems(string shoppingCartId);
        CartItem GetCartItem(string shoppingCartId, int productId);
    }
}
