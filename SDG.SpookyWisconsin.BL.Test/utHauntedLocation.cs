using Azure;
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
    public class utHauntedLocation : utBase
    {
        List<Address> addresses = AddressManager.Load();
        List<HauntedLocation> hauntedLocations = HauntedLocationManager.Load();

        [TestMethod]
        public void InsertTest()
        {
            HauntedLocation hauntedLocation = new HauntedLocation
            {
                AddressId = addresses.FirstOrDefault().Id,
                Name = "Appleton"
            };
            int result = HauntedLocationManager.Insert(hauntedLocation, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            HauntedLocation hauntedlocation = hauntedLocations.FirstOrDefault();
            hauntedlocation.Name = "Test";
            Assert.IsTrue(HauntedLocationManager.Delete(hauntedlocation.Id, true) > 0);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            HauntedLocation hauntedLocation = hauntedLocations.FirstOrDefault();
            Assert.AreEqual(HauntedLocationManager.LoadById(hauntedLocation.Id).Id, hauntedLocation.Id);
        }

        [TestMethod]
        public void LoadTest()
        {
            List<HauntedLocation> hauntedLocation = hauntedLocations;
            int expected = 6;

            Assert.AreEqual(expected, hauntedLocation.Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            HauntedLocation hauntedLocation = hauntedLocations.FirstOrDefault();
            Assert.IsTrue(HauntedLocationManager.Delete(hauntedLocation.Id, true) > 0);    
        }
    }
}
