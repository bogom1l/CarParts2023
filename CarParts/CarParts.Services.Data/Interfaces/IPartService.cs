namespace CarParts.Services.Data.Interfaces
{
    using CarParts.Data.Models;
    using Web.ViewModels.Part;

    public interface IPartService
    {
        public Task RefundPartAsync(int partId);

        public Task AddPartAsync(AddPartViewModel addPartViewModel, int dealerId);

        public Task EditPartAsync(int partId, EditPartViewModel editPartViewModel);

        public Task DeletePartAsync(int partId);

        public Task AddPartToMyFavoritePartsAsync(int partId, string userId);

        public Task RemovePartFromMyFavoritePartsAsync(int partId, string userId);

        public Task PurchasePartAsync(PurchasePartViewModel purchasePartViewModel, string userId);

        public Task<Part?> GetPartByIdAsync(int partId);

        public Task<AddPartViewModel> GetAddPartViewModelAsync();

        public Task<DetailsPartViewModel?> GetDetailsPartViewModelAsync(int partId);

        public Task<EditPartViewModel?> GetEditPartViewModelAsync(int partId);

        public Task<PurchasePartViewModel?> GetPurchasePartViewModelAsync(int partId);

        public Task<ICollection<PartViewModel>> GetMyPartsAsync(string userId);

        public Task<ICollection<PartViewModel>> GetMyFavoritePartsAsync(string userId);

        public Task<ICollection<PartViewModel>> GetAllPartsAsync();

        public Task<ICollection<PartViewModel>> GetHomePagePartsAsync();

        public Task<ICollection<PurchasePartViewModel>> GetMyPurchasedPartsAsync(string userId);

        public Task<ICollection<PartViewModel>> SearchPartsAsync(string searchTerm, string category,
            string priceSort, int? fromPrice, int? toPrice, bool showOnlyAvailable);

        public Task<bool> IsPartInMyFavoritesAsync(int partId, string userId);

        public Task<bool> IsPurchasedAsync(int partId);

        public Task<bool> IsAlreadyPurchasedByUserIdAsync(int partId, string userId);

        public Task<bool> ExistsByIdAsync(int partId);

        public Task<bool> IsUserOwnerOfPartByIdAsync(int partId, string userId);

        public Task<double> TotalMoneyToReturnForRefundAsync(int partId);
    }
}