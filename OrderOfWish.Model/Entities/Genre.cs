using OrderOfWish.Core.Entity;
using OrderOfWish.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderOfWish.Model.Entities
{
    public class Genre:BaseEntity
    {
        public Genre()
        {
            IsActive = true;
        }

        public string GenreName { get; set; }
        public string Description { get; set; }        
        public ICollection<Product> Products { get; set; }

    }
}
