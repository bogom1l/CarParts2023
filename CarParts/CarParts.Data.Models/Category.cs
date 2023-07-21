using System.ComponentModel.DataAnnotations;
using static CarParts.Common.GlobalConstants.CarProperties;


namespace CarParts.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
