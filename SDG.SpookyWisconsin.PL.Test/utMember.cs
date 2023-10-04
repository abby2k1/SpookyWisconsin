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
    public class utMember
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

            var rows = sc.tblMemberships;

            actual = rows.Count();

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void InsertTest()
        {
            // Create a new row in memory
            tblMember newrow = new tblMember();

            // Set the properties
            newrow.Id = -99;
            newrow.TierId = 2;
            newrow.NewsLetterId = 4;
            newrow.NewsLetterOpt = "Tomorrow";
            newrow.MemberOpt = "Pro";

            // Insert row into table
            sc.tblMemberships.Add(newrow);
            int result = sc.SaveChanges();

            Assert.IsTrue(result == 1);

        }

        [TestMethod]
        public void UpdateTest()
        {
            // Get a row update
            tblMember row = (from a in sc.tblMemberships
                             where a.Id == 2
                                      select a).FirstOrDefault();

            if (row == null)
            {
                // Set the properties
                row.TierId = 3;
                row.NewsLetterId = 2;
                row.NewsLetterOpt = "Test";
                row.MemberOpt = "Test";

                // Update the row into table
                int result = sc.SaveChanges();

                Assert.IsTrue(result == 1);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblMember row = (from a in sc.tblMemberships
                             where a.Id == 2
                                      select a).FirstOrDefault();

            if (row == null)
            {
                sc.tblMemberships.Remove(row);
                int result = sc.SaveChanges(true);
                Assert.IsTrue(result == 1);
            }

        }

    }
}
