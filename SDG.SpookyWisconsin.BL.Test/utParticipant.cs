using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDG.SpookyWisconsin.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.BL.Test
{
    public class utParticipant : utBase
    {
        List<Participant> participants = ParticipantManager.Load();
        List<HauntedEvent> hauntedEvents = HauntedEventManager.Load();
        List<Customer> customers = CustomerManager.Load();

        [TestMethod]
        public void InsertTest()
        {
            Participant participant = new Participant
            {
                HauntedEventId = hauntedEvents.FirstOrDefault().Id,
                CustomerId = customers.FirstOrDefault().Id
            };
            int result = ParticipantManager.Insert(participant, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Participant participant = participants.FirstOrDefault();
            participant.CustomerId = Guid.NewGuid();

            Assert.IsTrue(ParticipantManager.Update(participant, true) > 0);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Participant participant = participants.FirstOrDefault();
            Assert.AreEqual(ParticipantManager.LoadById(participant.Id).Id, participant.Id);
        }

        [TestMethod]
        public void LoadTest()
        {
            List<Participant> participant = participants;
            int expected = 3;

            Assert.AreEqual(expected, participant.Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Participant participant = participants.FirstOrDefault();
            Assert.IsTrue(ParticipantManager.Delete(participant.Id, true) > 0);
        }
    }
}
