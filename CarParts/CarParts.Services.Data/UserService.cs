using CarParts.Data;
using CarParts.Data.Models;
using CarParts.Services.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarParts.Services.Data
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        public async Task<string> GetUserFullNameByEmail(string email)
        {
            ApplicationUser? user = await this._dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return string.Empty;
                //throw new ArgumentException("User with this email does not exist!");
            }

            return $"{user.FirstName} {user.LastName}";
        }


        public async Task<double> GetBalance(string userId)
        {
            var user = await this._dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return 0;
            }

            return user.Balance;
        }

        public async Task AddMoney(string userId)
        {
            var user = await this._dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new ArgumentException("User with this id does not exist!");
            }

            user.Balance += 100;

            await this._dbContext.SaveChangesAsync();
        }


        public async Task<string> GetUserIdByEmail(string email)
        {
            ApplicationUser? user = await this._dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return string.Empty;
                //throw new ArgumentException("User with this email does not exist!");
            }

            return user.Id;
        }

    }


}