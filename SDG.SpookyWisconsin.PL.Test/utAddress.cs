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
    public class utAddress : utBase
    {

        [TestMethod]
        public void LoadTest()
        {
            //How many I expected
            int expected = 3;
            //How many I did get back
            var addresses = sc.tblAddresses;

            Assert.AreEqual(expected, addresses.Count());

        }

        [TestMethod]
        public void InsertTest()
        {
            // Create a new row in memory
            tblAddress newrow = new tblAddress(); 

            // Set the properties
            newrow.Id = Guid.NewGuid();
            newrow.Street = "456 Wing Road";
            newrow.City = "Oshkosh";
            newrow.State = "WI";
            newrow.County = "Winnebago";
            newrow.ZIP = "54906";

            // Insert row into table
            sc.tblAddresses.Add(newrow);
            int result = sc.SaveChanges();

            Assert.AreEqual(1, result);

        }

        [TestMethod]
        public void UpdateTest()
        {
            InsertTest();

            // Get a row update
            tblAddress row = sc.tblAddresses.FirstOrDefault();

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

                Assert.AreEqual(1, result);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            InsertTest();

            tblAddress row = (from a in sc.tblAddresses 
                              select a).FirstOrDefault();

            if (row == null)
            {
                sc.tblAddresses.Remove(row);
                int result = sc.SaveChanges();
                Assert.IsTrue(result == 1);
            }

        }


    }
}
