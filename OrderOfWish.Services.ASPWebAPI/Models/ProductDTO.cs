using OrderOfWish.Model.Entities;
using OrderOfWish.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderOfWish.Services.ASPWebAPI.Models
{
    public class ProductDTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ProductImgURL { get; set; }
        public decimal Price { get; set; }
        public short Stock { get; set; }
        public bool Continued { get; set; }
        public int BrandID { get; set; }
        public int GenreID { get; set; }
        public int SupplierID { get; set; }
        public string BrandName { get; set; }
        
    }


}

