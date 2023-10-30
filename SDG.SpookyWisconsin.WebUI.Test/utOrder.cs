using SDG.SpookyWisconsin.BL;
using SDG.SpookyWisconsin.BL.Models;
using SDG.SpookyWisconsin.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace SDG.SpookyWisconsin.UI.Test
{
    [TestClass]
    public class utOrder
    {
        [TestMethod]
        public void IndexTest()
        {
            OrderController controller = new OrderController();
            var results = controller.Index() as ViewResult;
            var list = results.Model as List<Order>;
            Assert.AreEqual(4, list.Count);
        }

        //[TestMethod]
        //public void DetailsTest()
        //{
        //    OrderController controller = new OrderController();
        //    var results = controller.Details(OrderManager.Load().FirstOrDefault().Id) as ViewResult;
        //    var Order = results.Model as Order;
        //    Assert.AreEqual(OrderManager.Load().FirstOrDefault().Id, Order.Id);
        //}

        //[TestMethod]
        //public void DeleteTest()
        //{
        //    OrderController controller = new OrderController();
        //    var results = controller.Delete(OrderManager.Load().FirstOrDefault().Id, null, true) as RedirectToActionResult;
        //    Assert.AreEqual("Index", results.ActionName);
        //}

        //[TestMethod]
        //public void CreateTest()
        //{
        //    OrderController controller = new OrderController();
        //    Order Order = new Order();
        //    Order.Id = new Guid();
        //    Order.CartId = new Guid();
        //    Order.CustomerId = new Guid();
        //    Order.OrderDate = DateTime.Now;
        //    Order.DeliverDate = DateTime.Now;
        //    var results = controller.Create(Order, true) as RedirectToActionResult;
        //    Assert.AreEqual("Index", results.ActionName);
        //}

        //[TestMethod]
        //public void EditTest()
        //{
        //    OrderController controller = new OrderController();
        //    var results = controller.Details(OrderManager.Load().FirstOrDefault().Id) as ViewResult;
        //    Order Order = results.Model as Order;
        //    Order.CartId = new Guid();
        //    Order.CustomerId = new Guid();
        //    Order.OrderDate = DateTime.Now;
        //    Order.DeliverDate = DateTime.Now;
        //    var results2 = controller.Edit(Order.Id, Order, true) as RedirectToActionResult;
        //    Assert.AreEqual("Index", results2.ActionName);
        //}
    }
}