using CarParts2023.Data;
using CarParts2023.Data.Models;
using CarParts2023.ViewModels.Car;
using CarParts2023.ViewModels.Description;
using Microsoft.EntityFrameworkCore;

namespace CarParts2023.Services
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
            /*var invalidCars = await _dbContext.Cars
                .Where(car => car.DescriptionId == 0 || car.Description == null)
                .ToListAsync();

            foreach (var car in invalidCars)
            {
                _dbContext.Cars.Remove(car);
            }

            await _dbContext.SaveChangesAsync();
            */


            List<CarViewModel> cars = await this._dbContext.Cars
                .Include(c => c.Description) // Include the Description entity
                .Select(car => new CarViewModel
                {
                    CarId = car.CarId,
                    Description = car.Description != null ? new DescriptionViewModel
                    {
                        Make = car.Description.Make,
                        Model = car.Description.Model,
                        Year = car.Description.Year,
                        Wheels = car.Description.Wheels,
                        Price = car.Description.Price,
                        Color = car.Description.Color,
                        EngineSize = car.Description.EngineSize,
                        FuelType = car.Description.FuelType,
                        Transmission = car.Description.Transmission,
                        Category = car.Description.Category,
                        Weight = car.Description.Weight,
                        TopSpeed = car.Description.TopSpeed,
                        Acceleration = car.Description.Acceleration,
                        Horsepower = car.Description.Horsepower,
                        Torque = car.Description.Torque,
                        FuelConsumption = car.Description.FuelConsumption,
                        Emission = car.Description.Emission,
                        SafetyFeatures = car.Description.SafetyFeatures
                    } : null // Handle cars without a description
                })
                .ToListAsync();

            return cars;
        }

        public async Task<AddCarViewModel> GetAddCarViewModelAsync()
        {
            var description = await this._dbContext.Descriptions
                .Select(d => new DescriptionViewModel
                {
                    Make = d.Make,
                    Model = d.Model,
                    Year = d.Year,
                    Wheels = d.Wheels,
                    Price = d.Price,
                    Color = d.Color,
                    EngineSize = d.EngineSize,
                    FuelType = d.FuelType,
                    Transmission = d.Transmission,
                    Category = d.Category,
                    Weight = d.Weight,
                    TopSpeed = d.TopSpeed,
                    Acceleration = d.Acceleration,
                    Horsepower = d.Horsepower,
                    Torque = d.Torque,
                    FuelConsumption = d.FuelConsumption,
                    Emission = d.Emission,
                    SafetyFeatures = d.SafetyFeatures,
                }).FirstAsync();

            var addCarViewModel = new AddCarViewModel
            {
                Description = description
            };

            return addCarViewModel;

        }

        public async Task AddCarAsync(AddCarViewModel car, string userId)
        {
            Description description = new Description
            {
                Make = car.Description.Make,
                Model = car.Description.Model,
                Year = car.Description.Year,
                Wheels = car.Description.Wheels,
                Price = car.Description.Price,
                Color = car.Description.Color,
                EngineSize = car.Description.EngineSize,
                FuelType = car.Description.FuelType,
                Transmission = car.Description.Transmission,
                Category = car.Description.Category,
                Weight = car.Description.Weight,
                TopSpeed = car.Description.TopSpeed,
                Acceleration = car.Description.Acceleration,
                Horsepower = car.Description.Horsepower,
                Torque = car.Description.Torque,
                FuelConsumption = car.Description.FuelConsumption,
                Emission = car.Description.Emission,
                SafetyFeatures = car.Description.SafetyFeatures
            };


            Car carToAdd = new Car
            {
                UserId = userId,
                Description = description,
                DescriptionId = description.DescriptionId
            };

            await this._dbContext.Cars.AddAsync(carToAdd);
            await this._dbContext.SaveChangesAsync();

        }
    }
}
