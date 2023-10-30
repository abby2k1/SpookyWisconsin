using SDG.SpookyWisconsin.BL;
using SDG.SpookyWisconsin.BL.Models;
using SDG.SpookyWisconsin.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace SDG.SpookyWisconsin.UI.Test
{
    [TestClass]
    public class utCustomer
    {
        [TestMethod]
        public void IndexTest()
        {
            CustomerController controller = new CustomerController();
            var results = controller.Index() as ViewResult;
            var list = results.Model as List<Customer>;
            Assert.AreEqual(4, list.Count);
        }

        //Uncomment when the CustomerController is complete.

        //[TestMethod]
        //public void DetailsTest()
        //{
        //    CustomerController controller = new CustomerController();
        //    var results = controller.Details(CustomerManager.Load().FirstOrDefault().Id) as ViewResult;
        //    var Customer = results.Model as Customer;
        //    Assert.AreEqual(CustomerManager.Load().FirstOrDefault().Id, Customer.Id);
        //}

        //[TestMethod]
        //public void DeleteTest()
        //{
        //    CustomerController controller = new CustomerController();
        //    var results = controller.Delete(CustomerManager.Load().FirstOrDefault().Id, null, true) as RedirectToActionResult;
        //    Assert.AreEqual("Index", results.ActionName);
        //}

        //[TestMethod]
        //public void CreateTest()
        //{
        //    CustomerController controller = new CustomerController();
        //    Customer Customer = new Customer();
        //    Customer.Id = new Guid();
        //    Customer.MemberId = new Guid();
        //    Customer.UserId = new Guid();
        //    Customer.FirstName = "TestFirstName";
        //    Customer.LastName = "TestLastName";
        //    Customer.Address = "TestAddress";
        //    Customer.Email = "TestEmail";
        //    var results = controller.Create(Customer, true) as RedirectToActionResult;
        //    Assert.AreEqual("Index", results.ActionName);
        //}

        //[TestMethod]
        //public void EditTest()
        //{
        //    CustomerController controller = new CustomerController();
        //    var results = controller.Details(CustomerManager.Load().FirstOrDefault().Id) as ViewResult;
        //    Customer Customer = results.Model as Customer;
        //    Customer.MemberId = new Guid();
        //    Customer.UserId = new Guid();
        //    Customer.FirstName = "EditTestFirstName";
        //    Customer.LastName = "EditTestLastName";
        //    Customer.Address = "EditTestAddress";
        //    Customer.Email = "EditTestEmail";
        //    var results2 = controller.Edit(Customer.Id, Customer, true) as RedirectToActionResult;
        //    Assert.AreEqual("Index", results2.ActionName);
        //}
    }
}