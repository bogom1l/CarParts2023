using System.ComponentModel.DataAnnotations;
using static CarParts.Common.GlobalConstants.Part;
using static CarParts.Common.GlobalConstants.PartProperties;


namespace CarParts.Web.ViewModels.Part
{
    public class PartViewModel
    {
        public int Id { get; set; }

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
        [StringLength(CategoryNameMaxLength, 
            MinimumLength = CategoryNameMinLength,
            ErrorMessage = "Category name can be between 2 and 50 characters.")]
        public string CategoryName { get; set; } = null!;


        [Required]
        public string Owner { get; set; } = null!;


        public string ImageUrl { get; set; } = null!;

    }
}

