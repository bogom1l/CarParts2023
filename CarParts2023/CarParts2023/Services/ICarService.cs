using CarParts2023.ViewModels.Car;

namespace CarParts2023.Services
{
    public interface ICarService
    {
        Task<ICollection<CarViewModel>> GetAllCarsAsync();

        Task<AddCarViewModel> GetAddCarViewModelAsync();

        Task AddCarAsync(AddCarViewModel car, string userId);
    }
}
