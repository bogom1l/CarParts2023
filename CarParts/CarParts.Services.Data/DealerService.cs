using CarParts.Data;
using CarParts.Data.Models;
using CarParts.Services.Data.Interfaces;
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

        public async Task<bool> AgentExistsByUserIdAsync(string userId)
        {
            return await this._dbContext
                .Dealers
                .AnyAsync(d => d.UserId == userId); //TODO: .ToString() necessary?
        }
    }
}
