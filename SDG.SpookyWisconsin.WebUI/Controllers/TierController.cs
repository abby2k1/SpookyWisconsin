using SDG.SpookyWisconsin.BL.Models;
using SDG.SpookyWisconsin.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Microsoft.AspNetCore.Http.Extensions;
using System.Xml.Linq;

namespace CCM.DVDCentral.UI.Controllers
{
    public class TierController : Controller
    {
        // GET: TierController
        public ActionResult Index()
        {
            return View(TierManager.Load());
        }

        // GET: TierController/Details/5
        public ActionResult Details(int id)
        {
            return View(TierManager.LoadById(id));
        }

        // GET: TierController/Create
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

        // POST: TierController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tier tier, bool rollback = false)
        {
            try
            {
                TierManager.Insert(tier, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TierController/Edit/5
        public ActionResult Edit(int id)
        {
            if (Authenticate.IsAuthenticated(HttpContext))
            {
                return View(TierManager.LoadById(id));
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }
        }

        // POST: TierController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Tier tier, bool rollback = false)
        {
            try
            {
                TierManager.Update(tier, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: TierController/Delete/5
        public ActionResult Delete(int id, Tier tier)
        {
            return View(TierManager.LoadById(id));
        }

        // POST: TierController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection, bool rollback = false)
        {
            try
            {
                TierManager.Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
