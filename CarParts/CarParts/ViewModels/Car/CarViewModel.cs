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

        [Required]
        public string Description { get; set; } = null!;


        [Required]
        public double Price { get; set; }

        [Required]
        [MaxLength(CarColorMaxLength)]
        public string Color { get; set; } = null!;

        [Required]
        public double EngineSize { get; set; }

        [Required]
        [MaxLength(CarFuelTypeMaxLength)]
        public string FuelType { get; set; } = null!; 

        [Required]
        [MaxLength(CarTransmissionMaxLength)]
        public string Transmission { get; set; } = null!; 

        [Required]
        [MaxLength(CarCategoryMaxLength)]
        public string Category { get; set; } = null!; 

        [Required]
        public double Weight { get; set; }

        [Required]
        public double TopSpeed { get; set; }

        [Required]
        public double Acceleration { get; set; }

        [Required]
        public double Horsepower { get; set; }

        [Required]
        public double Torque { get; set; }

        [Required]
        public double FuelConsumption { get; set; }

        [Required] //?
        public string Owner { get; set; } = null!;


        
        [Required]
        public string ImageUrl { get; set; } = null!;

    }
}
