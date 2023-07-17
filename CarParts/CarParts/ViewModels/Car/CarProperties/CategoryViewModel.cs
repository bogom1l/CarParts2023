using System.ComponentModel.DataAnnotations;

namespace CarParts.ViewModels.Car.CarProperties
{
    public class CategoryViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
    }
}
