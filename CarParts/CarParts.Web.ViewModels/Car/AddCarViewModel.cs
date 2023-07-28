using System.ComponentModel.DataAnnotations;
using CarParts.Common;
using CarParts.Web.ViewModels.Car.CarProperties;

namespace CarParts.Web.ViewModels.Car
{
    using static GlobalConstants.Car;

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
            ErrorMessage = "Engine size can be between 100 and 9000.")]
        public double EngineSize { get; set; }

        [Required]
        //TODO: Validation?
        public int FuelTypeId { get; set; }

        public ICollection<CarFuelTypeViewModel> FuelTypes { get; set; } = new List<CarFuelTypeViewModel>();

        [Required]
        //TODO: Validation?
        public int TransmissionId { get; set; }  

        public ICollection<CarTransmissionViewModel> Transmissions { get; set; } = new List<CarTransmissionViewModel>();

        [Required]
        //TODO: Validation?
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
            ErrorMessage = "Top speed can be between 60 and 350.")]
        public double TopSpeed { get; set; }

        [Required]
        [Range(CarAccelerationMinValue,
            CarAccelerationMaxValue,
            ErrorMessage = "Acceleration can be between 1 and 20.")]  
        public double Acceleration { get; set; } //seconds

        [Required]
        [Range(CarHorsepowerMinValue,
            CarHorsepowerMaxValue,
            ErrorMessage = "Horsepower can be between 20 and 2000.")]
        public double Horsepower { get; set; }

        [Required]
        [Range(CarTorqueMinValue,
            CarTorqueMaxValue,
            ErrorMessage = "Torque can be between 50 and 2000.")]
        public double Torque { get; set; }

        [Required]
        [Range(CarFuelConsumptionMinValue,
            CarFuelConsumptionMaxValue,
            ErrorMessage = "Fuel consumption can be between 2 and 50.")]
        public double FuelConsumption { get; set; }
        
        
        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public double RentPrice { get; set; }

    }
}