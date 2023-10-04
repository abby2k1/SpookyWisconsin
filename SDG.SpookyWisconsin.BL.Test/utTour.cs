using SDG.SpookyWisconsin.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.BL.Test
{
    [TestClass]
    public class utTour
    {
        [TestMethod]
        public void InsertTest()
        {
            Tour tour = new Tour
            {
                HauntedLocationId = 1, 
                TourName = "Spooky",
                Description = "Super scary"
            };
            Assert.AreEqual(1, TourManager.Insert(tour, true));
        }

        [TestMethod]
        public void UpdateTest()
        {
            Tour tour = TourManager.LoadById(2);
            tour.HauntedLocationId = 2;
            tour.TourName = "Test";
            tour.Description = "Test";

            int results = TourManager.Update(tour, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Assert.AreEqual(3, TourManager.LoadById(3).Id);
        }

        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(5, TourManager.Load().Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Assert.AreEqual(1, TourManager.Delete(1, true));
        }
    }
}
