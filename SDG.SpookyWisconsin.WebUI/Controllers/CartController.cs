using SDG.SpookyWisconsin.BL;
using SDG.SpookyWisconsin.BL.Models;
//using SDG.SpookyWisconsin.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace SDG.SpookyWisconsin.WebUI.Controllers
{
    public class CartController : Controller
    {
        Cart cart;
        // GET: CartController
        public ActionResult Index()
        {
            ViewBag.Title = "Cart";
            cart = GetCart();
            
            return View(cart);
        }

        private Cart GetCart()
        {
            if (HttpContext.Session.GetObject<Cart>("cart") != null)
            {
                return HttpContext.Session.GetObject<Cart>("cart");
            }
            else
            {
                return new Cart();
            }
        }

        public IActionResult AddToCart(Guid id)
        {
            /*cart = GetCart();
            Merch merch = MerchManager.LoadById(id);
            cart.Items.Add(merch);
            HttpContext.Session.SetObject("cart", cart);
            return RedirectToAction("Index");*/
            cart = GetCart();
            bool addnew = true;
            if (MerchManager.LoadById(id).InStkQty > 0)
            {
                foreach (OrderItem oi in cart.Items)
                {
                    if (oi.MerchId == id)
                    {
                        if (oi.Quantity < MerchManager.LoadById(oi.MerchId).InStkQty)
                        {
                            oi.Quantity += 1;
                        }
                        addnew = false;
                    }
                }
                if (addnew)
                {
                    OrderItem oi = new OrderItem();
                    Merch m = MerchManager.LoadById(id);
                    oi.MerchId = id;
                    oi.Cost = m.Cost;
                    oi.Quantity = 1;
                    oi.ProductName = m.MerchName;
                    oi.ProductDescription = m.Description;
                    cart.Items.Add(oi);
                }
            }
            HttpContext.Session.SetObject("cart", cart);
            return RedirectToAction(nameof(Index), "Merch");
        }
        
        public IActionResult Remove(Guid id)
        {
            cart = GetCart();
            cart.Items.Remove(cart.Items.FirstOrDefault(i => i.MerchId == id));
            HttpContext.Session.SetObject("cart", cart);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Checkout()
        {
            cart = GetCart();

            // Create a new Order Object and it's Order.OrderItems.
            // Loop through the ShoppingCart.Movies and them to the Order.OrderItems.

            Order order = new Order();
            order.OrderItems = cart.Items;
            order.CustomerId = GetCustomerId();
            order.UserId = GetUserId();
            order.OrderDate = DateTime.Now;
            order.ShipDate = DateTime.Now.AddDays(3);

            OrderManager.Insert(order);
            foreach(var item in cart.Items)
            {
                Merch merch = MerchManager.LoadById(item.MerchId);
                merch.InStkQty -= item.Quantity;
                MerchManager.Update(merch);
            }

            HttpContext.Session.SetObject("cart", null);

            return View();
        }
        
        private Guid GetCustomerId()
        {
            Guid customerId;
            if (HttpContext.Session.GetObject<Guid>("customerId") != null)
            {
                customerId = HttpContext.Session.GetObject<Guid>("customerId");
            }
            else
            {
                customerId = Guid.Empty;
            }
            return customerId;
        }
        
        private Guid GetUserId()
        {
            Guid userId;
            if (HttpContext.Session.GetObject<Guid>("userId") != null)
            {
                userId = HttpContext.Session.GetObject<Guid>("userId");
            }
            else
            {
                userId = Guid.Empty;
            }
            return userId;
        }
    }
}
