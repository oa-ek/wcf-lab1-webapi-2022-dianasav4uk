using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PharmacyApp.Shared.Dto
{
    public class OrderAddressDto
    {
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
