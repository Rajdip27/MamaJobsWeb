using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class EmploymentController : Controller
    {
        private readonly IEmploymentService _employmentService;
        private readonly IReadingService _readingService;
        private readonly IRelativeService _relativeService;
        private readonly IWritingService _writingService;
        private readonly ISpeakingService _speakingService;
        public EmploymentController(IEmploymentService employmentService, IReadingService readingService, IRelativeService relativeService, IWritingService writingService, ISpeakingService speakingService)
        {
            this._employmentService = employmentService;
            _readingService = readingService;
            _relativeService = relativeService;
            _writingService = writingService;
            _speakingService = speakingService;
        }
        public async Task< IActionResult> Index()
        {
            var Result=await _employmentService.GetAllAsync(i=>i.Speakings,i=>i.Writings, i=>i.Relatives,i=>i.Readings);
            return View(Result);
        }

        public IActionResult Create()
        {
            ViewData["ReadingId"] = _readingService.Dropdown();
            ViewData["RelativeId"] = _relativeService.Dropdown();
            ViewData["SpeakingId"] = _speakingService.Dropdown();
            ViewData["WritingId"] = _writingService.Dropdown();
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Create(Employment employment, IFormFile pictureFile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (pictureFile != null && pictureFile.Length > 0)
                    {
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Employment", pictureFile.FileName);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            pictureFile.CopyTo(stream);
                        }
                        employment.Photos = $"{pictureFile.FileName}";
                    }
                    await _employmentService.InsertAsync(employment);
                    TempData["successAlert"] = "Employment Jobs save successfull.";
                    return RedirectToAction(nameof(Index));
                }
                ViewData["ReadingId"] = _readingService.Dropdown();
                ViewData["RelativeId"] = _relativeService.Dropdown();
                ViewData["SpeakingId"] = _speakingService.Dropdown();
                ViewData["WritingId"] = _writingService.Dropdown();
                TempData["errorAlert"] = "Operation failed.";
                return View(employment);
            }
            catch
            {
                return View("Create", employment);
            }
        }
        public async Task<IActionResult> Edit(int id)
        {
            var val = await _employmentService.FindAsync(id);
            if (val == null)
            {
                return NotFound();
            }
            ViewData["ReadingId"] = _readingService.Dropdown();
            ViewData["RelativeId"] = _relativeService.Dropdown();
            ViewData["SpeakingId"] = _speakingService.Dropdown();
            ViewData["WritingId"] = _writingService.Dropdown();
            return View(val);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Employment employment, IFormFile pictureFile)
        {
            if (ModelState.IsValid)
            {

                var emp = await _employmentService.FindAsync(employment.Id);
                if (pictureFile != null && pictureFile.Length > 0)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Employment", pictureFile.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        pictureFile.CopyTo(stream);
                    }
                    employment.Photos = $"{pictureFile.FileName}";
                }
                else
                {
                    employment.Photos = emp.Photos;
                }
                await _employmentService.UpdateAsync(employment);
                TempData["successAlert"] = "Employment update successfull.";

                return RedirectToAction(nameof(Index));

            }

            return View(employment);
        }
        public async Task<IActionResult> Details(int id)
        {
            var val = await _employmentService.FindAsync(m => m.Id == id, i => i.Readings, x => x.Writings, x => x.Relatives, x => x.Speakings);
            return View(val);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var val = await _employmentService.FindAsync(m => m.Id == id, i => i.Readings, x => x.Writings, x => x.Relatives, x => x.Speakings);
            return View(val);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            try
            {
                var dc = await _employmentService.FindAsync(id);
                if (dc != null)
                {
                    await _employmentService.DeleteAsync(dc);
                }
                TempData["successAlert"] = "Employment delete successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }

        }

    }
}
