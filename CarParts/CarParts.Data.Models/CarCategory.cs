﻿namespace CarParts.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.GlobalConstants.Car;

    public class CarCategory
    {
        [Key] public int Id { get; set; }

        [Required]
        [MaxLength(CarCategoryMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}