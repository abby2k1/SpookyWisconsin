using SDG.SpookyWisconsin.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.BL.Test
{
    [TestClass]
    public class utOrder
    {
        [TestMethod]
        public void InsertTest()
        {
            Order order = new Order
            {
                CartId = 1,
                CustomerId = 2,
                OrderDate = DateTime.Now,
                DeliverDate = DateTime.Now
            };
            Assert.AreEqual(1, OrderManager.Insert(order, true));
        }

        [TestMethod]
        public void UpdateTest()
        {
            Order order = OrderManager.LoadById(2);
            order.OrderDate = DateTime.Now;
            order.DeliverDate = DateTime.Now;
            order.CustomerId = 1;
            order.CartId = 2;

            int results = OrderManager.Update(order, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Assert.AreEqual(3, OrderManager.LoadById(3).Id);
        }

        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(5, OrderManager.Load().Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Assert.AreEqual(1, OrderManager.Delete(1, true));
        }
    }
}
