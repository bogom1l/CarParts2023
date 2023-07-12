using System.ComponentModel.DataAnnotations;
using static CarParts2023.GlobalConstants.GlobalConstants.Part;

namespace CarParts2023.Data.Models
{
    public class PartCategory
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(PartNameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Part> Parts { get; set; } = new List<Part>();
    }
}
