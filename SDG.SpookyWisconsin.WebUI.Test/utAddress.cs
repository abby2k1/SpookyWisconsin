using SDG.SpookyWisconsin.BL;
using SDG.SpookyWisconsin.BL.Models;
using SDG.SpookyWisconsin.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace SDG.SpookyWisconsin.UI.Test
{
    [TestClass]
    public class utAddress
    {
        [TestMethod]
        public void IndexTest()
        {
            AddressController controller = new AddressController();
            var results = controller.Index() as ViewResult;
            var list = results.Model as List<Address>;
            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        public void DetailsTest()
        {
            AddressController controller = new AddressController();
            var results = controller.Details(AddressManager.Load().FirstOrDefault().Id) as ViewResult;
            var Address = results.Model as Address;
            Assert.AreEqual(AddressManager.Load().FirstOrDefault().Id, Address.Id);
        }

        [TestMethod]
        public void DeleteTest()
        {
            AddressController controller = new AddressController();
            var results = controller.Delete(AddressManager.Load().FirstOrDefault().Id, null, true) as RedirectToActionResult;
            Assert.AreEqual("Index", results.ActionName);
        }

        [TestMethod]
        public void CreateTest()
        {
            AddressController controller = new AddressController();
            Address Address = new Address();
            Address.Id = new Guid();
            Address.Street = "TestStreet";
            Address.County = "TestCounty";
            Address.City = "TestCity";
            Address.State = "TestState";
            Address.ZIP = "TestZIP";
            var results = controller.Create(Address, true) as RedirectToActionResult;
            Assert.AreEqual("Index", results.ActionName);
        }

        [TestMethod]
        public void EditTest()
        {
            AddressController controller = new AddressController();
            var results = controller.Details(AddressManager.Load().FirstOrDefault().Id) as ViewResult;
            Address Address = results.Model as Address;
            Address.Street = "EditStreetTest";
            Address.County = "EditCountyTest";
            Address.City = "EditCityTest";
            Address.State = "EditStateTest";
            Address.ZIP = "EditZIPTest";
            var results2 = controller.Edit(Address.Id, Address, true) as RedirectToActionResult;
            Assert.AreEqual("Index", results2.ActionName);
        }
    }
}