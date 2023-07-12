namespace CarParts2023.ViewModels.Car
{
    using System.ComponentModel.DataAnnotations;
    using static CarParts2023.GlobalConstants.GlobalConstants.Car;

    public class AddCarViewModel
    {
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
