using CarParts2023.Services;
using CarParts2023.ViewModels.Car;

namespace CarParts2023.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class CarController : BaseController
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            this._carService = carService;
        }

        public async Task<IActionResult> All()
        {
            var cars = await this._carService.GetAllCarsAsync();

            return View(cars);
        }
    }
}
