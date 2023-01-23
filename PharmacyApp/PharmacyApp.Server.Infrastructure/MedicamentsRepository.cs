using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PharmacyApp.Server.Core;
using PharmacyApp.Shared.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Server.Infrastructure
{
    public class MedicamentsRepository
    {
        private readonly PharmacyDbContext _ctx;
        private readonly SubCategoryMedicamentsRepository subCategoryMedicamentsRepos;
        private readonly SubCategoryRepository _subCategoryRepository;

        public MedicamentsRepository(PharmacyDbContext ctx, SubCategoryMedicamentsRepository subCategoryMedicamentsRepos,
            SubCategoryRepository subCategoryRepository)
        {
            _ctx = ctx;
            this.subCategoryMedicamentsRepos = subCategoryMedicamentsRepos;
            this._subCategoryRepository = subCategoryRepository;
        }
        public Medicaments GetMedicament(int id)
        {
            return  _ctx.Medicaments.Include(x=>x.SubCategories).ThenInclude(x=>x.SubCategory).First(x=>x.MedicamentsId == id);
        }


        public async Task<List<Medicaments>> ListMedicaments(List<SubCategoryMedicaments> medicaments)
        {
            List<Medicaments> listmedicaments = new List<Medicaments>();
            foreach (var md in medicaments)
            {
                var medics = await _ctx.Medicaments.FirstAsync(x => x.MedicamentsId == md.MedicamentsId);
                listmedicaments.Add(medics);
            }
            return listmedicaments;
        }

        public async Task<List<MedicamentsDto>> ListMedicamentsDto(List<SubCategoryMedicaments> medicaments)
        {
            List<Medicaments> listmedicaments = new List<Medicaments>();
            foreach (var md in medicaments)
            {
                var medics = await _ctx.Medicaments.FirstAsync(x => x.MedicamentsId == md.MedicamentsId);
                listmedicaments.Add(medics);
            }

            var medicamentsListDto = new List<MedicamentsDto>();
            foreach (var meds in listmedicaments)
            {
                medicamentsListDto.Add(new MedicamentsDto
                {
                    MedicamentsId = meds.MedicamentsId,
                    Name = meds.Name,
                    Code = meds.Code,
                    Price = meds.Price,
                    Image = meds.Image,
                    ReleaseForm = meds.ReleaseForm,
                    Dosage = meds.Dosage,
                    Description = meds.Description,
                });

            }
            return medicamentsListDto;
        }

        public async Task<List<MedicamentsDto>> MedicamentsDto(List<Medicaments> listmedicaments)
        {
            
            var medicamentsListDto = new List<MedicamentsDto>();
            foreach (var meds in listmedicaments)
            {
                medicamentsListDto.Add(new MedicamentsDto
                {
                    MedicamentsId = meds.MedicamentsId,
                    Name = meds.Name,
                    Code = meds.Code,
                    Price = meds.Price,
                    Image = meds.Image,
                    ReleaseForm = meds.ReleaseForm,
                    Dosage = meds.Dosage,
                    Description = meds.Description,
                });

            }
            return medicamentsListDto;
        }

        public async Task<MedicamentsDto> MedicamentDtoAsync(Medicaments med)
        {
           var SubCategories = new List<string>();
            var scats = await subCategoryMedicamentsRepos.GetSubCategoriesMedicament(med.MedicamentsId);
            var subcategories = new List<SubCategory>();
            foreach (var s in scats)
            {
                subcategories.Add(await _subCategoryRepository.GetSubCategory(s.SubCategoryId));
            }
           foreach (var s in subcategories)
            {
                SubCategories.Add(s.Name);
            }

            var medicamentDto = new MedicamentsDto();
            
                medicamentDto = new MedicamentsDto
                {
                    MedicamentsId = med.MedicamentsId,
                    Name = med.Name,
                    Code = med.Code,
                    Price = med.Price,
                    Image = med.Image,
                    ReleaseForm = med.ReleaseForm,
                    Dosage = med.Dosage,
                    Description = med.Description,
                    Subcategory = SubCategories,
                };
            return medicamentDto;
        }

        public async Task<List<Medicaments>> ListSearchMedicaments(List<SubCategoryMedicaments> medicaments, string search)
        {
            if (search == null)
            {
                return await ListMedicaments(medicaments);
            }
            else
            {
                List<Medicaments> listmedicaments = new List<Medicaments>();

                foreach (var md in medicaments)
                {
                    var medics = await _ctx.Medicaments.Where(x => x.Name.Contains(search)).FirstOrDefaultAsync(x => x.MedicamentsId == md.MedicamentsId);
                    listmedicaments.Add(medics);
                }

                return listmedicaments;
            }
        }


        public async Task<List<Medicaments>> GetAllMedicaments()
        {
            return await _ctx.Medicaments.Include(x => x.SubCategories).ThenInclude(x => x.SubCategory).ToListAsync();
        }
        /*public async Task<List<Medicaments>> GetAllMedicamentsFromCategory(SubCategory id)
        {
            return await _ctx.Medicaments.Where(x=>x.SubCategoryMedicaments==id).ToListAsync();
        }*/
        public async Task<Medicaments> InfoMedicaments(int id)
        {
            return await _ctx.Medicaments.FirstAsync(x => x.MedicamentsId==id);
        }


        public async Task DeleteMedicament(int id)
        {
            _ctx.Medicaments.Remove(GetMedicament(id));
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateAsyncDto(MedicamentsDto model)
        {
            var md = await _ctx.Medicaments.FirstOrDefaultAsync(x => x.MedicamentsId == model.MedicamentsId);
            //var subcategory = new List<SubCategory>();
            //subcategory = model.
            //if (md.Name != model.Name)
                md.Name = model.Name;

            //if (md.Code != model.Code)
                md.Code = model.Code;

            //if (md.Price != model.Price)
                md.Price = model.Price;

            //if (md.ReleaseForm != model.ReleaseForm)
                md.ReleaseForm = model.ReleaseForm;

            //if (md.Dosage != model.Dosage)
                md.Dosage = model.Dosage;

            //if (md.Description != model.Description)
                md.Description = model.Description;
            //if (model.Image != null)
            //{
                    md.Image = model.Image;
            //}

            /*if (await subCategoryMedicamentsRepos.GetSubCategoriesMedicament(md.MedicamentsId) != null)
            {
                await subCategoryMedicamentsRepos.RemoveFromSubCategory(md, await subCategoryMedicamentsRepos.GetSubCategoriesMedicament(md.MedicamentsId));
            }

            if (subcategory.Any())
            {
                await subCategoryMedicamentsRepos.AddToSubCategory(md, subcategory);
            }*/

            await _ctx.SaveChangesAsync();
        }

        public async Task<Medicaments> Create(string name, string code, float price, string? realiseform, string dosage, string photo, string description)
        {
            var newMd = new Medicaments
            {
                Name = name,
                Code = code,
                Price = price,
                ReleaseForm = realiseform,
                Dosage = dosage,
                Image = photo,
                Description = description,
            };
            _ctx.Medicaments.Add(newMd);
            await _ctx.SaveChangesAsync();


            return await _ctx.Medicaments.FirstAsync(x => x.Code == code);
            //return newMd;
        }
        /*public async Task<Medicaments> AddMedicamentByDto(MedicamentsDto medDto)
        {
            var med = new Medicaments();
            med.Name = medDto.Name;
            med.Price = medDto.Price;
            med.Code = medDto.Code;
            med.Dosage = medDto.Dosage;
            med.Description = medDto.Description;
            med.Image = medDto.Image;
            med.ReleaseForm = medDto.ReleaseForm;   
            _ctx.Medicaments.Add(med);
            await _ctx.SaveChangesAsync();
            return _ctx.Medicaments.FirstOrDefault(x => x.Name == medDto.Name);
        }*/
    }
}
