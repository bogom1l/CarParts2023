namespace CarParts.Services.Tests.UnitTests
{
    using Data;
    using Data.Interfaces;

    [TestFixture]
    public class StatisticsServiceTests : UnitTestsBase
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            _statisticsService = new StatisticsService(_data);
        }

        private IStatisticsService _statisticsService;


        [Test]
        public async Task GetTotalCars_ReturnsCorrectCount()
        {
            // Arrange
            var expectedCount = _data.Cars.Count();

            // Act
            var result = await _statisticsService.GetTotalCars();

            // Assert
            Assert.AreEqual(expectedCount, result);
        }

        [Test]
        public async Task GetTotalParts_ReturnsCorrectCount()
        {
            // Arrange
            var expectedCount = _data.Parts.Count();

            // Act
            var result = await _statisticsService.GetTotalParts();

            // Assert
            Assert.AreEqual(expectedCount, result);
        }

        [Test]
        public async Task GetTotalUsers_ReturnsCorrectCount()
        {
            // Arrange
            var expectedCount = _data.Users.Count();

            // Act
            var result = await _statisticsService.GetTotalUsers();

            // Assert
            Assert.AreEqual(expectedCount, result);
        }

        [Test]
        public async Task GetTotalDealers_ReturnsCorrectCount()
        {
            // Arrange
            var expectedCount = _data.Dealers.Count();

            // Act
            var result = await _statisticsService.GetTotalDealers();

            // Assert
            Assert.AreEqual(expectedCount, result);
        }

        [Test]
        public async Task GetTotalRents_ReturnsCorrectCount()
        {
            // Arrange
            var expectedCount = _data.Cars.Count(c => !string.IsNullOrEmpty(c.RenterId));

            // Act
            var result = await _statisticsService.GetTotalRents();

            // Assert
            Assert.AreEqual(expectedCount, result);
        }

        [Test]
        public async Task GetTotalCars_ReturnsNotCorrectCount()
        {
            // Arrange
            var incorrectCount = 999; // Set an incorrect count

            // Act
            var result = await _statisticsService.GetTotalCars();

            // Assert
            Assert.AreNotEqual(incorrectCount, result);
        }

        [Test]
        public async Task GetTotalParts_ReturnsNotCorrectCount()
        {
            // Arrange
            var incorrectCount = 888; // Set an incorrect count

            // Act
            var result = await _statisticsService.GetTotalParts();

            // Assert
            Assert.AreNotEqual(incorrectCount, result);
        }
    }
}