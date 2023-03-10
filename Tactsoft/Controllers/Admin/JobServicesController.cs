using Microsoft.AspNetCore.Mvc;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class JobServicesController : Controller
    {
        private readonly IDistrictService _districtService;
        private readonly IJobServices _IJobServices;
        private readonly ICountryService _countryService;
        public JobServicesController(IJobServices iJobServices)
        {

            _IJobServices = iJobServices;
        }


        public IActionResult Index()
        {
            var data = _IJobServices.GetJobCount();
            ViewData["jobCategoryList"] = data;
            return View();
        }

    }
}
