using OrderOfWish.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderOfWish.BLL.Abstract
{
    public interface IUserBLL:IBaseBLL<User>
    {
        User GetByActivationCode(Guid guid);
        User GetUserByLoginData(string mail, string password);
        string GetAddres(int id);
    }
}
