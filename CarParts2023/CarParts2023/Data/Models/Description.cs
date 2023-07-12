using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarParts2023.Data.Models
{
    using static CarParts2023.GlobalConstants.GlobalConstants.Car;
    public class Description
    {
        //add primary key so each car can have only one description
        [Key]
        public int DescriptionId { get; set; }

        [ForeignKey(nameof(Car))]
        public int CarId { get; set; }

        public Car Car { get; set; } = null!;


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
        [MaxLength(CarWheelsMaxLength)]
        public string Wheels { get; set; } = null!;

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

        [Required]
        public double Emission { get; set; }

        [Required] 
        public string SafetyFeatures { get; set; } = null!;


    }
}


