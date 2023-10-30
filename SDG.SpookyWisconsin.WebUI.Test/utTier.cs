using SDG.SpookyWisconsin.BL;
using SDG.SpookyWisconsin.BL.Models;
using SDG.SpookyWisconsin.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace SDG.SpookyWisconsin.UI.Test
{
    [TestClass]
    public class utTier
    {
        [TestMethod]
        public void IndexTest()
        {
            TierController controller = new TierController();
            var results = controller.Index() as ViewResult;
            var list = results.Model as List<Tier>;
            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        public void DetailsTest()
        {
            TierController controller = new TierController();
            var results = controller.Details(TierManager.Load().FirstOrDefault().Id) as ViewResult;
            var Tier = results.Model as Tier;
            Assert.AreEqual(TierManager.Load().FirstOrDefault().Id, Tier.Id);
        }

        [TestMethod]
        public void DeleteTest()
        {
            TierController controller = new TierController();
            var results = controller.Delete(TierManager.Load().FirstOrDefault().Id, null, true) as RedirectToActionResult;
            Assert.AreEqual("Index", results.ActionName);
        }

        [TestMethod]
        public void CreateTest()
        {
            TierController controller = new TierController();
            Tier Tier = new Tier();
            Tier.Id = new Guid();
            Tier.TierName = "TierTest";
            Tier.TierLevel = 4;
            var results = controller.Create(Tier, true) as RedirectToActionResult;
            Assert.AreEqual("Index", results.ActionName);
        }

        [TestMethod]
        public void EditTest()
        {
            TierController controller = new TierController();
            var results = controller.Details(TierManager.Load().FirstOrDefault().Id) as ViewResult;
            Tier Tier = results.Model as Tier;
            Tier.TierName = "TierEditTest";
            Tier.TierLevel = 2;
            var results2 = controller.Edit(Tier.Id, Tier, true) as RedirectToActionResult;
            Assert.AreEqual("Index", results2.ActionName);
        }
    }
}