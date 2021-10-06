using OrderOfWish.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderOfWish.Model.Entities
{
    public class Order:BaseEntity
    {
        public Order()
        {
            IsActive = true;
        }

        public DateTime OrderDate { get; set; }
        public string ShipAddress { get; set; }
        public User User { get; set; }
        public int UserID { get; set; }        
        public ICollection<OrderDetail> OrderDetails { get; set; }

        
    }
}
