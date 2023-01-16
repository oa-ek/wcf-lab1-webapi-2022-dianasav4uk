using Microsoft.AspNetCore.Mvc;
using PharmacyApp.Server.Core;
using PharmacyApp.Server.Infrastructure;
using PharmacyApp.Shared.Dto;

namespace PharmacyApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MedicamentsController : Controller
    {
        private readonly PharmacyDbContext _dbcontext;
        private readonly CategoryRepository _categoryRepository;
        private readonly SubCategoryRepository _subcategoryRepository;
        private readonly CatalogRepository _catalogRepository;
        private readonly MedicamentsRepository _medicamentsRepository;
        private readonly SubCategoryMedicamentsRepository _subcategorymedicamentsRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        //private readonly 

        public MedicamentsController(CategoryRepository categoryRepository, SubCategoryRepository subcategoryRepository,
            CatalogRepository catalogRepository, MedicamentsRepository medicamentsRepository,
            SubCategoryMedicamentsRepository subcategorymedicamentsRepository, IWebHostEnvironment webHostEnvironment)
        {
            _categoryRepository = categoryRepository;
            _subcategoryRepository = subcategoryRepository;
            _catalogRepository = catalogRepository;
            _medicamentsRepository = medicamentsRepository;
            _subcategorymedicamentsRepository = subcategorymedicamentsRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        //Return INFO about MEDICAMENT
        [HttpGet("{id}")]
        public async Task<MedicamentsDto> DetailsMedicament(int id)
        {
            ViewBag.returnUrl = Request.Headers["Referer"].ToString();
            var details = await _medicamentsRepository.InfoMedicaments(id);
            var info = _medicamentsRepository.MedicamentDto(details);
            return info;
        }

        //Create Medicament
        [HttpPost]
        public async Task<Medicaments> Create(MedicamentsDto medDto)
        {
            var createdMed = await _medicamentsRepository.AddMedicamentByDto(medDto);
            return createdMed;
        }


        //Edit Medicament
        [HttpPut]
        public async Task Edit(MedicamentsDto medDto)
        {
            //var med = await _medicamentsRepository.GetMedicament(id);
            ViewBag.Subcategory = await _subcategoryRepository.GetAllSubCategory();
            //ViewBag.SubcategoryOfMed = await _subcategorymedicamentsRepository.GetSubCategoriesMedicament(med.MedicamentsId);
            ViewBag.returnUrl = Request.Headers["Referer"].ToString();
            await _medicamentsRepository.UpdateAsyncDto(medDto);
        }

        //Delete Medicament
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _medicamentsRepository.DeleteMedicament(id);
        }


    }
}
