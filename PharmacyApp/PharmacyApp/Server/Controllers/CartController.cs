using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmacyApp.Server.Core;
using PharmacyApp.Server.Infrastructure;
using PharmacyApp.Shared;
using PharmacyApp.Shared.Dto;
using System.Data;
//using Pharmacy.UI.Models.ViewModels;

namespace PharmacyApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CartController: Controller
    {
        private readonly CartView _cartRepository;
        private readonly MedicamentsRepository _medicamentsRepository;
        private readonly OrderRepository _orderRepository;

        public CartController(MedicamentsRepository medicamentsRepository, OrderRepository orderRepository)
        {
            _medicamentsRepository = medicamentsRepository;
            _orderRepository = orderRepository;
        }
        /*
        public IViewComponentResult Invoke()
        {
            List<ShopCartItem> cart = HttpContext.Session.GetJson<List<ShopCartItem>>("Cart");
            SmallCart smallCart;

            if(cart==null || cart.Count == 0)
            {
                smallCart = null;
            }
            else
            {
                smallCart = new()
                {
                    NumberOfItems = cart.Sum(x => x.Quantity),
                    TotalAmount = cart.Sum(x => x.Quantity * x.Price),
                };
            }

            return (IViewComponentResult)View(smallCart);
        }

        public IActionResult Index()
        {
            List<ShopCartItem> cart = HttpContext.Session.GetJson<List<ShopCartItem>>("Cart") ?? new List<ShopCartItem>();
            
            CartView Cart = new()
            {
                shopCartItems = cart,
                GrandTotal = cart.Sum(x => x.Quantity * x.Price)
            };

            return View("Index", Cart);
        }*/
        [HttpPost]
        public CartView CreateOrder()
        {
            List<ShopCartItem> cart = HttpContext.Session.GetJson<List<ShopCartItem>>("Cart") ?? new List<ShopCartItem>();

            CartView Cart = new()
            {
                shopCartItems = cart,
                GrandTotal = cart.Sum(x => x.Quantity * x.Price)
            };

            return Cart;
        }

        /*
        public async Task<IActionResult> Add(int id)
        {

            Medicaments med = _medicamentsRepository.GetMedicament(id);

            List<ShopCartItem> cart = HttpContext.Session.GetJson<List<ShopCartItem>>("Cart") ?? new List<ShopCartItem>();

            ShopCartItem cartItem = cart.Where(c => c.ProductId == id).FirstOrDefault();

            if(cartItem == null)
            {
                cart.Add(new ShopCartItem(med));
            }
            else
            {
                cartItem.Quantity += 1;
            }

            HttpContext.Session.SetJson("Cart", cart);
            TempData["Success"] = "Товар доданий до корзини!";

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<IActionResult> Decrease(int id)
        {

            List<ShopCartItem> cart = HttpContext.Session.GetJson<List<ShopCartItem>>("Cart");

            ShopCartItem cartItem = cart.Where(c => c.ProductId == id).FirstOrDefault();

            if (cartItem.Quantity>1)
            {
                --cartItem.Quantity;
            }
            else
            {
                cart.RemoveAll(p=>p.ProductId == id);
            }

            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }
           
            TempData["Success"] = "Товар видалений з корзини!";

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<IActionResult> Remove(int id)
        {

            List<ShopCartItem> cart = HttpContext.Session.GetJson<List<ShopCartItem>>("Cart");

            cart.RemoveAll(p=>p.ProductId == id);

            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }

            TempData["Success"] = "Товар видалений з корзини!";

            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {

            HttpContext.Session.Remove("Cart");

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> SuccessfulOrder(int id)
        {
            //Order order = await _orderRepository.GetOrder(id);
            var details = await _orderRepository.GetOrderDetails(id);
            //ViewBag.Order = order;
            var items = await _orderRepository.GetOrderItems(details.Id);
            ViewBag.Items = items;
            return View(details);
        }*/
    }
}
