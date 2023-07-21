﻿using System.ComponentModel.DataAnnotations;

namespace CarParts.Web.ViewModels.Car.CarProperties
{
    public class CarTransmissionViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
    }
}
