namespace CarParts.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public List<Car> RentedCars { get; set; } = new();

        public double Balance { get; set; }
    }
}