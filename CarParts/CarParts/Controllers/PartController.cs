﻿namespace CarParts.Web.Controllers
{
    using Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Data.Interfaces;
    using ViewModels.Part;

    public class PartController : BaseController
    {
        private readonly IDealerService _dealerService;
        private readonly IPartService _partService;
        private readonly IUserService _userService;

        public PartController(IPartService partService, IDealerService dealerService, IUserService userService)
        {
            _partService = partService;
            _dealerService = dealerService;
            _userService = userService;
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
            var isDealer = await _dealerService.DealerExistsByUserIdAsync(GetUserId());

            if (!isDealer)
            {
                TempData["ErrorMessage"] = "You must become a dealer in order to add new parts!";
                return RedirectToAction("BecomeDealer", "Dealer");
            }

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
        public async Task<IActionResult> Add(AddPartViewModel part)
        {
            if (!ModelState.IsValid)
            {
                return View(part);
            }

            var dealerId = await _dealerService.GetDealerIdByUserIdAsync(GetUserId());

            if (dealerId == 0)
            {
                TempData["ErrorMessage"] = "You must become a dealer in order to add new parts!";
                return RedirectToAction("BecomeDealer", "Dealer");
            }

            try
            {
                await _partService.AddPartAsync(part, dealerId);

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
            var partExists = await _partService.ExistsByIdAsync(id);

            if (!partExists)
            {
                TempData["ErrorMessage"] = "Part with provided id does not exist! Please try again.";
                return RedirectToAction("All", "Part");
            }

            try
            {
                var detailsPartViewModel = await _partService.GetDetailsPartViewModelAsync(id);

                return View(detailsPartViewModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
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

            if (part.Dealer.UserId != GetUserId() && !User.IsAdmin())
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

            if (part.Dealer.UserId != GetUserId() && !User.IsAdmin())
            {
                TempData["ErrorMessage"] = "You are not authorized to delete this part!";
                return RedirectToAction("All", "Part");
            }

            try
            {
                await _partService.DeletePartAsync(id);

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

            var isPartMine = await _partService.IsUserOwnerOfPartByIdAsync(id, GetUserId());

            if (isPartMine && !User.IsAdmin())
            {
                TempData["ErrorMessage"] =
                    "You can't add a part in your favorite list if you are the owner of the part.";
                return RedirectToAction("All", "Part");
            }

            var isPartInMyFavorites = await _partService.IsPartInMyFavoritesAsync(id, GetUserId());

            if (isPartInMyFavorites)
            {
                TempData["ErrorMessage"] = "The part is already in your favorite parts.";
                return RedirectToAction("MyFavoriteParts", "Part");
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

        [HttpGet]
        public async Task<IActionResult> Purchase(int id)
        {
            var partExists = await _partService.ExistsByIdAsync(id);

            if (!partExists)
            {
                TempData["ErrorMessage"] = "Part with provided id does not exist! Please try again.";
                return RedirectToAction("All", "Part");
            }

            var isUserDealer = await _dealerService.DealerExistsByUserIdAsync(GetUserId());

            if (isUserDealer && !User.IsAdmin())
            {
                TempData["ErrorMessage"] = "Dealers can't purchase parts! Please register as a user.";
                return RedirectToAction("Index", "Home");
            }

            var isAlreadyPurchasedByMe = await _partService.IsAlreadyPurchasedByUserIdAsync(id, GetUserId());

            if (isAlreadyPurchasedByMe)
            {
                TempData["ErrorMessage"] = "You have already purchased this car!";
                return RedirectToAction("MyPurchasedParts", "Part");
            }

            var isPurchased = await _partService.IsPurchasedAsync(id);

            if (isPurchased)
            {
                TempData["ErrorMessage"] = "Part is already purchased by another user.";
                return RedirectToAction("All", "Part");
            }

            try
            {
                var purchasePartViewModel = await _partService.GetPurchasePartViewModelAsync(id);

                return View(purchasePartViewModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Purchase(PurchasePartViewModel purchasePartViewModel)
        {
            //if (!ModelState.IsValid) TODO: twa raboti li prawilno ?
            //{
            //    return View(purchasePartViewModel);
            //}

            var userBalance = await _userService.GetUserBalanceByIdAsync(GetUserId());
            var totalMoneyToPurchase = purchasePartViewModel.Price;

            if (totalMoneyToPurchase > userBalance)
            {
                TempData["ErrorMessage"] = "You currently don't have enough money to buy this part!";
                return RedirectToAction("All", "Car");
            }

            try
            {
                await _partService.PurchasePartAsync(purchasePartViewModel, GetUserId());
                await _userService.RemoveMoneyAsync(GetUserId(), totalMoneyToPurchase);


                TempData["SuccessMessage"] =
                    "You have successfully purchased the part." +
                    $" You have been taxed {totalMoneyToPurchase} Euros.";
                return RedirectToAction("MyPurchasedParts", "Part");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> MyPurchasedParts()
        {
            var parts = await _partService.GetMyPurchasedPartsAsync(GetUserId());

            var isUserDealer = await _dealerService.DealerExistsByUserIdAsync(GetUserId());

            if (isUserDealer && !User.IsAdmin())
            {
                TempData["ErrorMessage"] = "Dealers don't have access here! They are not allowed to purchase parts.";
                return RedirectToAction("Index", "Home");
            }

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