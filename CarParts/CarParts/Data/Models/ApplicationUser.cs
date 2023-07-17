using Microsoft.AspNetCore.Identity;

namespace CarParts.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Part> Parts { get; set; } = new List<Part>();

        public ICollection<Car> Cars { get; set; } = new List<Car>();

        //public string Name { get; set; } = null!; //TODO:?

    }
}
