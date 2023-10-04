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
    public class utNewsLetter
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

            var rows = sc.tblNewsLetter;

            actual = rows.Count();

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void InsertTest()
        {
            // Create a new row in memory
            tblNewsLetter newrow = new tblNewsLetter();

            // Set the properties
            newrow.Id = -99;
            newrow.HauntedEventId = 4;
            newrow.Description = "Ghost located after 3 am";
            newrow.Date = new System.DateTime(2023, 4, 8);


            // Insert row into table
            sc.tblNewsLetter.Add(newrow);
            int result = sc.SaveChanges();

            Assert.IsTrue(result == 1);

        }

        [TestMethod]
        public void UpdateTest()
        {
            // Get a row update
            tblNewsLetter row = (from a in sc.tblNewsLetter
                                 where a.Id == 2
                            select a).FirstOrDefault();

            if (row == null)
            {
                // Set the properties
                row.HauntedEventId = 3;
                row.Description = "Test";

                // Update the row into table
                int result = sc.SaveChanges();

                Assert.IsTrue(result == 1);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblNewsLetter row = (from a in sc.tblNewsLetter
                                 where a.Id == 2
                            select a).FirstOrDefault();

            if (row == null)
            {
                sc.tblNewsLetter.Remove(row);
                int result = sc.SaveChanges(true);
                Assert.IsTrue(result == 1);
            }

        }

    }
}
