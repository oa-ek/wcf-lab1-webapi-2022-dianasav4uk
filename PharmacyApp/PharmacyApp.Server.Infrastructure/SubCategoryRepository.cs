using Microsoft.EntityFrameworkCore;
using PharmacyApp.Server.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PharmacyApp.Server.Infrastructure
{
    public class SubCategoryRepository
    {
        public readonly PharmacyDbContext _ctx;

        public SubCategoryRepository(PharmacyDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<SubCategory> GetSubCategory(int id)
        {
            return await _ctx.SubCategory.FirstAsync(x=>x.SubCategoryId == id);
        }
        public async Task<List<SubCategory>> GetAllSubCategory()
        {
            return await _ctx.SubCategory.Include(x => x.Category).ToListAsync();
        }
        public async Task<List<SubCategory>> GetAllSubCategoryFromCategory(Category id)
        {
            return await _ctx.SubCategory.Include(x => x.Category).Where(x=>x.Category.Id == id.Id).ToListAsync();
        }
        public async Task<SubCategory> GetSubCategoryS(string name)
        {
            return await _ctx.SubCategory.FirstAsync(x=>x.Name == name);
        }


        public async Task AddToCategory(SubCategory md, List<Category> list)
        {
            foreach (var sc in list)
            {
                md.Category= sc;
            }
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(SubCategory model, List<Category> category)
        {
            var md = await _ctx.SubCategory.FirstAsync(x => x.SubCategoryId == model.SubCategoryId);

            if (md.Name != model.Name)
                md.Name = model.Name;
            //if (md.Category != model.Category)
                md.Category = null;

            if (category.Any())
            {
                await AddToCategory(md, category);
            }

            await _ctx.SaveChangesAsync();
        }

        public async Task<SubCategory> CreateSubCategory(string name, List<Category> category)
        {
            var newCt = new SubCategory
            {
                Name = name,
            };
            _ctx.SubCategory.Add(newCt);
            await _ctx.SaveChangesAsync();

            await AddToCategory(newCt, category);


            return await _ctx.SubCategory.FirstAsync(x => x.Name == name);
        }

        public async Task Delete(int id)
        {
            var subcategory = await GetSubCategory(id);
            _ctx.SubCategory.Remove(subcategory);
            await _ctx.SaveChangesAsync();
        }
    }
}
