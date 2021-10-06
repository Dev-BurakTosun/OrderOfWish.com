using OrderOfWish.BLL.Abstract;
using OrderOfWish.DAL.Abstract;
using OrderOfWish.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderOfWish.BLL.Concrete
{
    class OrderService : IOrderBLL
    {
        IOrderDAL orderDAL;

        public OrderService(IOrderDAL dal)
        {
            orderDAL =dal;
        }

        void Check(Order order)
        {
            if (order.OrderDate < DateTime.Now)
            {
                throw new Exception("Sipariş tarihi bugünün tarihinden sonra olmalıdır.");
            }
        }

        void CheckShipAddres(Order order)
        {
            if (order.ShipAddress == null)
            {
                throw new Exception("Teslim adresi boş geçilemez.");
            }
        }
        public void Insert(Order entity)
        {
            CheckShipAddres(entity);
            Check(entity);
            orderDAL.Add(entity);
        }

        public void Update(Order entity)
        {
            CheckShipAddres(entity);
            Check(entity);
            orderDAL.Update(entity);
        }
        public void Delete(Order entity)
        {
            entity.IsActive = false;
            orderDAL.Update(entity);
        }

        public void DeleteByID(int entityID)
        {
            Order order = Get(entityID);
            order.IsActive = false;
            orderDAL.Update(order);
        }

        public Order Get(int entityID)
        {

            return orderDAL.Get(a => a.ID == entityID);
        }

        public ICollection<Order> GetAll()
        {
            return orderDAL.GetAll();
        }


    }
}
