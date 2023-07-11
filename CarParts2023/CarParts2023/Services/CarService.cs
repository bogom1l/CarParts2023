using CarParts2023.Data;
using CarParts2023.ViewModels.Car;
using Microsoft.EntityFrameworkCore;

namespace CarParts2023.Services
{
    public class CarService : ICarService
    {

        private readonly ApplicationDbContext _dbContext;

        public CarService(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        public async Task<ICollection<CarViewModel>> GetAllCarsAsync()
        {
            return await this._dbContext.Cars.Select(c => new CarViewModel
            {
                CarId = c.CarId,
                Make = c.Make,
                Model = c.Model,
                Year = c.Year
            }).ToListAsync();
        }
    }
}
