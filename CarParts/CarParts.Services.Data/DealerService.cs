using CarParts.Data;
using CarParts.Data.Models;
using CarParts.Services.Data.Interfaces;
using CarParts.Web.ViewModels.Dealer;
using Microsoft.EntityFrameworkCore;

namespace CarParts.Services.Data
{
    public class DealerService : IDealerService
    {
        private readonly ApplicationDbContext _dbContext;

        public DealerService(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<int> GetDealerIdByUserIdAsync(string userId)
        {
            Dealer? dealer = await this._dbContext
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
            return await this._dbContext
                .Dealers
                .AnyAsync(d => d.UserId == userId); //TODO: .ToString() necessary?
        }

        public async Task<bool> DealerExistsByPhoneNumberAsync(string phoneNumber)
        {
            return await this._dbContext
                .Dealers
                .AnyAsync(d => d.PhoneNumber == phoneNumber);
        }

        public async Task<bool> HasRentsByUserIdAsync(string userId)
        {
            ApplicationUser? user = await this._dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return false;
            }

            return user.RentedCars.Any();
        }

        public async Task BecomeDealerAsync(BecomeDealerFormModel dealer, string userId)
        {
            Dealer dealerData = new Dealer
            {
                PhoneNumber = dealer.PhoneNumber,
                UserId = userId,
            };

            await this._dbContext.Dealers.AddAsync(dealerData);
            await this._dbContext.SaveChangesAsync();
        }
    }
}
