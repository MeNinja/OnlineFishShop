using System;
using Microsoft.AspNetCore.Http;

namespace OnlineFishShop.Web.Infrastructure.Extensions
{
    public static class SessionExtensions
    {
        public static string GetShoppingCartId(this ISession session)
        {
            var shoppingCartId = session.GetString("Shopping_Cart_Id");

            if (shoppingCartId == null)
            {
                shoppingCartId = Guid.NewGuid().ToString();
                session.SetString("Shopping_Cart_Id", shoppingCartId);
            }

            return shoppingCartId;
        }
    }
}
