namespace CarParts.Services.Data.Interfaces
{
    using Web.ViewModels.Rent;

    public interface IRentService
    {
        public Task<ICollection<RentInfoViewModel>> GetAllRentsAsync();
    }
}