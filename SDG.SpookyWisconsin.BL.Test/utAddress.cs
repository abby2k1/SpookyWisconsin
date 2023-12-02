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
        List<Address> addresses = AddressManager.Load();

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
            int result = AddressManager.Insert(address, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Address address = addresses.FirstOrDefault();
            address.Street = "Test";

            Assert.IsTrue(AddressManager.Update(address, true) > 0);

        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Address address = addresses.FirstOrDefault();
            Assert.AreEqual(AddressManager.LoadById(address.Id).Id, address.Id);
        }

        [TestMethod]
        public void LoadTest()
        {
            List<Address> address = addresses;
            int expected = 3;
            Assert.AreEqual(expected, address.Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Address address = addresses
                               .Where(d => d.Street == "Other")
                               .FirstOrDefault();

            Assert.IsTrue(AddressManager.Delete(address.Id, true) > 0);
        }



    }
}
