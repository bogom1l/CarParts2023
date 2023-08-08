namespace CarParts.Services.Tests
{
    using CarParts.Data;
    using CarParts.Web.ViewModels.Dealer;
    using Data;
    using Data.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using static DatabaseSeeder;

    public class DealerServiceTests
    {
        private DbContextOptions<ApplicationDbContext> dbOptions;
        private ApplicationDbContext dbContext;

        private IDealerService dealerService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("CarPartsInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new ApplicationDbContext(this.dbOptions, false);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.dealerService = new DealerService(this.dbContext);
        }


        [Test]
        public async Task DealerExistsByUserIdAsync_ShouldReturnTrueWhenExists()
        {
            string existingDealerUserId = DealerUser.Id.ToString();

            bool result = await this.dealerService.DealerExistsByUserIdAsync(existingDealerUserId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task DealerExistsByUserIdAsync_ShouldReturnFalseWhenNotExists()
        {
            string existingDealerUserId = RenterUser.Id.ToString();

            bool result = await this.dealerService.DealerExistsByUserIdAsync(existingDealerUserId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task GetDealerIdByUserIdAsync_ReturnsCorrectId()
        {
            // Arrange
            var userId = DealerUser.Id.ToString();

            // Act
            var result = await this.dealerService.GetDealerIdByUserIdAsync(userId);

            // Assert
            Assert.AreEqual(Dealer.Id, result);
        }

        [Test]
        public async Task GetDealerIdByUserIdAsync_ReturnsZeroWhenNotFound()
        {
            // Arrange
            var userId = "NonExistentUserId";

            // Act
            var result = await this.dealerService.GetDealerIdByUserIdAsync(userId);

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public async Task DealerExistsByAddressAsync_ReturnsTrueWhenExists()
        {
            // Arrange
            var address = Dealer.Address;

            // Act
            var result = await this.dealerService.DealerExistsByAddressAsync(address);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task DealerExistsByAddressAsync_ReturnsFalseWhenNotExists()
        {
            // Arrange
            var address = "NonExistentAddress";

            // Act
            var result = await this.dealerService.DealerExistsByAddressAsync(address);

            // Assert
            Assert.IsFalse(result);
        }


        [Test]
        public async Task HasRentsByUserIdAsync_ReturnsFalseWhenNoRents()
        {
            // Arrange
            var userId = "NonExistentUserId";

            // Act
            var result = await this.dealerService.HasRentsByUserIdAsync(userId);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task BecomeDealerAsync_AddsDealerToDatabase()
        {
            // Arrange
            var dealerFormModel = new BecomeDealerFormModel
            {
                Address = "NewAddress"
            };
            var userId = "NewUserId";

            // Act
            await this.dealerService.BecomeDealerAsync(dealerFormModel, userId);

            // Assert
            var addedDealer = await dbContext.Dealers.FirstOrDefaultAsync(x => x.UserId == userId);
            Assert.NotNull(addedDealer);
            Assert.AreEqual(dealerFormModel.Address, addedDealer.Address);
            Assert.AreEqual(userId, addedDealer.UserId);
        }
    }
}