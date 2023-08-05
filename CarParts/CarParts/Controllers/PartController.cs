namespace CarParts.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
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

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var parts = await _partService.GetAllPartsAsync();

            return View(parts);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            try
            {
                var part = await _partService.GetAddPartViewModelAsync();

                return View(part);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPartViewModel addPartViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(addPartViewModel);
            }


            try
            {
                await _partService.AddPartAsync(addPartViewModel, GetUserId());

                TempData["SuccessMessage"] = "Part successfully added!";
                return RedirectToAction("All", "Part");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var detailsPartViewModel = await _partService.GetDetailsPartViewModelAsync(id);

            if (detailsPartViewModel == null)
            {
                return RedirectToAction("All", "Part");
            }

            return View(detailsPartViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var part = await _partService.GetPartByIdAsync(id);

            if (part == null)
            {
                TempData["ErrorMessage"] = "Part with provided id does not exist! Please try again.";
                return RedirectToAction("All", "Part");
            }

            if (part.OwnerId != GetUserId())
            {
                TempData["ErrorMessage"] = "You are not authorized to edit this part!";
                return RedirectToAction("All", "Part");
            }


            try
            {
                var editPartViewModel = await _partService.GetEditPartViewModelAsync(id);
                return View(editPartViewModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditPartViewModel part)
        {
            if (!ModelState.IsValid)
            {
                return View(part);
            }

            try
            {
                await _partService.EditPartAsync(id, part);

                TempData["SuccessMessage"] = "Part successfully edited!";
                return RedirectToAction("All");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var part = await _partService.GetPartByIdAsync(id);

            if (part == null)
            {
                TempData["ErrorMessage"] = "Part with provided id does not exist! Please try again.";
                return RedirectToAction("All", "Part");
            }

            if (part.OwnerId != GetUserId())
            {
                TempData["ErrorMessage"] = "You are not authorized to delete this part!";
                return RedirectToAction("All", "Part");
            }

            try
            {
                await _partService.DeletePartAsync(id, GetUserId());

                TempData["SuccessMessage"] = "Part successfully deleted!";
                return RedirectToAction("All", "Part");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> MyParts()
        {
            try
            {
                var parts = await _partService.GetMyPartsAsync(GetUserId());

                return View(parts);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> MyFavoriteParts()
        {
            try
            {
                var parts = await _partService.GetMyFavoritePartsAsync(GetUserId());

                return View(parts);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> AddToFavoriteParts(int id)
        {
            var part = await _partService.GetPartByIdAsync(id);

            if (part == null)
            {
                TempData["ErrorMessage"] = "Part with provided id does not exist! Please try again.";
                return RedirectToAction("All", "Part");
            }

            var isPartInMyFavorites = await _partService.IsPartInMyFavoritesAsync(id, GetUserId());

            if (isPartInMyFavorites)
            {
                TempData["ErrorMessage"] = "The part is already in your favorite parts.";
                return RedirectToAction("All", "Part");
            }

            try
            {
                await _partService.AddPartToMyFavoritePartsAsync(id, GetUserId());
                TempData["SuccessMessage"] = "Part has been successfully added to favorite parts!";
                return RedirectToAction("MyFavoriteParts", "Part");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> RemoveFromFavoriteParts(int id)
        {
            var part = await _partService.GetPartByIdAsync(id);

            if (part == null)
            {
                TempData["ErrorMessage"] = "Part with provided id does not exist! Please try again.";
                return RedirectToAction("MyFavoriteParts", "Part");
            }

            var isPartInMyFavorites = await _partService.IsPartInMyFavoritesAsync(id, GetUserId());

            if (!isPartInMyFavorites)
            {
                TempData["ErrorMessage"] =
                    "Part with provided id does not exist in your favorite list! Please try again.";
                return RedirectToAction("MyFavoriteParts", "Part");
            }

            try
            {
                await _partService.RemovePartFromMyFavoritePartsAsync(id, GetUserId());
                TempData["SuccessMessage"] = "Part has been successfully removed from favorite parts!";
                return RedirectToAction("All", "Part");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Search(string searchTerm, string category, string priceSort,
            int? fromPrice, int? toPrice)
        {
            var parts = await _partService.SearchPartsAsync(searchTerm, category, priceSort, fromPrice, toPrice);

            return View(parts);
        }

        private IActionResult GeneralError()
        {
            TempData["ErrorMessage"] =
                "Unexpected error occurred! Please try again later or contact administrator.";

            return RedirectToAction("Index", "Home");
        }
    }
}