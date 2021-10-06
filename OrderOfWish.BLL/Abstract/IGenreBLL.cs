using OrderOfWish.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderOfWish.BLL.Abstract
{
    public interface IGenreBLL:IBaseBLL<Genre>
    {
         ICollection<Genre> GetGenreAll();//Satıştaki ürünler(Türe Bağlı.)
    }
}
