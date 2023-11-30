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
                CustomerId = new CustomerManager(options).Load().FirstOrDefault().Id,
                OrderDate = DateTime.Now,
                ShipDate = DateTime.Now
            };
            var result = new OrderManager(options).Insert(order, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Order order = new OrderManager(options).Load().FirstOrDefault();
            order.OrderDate = DateTime.Now;

            Assert.IsTrue(new OrderManager(options).Update(order, true) > 0);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Order order = new OrderManager(options).Load().FirstOrDefault();
            Assert.AreEqual(new OrderManager(options).LoadById(order.Id).Id, order.Id);
        }

        [TestMethod]
        public void LoadTest()
        {
            List<Order> orders = new OrderManager(options).Load();
            int expected = 2;

            Assert.AreEqual(expected, orders.Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Order order = new OrderManager(options).Load().FirstOrDefault();
            Assert.IsTrue(new OrderManager(options).Delete(order.Id, true) > 0);
        }
    }
}
