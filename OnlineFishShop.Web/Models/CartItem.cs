using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFishShop.Web.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        //add extras like discount here
    }
}
