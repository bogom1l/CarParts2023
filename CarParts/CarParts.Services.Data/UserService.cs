namespace CarParts.Services.Data
{
    using CarParts.Data;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Web.ViewModels.User;

    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<double> GetUserBalanceById(string userId)
        {
            var user = await _dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return 0;
            }

            return user.Balance;
        }

        public async Task AddMoney(string userId) //adds 100 euro
        {
            var user = await _dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new ArgumentException("User with this id does not exist!");
            }

            user.Balance += 100;

            await _dbContext.SaveChangesAsync();
        }

        public async Task AddCustomAmountMoney(string userId, double amount)
        {
            var user = await _dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new ArgumentException("User with this id does not exist!");
            }

            user.Balance += amount;

            await _dbContext.SaveChangesAsync();
        }


        public async Task RemoveMoney(string userId, double moneyToRemove)
        {
            var user = await _dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new ArgumentException("User with this id does not exist!");
            }

            user.Balance -= moneyToRemove;

            await _dbContext.SaveChangesAsync();
        }

        public async Task ResetMoney(string userId)
        {
            var user = await _dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new ArgumentException("User with this id does not exist!");
            }

            user.Balance = 0;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<string> GetUserFullNameById(string userId)
        {
            var user = await _dbContext.Users.FindAsync(userId);

            if (string.IsNullOrEmpty(user.FirstName)
                || string.IsNullOrEmpty(user.LastName))
            {
                return null;
            }

            return user.FirstName + " " + user.LastName;
        }

        public async Task<ICollection<UserViewModel>> GetAllUsersAsync()
        {
            var allUsers = new List<UserViewModel>();

            var dealers = await _dbContext
                .Dealers
                .Include(d => d.User)
                .Select(d => new UserViewModel
                {
                    Email = d.User.Email,
                    FullName = d.User.FirstName + " " + d.User.LastName,
                    Address = d.Address
                })
                .ToListAsync();

            allUsers.AddRange(dealers);

            var users = await _dbContext
                .Users
                .Where(u => !_dbContext.Dealers.Any(d => d.UserId == u.Id))
                .Select(u => new UserViewModel
                {
                    Email = u.Email,
                    FullName = u.FirstName + " " + u.LastName,
                    Address = string.Empty
                })
                .ToListAsync();

            allUsers.AddRange(users);

            return allUsers;
        }

        public async Task<bool> IsUserDealerOfCar(string userId, int carId)
        {
            var dealer = await _dbContext
                .Dealers
                .FirstOrDefaultAsync(d => d.UserId == userId);

            return await _dbContext.Cars.AnyAsync(c => c.CarId == carId && c.DealerId == dealer!.Id);
        }

        public async Task<bool> IsUserDealer(string userId)
        {
            return await _dbContext
                .Dealers
                .AnyAsync(d => d.UserId == userId);
        }

        public async Task DeleteAllReviewsForCar(int id)
        {
            var reviews = await _dbContext
                .Reviews
                .Where(r => r.CarId == id)
                .ToListAsync();

            _dbContext.Reviews.RemoveRange(reviews);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAllReviews()
        {
            var reviews = await _dbContext.Reviews.ToListAsync();

            _dbContext.Reviews.RemoveRange(reviews);
            await _dbContext.SaveChangesAsync();
        }
    }
}