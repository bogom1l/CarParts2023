using CarParts.Data.Models;
using CarParts.Web.ViewModels.Part;

namespace CarParts.Services.Data.Interfaces
{
    public interface IPartService
    {
        Task<ICollection<PartViewModel>> GetAllPartsAsync();

        Task<AddPartViewModel> GetAddPartViewModelAsync();

        Task AddPartAsync(AddPartViewModel addPartViewModel, string userId);

        Task<DetailsPartViewModel?> GetPartDetailsAsync(int id);

        Task<Part?> GetPartByIdAsync(int id);

        Task<EditPartViewModel?> GetEditPartViewModelAsync(int id, string userId);

        Task EditPartAsync(int id, EditPartViewModel editPartViewModel);

        Task DeletePartAsync(int id, string userId);

        Task<ICollection<PartViewModel>> GetMyPartsAsync(string userId);

        Task<ICollection<PartViewModel>> GetMyFavoritePartsAsync(string userId);

        Task<bool> AddPartToMyFavoritePartsAsync(int id, string userId);

        
        Task<bool> RemovePartFromMyFavoritePartsAsync(int id, string userId);

    }
}
