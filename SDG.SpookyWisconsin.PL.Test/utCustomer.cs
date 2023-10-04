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
    public class utCustomer
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

            var rows = sc.tblCustomers;

            actual = rows.Count();

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void InsertTest()
        {
            // Create a new row in memory
            tblCustomer newrow = new tblCustomer();

            // Set the properties
            newrow.Id = -99;
            newrow.MemberId = 2;
            newrow.Firstname = "Sam";
            newrow.Lastname = "Park";
            newrow.AddressId = 1;
            newrow.Email = "Park01_Sam@gmail.com";

            // Insert row into table
            sc.tblCustomers.Add(newrow);
            int result = sc.SaveChanges();

            Assert.IsTrue(result == 1);

        }

        [TestMethod]
        public void UpdateTest()
        {
            // Get a row update
            tblCustomer row = (from c in sc.tblCustomers
                              where c.Id == 2
                              select c).FirstOrDefault();

            if (row == null)
            {
                // Set the properties
                row.MemberId = 5;
                row.Firstname = "Test";
                row.Lastname = "Test";
                row.AddressId = 2;
                row.Email = "Test";

                // Update the row into table
                int result = sc.SaveChanges();

                Assert.IsTrue(result == 1);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblCustomer row = (from c in sc.tblCustomers
                              where c.Id == 2
                              select c).FirstOrDefault();

            if (row == null)
            {
                sc.tblCustomers.Remove(row);
                int result = sc.SaveChanges(true);
                Assert.IsTrue(result == 1);
            }

        }

    }

}
}
