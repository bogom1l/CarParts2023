using System.ComponentModel.DataAnnotations;

namespace CarParts2023.ViewModels.Part
{
    public class PartViewModel
    {

        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(2)]
        [MaxLength(300)]
        public string Description { get; set; } = null!;

        [Required]
        [Range(0, 10_000)]
        public double Price { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string CategoryName { get; set; } = null!;

    }
}

