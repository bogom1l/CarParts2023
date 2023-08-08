namespace CarParts.Services.Tests.UnitTests
{
    using CarParts.Data;
    using CarParts.Data.Models;
    using Mocks;

    public class UnitTestsBase
    {
        protected ApplicationDbContext _data;

        public ApplicationUser DealerUser { get; private set; }
        public ApplicationUser RenterUser { get; private set; }
        public Dealer Dealer { get; private set; }
        public Car Car { get; private set; }
        public Part Part { get; }

        [OneTimeSetUp]
        public void SetUpBase()
        {
            _data = DatabaseMock.Instance;

            SeedDatabase();
        }


        public void SeedDatabase()
        {
            DealerUser = new ApplicationUser
            {
                UserName = "Pesho",
                NormalizedUserName = "PESHO",
                Email = "pesho@agents.com",
                NormalizedEmail = "PESHO@AGENTS.COM",
                EmailConfirmed = true,
                PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                ConcurrencyStamp = "caf271d7-0ba7-4ab1-8d8d-6d0e3711c27d",
                SecurityStamp = "ca32c787-626e-4234-a4e4-8c94d85a2b1c",
                TwoFactorEnabled = false,
                FirstName = "Pesho",
                LastName = "Petrov"
            };
            _data.Users.Add(DealerUser);

            RenterUser = new ApplicationUser
            {
                UserName = "Gosho",
                NormalizedUserName = "GOSHO",
                Email = "gosho@renters.com",
                NormalizedEmail = "GOSHO@RENTERS.COM",
                EmailConfirmed = true,
                PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                ConcurrencyStamp = "8b51706e-f6e8-4dae-b240-54f856fb3004",
                SecurityStamp = "f6af46f5-74ba-43dc-927b-ad83497d0387",
                TwoFactorEnabled = false,
                FirstName = "Gosho",
                LastName = "Goshov"
            };
            _data.Users.Add(RenterUser);

            Dealer = new Dealer
            {
                Address = "St. Stolipin 13",
                User = DealerUser
            };
            _data.Dealers.Add(Dealer);

            Car = new Car
            {
                CarId = 1,
                Make = "make",
                Model = "model",
                Year = 2001,
                Description = "desc",
                Price = 123,
                Color = "color",
                EngineSize = 123,
                FuelTypeId = 1,
                FuelType = null,
                TransmissionId = 1,
                Transmission = null,
                CategoryId = 123,
                Category = null,
                Weight = 123,
                TopSpeed = 123,
                Acceleration = 2,
                Horsepower = 123,
                Torque = 123,
                FuelConsumption = 2,
                ImageUrl = "image",
                RentPrice = 123,
                RentalStartDate = null,
                RentalEndDate = null,
                RenterId = null,
                Renter = null,
                DealerId = 1,
                Dealer = null,
                UserFavoriteCars = null,
                Reviews = null,
                UserComparisonCars = null
            };
            _data.Cars.Add(Car);

            _data.SaveChanges();
        }

        [OneTimeTearDown]
        public void TearDownBase()
        {
            _data.Dispose();
        }
    }
}