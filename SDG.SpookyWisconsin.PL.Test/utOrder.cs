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
    public class utOrder
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

            var rows = sc.tblOrders;

            actual = rows.Count();

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void InsertTest()
        {
            // Create a new row in memory
            tblOrder newrow = new tblOrder();

            // Set the properties
            newrow.Id = -99;
            newrow.InCartId = 4;
            newrow.OrderDate = new System.DateTime(2023, 12, 1);
            newrow.DeliveryDate = new System.DateTime(2023, 12, 7);


            // Insert row into table
            sc.tblOrders.Add(newrow);
            int result = sc.SaveChanges();

            Assert.IsTrue(result == 1);

        }

        [TestMethod]
        public void UpdateTest()
        {
            // Get a row update
            tblOrder row = (from a in sc.tblOrders
                                 where a.Id == 2
                                 select a).FirstOrDefault();

            if (row == null)
            {
                // Set the properties
                row.InCartId = 2;

                // Update the row into table
                int result = sc.SaveChanges();

                Assert.IsTrue(result == 1);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblOrder row = (from a in sc.tblOrders
                                 where a.Id == 2
                                 select a).FirstOrDefault();

            if (row == null)
            {
                sc.tblOrders.Remove(row);
                int result = sc.SaveChanges(true);
                Assert.IsTrue(result == 1);
            }

        }

    }
}
