using OrderOfWish.Core.DataAccess;
using OrderOfWish.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderOfWish.DAL.Abstract
{
   public interface IUserDAL : IRepository<User>
    {
    }
}
