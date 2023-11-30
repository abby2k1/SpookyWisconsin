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
                HauntedLocationId = new HauntedLocationManager(options).Load().FirstOrDefault().Id,
                ParticipantId = new ParticipantManager(options).Load().FirstOrDefault().Id,
                Date = DateTime.Now,
                Description = "Test"
            };
            int result = new HauntedEventManager(options).Insert(hauntedEvent, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            HauntedEvent hauntedEvent = new HauntedEventManager(options).Load().FirstOrDefault();
            hauntedEvent.Description = "Test";

            Assert.IsTrue(new HauntedEventManager(options).Update(hauntedEvent, true) > 0);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            HauntedEvent hauntedEvent = new HauntedEventManager(options).Load().FirstOrDefault();
            Assert.AreEqual(new HauntedEventManager(options).LoadById(hauntedEvent.Id).Id, hauntedEvent.Id);
        }

        [TestMethod]
        public void LoadTest()
        {
            List<HauntedEvent> hauntedEvents = new HauntedEventManager(options).Load();
            int expected = 9;

            Assert.AreEqual(expected, hauntedEvents.Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            HauntedEvent hauntedEvent = new HauntedEventManager(options).Load().FirstOrDefault();
            Assert.IsTrue(new HauntedEventManager(options).Delete(hauntedEvent.Id, true) > 0);
        }
    }
}
