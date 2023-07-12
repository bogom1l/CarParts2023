using CarParts.Data;
using CarParts.Data.Models;
using CarParts.ViewModels.Category;
using CarParts.ViewModels.Part;
using Microsoft.EntityFrameworkCore;

namespace CarParts.Services
{
    public class PartService : IPartService
    {
        private readonly ApplicationDbContext _dbContext;

        public PartService(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<ICollection<PartViewModel>> GetAllPartsAsync()
        {
            return await this._dbContext.Parts.Select(p => new PartViewModel
            {
                Id = p.PartId,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                CategoryName = p.Category.Name
            }).ToListAsync();
        }

        public async Task<AddPartViewModel> GetAddPartViewModelAsync()
        {
            List<CategoryViewModel> categories = await this._dbContext
                .PartCategories
                .Select(c => new CategoryViewModel
                {
                    Id = c.CategoryId,
                    Name = c.Name
                }).ToListAsync();

            return new AddPartViewModel
            {
                Categories = categories
            };
        }

        public async Task AddPartAsync(AddPartViewModel addPartViewModel, string userId)
        {
            Part part = new Part
            {
                Name = addPartViewModel.Name,
                Description = addPartViewModel.Description,
                Price = addPartViewModel.Price,
                CategoryId = addPartViewModel.CategoryId,
                UserId = userId
            };

            await this._dbContext.Parts.AddAsync(part);
            await this._dbContext.SaveChangesAsync();
        }
    }
}
