using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDG.SpookyWisconsin.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.BL.Test
{
    [TestClass]
    public class utHauntedEvent : utBase
    {
        [TestMethod]
        public void InsertTest()
        {
            HauntedEvent hauntedEvent = new HauntedEvent
            {
                HauntedLocationId = HauntedLocationManager.Load().FirstOrDefault().Id,
                ParticipantId = ParticipantManager.Load().FirstOrDefault().Id,
                Date = DateTime.Now,
                Description = "Test"
            };
            int result = HauntedEventManager.Insert(hauntedEvent, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            HauntedEvent hauntedEvent = HauntedEventManager.Load().FirstOrDefault();
            hauntedEvent.Description = "Test";

            Assert.IsTrue(HauntedEventManager.Update(hauntedEvent, true) > 0);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            HauntedEvent hauntedEvent = HauntedEventManager.Load().FirstOrDefault();
            Assert.AreEqual(HauntedEventManager.LoadById(hauntedEvent.Id).Id, hauntedEvent.Id);
        }

        [TestMethod]
        public void LoadTest()
        {
            List<HauntedEvent> hauntedEvents = HauntedEventManager.Load();
            int expected = 9;

            Assert.AreEqual(expected, hauntedEvents.Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            HauntedEvent hauntedEvent = HauntedEventManager.Load().FirstOrDefault();
            Assert.IsTrue(HauntedEventManager.Delete(hauntedEvent.Id, true) > 0);
        }
    }
}
