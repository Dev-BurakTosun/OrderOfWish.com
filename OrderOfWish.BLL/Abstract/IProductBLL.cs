using OrderOfWish.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderOfWish.BLL.Abstract
{
    public interface IProductBLL:IBaseBLL<Product>
    {
        ICollection<Product> GetProducts();        
        ICollection<Product> GetByGenre(int id);
        ICollection<Product> GetCheapProduct(decimal price);        
        Product GetCartItem(int entityID);
        ICollection<Product> GetProductByBrand(int id);
    }
}
