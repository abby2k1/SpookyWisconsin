using SDG.SpookyWisconsin.BL.Models;
using SDG.SpookyWisconsin.BL;
using SDG.SpookyWisconsin.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Microsoft.AspNetCore.Http.Extensions;
using System.Xml.Linq;

namespace CCM.DVDCentral.UI.Controllers
{
    public class AddressController : Controller
    {
        // GET: AddressController
        public ActionResult Index()
        {
            return View(AddressManager.Load());
        }

        // GET: AddressController/Details/5
        public ActionResult Details(Guid id)
        {
            return View(AddressManager.LoadById(id));
        }

        // GET: AddressController/Create
        public ActionResult Create()
        {
            if (Authenticate.IsAuthenticated(HttpContext))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }
        }

        // POST: AddressController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Address address, bool rollback = false)
        {
            try
            {
                AddressManager.Insert(address, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AddressController/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (Authenticate.IsAuthenticated(HttpContext))
            {
                return View(AddressManager.LoadById(id));
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }
        }

        // POST: AddressController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, Address address, bool rollback = false)
        {
            try
            {
                AddressManager.Update(address, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: AddressController/Delete/5
        public ActionResult Delete(Guid id, Address address)
        {
            return View(AddressManager.LoadById(id));
        }

        // POST: AddressController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection, bool rollback = false)
        {
            try
            {
                AddressManager.Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
