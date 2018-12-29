using OnlineFishShop.Data.EntityConfigurations.ValidationAttributes;
using OnlineFishShop.Web.Models;
using OnlineFishShop.Web.Models.Automapper;

namespace OnlineFishShop.Web.Areas.Shopping.Models
{
    public class CartItemUpdateModel : IMapFrom<CartItem>
    {
        public int Id { get; set; }

        [StockQuantity]
        public byte Quantity { get; set; }
    }
}
