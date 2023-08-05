﻿namespace CarParts.Services.Data
{
    using CarParts.Data;
    using CarParts.Data.Models;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Web.ViewModels.Dealer;
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
                ImageUrl = p.ImageUrl,
                Owner = p.Dealer.User.Email,
                PurchaserEmail = p.Purchaser.Email ?? null
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

        public async Task AddPartAsync(AddPartViewModel addPartViewModel, int dealerId)
        {
            var part = new Part
            {
                Name = addPartViewModel.Name,
                Description = addPartViewModel.Description,
                Price = addPartViewModel.Price,
                CategoryId = addPartViewModel.CategoryId,
                ImageUrl = addPartViewModel.ImageUrl,
                DealerId = dealerId,
                PurchaserId = null
            };

            await _dbContext.Parts.AddAsync(part);
            await _dbContext.SaveChangesAsync();
        }

        public Task<DetailsPartViewModel?> GetDetailsPartViewModelAsync(int partId)
        {
            return _dbContext.Parts
                .Where(p => p.PartId == partId)
                .Select(p => new DetailsPartViewModel
                {
                    Id = p.PartId,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Category = p.Category.Name,
                    ImageUrl = p.ImageUrl,
                    Owner = p.Dealer.User.Email,
                    PurchaserEmail = p.Purchaser.Email ?? null,
                    DetailsDealerViewModel = new DetailsDealerViewModel
                    {
                        FullName = p.Dealer.User.FirstName + " " + p.Dealer.User.LastName,
                        Address = p.Dealer.Address,
                        Email = p.Dealer.User.Email
                    }
                })
                .FirstOrDefaultAsync();
        }

        public async Task<Part?> GetPartByIdAsync(int partId)
        {
            return await _dbContext.Parts
                .Include(p => p.Dealer)
                .FirstOrDefaultAsync(p => p.PartId == partId);
        }

        public async Task<EditPartViewModel?> GetEditPartViewModelAsync(int partId)
        {
            var categories = await _dbContext.PartCategories
                .Select(c => new PartCategoryViewModel
                {
                    Id = c.CategoryId,
                    Name = c.Name
                }).ToListAsync();

            var editCarViewModel = await _dbContext.Parts
                .Where(p => p.PartId == partId)
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

        public async Task EditPartAsync(int partId, EditPartViewModel editPartViewModel)
        {
            var part = _dbContext.Parts
                .FirstOrDefault(p => p.PartId == partId);

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

        public async Task DeletePartAsync(int partId)
        {
            var partToDelete = await _dbContext
                .Parts
                .FirstOrDefaultAsync(p => p.PartId == partId);

            if (partToDelete != null)
            {
                _dbContext.Parts.Remove(partToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsByIdAsync(int partId)
        {
            return await _dbContext
                .Parts
                .AnyAsync(p => p.PartId == partId);
        }

        public async Task<bool> IsUserOwnerOfPartByIdAsync(int partId, string userId)
        {
            return await _dbContext
                .Parts
                .AnyAsync(p => p.PartId == partId && p.Dealer.UserId == userId);
        }

        public async Task<ICollection<PartViewModel>> GetMyPartsAsync(string userId)
        {
            return await _dbContext
                .Parts
                .Where(p => p.Dealer.UserId == userId)
                .Select(p => new PartViewModel
                {
                    Id = p.PartId,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    CategoryName = p.Category.Name,
                    Owner = p.Dealer.User.Email,
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
                    Owner = p.Dealer.User.Email,
                    ImageUrl = p.ImageUrl
                }).ToListAsync();
        }

        public async Task<bool> IsPartInMyFavoritesAsync(int partId, string userId)
        {
            return await _dbContext
                .UsersFavoriteParts
                .AnyAsync(ufc => ufc.PartId == partId && ufc.UserId == userId);
        }

        public async Task AddPartToMyFavoritePartsAsync(int partId, string userId)
        {
            var userFavoritePart = new UserFavoritePart
            {
                PartId = partId,
                UserId = userId
            };

            await _dbContext.UsersFavoriteParts.AddAsync(userFavoritePart);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemovePartFromMyFavoritePartsAsync(int partId, string userId)
        {
            var part = await _dbContext
                .UsersFavoriteParts
                .FirstOrDefaultAsync(ufp => ufp.PartId == partId && ufp.UserId == userId);

            _dbContext.UsersFavoriteParts.Remove(part!);
            await _dbContext.SaveChangesAsync();
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
                    Owner = p.Dealer.User.Email,
                    ImageUrl = p.ImageUrl
                }).ToListAsync();

            return parts;
        }

        public async Task<bool> IsPurchasedAsync(int partId)
        {
            var car = await _dbContext
                .Parts
                .FirstAsync(p => p.PartId == partId);

            return !string.IsNullOrEmpty(car.PurchaserId);
        }

        public async Task<bool> IsAlreadyPurchasedByUserIdAsync(int partId, string userId)
        {
            var part = await _dbContext.Parts
                .FirstAsync(p => p.PartId == partId);

            return part.PurchaserId == userId;
        }

        public async Task PurchasePartAsync(PurchasePartViewModel purchasePartViewModel, string userId)
        {
            var part = await _dbContext
                .Parts
                .FirstAsync(p => p.PartId == purchasePartViewModel.PartId);

            part.PurchaserId = userId;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<PurchasePartViewModel?> GetPurchasePartViewModelAsync(int partId)
        {
            var purchasePartViewModel = await _dbContext.Parts
                .Where(p => p.PartId == partId)
                .Select(p => new PurchasePartViewModel
                {
                    PartId = p.PartId,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    PurchaserName = p.Purchaser.FirstName + " " + p.Purchaser.LastName
                }).FirstOrDefaultAsync();

            return purchasePartViewModel;
        }

        public async Task<ICollection<PurchasePartViewModel>> GetMyPurchasedPartsAsync(string userId)
        {
            var parts = await _dbContext.Parts
                .Where(p => p.PurchaserId == userId && p.PurchaserId != null) //TODO: nujna prowerka?
                .Select(p => new PurchasePartViewModel
                {
                    PartId = p.PartId,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    PurchaserName = p.Purchaser.FirstName + " " + p.Purchaser.LastName
                }).ToListAsync();

            return parts;
        }

        public async Task<double> TotalMoneyToReturnForRefundAsync(int partId)
        {
            var part = await _dbContext.Parts
                .FirstAsync(p => p.PartId == partId);

            return part.Price;
        }

        public async Task RefundPartAsync(int partId)
        {
            var part = await _dbContext.Parts
                .FirstAsync(p => p.PartId == partId);

            part.PurchaserId = null;

            await _dbContext.SaveChangesAsync();
        }
    }
}