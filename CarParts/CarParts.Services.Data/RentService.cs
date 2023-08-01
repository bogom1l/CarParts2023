namespace CarParts.Services.Data
{
    using CarParts.Data;
    using Interfaces;
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
                .Select(c => new RentInfoViewModel
                {
                    CarMake = c.Make,
                    CarModel = c.Model,
                    CarImageUrl = c.ImageUrl,
                    DealerFullName = c.Dealer.User.FirstName + " " + c.Dealer.User.LastName,
                    DealerEmail = c.Dealer.User.Email,
                    RenterFullName = c.Renter!.FirstName + " " + c.Renter.LastName,
                    RenterEmail = c.Renter.Email
                }).ToListAsync();

            return allRents;
        }
    }
}