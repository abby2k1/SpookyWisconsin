using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SDG.SpookyWisconsin.BL.Models;
using SDG.SpookyWisconsin.PL;
using SDG.SpookyWisconsin.PL.Entities;
using SGD.SpookyWisconsin.BL;

namespace SDG.SpookyWisconsin.BL
{
    public class CartManager : GenericManager<tblCart>
    {
        private const string NOTFOUND_MESSAGE = "Row does not exist";

        DbContextOptions<SpookyWisconsinEntities> options;
        public CartManager(DbContextOptions<SpookyWisconsinEntities> options)
        {
            this.options = options;
        }

        public static void Checkout(Cart cart)
        {
            Order order = new Order();
            order.Id = new Guid();
            order.CustomerId = cart.CustomerId;
            order.OrderDate = DateTime.Now;
            order.DeliverDate = DateTime.Now.AddDays(2); 
            OrderManager.Insert(order);
        }

        public void Add(Cart cart) //(Cart cart, Item item)
        {
            //if (!cart.Items.Any(n => n.Id == item.Id))
            //    cart.Add(item);
            //else
            //    cart.Items.Where(n => n.Id == item.Id).FirstOrDefault().Quantity++;
        }

        public void Remove(Cart cart) //(Cart cart, Item item)
        {
            //cart.Remove(item);
        }
    }
}
