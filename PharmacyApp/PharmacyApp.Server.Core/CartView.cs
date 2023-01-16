using PharmacyApp.Server.Core;

namespace PharmacyApp.Server.Core
{
    public class CartView
    {
        public List<ShopCartItem> shopCartItems { get; set; }
        public float GrandTotal { get; set; }
    }
}
