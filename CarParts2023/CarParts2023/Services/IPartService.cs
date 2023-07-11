using CarParts2023.ViewModels.Part;

namespace CarParts2023.Services
{
    public interface IPartService
    {
        Task<ICollection<PartViewModel>> GetAllPartsAsync();

        Task<AddPartViewModel> GetAddPartViewModelAsync();

        Task AddPartAsync(AddPartViewModel addPartViewModel, string userId);
    }
}
