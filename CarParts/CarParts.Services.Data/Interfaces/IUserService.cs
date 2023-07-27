namespace CarParts.Services.Data.Interfaces
{
    using CarParts.Web.ViewModels.Car;

    public interface IUserService
    {
        Task<string> GetUserFullNameByEmail(string email);

        Task<double> GetBalance(string userId);
        Task AddMoney(string userId);

        Task RemoveMoney(string userId, RentCarViewModel rentCarViewModel);

        Task<string> GetUserIdByEmail(string email);
    }
}
