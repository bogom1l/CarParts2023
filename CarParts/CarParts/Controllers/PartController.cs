using CarParts.Services;
using CarParts.ViewModels.Part;

namespace CarParts.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class PartController : BaseController
    {
        private readonly IPartService _partService;

        public PartController(IPartService partService)
        {
            this._partService = partService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var parts = await this._partService.GetAllPartsAsync();

            return View(parts);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddPartViewModel part = await this._partService.GetAddPartViewModelAsync();

            return View(part);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPartViewModel addPartViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(addPartViewModel);
            }
            
            await this._partService.AddPartAsync(addPartViewModel, GetUserId());

            return RedirectToAction("All");
        }

    }
}
