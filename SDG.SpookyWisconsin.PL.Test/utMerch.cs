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
    public class utMerch
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

            var rows = sc.tblMerches;

            actual = rows.Count();

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void InsertTest()
        {
            // Create a new row in memory
            tblMerch newrow = new tblMerch();

            // Set the properties
            newrow.Id = -99;
            newrow.MerchName = "Skull";
            newrow.InStkQty = 65;
            newrow.Description = "hoodie";
            newrow.Cost = 1;


            // Insert row into table
            sc.tblMerches.Add(newrow);
            int result = sc.SaveChanges();

            Assert.IsTrue(result == 1);

        }

        [TestMethod]
        public void UpdateTest()
        {
            // Get a row update
            tblMerch row = (from a in sc.tblMerches
                            where a.Id == 2
                             select a).FirstOrDefault();

            if (row == null)
            {
                // Set the properties
                row.MerchName = "Test";
                row.InStkQty = 40;
                row.Description = "Test";
                row.Cost = 32;

                // Update the row into table
                int result = sc.SaveChanges();

                Assert.IsTrue(result == 1);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblMerch row = (from a in sc.tblMerches
                            where a.Id == 2
                             select a).FirstOrDefault();

            if (row == null)
            {
                sc.tblMerches.Remove(row);
                int result = sc.SaveChanges(true);
                Assert.IsTrue(result == 1);
            }

        }

    }
}
