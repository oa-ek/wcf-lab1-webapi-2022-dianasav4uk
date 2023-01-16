using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmacyApp.Server.Core;

namespace PharmacyApp.Server.Infrastructure
{
    public class CartViewRepository
    {
        public readonly PharmacyDbContext _ctx;
        private readonly CartView cartView;

        public CartViewRepository(PharmacyDbContext ctx)
        {
            _ctx = ctx;
            //this.cartView = cartView;
        }
        public CartView Create(List<ShopCartItem> cart)
        {
            CartView Cart = new()
            {
                shopCartItems = cart,
                GrandTotal = cart.Sum(x => x.Quantity * x.Price)
            };
            return Cart;
        }


    }
}
