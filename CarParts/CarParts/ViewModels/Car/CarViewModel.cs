namespace CarParts.ViewModels.Car
{
    using System.ComponentModel.DataAnnotations;
    using static CarParts.GlobalConstants.GlobalConstants.Car;

    public class CarViewModel
    {
        public int CarId { get; set; }

        [Required]
        [StringLength(CarMakeMaxLength, 
            MinimumLength = CarMakeMinLength,
            ErrorMessage = "Make can be between 2 and 50 characters.")]
        public string Make { get; set; } = null!;

        [Required]
        [StringLength(CarModelMaxLength, 
            MinimumLength = CarModelMinLength,
            ErrorMessage = "Model can be between 2 and 50 characters.")]
        public string Model { get; set; } = null!;

        [Required]
        [Range(CarYearMinValue,
            CarYearMaxValue,
            ErrorMessage = "Year can be between 1900 and 2024.")]
        public int Year { get; set; }

    }
}
