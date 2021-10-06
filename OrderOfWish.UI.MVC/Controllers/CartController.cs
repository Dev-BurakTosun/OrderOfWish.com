using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderOfWish.BLL.Abstract;
using OrderOfWish.UI.MVC.Helper;
using OrderOfWish.UI.MVC.Models.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderOfWish.UI.MVC.Controllers
{
    public class CartController : Controller
    {


        public IActionResult Index()
        {
            MyCart myCart = HttpContext.Session.Get<MyCart>("cart");
            return View(myCart);
        }
        [HttpPost]
        public IActionResult AddToCart([FromBody] CartVM cart)
        {
            MyCart myCart = HttpContext.Session.Get<MyCart>("cart");
            CartItem cartItem = new CartItem()
            {
                ID = cart.ProductID,
                Amout = 1,
                Name = cart.ProductName,
                Price = cart.Price,
                ProductImgUrl = cart.ProductImgUrl
            };
            myCart.AddCart(cartItem);
            HttpContext.Session.Set<MyCart>("cart",myCart);
            return Ok();            
        }

        public IActionResult UpdateCart(short amount, int id)
        {
            MyCart updateCart = HttpContext.Session.Get<MyCart>("cart");
            updateCart.Update(id, amount);
            HttpContext.Session.Set<MyCart>("cart", updateCart);
            return PartialView("_cartView", updateCart);
        }



        public IActionResult DeleteToCart(int id)
        {
            MyCart deleteCart = HttpContext.Session.Get<MyCart>("cart");
            deleteCart.Delete(id);
            HttpContext.Session.Set<MyCart>("cart", deleteCart);
            return Ok();
        }

        public IActionResult GetCartButton()
        {
            MyCart myCart = HttpContext.Session.Get<MyCart>("cart");
            return PartialView("_cartButton", myCart.TotalAmout);
        }
    }
}
