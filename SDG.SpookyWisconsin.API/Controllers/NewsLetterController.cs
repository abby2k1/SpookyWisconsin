using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SDG.SpookyWisconsin.API.Controllers
{
    public class NewsLetterController : Controller
    {
        // GET: NewsLetterController
        public ActionResult Index()
        {
            return View();
        }

        // GET: NewsLetterController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NewsLetterController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewsLetterController/Create
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

        // GET: NewsLetterController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NewsLetterController/Edit/5
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

        // GET: NewsLetterController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NewsLetterController/Delete/5
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
