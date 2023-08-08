namespace CarParts.Services.Tests.UnitTests
{
    using Data;
    using Data.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Web.ViewModels.Dealer;

    public class DealerServiceTests : UnitTestsBase
    {
        private IDealerService _dealerService;

        [OneTimeSetUp]
        public void SetUp()
        {
            _dealerService = new DealerService(_data);
        }


        [Test]
        public async Task DealerExistsByUserIdAsync_ShouldReturnTrueWhenExists()
        {
            var existingDealerUserId = DealerUser.Id;

            var result = await _dealerService.DealerExistsByUserIdAsync(existingDealerUserId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task DealerExistsByUserIdAsync_ShouldReturnFalseWhenNotExists()
        {
            var existingDealerUserId = RenterUser.Id;

            var result = await _dealerService.DealerExistsByUserIdAsync(existingDealerUserId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task GetDealerIdByUserIdAsync_ReturnsCorrectId()
        {
            // Arrange
            var userId = DealerUser.Id;

            // Act
            var result = await _dealerService.GetDealerIdByUserIdAsync(userId);

            // Assert
            Assert.AreEqual(Dealer.Id, result);
        }

        [Test]
        public async Task GetDealerIdByUserIdAsync_ReturnsZeroWhenNotFound()
        {
            // Arrange
            var userId = "NonExistentUserId";

            // Act
            var result = await _dealerService.GetDealerIdByUserIdAsync(userId);

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public async Task DealerExistsByAddressAsync_ReturnsTrueWhenExists()
        {
            // Arrange
            var address = Dealer.Address;

            // Act
            var result = await _dealerService.DealerExistsByAddressAsync(address);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task DealerExistsByAddressAsync_ReturnsFalseWhenNotExists()
        {
            // Arrange
            var address = "NonExistentAddress";

            // Act
            var result = await _dealerService.DealerExistsByAddressAsync(address);

            // Assert
            Assert.IsFalse(result);
        }


        [Test]
        public async Task HasRentsByUserIdAsync_ReturnsFalseWhenNoRents()
        {
            // Arrange
            var userId = "NonExistentUserId";

            // Act
            var result = await _dealerService.HasRentsByUserIdAsync(userId);

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
            var dealersBefore = await _data.Dealers.CountAsync();

            // Act
            await _dealerService.BecomeDealerAsync(dealerFormModel, userId);

            // Assert
            var addedDealer = await _data.Dealers.FirstOrDefaultAsync(x => x.UserId == userId);
            Assert.NotNull(addedDealer);
            Assert.AreEqual(dealerFormModel.Address, addedDealer.Address);
            Assert.AreEqual(userId, addedDealer.UserId);
            Assert.AreEqual(dealersBefore + 1, await _data.Dealers.CountAsync());
        }
    }
}