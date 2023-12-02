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
        List<Order> orders = OrderManager.Load();
        List<Customer> customers = CustomerManager.Load();

        [TestMethod]
        public void InsertTest()
        {
            Order order = new Order
            { 
                CustomerId = customers.FirstOrDefault().Id,
                OrderDate = DateTime.Now,
                ShipDate = DateTime.Now
            };
            var result = OrderManager.Insert(order, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Order order = orders.FirstOrDefault();
            order.OrderDate = DateTime.Now;

            Assert.IsTrue(OrderManager.Update(order, true) > 0);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Order order = orders.FirstOrDefault();
            Assert.AreEqual(OrderManager.LoadById(order.Id).Id, order.Id);
        }

        [TestMethod]
        public void LoadTest()
        {
            List<Order> order = orders;
            int expected = 2;

            Assert.AreEqual(expected, order.Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Order order = orders.FirstOrDefault();
            Assert.IsTrue(OrderManager.Delete(order.Id, true) > 0);
        }
    }
}
