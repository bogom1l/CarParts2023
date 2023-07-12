using CarParts.ViewModels.Category;
using System.ComponentModel.DataAnnotations;
using static CarParts.GlobalConstants.GlobalConstants.Part;

namespace CarParts.ViewModels.Part
{
    public class AddPartViewModel
    {
        [Required]
        [StringLength(PartNameMaxLength, 
            MinimumLength = PartNameMinLength, 
            ErrorMessage = "Name can be between 1 and 50 characters.")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(PartDescriptionMaxLength,
        MinimumLength = PartDescriptionMinLength,
        ErrorMessage = "Description can be between 2 and 300 characters.")]
        public string Description { get; set; } = null!;

        [Required]
        [Range(PartPriceMinValue,
            PartPriceMaxValue,
            ErrorMessage = "Price can be between 0.01 and 10 000.")]
        public double Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public ICollection<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
