using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDG.SpookyWisconsin.PL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.PL.Test
{
    [TestClass]
    public class utParticipant : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            //How many I expected
            int expected = 3;
            //How many I did get back
            var participants = sc.tblParticipants;

            Assert.AreEqual(expected, participants.Count());

        }

        [TestMethod]
        public void InsertTest()
        {
            // Create a new row in memory
            tblParticipant newrow = new tblParticipant();

            // Set the properties
            newrow.Id = Guid.NewGuid();
            newrow.HauntedEventId = sc.tblHauntedEvents.FirstOrDefault().Id;
            newrow.CustomerId = sc.tblCustomers.FirstOrDefault().Id;


            // Insert row into table
            sc.tblParticipants.Add(newrow);
            int result = sc.SaveChanges();

            Assert.AreEqual(1, result);

        }

        [TestMethod]
        public void UpdateTest()
        {
            InsertTest();
            // Get a row update
            tblParticipant row = sc.tblParticipants.FirstOrDefault();

            if (row == null)
            {
                // Set the properties
                row.HauntedEventId = sc.tblHauntedEvents.FirstOrDefault().Id;
                row.CustomerId = sc.tblCustomers.OrderByDescending(c => c.Lastname).FirstOrDefault().Id;

                // Update the row into table
                int result = sc.SaveChanges();

                Assert.AreEqual(1, result);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            InsertTest();

            tblParticipant row = (from a in sc.tblParticipants
                            select a).FirstOrDefault();

            if (row == null)
            {
                sc.tblParticipants.Remove(row);
                int result = sc.SaveChanges();
                Assert.IsTrue(result == 1);
            }

        }

    }
}
