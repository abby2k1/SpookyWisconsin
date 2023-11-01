using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using SDG.SpookyWisconsin.BL;
using SDG.SpookyWisconsin.WebUI.Models;

namespace SDG.SpookyWisconsin.WebUI.Controllers
{
    public class HauntedLocationController : Controller
    {
        public IActionResult Index()
        {
            return View(HauntedLocationManager.Load());
        }
        
        //Location Pages start
                public IActionResult AlRinglingMuseum()
                {
                    return View();
                }
                public IActionResult AmbassadorHotel()
                {
                    return View();
                }
                public IActionResult BloodyBrideBridge()
                {
                    return View();
                }
                public IActionResult BoyScoutLane()
                {
                    return View();
                }
                public IActionResult BlackRiverFalls()
                {
                    return View();
                }
                public IActionResult ClarkCountyInsaneAsylum()
                {
                    return View();
                }
                public IActionResult DartfordCemetery()
                {
                    return View();
                }
                public IActionResult ForestHillCemetery()
                {
                    return View();
                }
                public IActionResult GrandOperaHouse()
                {
                    return View();
                }
                public IActionResult HotelHell()
                {
                    return View();
                }
                public IActionResult MorrisPrattInstitute()
                {
                    return View();
                }
                public IActionResult NelsenHall()
                {
                    return View();
                }
                public IActionResult OctagonHouse()
                {
                    return View();
                }
                public IActionResult OldBarabooInn()
                {
                    return View();
                }
                public IActionResult PfisterHotel()
                {
                    return View();
                }
                public IActionResult PlainfieldCemetery()
                {
                    return View();
                }
                public IActionResult RiversideCemetery()
                {
                    return View();
                }
                public IActionResult RiversideTheater()
                {
                    return View();
                }
                public IActionResult SanatoriumHill()
                {
                    return View();
                }
                public IActionResult SirenBridge()
                {
                    return View();
                }
                public IActionResult SummerwindMansion()
                {
                    return View();
                }
                public IActionResult WinnebagoMentalHealthInstitute()
                {
                    return View();
                }
                public IActionResult WitchRoad()
                {
                    return View();
                }
                public IActionResult WoodCountyInsaneAsylum()
                {
                    return View();
                }

        //Location Pages end

        public ActionResult Details(Guid id, BL.Models.HauntedLocation hauntedLocation)
        {
            return View(HauntedLocationManager.LoadById(id));
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

        public ActionResult Delete(Guid id)
        {
            return View(HauntedLocationManager.LoadById(id));
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
