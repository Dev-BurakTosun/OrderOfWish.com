using Microsoft.AspNetCore.Mvc;
using OrderOfWish.BLL.Abstract;
using OrderOfWish.Model.Entities;
using OrderOfWish.Services.ASPWebAPI.Models;
using System.Collections.Generic;

namespace OrderOfWish.Services.ASPWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductBLL productBLL;

        public ProductController(IProductBLL bll)
        {
            productBLL = bll;
        }

        List<ProductDTO> ProductDtoList(ICollection<Product> listproducts)
        {
            List<ProductDTO> products = new List<ProductDTO>();
            foreach (Product item in listproducts)
            {
                products.Add(new ProductDTO()
                {
                    ProductID=item.ID,
                    ProductName=item.ProductName,
                    Description=item.Description,
                    ProductImgURL=item.ProductImgURL,
                    Price=item.Price,
                    Stock=item.Stock,
                    Continued=item.Continued,
                    BrandID=item.BrandID,
                    GenreID=item.GenreID,
                    SupplierID=item.SupplierID,
                    BrandName=item.Brand.BrandName,
                });
            }
            return products;

        }
        public IActionResult GetProducts()
        {

            List<ProductDTO> products = ProductDtoList(productBLL.GetProducts());
            return Ok(products);


        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            Product product = productBLL.Get(id);
            ProductDTO productDTO = new ProductDTO();
            productDTO.ProductID = product.ID;
            productDTO.ProductName = product.ProductName;
            productDTO.Description = product.Description;
            productDTO.ProductImgURL = product.ProductImgURL;
            productDTO.Price = product.Price;
            productDTO.Stock = product.Stock;
            productDTO.Continued = product.Continued;
            productDTO.BrandName = product.Brand.BrandName;

            return Ok(productDTO);
        }


        [HttpGet("{id}")]
        public IActionResult GetProductByBrand(int id)
        {
            List<ProductDTO> products = ProductDtoList(productBLL.GetProductByBrand(id));
            return Ok(products);
        }

        [HttpGet("{id}")]
         public IActionResult GetByGenre(int id)
        {
            List<ProductDTO> products = ProductDtoList(productBLL.GetByGenre(id));
            return Ok(products);
        }

        [HttpGet("{price}")]
        public IActionResult GetCheapProduct(decimal price)
        {
            List<ProductDTO> products = ProductDtoList(productBLL.GetCheapProduct(price));
            return Ok(products);
        }
             

    }
}
