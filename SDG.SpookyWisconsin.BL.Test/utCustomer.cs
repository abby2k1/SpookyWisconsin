using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDG.SpookyWisconsin.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.BL.Test
{
    [TestClass]
    public class utCustomer : utBase
    {
        [TestMethod]
        public void InsertTest()
        {
            Customer customer = new Customer
            {
                MemberId = MemberManager.Load().FirstOrDefault().Id,
                UserId = UserManager.Load().FirstOrDefault().Id,
                FirstName = "Mark",
                LastName = "Johnson",
                AddressId = AddressManager.Load().FirstOrDefault().Id,
                Email = "Mark_Johnson@gmail.com"
            };
            int result = CustomerManager.Insert(customer, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Customer customer = CustomerManager.Load().FirstOrDefault();
            customer.FirstName = "Test";

            Assert.IsTrue(CustomerManager.Update(customer, true) > 0);

        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Customer customer = CustomerManager.Load().FirstOrDefault();

            Assert.AreEqual(CustomerManager.LoadById(customer.Id).Id, customer.Id);
        }

        [TestMethod]
        public void LoadTest()
        {
            List<Customer> customers = CustomerManager.Load();
            int expected = 8;

            Assert.AreEqual(expected, customers.Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Customer customer = CustomerManager.Load().FirstOrDefault();

            Assert.IsTrue(CustomerManager.Delete(customer.Id, true) > 0);
        }

    }
}
