namespace CarParts.Services.Data
{
    using CarParts.Data;
    using CarParts.Data.Models;
    using CarParts.Web.ViewModels.Car;
    using Interfaces;
    using Mapping;
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
            //Select(p => new PartViewModel
            //{
            //    Id = p.PartId,
            //    Name = p.Name,
            //    Description = p.Description,
            //    Price = p.Price,
            //    CategoryName = p.Category.Name,
            //    ImageUrl = p.ImageUrl,
            //    OwnerEmail = p.Dealer.User.Email,
            //    PurchaserEmail = p.Purchaser.Email ?? null
            //})

            var parts = await _dbContext.Parts.To<PartViewModel>().ToListAsync();
            return parts;
        }

        public async Task<AddPartViewModel> GetAddPartViewModelAsync()
        {
            var categories = await _dbContext.PartCategories
                .To<PartCategoryViewModel>().ToListAsync();

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
                .To<PartCategoryViewModel>().ToListAsync();

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
                .To<PartViewModel>().ToListAsync();
        }

        public async Task<ICollection<PartViewModel>> GetMyFavoritePartsAsync(string userId)
        {
            return await _dbContext
                .Parts
                .Where(p => p.UserFavoriteParts.Any(ufp => ufp.UserId == userId))
                .To<PartViewModel>().ToListAsync();
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
            string category, string priceSort, int? fromPrice, int? toPrice, bool showOnlyAvailable)
        {
            var partsQuery = _dbContext.Parts.AsQueryable();

            if (!string.IsNullOrEmpty(category))
            {
                partsQuery = partsQuery.Where(c => c.Category.Name == category);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                partsQuery = partsQuery.Where(c =>
                    c.Name.Contains(searchTerm) ||
                    c.Description.Contains(searchTerm)
                );
            }

            if (fromPrice != null)
            {
                partsQuery = partsQuery.Where(c => c.Price >= fromPrice);
            }

            if (toPrice != null)
            {
                partsQuery = partsQuery.Where(c => c.Price <= toPrice);
            }

            if (priceSort == "asc")
            {
                partsQuery = partsQuery.OrderBy(c => c.Price);
            }
            else if (priceSort == "desc")
            {
                partsQuery = partsQuery.OrderByDescending(c => c.Price);
            }

            if (showOnlyAvailable)
            {
                partsQuery = partsQuery.Where(p => string.IsNullOrEmpty(p.PurchaserId));
            }

            var parts = await partsQuery
                .To<PartViewModel>().ToListAsync();

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
                .To<PurchasePartViewModel>().FirstOrDefaultAsync();

            return purchasePartViewModel;
        }

        public async Task<ICollection<PurchasePartViewModel>> GetMyPurchasedPartsAsync(string userId)
        {
            var parts = await _dbContext.Parts
                .Where(p => p.PurchaserId == userId && p.PurchaserId != null)
                .To<PurchasePartViewModel>().ToListAsync();

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

        public async Task<ICollection<PartViewModel>> GetHomePagePartsAsync()
        {
            var parts = new List<PartViewModel>();

            var firstPart = await _dbContext.Parts.To<PartViewModel>()
                .FirstOrDefaultAsync(x => x.Name.Contains("BMW S85"));
            var secondPart = await _dbContext.Parts.To<PartViewModel>()
                .FirstOrDefaultAsync(x => x.Name.Contains("Audi S-line Brakes"));
            var thirdPart = await _dbContext.Parts.To<PartViewModel>()
                .FirstOrDefaultAsync(x => x.Name.Contains("Side Mirror C-Class"));

            parts.Add(firstPart);
            parts.Add(secondPart);
            parts.Add(thirdPart);

            return parts;
        }

    }
}