using OrderOfWish.BLL.Abstract;
using OrderOfWish.DAL.Abstract;
using OrderOfWish.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderOfWish.BLL.Concrete
{
    class SupplierService:ISupplierBLL
    {
        ISupplierDAL supplierDAL;

        public SupplierService(ISupplierDAL dal)
        {
            supplierDAL = dal;
        }

        void CheckSupplierName(Supplier supplier)
        {
            if (supplier.CompanyName == null)
            {
                throw new Exception("Tedarikçi ismi boş geçilemez.");
            }
            else if (supplier.CompanyName.Length <= 40)
            {
                throw new Exception("Tedarikçi adı 40 haneden büyük olamaz.");
            }
        }

        #region BaseMethod
        public void Insert(Supplier entity)
        {
            CheckSupplierName(entity);
            supplierDAL.Add(entity);
        }

        public void Update(Supplier entity)
        {
            CheckSupplierName(entity);
            supplierDAL.Update(entity);
        }
        public void Delete(Supplier entity)
        {
            entity.IsActive = false;
            supplierDAL.Update(entity);
        }

        public void DeleteByID(int entityID)
        {
            Supplier supplier = Get(entityID);
            supplier.IsActive = false;
            supplierDAL.Update(supplier);
        }

        public Supplier Get(int entityID)
        {
            return supplierDAL.Get(a => a.ID == entityID);
        }

        public ICollection<Supplier> GetAll()
        {
            return supplierDAL.GetAll();
        } 
        #endregion

        public ICollection<Supplier> GetSuppliers()
        {
            return supplierDAL.GetAll(a => a.IsActive == true, a => a.CompanyName, a => a.Country).OrderByDescending(a => a.CompanyName).ToList();
        }

        public ICollection<Supplier> GetActiveSuppliers()
        {
            return supplierDAL.GetAll(a => a.IsActive, a => a.Products);
        }
    }
}
