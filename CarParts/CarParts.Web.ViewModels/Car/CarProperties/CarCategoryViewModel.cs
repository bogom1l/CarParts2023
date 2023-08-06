namespace CarParts.Web.ViewModels.Car.CarProperties
{
    using System.ComponentModel.DataAnnotations;
    using static Common.GlobalConstants.Car;

    public class CarCategoryViewModel
    {
        [Required] public int Id { get; set; }

        [Required] 
        [StringLength(CarCategoryMaxLength,
            MinimumLength = CarCategoryMinLength)]
        public string Name { get; set; } = null!;
    }
}