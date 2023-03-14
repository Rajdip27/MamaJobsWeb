using Tactsoft.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tactsoft.Service.Services;
using Microsoft.EntityFrameworkCore;
using Tactsoft.Core.ViewModel;

namespace Tactsoft.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IJobServices _jobServices;
        private readonly IPostingJobsService _postingJobsService;
        private readonly IDistrictService _districtService;
        private readonly ICountryService _countryService;

        public HomeController(ILogger<HomeController> logger,IJobServices jobServices,IPostingJobsService postingJobsService,ICountryService countryService, IDistrictService districtService)
        {
            _logger = logger;
            _jobServices = jobServices;
            _postingJobsService = postingJobsService;
            _countryService = countryService;
            _districtService = districtService;
        }

        public IActionResult Index()
        {
            FrontendViewModel vm = new FrontendViewModel();
            vm.JobViewModels = _jobServices.GetJobByCategory();
            vm.NumberOfJobs = _jobServices.NumberOfJobs();
            vm.NumberOfCompanies=_jobServices.NumberOfCompanies();
            vm.NumberOfVacancies=_jobServices.NumberOfVacancies();
            vm.HotJobsViews = _jobServices.HotJobsViews();
            return View(vm);
        }

        public IActionResult AllJobByCategory( long id)
        {
           var data=_postingJobsService.All().Where(x => x.JobCategoryeId==id).Include(x=>x.JobCategory).ToList();
            return View(data);
        }
        public async Task<IActionResult> JobDetails(long id)
        {
            var data = await _postingJobsService.FindAsync(x => x.Id == id, i => i.JobCategory, x => x.ServiceType, x => x.ResumeReceivingOption, x => x.IndustryType);
            return View(data);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}