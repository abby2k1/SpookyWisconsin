using SDG.SpookyWisconsin.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.BL.Test
{
    [TestClass]
    public class utCustomer
    {
        [TestMethod]
        public void InsertTest()
        {
            Customer customer = new Customer
            {
                MemberId = 2,
                UserId = 3,
                FirstName = "Mark",
                LastName = "Johnson",
                AddressId = 2,
                Email = "Mark_Johnson@gmail.com"
            };
            Assert.AreEqual(1, CustomerManager.ReferenceEquals(customer, true));
        }

        [TestMethod]
        public void UpdateTest()
        {
            Customer customer = CustomerManager.LoadById(2);
            customer.MemberId = 1;
            customer.UserId = 2;
            customer.FirstName = "Test";
            customer.LastName = "Test";
            customer.AddressId = 1;
            customer.Email = "Test";

            int results = CustomerManager.Update(customer, true);
            Assert.AreEqual(1, results);

        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Assert.AreEqual(4, CustomerManager.LoadById(4).Id);
        }

        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(3, CustomerManager.Load().Count());
        }

        [TestMethod]
        public void DeleteTest()
        {
            Assert.AreEqual(1, CustomerManager.Delete(1, true));
        }

    }
}
