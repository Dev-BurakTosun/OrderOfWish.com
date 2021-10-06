using OrderOfWish.Core.Entity;
using OrderOfWish.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderOfWish.Model.Entities
{
    public class Brand:BaseEntity
    {
        public Brand()
        {
            IsActive = true;
            
        }
                
        public string BrandName { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
        

    }
}
