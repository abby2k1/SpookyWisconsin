using Microsoft.EntityFrameworkCore.Metadata;
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
        List<Member> members = MemberManager.Load();
        List<User> users = UserManager.Load();
        List<Address> addresses = AddressManager.Load();
        List<Customer> customers = CustomerManager.Load();

        [TestMethod]
        public void InsertTest()
        {
            
            Customer customer = new Customer
            {
                
                MemberId = members.FirstOrDefault().Id,
                UserId = users.FirstOrDefault().Id,
                FirstName = "Mark",
                LastName = "Johnson",
                AddressId = addresses.FirstOrDefault().Id,
                Email = "Mark_Johnson@gmail.com"
            };
            //int result = new CustomerManager(options).Insert(customer, true);
            int result = CustomerManager.Insert(customer, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Customer customer = customers.FirstOrDefault();
            customer.FirstName = "Test";

            Assert.IsTrue(CustomerManager.Update(customer, true) > 0);

        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Customer customer = customers.FirstOrDefault();

            Assert.AreEqual(CustomerManager.LoadById(customer.Id).Id, customer.Id);
        }

        [TestMethod]
        public void LoadTest()
        {
            List<Customer> customer = customers;
            int expected = 8;

            Assert.AreEqual(expected, customer.Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Customer customer = customers.FirstOrDefault();

            Assert.IsTrue(CustomerManager.Delete(customer.Id, true) > 0);
        }

    }
}
