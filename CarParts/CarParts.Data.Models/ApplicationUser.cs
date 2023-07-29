namespace CarParts.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public List<Car> RentedCars { get; set; } = new();

        public double Balance { get; set; }
    }
}