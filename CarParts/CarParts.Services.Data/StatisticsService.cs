namespace CarParts.Services.Data
{
    using CarParts.Data;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class StatisticsService : IStatisticsService
    {
        private readonly ApplicationDbContext _dbContext;

        public StatisticsService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<int> GetTotalCars()
        {
            return await _dbContext.Cars.CountAsync();
        }

        public async Task<int> GetTotalParts()
        {
            return await _dbContext.Parts.CountAsync();
        }

        public async Task<int> GetTotalUsers()
        {
            return await _dbContext.Users.CountAsync();
        }

        public async Task<int> GetTotalDealers()
        {
            return await _dbContext.Dealers.CountAsync();
        }

        public async Task<int> GetTotalRents()
        {
            return await _dbContext.Cars
                .Where(c => !string.IsNullOrEmpty(c.RenterId)).CountAsync();
        }
    }
}