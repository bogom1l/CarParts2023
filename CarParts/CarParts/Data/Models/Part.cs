using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CarParts.GlobalConstants.GlobalConstants.Part;


namespace CarParts.Data.Models
{
    public class Part
    {
        [Key]
        public int PartId { get; set; }

        [Required]
        [MaxLength(PartNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(PartDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public double Price { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public PartCategory Category { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(User))]
        public string? UserId { get; set; } = null!; //TODO: remove nullability
        
        [Required]
        public ApplicationUser User { get; set; } = null!;
    }
}

