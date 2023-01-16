using Microsoft.AspNetCore.Mvc;
using PharmacyApp.Server.Core;
using PharmacyApp.Server.Infrastructure;

namespace PharmacyApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SmallCartController : Controller
    {
        private readonly MedicamentsRepository _medicamentsRepository;

        public SmallCartController(MedicamentsRepository medicamentsRepository)
        {
            _medicamentsRepository = medicamentsRepository;
            //_shopcartRepository = shoppingCartRepository;
        }

        [HttpGet]
        public SmallCart Index()
        {
            List<ShopCartItem> cart = HttpContext.Session.GetJson<List<ShopCartItem>>("Cart");
            SmallCart smallCart;

            if (cart == null || cart.Count == 0)
            {
                smallCart = null;
            }
            else
            {
                smallCart = new()
                {
                    NumberOfItems = cart.Sum(x => x.Quantity),
                    TotalAmount = cart.Sum(x => x.Quantity * x.Price)
                };
            }

            return smallCart;
        }
    }
}
