using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarParts2023.Data.Models
{
    public class Part
    {
        //write the code from the comment below

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        [ForeignKey(nameof(CategoryId))]
        public int CarId { get; set; }


        [Required]
        public PartCategory CategoryId { get; set; } = null!;


        [Required]
        public Car Car { get; set; } = null!;



    }
}

/*
 Part: Represents a car part.

PartID (Primary Key): A unique identifier for each car part.
Name: The name or description of the part.
Description: Additional details or specifications about the part.
Price: The price of the part.
CategoryID (Foreign Key referencing PartCategory): Indicates the category to which the part belongs.
CarID (Foreign Key referencing Car): Specifies the car model for which the part is compatible.
 */
