namespace CarParts.Web.ViewModels.Part.PartProperties
{
    using System.ComponentModel.DataAnnotations;
    using static Common.GlobalConstants.Part;

    public class PartCategoryViewModel
    {
        [Required] public int Id { get; set; }

        [Required] 
        [StringLength(PartNameMaxLength,
            MinimumLength = PartNameMinLength)]
        public string Name { get; set; } = null!;
    }
}