using System.ComponentModel.DataAnnotations;

namespace CarParts.ViewModels.Car.CarProperties
{
    public class FuelTypeViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
    }
}
