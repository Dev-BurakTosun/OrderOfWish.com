using OrderOfWish.Core.DataAccess.EntityFramework;
using OrderOfWish.DAL.Abstract;
using OrderOfWish.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderOfWish.DAL.Concrete
{
    class BrandRepository:EFRepositoryBase<Brand, OrderOfWishDbContext>, IBrandDAL
    {
    }
}
