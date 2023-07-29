namespace CarParts.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.GlobalConstants.Car;

    public class CarFuelType
    {
        [Key] public int Id { get; set; }

        [Required]
        [MaxLength(CarFuelTypeMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}