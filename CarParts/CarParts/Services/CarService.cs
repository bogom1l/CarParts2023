using CarParts.Data;
using CarParts.ViewModels.Car;
using Microsoft.EntityFrameworkCore;

namespace CarParts.Services
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

        public async Task<AddCarViewModel> GetAddCarViewModelAsync()
        {
            return new AddCarViewModel();
        }
    }
}
