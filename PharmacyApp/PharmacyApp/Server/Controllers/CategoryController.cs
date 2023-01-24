using Microsoft.AspNetCore.Mvc;
using PharmacyApp.Server.Core;
using PharmacyApp.Server.Infrastructure;
using PharmacyApp.Shared;
using PharmacyApp.Shared.Dto;
using System.Diagnostics;

namespace PharmacyApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly PharmacyDbContext _dbcontext;
        private readonly CategoryRepository _categoryRepository;
        private readonly CatalogRepository _catalogRepository;
        private readonly SubCategoryRepository _subcategoryRepository;
        private readonly MedicamentsRepository _medicamentsRepository;
        private readonly SubCategoryMedicamentsRepository _subcategorymedicamentsRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CategoryController(CategoryRepository categoryRepository, SubCategoryRepository subcategoryRepository,
            CatalogRepository catalogRepository, MedicamentsRepository medicamentsRepository,
            SubCategoryMedicamentsRepository subcategorymedicamentsRepository, IWebHostEnvironment webHostEnvironment)
        {
            _categoryRepository = categoryRepository;
            _subcategoryRepository = subcategoryRepository;
            _catalogRepository = catalogRepository;
            _medicamentsRepository = medicamentsRepository;
            _subcategorymedicamentsRepository = subcategorymedicamentsRepository;
            _webHostEnvironment = webHostEnvironment;
            //_cartViewRepository = cartViewRepository;
        }

        //CATALOG
        [HttpGet]
        public List<CatalogDto> GetCatalogDtoAsync()
        {
            var catalog = _catalogRepository.GetAllCatalogDto();
            return catalog;
        }
        //

        //CATEGORY
        [HttpGet("{id}")]
        public async Task<List<CategoryDto>> GetCategoryWithSubDto(int id)
        {
            //ViewData["id"] = id;
            var catalog = await _catalogRepository.GetCatalog(id);
            //ViewData["catalog"] = catalog;
            var categories = await _categoryRepository.GetCategoryCatalogWithSubDto(id);
            return categories;
        }

        // Return MEDICAMENTS from SUBCATEGORY
        [HttpGet("{id}")]
        public async Task<List<MedicamentsDto>> CategoryProducts(int id)
        {
            //Medicaments med = await _medicamentsRepository.GetMedicament(id);
            //List<ShopCartItem> cart = HttpContext.Session.GetJson<List<ShopCartItem>>("Cart") ?? new List<ShopCartItem>();
            //HttpContext.Session.SetJson("Cart", cart);

            //ViewData["id"] = id;
            var subcategory = await _subcategoryRepository.GetSubCategory(id);
            var medicamentsSub = await _subcategorymedicamentsRepository.GetAllMedicamentsFromSubCategory(subcategory.SubCategoryId);
            //ViewData["title"] = subcategory.Name;
            // ViewData["subcategory"] = subcategory.SubCategoryId;
            //ViewBag.CartItem = cart;
            var list = await _medicamentsRepository.ListMedicamentsDto(medicamentsSub);
            //var meds = await _medicamentsRepository.MedicamentsDto(list);
            return list;
        }

        //Return all MEDICAMENTS from CATEGORY
        [HttpGet("{id}")]
        public async Task<List<MedicamentsDto>> CategoryAllProductsDto(int id)
        {
            var category = await _categoryRepository.GetCategory(id);
            //ViewData["title"] = category.Name;
            var subcategories = await _subcategoryRepository.GetAllSubCategoryFromCategory(category);
            List<SubCategoryMedicaments> medicaments = new List<SubCategoryMedicaments>();
            foreach (var ct in subcategories)
            {
                medicaments.AddRange(await _subcategorymedicamentsRepository.GetAllMedicamentsFromSubCategory(ct.SubCategoryId));
            }

            var listMeds = await _medicamentsRepository.ListMedicamentsDto(medicaments);
            return listMeds;
        }

        //SEARCH
        [HttpPut]
        public async Task<List<MedicamentsDto>> CategoryProductsS(int id, string customerName)
        {
            //ViewData["id"] = id;
            var subcategory = await _subcategoryRepository.GetSubCategory(id);
            //ViewData["title"] = subcategory.Name;
            //ViewData["subcategory"] = subcategory.SubCategoryId;
            var medicaments = await _subcategorymedicamentsRepository.GetAllMedicamentsFromSubCategory(subcategory.SubCategoryId);
            var list = await _medicamentsRepository.ListSearchMedicaments(medicaments, customerName);
            var listMeds = await _medicamentsRepository.MedicamentsDto(list);
            return listMeds;
        }









    }
}