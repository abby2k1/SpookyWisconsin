using SDG.SpookyWisconsin.BL;
using SDG.SpookyWisconsin.BL.Models;
using SDG.SpookyWisconsin.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace SDG.SpookyWisconsin.UI.Test
{
    [TestClass]
    public class utHauntedEvent
    {
        [TestMethod]
        public void IndexTest()
        {
            HauntedEventController controller = new HauntedEventController();
            var results = controller.Index() as ViewResult;
            var list = results.Model as List<HauntedEvent>;
            Assert.AreEqual(4, list.Count);
        }

        [TestMethod]
        public void DetailsTest()
        {
            HauntedEventController controller = new HauntedEventController();
            var results = controller.Details(HauntedEventManager.Load().FirstOrDefault().Id) as ViewResult;
            var HauntedEvent = results.Model as HauntedEvent;
            Assert.AreEqual(HauntedEventManager.Load().FirstOrDefault().Id, HauntedEvent.Id);
        }

        [TestMethod]
        public void DeleteTest()
        {
            HauntedEventController controller = new HauntedEventController();
            var results = controller.Delete(HauntedEventManager.Load().FirstOrDefault().Id, null, true) as RedirectToActionResult;
            Assert.AreEqual("Index", results.ActionName);
        }

        [TestMethod]
        public void CreateTest()
        {
            HauntedEventController controller = new HauntedEventController();
            HauntedEvent HauntedEvent = new HauntedEvent();
            HauntedEvent.Id = new Guid();
            HauntedEvent.HauntedLocationId = new Guid();
            HauntedEvent.ParticipantId = new Guid();
            HauntedEvent.Name = "TestName";
            HauntedEvent.Date = DateTime.Now;
            HauntedEvent.Description = "TestDescription";
            HauntedEvent.ImagePath = "TestImgPath";
            var results = controller.Create(HauntedEvent, true) as RedirectToActionResult;
            Assert.AreEqual("Index", results.ActionName);
        }

        [TestMethod]
        public void EditTest()
        {
            HauntedEventController controller = new HauntedEventController();
            var results = controller.Details(HauntedEventManager.Load().FirstOrDefault().Id) as ViewResult;
            HauntedEvent HauntedEvent = results.Model as HauntedEvent;
            HauntedEvent.HauntedLocationId = new Guid();
            HauntedEvent.ParticipantId = new Guid();
            HauntedEvent.Name = "TestName";
            HauntedEvent.Date = DateTime.Now;
            HauntedEvent.Description = "TestDescription";
            HauntedEvent.ImagePath = "TestImgPath";
            var results2 = controller.Edit(HauntedEvent.Id, HauntedEvent, true) as RedirectToActionResult;
            Assert.AreEqual("Index", results2.ActionName);
        }
    }
}