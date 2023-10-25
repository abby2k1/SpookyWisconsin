using Microsoft.AspNetCore.Mvc;

namespace SDG.SpookyWisconsin.WebUI.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
