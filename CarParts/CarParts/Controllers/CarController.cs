namespace CarParts.Web.Controllers
{
    using CarParts.Services.Data.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Car;
    using static Common.GlobalConstants.Rental;

    public class CarController : BaseController
    {
        private readonly ICarService _carService;
        private readonly IDealerService _dealerService;
        private readonly IUserService _userService;

        public CarController(ICarService carService, IDealerService dealerService, IUserService userService)
        {
            this._carService = carService;
            this._dealerService = dealerService;
            this._userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var cars = await this._carService.GetAllCarsAsync();

            return View(cars);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var isDealer = await this._dealerService.DealerExistsByUserIdAsync(GetUserId());

            if (!isDealer)
            {
                TempData["ErrorMessage"] = "You must become a dealer in order to add new cars!";
                return RedirectToAction("BecomeDealer", "Dealer");
            }

            var car = await this._carService.GetAddCarViewModelAsync();

            return View(car);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCarViewModel car)
        {
            var isDealer = await this._dealerService.DealerExistsByUserIdAsync(GetUserId());
            if (!isDealer)
            {
                TempData["ErrorMessage"] = "You must become a dealer in order to add new cars!";

                return RedirectToAction("BecomeDealer", "Dealer");
            }

            if (!ModelState.IsValid)
            {
                return View(car);
            }

            var dealerId = await this._dealerService.GetDealerIdByUserIdAsync(GetUserId());

            await this._carService.AddCarAsync(car, dealerId);

            TempData["SuccessMessage"] = "Car successfully added!";
            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var detailsCarViewModel = await this._carService.GetCarDetailsAsync(id);

            if (detailsCarViewModel == null)
            {
                RedirectToPage("All");
            }

            return View(detailsCarViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var car = await this._carService.GetCarByIdAsync(id);

            if (car == null)
            {
                return RedirectToAction("All");
            }

            if (car.Dealer.UserId != GetUserId())
            {
                return RedirectToAction("All");
            }

            var editCarViewModel = await this._carService.GetEditCarViewModelAsync(id, GetUserId());

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

            await this._carService.EditCarAsync(id, car);

            TempData["SuccessMessage"] = "Car successfully edited!";
            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var car = await this._carService.GetCarByIdAsync(id);

            if (car == null)
            {
                return RedirectToAction("All");
            }

            if (car.Dealer.UserId != GetUserId())
            {
                return RedirectToAction("All");
            }

            await this._carService.DeleteCarAsync(id, GetUserId());

            TempData["SuccessMessage"] = "Car successfully deleted!";
            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> MyCars()
        {
            var cars = await this._carService.GetMyCarsAsync(GetUserId());

            return View(cars);
        }

        [HttpGet]
        public async Task<IActionResult> MyFavoriteCars()
        {
            var cars = await this._carService.GetMyFavoriteCarsAsync(GetUserId());

            return View(cars);
        }


        [HttpGet]
        public async Task<IActionResult> AddToFavoriteCars(int id)
        {
            var car = await this._carService.GetCarByIdAsync(id);

            if (car == null)
            {
                TempData["ErrorMessage"] = "The car does not exist.";
                return RedirectToAction("All");
            }

            if (!await this._carService.AddCarToMyFavoriteCarsAsync(id, GetUserId()))
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
            var car = await this._carService.GetCarByIdAsync(id);

            if (car == null)
            {
                TempData["ErrorMessage"] = "The car does not exist.";
                return RedirectToAction("MyFavoriteCars");
            }

            if (!await this._carService.RemoveCarFromMyFavoriteCarsAsync(id, GetUserId()))
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
            var carExists = await this._carService.ExistsByIdAsync(id);

            if (!carExists)
            {
                TempData["ErrorMessage"] = "Car with provided id does not exist! Please try again!";

                return RedirectToAction("All", "Car");
            }

            var isUserDealer = await this._dealerService.DealerExistsByUserIdAsync(GetUserId());

            if (isUserDealer) //TODO: && !User.IsAdmin()
            {
                TempData["ErrorMessage"] = "Dealers can't rent cars. Please register as a user!";

                return RedirectToAction("Index", "Home");
            }

            var isRented = await this._carService.IsRentedAsync(id);

            if (isRented)
            {
                TempData["ErrorMessage"] = "Car is already rented! Please try again!";

                return RedirectToAction("All", "Car");
            }

            var rentCarViewModel = await this._carService.GetRentCarViewModelAsync(id); //+userid?

            if (rentCarViewModel == null)
            {
                return RedirectToAction("All");
            }

            return View(rentCarViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Rent(int id, RentCarViewModel rentCarViewModel)
        {
            var carExists = await this._carService.ExistsByIdAsync(id);

            if (!carExists)
            {
                TempData["ErrorMessage"] = "Car with provided id does not exist! Please try again!";

                return RedirectToAction("All", "Car");
            }

            var isRented = await this._carService.IsRentedAsync(id);

            if (isRented)
            {
                TempData["ErrorMessage"] = "Car is already rented! Please try again!";

                return RedirectToAction("All", "Car");
            }

            var isUserDealer = await this._dealerService.DealerExistsByUserIdAsync(GetUserId());

            if (isUserDealer) //TODO: && !User.IsAdmin()
            {
                TempData["ErrorMessage"] = "Dealers can't rent cars. Please register as a user!";

                return RedirectToAction("Index", "Home");
            }

            if (!this._carService.IsStartDateBeforeEndDate(rentCarViewModel))
            {
                TempData["ErrorMessage"] = "Rent start time can't be after rent end time!";

                return RedirectToAction("All", "Car");
            }

            var userBalance = await this._userService.GetBalance(GetUserId());
            var totalMoneyToRent = await this._carService.TotalMoneyToRentAsync(rentCarViewModel);

            if (totalMoneyToRent > userBalance)
            {
                TempData["ErrorMessage"] = "You don't have enough money to rent this car!";

                return RedirectToAction("All", "Car");
            }

            await this._carService.RentCarAsync(rentCarViewModel, GetUserId());
            await this._userService.RemoveMoney(GetUserId(), totalMoneyToRent);

            TempData["SuccessMessage"] = "You successfully rented the car!";
            return RedirectToAction("MyRentedCars", "Car");
        }

        [HttpGet]
        public async Task<IActionResult> MyRentedCars()
        {
            var cars = await this._carService.GetMyRentedCarsAsync(GetUserId());

            return View(cars);
        }

        private static DateTime _curentEndDate = DateTime.Now.AddYears(-3); //TODO: ?

        [HttpGet]
        public async Task<IActionResult> ManageRental(int id)
            //MUST be named id, because in the View its: asp-route-id="@car.Id", and not asp-route-carId="@car.Id"
        {
            var carExists = await this._carService.ExistsByIdAsync(id);

            if (!carExists)
            {
                TempData["ErrorMessage"] = "Car with provided id does not exist! Please try again!";

                return RedirectToAction("All", "Car");
            }

            var isUserDealer = await this._dealerService.DealerExistsByUserIdAsync(GetUserId());

            if (isUserDealer) //TODO: && !User.IsAdmin()
            {
                TempData["ErrorMessage"] = "Dealers can't rent cars. Please register as a user!";

                return RedirectToAction("Index", "Home");
            }

            var rentCarViewModel = await this._carService.GetRentCarViewModelAsync(id);

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
            if (!this._carService.IsStartDateBeforeEndDate(rentCarViewModel))
            {
                TempData["ErrorMessage"] = "Rent start time can't be after rent end time!";

                return RedirectToAction("MyRentedCars", "Car");
            }

            var userBalance = await this._userService.GetBalance(GetUserId());
            var totalMoneyToRentMore =
                await this._carService.TotalMoneyToRentMore(rentCarViewModel, _curentEndDate);

            if (totalMoneyToRentMore > userBalance)
            {
                TempData["ErrorMessage"] = "You don't have enough money to rent this car!";

                return RedirectToAction("MyRentedCars", "Car");
            }

            await this._carService.UpdateRentalForCarAsync(rentCarViewModel, GetUserId());
            await this._userService.RemoveMoney(GetUserId(), totalMoneyToRentMore);

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
            var userBalance = await this._userService.GetBalance(GetUserId());

            if (userBalance >= TaxPriceForEndingRental)
            {
                await this._carService.EndRentalAsync(id, GetUserId());
                await this._userService.RemoveMoney(GetUserId(), TaxPriceForEndingRental);

                TempData["SuccessMessage"] = "You successfully ended your rental for the car!";
                return RedirectToAction("MyRentedCars", "Car");
            }

            await this._carService.EndRentalAsync(id, GetUserId());

            TempData["SuccessMessage"] = "You don't have enough money to end the rental purchase," +
                                         "\n so we will end it for you free this time. Consider making more money.";
            return RedirectToAction("MyRentedCars", "Car");
        }
    }
}