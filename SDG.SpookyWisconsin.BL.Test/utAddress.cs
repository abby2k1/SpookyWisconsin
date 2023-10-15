using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDG.SpookyWisconsin.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.BL.Test
{
    [TestClass]
    public class utAddress : utBase
    {
        [TestMethod]
        public void InsertTest()
        {
            Address address = new Address
            {
                Street = "2356 Elm St",
                City = "Appleton",
                State = "WI",
                County = "Outagamie",
                ZIP = "54911"
                
            };
           Guid result = new AddressManager(options).Load().FirstOrDefault().Id;
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Address address = new AddressManager(options).Load().FirstOrDefault();
            address.Street = "Test";

            Assert.IsTrue(new AddressManager(options).Update(address, true) > 0);

        }

        [TestMethod]
        public void LoadByIdTest()
        {
           Address addresses = new AddressManager(options).Load().FirstOrDefault();
            Assert.AreEqual(new AddressManager(options).LoadById(addresses.Id).Id, addresses.Id);
        }

        [TestMethod]
        public void LoadTest()
        {
            List<Address> addresses = new AddressManager(options).Load();
            int expected = 3;

            Assert.AreEqual(expected, addresses.Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Address address = new AddressManager(options).Load().FirstOrDefault();

            Assert.IsTrue(new AddressManager(options).Delete(address.Id, true) > 0);
        }



    }
}
