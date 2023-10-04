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
    public class utAddress
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

            var rows = sc.tblAddresses;

            actual = rows.Count();

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void InsertTest()
        {
            // Create a new row in memory
            tblAddress newrow = new tblAddress(); 

            // Set the properties
            newrow.Id = -99;
            newrow.Street = "456 Wing Road";
            newrow.City = "Oshkosh";
            newrow.State = "WI";
            newrow.County = "Winnebago";
            newrow.ZIP = "54906";

            // Insert row into table
            sc.tblAddresses.Add(newrow);
            int result = sc.SaveChanges();

            Assert.IsTrue(result == 1);

        }

        [TestMethod]
        public void UpdateTest()
        {
            // Get a row update
            tblAddress row = (from a in sc.tblAddresses
                              where  a.Id == 2
                              select a).FirstOrDefault();

            if (row == null)
            {
                // Set the properties
                row.Street = "Test";
                row.City = "Test";
                row.State = "Test";
                row.County = "Test";
                row.ZIP = "Test";

                // Update the row into table
                int result = sc.SaveChanges();

                Assert.IsTrue(result == 1);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblAddress row = (from a in sc.tblAddresses 
                              where a.Id == 2
                              select a).FirstOrDefault();

            if (row == null)
            {
                sc.tblAddresses.Remove(row);
                int result = sc.SaveChanges(true);
                Assert.IsTrue(result == 1);
            }

        }


    }
}
