using CarParts.Data.Models;
using CarParts.Services;
using CarParts.ViewModels.Car;

namespace CarParts.Controllers
{
    using Microsoft.AspNetCore.Mvc;

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
            Car? car = await this._carService.GetCarById(id);

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

            await this._carService.EditCarAsync(id, car);

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Car? car = await this._carService.GetCarById(id);

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


    }
}
