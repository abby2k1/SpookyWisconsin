using SDG.SpookyWisconsin.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.BL.Test
{
    [TestClass]
    public class utAddress
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
            Assert.AreEqual(1, AddressManager.Insert(address, true));
        }

        [TestMethod]
        public void UpdateTest()
        {
            Address address = AddressManager.LoadById(2);
            address.Street = "Test";

            int results = AddressManager.Update(address, true);
            Assert.AreEqual(1, results);

        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Assert.AreEqual(3, AddressManager.LoadById(3).Id);
        }

        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(24, AddressManager.Load().Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Assert.AreEqual(1,  AddressManager.Delete(1, true));
        }



    }
}
