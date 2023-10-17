using SDG.SpookyWisconsin.BL.Models;
using SDG.SpookyWisconsin.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Microsoft.AspNetCore.Http.Extensions;
using System.Xml.Linq;

namespace CCM.DVDCentral.UI.Controllers
{
    public class MemberController : Controller
    {
        // GET: MemberController
        public ActionResult Index()
        {
            return View(MemberManager.Load());
        }

        // GET: MemberController/Details/5
        public ActionResult Details(int id)
        {
            return View(MemberManager.LoadById(id));
        }

        // GET: MemberController/Create
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

        // POST: MemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Member member, bool rollback = false)
        {
            try
            {
                MemberManager.Insert(member, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MemberController/Edit/5
        public ActionResult Edit(int id)
        {
            if (Authenticate.IsAuthenticated(HttpContext))
            {
                return View(MemberManager.LoadById(id));
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }
        }

        // POST: MemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Member member, bool rollback = false)
        {
            try
            {
                MemberManager.Update(member, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: MemberController/Delete/5
        public ActionResult Delete(int id, Member member)
        {
            return View(MemberManager.LoadById(id));
        }

        // POST: MemberController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection, bool rollback = false)
        {
            try
            {
                MemberManager.Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
