namespace CarParts.Web.ViewModels.Part.PartProperties
{
    using System.ComponentModel.DataAnnotations;

    public class PartCategoryViewModel
    {
        [Required] public int Id { get; set; }

        [Required] public string Name { get; set; } = null!;
    }
}