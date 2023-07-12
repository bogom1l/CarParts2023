using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CarParts2023.GlobalConstants.GlobalConstants.Car;

namespace CarParts2023.Data.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }

        [Required] 
        [MaxLength(CarMakeMaxLength)]
        public string Make { get; set; } = null!;

        [Required]
        [MaxLength(CarModelMaxLength)]
        public string Model { get; set; } = null!;

        [Required]
        public int Year { get; set; }

        public ICollection<Part> Parts { get; set; } = new List<Part>();

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        
        [Required]
        public ApplicationUser User { get; set; } = null!;

    }
}

