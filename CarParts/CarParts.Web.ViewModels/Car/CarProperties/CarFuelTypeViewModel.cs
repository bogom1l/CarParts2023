﻿namespace CarParts.Web.ViewModels.Car.CarProperties
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Services.Mapping;
    using static Common.GlobalConstants.Car;

    public class CarFuelTypeViewModel : IMapFrom<CarFuelType>
    {
        [Required] public int Id { get; set; }

        [Required]
        [StringLength(CarFuelTypeMaxLength,
            MinimumLength = CarFuelTypeMinLength)]
        public string Name { get; set; } = null!;
    }
}