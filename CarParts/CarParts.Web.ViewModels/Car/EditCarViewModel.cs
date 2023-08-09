namespace CarParts.Web.ViewModels.Car
{
    using System.ComponentModel.DataAnnotations;
    using CarProperties;
    using static Common.GlobalConstants.Car;

    public class EditCarViewModel
    {
        [Required]
        [StringLength(CarMakeMaxLength,
            MinimumLength = CarMakeMinLength,
            ErrorMessage = "Make can be between 1 and 50 characters.")]
        public string Make { get; set; } = null!;

        [Required]
        [StringLength(CarModelMaxLength,
            MinimumLength = CarModelMinLength,
            ErrorMessage = "Model can be between 1 and 50 characters.")]
        public string Model { get; set; } = null!;

        [Required]
        [Range(CarYearMinValue,
            CarYearMaxValue,
            ErrorMessage = "Year can be between 1900 and 2024.")]
        public int Year { get; set; }

        [Required]
        [StringLength(CarDescriptionMaxLength,
            MinimumLength = CarDescriptionMinLength,
            ErrorMessage = "Description can be between 1 and 3500.")]
        public string Description { get; set; } = null!;


        [Required]
        [Range(CarPriceMinValue,
            CarPriceMaxValue,
            ErrorMessage = "Price can be between 0 and 999 999.")]
        public double Price { get; set; }

        [Required]
        [StringLength(CarColorMaxLength,
            MinimumLength = CarColorMinLength,
            ErrorMessage = "Color can be between 1 and 50 characters.")]
        public string Color { get; set; } = null!;

        [Required]
        [Range(CarEngineSizeMinValue,
            CarEngineSizeMaxValue,
            ErrorMessage = "Engine size can be between 10 and 9000.")]
        public double EngineSize { get; set; }


        [Required(ErrorMessage = "Please select a fuel type.")]
        public int FuelTypeId { get; set; }

        public ICollection<CarFuelTypeViewModel> FuelTypes { get; set; } = new List<CarFuelTypeViewModel>();


        [Required(ErrorMessage = "Please select a transmission type.")]
        public int TransmissionId { get; set; }

        public ICollection<CarTransmissionViewModel> Transmissions { get; set; } = new List<CarTransmissionViewModel>();


        [Required(ErrorMessage = "Please select a category type.")]
        public int CategoryId { get; set; }

        public ICollection<CarCategoryViewModel> Categories { get; set; } = new List<CarCategoryViewModel>();

        [Required]
        [Range(CarWeightMinValue,
            CarWeightMaxValue,
            ErrorMessage = "Weight can be between 100 and 9000.")]

        public double Weight { get; set; }

        [Required]
        [Range(CarTopSpeedMinValue,
            CarTopSpeedMaxValue,
            ErrorMessage = "Top speed can be between 10 and 350.")]
        public double TopSpeed { get; set; }

        [Required]
        [Range(CarAccelerationMinValue,
            CarAccelerationMaxValue,
            ErrorMessage = "Acceleration can be between 0 and 30 seconds.")]
        public double Acceleration { get; set; }

        [Required]
        [Range(CarHorsepowerMinValue,
            CarHorsepowerMaxValue,
            ErrorMessage = "Horsepower can be between 1 and 3000.")]
        public double Horsepower { get; set; }

        [Required]
        [Range(CarTorqueMinValue,
            CarTorqueMaxValue,
            ErrorMessage = "Torque can be between 1 and 3000.")]
        public double Torque { get; set; }

        [Required]
        [Range(CarFuelConsumptionMinValue,
            CarFuelConsumptionMaxValue,
            ErrorMessage = "Fuel consumption can be between 0 and 50.")]
        public double FuelConsumption { get; set; }

        [Required] [Url] public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(CarRentPriceMinValue,
            CarRentPriceMaxValue,
            ErrorMessage = "Car rent price can be between 20 and 30 000 eur.")]
        public double RentPrice { get; set; }
    }
}