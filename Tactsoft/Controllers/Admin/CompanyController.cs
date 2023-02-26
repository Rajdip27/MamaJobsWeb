using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Tactsoft.Controllers.Admin
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly ICountryService _countryService;
        private readonly IDistrictService _DistrictService;
        private readonly IThanaService _ThanaService;
        private readonly IIndustryTypeService _industryTypeService;
        private readonly   ICompanySizeService _companySizeService;

        
        public CompanyController(ICompanyService companyService,ICountryService countryService,IDistrictService districtService,IThanaService thanaService,IIndustryTypeService industryTypeService,ICompanySizeService  companySizeService)
        {
            _companyService = companyService;
            _countryService = countryService;
            _DistrictService = districtService;
            _ThanaService = thanaService;   
            _industryTypeService = industryTypeService;
            _companySizeService = companySizeService;
        }

        public async Task<IActionResult> Index()
        {

            var val = await _companyService.GetAllAsync(i => i.District, x => x.Thana, x => x.IndustialType, x => x.Country, x => x.CompanySize);
            return View(val);
        }


        public IActionResult Create()
        {
            ViewData["CountryId"] = _countryService.Dropdown();
            ViewData["DistrictId"] = _DistrictService.Dropdown();
            ViewData["ThanaId"] = _ThanaService.Dropdown();
            ViewData["IndustialTypeId"] = _industryTypeService.Dropdown();
            ViewData["CompanySizeId"] = _companySizeService.Dropdown();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Company company)
        {


            try
            {
                if (ModelState.IsValid)
                {
                    await _companyService.InsertAsync(company);
                    TempData["successAlert"] = "company  save successfully.";
                    return RedirectToAction(nameof(Index));
                }
                ViewData["CountryId"] = _countryService.Dropdown();
                ViewData["DistrictId"] = _DistrictService.Dropdown();
                ViewData["ThanaId"] = _ThanaService.Dropdown();
                ViewData["IndustialTypeId"] = _industryTypeService.Dropdown();
                ViewData["CompanySizeId"] = _companySizeService.Dropdown();
                return View(company);
            }
            

            catch
            {
                return View("Create", company);
            }



        }


        public async Task<IActionResult> Edit(int id)
        {
            var val = await _companyService.FindAsync(id);
            if (val == null)
            {
                return NotFound();
            }

            ViewData["CountryId"] = _countryService.Dropdown();
            ViewData["DistrictId"] = _DistrictService.Dropdown();
            ViewData["ThanaId"] = _ThanaService.Dropdown();
            ViewData["IndustialTypeId"] = _industryTypeService.Dropdown();
            ViewData["CompanySizeId"] = _companySizeService.Dropdown();
            

            return View(val);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Company company)
        {
            if (ModelState.IsValid)
            {
                await _companyService.UpdateAsync(company);
                TempData["successAlert"] = "company update successfull.";
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = _countryService.Dropdown();
            ViewData["DistrictId"] = _DistrictService.Dropdown();
            ViewData["ThanaId"] = _ThanaService.Dropdown();
            ViewData["IndustialTypeId"] = _industryTypeService.Dropdown();
            ViewData["CompanySizeId"] = _companySizeService.Dropdown();

            return View(company);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var dc = await _companyService.FindAsync(m => m.Id == id, i => i.District, x => x.Thana, x => x.Country, x => x.CompanySize, x => x.IndustialType);
            if (dc == null)
            {
                return NotFound();
            }

            ViewData["CountryId"] = _countryService.Dropdown();
            ViewData["DistrictId"] = _DistrictService.Dropdown();
            ViewData["ThanaId"] = _ThanaService.Dropdown();
            ViewData["IndustialTypeId"] = _industryTypeService.Dropdown();
            ViewData["CompanySizeId"] = _companySizeService.Dropdown();

            return View(dc);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            try
            {
                var dc = await _companyService.FindAsync(id);
                if (dc != null)
                {
                    await _companyService.DeleteAsync(dc);
                }
                TempData["successAlert"] = "company delete successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }

        public async Task<IActionResult> Details(int id)
        {
            var val = await _companyService.FindAsync(m => m.Id == id, i => i.District, x => x.Thana,  x => x.IndustialType, x => x.Country, x => x.CompanySize);
            return View(val);
        }

    }
}
