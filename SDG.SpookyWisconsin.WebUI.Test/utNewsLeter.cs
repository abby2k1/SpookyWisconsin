using SDG.SpookyWisconsin.BL;
using SDG.SpookyWisconsin.BL.Models;
using SDG.SpookyWisconsin.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace SDG.SpookyWisconsin.UI.Test
{
    [TestClass]
    public class utNewsLetter
    {
        [TestMethod]
        public void IndexTest()
        {
            NewsLetterController controller = new NewsLetterController();
            var results = controller.Index() as ViewResult;
            var list = results.Model as List<NewsLetter>;
            Assert.AreEqual(4, list.Count);
        }

        //[TestMethod]
        //public void DetailsTest()
        //{
        //    NewsLetterController controller = new NewsLetterController();
        //    var results = controller.Details(NewsLetterManager.Load().FirstOrDefault().Id) as ViewResult;
        //    var NewsLetter = results.Model as NewsLetter;
        //    Assert.AreEqual(NewsLetterManager.Load().FirstOrDefault().Id, NewsLetter.Id);
        //}

        //[TestMethod]
        //public void DeleteTest()
        //{
        //    NewsLetterController controller = new NewsLetterController();
        //    var results = controller.Delete(NewsLetterManager.Load().FirstOrDefault().Id, null, true) as RedirectToActionResult;
        //    Assert.AreEqual("Index", results.ActionName);
        //}

        //[TestMethod]
        //public void CreateTest()
        //{
        //    NewsLetterController controller = new NewsLetterController();
        //    NewsLetter NewsLetter = new NewsLetter();
        //    NewsLetter.Id = new Guid();
        //    NewsLetter.HauntedEventId = new Guid();
        //    NewsLetter.Description = "TestDesc";
        //    NewsLetter.Date = DateTime.Now;
        //    var results = controller.Create(NewsLetter, true) as RedirectToActionResult;
        //    Assert.AreEqual("Index", results.ActionName);
        //}

        //[TestMethod]
        //public void EditTest()
        //{
        //    NewsLetterController controller = new NewsLetterController();
        //    var results = controller.Details(NewsLetterManager.Load().FirstOrDefault().Id) as ViewResult;
        //    NewsLetter NewsLetter = results.Model as NewsLetter;
        //    NewsLetter.HauntedEventId = new Guid();
        //    NewsLetter.Description = "TestDesc";
        //    NewsLetter.Date = DateTime.Now;
        //    var results2 = controller.Edit(NewsLetter.Id, NewsLetter, true) as RedirectToActionResult;
        //    Assert.AreEqual("Index", results2.ActionName);
        //}
    }
}