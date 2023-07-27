namespace CarParts.Services.Data.Interfaces
{
    public interface IUserService
    {
        Task<string> GetUserFullNameByEmail(string email);
    }
}
