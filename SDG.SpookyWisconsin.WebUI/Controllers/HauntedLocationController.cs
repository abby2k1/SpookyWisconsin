using Microsoft.AspNetCore.Mvc;
using SDG.SpookyWisconsin.BL;

namespace SDG.SpookyWisconsin.WebUI.Controllers
{
    public class HauntedLocationController : Controller
    {
        public IActionResult Index()
        {
            return View(HauntedLocationManager.Load());
        }

        public ActionResult Details(Guid id, BL.Models.HauntedLocation hauntedLocation)
        {
            return View(HauntedLocationManager.LoadById(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BL.Models.HauntedLocation hauntedLocation, bool rollback = false)
        {
            try
            {
                HauntedLocationManager.Insert(hauntedLocation, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, BL.Models.HauntedLocation hauntedLocation, bool rollback = false)
        {
            try
            {
                HauntedLocationManager.Update(hauntedLocation, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, BL.Models.HauntedLocation hauntedLocation, bool rollback = false)
        {
            try
            {
                HauntedLocationManager.Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
