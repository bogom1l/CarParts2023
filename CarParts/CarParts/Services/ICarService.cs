using CarParts.Data.Models;
using CarParts.ViewModels.Car;

namespace CarParts.Services
{
    public interface ICarService
    {
        Task<ICollection<CarViewModel>> GetAllCarsAsync();

        Task<AddCarViewModel> GetAddCarViewModelAsync();

        Task AddCarAsync(AddCarViewModel car, string userId);

        Task<DetailsCarViewModel?> GetCarDetailsAsync(int id);

        Task<EditCarViewModel?> GetEditCarViewModelAsync(int id, string userId);

        Task EditCarAsync(int id, EditCarViewModel car);

        Task DeleteCarAsync(int id, string userId);

        Task<Car?> GetCarById(int id);

        Task<ICollection<CarViewModel>> GetMyCarsAsync(string userId);
    }
}
