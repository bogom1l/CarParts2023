namespace CarParts.Services.Data.Interfaces
{
    using CarParts.Data.Models;
    using Web.ViewModels.Car;

    public interface ICarService
    {
        Task<ICollection<CarViewModel>> GetAllCarsAsync();

        Task<AddCarViewModel> GetAddCarViewModelAsync();

        Task AddCarAsync(AddCarViewModel car, int dealerId);

        Task<DetailsCarViewModel?> GetDetailsCarViewModelAsync(int carId);

        Task<EditCarViewModel?> GetEditCarViewModelAsync(int carId);

        Task EditCarAsync(int carId, EditCarViewModel car);

        Task DeleteCarAsync(int carId, string userId);

        Task<Car?> GetCarByIdAsync(int carId);

        Task<ICollection<CarViewModel>> GetMyCarsAsync(string userId);

        Task<ICollection<CarViewModel>> GetMyFavoriteCarsAsync(string userId);

        Task<bool> AddCarToMyFavoriteCarsAsync(int carId, string userId);

        Task<bool> RemoveCarFromMyFavoriteCarsAsync(int carId, string userId);

        Task<ICollection<CarViewModel>> SearchCarsAsync(string searchTerm, string category,
            string priceSort, string transmissionName, string fuelName, int? fromYear,
            int? toYear, int? fromHp, int? toHp, int? fromPrice, int? toPrice);

        Task<bool> ExistsByIdAsync(int carId);

        Task<bool> IsRentedAsync(int carId);

        Task RentCarAsync(RentCarViewModel rentCarViewModel, string userId);

        Task<RentCarViewModel?> GetRentCarViewModelAsync(int carId);

        Task<ICollection<RentCarViewModel>> GetMyRentedCarsAsync(string getUserId);

        Task UpdateCarRentalAsync(RentCarViewModel rentCarViewModel);

        Task EndCarRentalAsync(int carId);

        bool IsRentalPeriodValid(RentCarViewModel rentCarViewModel);

        Task<double> TotalMoneyToRentAsync(RentCarViewModel rentCarViewModel);

        Task<double> TotalMoneyToExtendRentAsync(RentCarViewModel rentCarViewModel, DateTime endDate);
    }
}