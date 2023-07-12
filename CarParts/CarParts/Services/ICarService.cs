using CarParts.ViewModels.Car;

namespace CarParts.Services
{
    public interface ICarService
    {
        Task<ICollection<CarViewModel>> GetAllCarsAsync();

        Task<AddCarViewModel> GetAddCarViewModelAsync();
    }
}
