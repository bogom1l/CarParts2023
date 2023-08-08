namespace CarParts.Services.Tests.UnitTests
{
    using Data;
    using Data.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Web.ViewModels.Car;

    public class CarServiceTests : UnitTestsBase
    {
        private ICarService _carService;

        [OneTimeSetUp]
        public void SetUp()
        {
            _carService = new CarService(_data);
        }

        [Test]
        public async Task AddPartAsync_AddsNewPart()
        {
            // Arrange
            var addCarViewModel = new AddCarViewModel
            {
                Make = "make1",
                Model = "model1",
                Year = 2001,
                Description = "d",
                Price = 123,
                Color = "red",
                EngineSize = 1123,
                FuelTypeId = 1,
                FuelTypes = null,
                TransmissionId = 1,
                Transmissions = null,
                CategoryId = 1,
                Categories = null,
                Weight = 1234,
                TopSpeed = 123,
                Acceleration = 12,
                Horsepower = 123,
                Torque = 123,
                FuelConsumption = 10,
                ImageUrl = "imageUrl",
                RentPrice = 123
            };
            var dealerId = 1;

            // Act
            await _carService.AddCarAsync(addCarViewModel, dealerId);
            var addedCar = await _data.Cars.FirstOrDefaultAsync(c => c.Model == "model1");

            // Assert
            Assert.NotNull(addedCar);
            Assert.AreEqual(addCarViewModel.Model, addedCar.Model);
            Assert.AreEqual(addCarViewModel.Make, addedCar.Make);
            Assert.AreEqual(addCarViewModel.Year, addedCar.Year);
            Assert.AreEqual(addCarViewModel.Description, addedCar.Description);
            Assert.AreEqual(addCarViewModel.Price, addedCar.Price);
            Assert.AreEqual(addCarViewModel.Color, addedCar.Color);
            Assert.AreEqual(addCarViewModel.EngineSize, addedCar.EngineSize);
            Assert.AreEqual(addCarViewModel.FuelTypeId, addedCar.FuelTypeId);
            Assert.AreEqual(addCarViewModel.TransmissionId, addedCar.TransmissionId);
            Assert.AreEqual(addCarViewModel.CategoryId, addedCar.CategoryId);
            Assert.AreEqual(addCarViewModel.Weight, addedCar.Weight);
            Assert.AreEqual(addCarViewModel.TopSpeed, addedCar.TopSpeed);
            Assert.AreEqual(addCarViewModel.Acceleration, addedCar.Acceleration);
            Assert.AreEqual(addCarViewModel.Horsepower, addedCar.Horsepower);
            Assert.AreEqual(addCarViewModel.Torque, addedCar.Torque);
            Assert.AreEqual(addCarViewModel.FuelConsumption, addedCar.FuelConsumption);
            Assert.AreEqual(addCarViewModel.ImageUrl, addedCar.ImageUrl);
            Assert.AreEqual(addCarViewModel.RentPrice, addedCar.RentPrice);
        }

        [Test]
        public async Task GetCarByIdAsync_ReturnsCar()
        {
            // Arrange
            var carId = 1;

            // Act
            var result = await _carService.GetCarByIdAsync(carId);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(carId, result.CarId);
        }
        




    }
}