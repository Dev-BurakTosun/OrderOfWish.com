using OrderOfWish.Core.Entity;
using OrderOfWish.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderOfWish.Model.Entities
{
    public class Product:BaseEntity
    {
        public Product()
        {
            IsActive = true;            
            Continued = true;
        }

        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ProductImgURL { get; set; }
        public decimal Price { get; set; }
        public short Stock { get; set; }
        public bool Continued { get; set; }
        public int BrandID { get; set; }
        public Brand Brand { get; set; }
        public Gender Gender { get; set; }
        public int GenreID { get; set; }
        public Genre Genre { get; set; }
        public int SupplierID { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
