using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using SDG.SpookyWisconsin.BL;
using SDG.SpookyWisconsin.WebUI.Models;

namespace SDG.SpookyWisconsin.WebUI.Controllers
{
    public class TourController : Controller
    {
        public IActionResult Index()
        {
            return View(TourManager.Load());
        }

        public ActionResult Details(Guid id, BL.Models.Tour tour)
        {
            return View(TourManager.LoadById(id));
        }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BL.Models.Tour tour, bool rollback = false)
        {
            try
            {
                TourManager.Insert(tour, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit()
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, BL.Models.Tour tour, bool rollback = false)
        {
            try
            {
                TourManager.Update(tour, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        public ActionResult Delete(Guid id)
        {
            return View(TourManager.LoadById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, BL.Models.Tour tour, bool rollback = false)
        {
            try
            {
                TourManager.Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
