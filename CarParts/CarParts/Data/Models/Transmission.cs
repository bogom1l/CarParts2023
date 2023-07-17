namespace CarParts.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static CarParts.GlobalConstants.GlobalConstants.CarProperties;

    public class Transmission
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TransmissionMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
