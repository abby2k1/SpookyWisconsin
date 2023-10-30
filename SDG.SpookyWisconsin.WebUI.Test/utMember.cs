using SDG.SpookyWisconsin.BL;
using SDG.SpookyWisconsin.BL.Models;
using SDG.SpookyWisconsin.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace SDG.SpookyWisconsin.UI.Test
{
    [TestClass]
    public class utMember
    {
        [TestMethod]
        public void IndexTest()
        {
            MemberController controller = new MemberController();
            var results = controller.Index() as ViewResult;
            var list = results.Model as List<Member>;
            Assert.AreEqual(4, list.Count);
        }

        [TestMethod]
        public void DetailsTest()
        {
            MemberController controller = new MemberController();
            var results = controller.Details(MemberManager.Load().FirstOrDefault().Id) as ViewResult;
            var Member = results.Model as Member;
            Assert.AreEqual(MemberManager.Load().FirstOrDefault().Id, Member.Id);
        }

        [TestMethod]
        public void DeleteTest()
        {
            MemberController controller = new MemberController();
            var results = controller.Delete(MemberManager.Load().FirstOrDefault().Id, null, true) as RedirectToActionResult;
            Assert.AreEqual("Index", results.ActionName);
        }

        [TestMethod]
        public void CreateTest()
        {
            MemberController controller = new MemberController();
            Member Member = new Member();
            Member.Id = new Guid();
            Member.MemberOpt = "No";
            Member.NewsLetterOpt = "Yes";
            Member.TierId = TierManager.Load().FirstOrDefault().Id;
            Member.NewsLetterId = new Guid();
            var results = controller.Create(Member, true) as RedirectToActionResult;
            Assert.AreEqual("Index", results.ActionName);
        }

        [TestMethod]
        public void EditTest()
        {
            MemberController controller = new MemberController();
            var results = controller.Details(MemberManager.Load().FirstOrDefault().Id) as ViewResult;
            Member Member = results.Model as Member;
            Member.MemberOpt = "Yes";
            Member.NewsLetterOpt = "Yes";
            Member.TierId = TierManager.Load().FirstOrDefault().Id;
            Member.NewsLetterId = new Guid();
            var results2 = controller.Edit(Member.Id, Member, true) as RedirectToActionResult;
            Assert.AreEqual("Index", results2.ActionName);
        }
    }
}