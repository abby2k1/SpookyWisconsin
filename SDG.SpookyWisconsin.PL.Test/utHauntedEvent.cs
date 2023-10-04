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
    public class utHauntedEvent
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

            var rows = sc.tblHauntedEvents;

            actual = rows.Count();

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void InsertTest()
        {
            // Create a new row in memory
            tblHauntedEvent newrow = new tblHauntedEvent();

            // Set the properties
            newrow.Id = -99;
            newrow.HauntedLocationId = 2;
            newrow.ParticipantId = 3;
            newrow.Date = new System.DateTime(2022, 6, 12);
            newrow.Description = "Bridge";

            // Insert row into table
            sc.tblHauntedEvents.Add(newrow);
            int result = sc.SaveChanges();

            Assert.IsTrue(result == 1);

        }

        [TestMethod]
        public void UpdateTest()
        {
            // Get a row update
            tblHauntedEvent row = (from a in sc.tblHauntedEvents
                              where a.Id == 2
                              select a).FirstOrDefault();

            if (row == null)
            {
                // Set the properties
                row.HauntedLocationId = 3;
                row.ParticipantId = 1;
                row.Description = "Bridge";

                // Update the row into table
                int result = sc.SaveChanges();

                Assert.IsTrue(result == 1);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblHauntedEvent row = (from a in sc.tblHauntedEvents
                              where a.Id == 2
                              select a).FirstOrDefault();

            if (row == null)
            {
                sc.tblHauntedEvents.Remove(row);
                int result = sc.SaveChanges(true);
                Assert.IsTrue(result == 1);
            }

        }

    }

}
