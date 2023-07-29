namespace CarParts.Services.Data.Interfaces
{
    public interface IUserService
    {
        Task<string> GetUserFullNameByEmail(string email);

        Task<double> GetBalance(string userId);

        Task AddMoney(string userId);

        Task RemoveMoney(string userId, double moneyToRemove);

        Task<string> GetUserIdByEmail(string email);
    }
}