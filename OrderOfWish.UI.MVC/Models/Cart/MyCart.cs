using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderOfWish.UI.MVC.Models.Cart
{
    public class MyCart
    {
        static private Dictionary<int, CartItem> sepet = new Dictionary<int, CartItem>();

        public List<CartItem> GetAllCartItem => sepet.Values.ToList();

        public void AddCart(CartItem cartItem)
        {
            if (sepet.ContainsKey(cartItem.ID))
            {
                sepet[cartItem.ID].Amout += cartItem.Amout;
                return;
            }
            sepet.Add(cartItem.ID, cartItem);
        }

        public void Update(int id, short amout)
        {
            if (sepet.ContainsKey(id))
            {
                sepet[id].Amout = amout;
            }
        }

        public void Delete(int id)
        {
            if (sepet.ContainsKey(id))
            {
                sepet.Remove(id);
            }
        }

        public int TotalAmout => sepet.Values.Sum(a => a.Amout);

        public decimal SubTotal => sepet.Values.Sum(a => a.SubTotal);
    }
}
