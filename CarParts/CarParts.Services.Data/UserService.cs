namespace CarParts.Services.Data
{
    using CarParts.Data;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> GetUserFullNameByEmail(string email)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return string.Empty;
                //? TODO: throw new ArgumentException("User with this email does not exist!");
            }

            return $"{user.FirstName} {user.LastName}";
        }

        public async Task<double> GetBalance(string userId)
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

        public async Task<string> GetUserIdByEmail(string email)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return string.Empty;
                //? TODO: throw new ArgumentException("User with this email does not exist!");
            }

            return user.Id;
        }
    }
}