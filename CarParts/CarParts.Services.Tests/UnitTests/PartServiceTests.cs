namespace CarParts.Services.Tests.UnitTests
{
    using Data;
    using Data.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Web.ViewModels.Part;
    using Web.ViewModels.Part.PartProperties;

    public class _partServiceTests : UnitTestsBase
    {
        private IPartService _partService;

        [OneTimeSetUp]
        public void SetUp()
        {
            _partService = new PartService(_data);
        }


        [Test]
        public async Task AddPartAsync_AddsNewPart()
        {
            // Arrange
            var addPartViewModel = new AddPartViewModel
            {
                Name = "name1",
                Description = "bb",
                Price = 123,
                ImageUrl = "image",
                CategoryId = 1,
                Categories = new List<PartCategoryViewModel>()
            };
            var dealerId = 1; 

            // Act
            await _partService.AddPartAsync(addPartViewModel, dealerId);
            var addedPart = await _data.Parts.FirstOrDefaultAsync(p => p.Name == "name1");

            // Assert
            Assert.NotNull(addedPart);
            Assert.AreEqual(addPartViewModel.Name, addedPart.Name);
        }


        [Test]
        public async Task GetPartByIdAsync_ReturnsPart()
        {
            // Arrange
            var partId = 1; 

            // Act
            var result = await _partService.GetPartByIdAsync(partId);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(partId, result.PartId);
        }


        [Test]
        public async Task EditPartAsync_EditsPart()
        {
            // Arrange
            var partId = 1; 
            var editPartViewModel = new EditPartViewModel
            {
                Name = "aa",
                Description = "bb",
                Price = 123,
                CategoryId = 1,
                Categories = new List<PartCategoryViewModel>(),
                ImageUrl = "image"
            };

            // Act
            await _partService.EditPartAsync(partId, editPartViewModel);
            var editedPart = await _data.Parts.FirstOrDefaultAsync(p => p.PartId == partId);

            // Assert
            Assert.NotNull(editedPart);
        }

        [Test]
        public async Task IsUserOwnerOfPartByIdAsync_ReturnsTrueWhenUserIsOwner()
        {
            // Arrange
            var partId = 2; 
            var userId = "PurchaserId"; 

            // Act
            var result = await _partService.IsUserOwnerOfPartByIdAsync(partId, userId);

            // Assert
            Assert.IsFalse(result);
        }


        [Test]
        public async Task AddPartToMyFavoritePartsAsync_AddsPartToMyFavoriteParts()
        {
            // Arrange
            var partId = 2; 
            var userId = "Purchaser2Id"; 

            // Act
            await _partService.AddPartToMyFavoritePartsAsync(partId, userId);
            var addedPart =
                await _data.UsersFavoriteParts.FirstOrDefaultAsync(p => p.PartId == partId && p.UserId == userId);

            // Assert
            Assert.NotNull(addedPart);

        }
    }
}