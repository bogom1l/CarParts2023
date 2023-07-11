using System.ComponentModel.DataAnnotations;

namespace CarParts2023.Data.Models
{
    public class PartCategory
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        public ICollection<Part> Parts { get; set; } = new List<Part>();
    }
}
