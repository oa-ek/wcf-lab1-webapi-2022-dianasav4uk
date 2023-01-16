using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Server.Core
{
    public class OrderDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public List<OrderItems>? orderItems { get; set; }
        public float? Total { get; set; }
        public OrderAddress? Address { get; set; }
        public string? TypeOfDelivery { get; set; }
        public string? Payment { get; set; }
    }
}
