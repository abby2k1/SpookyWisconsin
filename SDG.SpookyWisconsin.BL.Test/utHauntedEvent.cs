using SDG.SpookyWisconsin.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.BL.Test
{
    [TestClass]
    public class utHauntedEvent
    {
        [TestMethod]
        public void InsertTest()
        {
            HauntedEvent hauntedEvent = new HauntedEvent
            {
                HauntedLocationId = 2,
                ParticipantId = 1,
                Date = DateTime.Now,
                Description = "Test"
            };
            Assert.AreEqual(1, HauntedEventManager.Insert(hauntedEvent, true);
        }

        [TestMethod]
        public void UpdateTest()
        {
            HauntedEvent hauntedEvent = HauntedEventManager.LoadById(1);
            hauntedEvent.HauntedLocationId = 1;
            hauntedEvent.ParticipantId = 2;
            hauntedEvent.Date = DateTime.Now;
            hauntedEvent.Description = "Test";

            int results = HauntedEventManager.Update(hauntedEvent, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Assert.AreEqual(3, HauntedEventManager.LoadById(1).Id);
        }

        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(5, HauntedEventManager.Load().Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Assert.AreEqual(1, HauntedEventManager.Delete(1, true)); 
        }
    }
}
