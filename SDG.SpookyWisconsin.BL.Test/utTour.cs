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
        List<Tour> tours = TourManager.Load();
        List<HauntedLocation> hauntedLocation = HauntedLocationManager.Load();

        [TestMethod]
        public void InsertTest()
        {
            Tour tour = new Tour
            {
                HauntedLocationId = hauntedLocation.FirstOrDefault().Id, 
                TourName = "Spooky",
                Description = "Super scary"
            };
            int result = TourManager.Insert(tour, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Tour tour = tours.FirstOrDefault();
            tour.Description = "Test";

            Assert.IsTrue(TourManager.Update(tour, true) > 0);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Tour tour = tours.FirstOrDefault();
            Assert.AreEqual(TourManager.LoadById(tour.Id).Id, tour.Id);
        }

        [TestMethod]
        public void LoadTest()
        {
            List<Tour> tour = tours;
            int expected = 3;

            Assert.AreEqual(expected, tour.Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Tour tour = tours.FirstOrDefault();
            Assert.IsTrue(TourManager.Delete(tour.Id, tour) > 0);
        }
    }
}
