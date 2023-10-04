using Microsoft.EntityFrameworkCore.Storage;
using SDG.SpookyWisconsin.PL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.PL.Test
{
    [TestClass]
    public class utHauntedLocation
    {
        protected SpookyWisconsinEntities sc;
        protected IDbContextTransaction transaction;

        [TestInitialize]
        public void TestInitialize()
        {
            sc = new SpookyWisconsinEntities();
            transaction = sc.Database.BeginTransaction();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            transaction.Rollback();
            transaction.Dispose();
        }

        [TestMethod]
        public void LoadTest()
        {
            //How many I expected
            int expected = 3;
            //How many I did get back
            int actual;

            var rows = sc.tblHauntedLocations;

            actual = rows.Count();

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void InsertTest()
        {
            // Create a new row in memory
            tblHauntedLocation newrow = new tblHauntedLocation();

            // Set the properties
            newrow.Id = -99;
            newrow.AddressId = 2;
            newrow.Name = "Haunted";

            // Insert row into table
            sc.tblHauntedLocations.Add(newrow);
            int result = sc.SaveChanges();

            Assert.IsTrue(result == 1);

        }

        [TestMethod]
        public void UpdateTest()
        {
            // Get a row update
            tblHauntedLocation row = (from a in sc.tblHauntedLocations
                                   where a.Id == 2
                                   select a).FirstOrDefault();

            if (row == null)
            {
                // Set the properties
                row.AddressId = 2;
                row.Name = "Test";

                // Update the row into table
                int result = sc.SaveChanges();

                Assert.IsTrue(result == 1);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblHauntedLocation row = (from a in sc.tblHauntedLocations
                                   where a.Id == 2
                                   select a).FirstOrDefault();

            if (row == null)
            {
                sc.tblHauntedLocations.Remove(row);
                int result = sc.SaveChanges(true);
                Assert.IsTrue(result == 1);
            }

        }

    }
}
