using Microsoft.AspNetCore.Mvc;

namespace SDG.SpookyWisconsin.WebUI.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
