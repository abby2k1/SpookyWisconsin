using SDG.SpookyWisconsin.BL;
using SDG.SpookyWisconsin.BL.Models;
using SDG.SpookyWisconsin.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace SDG.SpookyWisconsin.UI.Test
{
    [TestClass]
    public class utMerch
    {
        [TestMethod]
        public void IndexTest()
        {
            MerchController controller = new MerchController();
            var results = controller.Index() as ViewResult;
            var list = results.Model as List<Merch>;
            Assert.AreEqual(4, list.Count);
        }

        //[TestMethod]
        //public void DetailsTest()
        //{
        //    MerchController controller = new MerchController();
        //    var results = controller.Details(MerchManager.Load().FirstOrDefault().Id) as ViewResult;
        //    var Merch = results.Model as Merch;
        //    Assert.AreEqual(MerchManager.Load().FirstOrDefault().Id, Merch.Id);
        //}

        //[TestMethod]
        //public void DeleteTest()
        //{
        //    MerchController controller = new MerchController();
        //    var results = controller.Delete(MerchManager.Load().FirstOrDefault().Id, null, true) as RedirectToActionResult;
        //    Assert.AreEqual("Index", results.ActionName);
        //}

        //[TestMethod]
        //public void CreateTest()
        //{
        //    MerchController controller = new MerchController();
        //    Merch Merch = new Merch();
        //    Merch.Id = new Guid();
        //    Merch.InStkQty = 20;
        //    Merch.MerchName = "TestMerchName";
        //    Merch.Description = "TestMerchDescription";
        //    Merch.Cost = 15.99;
        //    var results = controller.Create(Merch, true) as RedirectToActionResult;
        //    Assert.AreEqual("Index", results.ActionName);
        //}

        //[TestMethod]
        //public void EditTest()
        //{
        //    MerchController controller = new MerchController();
        //    var results = controller.Details(MerchManager.Load().FirstOrDefault().Id) as ViewResult;
        //    Merch Merch = results.Model as Merch;
        //    Merch.InStkQty = 20;
        //    Merch.MerchName = "TestMerchName";
        //    Merch.Description = "TestMerchDescription";
        //    Merch.Cost = 15.99;
        //    var results2 = controller.Edit(Merch.Id, Merch, true) as RedirectToActionResult;
        //    Assert.AreEqual("Index", results2.ActionName);
        //}
    }
}