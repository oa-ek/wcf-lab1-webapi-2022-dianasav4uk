using Microsoft.EntityFrameworkCore;
using PharmacyApp.Server.Core;
using PharmacyApp.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PharmacyApp.Server.Infrastructure
{
    public class CatalogRepository
    {
        public readonly PharmacyDbContext _ctx;

        public CatalogRepository(PharmacyDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Catalog> GetCatalog(int id)
        {
            return await _ctx.Catalog.FirstAsync(x => x.Id == id);
        }
        public async Task<Catalog> GetCatalogS(string id)
        {
            return await _ctx.Catalog.FirstAsync(x => x.Name == id);
        }
        public async Task<List<Catalog>> GetAllCatalog()
        {
            return await _ctx.Catalog.ToListAsync();
        }

        public List<CatalogDto> GetAllCatalogDto()
        {
            var catalogList = _ctx.Catalog.Include(x => x.Category).ToList();
            var catalogListDto = new List<CatalogDto>();
            foreach (var catalog in catalogList)
            {
                catalogListDto.Add(new CatalogDto
                {
                    Id = catalog.Id,
                    Name = catalog.Name,
                });
            }
            return catalogListDto;
        }

        public async Task UpdateAsync(Catalog model)
        {
            var md = await _ctx.Catalog.FirstAsync(x => x.Id == model.Id);

            if (md.Name != model.Name)
                md.Name = model.Name;

            await _ctx.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var catalog = await GetCatalog(id);
            _ctx.Catalog.Remove(catalog);
            await _ctx.SaveChangesAsync();
        }

        public async Task<Catalog> CreateCatalog(string name)
        {
            var newCt = new Catalog
            {
                Name = name,
            };
            _ctx.Catalog.Add(newCt);
            await _ctx.SaveChangesAsync();

            return await _ctx.Catalog.FirstAsync(x => x.Name == name);
        }
    }
}
