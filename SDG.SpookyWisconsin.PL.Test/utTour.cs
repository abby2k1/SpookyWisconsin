﻿using Microsoft.EntityFrameworkCore.Storage;
using SDG.SpookyWisconsin.PL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.PL.Test
{
    [TestClass]
    public class utTour
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

            var rows = sc.tblTours;

            actual = rows.Count();

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void InsertTest()
        {
            // Create a new row in memory
            tblTour newrow = new tblTour();

            // Set the properties
            newrow.Id = -99;
            newrow.Description = "3 hour tour";
            newrow.HauntedLocationId = 3;

            // Insert row into table
            sc.tblTours.Add(newrow);
            int result = sc.SaveChanges();

            Assert.IsTrue(result == 1);

        }

        [TestMethod]
        public void UpdateTest()
        {
            // Get a row update
            tblTour row = (from a in sc.tblTours
                           where a.Id == 2
                           select a).FirstOrDefault();

            if (row == null)
            {
                // Set the properties
                row.Description = "Test";
                row.HauntedLocationId = 2;


                // Update the row into table
                int result = sc.SaveChanges();

                Assert.IsTrue(result == 1);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblTour row = (from a in sc.tblTours
                           where a.Id == 2
                           select a).FirstOrDefault();

            if (row == null)
            {
                sc.tblTours.Remove(row);
                int result = sc.SaveChanges(true);
                Assert.IsTrue(result == 1);
            }

        }

    }
}
