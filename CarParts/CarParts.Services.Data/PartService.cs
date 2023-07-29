namespace CarParts.Services.Data
{
    using CarParts.Data;
    using CarParts.Data.Models;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Web.ViewModels.Part;
    using Web.ViewModels.Part.PartProperties;

    public class PartService : IPartService
    {
        private readonly ApplicationDbContext _dbContext;

        public PartService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<PartViewModel>> GetAllPartsAsync()
        {
            return await _dbContext.Parts.Select(p => new PartViewModel
            {
                Id = p.PartId,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                CategoryName = p.Category.Name,
                Owner = p.User.UserName,
                ImageUrl = p.ImageUrl
            }).ToListAsync();
        }

        public async Task<AddPartViewModel> GetAddPartViewModelAsync()
        {
            var categories = await _dbContext
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
            var part = new Part
            {
                Name = addPartViewModel.Name,
                Description = addPartViewModel.Description,
                Price = addPartViewModel.Price,
                CategoryId = addPartViewModel.CategoryId,
                UserId = userId,
                ImageUrl = addPartViewModel.ImageUrl
            };

            await _dbContext.Parts.AddAsync(part);
            await _dbContext.SaveChangesAsync();
        }

        public Task<DetailsPartViewModel?> GetPartDetailsAsync(int id)
        {
            return _dbContext.Parts
                .Where(p => p.PartId == id)
                .Select(p => new DetailsPartViewModel
                {
                    Id = p.PartId,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Category = p.Category.Name,
                    ImageUrl = p.ImageUrl
                })
                .FirstOrDefaultAsync();
        }

        public async Task<Part?> GetPartByIdAsync(int id)
        {
            return await _dbContext.Parts
                .FirstOrDefaultAsync(p => p.PartId == id);
        }

        public async Task<EditPartViewModel?> GetEditPartViewModelAsync(int id, string userId)
        {
            var categories = await _dbContext.PartCategories
                .Select(c => new PartCategoryViewModel
                {
                    Id = c.CategoryId,
                    Name = c.Name
                }).ToListAsync();

            var editCarViewModel = await _dbContext.Parts
                .Where(p => p.PartId == id)
                .Select(p => new EditPartViewModel
                {
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    CategoryId = p.CategoryId,
                    Categories = categories,
                    ImageUrl = p.ImageUrl
                }).FirstOrDefaultAsync();

            return editCarViewModel;
        }

        public async Task EditPartAsync(int id, EditPartViewModel editPartViewModel)
        {
            var part = _dbContext.Parts
                .FirstOrDefault(p => p.PartId == id);

            if (part != null)
            {
                part.Name = editPartViewModel.Name;
                part.Description = editPartViewModel.Description;
                part.Price = editPartViewModel.Price;
                part.CategoryId = editPartViewModel.CategoryId;
                part.ImageUrl = editPartViewModel.ImageUrl;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeletePartAsync(int id, string userId)
        {
            var partToDelete = await _dbContext
                .Parts
                .FirstOrDefaultAsync(p => p.PartId == id && p.UserId == userId);

            if (partToDelete != null)
            {
                _dbContext.Parts.Remove(partToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<ICollection<PartViewModel>> GetMyPartsAsync(string userId)
        {
            return await _dbContext
                .Parts
                .Where(p => p.UserId == userId)
                .Select(p => new PartViewModel
                {
                    Id = p.PartId,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    CategoryName = p.Category.Name,
                    Owner = p.User.UserName,
                    ImageUrl = p.ImageUrl
                }).ToListAsync();
        }

        public async Task<ICollection<PartViewModel>> GetMyFavoritePartsAsync(string userId)
        {
            return await _dbContext
                .Parts
                .Where(p => p.UserFavoriteParts.Any(ufp => ufp.UserId == userId))
                .Select(p => new PartViewModel
                {
                    Id = p.PartId,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    CategoryName = p.Category.Name,
                    Owner = p.User.UserName,
                    ImageUrl = p.ImageUrl
                }).ToListAsync();
        }

        public async Task<bool> AddPartToMyFavoritePartsAsync(int partId, string userId)
        {
            var isPartAlreadyInMyFavoriteParts = await _dbContext
                .UsersFavoriteParts
                .AnyAsync(ufp => ufp.PartId == partId && ufp.UserId == userId);

            if (isPartAlreadyInMyFavoriteParts)
            {
                return false;
            }

            var userFavoritePart = new UserFavoritePart
            {
                PartId = partId,
                UserId = userId
            };

            await _dbContext.UsersFavoriteParts.AddAsync(userFavoritePart);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RemovePartFromMyFavoritePartsAsync(int partId, string userId)
        {
            var part = await _dbContext
                .UsersFavoriteParts
                .FirstOrDefaultAsync(ufp => ufp.PartId == partId && ufp.UserId == userId);

            if (part == null)
            {
                return false; //doesnt exist (for some reason..) TODO:
            }

            _dbContext.UsersFavoriteParts.Remove(part);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<ICollection<PartViewModel>> SearchPartsAsync(string searchTerm,
            string category, string priceSort, int? fromPrice, int? toPrice)
        {
            var partsQuery = _dbContext.Parts.AsQueryable();

            // Filter by category
            if (!string.IsNullOrEmpty(category))
            {
                partsQuery = partsQuery.Where(c => c.Category.Name == category);
            }

            // Search by custom text in part's name/description
            if (!string.IsNullOrEmpty(searchTerm))
            {
                partsQuery = partsQuery.Where(c =>
                    c.Name.Contains(searchTerm) ||
                    c.Description.Contains(searchTerm)
                );
            }

            // Filter by price range
            if (fromPrice != null)
            {
                partsQuery = partsQuery.Where(c => c.Price >= fromPrice);
            }

            if (toPrice != null)
            {
                partsQuery = partsQuery.Where(c => c.Price <= toPrice);
            }

            // Sort by price ascending/descending
            if (priceSort == "asc")
            {
                partsQuery = partsQuery.OrderBy(c => c.Price);
            }
            else if (priceSort == "desc")
            {
                partsQuery = partsQuery.OrderByDescending(c => c.Price);
            }

            var parts = await partsQuery
                .Select(p => new PartViewModel
                {
                    Id = p.PartId,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    CategoryName = p.Category.Name,
                    Owner = p.User.UserName,
                    ImageUrl = p.ImageUrl
                }).ToListAsync();

            return parts;
        }
    }
}