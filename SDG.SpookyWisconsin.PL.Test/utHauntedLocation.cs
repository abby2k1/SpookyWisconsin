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
    public class utHauntedLocation : utBase
    {

        [TestMethod]
        public void LoadTest()
        {
            //How many I expected
            int expected = 3;
            //How many I did get back
            var hauntedLocations = sc.tblHauntedLocations;
            Assert.AreEqual(expected, hauntedLocations.Count());

        }

        [TestMethod]
        public void InsertTest()
        {
            // Create a new row in memory
            tblHauntedLocation newrow = new tblHauntedLocation();

            // Set the properties
            newrow.Id = Guid.NewGuid();
            newrow.AddressId = sc.tblAddresses.FirstOrDefault().Id;
            newrow.Name = "Haunted";

            // Insert row into table
            sc.tblHauntedLocations.Add(newrow);
            int result = sc.SaveChanges();

            Assert.IsTrue(result == 1);

        }

        [TestMethod]
        public void UpdateTest()
        {
            InsertTest();

            // Get a row update
            tblHauntedLocation row = sc.tblHauntedLocations.FirstOrDefault();

            if (row == null)
            {
                // Set the properties
                row.AddressId = sc.tblAddresses.OrderByDescending(a => a.State).FirstOrDefault().Id;
                row.Name = "Test";

                // Update the row into table
                int result = sc.SaveChanges();

                Assert.AreEqual(1, result);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            InsertTest();

            tblHauntedLocation row = (from a in sc.tblHauntedLocations
                                   select a).FirstOrDefault();

            if (row == null)
            {
                sc.tblHauntedLocations.Remove(row);
                int result = sc.SaveChanges();
                Assert.IsTrue(result == 1);
            }

        }

    }
}
