using OrderOfWish.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderOfWish.Model.Entities
{
    public class OrderDetail
    {
        public int OrderID { get; set; }
        public Order Order { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public decimal Price { get; set; }
        public decimal Stock { get; set; }
        public short Quantity { get; set; }
        public double Discount { get; set; }

    }
}
