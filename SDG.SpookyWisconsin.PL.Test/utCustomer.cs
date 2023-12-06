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
    public class utCustomer : utBase
    {

        [TestMethod]
        public void LoadTest()
        {
            //How many I expected
            int expected = 3;
            //How many I did get back
            var customers = sc.tblCustomers;

            Assert.AreEqual(expected, customers.Count());

        }

        [TestMethod]
        public void InsertTest()
        {
            // Create a new row in memory
            tblCustomer newrow = new tblCustomer();

            // Set the properties
            newrow.Id = Guid.NewGuid();
            newrow.MemberId = sc.tblMemberships.FirstOrDefault().Id;
            newrow.Firstname = "Sam";
            newrow.Lastname = "Park";
            newrow.AddressId = sc.tblAddresses.FirstOrDefault().Id;
            newrow.Email = "Park01_Sam@gmail.com";

            // Insert row into table
            sc.tblCustomers.Add(newrow);
            int result = sc.SaveChanges();

            Assert.AreEqual(1, result);

        }

        [TestMethod]
        public void UpdateTest()
        {
            InsertTest();

            // Get a row update
            tblCustomer row = sc.tblCustomers.FirstOrDefault();

            if (row == null)
            {
                // Set the properties
                row.MemberId = sc.tblMemberships.FirstOrDefault().Id;
                row.Firstname = "Test";
                row.Lastname = "Test";
                row.AddressId = sc.tblAddresses.OrderByDescending(a => a.State).FirstOrDefault().Id;
                row.Email = "Test";

                // Update the row into table
                int result = sc.SaveChanges();

                Assert.IsTrue(result == 1);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            InsertTest();

            tblCustomer row = (from c in sc.tblCustomers
                              select c).FirstOrDefault();

            if (row == null)
            {
                sc.tblCustomers.Remove(row);
                int result = sc.SaveChanges();
                Assert.IsTrue(result == 1);
            }

        }

    }

}

