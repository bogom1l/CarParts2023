﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using static CarParts.GlobalConstants.GlobalConstants.Car;

namespace CarParts.Data.Models
{
    public class Car
    {
        [Key] public int CarId { get; set; }

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

        [Required] public IdentityUser User { get; set; } = null!; // changed from ApplicationUser to IdentityUser


        [Required] 
        [MaxLength(CarDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required] 
        public double Price { get; set; }

        [Required]
        [MaxLength(CarColorMaxLength)]
        public string Color { get; set; } = null!;

        [Required]
        public double EngineSize { get; set; }


        

        [Required]
        [ForeignKey(nameof(FuelType))]
        public int FuelTypeId { get; set; }

        public FuelType FuelType { get; set; } = null!;


        [Required]
        [ForeignKey(nameof(Transmission))]
        public int TransmissionId { get; set; }

        public Transmission Transmission { get; set; } = null!;


        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;





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


        public string ImageUrl { get; set; } = null!;


    }
}

