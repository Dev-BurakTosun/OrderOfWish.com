using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderOfWish.UI.MVC.Models.Cart
{
    public class CartItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ProductImgUrl { get; set; }      
        public decimal Price { get; set; }
        public short Amout { get; set; }
        public decimal SubTotal
        {
            get
            {
                return Price * Amout;
            }

        }
    }
}
