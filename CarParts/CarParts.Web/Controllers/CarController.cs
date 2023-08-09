namespace CarParts.Web.Controllers
{
    using Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Data.Interfaces;
    using ViewModels.Car;
    using ViewModels.Review;
    using static Common.GlobalConstants.Car;

    public class CarController : BaseController
    {
        private static DateTime _curentEndDate = DateTime.Now.AddYears(-1);
        private readonly ICarService _carService;
        private readonly IDealerService _dealerService;
        private readonly IUserService _userService;

        public CarController(ICarService carService, IDealerService dealerService, IUserService userService)
        {
            _carService = carService;
            _dealerService = dealerService;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var cars = await _carService.GetAllCarsAsync();

            return View(cars);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var isDealer = await _dealerService.DealerExistsByUserIdAsync(GetUserId());

            if (!isDealer)
            {
                TempData["ErrorMessage"] = "You must become a dealer in order to add new cars!";
                return RedirectToAction("BecomeDealer", "Dealer");
            }

            try
            {
                var car = await _carService.GetAddCarViewModelAsync();
                return View(car);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCarViewModel car)
        {
            if (!ModelState.IsValid)
            {
                return View(car);
            }

            var dealerId = await _dealerService.GetDealerIdByUserIdAsync(GetUserId());

            if (dealerId == 0)
            {
                TempData["ErrorMessage"] = "You must become a dealer in order to add new cars!";
                return RedirectToAction("BecomeDealer", "Dealer");
            }

            try
            {
                await _carService.AddCarAsync(car, dealerId);

                TempData["SuccessMessage"] = "Car has been successfully added.";
                return RedirectToAction("All");
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
            var carExists = await _carService.ExistsByIdAsync(id);

            if (!carExists)
            {
                TempData["ErrorMessage"] = "Car with provided id does not exist! Please try again.";
                return RedirectToAction("All", "Car");
            }

            try
            {
                var detailsCarViewModel = await _carService.GetDetailsCarViewModelAsync(id);

                return View(detailsCarViewModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var car = await _carService.GetCarByIdAsync(id);

            if (car == null)
            {
                TempData["ErrorMessage"] = "Car with provided id does not exist! Please try again.";
                return RedirectToAction("All", "Car");
            }

            if (car.Dealer.UserId != GetUserId() && !User.IsAdmin())
            {
                TempData["ErrorMessage"] = "You are not authorized to edit this car!";
                return RedirectToAction("All", "Car");
            }

            try
            {
                var editCarViewModel = await _carService.GetEditCarViewModelAsync(id);

                return View(editCarViewModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditCarViewModel car)
        {
            if (!ModelState.IsValid)
            {
                return View(car);
            }

            try
            {
                await _carService.EditCarAsync(id, car);

                TempData["SuccessMessage"] = "Car has been successfully edited.";
                return RedirectToAction("All", "Car");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var car = await _carService.GetCarByIdAsync(id);

            if (car == null)
            {
                TempData["ErrorMessage"] = "Car with provided id does not exist! Please try again.";
                return RedirectToAction("All", "Car");
            }

            if (car.Dealer.UserId != GetUserId() && !User.IsAdmin())
            {
                TempData["ErrorMessage"] = "You are not authorized to delete this car!";
                return RedirectToAction("All", "Car");
            }

            try
            {
                await _carService.RemoveCarFromComparisonForAllUsersAsync(id);
                await _carService.DeleteCarAsync(id);

                TempData["SuccessMessage"] = "Car has been successfully deleted!";
                return RedirectToAction("All", "Car");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> MyCars()
        {
            if (!await _userService.IsUserDealerAsync(GetUserId()))
            {
                TempData["ErrorMessage"] = "You must become a dealer in order to see your added cars!";
                return RedirectToAction("BecomeDealer", "Dealer");
            }

            try
            {
                var cars = await _carService.GetMyCarsAsync(GetUserId());

                return View(cars);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> MyFavoriteCars()
        {
            try
            {
                var cars = await _carService.GetMyFavoriteCarsAsync(GetUserId());

                return View(cars);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> AddToFavoriteCars(int id)
        {
            var car = await _carService.GetCarByIdAsync(id);

            if (car == null)
            {
                TempData["ErrorMessage"] = "Car with provided id does not exist! Please try again.";
                return RedirectToAction("All", "Car");
            }

            var isCarMine = await _carService.IsUserOwnerOfCarByIdAsync(id, GetUserId());

            if (isCarMine && !User.IsAdmin())
            {
                TempData["ErrorMessage"] = "You can't add a car in your favorite list if you are the owner of the car.";
                return RedirectToAction("All", "Car");
            }

            var isCarInMyFavorites = await _carService.IsCarInMyFavoritesAsync(id, GetUserId());

            if (isCarInMyFavorites)
            {
                TempData["ErrorMessage"] = "The car is already in your favorite cars.";
                return RedirectToAction("MyFavoriteCars", "Car");
            }

            try
            {
                await _carService.AddCarToMyFavoriteCarsAsync(id, GetUserId());

                TempData["SuccessMessage"] = "Car has been successfully added to favorite cars!";
                return RedirectToAction("MyFavoriteCars", "Car");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> RemoveFromFavoriteCars(int id)
        {
            var car = await _carService.GetCarByIdAsync(id);

            if (car == null)
            {
                TempData["ErrorMessage"] = "Car with provided id does not exist! Please try again.";
                return RedirectToAction("MyFavoriteCars", "Car");
            }

            var isCarInMyFavorites = await _carService.IsCarInMyFavoritesAsync(id, GetUserId());

            if (!isCarInMyFavorites)
            {
                TempData["ErrorMessage"] =
                    "Car with provided id does not exist in your favorite list! Please try again.";
                return RedirectToAction("MyFavoriteCars", "Car");
            }

            try
            {
                await _carService.RemoveCarFromMyFavoriteCarsAsync(id, GetUserId());

                TempData["SuccessMessage"] = "Car successfully removed from favorite cars.";
                return RedirectToAction("All", "Car");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Search(string searchTerm, string category,
            string priceSort, string transmissionName, string fuelName, int? fromYear,
            int? toYear, int? fromHp, int? toHp, int? fromPrice, int? toPrice, bool showOnlyNonRented)
        {
            var cars = await _carService.SearchCarsAsync(searchTerm, category, priceSort,
                transmissionName, fuelName, fromYear, toYear, fromHp, toHp, fromPrice, toPrice, showOnlyNonRented);

            ViewBag.SearchTerm = searchTerm;
            ViewBag.Category = category;
            ViewBag.Transmission = transmissionName;
            ViewBag.Fuel = fuelName;
            ViewBag.FromYear = fromYear;
            ViewBag.ToYear = toYear;
            ViewBag.FromHp = fromHp;
            ViewBag.ToHp = toHp;
            ViewBag.FromPrice = fromPrice;
            ViewBag.ToPrice = toPrice;
            ViewBag.PriceSort = priceSort;
            ViewBag.ShowOnlyNonRented = showOnlyNonRented;

            return View(cars);
        }

        [HttpGet]
        public async Task<IActionResult> Rent(int id)
        {
            var carExists = await _carService.ExistsByIdAsync(id);

            if (!carExists)
            {
                TempData["ErrorMessage"] = "Car with provided id does not exist! Please try again.";
                return RedirectToAction("All", "Car");
            }

            var isUserDealer = await _dealerService.DealerExistsByUserIdAsync(GetUserId());

            if (isUserDealer && !User.IsAdmin())
            {
                TempData["ErrorMessage"] = "Dealers can't rent cars! Please register as a user.";
                return RedirectToAction("Index", "Home");
            }

            var isRentedByMe = await _carService.IsRentedByUserIdAsync(id, GetUserId());

            if (isRentedByMe)
            {
                TempData["ErrorMessage"] = "You have already rented this car!";
                return RedirectToAction("MyRentedCars", "Car");
            }

            var isRented = await _carService.IsRentedAsync(id);

            if (isRented)
            {
                TempData["ErrorMessage"] = "Car is already rented by another user. Please choose a different car.";
                return RedirectToAction("All", "Car");
            }

            try
            {
                var rentCarViewModel = await _carService.GetRentCarViewModelAsync(id);

                return View(rentCarViewModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Rent(RentCarViewModel rentCarViewModel)
        {
            if (!_carService.IsRentalPeriodValid(rentCarViewModel))
            {
                TempData["ErrorMessage"] = "Your rental period was invalid! Please try again with correct data.";
                return RedirectToAction("Details", "Car", new { id = rentCarViewModel.Id });
            }

            var userBalance = await _userService.GetUserBalanceByIdAsync(GetUserId());
            var totalMoneyToRent = _carService.TotalMoneyToRentAsync(rentCarViewModel);

            if (totalMoneyToRent > userBalance)
            {
                TempData["ErrorMessage"] = "You currently don't have enough money to rent this car!";
                return RedirectToAction("All", "Car");
            }

            try
            {
                await _carService.RentCarAsync(rentCarViewModel, GetUserId());
                await _userService.RemoveMoneyAsync(GetUserId(), totalMoneyToRent);

                TempData["SuccessMessage"] =
                    $"You have successfully rented the car to date {rentCarViewModel.RentalEndDate!.Value.ToShortDateString()}." +
                    $" You have been taxed {totalMoneyToRent} Euros.";
                return RedirectToAction("MyRentedCars", "Car");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> MyRentedCars()
        {
            var cars = await _carService.GetMyRentedCarsAsync(GetUserId());

            var isUserDealer = await _dealerService.DealerExistsByUserIdAsync(GetUserId());

            if (isUserDealer && !User.IsAdmin())
            {
                TempData["ErrorMessage"] = "Dealers don't have access here! They are not allowed to rent cars.";
                return RedirectToAction("Index", "Home");
            }

            return View(cars);
        }

        [HttpGet]
        public async Task<IActionResult> ManageRental(int id)
        {
            var carExists = await _carService.ExistsByIdAsync(id);

            if (!carExists)
            {
                TempData["ErrorMessage"] = "Car with provided id does not exist! Please try again.";
                return RedirectToAction("All", "Car");
            }

            var isUserDealer = await _dealerService.DealerExistsByUserIdAsync(GetUserId());

            if (isUserDealer && !User.IsAdmin())
            {
                TempData["ErrorMessage"] = "Dealers can't rent cars. Please register as a user.";
                return RedirectToAction("Index", "Home");
            }

            try
            {
                var rentCarViewModel = await _carService.GetRentCarViewModelAsync(id);

                _curentEndDate = (DateTime)rentCarViewModel!.RentalEndDate!;

                return View(rentCarViewModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> ManageRental(RentCarViewModel rentCarViewModel)
        {
            var hasUserMadeAnyChanges = _curentEndDate != rentCarViewModel.RentalEndDate;

            if (!hasUserMadeAnyChanges)
            {
                TempData["ErrorMessage"] = "You haven't made changes to the rental period! Please try again.";
                return RedirectToAction("MyRentedCars", "Car");
            }

            if (!_carService.IsRentalPeriodValid(rentCarViewModel))
            {
                TempData["ErrorMessage"] = "Your rental period was invalid! Please try again with correct data.";
                return View(rentCarViewModel);
            }

            var userBalance = await _userService.GetUserBalanceByIdAsync(GetUserId());
            var totalMoneyToRentMore = _carService.TotalMoneyToExtendRentAsync(rentCarViewModel, _curentEndDate);

            if (totalMoneyToRentMore > userBalance)
            {
                TempData["ErrorMessage"] = "You currently don't have enough money to rent this car!";
                return RedirectToAction("MyRentedCars", "Car");
            }

            try
            {
                await _carService.UpdateCarRentalAsync(rentCarViewModel);
                await _userService.RemoveMoneyAsync(GetUserId(), totalMoneyToRentMore);

                if (totalMoneyToRentMore > 0)
                {
                    TempData["SuccessMessage"] =
                        $"You have successfully changed the car rental. You have been charged {totalMoneyToRentMore} euros for the rental, including taxes. " +
                        $"Your new rental end date is {rentCarViewModel.RentalEndDate!.Value.ToShortDateString()}.";
                }
                else
                {
                    TempData["SuccessMessage"] =
                        $"You have successfully changed the car rental. " +
                        $"You received back: {-totalMoneyToRentMore} euros! " +
                        $"Your new rental end date is {rentCarViewModel.RentalEndDate!.Value.ToShortDateString()}.";
                }

                return RedirectToAction("MyRentedCars", "Car");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> EndRental(int id)
        {
            try
            {
                var moneyToReturn = await _carService.TotalMoneyToReturnForEndingRentalAsync(id);
                await _userService.AddCustomAmountMoneyAsync(GetUserId(), moneyToReturn);

                await _carService.EndCarRentalAsync(id);
                await _userService.RemoveMoneyAsync(GetUserId(), TaxPriceForCancelingRental);

                TempData["SuccessMessage"] = "You have successfully ended the car rental! " +
                                             $"You received back {moneyToReturn} euros " +
                                             $"and you have been taxed {TaxPriceForCancelingRental} euros.";
                return RedirectToAction("MyRentedCars", "Car");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateMyRentals()
        {
            try
            {
                var cars = await _carService.GetMyRentedCarsAsync(GetUserId());

                foreach (var car in cars)
                {
                    if (car.RentalEndDate < DateTime.Now)
                    {
                        await _carService.EndCarRentalAsync(car.Id);
                    }
                }

                return RedirectToAction("MyRentedCars", "Car");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(ReviewViewModel reviewViewModel)
        {
            var hasUserAlreadyReviewedThisCar =
                await _carService.HasUserAlreadyReviewedThisCarAsync(reviewViewModel.CarId, GetUserId());
            if (hasUserAlreadyReviewedThisCar)
            {
                TempData["ErrorMessage"] = "Sending more than one review per car is not allowed.";
                return RedirectToAction("Details", "Car", new { id = reviewViewModel.CarId });
            }

            try
            {
                await _carService.AddReviewAsync(reviewViewModel, GetUserId());

                TempData["SuccessMessage"] = "Review has been successfully added.";
                return RedirectToAction("Details", "Car", new { id = reviewViewModel.CarId });
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }


        [HttpGet]
        public async Task<IActionResult> Compare()
        {
            var cars = await _carService.GetAllCarCompareViewModelsAsync(GetUserId());

            switch (cars.Count)
            {
                case 0:
                    TempData["ErrorMessage"] =
                        $"Your comparison list is empty. Please add at least {ComparisonListMinCount} cars to compare.";
                    return RedirectToAction("All", "Car");
                case 1:
                    TempData["ErrorMessage"] = "Please add at least 1 more car to compare.";
                    return RedirectToAction("All", "Car");
                case > 5:
                    TempData["ErrorMessage"] =
                        $"You can compare up to maximum {ComparisonListMaxCount} cars! Please remove at least one.";
                    return RedirectToAction("All", "Car");
                default:
                    return View(cars);
            }
        }

        [HttpGet]
        public async Task<IActionResult> AddCarForCompare(int id)
        {
            var car = await _carService.GetCarByIdAsync(id);

            if (car == null)
            {
                TempData["ErrorMessage"] = "Car with provided id does not exist! Please try again.";
                return RedirectToAction("All", "Car");
            }

            var isCarInMyComparisonListAsync = await _carService.IsCarInMyComparisonListAsync(id, GetUserId());

            if (isCarInMyComparisonListAsync)
            {
                TempData["ErrorMessage"] = "You have already added this car for comparison!";
                return RedirectToAction("All", "Car");
            }

            var isComparisonListFull = await _carService.IsComparisonListFullAsync(GetUserId());

            if (isComparisonListFull)
            {
                TempData["ErrorMessage"] =
                    $"You can compare up to maximum {ComparisonListMaxCount} cars! Please remove at least one.";
                return RedirectToAction("Compare", "Car");
            }

            try
            {
                await _carService.AddCarForComparisonAsync(id, GetUserId());

                TempData["SuccessMessage"] = "Car has been successfully added for comparison.";
                return RedirectToAction("Details", "Car", new { id });
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> RemoveCarFromCompare(int id)
        {
            var car = await _carService.GetCarByIdAsync(id);

            if (car == null)
            {
                TempData["ErrorMessage"] = "Car with provided id does not exist! Please try again.";
                return RedirectToAction("All", "Car");
            }

            try
            {
                await _carService.RemoveCarFromComparisonAsync(id, GetUserId());

                TempData["SuccessMessage"] = "Car has been successfully removed for comparison.";
                return RedirectToAction("Compare", "Car");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> ClearMyComparisonList()
        {
            try
            {
                await _carService.ClearMyComparisonListAsync(GetUserId());

                TempData["SuccessMessage"] = "Comparison list has been successfully cleared.";
                return RedirectToAction("All", "Car");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        private IActionResult GeneralError()
        {
            TempData["ErrorMessage"] =
                "Unexpected error occurred! Please try again later or contact administrator.";

            return RedirectToAction("Index", "Home");
        }
    }
}