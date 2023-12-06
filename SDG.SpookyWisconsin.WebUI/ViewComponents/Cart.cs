using SDG.SpookyWisconsin.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace SDG.SpookyWisconsin.WebUI.ViewComponents
{
    public class Cart : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            if (HttpContext.Session.GetObject<BL.Models.Cart>("cart") != null)
            {
                return View(HttpContext.Session.GetObject<BL.Models.Cart>("cart"));
            }
            else
            {
                return View(new BL.Models.Cart());
            }
        }
    }
}
