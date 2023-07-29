namespace CarParts.Services.Data.Interfaces
{
    using CarParts.Data.Models;
    using Web.ViewModels.Part;

    public interface IPartService
    {
        Task<ICollection<PartViewModel>> GetAllPartsAsync();

        Task<AddPartViewModel> GetAddPartViewModelAsync();

        Task AddPartAsync(AddPartViewModel addPartViewModel, string userId);

        Task<DetailsPartViewModel?> GetDetailsPartViewModelAsync(int partId);

        Task<Part?> GetPartByIdAsync(int partId);

        Task<EditPartViewModel?> GetEditPartViewModelAsync(int partId);

        Task EditPartAsync(int partId, EditPartViewModel editPartViewModel);

        Task DeletePartAsync(int partId, string userId);

        Task<ICollection<PartViewModel>> GetMyPartsAsync(string userId);

        Task<ICollection<PartViewModel>> GetMyFavoritePartsAsync(string userId);

        Task<bool> AddPartToMyFavoritePartsAsync(int partId, string userId);

        Task<bool> RemovePartFromMyFavoritePartsAsync(int partId, string userId);

        Task<ICollection<PartViewModel>> SearchPartsAsync(string searchTerm, string category,
            string priceSort, int? fromPrice, int? toPrice);
    }
}