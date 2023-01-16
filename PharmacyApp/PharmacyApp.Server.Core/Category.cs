using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Server.Core
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public Catalog? Catalog { get; set; }
        [Display(Name = "Фото")]
        public string? Image { get; set; }
        public virtual ICollection<SubCategory>? SubCategory { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}
