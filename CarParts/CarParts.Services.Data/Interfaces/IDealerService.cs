namespace CarParts.Services.Data.Interfaces
{
    using Web.ViewModels.Dealer;

    public interface IDealerService
    {
        public Task<int> GetDealerIdByUserIdAsync(string userId);

        public Task<bool> DealerExistsByUserIdAsync(string userId);

        public Task<bool> DealerExistsByPhoneNumberAsync(string phoneNumber);

        public Task<bool> HasRentsByUserIdAsync(string userId);

        public Task BecomeDealerAsync(BecomeDealerFormModel dealer, string userId);
    }
}