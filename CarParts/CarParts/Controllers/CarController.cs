﻿using CarParts.Data.Models;
using CarParts.Services.Data.Interfaces;
using CarParts.Web.ViewModels.Car;
using CarParts.Web.ViewModels.Part;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarParts.Web.Controllers
{
    public class CarController : BaseController
    {
        private readonly ICarService _carService;
        private readonly IDealerService _dealerService;

        public CarController(ICarService carService, IDealerService dealerService)
        {
            this._carService = carService;
            _dealerService = dealerService;

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
            bool isDealer = await this._dealerService.DealerExistsByUserIdAsync(GetUserId());
            if (!isDealer)
            {
                TempData["ErrorMessage"] = "You must become a dealer in order to add new cars!";

                return RedirectToAction("BecomeDealer", "Dealer");
            }

            AddCarViewModel car = await this._carService.GetAddCarViewModelAsync();

            return View(car);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCarViewModel car)
        {
            bool isDealer = await this._dealerService.DealerExistsByUserIdAsync(GetUserId());
            if (!isDealer)
            {
                TempData["ErrorMessage"] = "You must become a dealer in order to add new cars!";

                return RedirectToAction("BecomeDealer", "Dealer");
            }


            if (!ModelState.IsValid)
            {
                return View(car);
            }

            int dealerId = await this._dealerService.GetDealerIdByUserIdAsync(GetUserId());

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
            Car? car = await this._carService.GetCarByIdAsync(id);

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

            await this._carService.EditCarAsync(id, car); //x

            TempData["SuccessMessage"] = "Car successfully edited!";
            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Car? car = await this._carService.GetCarByIdAsync(id);

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

            if (!await this._carService.AddCarToMyFavoriteCarsAsync(id, GetUserId())) //false = car already in favorite cars
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
        public async Task<IActionResult> Search(string searchTerm, string category, string priceSort, string transmissionName,
            string fuelName, int? fromYear, int? toYear, int? fromHp, int? toHp, int? fromPrice, int? toPrice)
        {
            var cars = await _carService.SearchCarsAsync(searchTerm, category, priceSort,
                 transmissionName, fuelName, fromYear, toYear, fromHp, toHp, fromPrice, toPrice);

            /*  if i want to keep the search term in the search box
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
            bool carExists = await this._carService.ExistsByIdAsync(id);

            if (!carExists)
            {
                TempData["ErrorMessage"] = "Car with provided id does not exist! Please try again!";

                return RedirectToAction("All", "Car");
            }

            bool isUserDealer = await this._dealerService.DealerExistsByUserIdAsync(GetUserId());

            if (isUserDealer) //TODO: && !User.IsAdmin()
            {
                TempData["ErrorMessage"] = "Dealers can't rent houses. Please register as a user!";

                return RedirectToAction("Index", "Home");
            }
            
            bool isRented = await this._carService.IsRentedAsync(id);
            
            if (isRented)
            {
                TempData["ErrorMessage"] = "Car is already rented! Please try again!";

                return RedirectToAction("All", "Car");
            }

           
            var rentCarViewModel = await this._carService.GetRentCarViewModelAsync(id, GetUserId());

            if (rentCarViewModel == null)
            {
                return RedirectToAction("All");
            }

            return View(rentCarViewModel); 
        }

        [HttpPost]
        public async Task<IActionResult> Rent(int id, RentCarViewModel rentCarViewModel)
        {
            bool carExists = await this._carService.ExistsByIdAsync(id);

            if (!carExists)
            {
                TempData["ErrorMessage"] = "Car with provided id does not exist! Please try again!";

                return RedirectToAction("All", "Car");
            }
            
            bool isRented = await this._carService.IsRentedAsync(id);
            
            if (isRented)
            {
                TempData["ErrorMessage"] = "Car is already rented! Please try again!";

                return RedirectToAction("All", "Car");
            }

            bool isUserDealer = await this._dealerService.DealerExistsByUserIdAsync(GetUserId());

            if (isUserDealer) //TODO: && !User.IsAdmin()
            {
                TempData["ErrorMessage"] = "Dealers can't rent houses. Please register as a user!";

                return RedirectToAction("Index", "Home");
            }

            await this._carService.RentCarAsync(rentCarViewModel, GetUserId());

            return RedirectToAction("MyRentedCars", "Car");
        }


        
        [HttpGet]
        public async Task<IActionResult> MyRentedCars()
        {
            var cars = await this._carService.GetMyRentedCarsAsync(GetUserId());

            return View(cars);
        }

    }
}
