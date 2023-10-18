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
                HauntedEventId = new HauntedEventManager(options).Load().FirstOrDefault().Id,
                CustomerId = new CustomerManager(options).Load().FirstOrDefault().Id
            };
            int result = new ParticipantManager(options).Insert(participant, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Participant participant = new ParticipantManager(options).Load().FirstOrDefault();
            participant.CustomerId = Guid.NewGuid();

            Assert.IsTrue(new ParticipantManager(options).Update(participant, true) > 0);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Participant participant = new ParticipantManager(options).Load().FirstOrDefault();
            Assert.AreEqual(new ParticipantManager(options).LoadById(participant.Id).Id, participant.Id);
        }

        [TestMethod]
        public void LoadTest()
        {
            List<Participant> participant = new ParticipantManager(options).Load();
            int expected = 3;

            Assert.AreEqual(expected, participant.Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Participant participant = new ParticipantManager(options).Load().FirstOrDefault();
            Assert.IsTrue(new ParticipantManager(options).Delete(participant.Id, participant) > 0);
        }
    }
}
