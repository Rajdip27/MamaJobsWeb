using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class JobCategoryController : Controller
    {
        private readonly IJobCategoryService _jobCategoryService;

        public JobCategoryController(IJobCategoryService jobCategoryServic)
        {
            this._jobCategoryService = jobCategoryServic;
        }

        public async Task<IActionResult> Index()
        {
            var val = await _jobCategoryService.GetAllAsync();
            return View(val);
        }

        
        public async Task<IActionResult> Details(int id)
        {
            var val = await _jobCategoryService.FindAsync(id);
            return View(val);
        }

        // GET: JobCategoryController/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JobCategory jobCategory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _jobCategoryService.InsertAsync(jobCategory);
                }
                TempData["successAlert"] = "JobCategory  save successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
        public async Task<IActionResult> Edit(int id)
        {
            var val = await _jobCategoryService.FindAsync(id);
            return View(val);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(JobCategory jobCategory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _jobCategoryService.UpdateAsync(jobCategory);
                }

                TempData["successAlert"] = "JobCategory update successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

      
        public async Task<IActionResult> Delete(int id)
        {
            var val = await _jobCategoryService.FindAsync(id);
            return View(val);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            try
            {
                var val = await _jobCategoryService.FindAsync(id);
                if (val != null)
                {
                    await _jobCategoryService.DeleteAsync(val);
                }
                TempData["successAlert"] = "JobCategory delete successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
