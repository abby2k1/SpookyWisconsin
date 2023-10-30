using SDG.SpookyWisconsin.BL;
using SDG.SpookyWisconsin.BL.Models;
using SDG.SpookyWisconsin.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace SDG.SpookyWisconsin.UI.Test
{
    [TestClass]
    public class utTour
    {
        [TestMethod]
        public void IndexTest()
        {
            TourController controller = new TourController();
            var results = controller.Index() as ViewResult;
            var list = results.Model as List<Tour>;
            Assert.AreEqual(4, list.Count);
        }

        [TestMethod]
        public void DetailsTest()
        {
            TourController controller = new TourController();
            var results = controller.Details(TourManager.Load().FirstOrDefault().Id) as ViewResult;
            var Tour = results.Model as Tour;
            Assert.AreEqual(TourManager.Load().FirstOrDefault().Id, Tour.Id);
        }

        [TestMethod]
        public void DeleteTest()
        {
            TourController controller = new TourController();
            var results = controller.Delete(TourManager.Load().FirstOrDefault().Id, null, true) as RedirectToActionResult;
            Assert.AreEqual("Index", results.ActionName);
        }

        [TestMethod]
        public void CreateTest()
        {
            TourController controller = new TourController();
            Tour Tour = new Tour();
            Tour.Id = new Guid();
            Tour.HauntedLocationId = new Guid();
            Tour.TourName = "TestTourName";
            Tour.Description = "TestTourDesc";
            var results = controller.Create(Tour, true) as RedirectToActionResult;
            Assert.AreEqual("Index", results.ActionName);
        }

        [TestMethod]
        public void EditTest()
        {
            TourController controller = new TourController();
            var results = controller.Details(TourManager.Load().FirstOrDefault().Id) as ViewResult;
            Tour Tour = results.Model as Tour;
            Tour.HauntedLocationId = new Guid();
            Tour.TourName = "EditTestTourName";
            Tour.Description = "EditTestTourDesc";
            var results2 = controller.Edit(Tour.Id, Tour, true) as RedirectToActionResult;
            Assert.AreEqual("Index", results2.ActionName);
        }
    }
}