using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.PL.Test
{
    [TestClass]
    public class utMerch : utBase
    {

        [TestMethod]
        public void LoadTest()
        {
            //How many I expected
            int expected = 3;
            //How many I did get back
            var merches = sc.tblMerches;

            Assert.AreEqual(expected, merches.Count());

        }

        [TestMethod]
        public void InsertTest()
        {
            // Create a new row in memory
            tblMerch newrow = new tblMerch();

            // Set the properties
            newrow.Id = Guid.NewGuid();
            newrow.MerchName = "Skull";
            newrow.InStkQty = 65;
            newrow.Description = "hoodie";
            newrow.Cost = 1;


            // Insert row into table
            sc.tblMerches.Add(newrow);
            int result = sc.SaveChanges();

            Assert.AreEqual(1, result);

        }

        [TestMethod]
        public void UpdateTest()
        {
            InsertTest();
            // Get a row update
            tblMerch row = sc.tblMerches.FirstOrDefault();

            if (row == null)
            {
                // Set the properties
                row.MerchName = "Test";
                row.InStkQty = 40;
                row.Description = "Test";
                row.Cost = 32;

                // Update the row into table
                int result = sc.SaveChanges();

                Assert.AreEqual(1, result);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            InsertTest();

            tblMerch row = (from a in sc.tblMerches
                             select a).FirstOrDefault();

            if (row == null)
            {
                sc.tblMerches.Remove(row);
                int result = sc.SaveChanges();
                Assert.IsTrue(result == 1);
            }

        }

    }
}
