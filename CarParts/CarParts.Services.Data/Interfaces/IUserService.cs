namespace CarParts.Services.Data.Interfaces
{
    using Web.ViewModels.User;

    public interface IUserService
    {
        public Task<double> GetUserBalanceByIdAsync(string userId);

        public Task AddMoneyAsync(string userId);

        public Task RemoveMoneyAsync(string userId, double moneyToRemove);

        public Task ResetMoneyAsync(string userId);

        public Task AddCustomAmountMoneyAsync(string userId, double amount);

        public Task<string> GetUserFullNameByIdAsync(string userId);

        public Task<ICollection<UserViewModel>> GetAllUsersAsync();

        public Task<bool> IsUserDealerAsync(string userId);

        public Task DeleteAllReviewsForCarAsync(int id);

        public Task DeleteAllReviewsAsync();

        public Task DeleteAllReviewsForUserByIdAsync(string userId);

        public Task<int> GetMyReviewsCountAsync(string userId);
    }
}