using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDG.SpookyWisconsin.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.BL.Test
{
    [TestClass]
    public class utOrder : utBase
    {
        [TestMethod]
        public void InsertTest()
        {
            Order order = new Order
            { 
                CustomerId = CustomerManager.Load().FirstOrDefault().Id,
                OrderDate = DateTime.Now,
                DeliverDate = DateTime.Now
            };
            var result = OrderManager.Insert(order, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Order order = OrderManager.Load().FirstOrDefault();
            order.OrderDate = DateTime.Now;

            Assert.IsTrue(OrderManager.Update(order, true) > 0);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Order order = OrderManager.Load().FirstOrDefault();
            Assert.AreEqual(OrderManager.LoadById(order.Id).Id, order.Id);
        }

        [TestMethod]
        public void LoadTest()
        {
            List<Order> orders = OrderManager.Load();
            int expected = 2;

            Assert.AreEqual(expected, orders.Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Order order = OrderManager.Load().FirstOrDefault();
            Assert.IsTrue(OrderManager.Delete(order.Id, true) > 0);
        }
    }
}
