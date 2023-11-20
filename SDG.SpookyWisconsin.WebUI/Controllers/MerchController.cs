using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SDG.SpookyWisconsin.BL;

namespace SDG.SpookyWisconsin.WebUI.Controllers
{
    public class MerchController : Controller
    {
        // GET: MerchController
        public ActionResult Index(Guid? id = null)
        {
            if (id == null)
            {
                ViewBag.MerchTypeDesc = "All";
                return View(MerchManager.Load());
            }
            else
            {
                //ViewBag.MerchTypeDesc = MerchTypeManager.LoadById((Guid)id).Description;
                //return View(MerchManager.LoadByTypeId((Guid)id));
                return View(MerchManager.Load());
            }
        }

        // GET: MerchController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MerchController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MerchController/Create
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

        // GET: MerchController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MerchController/Edit/5
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

        // GET: MerchController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MerchController/Delete/5
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
