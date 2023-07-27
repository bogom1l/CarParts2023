using CarParts.Data;
using CarParts.Data.Models;
using CarParts.Services.Data.Interfaces;
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
    }
}