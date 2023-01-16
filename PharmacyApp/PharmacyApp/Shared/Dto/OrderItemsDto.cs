using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Shared.Dto
{
    public class OrderItemsDto
    {
        public int Id { get; set; }
        public MedicamentsDto medicaments { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public float Total { get { return Quantity * Price; } }
        public int OrderDetailsId { get; set; }
    }
}
