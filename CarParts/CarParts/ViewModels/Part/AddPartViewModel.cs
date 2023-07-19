using System.ComponentModel.DataAnnotations;
using CarParts.ViewModels.Part.PartProperties;
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
        ErrorMessage = "Description can be between 2 and 1500 characters.")]
        public string Description { get; set; } = null!;

        [Required]
        [Range(PartPriceMinValue,
            PartPriceMaxValue,
            ErrorMessage = "Price can be between 0.01 and 100 000.")]
        public double Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public ICollection<PartCategoryViewModel> Categories { get; set; } = new List<PartCategoryViewModel>();


        
        public string ImageUrl { get; set; } = null!;
    }
}
