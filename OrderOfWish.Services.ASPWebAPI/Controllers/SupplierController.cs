using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderOfWish.BLL.Abstract;
using OrderOfWish.Model.Entities;
using OrderOfWish.Services.ASPWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderOfWish.Services.ASPWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        ISupplierBLL supplierBLL;

        public SupplierController(ISupplierBLL bll)
        {
            supplierBLL = bll;
        }

        List<SupplierDTO> SupplierDTOList(ICollection<Supplier> supplierList)
        {
            List<SupplierDTO> suppliers = new List<SupplierDTO>();
            foreach (Supplier item in supplierList)
            {
                suppliers.Add(new SupplierDTO
                {
                    SupplierID = item.ID,
                    CompanyName = item.CompanyName,
                    City = item.City,
                    Country = item.Country,
                    Address = item.Address,
                    PhoneNumber = item.PhoneNumber,
                    Email = item.Email
                });
            }
            return suppliers;
        }

        void NameControl(string CompanyName)
        {
            ICollection<Supplier> suppliers = supplierBLL.GetAll();
            foreach (Supplier item in suppliers)
            {
                if (item.CompanyName == CompanyName)
                {
                    throw new Exception($"{item.CompanyName} isimli bir tedarikçi zaten mevcut.");
                }
            }
        }

        public IActionResult GetSuppliers()
        {
            List<SupplierDTO> suppliers = SupplierDTOList(supplierBLL.GetSuppliers());
            return Ok(suppliers);
        }

        public IActionResult GetActiveSuppliers()
        {
            List<SupplierDTO> suppliers = SupplierDTOList(supplierBLL.GetActiveSuppliers());
            return Ok(suppliers);
        }

        public IActionResult GetAllSuppliers()
        {
            List<SupplierDTO> suppliers = SupplierDTOList(supplierBLL.GetAll());
            return Ok(suppliers);
        }

        [HttpGet("{id}")]
        public IActionResult GetSupplierByID(int id)
        {
            Supplier supplier = supplierBLL.Get(id);
            SupplierDTO supplierDTO = new SupplierDTO();
            supplierDTO.SupplierID = supplier.ID;
            supplierDTO.CompanyName = supplier.CompanyName;
            supplierDTO.City = supplier.City;
            supplierDTO.Country = supplier.Country;
            supplierDTO.Address = supplier.Address;
            supplierDTO.PhoneNumber = supplier.PhoneNumber;
            supplierDTO.Email = supplier.Email;
            return Ok(supplierDTO);
        }

        [HttpPost]
        public IActionResult UpdateSupplier([FromBody] SupplierDTO itemDTO)
        {
            try
            {
                Supplier supplier = supplierBLL.Get(itemDTO.SupplierID);
                supplier.CompanyName = itemDTO.CompanyName;
                supplier.City = itemDTO.City;
                supplier.Country = itemDTO.Country;
                supplier.Address = itemDTO.Address;
                supplier.PhoneNumber = itemDTO.PhoneNumber;
                supplier.Email = itemDTO.Email;
                return Ok(new { message = "Tedarikçi gğncellendi.", check = true });


            }
            catch (Exception ex)
            {

                return Ok(new { message = ex.Message, check = false });
            }
        }

        [HttpPost]
        public IActionResult AddSupplier([FromBody] SupplierDTO itemDTO)
        {
            try
            {
                NameControl(itemDTO.CompanyName);
                Supplier supplier = new Supplier();

                supplier.ID = itemDTO.SupplierID;
                supplier.CompanyName = itemDTO.CompanyName;
                supplier.City = itemDTO.City;
                supplier.Country = itemDTO.Country;
                supplier.Address = itemDTO.Address;
                supplier.PhoneNumber = itemDTO.PhoneNumber;
                supplier.Email = itemDTO.Email;
                supplierBLL.Insert(supplier);
                return Ok(new { message = "Tedarikçi başarı ile eklendi.", check = true });
            }
            catch (Exception ex)
            {

                return Ok(new { message = ex.Message, check = false });
            }
        }

        [HttpGet("{id}")]
        public IActionResult DeleteSupplier(int id)
        {
            supplierBLL.DeleteByID(id);
            return Ok(new { message = "Tedarikçi silindi.", check = true });
        }
    }
}
