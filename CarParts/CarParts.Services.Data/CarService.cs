using System.Xml;
using CarParts.Data;
using CarParts.Services.Data.Interfaces;
using CarParts.Web.ViewModels.Car;
using CarParts.Web.ViewModels.Car.CarProperties;
using Microsoft.EntityFrameworkCore;

namespace CarParts.Services.Data
{
    using CarParts.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;

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
                    Owner = c.Dealer.User.FirstName,
                    ImageUrl = c.ImageUrl,
                    Email = c.Dealer.User.Email
                }).ToListAsync();

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

        public async Task AddCarAsync(AddCarViewModel car, int dealerId)
        {
            var carData = new Car
            {
                Make = car.Make,
                Model = car.Model,
                Year = car.Year,
                DealerId = dealerId,
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
                ImageUrl = car.ImageUrl,
                RentPrice = car.RentPrice,
                RenterId = null
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
                    ImageUrl = c.ImageUrl,
                    RentPrice = c.RentPrice
                }).FirstOrDefaultAsync();

            return detailsCarViewModel;
        }

        public async Task<EditCarViewModel?> GetEditCarViewModelAsync(int id, string userId) //TODO: userId neccessary?
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
                    ImageUrl = c.ImageUrl,
                    RentPrice = c.RentPrice
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
                carData.RentPrice = car.RentPrice;

                await this._dbContext.SaveChangesAsync();
            }

        }


        public async Task DeleteCarAsync(int id, string userId)
        {
            var carData = await this._dbContext
                .Cars
                .FirstOrDefaultAsync(cu => cu.CarId == id && cu.Dealer.UserId == userId);//.ToString()

            if (carData != null)
            {
                this._dbContext.Cars.Remove(carData);
                await this._dbContext.SaveChangesAsync();
            }
        }

        public async Task<Car?> GetCarByIdAsync(int id)
        {
            Car? carData = await this._dbContext.Cars
                .Include(c => c.Dealer)
                .FirstOrDefaultAsync(c => c.CarId == id);

            return carData;
        }

        public async Task<ICollection<CarViewModel>> GetMyCarsAsync(string userId)
        {
            return await this._dbContext
                .Cars
                .Where(c => c.Dealer.UserId == userId) //.ToString()
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
                    Owner = c.Dealer.User.FirstName,
                    ImageUrl = c.ImageUrl,
                    Email = c.Dealer.User.Email
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
                    Owner = c.Dealer.User.FirstName,
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

        public async Task<ICollection<CarViewModel>> SearchCarsAsync(string searchTerm, string category, string priceSort
            , string transmissionName, string fuelName,
            int? fromYear, int? toYear, int? fromHp, int? toHp,
            int? fromPrice, int? toPrice)
        {
            var carsQuery = _dbContext.Cars.AsQueryable();

            // Filter by category
            if (!string.IsNullOrEmpty(category))
            {
                carsQuery = carsQuery.Where(c => c.Category.Name == category);
            }

            // Filter by transmission
            if (!string.IsNullOrEmpty(transmissionName))
            {
                carsQuery = carsQuery.Where(c => c.Transmission.Name == transmissionName);
            }

            // Filter by fuel
            if (!string.IsNullOrEmpty(fuelName))
            {
                carsQuery = carsQuery.Where(c => c.FuelType.Name == fuelName);
            }

            // Search by custom text in car's name/description
            if (!string.IsNullOrEmpty(searchTerm))
            {
                carsQuery = carsQuery.Where(c =>
                    c.Make.Contains(searchTerm) ||
                    c.Model.Contains(searchTerm) ||
                    c.Description.Contains(searchTerm)
                );
            }

            // Filter by price range
            if (fromPrice != null)
            {
                carsQuery = carsQuery.Where(c => c.Price >= fromPrice);
            }

            if (toPrice != null)
            {
                carsQuery = carsQuery.Where(c => c.Price <= toPrice);
            }

            // Filter by year range
            if (fromYear != null)
            {
                carsQuery = carsQuery.Where(c => c.Year >= fromYear);
            }

            if (toYear != null)
            {
                carsQuery = carsQuery.Where(c => c.Year <= toYear);
            }

            // Filter by horsepower range
            if (fromHp != null)
            {
                carsQuery = carsQuery.Where(c => c.Horsepower >= fromHp);
            }

            if (toHp != null)
            {
                carsQuery = carsQuery.Where(c => c.Horsepower <= toHp);
            }


            // Sort by price ascending/descending
            if (priceSort == "asc")
            {
                carsQuery = carsQuery.OrderBy(c => c.Price);
            }
            else if (priceSort == "desc")
            {
                carsQuery = carsQuery.OrderByDescending(c => c.Price);
            }

            // Project the query results into CarViewModel
            var cars = await carsQuery
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
                    Owner = c.Dealer.User.FirstName,
                    ImageUrl = c.ImageUrl
                })
                .ToListAsync();

            return cars;
        }

        public async void GetDataFromDatabase()
        {
            //get all the data from the database
            var cars = await this._dbContext.Cars.ToListAsync();
            var parts = await this._dbContext.Parts.ToListAsync();

            string jsonCars = JsonSerializer.Serialize(cars);
            string jsonParts = JsonSerializer.Serialize(parts);

            await File.WriteAllTextAsync("cars_24_07_2023.json", jsonCars);
            await File.WriteAllTextAsync("parts_24_07_2023.json", jsonParts);

            /*
               string jsonCars = File.ReadAllText("cars_24_07_2023.json.json");
               var carPartsCars = JsonSerializer.Deserialize<List<CarPart>>(jsonCars);
               dbContext.CarParts.AddRange(carPartsCars);
               dbContext.SaveChanges();

               -||- for parts
             */
        }


        public async Task<bool> IsCarAlreadyInMyFavoriteCars(int carId, string userId)
        {
            return await this._dbContext
                .UsersFavoriteCars
                .AnyAsync(ufc => ufc.CarId == carId && ufc.UserId == userId);
        }


        public async Task<bool> ExistsByIdAsync(int carId)
        {
            bool result = await this._dbContext
                .Cars
                .AnyAsync(c => c.CarId == carId);

            return result;
        }

        public async Task<bool> IsRentedAsync(int carId)
        {
            var car = await this._dbContext
                .Cars
                .FirstAsync(c => c.CarId == carId);

            return !string.IsNullOrEmpty(car.RenterId); 
        }

        public async Task RentCarAsync(RentCarViewModel rentCarViewModel, string userId)
        {
            Car car = await this._dbContext
                .Cars
                .FirstAsync(c => c.CarId == rentCarViewModel.Id);

            car.RenterId = userId;
            car.RentalStartDate = rentCarViewModel.RentalStartDate;
            car.RentalEndDate = rentCarViewModel.RentalEndDate;
            car.RentPrice = rentCarViewModel.RentPrice;

            await this._dbContext.SaveChangesAsync();
        }

        public async Task<RentCarViewModel?> GetRentCarViewModelAsync(int id)
        {
            var rentCarViewModel = await this._dbContext.Cars
                .Where(c => c.CarId == id)
                .Select(c => new RentCarViewModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    Year = c.Year,
                    Description = c.Description,
                    Price = c.Price,
                    Color = c.Color,
                    ImageUrl = c.ImageUrl,
                    RentalStartDate = c.RentalStartDate != null ? c.RentalStartDate.Value : DateTime.Now,
                    RentalEndDate = c.RentalEndDate ?? DateTime.Now.AddDays(1),
                    RenterName = c.Renter.FirstName + " " + c.Renter.LastName ?? null,
                    RentPrice = c.RentPrice,
                    Id = c.CarId,

                })
                .FirstOrDefaultAsync();

            return rentCarViewModel;
        }


        public async Task<ICollection<RentCarViewModel>> GetMyRentedCarsAsync(string userId)
        {
            var cars = await this._dbContext
                .Cars
                .Where(c => c.RenterId == userId && c.RenterId != null)
                .Select(c => new RentCarViewModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    Year = c.Year,
                    Description = c.Description,
                    Price = c.Price,
                    Color = c.Color,
                    ImageUrl = c.ImageUrl,
                    RentPrice = c.RentPrice,
                    RentalStartDate = c.RentalStartDate.HasValue ? c.RentalStartDate.Value : DateTime.Now.AddDays(1),
                    RentalEndDate = c.RentalEndDate ?? DateTime.Now.AddDays(1),
                    RenterName = c.Renter.FirstName + " " + c.Renter.LastName,
                    Id = c.CarId
                }).ToListAsync();

            return cars;
        }

        //public async Task<bool> HasUserEnoughMoneyAsync(double userBalance, RentCarViewModel rentCarViewModel)
        //{
        //   var car = await this._dbContext.Cars.FirstAsync(c => c.CarId == rentCarViewModel.Id);

        //   //calculate how much days the car is rented and then multiply it by the price per day (RentPrice)
        //   var days = ((DateTime)rentCarViewModel!.RentalEndDate! - (DateTime)rentCarViewModel!.RentalStartDate!).Days;

        //   var totalPrice = days * rentCarViewModel.RentPrice;

        //   return totalPrice <= userBalance;
        //}

        public async Task<double> TotalMoneyToRentAsync(RentCarViewModel rentCarViewModel)
        {
            var car = await this._dbContext.Cars.FirstAsync(c => c.CarId == rentCarViewModel.Id);

            var days = ((DateTime)rentCarViewModel!.RentalEndDate! - (DateTime)rentCarViewModel!.RentalStartDate!).Days;

            var totalPrice = days * rentCarViewModel.RentPrice;

            return totalPrice;
        }

        //public async Task<bool> HasUserEnoughMoneyToRentMoreAsync(double userBalance,
        //    RentCarViewModel rentCarViewModel, DateTime pastEndDate)
        //{   
        //    var car = await this._dbContext.Cars.FirstAsync(c => c.CarId == rentCarViewModel.Id);

        //    //calculate how much days the car is rented and then multiply it by the price per day (RentPrice)
        //    var days = ((DateTime)rentCarViewModel!.RentalEndDate! - pastEndDate).Days;

        //    var totalPrice = days * rentCarViewModel.RentPrice;
        //    totalPrice += 10;

        //    return totalPrice <= userBalance;
        //}

        public async Task<double> TotalMoneyToRentMore(RentCarViewModel rentCarViewModel, DateTime pastEndDate)
        {   
            var car = await this._dbContext.Cars.FirstAsync(c => c.CarId == rentCarViewModel.Id);

            var days = ((DateTime)rentCarViewModel!.RentalEndDate! - pastEndDate).Days;

            var totalPrice = days * rentCarViewModel.RentPrice;
            totalPrice += 10;

            return totalPrice;
        }

        public bool IsStartDateBeforeEndDate(RentCarViewModel rentCarViewModel)
        {
            var days = ((DateTime)rentCarViewModel!.RentalEndDate! - (DateTime)rentCarViewModel!.RentalStartDate!).Days;

            //check if RentalStartDate is before RentalEndDate
            if (days <= 0)
            {
                return false;
            }

            return true;
        }

        public async Task UpdateRentalForCarAsync(RentCarViewModel rentCarViewModel, string userId)
        {
            Car car = await this._dbContext.Cars
                .FirstAsync(c => c.CarId == rentCarViewModel.Id);

            car.RentalEndDate = rentCarViewModel.RentalEndDate;

            await this._dbContext.SaveChangesAsync();
        }

        public async Task EndRentalAsync(int carId, string userId)
        {
            Car car = await this._dbContext.Cars
                .FirstAsync(c => c.CarId == carId);

            car.RenterId = null;
            car.RentalStartDate = null;
            car.RentalEndDate = null;

            await this._dbContext.SaveChangesAsync();
        }
        


    }


}