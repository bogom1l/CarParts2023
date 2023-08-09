namespace CarParts.Services.Data
{
    using CarParts.Data;
    using CarParts.Data.Models;
    using Interfaces;
    using Mapping;
    using Microsoft.EntityFrameworkCore;
    using Web.ViewModels.Car;
    using Web.ViewModels.Car.CarProperties;
    using Web.ViewModels.Dealer;
    using Web.ViewModels.Review;
    using static Common.GlobalConstants.Car;

    /*
    using Car = CarParts.Data.Models.Car;
    using Review = CarParts.Data.Models.Review;
    */

    public class CarService : ICarService
    {
        private readonly ApplicationDbContext _dbContext;

        public CarService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<CarViewModel>> GetAllCarsAsync()
        {
            return await _dbContext.Cars.To<CarViewModel>().ToListAsync();
        }

        public async Task<AddCarViewModel> GetAddCarViewModelAsync()
        {
            var fuelTypes = await _dbContext.FuelTypes
                .To<CarFuelTypeViewModel>().ToListAsync();

            var transmissions = await _dbContext.Transmissions
                .To<CarTransmissionViewModel>().ToListAsync();

            var categories = await _dbContext.Categories
                .To<CarCategoryViewModel>().ToListAsync();

            var addCarViewModel = new AddCarViewModel
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
                RenterId = null,
                RentalStartDate = null,
                RentalEndDate = null
            };

            await _dbContext.Cars.AddAsync(carData);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<DetailsCarViewModel?> GetDetailsCarViewModelAsync(int carId)
        {
            var detailsCarViewModel = await _dbContext
                .Cars
                .Where(c => c.CarId == carId)
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
                    RentPrice = c.RentPrice,
                    RenterEmail = c.Renter.Email ?? null,
                    OwnerEmail = c.Dealer.User.Email,
                    DetailsDealerViewModel = new DetailsDealerViewModel
                    {
                        FullName = c.Dealer.User.FirstName + " " + c.Dealer.User.LastName,
                        Address = c.Dealer.Address,
                        Email = c.Dealer.User.Email
                    },
                    Reviews = c.Reviews.Select(r => new ReviewViewModel
                    {
                        Content = r.Content,
                        Rating = r.Rating,
                        DatePosted = r.DatePosted,
                        UserId = r.UserId,
                        Username = r.User.FirstName + " " + r.User.LastName,
                        CarId = r.CarId
                    }).ToList()
                }).FirstOrDefaultAsync();

            return detailsCarViewModel;
        }

        public async Task<EditCarViewModel?> GetEditCarViewModelAsync(int carId)
        {
            var fuelTypes = await _dbContext.FuelTypes
                .To<CarFuelTypeViewModel>().ToListAsync();

            var transmissions = await _dbContext.Transmissions
                .To<CarTransmissionViewModel>().ToListAsync();

            var categories = await _dbContext.Categories
                .To<CarCategoryViewModel>().ToListAsync();

            var editCarViewModel = await _dbContext.Cars
                .Where(c => c.CarId == carId)
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

        public async Task EditCarAsync(int carId, EditCarViewModel car)
        {
            var carData = await _dbContext.Cars
                .FirstOrDefaultAsync(c => c.CarId == carId);

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

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteCarAsync(int carId)
        {
            var carData = await _dbContext
                .Cars
                .FirstOrDefaultAsync(c => c.CarId == carId);

            if (carData != null)
            {
                _dbContext.Cars.Remove(carData);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Car?> GetCarByIdAsync(int carId)
        {
            var car = await _dbContext.Cars
                .Include(c => c.Dealer)
                .FirstOrDefaultAsync(c => c.CarId == carId);

            return car;
        }

        public async Task<ICollection<CarViewModel>> GetMyCarsAsync(string userId)
        {
            return await _dbContext
                .Cars
                .Where(c => c.Dealer.UserId == userId)
                .To<CarViewModel>()
                .ToListAsync();
        }

        public async Task<ICollection<CarViewModel>> GetMyFavoriteCarsAsync(string userId)
        {
            return await _dbContext
                .Cars
                .Where(c => c.UserFavoriteCars.Any(ufc => ufc.UserId == userId))
                .To<CarViewModel>()
                .ToListAsync();
        }

        public async Task<bool> IsCarInMyFavoritesAsync(int carId, string userId)
        {
            return await _dbContext
                .UsersFavoriteCars
                .AnyAsync(ufc => ufc.CarId == carId && ufc.UserId == userId);
        }

        public async Task<bool> IsUserOwnerOfCarByIdAsync(int carId, string userId)
        {
            return await _dbContext
                .Cars
                .AnyAsync(c => c.CarId == carId && c.Dealer.UserId == userId);
        }

        public async Task AddCarToMyFavoriteCarsAsync(int carId, string userId)
        {
            var userFavoriteCar = new UserFavoriteCar
            {
                CarId = carId,
                UserId = userId
            };

            await _dbContext.UsersFavoriteCars.AddAsync(userFavoriteCar);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveCarFromMyFavoriteCarsAsync(int carId, string userId)
        {
            var car = await _dbContext
                .UsersFavoriteCars
                .FirstOrDefaultAsync(ufc => ufc.CarId == carId && ufc.UserId == userId);

            if (car != null)
            {
                _dbContext.UsersFavoriteCars.Remove(car);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<ICollection<CarViewModel>> SearchCarsAsync(string searchTerm, string category,
            string priceSort, string transmissionName, string fuelName, int? fromYear,
            int? toYear, int? fromHp, int? toHp, int? fromPrice, int? toPrice, bool showOnlyNonRented)
        {
            var carsQuery = _dbContext.Cars.AsQueryable();

            if (!string.IsNullOrEmpty(category))
            {
                carsQuery = carsQuery.Where(c => c.Category.Name == category);
            }

            if (!string.IsNullOrEmpty(transmissionName))
            {
                carsQuery = carsQuery.Where(c => c.Transmission.Name == transmissionName);
            }

            if (!string.IsNullOrEmpty(fuelName))
            {
                carsQuery = carsQuery.Where(c => c.FuelType.Name == fuelName);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                carsQuery = carsQuery.Where(c =>
                    c.Make.Contains(searchTerm) ||
                    c.Model.Contains(searchTerm) ||
                    c.Description.Contains(searchTerm)
                );
            }

            if (fromPrice != null)
            {
                carsQuery = carsQuery.Where(c => c.Price >= fromPrice);
            }

            if (toPrice != null)
            {
                carsQuery = carsQuery.Where(c => c.Price <= toPrice);
            }

            if (fromYear != null)
            {
                carsQuery = carsQuery.Where(c => c.Year >= fromYear);
            }

            if (toYear != null)
            {
                carsQuery = carsQuery.Where(c => c.Year <= toYear);
            }

            if (fromHp != null)
            {
                carsQuery = carsQuery.Where(c => c.Horsepower >= fromHp);
            }

            if (toHp != null)
            {
                carsQuery = carsQuery.Where(c => c.Horsepower <= toHp);
            }

            if (priceSort == "asc")
            {
                carsQuery = carsQuery.OrderBy(c => c.Price);
            }
            else if (priceSort == "desc")
            {
                carsQuery = carsQuery.OrderByDescending(c => c.Price);
            }

            if (showOnlyNonRented)
            {
                carsQuery = carsQuery.Where(c => string.IsNullOrEmpty(c.RenterId));
            }

            var cars = await carsQuery
                .To<CarViewModel>().ToListAsync();

            return cars;
        }

        public async Task<bool> ExistsByIdAsync(int carId)
        {
            return await _dbContext
                .Cars
                .AnyAsync(c => c.CarId == carId);
        }

        public async Task<bool> IsRentedAsync(int carId)
        {
            var car = await _dbContext
                .Cars
                .FirstAsync(c => c.CarId == carId);

            return !string.IsNullOrEmpty(car.RenterId);
        }

        public async Task<bool> IsRentedByUserIdAsync(int carId, string userId)
        {
            var car = await _dbContext
                .Cars
                .FirstAsync(c => c.CarId == carId);

            return car.RenterId == userId;
        }

        public async Task RentCarAsync(RentCarViewModel rentCarViewModel, string userId)
        {
            var car = await _dbContext
                .Cars
                .FirstAsync(c => c.CarId == rentCarViewModel.Id);

            car.RenterId = userId;
            car.RentalStartDate = rentCarViewModel.RentalStartDate;
            car.RentalEndDate = rentCarViewModel.RentalEndDate;
            car.RentPrice = rentCarViewModel.RentPrice;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<RentCarViewModel?> GetRentCarViewModelAsync(int carId)
        {
            var rentCarViewModel = await _dbContext.Cars
                .Where(c => c.CarId == carId)
                .Select(c => new RentCarViewModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    Year = c.Year,
                    Description = c.Description,
                    Price = c.Price,
                    Color = c.Color,
                    ImageUrl = c.ImageUrl,
                    RentalStartDate = c.RentalStartDate ?? DateTime.Now,
                    RentalEndDate = c.RentalEndDate ?? DateTime.Now.AddDays(1),
                    RenterName = c.Renter.FirstName + " " + c.Renter.LastName,
                    RentPrice = c.RentPrice,
                    Id = c.CarId
                })
                .FirstOrDefaultAsync();

            return rentCarViewModel;
        }

        public async Task<ICollection<RentCarViewModel>> GetMyRentedCarsAsync(string userId)
        {
            var cars = await _dbContext
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
                    RentalStartDate = c.RentalStartDate ?? DateTime.Now.AddDays(1),
                    RentalEndDate = c.RentalEndDate ?? DateTime.Now.AddDays(1),
                    RenterName = c.Renter.FirstName + " " + c.Renter.LastName,
                    Id = c.CarId
                }).ToListAsync();

            return cars;
        }

        public double TotalMoneyToRentAsync(RentCarViewModel rentCarViewModel)
        {
            var days = ((DateTime)rentCarViewModel!.RentalEndDate! - (DateTime)rentCarViewModel!.RentalStartDate!).Days;

            return days * rentCarViewModel.RentPrice;
        }

        public double TotalMoneyToExtendRentAsync(RentCarViewModel rentCarViewModel, DateTime pastEndDate)
        {
            var days = ((DateTime)rentCarViewModel!.RentalEndDate! - pastEndDate).Days;

            var totalPrice = days * rentCarViewModel.RentPrice;
            totalPrice += TaxPriceForAdjustingRental;

            return totalPrice;
        }

        public bool IsRentalPeriodValid(RentCarViewModel rentCarViewModel)
        {
            var days = ((DateTime)rentCarViewModel!.RentalEndDate! - (DateTime)rentCarViewModel!.RentalStartDate!).Days;

            return days > 0;
        }

        public async Task UpdateCarRentalAsync(RentCarViewModel rentCarViewModel)
        {
            var car = await _dbContext.Cars
                .FirstOrDefaultAsync(c => c.CarId == rentCarViewModel.Id);

            if (car != null)
            {
                car.RentalEndDate = rentCarViewModel.RentalEndDate;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task EndCarRentalAsync(int carId)
        {
            var car = await _dbContext.Cars
                .FirstOrDefaultAsync(c => c.CarId == carId);

            if (car != null)
            {
                car.RenterId = null;
                car.RentalStartDate = null;
                car.RentalEndDate = null;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<double> TotalMoneyToReturnForEndingRentalAsync(int carId)
        {
            var car = await _dbContext.Cars.FirstOrDefaultAsync(c => c.CarId == carId);

            if (car.RentalEndDate.HasValue && car.RentalStartDate.HasValue)
            {
                var days = (car!.RentalEndDate!.Value - car!.RentalStartDate!.Value).Days;
                var totalPrice = days * car.RentPrice;

                return totalPrice;
            }

            return 0;
        }


        public async Task AddReviewAsync(ReviewViewModel reviewViewModel, string userId)
        {
            var review = new Review
            {
                Content = reviewViewModel.Content,
                Rating = Math.Round(reviewViewModel.Rating, 1),
                DatePosted = DateTime.Now,
                UserId = userId,
                CarId = reviewViewModel.CarId
            };

            await _dbContext.Reviews.AddAsync(review);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> HasUserAlreadyReviewedThisCarAsync(int carId, string userId)
        {
            return await _dbContext.Reviews.AnyAsync(r => r.CarId == carId && r.UserId == userId);
        }

        public async Task<ICollection<CompareCarViewModel>> GetAllCarCompareViewModelsAsync(string userId)
        {
            return await _dbContext
                .Cars
                .Where(c => c.UserComparisonCars.Any(ucc => ucc.UserId == userId))
                .To<CompareCarViewModel>()
                .ToListAsync();
        }

        public async Task AddCarForComparisonAsync(int carId, string userId)
        {
            var userComparisonCar = new UserComparisonCar
            {
                CarId = carId,
                UserId = userId
            };

            await _dbContext.UsersComparisonCars.AddAsync(userComparisonCar);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveCarFromComparisonAsync(int carId, string userId)
        {
            var userComparisonCar = await _dbContext
                .UsersComparisonCars
                .FirstOrDefaultAsync(c => c.CarId == carId && c.UserId == userId);

            if (userComparisonCar != null)
            {
                _dbContext.UsersComparisonCars.Remove(userComparisonCar);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task RemoveCarFromComparisonForAllUsersAsync(int carId)
        {
            var cars = await _dbContext
                .UsersComparisonCars
                .Where(ufc => ufc.CarId == carId).ToListAsync();

            _dbContext.UsersComparisonCars.RemoveRange(cars);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> IsCarInMyComparisonListAsync(int carId, string userId)
        {
            return await _dbContext
                .UsersComparisonCars
                .AnyAsync(c => c.CarId == carId && c.UserId == userId);
        }

        public async Task<bool> IsComparisonListFullAsync(string userId)
        {
            var comparisonListCount = await _dbContext
                .UsersComparisonCars
                .CountAsync(c => c.UserId == userId);

            return comparisonListCount >= ComparisonListMaxCount;
        }

        public async Task ClearMyComparisonListAsync(string userId)
        {
            var userComparisonCars = await _dbContext
                .UsersComparisonCars
                .Where(c => c.UserId == userId)
                .ToListAsync();

            _dbContext.UsersComparisonCars.RemoveRange(userComparisonCars);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<CarViewModel>> GetHomePageCarsAsync()
        {
            var cars = new List<CarViewModel>();

            var firstCar = await _dbContext.Cars.To<CarViewModel>()
                .FirstOrDefaultAsync(x => x.Make.Contains("BMW") && x.Model.Contains("E92 M3"));
            var secondCar = await _dbContext.Cars.To<CarViewModel>()
                .FirstOrDefaultAsync(x => x.Make.Contains("Mercedes-Benz") && x.Model.Contains("CLS 63 AMG"));
            var thirdCar = await _dbContext.Cars.To<CarViewModel>()
                .FirstOrDefaultAsync(x => x.Make.Contains("Audi") && x.Model.Contains("S5"));

            cars.Add(firstCar);
            cars.Add(secondCar);
            cars.Add(thirdCar);

            return cars;
        }
    }
}