using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class OtherBenfitsController : Controller
    {
        private readonly IOtherBenfitsService  _otherBenfitsService;
        public OtherBenfitsController(IOtherBenfitsService otherBenfitsService  )
        {
            this._otherBenfitsService = otherBenfitsService;
        }

        public async Task<IActionResult> Index()
        {
            var Result = await _otherBenfitsService.GetAllAsync();
            return View(Result);
        }


        public async Task<IActionResult> Details(int id)
        {
            var Result = await _otherBenfitsService.FindAsync(id);
            return View(Result);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OtherBenfits otherBenfits)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _otherBenfitsService.InsertAsync(otherBenfits);
                    TempData["successAlert"] = "Other Benfits Save Successfull.";
                    return RedirectToAction(actionName: nameof(Index));
                }
                return View(otherBenfits);

            }
            catch
            {
                return View("Create", otherBenfits);
            }
        }


        public async Task<ActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Result = await _otherBenfitsService.FindAsync(id);
            return View(Result);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(OtherBenfits otherBenfits)
        {
            try
            {
                var Result = await _otherBenfitsService.FindAsync(otherBenfits.Id);
                if (Result != null)
                {
                    Result.BenfitName = otherBenfits.BenfitName;
                    await _otherBenfitsService.UpdateAsync(Result);
                    TempData["successAlert"] = "Other Benfits Update Successfull.";
                    return RedirectToAction(actionName: nameof(Index));

                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return View(otherBenfits);
            }
        }


        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Result = await _otherBenfitsService.FindAsync(id);
            return View(Result);
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deletecon(int id)
        {
            try
            {
                var Result = await _otherBenfitsService.FindAsync(id);
                if (Result == null)
                {
                    return NotFound();
                }
                await _otherBenfitsService.DeleteAsync(Result);
                TempData["successAlert"] = "Other Benfits Delete Successfull.";
                return RedirectToAction(actionName: nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
