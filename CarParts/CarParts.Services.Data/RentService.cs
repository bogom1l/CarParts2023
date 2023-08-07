namespace CarParts.Services.Data
{
    using CarParts.Data;
    using Interfaces;
    using Mapping;
    using Microsoft.EntityFrameworkCore;
    using Web.ViewModels.Rent;

    public class RentService : IRentService
    {
        private readonly ApplicationDbContext _dbContext;

        public RentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<RentInfoViewModel>> GetAllRentsAsync()
        {
            var allRents = await _dbContext
                .Cars
                .Include(c => c.Dealer.User)
                .Include(c => c.Renter)
                .Where(c => c.RenterId != null)
                .To<RentInfoViewModel>()
                .ToListAsync();

            return allRents;
        }
    }
}