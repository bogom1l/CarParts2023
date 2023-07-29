﻿namespace CarParts.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Data.Interfaces;
    using ViewModels.Car;
    using static Common.GlobalConstants.Rental;

    public class CarController : BaseController
    {
        private static DateTime _curentEndDate = DateTime.Now.AddYears(-3); //TODO: ?
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
            var isDealer = await _dealerService.DealerExistsByUserIdAsync(GetUserId());
            if (!isDealer)
            {
                TempData["ErrorMessage"] = "You must become a dealer in order to add new cars!";

                return RedirectToAction("BecomeDealer", "Dealer");
            }

            if (!ModelState.IsValid)
            {
                return View(car);
            }

            var dealerId = await _dealerService.GetDealerIdByUserIdAsync(GetUserId());

            await _carService.AddCarAsync(car, dealerId);

            TempData["SuccessMessage"] = "Car successfully added!";
            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var detailsCarViewModel = await _carService.GetCarDetailsAsync(id);

            if (detailsCarViewModel == null)
            {
                RedirectToPage("All");
            }

            return View(detailsCarViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var car = await _carService.GetCarByIdAsync(id);

            if (car == null)
            {
                return RedirectToAction("All");
            }

            if (car.Dealer.UserId != GetUserId())
            {
                return RedirectToAction("All");
            }

            var editCarViewModel = await _carService.GetEditCarViewModelAsync(id, GetUserId());

            if (editCarViewModel == null)
            {
                return RedirectToAction("All");
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

            TempData["SuccessMessage"] = "Car successfully edited!";
            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var car = await _carService.GetCarByIdAsync(id);

            if (car == null)
            {
                return RedirectToAction("All");
            }

            if (car.Dealer.UserId != GetUserId())
            {
                return RedirectToAction("All");
            }

            await _carService.DeleteCarAsync(id, GetUserId());

            TempData["SuccessMessage"] = "Car successfully deleted!";
            return RedirectToAction("All");
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
                TempData["ErrorMessage"] = "The car does not exist.";
                return RedirectToAction("All");
            }

            if (!await _carService.AddCarToMyFavoriteCarsAsync(id, GetUserId()))
            {
                TempData["ErrorMessage"] = "The car is already in your favorite cars.";
                return RedirectToAction("All");
            }

            TempData["SuccessMessage"] = "Car added to favorite cars!";
            return RedirectToAction("MyFavoriteCars");
        }

        [HttpGet]
        public async Task<IActionResult> RemoveFromFavoriteCars(int id)
        {
            var car = await _carService.GetCarByIdAsync(id);

            if (car == null)
            {
                TempData["ErrorMessage"] = "The car does not exist.";
                return RedirectToAction("MyFavoriteCars");
            }

            if (!await _carService.RemoveCarFromMyFavoriteCarsAsync(id, GetUserId()))
            {
                TempData["ErrorMessage"] = "The car does not exist.";
                return RedirectToAction("MyFavoriteCars");
            }

            TempData["SuccessMessage"] = "Car removed from favorite cars!";
            return RedirectToAction("All");
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
                TempData["ErrorMessage"] = "Car with provided id does not exist! Please try again!";

                return RedirectToAction("All", "Car");
            }

            var isUserDealer = await _dealerService.DealerExistsByUserIdAsync(GetUserId());

            if (isUserDealer) //TODO: && !User.IsAdmin()
            {
                TempData["ErrorMessage"] = "Dealers can't rent cars. Please register as a user!";

                return RedirectToAction("Index", "Home");
            }

            var isRented = await _carService.IsRentedAsync(id);

            if (isRented)
            {
                TempData["ErrorMessage"] = "Car is already rented! Please try again!";

                return RedirectToAction("All", "Car");
            }

            var rentCarViewModel = await _carService.GetRentCarViewModelAsync(id); //+userid?

            if (rentCarViewModel == null)
            {
                return RedirectToAction("All");
            }

            return View(rentCarViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Rent(int id, RentCarViewModel rentCarViewModel)
        {
            var carExists = await _carService.ExistsByIdAsync(id);

            if (!carExists)
            {
                TempData["ErrorMessage"] = "Car with provided id does not exist! Please try again!";

                return RedirectToAction("All", "Car");
            }

            var isRented = await _carService.IsRentedAsync(id);

            if (isRented)
            {
                TempData["ErrorMessage"] = "Car is already rented! Please try again!";

                return RedirectToAction("All", "Car");
            }

            var isUserDealer = await _dealerService.DealerExistsByUserIdAsync(GetUserId());

            if (isUserDealer) //TODO: && !User.IsAdmin()
            {
                TempData["ErrorMessage"] = "Dealers can't rent cars. Please register as a user!";

                return RedirectToAction("Index", "Home");
            }

            if (!_carService.IsStartDateBeforeEndDate(rentCarViewModel))
            {
                TempData["ErrorMessage"] = "Rent start time can't be after rent end time!";

                return RedirectToAction("All", "Car");
            }

            var userBalance = await _userService.GetBalance(GetUserId());
            var totalMoneyToRent = await _carService.TotalMoneyToRentAsync(rentCarViewModel);

            if (totalMoneyToRent > userBalance)
            {
                TempData["ErrorMessage"] = "You don't have enough money to rent this car!";

                return RedirectToAction("All", "Car");
            }

            await _carService.RentCarAsync(rentCarViewModel, GetUserId());
            await _userService.RemoveMoney(GetUserId(), totalMoneyToRent);

            TempData["SuccessMessage"] = "You successfully rented the car!";
            return RedirectToAction("MyRentedCars", "Car");
        }

        [HttpGet]
        public async Task<IActionResult> MyRentedCars()
        {
            var cars = await _carService.GetMyRentedCarsAsync(GetUserId());

            return View(cars);
        }

        [HttpGet]
        public async Task<IActionResult> ManageRental(int id)
            //MUST be named id, because in the View its: asp-route-id="@car.Id", and not asp-route-carId="@car.Id"
        {
            var carExists = await _carService.ExistsByIdAsync(id);

            if (!carExists)
            {
                TempData["ErrorMessage"] = "Car with provided id does not exist! Please try again!";

                return RedirectToAction("All", "Car");
            }

            var isUserDealer = await _dealerService.DealerExistsByUserIdAsync(GetUserId());

            if (isUserDealer) //TODO: && !User.IsAdmin()
            {
                TempData["ErrorMessage"] = "Dealers can't rent cars. Please register as a user!";

                return RedirectToAction("Index", "Home");
            }

            var rentCarViewModel = await _carService.GetRentCarViewModelAsync(id);

            if (rentCarViewModel == null)
            {
                return RedirectToAction("All");
            }

            _curentEndDate = (DateTime)rentCarViewModel.RentalEndDate!;

            return View(rentCarViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ManageRental(int id, RentCarViewModel rentCarViewModel)
        {
            if (!_carService.IsStartDateBeforeEndDate(rentCarViewModel))
            {
                TempData["ErrorMessage"] = "Rent start time can't be after rent end time!";

                return RedirectToAction("MyRentedCars", "Car");
            }

            var userBalance = await _userService.GetBalance(GetUserId());
            var totalMoneyToRentMore =
                await _carService.TotalMoneyToRentMore(rentCarViewModel, _curentEndDate);

            if (totalMoneyToRentMore > userBalance)
            {
                TempData["ErrorMessage"] = "You don't have enough money to rent this car!";

                return RedirectToAction("MyRentedCars", "Car");
            }

            await _carService.UpdateRentalForCarAsync(rentCarViewModel, GetUserId());
            await _userService.RemoveMoney(GetUserId(), totalMoneyToRentMore);

            if (totalMoneyToRentMore > 0)
            {
                TempData["SuccessMessage"] =
                    $"You successfully changed your rental for the car for price {totalMoneyToRentMore} euro!";
            }
            else
            {
                TempData["SuccessMessage"] = $"You successfully changed your rental. " +
                                             $"You received back your money: {-totalMoneyToRentMore} euro!";
            }

            return RedirectToAction("MyRentedCars", "Car");
        }

        [HttpPost]
        public async Task<IActionResult> EndRental(int id)
        {
            var userBalance = await _userService.GetBalance(GetUserId());

            if (userBalance >= TaxPriceForCancelingRental)
            {
                await _carService.EndRentalAsync(id, GetUserId());
                await _userService.RemoveMoney(GetUserId(), TaxPriceForCancelingRental);

                TempData["SuccessMessage"] = "You successfully ended your rental for the car!";
                return RedirectToAction("MyRentedCars", "Car");
            }

            await _carService.EndRentalAsync(id, GetUserId());

            TempData["SuccessMessage"] = "You don't have enough money to end the rental purchase," +
                                         "\n so we will end it for you free this time. Consider making more money.";
            return RedirectToAction("MyRentedCars", "Car");
        }
    }
}