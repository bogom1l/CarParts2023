﻿namespace CarParts.Web.ViewModels.Car.CarProperties
{
    using System.ComponentModel.DataAnnotations;

    public class CarCategoryViewModel
    {
        [Required] public int Id { get; set; }

        [Required] public string Name { get; set; } = null!;
    }
}