namespace CarParts.Services.Data.Interfaces
{
    using CarParts.Data.Models;
    using Web.ViewModels.Part;

    public interface IPartService
    {
        public Task<ICollection<PartViewModel>> GetAllPartsAsync();

        public Task<AddPartViewModel> GetAddPartViewModelAsync();

        public Task AddPartAsync(AddPartViewModel addPartViewModel, string userId);

        public Task<DetailsPartViewModel?> GetDetailsPartViewModelAsync(int partId);

        public Task<Part?> GetPartByIdAsync(int partId);

        public Task<EditPartViewModel?> GetEditPartViewModelAsync(int partId);

        public Task EditPartAsync(int partId, EditPartViewModel editPartViewModel);

        public Task DeletePartAsync(int partId, string userId);

        public Task<ICollection<PartViewModel>> GetMyPartsAsync(string userId);

        public Task<ICollection<PartViewModel>> GetMyFavoritePartsAsync(string userId);

        public Task<bool> AddPartToMyFavoritePartsAsync(int partId, string userId);

        public Task<bool> RemovePartFromMyFavoritePartsAsync(int partId, string userId);

        public Task<ICollection<PartViewModel>> SearchPartsAsync(string searchTerm, string category,
            string priceSort, int? fromPrice, int? toPrice);
    }
}