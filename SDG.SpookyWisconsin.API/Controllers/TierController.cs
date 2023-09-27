using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SDG.SpookyWisconsin.API.Controllers
{
    public class TierController : Controller
    {
        // GET: TierController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TierController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TierController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TierController/Create
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

        // GET: TierController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TierController/Edit/5
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

        // GET: TierController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TierController/Delete/5
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
