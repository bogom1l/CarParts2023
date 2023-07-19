using CarParts.Data;
using CarParts.Data.Models;
using CarParts.ViewModels.Part;
using CarParts.ViewModels.Part.PartProperties;
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
                CategoryName = p.Category.Name,
                Owner = p.User.UserName
            }).ToListAsync();
        }

        public async Task<AddPartViewModel> GetAddPartViewModelAsync()
        {
            var categories = await this._dbContext
                .PartCategories
                .Select(c => new PartCategoryViewModel
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

        public Task<DetailsPartViewModel?> GetPartDetailsAsync(int id)
        {
            return this._dbContext.Parts
                .Where(p => p.PartId == id)
                .Select(p => new DetailsPartViewModel
                {
                    Id = p.PartId,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Category = p.Category.Name
                })
                .FirstOrDefaultAsync();
        }

        public async Task<Part?> GetPartByIdAsync(int id)
        {
            return await this._dbContext.Parts
                .FirstOrDefaultAsync(p => p.PartId == id);
        }

        public async Task<EditPartViewModel?> GetEditPartViewModelAsync(int id, string userId)
        {
            var categories = await this._dbContext.PartCategories
                .Select(c => new PartCategoryViewModel
                {
                    Id = c.CategoryId,
                    Name = c.Name
                }).ToListAsync();

            var editCarViewModel = await this._dbContext.Parts
                .Where(p => p.PartId == id)
                .Select(p => new EditPartViewModel
                {
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    CategoryId = p.CategoryId,
                    Categories = categories
                }).FirstOrDefaultAsync();

            return editCarViewModel;
        }

        public async Task EditPartAsync(int id, EditPartViewModel editPartViewModel)
        {
            var part = this._dbContext.Parts
                .FirstOrDefault(p => p.PartId == id);

            if (part != null)
            {
                part.Name = editPartViewModel.Name;
                part.Description = editPartViewModel.Description;
                part.Price = editPartViewModel.Price;
                part.CategoryId = editPartViewModel.CategoryId;

                await this._dbContext.SaveChangesAsync();
            }
        }
    }
}
