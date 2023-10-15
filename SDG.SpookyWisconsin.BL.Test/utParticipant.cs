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
        [TestMethod]
        public void InsertTest()
        {
            Participant participant = new Participant
            {
                HauntedEventId = HauntedEventManager.Load().FirstOrDefault().Id,
                CustomerId = CustomerManager.Load().FirstOrDefault().Id
            };
            int result = ParticipantManager.Insert(participant, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Participant participant = ParticipantManager.Load().FirstOrDefault();
            participant.CustomerId = Guid.NewGuid();

            Assert.IsTrue(ParticipantManager.Update(participant, true) > 0);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Participant participant = ParticipantManager.Load().FirstOrDefault();
            Assert.AreEqual(ParticipantManager.LoadById(participant.Id).Id, participant.Id);
        }

        [TestMethod]
        public void LoadTest()
        {
            List<Participant> participant = ParticipantManager.Load();
            int expected = 3;

            Assert.AreEqual(expected, participant.Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Participant participant = ParticipantManager.Load().FirstOrDefault();
            Assert.IsTrue(ParticipantManager.Delete(participant.Id, true) > 0);
        }
    }
}
