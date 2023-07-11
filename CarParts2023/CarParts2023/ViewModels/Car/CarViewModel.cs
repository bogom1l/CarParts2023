namespace CarParts2023.ViewModels.Car
{
    using System.ComponentModel.DataAnnotations;

    public class CarViewModel
    {
        public int CarId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Make { get; set; } = null!;

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Model { get; set; } = null!;

        [Required]
        [Range(1900, 2024)]
        public int Year { get; set; }

    }
}
