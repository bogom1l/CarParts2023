namespace CarParts.Services.Data
{
    using CarParts.Data;
    using CarParts.Data.Models;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Web.ViewModels.Dealer;

    public class DealerService : IDealerService
    {
        private readonly ApplicationDbContext _dbContext;

        public DealerService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> GetDealerIdByUserIdAsync(string userId)
        {
            var dealer = await _dbContext
                .Dealers
                .FirstOrDefaultAsync(d => d.UserId == userId);

            if (dealer == null)
            {
                return 0;
            }

            return dealer.Id;
        }

        public async Task<bool> DealerExistsByUserIdAsync(string userId)
        {
            return await _dbContext
                .Dealers
                .AnyAsync(d => d.UserId == userId);
        }

        public async Task<bool> DealerExistsByAddressAsync(string address)
        {
            return await _dbContext
                .Dealers
                .AnyAsync(d => d.Address == address);
        }

        public async Task<bool> HasRentsByUserIdAsync(string userId)
        {
            var cars = await _dbContext
                .Cars
                .Where(c => c.RenterId == userId)
                .ToListAsync();

            return cars.Any();
        }

        public async Task BecomeDealerAsync(BecomeDealerFormModel dealer, string userId)
        {
            var dealerData = new Dealer
            {
                Address = dealer.Address,
                UserId = userId
            };

            await _dbContext.Dealers.AddAsync(dealerData);
            await _dbContext.SaveChangesAsync();
        }
    }
}