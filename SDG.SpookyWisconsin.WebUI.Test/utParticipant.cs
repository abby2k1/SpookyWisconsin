using SDG.SpookyWisconsin.BL;
using SDG.SpookyWisconsin.BL.Models;
using SDG.SpookyWisconsin.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace SDG.SpookyWisconsin.UI.Test
{
    [TestClass]
    public class utParticipant
    {
        [TestMethod]
        public void IndexTest()
        {
            ParticipantController controller = new ParticipantController();
            var results = controller.Index() as ViewResult;
            var list = results.Model as List<Participant>;
            Assert.AreEqual(4, list.Count);
        }

        [TestMethod]
        public void DetailsTest()
        {
            ParticipantController controller = new ParticipantController();
            var results = controller.Details(ParticipantManager.Load().FirstOrDefault().Id) as ViewResult;
            var Participant = results.Model as Participant;
            Assert.AreEqual(ParticipantManager.Load().FirstOrDefault().Id, Participant.Id);
        }

        [TestMethod]
        public void DeleteTest()
        {
            ParticipantController controller = new ParticipantController();
            var results = controller.Delete(ParticipantManager.Load().FirstOrDefault().Id, null, true) as RedirectToActionResult;
            Assert.AreEqual("Index", results.ActionName);
        }

        [TestMethod]
        public void CreateTest()
        {
            ParticipantController controller = new ParticipantController();
            Participant Participant = new Participant();
            Participant.Id = new Guid();
            Participant.HauntedEventId = new Guid();
            Participant.CustomerId = new Guid();
            var results = controller.Create(Participant, true) as RedirectToActionResult;
            Assert.AreEqual("Index", results.ActionName);
        }

        [TestMethod]
        public void EditTest()
        {
            ParticipantController controller = new ParticipantController();
            var results = controller.Details(ParticipantManager.Load().FirstOrDefault().Id) as ViewResult;
            Participant Participant = results.Model as Participant;
            Participant.HauntedEventId = new Guid();
            Participant.CustomerId = new Guid();
            var results2 = controller.Edit(Participant.Id, Participant, true) as RedirectToActionResult;
            Assert.AreEqual("Index", results2.ActionName);
        }
    }
}