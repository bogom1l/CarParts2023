namespace CarParts.Services.Data.Interfaces
{
    using Web.ViewModels.Dealer;

    public interface IDealerService
    {
        public Task BecomeDealerAsync(BecomeDealerFormModel dealer, string userId);

        public Task<bool> DealerExistsByUserIdAsync(string userId);

        public Task<bool> DealerExistsByAddressAsync(string phoneNumber);

        public Task<bool> HasRentsByUserIdAsync(string userId);

        public Task<int> GetDealerIdByUserIdAsync(string userId);
    }
}