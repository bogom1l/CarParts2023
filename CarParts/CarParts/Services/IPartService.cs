using CarParts.ViewModels.Part;

namespace CarParts.Services
{
    public interface IPartService
    {
        Task<ICollection<PartViewModel>> GetAllPartsAsync();

        Task<AddPartViewModel> GetAddPartViewModelAsync();

        Task AddPartAsync(AddPartViewModel addPartViewModel, string userId);
    }
}
