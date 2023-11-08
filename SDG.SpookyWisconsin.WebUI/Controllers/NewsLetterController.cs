using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using SDG.SpookyWisconsin.BL;
using SDG.SpookyWisconsin.WebUI.Models;

namespace SDG.SpookyWisconsin.WebUI.Controllers
{
    public class NewsLetterController : Controller
    {
        public IActionResult Index()
        {
            return View(NewsLetterManager.Load());
        }

        public ActionResult Details(Guid id)
        {
            return View(NewsLetterManager.LoadById(id));
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
        public ActionResult Create(BL.Models.NewsLetter newsLetter, bool rollback = false)
        {
            try
            {
                NewsLetterManager.Insert(newsLetter, rollback);
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
        public ActionResult Edit(Guid id, BL.Models.NewsLetter newsLetter, bool rollback = false)
        {
            try
            {
                NewsLetterManager.Update(newsLetter, rollback);
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
            return View(NewsLetterManager.LoadById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, BL.Models.NewsLetter newsLetter, bool rollback = false)
        {
            try
            {
                NewsLetterManager.Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
