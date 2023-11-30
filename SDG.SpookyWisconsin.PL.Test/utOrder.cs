using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDG.SpookyWisconsin.PL.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.PL.Test
{
    [TestClass]
    public class utOrder : utBase
    {

        [TestMethod]
        public void LoadTest()
        {
            //How many I expected
            int expected = 3;
            //How many I did get back
            var orders = sc.tblOrders;

            Assert.AreEqual(expected, orders.Count());

        }

        [TestMethod]
        public void InsertTest()
        {
            // Create a new row in memory
            tblOrder newrow = new tblOrder();

            // Set the properties
            newrow.Id = Guid.NewGuid();
            //newrow.UserId = sc.tblCarts.FirstOrDefault().Id;
            newrow.OrderDate = new System.DateTime(2023, 12, 1);
            newrow.ShipDate = new System.DateTime(2023, 12, 7);


            // Insert row into table
            sc.tblOrders.Add(newrow);
            int result = sc.SaveChanges();

            Assert.AreEqual(1, result);

        }

        [TestMethod]
        public void UpdateTest()
        {
            InsertTest();
            // Get a row update
            //tblOrder row = sc.tblOrders.FirstOrDefault();

            if (row == null)
            {
                // Set the properties
                row.UserId = sc.tblCarts.FirstOrDefault().Id;

                // Update the row into table
                int result = sc.SaveChanges();

                Assert.AreEqual(1, result);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            InsertTest();

            tblOrder row = (from a in sc.tblOrders
                                 select a).FirstOrDefault();

            if (row == null)
            {
                sc.tblOrders.Remove(row);
                int result = sc.SaveChanges();
                Assert.IsTrue(result == 1);
            }

        }

    }
}
