namespace CarParts.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Data.Interfaces;
    using ViewModels.Part;

    public class PartController : BaseController
    {
        private readonly IPartService _partService;

        public PartController(IPartService partService)
        {
            _partService = partService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var parts = await _partService.GetAllPartsAsync();

            return View(parts);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var part = await _partService.GetAddPartViewModelAsync();

            return View(part);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPartViewModel addPartViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(addPartViewModel);
            }

            await _partService.AddPartAsync(addPartViewModel, GetUserId());

            TempData["SuccessMessage"] = "Part successfully added!";
            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var detailsPartViewModel = await _partService.GetPartDetailsAsync(id);

            if (detailsPartViewModel == null)
            {
                RedirectToPage("All");
            }

            return View(detailsPartViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var part = await _partService.GetPartByIdAsync(id);

            if (part == null)
            {
                return RedirectToAction("All");
            }

            if (part.UserId != GetUserId())
            {
                return RedirectToAction("All");
            }

            var editPartViewModel = await _partService.GetEditPartViewModelAsync(id, GetUserId());

            if (editPartViewModel == null)
            {
                RedirectToPage("All");
            }

            return View(editPartViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditPartViewModel part)
        {
            if (!ModelState.IsValid)
            {
                return View(part);
            }

            await _partService.EditPartAsync(id, part);

            TempData["SuccessMessage"] = "Part successfully edited!";
            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var part = await _partService.GetPartByIdAsync(id);

            if (part == null)
            {
                return RedirectToAction("All");
            }

            if (part.UserId != GetUserId())
            {
                return RedirectToAction("All");
            }

            await _partService.DeletePartAsync(id, GetUserId());

            TempData["SuccessMessage"] = "Part successfully deleted!";
            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> MyParts()
        {
            var parts = await _partService.GetMyPartsAsync(GetUserId());

            return View(parts);
        }

        [HttpGet]
        public async Task<IActionResult> MyFavoriteParts()
        {
            var parts = await _partService.GetMyFavoritePartsAsync(GetUserId());

            return View(parts);
        }

        [HttpGet]
        public async Task<IActionResult> AddToFavoriteParts(int id)
        {
            var part = await _partService.GetPartByIdAsync(id);

            if (part == null)
            {
                TempData["ErrorMessage"] = "The part does not exist.";
                return RedirectToAction("All");
            }

            if (!await _partService.AddPartToMyFavoritePartsAsync(id, GetUserId()))
            {
                TempData["ErrorMessage"] = "The part is already in your favorite parts.";
                return RedirectToAction("All");
            }

            TempData["SuccessMessage"] = "Part successfully added to favorite parts!";
            return RedirectToAction("MyFavoriteParts");
        }

        [HttpGet]
        public async Task<IActionResult> RemoveFromFavoriteParts(int id)
        {
            var part = await _partService.GetPartByIdAsync(id);

            if (part == null)
            {
                TempData["ErrorMessage"] = "The part does not exist.";
                return RedirectToAction("MyFavoriteParts");
            }

            if (!await _partService.RemovePartFromMyFavoritePartsAsync(id, GetUserId()))
            {
                TempData["ErrorMessage"] = "The part does not exist.";
                return RedirectToAction("MyFavoriteParts");
            }

            TempData["SuccessMessage"] = "Part successfully removed from favorite parts!";
            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Search(string searchTerm, string category,
            string priceSort, int? fromPrice, int? toPrice)
        {
            var parts = await _partService.SearchPartsAsync(searchTerm, category, priceSort, fromPrice, toPrice);

            return View(parts);
        }
    }
}