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

        public ActionResult Details(int id, BL.Models.HauntedLocation hauntedLocation)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }
    }
}
