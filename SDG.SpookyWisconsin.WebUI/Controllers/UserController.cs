using SDG.SpookyWisconsin.BL.Models;
using SDG.SpookyWisconsin.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

namespace SDG.SpookyWisconsin.WebUI.Controllers
{
    public class UserController : Controller
    {

        public void SetUser(User user)
        {
            HttpContext.Session.SetObject("user", user);
            if (user != null)
            {
                HttpContext.Session.SetObject("fullname", "Welcome " + user.UserName);
            }
            else
            {
                HttpContext.Session.SetObject("fullname", string.Empty);
            }
        }
        


        public IActionResult Logout()
        {   
            SetUser(null);
            return View();
        }

        public IActionResult Login(string returnUrl)
        {
            UserManager.Seed();
            TempData["returnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            try
            {
                bool result = UserManager.Login(user);
                SetUser(user);

                if (TempData["returnUrl"] != null)
                    return Redirect(TempData["returnUrl"]?.ToString());
                else
                    return RedirectToAction(nameof(Index), "Home");
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                return View(user);
            }
        }

        // GET: UserController
        public ActionResult Index()
        {
            return View(UserManager.Load());
        }

        // GET: UserController
        public ActionResult Seed()
        {
            UserManager.Seed();
            return View();
        }

        // GET: UserController/Details/5
        public ActionResult Details(Guid id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
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

        // GET: UserController/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
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

        // GET: UserController/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, BL.Models.User user, bool rollback = false)
        {
            try
            {
                UserManager.Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
