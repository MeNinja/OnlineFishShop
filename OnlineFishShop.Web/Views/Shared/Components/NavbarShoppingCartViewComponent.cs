using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OnlineFishShop.Services.Contracts;
using OnlineFishShop.Web.Infrastructure.Extensions;

namespace OnlineFishShop.Web.Views.Shared.Components
{
    public class NavbarShoppingCartViewComponent : ViewComponent
    {
        private readonly IShoppingCartManager shoppingCartManager;

        public NavbarShoppingCartViewComponent(IShoppingCartManager shoppingCartManager)
        {
            this.shoppingCartManager = shoppingCartManager;
        }

        public IViewComponentResult Invoke()
        {
            var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();
            var items = this.shoppingCartManager.GetCartItems(shoppingCartId);

            return View("NavbarShoppingCart", items.Count());
        }
    }
}
