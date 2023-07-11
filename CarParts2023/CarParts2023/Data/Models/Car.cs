using System.ComponentModel.DataAnnotations;

namespace CarParts2023.Data.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }

        [Required] 
        public string Make { get; set; } = null!;

        [Required]
        public string Model { get; set; } = null!;

        public int Year { get; set; }

    }
}


/*
     Car: Represents a car model.
        CarID (Primary Key): A unique identifier for each car model.
        Make: The make or manufacturer of the car (e.g., Ford, Toyota, BMW).
        Model: The specific model of the car (e.g., Mustang, Camry, 3 Series).
        Year: The year in which the car model was released (e.g., 2021, 2018).
*/