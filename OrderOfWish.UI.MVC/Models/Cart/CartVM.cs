using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderOfWish.UI.MVC.Models.Cart
{
    public class CartVM
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }        
        public string ProductImgUrl { get; set; }        
        
    }
}
