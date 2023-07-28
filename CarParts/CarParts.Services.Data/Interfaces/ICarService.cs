using CarParts.Data.Models;
using CarParts.Web.ViewModels.Car;

namespace CarParts.Services.Data.Interfaces
{
    public interface ICarService
    {
        Task<ICollection<CarViewModel>> GetAllCarsAsync();

        Task<AddCarViewModel> GetAddCarViewModelAsync();

        Task AddCarAsync(AddCarViewModel car, int dealerId);

        Task<DetailsCarViewModel?> GetCarDetailsAsync(int id);

        Task<EditCarViewModel?> GetEditCarViewModelAsync(int id, string userId);

        Task EditCarAsync(int id, EditCarViewModel car);

        Task DeleteCarAsync(int id, string userId);

        Task<Car?> GetCarByIdAsync(int id);

        Task<ICollection<CarViewModel>> GetMyCarsAsync(string userId);

        Task<ICollection<CarViewModel>> GetMyFavoriteCarsAsync(string userId);

        Task<bool> AddCarToMyFavoriteCarsAsync(int carId, string userId);

        Task<bool> RemoveCarFromMyFavoriteCarsAsync(int carId, string userId);

        Task<ICollection<CarViewModel>> SearchCarsAsync(string searchTerm, string category, string priceSort
            , string transmissionName, string fuelName,
            int? fromYear, int? toYear, int? fromHp, int? toHp,
            int? fromPrice, int? toPrice);


        Task<bool> IsCarAlreadyInMyFavoriteCars(int carId, string userId);

        Task<bool> ExistsByIdAsync(int carId);
        Task<bool> IsRentedAsync(int carId);

        Task RentCarAsync(RentCarViewModel rentCarViewModel, string userId);

        Task<RentCarViewModel?> GetRentCarViewModelAsync(int id);
        Task<ICollection<RentCarViewModel>> GetMyRentedCarsAsync(string getUserId);
        Task<double> TotalMoneyToRentAsync(RentCarViewModel rentCarViewModel);
        Task UpdateRentalForCarAsync(RentCarViewModel rentCarViewModel, string userId);

        Task EndRentalAsync(int carId, string userId);

        bool IsStartDateBeforeEndDate(RentCarViewModel rentCarViewModel);

        Task<double> TotalMoneyToRentMore(RentCarViewModel rentCarViewModel, DateTime endDate);

      
    }

}
