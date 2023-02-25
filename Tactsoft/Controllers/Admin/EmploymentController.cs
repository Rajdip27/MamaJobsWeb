using Microsoft.AspNetCore.Mvc;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class EmploymentController : Controller
    {
        private readonly IEmploymentService _employmentService;
        public EmploymentController(IEmploymentService employmentService)
        {
            this._employmentService = employmentService;
        }
        public async Task< IActionResult> Index()
        {
            var Result=await _employmentService.GetAllAsync();
            return View(Result);
        }
    }
}
