using CarParts.Data;
using CarParts.Data.Models;
using CarParts.ViewModels.Car;
using CarParts.ViewModels.Car.CarProperties;
using CarParts.ViewModels.Part;
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
            var cars = await this._dbContext.Cars
                .Select(c => new CarViewModel
                {
                    CarId = c.CarId,
                    Make = c.Make,
                    Model = c.Model,
                    Year = c.Year,
                    Description = c.Description,
                    Price = c.Price,
                    Color = c.Color,
                    EngineSize = c.EngineSize,
                    FuelTypeName = c.FuelType.Name,
                    TransmissionName = c.Transmission.Name,
                    CategoryName = c.Category.Name,
                    Weight = c.Weight,
                    TopSpeed = c.TopSpeed,
                    Acceleration = c.Acceleration,
                    Horsepower = c.Horsepower,
                    Torque = c.Torque,
                    FuelConsumption = c.FuelConsumption,
                    Owner = c.User.UserName,
                    ImageUrl = c.ImageUrl
                }).ToListAsync();

            int a = 2;
            int b = 3;

            return cars;
        }

        public async Task<AddCarViewModel> GetAddCarViewModelAsync()
        {
            var fuelTypes = await this._dbContext.FuelTypes.Select(f => new CarFuelTypeViewModel
            {
                Id = f.Id,
                Name = f.Name
            }).ToListAsync();

            var transmissions = await this._dbContext.Transmissions.Select(t => new CarTransmissionViewModel
            {
                Id = t.Id,
                Name = t.Name
            }).ToListAsync();

            var categories = await this._dbContext.Categories.Select(c => new CarCategoryViewModel
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
                FuelConsumption = car.FuelConsumption,
                ImageUrl = car.ImageUrl
            };

            await this._dbContext.Cars.AddAsync(carData);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task<DetailsCarViewModel?> GetCarDetailsAsync(int id)
        {
            DetailsCarViewModel? detailsCarViewModel = await this._dbContext
                .Cars
                .Where(c => c.CarId == id)
                .Select(c => new DetailsCarViewModel
                {
                    CarId = c.CarId,
                    Make = c.Make,
                    Model = c.Model,
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
                    FuelConsumption = c.FuelConsumption,
                    ImageUrl = c.ImageUrl

                }).FirstOrDefaultAsync();

            return detailsCarViewModel;
        }

        public async Task<EditCarViewModel?> GetEditCarViewModelAsync(int id, string userId)
        {
            var fuelTypes = await this._dbContext.FuelTypes.Select(f => new CarFuelTypeViewModel
            {
                Id = f.Id,
                Name = f.Name
            }).ToListAsync();

            var transmissions = await this._dbContext.Transmissions.Select(t => new CarTransmissionViewModel
            {
                Id = t.Id,
                Name = t.Name
            }).ToListAsync();

            var categories = await this._dbContext.Categories.Select(c => new CarCategoryViewModel
            {
                Id = c.Id,
                Name = c.Name
            }).ToListAsync();

            var editCarViewModel = await this._dbContext.Cars
                .Where(c => c.CarId == id)
                .Select(c => new EditCarViewModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    Year = c.Year,
                    Description = c.Description,
                    Price = c.Price,
                    Color = c.Color,
                    EngineSize = c.EngineSize,
                    FuelTypeId = c.FuelTypeId,
                    FuelTypes = fuelTypes,
                    TransmissionId = c.TransmissionId,
                    Transmissions = transmissions,
                    CategoryId = c.CategoryId,
                    Categories = categories,
                    Weight = c.Weight,
                    TopSpeed = c.TopSpeed,
                    Acceleration = c.Acceleration,
                    Horsepower = c.Horsepower,
                    Torque = c.Torque,
                    FuelConsumption = c.FuelConsumption,
                    ImageUrl = c.ImageUrl
                })
                .FirstOrDefaultAsync();

            return editCarViewModel;
        }

        public async Task EditCarAsync(int id, EditCarViewModel car)
        {
            var carData = await this._dbContext.Cars
                .FirstOrDefaultAsync(c => c.CarId == id);

            if (carData != null)
            {
                carData.Make = car.Make;
                carData.Model = car.Model;
                carData.Year = car.Year;
                carData.Description = car.Description;
                carData.Price = car.Price;
                carData.Color = car.Color;
                carData.EngineSize = car.EngineSize;
                carData.FuelTypeId = car.FuelTypeId;
                carData.TransmissionId = car.TransmissionId;
                carData.CategoryId = car.CategoryId;
                carData.Weight = car.Weight;
                carData.TopSpeed = car.TopSpeed;
                carData.Acceleration = car.Acceleration;
                carData.Horsepower = car.Horsepower;
                carData.Torque = car.Torque;
                carData.FuelConsumption = car.FuelConsumption;
                carData.ImageUrl = car.ImageUrl;

                await this._dbContext.SaveChangesAsync();
            }

        }


        public async Task DeleteCarAsync(int id, string userId)
        {
            var carData = await this._dbContext
                .Cars
                .FirstOrDefaultAsync(cu => cu.CarId == id && cu.UserId == userId);

            if (carData != null)
            {
                this._dbContext.Cars.Remove(carData);
                await this._dbContext.SaveChangesAsync();
            }
        }

        public async Task<Car?> GetCarByIdAsync(int id)
        {
            Car? carData = await this._dbContext.Cars
                .FirstOrDefaultAsync(c => c.CarId == id);

            return carData;
        }

        public async Task<ICollection<CarViewModel>> GetMyCarsAsync(string userId)
        {
            return await this._dbContext
                .Cars
                .Where(c => c.UserId == userId)
                .Select(c => new CarViewModel()
                {
                    CarId = c.CarId,
                    Make = c.Make,
                    Model = c.Model,
                    Year = c.Year,
                    Description = c.Description,
                    Price = c.Price,
                    Color = c.Color,
                    EngineSize = c.EngineSize,
                    FuelTypeName = c.FuelType.Name,
                    TransmissionName = c.Transmission.Name,
                    CategoryName = c.Category.Name,
                    Weight = c.Weight,
                    TopSpeed = c.TopSpeed,
                    Acceleration = c.Acceleration,
                    Horsepower = c.Horsepower,
                    Torque = c.Torque,
                    FuelConsumption = c.FuelConsumption,
                    Owner = c.User.UserName,
                    ImageUrl = c.ImageUrl
                }).ToListAsync();
        }

        public async Task<ICollection<CarViewModel>> GetMyFavoriteCarsAsync(string userId)
        {
            return await this._dbContext
                .Cars
                .Where(c => c.UserFavoriteCars.Any(ufc => ufc.UserId == userId))
                .Select(c => new CarViewModel
                {
                    CarId = c.CarId,
                    Make = c.Make,
                    Model = c.Model,
                    Year = c.Year,
                    Description = c.Description,
                    Price = c.Price,
                    Color = c.Color,
                    EngineSize = c.EngineSize,
                    FuelTypeName = c.FuelType.Name,
                    TransmissionName = c.Transmission.Name,
                    CategoryName = c.Category.Name,
                    Weight = c.Weight,
                    TopSpeed = c.TopSpeed,
                    Acceleration = c.Acceleration,
                    Horsepower = c.Horsepower,
                    Torque = c.Torque,
                    FuelConsumption = c.FuelConsumption,
                    Owner = c.User.UserName,
                    ImageUrl = c.ImageUrl
                }).ToListAsync();
        }

        public async Task<bool> AddCarToMyFavoriteCarsAsync(int carId, string userId)
        {
            bool isCarAlreadyInMyFavoriteCars = await this._dbContext
                .UsersFavoriteCars
                .AnyAsync(ufc => ufc.CarId == carId && ufc.UserId == userId);

            if (isCarAlreadyInMyFavoriteCars)
            {
                return false;
            }

            UserFavoriteCar userFavoriteCar = new UserFavoriteCar
            {
                CarId = carId,
                UserId = userId
            };

            await this._dbContext.UsersFavoriteCars.AddAsync(userFavoriteCar);
            await this._dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RemoveCarFromMyFavoriteCarsAsync(int carId, string userId)
        {
            UserFavoriteCar? car = await this._dbContext
                .UsersFavoriteCars
                .FirstOrDefaultAsync(ufc => ufc.CarId == carId && ufc.UserId == userId);

            if (car == null)
            {
                return false; //doesnt exist (for some reason...)
            }

            this._dbContext.UsersFavoriteCars.Remove(car);
            await this._dbContext.SaveChangesAsync();

            return true;
        }


    }
}