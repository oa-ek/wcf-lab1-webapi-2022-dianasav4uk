using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PharmacyApp.Shared.Dto
{
    public class OrderDto
    {
        public string OrderId { get; set; }
        public List<OrderItemsDto>? orderItems { get; set; }
        public float? Total { get; set; }
        public OrderAddressDto? Address { get; set; }
        public string? TypeOfDelivery { get; set; }
        public string? Payment { get; set; }
    }
}
