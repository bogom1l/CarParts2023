﻿using CarParts.Data.Models;
using CarParts.Web.ViewModels.Car;

namespace CarParts.Services.Data.Interfaces
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

        Task<Car?> GetCarByIdAsync(int id);

        Task<ICollection<CarViewModel>> GetMyCarsAsync(string userId);

        Task<ICollection<CarViewModel>> GetMyFavoriteCarsAsync(string userId);

        Task<bool> AddCarToMyFavoriteCarsAsync(int carId, string userId);

        Task<bool> RemoveCarFromMyFavoriteCarsAsync(int carId, string userId);
    }
}
