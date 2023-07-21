using System.ComponentModel.DataAnnotations;
using CarParts.Common;
using CarParts.Web.ViewModels.Part.PartProperties;

namespace CarParts.Web.ViewModels.Part
{
    using static GlobalConstants.Part;

    public class EditPartViewModel
    {
        [Required]
        [StringLength(PartNameMaxLength,
            MinimumLength = PartNameMinLength,
            ErrorMessage = "Part name can be between 1 and 50 characters.")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(PartDescriptionMaxLength,
            MinimumLength = PartDescriptionMinLength,
            ErrorMessage = "Part description can be between 2 and 300 characters.")]
        public string Description { get; set; } = null!;

        [Required]
        [Range(PartPriceMinValue, 
            PartPriceMaxValue,
            ErrorMessage = "Part price can be between 0.01 and 10 000")]
        public double Price { get; set; }


        [Required]
        public int CategoryId { get; set; }
        public ICollection<PartCategoryViewModel> Categories { get; set; } = new List<PartCategoryViewModel>();


        
        public string ImageUrl { get; set; } = null!;
    }
}
