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

    }
}
