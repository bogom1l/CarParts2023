namespace CarParts.Services.Data.Interfaces
{
    using CarParts.Data.Models;
    using Web.ViewModels.Car;

    public interface ICarService
    {
        public Task<ICollection<CarViewModel>> GetAllCarsAsync();

        public Task<AddCarViewModel> GetAddCarViewModelAsync();

        public Task AddCarAsync(AddCarViewModel car, int dealerId);

        public Task<DetailsCarViewModel?> GetDetailsCarViewModelAsync(int carId);

        public Task<EditCarViewModel?> GetEditCarViewModelAsync(int carId);

        public Task EditCarAsync(int carId, EditCarViewModel car);

        public Task DeleteCarAsync(int carId, string userId);

        public Task<Car?> GetCarByIdAsync(int carId);

        public Task<ICollection<CarViewModel>> GetMyCarsAsync(string userId);

        public Task<ICollection<CarViewModel>> GetMyFavoriteCarsAsync(string userId);

        public Task<bool> IsCarMine(int carId, string userId);

        public Task<bool> AddCarToMyFavoriteCarsAsync(int carId, string userId);

        public Task<bool> RemoveCarFromMyFavoriteCarsAsync(int carId, string userId);

        public Task<ICollection<CarViewModel>> SearchCarsAsync(string searchTerm, string category,
            string priceSort, string transmissionName, string fuelName, int? fromYear,
            int? toYear, int? fromHp, int? toHp, int? fromPrice, int? toPrice);

        public Task<bool> ExistsByIdAsync(int carId);

        public Task<bool> IsRentedAsync(int carId);

        public Task<bool> IsRentedByMeAsync(int carId, string userId);

        public Task RentCarAsync(RentCarViewModel rentCarViewModel, string userId);

        public Task<RentCarViewModel?> GetRentCarViewModelAsync(int carId);

        public Task<ICollection<RentCarViewModel>> GetMyRentedCarsAsync(string getUserId);

        public Task UpdateCarRentalAsync(RentCarViewModel rentCarViewModel);

        public Task EndCarRentalAsync(int carId);

        public bool IsRentalPeriodValid(RentCarViewModel rentCarViewModel);

        public Task<double> TotalMoneyToRentAsync(RentCarViewModel rentCarViewModel);

        public Task<double> TotalMoneyToExtendRentAsync(RentCarViewModel rentCarViewModel, DateTime endDate);

        public Task<double> TotalMoneyToReturnForEndingRental(int carId);
    }
}