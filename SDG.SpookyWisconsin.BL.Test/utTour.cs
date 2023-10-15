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
    public class utTour : utBase
    {
        [TestMethod]
        public void InsertTest()
        {
            Tour tour = new Tour
            {
                HauntedLocationId = HauntedLocationManager.Load().FirstOrDefault().Id, 
                TourName = "Spooky",
                Description = "Super scary"
            };
            int result = TourManager.Insert(tour, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Tour tour = TourManager.Load().FirstOrDefault();
            tour.Description = "Test";

            Assert.IsTrue(TourManager.Update(tour, true) > 0);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Tour tour = TourManager.Load().FirstOrDefault();
            Assert.AreEqual(TourManager.LoadById(tour.Id).Id, tour.Id);
        }

        [TestMethod]
        public void LoadTest()
        {
            List<Tour> tour = TourManager.Load();
            int expected = 3;

            Assert.AreEqual(expected, tour.Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Tour tour = TourManager.Load().FirstOrDefault();
            Assert.IsTrue(TourManager.Delete(tour.Id, true) > 0);
        }
    }
}
