namespace CarParts.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.GlobalConstants.Car;

    public class CarTransmission
    {
        [Key] public int Id { get; set; }

        [Required]
        [MaxLength(CarTransmissionMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}