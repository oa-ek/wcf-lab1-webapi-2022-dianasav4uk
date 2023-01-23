using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyApp.Server.Core;
using PharmacyApp.Server.Infrastructure;
using PharmacyApp.Shared.Dto;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace PharmacyApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OrderController : Controller
    {
        private readonly CartView _cartRepository;
        private readonly MedicamentsRepository _medicamentsRepository;
        private readonly OrderRepository _orderRepository;
        private readonly UserManager<User> userManager;

        public OrderController(MedicamentsRepository medicamentsRepository, OrderRepository orderRepository)
        {
            _medicamentsRepository = medicamentsRepository;
            _orderRepository = orderRepository;
        }

        [HttpPost]
        public IActionResult FormOrder()
        {
            List<ShopCartItem> cart = HttpContext.Session.GetJson<List<ShopCartItem>>("Cart");
            return RedirectToAction("CreateOrder","Cart");
        }

        [HttpGet("{orderDetails}")]
        public async Task<OrderDto> Create(int id)
        {
            List<ShopCartItem> cart = HttpContext.Session.GetJson<List<ShopCartItem>>("Cart");
            //var user = await _usersRepository.GetCurrentUser();
            var od = await _orderRepository.GetOrderDetails(id);
            Order order = await _orderRepository.CreateOrder(cart, od);
            //Order order = await _orderRepository.GetOrderUser(user);
            var Order = await _orderRepository.OrderCreateDto(order);
            return Order;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(string Address, string payment, string phone, string name, string email, string typeofdelivery)
        {
            List<ShopCartItem> cart = HttpContext.Session.GetJson<List<ShopCartItem>>("Cart");
            OrderDetails d = await _orderRepository.CreateOrderDetails();

            // var od = await _orderRepository.GetOrderDetails(d.Id);
            await _orderRepository.CreateOrderItems(cart, d);
            var orderitems = await _orderRepository.GetOrderItems(d.Id);
            var total = (float)0.0;
            foreach (var i in cart)
                total = cart.Sum(x => x.Total);

            if (typeofdelivery == "Нова пошта - Доставка до відділення")
                total += 50;
            else if (typeofdelivery == "Нова пошта - Доставка за адресою")
                total += 80;
            else if (typeofdelivery == "Укрпошта - Доставка до відділення")
                total += 50;
            else if (typeofdelivery == "Укрпошта - Доставка за адресою")
                total += 55;

            await _orderRepository.AddItems(d.Id, orderitems, total);
            await _orderRepository.AddInfo(d.Id, Address, email, phone, name, payment, typeofdelivery);
            var details = await _orderRepository.GetOrderDetails(d.Id);
            return RedirectToAction("Create", details.Id);
            //return d;
        }

        [HttpGet("{id}")]
        public async Task<OrderDto> Details(string id)
        {
            var order = await _orderRepository.GetOrder(id);
            var detid = order.details;
            var orderDto = await _orderRepository.OrderCreateDto(order);
            //ViewBag.Order = order;
            //var items = await _orderRepository.GetOrderItems(detid.Id);
            //ViewBag.Items = items;
            return orderDto;
        }

        /*[HttpGet]
        public async Task<OrderDto> OrderCreateDto(List<OrderItemsDto>? orderItems, OrderAddressDto? Address)
        {
            
            var order = _orderRepository.OrderCreateDto(details);
            return info;
        }*/



    }
}
