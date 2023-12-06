using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.PL.Test
{
    [TestClass]
    public class utHauntedEvent : utBase
    {

        [TestMethod]
        public void LoadTest()
        {
            //How many I expected
            int expected = 3;
            //How many I did get back
            var hauntedEvents = sc.tblHauntedEvents;
            Assert.AreEqual(expected, hauntedEvents.Count());

        }

        [TestMethod]
        public void InsertTest()
        {
            // Create a new row in memory
            tblHauntedEvent newrow = new tblHauntedEvent();

            // Set the properties
            newrow.Id = Guid.NewGuid();
            newrow.HauntedLocationId = sc.tblHauntedLocations.FirstOrDefault().Id;
            newrow.ParticipantId = sc.tblParticipants.FirstOrDefault().Id;
            newrow.Date = new System.DateTime(2022, 6, 12);
            newrow.Description = "Bridge";

            // Insert row into table
            sc.tblHauntedEvents.Add(newrow);
            int result = sc.SaveChanges();

            Assert.AreEqual(1, result);

        }

        [TestMethod]
        public void UpdateTest()
        {
            InsertTest();

            // Get a row update
            tblHauntedEvent row = sc.tblHauntedEvents.FirstOrDefault();
            if (row == null)
            {
                // Set the properties
                row.HauntedLocationId = sc.tblHauntedLocations.OrderByDescending(h => h.Name).FirstOrDefault().Id;
                row.ParticipantId = sc.tblParticipants.FirstOrDefault().Id;
                row.Description = "Bridge";

                // Update the row into table
                int result = sc.SaveChanges();

                Assert.AreEqual(1, result);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            InsertTest();

            tblHauntedEvent row = (from a in sc.tblHauntedEvents
                              select a).FirstOrDefault();

            if (row == null)
            {
                sc.tblHauntedEvents.Remove(row);
                int result = sc.SaveChanges();
                Assert.IsTrue(result == 1);
            }

        }

    }

}
