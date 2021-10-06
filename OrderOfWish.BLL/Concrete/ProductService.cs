using OrderOfWish.BLL.Abstract;
using OrderOfWish.DAL.Abstract;
using OrderOfWish.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderOfWish.BLL.Concrete
{
    public class ProductService : IProductBLL
    {
        IProductDAL productDAL;

        public ProductService(IProductDAL dal)
        {
            productDAL = dal;
        }
        void CheckProductName(Product product)
        {

            if (product.ProductName.Length <= 50 && product.ProductName == null)
            {
                throw new Exception("Ürün ismi 50 karakterden büyük olamaz.");
            }
            //else if (product.ProductName == null)
            //{
            //    throw new Exception("Ürün adı boş geçilemez.");
            //}
        }

        void CheckStock(Product product)
        {
            if (product.Stock == 0)
            {
                throw new Exception("En az '1' ürün olması gerekmektedir.");
            }
            
        }

        void CheckContinued(Product product)
        {
            if (product.Continued == false)
            {
                throw new Exception("Bu ürün şuan satın alınamaz.");
            }
        }

        void CheckPrice(Product product)
        {
            if (product.Price == 0)
            {
                throw new Exception("Ürün fiyatı olmak zorunda!");
            }
        }

        #region BaseMethod
        public void Insert(Product entity)
        {
            CheckProductName(entity);
            CheckContinued(entity);
            CheckPrice(entity);
            CheckStock(entity);
            productDAL.Add(entity);
        }

        public void Update(Product entity)
        {
            CheckProductName(entity);
            CheckContinued(entity);
            CheckPrice(entity);
            CheckStock(entity);
            productDAL.Update(entity);
        }
        public void Delete(Product entity)
        {
            entity.IsActive = false;
            productDAL.Update(entity);
        }

        public void DeleteByID(int entityID)
        {
            Product product = Get(entityID);
            product.IsActive = false;
            productDAL.Update(product);
        }

        public Product Get(int entityID)
        {
            return productDAL.Get(a => a.ID == entityID && a.Continued && a.IsActive , a=> a.Brand, a=> a.Genre, a=> a.Supplier);
        }

        public ICollection<Product> GetAll()
        {
            return productDAL.GetAll();
        }
        #endregion

        public ICollection<Product> GetProducts()
        {
            return productDAL.GetAll(a => a.Continued && a.IsActive, a => a.Genre, a => a.Brand, a => a.Supplier).OrderByDescending(a => a.CreatedDate).ToList();
        }      

        public ICollection<Product> GetProductByBrand(int id)
        {
            return productDAL.GetAll(a => a.Continued && a.IsActive && a.BrandID == id, a => a.Brand, a => a.Genre, a => a.Supplier);
        }

        public ICollection<Product> GetByGenre(int id)
        {
            return productDAL.GetAll(a => a.Continued && a.IsActive == true && a.GenreID == id, a => a.Brand, a => a.Genre, a => a.Supplier);
        }

        public ICollection<Product> GetCheapProduct(decimal price)
        {
            return productDAL.GetAll(a => a.Price <= 1, a => a.ProductName, a => a.Continued).OrderByDescending(a => a.Price).ToList();
        }

        public ICollection<Product> GetStock()
        {
            return productDAL.GetAll(a => a.Stock <= 1, a => a.ProductName, a => a.Brand).OrderByDescending(a => a.Stock).ToList();
        }

        public Product GetCartItem(int entityID)
        {
            return productDAL.Get(a => a.ID == entityID && a.Continued && a.IsActive, a=> a.Brand, a=> a.Genre, a=>a.Supplier);
        }
     
    }
}
