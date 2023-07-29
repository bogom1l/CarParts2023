namespace CarParts.Web.ViewModels.Part
{
    using System.ComponentModel.DataAnnotations;
    using PartProperties;
    using static Common.GlobalConstants.Part;

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
            ErrorMessage = "Description can be between 1 and 3500 characters.")]
        public string Description { get; set; } = null!;

        [Required]
        [Range(PartPriceMinValue,
            PartPriceMaxValue,
            ErrorMessage = "Price can be between 1 and 300 000 euro.")]
        public double Price { get; set; }

        [Required] public int CategoryId { get; set; }

        public ICollection<PartCategoryViewModel> Categories { get; set; } = new List<PartCategoryViewModel>();

        [Required] [Url] public string ImageUrl { get; set; } = null!;
    }
}