using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;

namespace PharmacyApp.Server.Core
{
    public class ShopCartItem
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public float Total { get { return Quantity * Price; }}
        public string Image  { get; set; }

        public string Brend { get; set; }
        public string Country { get; set; }
        

        public ShopCartItem() { }


        public ShopCartItem(Medicaments medicaments) 
        {
            ProductId = medicaments.MedicamentsId;
            ProductName = medicaments.Name;
            Price = medicaments.Price;
            Quantity = 1;
            Image = medicaments.Image;
            //Brend = medicaments.Brend.ToString();
            //Country = medicaments.Country.ToString();
        }


    }
}
