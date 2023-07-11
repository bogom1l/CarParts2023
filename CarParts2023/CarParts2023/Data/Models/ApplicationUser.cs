using Microsoft.AspNetCore.Identity;

namespace CarParts2023.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Part> Parts { get; set; } = new List<Part>();

        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
