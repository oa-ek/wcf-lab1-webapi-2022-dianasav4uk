using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Server.Core
{
    public class OrderAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "ПІБ")]
        public string? Name { get; set; }
        [Display(Name = "Телефон")]
        public string? Phone { get; set; }
        [Display(Name = "Адреса")]
        public string? Address { get; set; }
        [Display(Name = "Email")]
        public string? Email { get; set; }
    }
}
