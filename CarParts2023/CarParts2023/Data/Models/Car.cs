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
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        
        [Required]
        public ApplicationUser User { get; set; } = null!;


        [ForeignKey(nameof(Description))]
        public int DescriptionId { get; set; }

        [Required] 
        public Description Description { get; set; } = null!;

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

