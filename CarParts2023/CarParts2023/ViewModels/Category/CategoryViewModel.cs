namespace CarParts2023.ViewModels.Category
{
    using System.ComponentModel.DataAnnotations;

    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; } = null!;
    }
}
