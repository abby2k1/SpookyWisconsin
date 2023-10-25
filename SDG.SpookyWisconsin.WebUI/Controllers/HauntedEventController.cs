using Microsoft.AspNetCore.Mvc;
using SDG.SpookyWisconsin.BL;

namespace SDG.SpookyWisconsin.WebUI.Controllers
{
    public class HauntedEventController : Controller
    {
        public IActionResult Index()
        {
            return View(HauntedEventManager.Load());
        }

        public ActionResult Details(Guid id)
        {
            return View(HauntedEventManager.LoadById(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BL.Models.HauntedEvent hauntedEvent, bool rollback = false)
        {
            try
            {
                HauntedEventManager.Insert(hauntedEvent, rollback);
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
        public ActionResult Edit(Guid id, BL.Models.HauntedEvent hauntedEvent, bool rollback = false)
        {
            try
            {
                HauntedEventManager.Update(hauntedEvent, rollback);
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
        public ActionResult Delete(Guid id, BL.Models.HauntedEvent hauntedEvent, bool rollback = false)
        {
            try
            {
                HauntedEventManager.Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
