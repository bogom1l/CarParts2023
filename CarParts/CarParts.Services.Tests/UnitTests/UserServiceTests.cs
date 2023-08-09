namespace CarParts.Services.Tests.UnitTests
{
    using Data;
    using Data.Interfaces;

    public class UserServiceTests : UnitTestsBase
    {
        private IUserService _userService;

        [OneTimeSetUp]
        public void SetUp()
        {
            _userService = new UserService(_data);
        }

        [Test]
        public async Task GetUserBalanceByIdAsync_ReturnsCorrectBalance()
        {
            // Arrange
            var userId = "RenterId2";
            var expectedBalance = 123;

            // Act
            var result = await _userService.GetUserBalanceByIdAsync(userId);

            // Assert
            Assert.AreEqual(expectedBalance, result);
        }

        [Test]
        public async Task GetUserBalanceByIdAsync_ReturnsZeroForNonExistentUser()
        {
            // Arrange
            var userId = "NonExistentUserId";
            var expectedBalance = 0.0;

            // Act
            var result = await _userService.GetUserBalanceByIdAsync(userId);

            // Assert
            Assert.AreEqual(expectedBalance, result);
        }

        [Test]
        public async Task AddMoneyAsync_IncreasesBalanceBy100()
        {
            // Arrange
            var userId = "DealerUserId";
            var initialBalance = 123;

            // Act
            await _userService.AddMoneyAsync(userId);
            var newBalance = await _userService.GetUserBalanceByIdAsync(userId);

            // Assert
            Assert.AreEqual(initialBalance + 100, newBalance);
        }

        [Test]
        public async Task AddCustomAmountMoneyAsync_IncreasesBalanceByCustomAmount()
        {
            // Arrange
            var userId = "RenterUserId";
            var initialBalance = 123;
            var customAmount = 150;

            // Act
            await _userService.AddCustomAmountMoneyAsync(userId, customAmount);
            var newBalance = await _userService.GetUserBalanceByIdAsync(userId);

            // Assert
            Assert.AreEqual(initialBalance + customAmount, newBalance);
        }

        [Test]
        public async Task RemoveMoneyAsync_DecreasesBalanceBySpecifiedAmount()
        {
            // Arrange
            var userId = "RenterId2";
            var initialBalance = 123;
            var amountToRemove = 23;

            // Act
            await _userService.RemoveMoneyAsync(userId, amountToRemove);
            var newBalance = await _userService.GetUserBalanceByIdAsync(userId);

            // Assert
            Assert.That(newBalance, Is.EqualTo(initialBalance - amountToRemove));
        }

        [Test]
        public async Task ResetMoneyAsync_SetsBalanceToZero()
        {
            // Arrange
            var userId = "RenterUserId";

            // Act
            await _userService.ResetMoneyAsync(userId);
            var newBalance = await _userService.GetUserBalanceByIdAsync(userId);

            // Assert
            Assert.That(newBalance, Is.EqualTo(0));
        }

        [Test]
        public async Task IsUserDealerAsync_ReturnsTrueWhenDealer()
        {
            // Arrange
            var userId = "DealerUserId";

            // Act
            var result = await _userService.IsUserDealerAsync(userId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task GetUserFullNameByIdAsync_ReturnsCorrectFullName()
        {
            // Arrange
            var userId = "RenterId2";
            var expectedFullName = "Renter2 Renterov2";

            // Act
            var result = await _userService.GetUserFullNameByIdAsync(userId);

            // Assert
            Assert.AreEqual(expectedFullName, result);
        }
    }
}