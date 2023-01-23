using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PharmacyApp.Shared.Dto
{
    public class MedicamentsDto
    {
        public int MedicamentsId { get; set; }
        public string? Name { get; set; }
        [Display(Name = "Артикул")]
        public string Code { get; set; }
        [Display(Name = "Ціна")]
        public float Price { get; set; }
        [Display(Name = "Фото")]
        public string? Image { get; set; }
        [Display(Name = "Форма випуску")]
        public string ReleaseForm { get; set; }
        [Display(Name = "Дозування")]
        public string Dosage { get; set; }
        [Display(Name = "Опис")]
        public string? Description { get; set; }
        public List<string>? Subcategory { get; set; }
       
    }
}
