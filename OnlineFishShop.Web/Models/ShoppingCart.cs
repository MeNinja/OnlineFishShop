using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFishShop.Web.Models
{
    public class ShoppingCart
    {
        private readonly IList<CartItem> cartItems;

        public IEnumerable<CartItem> CartItems => new List<CartItem>(this.cartItems);

        public ShoppingCart()
        {
            this.cartItems = new List<CartItem>();
        }

        /// <summary>
        /// adds a single item to cart
        /// </summary>
        /// <param name="productId"></param>
        public void AddToCart(int productId)
        {
            //null check
            var cartitem = this.cartItems.SingleOrDefault(x => x.ProductId == productId);

            if (cartitem == null)
            {
                cartitem = new CartItem()
                {
                    ProductId = productId,
                    Quantity = 1
                };

                this.cartItems.Add(cartitem);
            }
            else
            {
                cartitem.Quantity++;
            }
        }

        /// <summary>
        /// adds many items of a kind to cart
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        public void AddToCart(int productId, int quantity)
        {
            var cartitem = this.cartItems.SingleOrDefault(x => x.ProductId == productId);

            //does not exists in shopping cart
            if (cartitem == null)
            {
                cartitem = new CartItem()
                {
                    ProductId = productId,
                    Quantity = quantity
                };

                this.cartItems.Add(cartitem);
            }
            else
            {
                cartitem.Quantity += quantity;
            }
        }

        public void RemoveFromCart(int productId)
        {
            var cartItem = this.cartItems.SingleOrDefault(x => x.ProductId == productId);

            if (cartItem != null)
            {
                this.cartItems.Remove(cartItem);
            }
        }
    }
}
