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
        [TestMethod]
        public void InsertTest()
        {
            HauntedLocation hauntedLocation = new HauntedLocation
            {
                AddressId = new AddressManager(options).Load().FirstOrDefault().Id,
                Name = "Appleton"
            };
            int result = new HauntedLocationManager(options).Insert(hauntedLocation, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            HauntedLocation hauntedlocation = new HauntedLocationManager(options).Load().FirstOrDefault();
            hauntedlocation.Name = "Test";
            Assert.IsTrue(new HauntedLocationManager(options).Delete(hauntedlocation.Id, true) > 0);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            HauntedLocation hauntedLocation = new HauntedLocationManager(options).Load().FirstOrDefault();
            Assert.AreEqual(new HauntedLocationManager(options).LoadById(hauntedLocation.Id).Id, hauntedLocation.Id);
        }

        [TestMethod]
        public void LoadTest()
        {
            List<HauntedLocation> hauntedLocations = new HauntedLocationManager(options).Load();
            int expected = 6;

            Assert.AreEqual(expected, hauntedLocations.Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            HauntedLocation hauntedLocation = new HauntedLocationManager(options).Load().FirstOrDefault();
            Assert.IsTrue(new HauntedLocationManager(options).Delete(hauntedLocation.Id, true) > 0);    
        }
    }
}
