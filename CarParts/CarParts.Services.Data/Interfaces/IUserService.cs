﻿namespace CarParts.Services.Data.Interfaces
{
    using Web.ViewModels.User;

    public interface IUserService
    {
       public Task<double> GetUserBalanceById(string userId);

       public Task AddMoney(string userId);

       public Task RemoveMoney(string userId, double moneyToRemove);

       public Task ResetMoney(string userId);

       public Task AddCustomAmountMoney(string userId, double amount);

       public Task<string> GetUserFullNameById(string userId);

       public Task<ICollection<UserViewModel>> GetAllUsersAsync();
    }
}