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
    public class utTier : utBase
    {

        [TestMethod]
        public void LoadTest()
        {
            //How many I expected
            int expected = 3;
            //How many I did get back
            var tiers = sc.tblTier;

            Assert.AreEqual(expected, tiers.Count());

        }

        [TestMethod]
        public void InsertTest()
        {
            // Create a new row in memory
            tblTier newrow = new tblTier();

            // Set the properties
            newrow.Id = Guid.NewGuid();
            newrow.TierName = "Pro";
            newrow.TierLevel = 3;

            // Insert row into table
            sc.tblTier.Add(newrow);
            int result = sc.SaveChanges();

            Assert.AreEqual(1, result);

        }

        [TestMethod]
        public void UpdateTest()
        {
            InsertTest();
            // Get a row update
            tblTier row = sc.tblTier.FirstOrDefault();

            if (row == null)
            {
                // Set the properties
                row.TierName = "Test";
                row.TierLevel = 1;


                // Update the row into table
                int result = sc.SaveChanges();

                Assert.AreEqual(1, result);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            InsertTest();

            tblTier row = (from a in sc.tblTier
                                  select a).FirstOrDefault();

            if (row == null)
            {
                sc.tblTier.Remove(row);
                int result = sc.SaveChanges();
                Assert.IsTrue(result == 1);
            }

        }

    }
}
