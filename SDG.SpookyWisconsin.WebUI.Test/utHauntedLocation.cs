using SDG.SpookyWisconsin.BL;
using SDG.SpookyWisconsin.BL.Models;
using SDG.SpookyWisconsin.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace SDG.SpookyWisconsin.UI.Test
{
    [TestClass]
    public class utHauntedLocation
    {
        [TestMethod]
        public void IndexTest()
        {
            HauntedLocationController controller = new HauntedLocationController();
            var results = controller.Index() as ViewResult;
            var list = results.Model as List<HauntedLocation>;
            Assert.AreEqual(24, list.Count);
        }

        //[TestMethod]
        //public void DetailsTest()
        //{
        //    HauntedLocationController controller = new HauntedLocationController();
        //    var results = controller.Details(HauntedLocationManager.Load().FirstOrDefault().Id) as ViewResult;
        //    var HauntedLocation = results.Model as HauntedLocation;
        //    Assert.AreEqual(HauntedLocationManager.Load().FirstOrDefault().Id, HauntedLocation.Id);
        //}

        [TestMethod]
        public void DeleteTest()
        {
            HauntedLocationController controller = new HauntedLocationController();
            var results = controller.Delete(HauntedLocationManager.Load().FirstOrDefault().Id, null, true) as RedirectToActionResult;
            Assert.AreEqual("Index", results.ActionName);
        }

        [TestMethod]
        public void CreateTest()
        {
            HauntedLocationController controller = new HauntedLocationController();
            HauntedLocation HauntedLocation = new HauntedLocation();
            HauntedLocation.Id = new Guid();
            HauntedLocation.AddressId = new Guid();
            HauntedLocation.Name = "TestName";
            var results = controller.Create(HauntedLocation, true) as RedirectToActionResult;
            Assert.AreEqual("Index", results.ActionName);
        }

        //[TestMethod]
        //public void EditTest()
        //{
        //    HauntedLocationController controller = new HauntedLocationController();
        //    var results = controller.Details(HauntedLocationManager.Load().FirstOrDefault().Id) as ViewResult;
        //    HauntedLocation HauntedLocation = results.Model as HauntedLocation;
        //    HauntedLocation.AddressId = new Guid();
        //    HauntedLocation.Name = "TestName";
        //    var results2 = controller.Edit(HauntedLocation.Id, HauntedLocation, true) as RedirectToActionResult;
        //    Assert.AreEqual("Index", results2.ActionName);
        //}
    }
}