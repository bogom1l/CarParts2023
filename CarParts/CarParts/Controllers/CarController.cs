namespace CarParts.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Data.Interfaces;
    using ViewModels.Car;
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

            var car = await _carService.GetAddCarViewModelAsync();

            return View(car);
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

            await _carService.AddCarAsync(car, dealerId);

            TempData["SuccessMessage"] = "Car has been successfully added.";
            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var detailsCarViewModel = await _carService.GetDetailsCarViewModelAsync(id);

            if (detailsCarViewModel == null)
            {
                TempData["ErrorMessage"] = "Car with provided id does not exist! Please try again.";
                return RedirectToAction("All", "Car");
            }

            return View(detailsCarViewModel);
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

            if (car.Dealer.UserId != GetUserId())
            {
                TempData["ErrorMessage"] = "You are not authorized to edit this car!";
                return RedirectToAction("All", "Car");
            }

            var editCarViewModel = await _carService.GetEditCarViewModelAsync(id);

            if (editCarViewModel == null)
            {
                TempData["ErrorMessage"] = "Car with provided id does not exist! Please try again.";
                return RedirectToAction("All", "Car");
            }

            return View(editCarViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditCarViewModel car)
        {
            if (!ModelState.IsValid)
            {
                return View(car);
            }

            await _carService.EditCarAsync(id, car);

            TempData["SuccessMessage"] = "Car has been successfully edited.";
            return RedirectToAction("All", "Car");
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

            if (car.Dealer.UserId != GetUserId())
            {
                TempData["ErrorMessage"] = "You are not authorized to delete this car!";
                return RedirectToAction("All", "Car");
            }

            await _carService.DeleteCarAsync(id, GetUserId());

            TempData["SuccessMessage"] = "Car has been successfully deleted!";
            return RedirectToAction("All", "Car");
        }

        [HttpGet]
        public async Task<IActionResult> MyCars()
        {
            var cars = await _carService.GetMyCarsAsync(GetUserId());

            return View(cars);
        }

        [HttpGet]
        public async Task<IActionResult> MyFavoriteCars()
        {
            var cars = await _carService.GetMyFavoriteCarsAsync(GetUserId());

            return View(cars);
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

            bool isCarInMyFavoriteCars = await _carService.IsCarMine(id, GetUserId());
            if (isCarInMyFavoriteCars)
            {
                TempData["ErrorMessage"] = "You can't add a car in your favorite list if you are the owner of the car.";
                return RedirectToAction("All", "Car");
            }

            if (!await _carService.AddCarToMyFavoriteCarsAsync(id, GetUserId()))
            {
                TempData["ErrorMessage"] = "The car is already in your favorite cars.";
                return RedirectToAction("All", "Car");
            }

            TempData["SuccessMessage"] = "Car has been successfully added to favorite cars!";
            return RedirectToAction("MyFavoriteCars", "Car");
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

            if (!await _carService.RemoveCarFromMyFavoriteCarsAsync(id, GetUserId()))
            {
                TempData["ErrorMessage"] =
                    "Car with provided id does not exist in your favorite list! Please try again.";
                return RedirectToAction("MyFavoriteCars", "Car");
            }

            TempData["SuccessMessage"] = "Car successfully removed from favorite cars.";
            return RedirectToAction("All", "Car");
        }

        [HttpGet]
        public async Task<IActionResult> Search(string searchTerm, string category,
            string priceSort, string transmissionName, string fuelName, int? fromYear,
            int? toYear, int? fromHp, int? toHp, int? fromPrice, int? toPrice)
        {
            var cars = await _carService.SearchCarsAsync(searchTerm, category, priceSort,
                transmissionName, fuelName, fromYear, toYear, fromHp, toHp, fromPrice, toPrice);
            /*
            if i want to keep the search term in the search box:

            ViewBag.SearchTerm = searchTerm;
            ViewBag.FromPrice = fromPrice;
            ViewBag.ToPrice = toPrice;
            ViewBag.FromHp = fromHp;
            ViewBag.ToHp = toHp;
            ViewBag.FromYear = fromYear;
            ViewBag.ToYear = toYear;  */

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

            if (isUserDealer) //TODO: && !User.IsAdmin()
            {
                TempData["ErrorMessage"] = "Dealers can't rent cars! Please register as a user.";
                return RedirectToAction("Index", "Home");
            }

            var isRentedByMe = await _carService.IsRentedByMeAsync(id, GetUserId());

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
            
            var rentCarViewModel = await _carService.GetRentCarViewModelAsync(id);

            if (rentCarViewModel == null)
            {
                TempData["ErrorMessage"] = "Car with provided id does not exist! Please try again.";
                return RedirectToAction("All", "Car");
            }

            return View(rentCarViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Rent(RentCarViewModel rentCarViewModel)
        {
            if (!_carService.IsRentalPeriodValid(rentCarViewModel))
            {
                TempData["ErrorMessage"] = "Your rental period was invalid! Please try again with correct data.";
                return View(rentCarViewModel);
            }

            var userBalance = await _userService.GetUserBalanceById(GetUserId());
            var totalMoneyToRent = await _carService.TotalMoneyToRentAsync(rentCarViewModel);

            if (totalMoneyToRent > userBalance)
            {
                TempData["ErrorMessage"] = "You currently don't have enough money to rent this car!";
                return RedirectToAction("All", "Car");
            }

            await _carService.RentCarAsync(rentCarViewModel, GetUserId());
            await _userService.RemoveMoney(GetUserId(), totalMoneyToRent);

            TempData["SuccessMessage"] =
                $"You have successfully rented the car to date {rentCarViewModel.RentalEndDate!.Value.ToShortDateString()}.";
            return RedirectToAction("MyRentedCars", "Car");
        }

        [HttpGet]
        public async Task<IActionResult> MyRentedCars()
        {
            var cars = await _carService.GetMyRentedCarsAsync(GetUserId());

            var isUserDealer = await _dealerService.DealerExistsByUserIdAsync(GetUserId());

            if (isUserDealer) //TODO: && !User.IsAdmin()
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

            if (isUserDealer) //TODO: && !User.IsAdmin()
            {
                TempData["ErrorMessage"] = "Dealers can't rent cars. Please register as a user.";
                return RedirectToAction("Index", "Home");
            }

            var rentCarViewModel = await _carService.GetRentCarViewModelAsync(id);

            if (rentCarViewModel == null)
            {
                TempData["ErrorMessage"] = "Car with provided id does not exist! Please try again.";
                return RedirectToAction("All", "Car");
            }

            _curentEndDate = (DateTime)rentCarViewModel.RentalEndDate!;

            return View(rentCarViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ManageRental(RentCarViewModel rentCarViewModel)
        {
            bool hasUserMadeAnyChanges = _curentEndDate != rentCarViewModel.RentalEndDate;

            if (!hasUserMadeAnyChanges)
            {
                TempData["ErrorMessage"] = "You haven't made changes to the rental period! Please try again.";
                return RedirectToAction("MyRentedCars", "Car");
            }

            if (!_carService.IsRentalPeriodValid(rentCarViewModel))
            {
                TempData["ErrorMessage"] = "Please check and alter your rental period.";
                return View(rentCarViewModel);
            }

            var userBalance = await _userService.GetUserBalanceById(GetUserId());
            var totalMoneyToRentMore =
                await _carService.TotalMoneyToExtendRentAsync(rentCarViewModel, _curentEndDate);

            if (totalMoneyToRentMore > userBalance)
            {
                TempData["ErrorMessage"] = "You currently don't have enough money to rent this car!";
                return RedirectToAction("MyRentedCars", "Car");
            }

            await _carService.UpdateCarRentalAsync(rentCarViewModel);
            await _userService.RemoveMoney(GetUserId(), totalMoneyToRentMore);

            if (totalMoneyToRentMore > 0)
            {
                TempData["SuccessMessage"] =
                    $"You have successfully changed the car rental for the price of {totalMoneyToRentMore} euros. " +
                    $"Your new rental end date is {rentCarViewModel.RentalEndDate!.Value.ToShortDateString()}.";
            }
            else
            {
                TempData["SuccessMessage"] = $"You have successfully changed the car rental. " +
                                             $"You received back: {-totalMoneyToRentMore} euros! " +
                                             $"Your new rental end date is {rentCarViewModel.RentalEndDate!.Value.ToShortDateString()}.";
            }

            return RedirectToAction("MyRentedCars", "Car");
        }

        [HttpPost]
        public async Task<IActionResult> EndRental(int id)
        {
            //return user the money that he spent for the rental
            var moneyToReturn = await _carService.TotalMoneyToReturnForEndingRental(id);
            await _userService.AddCustomAmountMoney(GetUserId(), moneyToReturn);

            await _carService.EndCarRentalAsync(id);
            await _userService.RemoveMoney(GetUserId(), TaxPriceForCancelingRental);

            TempData["SuccessMessage"] = "You have successfully ended the car rental! " +
                                         $"You received back {moneyToReturn} euros " +
                                         $"and you have been taxed {TaxPriceForCancelingRental} euros.";
            return RedirectToAction("MyRentedCars", "Car");
        }
    }
}