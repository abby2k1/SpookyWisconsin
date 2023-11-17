using SDG.SpookyWisconsin.BL;
using SDG.SpookyWisconsin.BL.Models;
//using SDG.SpookyWisconsin.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace SDG.SpookyWisconsin.WebUI.Controllers
{
    public class CartController : Controller
    {
    //    Cart cart;
    //    // GET: CartController
    //    public ActionResult Index()
    //    {
    //        ViewBag.Title = "Cart";
    //        cart = GetCart();
            
    //        return View(cart);
    //    }

    //    private Cart GetCart()
    //    {
    //        if (HttpContext.Session.GetObject<Cart>("cart") != null)
    //        {
    //            return HttpContext.Session.GetObject<Cart>("cart");
    //        }
    //        else
    //        {
    //            return new Cart();
    //        }
    //    }

    //    public IActionResult AddToCart(Guid id)
    //    {
    //        cart = GetCart();
    //        Merch merch = MerchManager.LoadById(id);
    //        cart.Items.Add(merch);
    //        HttpContext.Session.SetObject("cart", cart);
    //        return RedirectToAction("Index");
    //    }
        
    //    public IActionResult Remove(Guid id)
    //    {
    //        cart = GetCart();
    //        Merch merch = cart.Items.FirstOrDefault(i => i.Id == id);
    //        cart.Items.Remove(merch);
    //        HttpContext.Session.SetObject("cart", cart);
    //        return RedirectToAction("Index");
    //    }

    //    public IActionResult Checkout()
    //    {
    //        cart = GetCart();
    //        CartManager.Checkout(cart);
    //        HttpContext.Session.SetObject("cart", null);
    //        return View();
    //    }
    }
}
