namespace CarParts.Services.Data.Interfaces
{
    public interface IStatisticsService
    {
        public Task<int> GetTotalCars();

        public Task<int> GetTotalParts();

        public Task<int> GetTotalUsers();

        public Task<int> GetTotalDealers();

        public Task<int> GetTotalRents();
    }
}