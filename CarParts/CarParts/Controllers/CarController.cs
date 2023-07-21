using CarParts.Data.Models;
using CarParts.Services.Data.Interfaces;
using CarParts.Web.ViewModels.Car;
using Microsoft.AspNetCore.Mvc;

namespace CarParts.Web.Controllers
{
    public class CarController : BaseController
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            this._carService = carService;
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
            AddCarViewModel car = await this._carService.GetAddCarViewModelAsync();

            return View(car);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCarViewModel car)
        {

            if (!ModelState.IsValid)
            {
                return View(car);
            }

            await this._carService.AddCarAsync(car, GetUserId());

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

            if (car.UserId != GetUserId())
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
            
            if (car.UserId != GetUserId())
            {
                return RedirectToAction("All");
            }

            await this._carService.DeleteCarAsync(id, GetUserId());

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
                return RedirectToAction("All");
            }

            if (!await this._carService.AddCarToMyFavoriteCarsAsync(id, GetUserId()))
            {
                return RedirectToAction("All");
            }

            return RedirectToAction("MyFavoriteCars");
        }

        [HttpGet]
        public async Task<IActionResult> RemoveFromFavoriteCars(int id)
        {
            var car = await this._carService.GetCarByIdAsync(id); 

            if (car == null)
            {
                return RedirectToAction("MyFavoriteCars");
            }

            if (!await this._carService.RemoveCarFromMyFavoriteCarsAsync(id, GetUserId()))
            {
                return RedirectToAction("MyFavoriteCars");
            }

            return RedirectToAction("All");
        }


    }
}
