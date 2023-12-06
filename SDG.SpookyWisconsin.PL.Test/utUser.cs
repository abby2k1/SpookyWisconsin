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
    public class utUser : utBase
    {

        [TestMethod]
        public void LoadTest()
        {
            var users = sc.tblUsers;

            Assert.IsTrue(users.Count() > 0);

        }

        [TestMethod]
        public void InsertTest()
        {
            // Create a new row in memory
            tblUser newrow = new tblUser();

            // Set the properties
            newrow.Id = Guid.NewGuid();
            newrow.Username = "MThomas";
            newrow.Password = "12345";

            // Insert row into table
            sc.tblUsers.Add(newrow);
            int result = sc.SaveChanges();

            Assert.AreEqual(1, result);

        }

        [TestMethod]
        public void UpdateTest()
        {
            InsertTest();
            // Get a row update
            tblUser row = sc.tblUsers.FirstOrDefault();

            if (row == null)
            {
                // Set the properties
                row.Username = "Test";
                row.Password = "Test";


                // Update the row into table
                int result = sc.SaveChanges();

                Assert.AreEqual(1, result);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            InsertTest();

            tblUser row = (from a in sc.tblUsers
                           select a).FirstOrDefault();

            if (row == null)
            {
                sc.tblUsers.Remove(row);
                int result = sc.SaveChanges();
                Assert.IsTrue(result == 1);
            }

        }

    }
}
