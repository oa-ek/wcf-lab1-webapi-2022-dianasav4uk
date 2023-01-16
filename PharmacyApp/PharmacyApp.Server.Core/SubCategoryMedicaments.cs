

namespace PharmacyApp.Server.Core
{
    public class SubCategoryMedicaments
    {
        public int MedicamentsId { get; set; }
        public Medicaments? Medicaments { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory? SubCategory { get; set; }

    }
}