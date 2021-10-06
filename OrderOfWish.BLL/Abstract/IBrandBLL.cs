using OrderOfWish.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderOfWish.BLL.Abstract
{
    public interface IBrandBLL:IBaseBLL<Brand>
    {
         ICollection<Brand> GetBrands();//Tüm markaları çağırmak için kullanılan metod.Şuandan ve öncesinde oluşturulan markalar için kullanılacak.
    }
}
