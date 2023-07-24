using CarParts.Common;

namespace CarParts.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static GlobalConstants.CarProperties;

    public class CarTransmission
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TransmissionMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
