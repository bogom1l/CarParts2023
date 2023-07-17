using CarParts.Data;
using CarParts.Data.Models;
using CarParts.ViewModels.Car;
using CarParts.ViewModels.Car.CarProperties;
using Microsoft.EntityFrameworkCore;

namespace CarParts.Services
{
    public class CarService : ICarService
    {

        private readonly ApplicationDbContext _dbContext;

        public CarService(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        public async Task<ICollection<CarViewModel>> GetAllCarsAsync()
        {
            return await this._dbContext.Cars.Select(c => new CarViewModel
            {
                CarId = c.CarId,
                Make = c.Make,
                Model = c.Make,
                Year = c.Year,
                Description = c.Description,
                Price = c.Price,
                Color = c.Color,
                EngineSize = c.EngineSize,
                FuelType = c.FuelType.Name,
                Transmission = c.Transmission.Name,
                Category = c.Category.Name,
                Weight = c.Weight,
                TopSpeed = c.TopSpeed,
                Acceleration = c.Acceleration,
                Horsepower = c.Horsepower,
                Torque = c.Torque,
                FuelConsumption = c.FuelConsumption
            }).ToListAsync();
        }

        public async Task<AddCarViewModel> GetAddCarViewModelAsync()
        {
            var fuelTypes = await this._dbContext.FuelTypes.Select(f => new FuelTypeViewModel
            {
                Id = f.Id,
                Name = f.Name
            }).ToListAsync();

            var transmissions = await this._dbContext.Transmissions.Select(t => new TransmissionViewModel
            {
                Id = t.Id,
                Name = t.Name
            }).ToListAsync();

            var categories = await this._dbContext.Categories.Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name
            }).ToListAsync();

            var addCarViewModel = new AddCarViewModel()
            {
                FuelTypes = fuelTypes,
                Transmissions = transmissions,
                Categories = categories
            };

            return addCarViewModel; 
        }

        public async Task AddCarAsync(AddCarViewModel car, string userId)
        {
            var carData = new Car
            {
                Make = car.Make,
                Model = car.Model,
                Year = car.Year,
                UserId = userId,
                Description = car.Description,
                Price = car.Price,
                Color = car.Color,
                EngineSize = car.EngineSize,
                FuelTypeId = car.FuelTypeId,
                TransmissionId = car.TransmissionId,
                CategoryId = car.CategoryId,
                Weight = car.Weight,
                TopSpeed = car.TopSpeed,
                Acceleration = car.Acceleration,
                Horsepower = car.Horsepower,
                Torque = car.Torque,
                FuelConsumption = car.FuelConsumption
            };

            await this._dbContext.Cars.AddAsync(carData);
            await this._dbContext.SaveChangesAsync();
        }
    }
}
