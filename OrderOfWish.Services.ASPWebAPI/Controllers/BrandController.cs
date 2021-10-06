using Microsoft.AspNetCore.Mvc;
using OrderOfWish.BLL.Abstract;
using OrderOfWish.Model.Entities;
using OrderOfWish.Services.ASPWebAPI.Models;
using System.Collections.Generic;

namespace OrderOfWish.Services.ASPWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        IBrandBLL brandBLL;
        public BrandController(IBrandBLL bll)
        {
            brandBLL = bll;
        }

        List<BrandDTO> BrandDtoList(ICollection<Brand> listBrand)
        {
            List<BrandDTO> brands = new List<BrandDTO>();
            foreach (Brand item in brandBLL.GetAll())
            {
                brands.Add(new BrandDTO()
                {
                    BrandID = item.ID,
                    BrandName = item.BrandName,
                    Description = item.Description
                });
            }
            return brands;
        }

        public IActionResult GetBrands()
        {
            List<BrandDTO> brands = BrandDtoList(brandBLL.GetBrands());
            return Ok(brands);
        }       
        
    }
}
