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
                MemberId = new MemberManager(options).Load().FirstOrDefault().Id,
                UserId = new UserManager(options).Load().FirstOrDefault().Id,
                FirstName = "Mark",
                LastName = "Johnson",
                AddressId = new AddressManager(options).Load().FirstOrDefault().Id,
                Email = "Mark_Johnson@gmail.com"
            };
            int result = new CustomerManager(options).Insert(customer, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Customer customer = new CustomerManager(options).Load().FirstOrDefault();
            customer.FirstName = "Test";

            Assert.IsTrue(new CustomerManager(options).Update(customer, true) > 0);

        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Customer customer = new CustomerManager(options).Load().FirstOrDefault();

            Assert.AreEqual(new CustomerManager(options).LoadById(customer.Id).Id, customer.Id);
        }

        [TestMethod]
        public void LoadTest()
        {
            List<Customer> customers = new CustomerManager(options).Load();
            int expected = 8;

            Assert.AreEqual(expected, customers.Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Customer customer = new CustomerManager(options).Load().FirstOrDefault();

            Assert.IsTrue(new CustomerManager(options).Delete(customer.Id, true) > 0);
        }

    }
}
