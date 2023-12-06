using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.PL.Test
{
    [TestClass]
    public class utTour : utBase
    {

        [TestMethod]
        public void LoadTest()
        {
            //How many I expected
            int expected = 3;
            //How many I did get back
            var tours = sc.tblTours;

            Assert.AreEqual(expected, tours.Count());

        }

        [TestMethod]
        public void InsertTest()
        {
            // Create a new row in memory
            tblTour newrow = new tblTour();

            // Set the properties
            newrow.Id = Guid.NewGuid();
            newrow.Description = "3 hour tour";
            newrow.HauntedLocationId = sc.tblHauntedLocations.FirstOrDefault().Id;

            // Insert row into table
            sc.tblTours.Add(newrow);
            int result = sc.SaveChanges();

            Assert.AreEqual(1, result);

        }

        [TestMethod]
        public void UpdateTest()
        {
            InsertTest();
            // Get a row update
            tblTour row = sc.tblTours.FirstOrDefault();

            if (row == null)
            {
                // Set the properties
                row.Description = "Test";
                row.HauntedLocationId = sc.tblHauntedLocations.OrderByDescending(h => h.Name).FirstOrDefault().Id;


                // Update the row into table
                int result = sc.SaveChanges();

                Assert.AreEqual(1, result);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            InsertTest();

            tblTour row = (from a in sc.tblTours
                           select a).FirstOrDefault();

            if (row == null)
            {
                sc.tblTours.Remove(row);
                int result = sc.SaveChanges();
                Assert.IsTrue(result == 1);
            }

        }

    }
}
