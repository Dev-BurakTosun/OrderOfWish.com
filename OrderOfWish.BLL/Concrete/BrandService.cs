using OrderOfWish.BLL.Abstract;
using OrderOfWish.DAL.Abstract;
using OrderOfWish.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderOfWish.BLL.Concrete
{
    class BrandService : IBrandBLL
    {
        IBrandDAL brandDAL;        


        public BrandService(IBrandDAL dal)
        {
            brandDAL = dal;
        }

        void CheckBrandName(Brand brand)
        {
            if (brand.BrandName.Length > 50 && brand.BrandName == null)
            {
                throw new Exception("Lütfen marka ismini kontrol ediniz(50 karakterden uzun olamaz ve boş geçilemez.).");
            }            
            else if (brand.CreatedDate <= DateTime.Now)
            {
                throw new Exception("Kayıt tarihi bugünden sonra olamaz.");
            }
        }

        #region BaseMethod
        public void Insert(Brand entity)
        {
            CheckBrandName(entity);
            brandDAL.Add(entity);
        }

        public void Update(Brand entity)
        {
            CheckBrandName(entity);
            brandDAL.Update(entity);
        }
        public void Delete(Brand entity)
        {
            entity.IsActive = false;
            brandDAL.Update(entity);
        }

        public void DeleteByID(int entityID)
        {
            Brand brand = Get(entityID);
            brand.IsActive = false;
            brandDAL.Update(brand);
        }

        public Brand Get(int entityID)
        {
            return brandDAL.Get(a => a.ID == entityID);
        }

        public ICollection<Brand> GetAll()
        {
            return brandDAL.GetAll();
        }
        #endregion

        //Satışta tüm markalar
        public ICollection<Brand> GetBrands()
        {
            return brandDAL.GetAll(a => a.IsActive == true, a => a.CreatedDate <= DateTime.Now, a => a.BrandName).OrderByDescending(a => a.BrandName).ToList();
        }


    }

}

