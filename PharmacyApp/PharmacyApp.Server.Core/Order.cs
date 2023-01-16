using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Server.Core
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string OrderId { get; set; }
        public User user { get; set; }        
        public float Total { get; set; }

        [Display(Name = "Date Added")]
        public DateTime OrderDate { get; set; }
        public string? Status { get; set; }
        [Display(Name = "Статус оплати")]
        public bool IsPaid { get; set; }
        public OrderDetails? details { get; set; }
   

    }
}
