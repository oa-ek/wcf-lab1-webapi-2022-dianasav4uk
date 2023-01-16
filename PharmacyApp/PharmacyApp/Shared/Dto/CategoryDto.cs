using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PharmacyApp.Shared.Dto
{
    public class CategoryDto
    {
        
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Catalog { get; set; }
        [Display(Name = "Фото")]
        public string? Image { get; set; }
        public List<string>? SubCategory { get; set; }

    }
}
