using Microsoft.AspNetCore.Mvc;

namespace SDG.SpookyWisconsin.WebUI.Controllers
{
    public class NewsLetterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
