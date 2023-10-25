using Microsoft.AspNetCore.Mvc;

namespace SDG.SpookyWisconsin.WebUI.Controllers
{
    public class MerchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
