using OrderOfWish.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderOfWish.BLL.Abstract
{
    public interface ISupplierBLL:IBaseBLL<Supplier>
    {
        ICollection<Supplier> GetSuppliers();
        ICollection<Supplier> GetActiveSuppliers();
    }
}
