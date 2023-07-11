using System.ComponentModel.DataAnnotations;

namespace CarParts2023.Data.Models
{
    public class PartCategory
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        
    }
}

/*
 PartCategory: Represents the categories of car parts.

CategoryID (Primary Key): A unique identifier for each part category.
Name: The name or description of the category (e.g., Engine, Suspension, Brakes).
    */