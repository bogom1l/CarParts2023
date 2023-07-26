using Microsoft.AspNetCore.Identity;

namespace CarParts.Data.Models
{
    using System.Collections.Generic;

    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public List<Car> RentedCars { get; set; } = new List<Car>();

        public double Balance { get; set; } //Money
    }
}