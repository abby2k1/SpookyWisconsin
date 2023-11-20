using SDG.SpookyWisconsin.BL.Models;
using SDG.SpookyWisconsin.BL;
using SDG.SpookyWisconsin.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Microsoft.AspNetCore.Http.Extensions;
using System.Xml.Linq;

namespace SDG.SpookyWisconsin.WebUI.Controllers
{
    public class ParticipantController : Controller
    {
        // GET: ParticipantController
        public ActionResult Index()
        {
            return View(ParticipantManager.Load());
        }

        // GET: ParticipantController/Details/5
        public ActionResult Details(Guid id)
        {
            return View(ParticipantManager.LoadById(id));
        }

        // GET: ParticipantController/Create
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

        // POST: ParticipantController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Participant participant, bool rollback = false)
        {
            try
            {
                ParticipantManager.Insert(participant, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ParticipantController/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (Authenticate.IsAuthenticated(HttpContext))
            {
                //return View(ParticipantManager.LoadById(id));
                return View();
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }
        }

        // POST: ParticipantController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, Participant participant, bool rollback = false)
        {
            try
            {
                ParticipantManager.Update(participant, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: ParticipantController/Delete/5
        public ActionResult Delete(Guid id, Participant participant)
        {
            return View(ParticipantManager.LoadById(id));
        }

        // POST: ParticipantController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection, bool rollback = false)
        {
            try
            {
                ParticipantManager.Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
