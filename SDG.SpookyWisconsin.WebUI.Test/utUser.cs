using SDG.SpookyWisconsin.BL;
using SDG.SpookyWisconsin.BL.Models;
using SDG.SpookyWisconsin.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace SDG.SpookyWisconsin.UI.Test
{
    [TestClass]
    public class utUser
    {
        [TestMethod]
        public void IndexTest()
        {
            UserManager.Seed();
            UserController controller = new UserController();
            var results = controller.Index() as ViewResult;
            var list = results.Model as List<User>;
            Assert.AreEqual(6, list.Count);
        }

        [TestMethod]
        public void DetailsTest()
        {
            UserManager.Seed();
            UserController controller = new UserController();
            var results = controller.Details(UserManager.Load().FirstOrDefault().Id) as ViewResult;
            var User = results.Model as User;
            Assert.AreEqual(UserManager.Load().FirstOrDefault().Id, User.Id);
        }

        [TestMethod]
        public void DeleteTest()
        {
            UserManager.Seed();
            UserController controller = new UserController();
            var results = controller.Delete(UserManager.Load().FirstOrDefault().Id, null ,true) as RedirectToActionResult;
            Assert.AreEqual("Index", results.ActionName);
        }

        //[TestMethod]
        //public void CreateTest()
        //{
        //    UserController controller = new UserController();
        //    User User = new User();
        //    User.Id = new Guid();
        //    User.Username = "TestUsername";
        //    User.Password = "TestPassword";
        //    var results = controller.Create(User, true) as RedirectToActionResult;
        //    Assert.AreEqual("Index", results.ActionName);
        //}

        //[TestMethod]
        //public void EditTest()
        //{
        //    UserManager.Seed();
        //    UserController controller = new UserController();
        //    var results = controller.Details(UserManager.Load().FirstOrDefault().Id) as ViewResult;
        //    User User = results.Model as User;
        //    User.Username = "EditTestUsername";
        //    User.Password = "EditTestPassword";
        //    var results2 = controller.Edit(User.Id, User, true) as RedirectToActionResult;
        //    Assert.AreEqual("Index", results2.ActionName);
        //}
    }
}