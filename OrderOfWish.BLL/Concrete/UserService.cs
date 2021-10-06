using OrderOfWish.BLL.Abstract;
using OrderOfWish.DAL.Abstract;
using OrderOfWish.Model.Entities;
using OrderOfWish.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderOfWish.BLL.Concrete
{
    class UserService : IUserBLL
    {
        IUserDAL userDAL;

        public UserService(IUserDAL dal)
        {
            userDAL = dal;
        }

        void CheckUser(User user)
        {
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName) || string.IsNullOrEmpty(user.BirthDate.ToShortDateString()) || string.IsNullOrEmpty(user.Address))
            {
                throw new Exception("Lütfen girilen bilgileri kontrol ediniz.");
            }
        }

        void CheckEmail(User user)
        {
            if (!user.Email.Contains("@") || !user.Email.Contains(".com"))
            {
                throw new Exception("E-mail bilgilerinizi lütfen kontrol ediniz.(E-Mail Adresiniz '@' içermelidir ve '.com' ile bitmelidir.)");
            }
        }
        

        void CheckBirth(User user)
        {
            if (user.BirthDate.AddYears(18)> DateTime.Now)
            {
                throw new Exception("18 yaşını doldurmuş olmak zorunludur.");
            }
        }

        #region BaseMethod
        public void Insert(User entity)
        {
            CheckUser(entity);            
            CheckEmail(entity);
            CheckBirth(entity);
            entity.Role = UserRole.User;
            entity.ActivationCode = Guid.NewGuid();
            userDAL.Add(entity);
        }

        public void Update(User entity)
        {
            CheckUser(entity);            
            CheckEmail(entity);
            CheckBirth(entity);
            userDAL.Update(entity);
        }
        public void Delete(User entity)
        {
            entity.IsActive = false;
            userDAL.Update(entity);
        }

        public void DeleteByID(int entityID)
        {
            User user = Get(entityID);
            user.IsActive = false;
            userDAL.Update(user);
        }

        public User Get(int entityID)
        {
            return userDAL.Get(a => a.ID == entityID);
        }

        public ICollection<User> GetAll()
        {
            return userDAL.GetAll();
        }
        #endregion

        public User GetByActivationCode(Guid guid)
        {
            User newUser = userDAL.Get(a => a.ActivationCode == guid);
            return newUser;
        }

        public User GetUserByLoginData(string mail, string password)
        {
            User loginUser = userDAL.Get(a => a.Email == mail && a.Password == password && a.IsActive, a => a.Orders);
            return loginUser;
        }

        public string GetAddres(int id)
        {
            User user = userDAL.Get(a => a.ID == id);
            return user.Address;
        }
    }
}
