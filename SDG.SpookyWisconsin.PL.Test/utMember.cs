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
    public class utMember : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            //How many I expected
            int expected = 3;
            //How many I did get back
            var members = sc.tblMemberships;
            Assert.AreEqual(expected, members.Count());

        }

        [TestMethod]
        public void InsertTest()
        {
            // Create a new row in memory
            tblMember newrow = new tblMember();

            // Set the properties
            newrow.Id = Guid.NewGuid();
            newrow.TierId = sc.tblTiers.FirstOrDefault().Id;
            newrow.NewsLetterId = sc.tblNewLetters.FirstOrDefault().Id;
            newrow.NewsLetterOpt = "Tomorrow";
            newrow.MemberOpt = "Pro";

            // Insert row into table
            sc.tblMemberships.Add(newrow);
            int result = sc.SaveChanges();

            Assert.AreEqual(1, result);

        }

        [TestMethod]
        public void UpdateTest()
        {
            InsertTest(); 

            // Get a row update
            tblMember row = sc.tblMemberships.FirstOrDefault();

            if (row == null)
            {
                // Set the properties
                row.TierId = sc.tblTiers.OrderByDescending(t => t.TierLevel).FirstOrDefault().Id;
                row.NewsLetterId = sc.tblNewLetters.OrderByDescending(n => n.Date).FirstOrDefault().Id;
                row.NewsLetterOpt = "Test";
                row.MemberOpt = "Test";

                // Update the row into table
                int result = sc.SaveChanges();

                Assert.AreEqual(1, result);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            InsertTest();

            tblMember row = (from a in sc.tblMemberships
                                      select a).FirstOrDefault();

            if (row == null)
            {
                sc.tblMemberships.Remove(row);
                int result = sc.SaveChanges();
                Assert.IsTrue(result == 1);
            }

        }

    }
}
