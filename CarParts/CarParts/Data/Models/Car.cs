using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CarParts.GlobalConstants.GlobalConstants.Car;

namespace CarParts.Data.Models
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


        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        
        [Required]
        public ApplicationUser User { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

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


    }
}


/*
 
CarId
Make
Model
Year
Parts
UserId, User

price
color
Engine size: The size of the engine in cubic centimeters (cc) or liters (L).
Fuel type: - gasoline, diesel, or electric.
Transmission: The type of transmission the car has, such as manual, automatic
Category: The category of the car, such as sedan, coupe, hatchback, SUV, or pickup truck.
Weight: The weight of the car in kilograms.
Top speed: The maximum speed the car can achieve in kilometers per hour.
Acceleration: The time it takes for the car to reach a certain speed, such as 0-60 mph or 0-100 km/h.
horsepower 
torque 
fuel consumption
emission
safety features (e.g. airbags, backup camera, lane departure warning)

Wheel Wheel 
 
*/

