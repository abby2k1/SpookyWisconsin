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

        public ActionResult Details()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BL.Models.HauntedEvent hauntedEvent)
        {
            try
            {
                HauntedEventManager.Insert(hauntedEvent);
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
        public ActionResult Edit(int id, BL.Models.HauntedEvent hauntedEvent)
        {
            try
            {
                HauntedEventManager.Update(hauntedEvent);
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
        public ActionResult Delete(int id, BL.Models.HauntedEvent hauntedEvent)
        {
            try
            {
                //HauntedEventManager.Delete();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
