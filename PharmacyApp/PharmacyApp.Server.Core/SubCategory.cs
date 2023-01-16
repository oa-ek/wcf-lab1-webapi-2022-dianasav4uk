using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Server.Core
{
    public class SubCategory
    {
        /*public SubCategory()
        {
            this.Medicaments = new HashSet<Medicaments>();
        }*/
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubCategoryId { get; set; }
        public string? Name { get; set; }
        public Category? Category { get; set; }
        public virtual ICollection<SubCategoryMedicaments>? Medicaments { get; set; } = new HashSet<SubCategoryMedicaments>();
    }
    
}
