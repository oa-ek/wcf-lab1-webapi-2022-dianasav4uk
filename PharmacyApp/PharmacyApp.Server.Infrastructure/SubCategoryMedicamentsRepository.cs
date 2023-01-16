using Microsoft.EntityFrameworkCore;
using PharmacyApp.Server.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PharmacyApp.Server.Infrastructure
{
    public class SubCategoryMedicamentsRepository
    {
        public readonly PharmacyDbContext _ctx;

        public SubCategoryMedicamentsRepository(PharmacyDbContext ctx)
        {
            _ctx = ctx;
        }
        public List<SubCategoryMedicaments> GetAllMedicamentsFromCategory(int id)
        {
            return _ctx.SubCategoryMedicaments.Include(x => x.SubCategory).Include(x => x.Medicaments).Where(x => x.SubCategoryId == id).ToList();
        }
        public async Task<List<SubCategoryMedicaments>> GetAllMedicamentsFromSubCategory(int id)
        {
            return await _ctx.SubCategoryMedicaments.Include(x=>x.Medicaments).Where(x=>x.SubCategoryId==id).ToListAsync();
        }
        public async Task<List<SubCategoryMedicaments>> GetAllSubCategory()
        {
            return await _ctx.SubCategoryMedicaments.ToListAsync();
        }
        public async Task<List<SubCategoryMedicaments?>> GetSubCategoriesMedicament(int id)
        {
            return await _ctx.SubCategoryMedicaments.Where(x => x.MedicamentsId == id).ToListAsync();
        }

        public async Task RemoveFromSubCategory(Medicaments md, List<SubCategoryMedicaments> subCategoryMedicaments)
        {
            foreach (var sc in subCategoryMedicaments)
            {
                 _ctx.SubCategoryMedicaments.Remove(sc);
            }
        }

        public async Task AddToSubCategory(Medicaments md, List<SubCategory> list)
        {
            var subcategorymedicament = new SubCategoryMedicaments();
            foreach (var sc in list)
            {
                subcategorymedicament.MedicamentsId = md.MedicamentsId;
                subcategorymedicament.SubCategoryId = sc.SubCategoryId;                
                subcategorymedicament.SubCategory = null;
                subcategorymedicament.Medicaments = null;
                await _ctx.SubCategoryMedicaments.AddAsync(subcategorymedicament);
            }
            await _ctx.SaveChangesAsync();
        }
    }
}
