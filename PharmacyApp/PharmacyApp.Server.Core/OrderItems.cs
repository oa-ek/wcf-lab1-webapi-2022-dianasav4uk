using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Server.Core
{
    public class OrderItems
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Medicaments medicaments { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public float Total { get { return Quantity * Price; } }
        public int OrderDetailsId { get; set; }
    }
}
