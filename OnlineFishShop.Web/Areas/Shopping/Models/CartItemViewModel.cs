using OnlineFishShop.Data.Models;
using OnlineFishShop.Web.Models.Automapper;

namespace OnlineFishShop.Web.Areas.Shopping.Models
{
    public class CartItemViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ThumbnailSource { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
