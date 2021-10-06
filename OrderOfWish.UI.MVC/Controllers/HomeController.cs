using Microsoft.AspNetCore.Mvc;
using OrderOfWish.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderOfWish.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }
        public IActionResult ProductDetails()
        {
            return View();
        }

        public IActionResult BlogDetails()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Shop()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }
       

        [HttpPost]
        public IActionResult GetProducts([FromBody]List<ProductVM> products)
        {
            if (products == null)
            {
                ViewBag.Message = "Ürün bulunamadı.";  
            }
            return PartialView("_singleProduct", products);
        }


        [HttpPost]
        public IActionResult GetGenre([FromBody] List<GenreVM> genres)
        {
            if (genres == null)
            {
                ViewBag.Message = "Kategori bulunamadı.";
            }
            return PartialView("_singleGenre", genres);
        }


    }
}
