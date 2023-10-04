using Azure;
using SDG.SpookyWisconsin.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.BL.Test
{
    [TestClass]
    public class utHauntedLocation
    {
        [TestMethod]
        public void InsertTest()
        {
            HauntedLocation hauntedLocation = new HauntedLocation
            {
                AddressId = 1,
                CountyId = 2,
                Name = "Appleton"
            };
            Assert.AreEqual(1, HauntedLocationManager.Insert(hauntedLocation, true));
        }

        [TestMethod]
        public void UpdateTest()
        {
            HauntedLocation hauntedlocation = HauntedLocationManager.LoadById(2);
            hauntedlocation.AddressId = 2;
            hauntedlocation.CountyId = 3;
            hauntedlocation.Name = "Test";
            int results = HauntedLocationManager.Update(hauntedlocation, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Assert.AreEqual(3, HauntedLocationManager.LoadById(3).Id);
        }

        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(5, HauntedLocationManager.Load().Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Assert.AreEqual(1, HauntedLocationManager.Delete(1, true));
        }
    }
}
