using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SDG.SpookyWisconsin.API.Controllers
{
    public class HauntedLocationController : Controller
    {
        // GET: HauntedLocationController
        public ActionResult Index()
        {
            return View();
        }

        // GET: HauntedLocationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HauntedLocationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HauntedLocationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HauntedLocationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HauntedLocationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HauntedLocationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HauntedLocationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
