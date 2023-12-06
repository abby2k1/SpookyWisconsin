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
    public class utNewsLetter : utBase
    {

        [TestMethod]
        public void LoadTest()
        {
            //How many I expected
            int expected = 3;
            //How many I did get back
            var newsLetters = sc.tblNewLetters;

            Assert.AreEqual(expected, newsLetters.Count());

        }

        [TestMethod]
        public void InsertTest()
        {
            // Create a new row in memory
            tblNewsLetter newrow = new tblNewsLetter();

            // Set the properties
            newrow.Id = Guid.NewGuid();
            newrow.HauntedEventId = sc.tblHauntedEvents.FirstOrDefault().Id;
            newrow.Description = "Ghost located after 3 am";
            newrow.Date = new System.DateTime(2023, 4, 8);


            // Insert row into table
            sc.tblNewLetters.Add(newrow);
            int result = sc.SaveChanges();

            Assert.AreEqual(1, result);

        }

        [TestMethod]
        public void UpdateTest()
        {
            InsertTest();

            // Get a row update
            tblNewsLetter row = sc.tblNewLetters.FirstOrDefault();  

            if (row == null)
            {
                // Set the properties
                row.HauntedEventId = sc.tblHauntedEvents.FirstOrDefault().Id;
                row.Description = "Test";

                // Update the row into table
                int result = sc.SaveChanges();

                Assert.AreEqual(1, result);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            InsertTest();

            tblNewsLetter row = (from a in sc.tblNewLetters
                                 select a).FirstOrDefault();

            if (row == null)
            {
                sc.tblNewLetters.Remove(row);
                int result = sc.SaveChanges();
                Assert.IsTrue(result == 1);
            }

        }

    }
}
