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
                HauntedLocationId = new HauntedLocationManager(options).Load().FirstOrDefault().Id, 
                TourName = "Spooky",
                Description = "Super scary"
            };
            int result = new TourManager(options).Insert(tour, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Tour tour = new TourManager(options).Load().FirstOrDefault();
            tour.Description = "Test";

            Assert.IsTrue(new TourManager(options).Update(tour, true) > 0);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Tour tour = new TourManager(options).Load().FirstOrDefault();
            Assert.AreEqual(new TourManager(options).LoadById(tour.Id).Id, tour.Id);
        }

        [TestMethod]
        public void LoadTest()
        {
            List<Tour> tour = new TourManager(options).Load();
            int expected = 3;

            Assert.AreEqual(expected, tour.Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Tour tour = new TourManager(options).Load().FirstOrDefault();
            Assert.IsTrue(new TourManager(options).Delete(tour.Id, tour) > 0);
        }
    }
}
