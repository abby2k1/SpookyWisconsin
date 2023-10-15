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
            AddressManager.Insert(address);
            Guid result = AddressManager.Load().FirstOrDefault().Id;
            Assert.IsTrue(result != Guid.Empty);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Address address = AddressManager.Load().FirstOrDefault();
            address.Street = "Test";

            Assert.IsTrue(AddressManager.Update(address, true) > 0);

        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Guid id = AddressManager.Load().FirstOrDefault().Id;
            Address address = AddressManager.LoadById(id);
            Assert.AreEqual(id, address.Id);
        }

        [TestMethod]
        public void LoadTest()
        {
            List<Address> addresses = AddressManager.Load();
            int expected = 3;

            Assert.AreEqual(expected, addresses.Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Address address = AddressManager.Load().FirstOrDefault();

            Assert.IsTrue(AddressManager.Delete(address.Id, true) > 0);
        }



    }
}
