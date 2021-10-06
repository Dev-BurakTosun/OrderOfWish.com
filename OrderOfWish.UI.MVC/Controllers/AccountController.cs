using Microsoft.AspNetCore.Mvc;
using OrderOfWish.BLL.Abstract;
using OrderOfWish.Model.Entities;
using OrderOfWish.UI.MVC.Helper;
using OrderOfWish.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderOfWish.UI.MVC.Controllers
{
    public class AccountController : Controller
    {
        IUserBLL userBLL;
        public AccountController(IUserBLL bll)
        {
            userBLL = bll;
        }
        public IActionResult Login()
        {
            return View();
        }       


        [HttpPost]
        public IActionResult Register(UserVM userVM)
        {
            try
            {
                User user = new User()
                {
                    ID = userVM.UserID,
                    Email = userVM.Email,
                    Password = userVM.Password,
                    LastName = userVM.LastName,
                    FirstName = userVM.FirstName,
                    Address = userVM.Address,
                    BirthDate = userVM.BirthDate,
                };
                userBLL.Insert(user);
                bool check = MailHelper.SendActivationCode(user.FirstName, user.Email, user.ActivationCode);


                if (check)
                {
                    ViewData["Message"] = $"{user.Email} adresinin mail kutusunu (spam) kontrol ediniz";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData["Message"] = "Aktivasyon Maili Gönderilemedi. Bilgilerinizi kontrol edin";
                    return RedirectToAction("Login", "Account");
                }

            }
            catch (Exception ex)
            {

                ViewData["Message"] = ex.Message;
                return RedirectToAction("Login", "Account");
            }

        }

        public IActionResult ActivationUser(Guid id)
        {
            User newUser = userBLL.GetByActivationCode(id);
            if (newUser != null)
            {
                newUser.IsActive = true;
                userBLL.Update(newUser);
                return RedirectToAction("Login");
            }
            else
            {
                ViewData["Message"] = "Aktif edilecek kullanıcı bulunamadı.";
                return RedirectToAction("Login");
            }
        }
    }
}
