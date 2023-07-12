namespace CarParts.ViewModels.Category
{
    using System.ComponentModel.DataAnnotations;
    using static CarParts.GlobalConstants.GlobalConstants.Category;

    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(CategoryNameMaxLength,
            MinimumLength = CategoryNameMinLength,
            ErrorMessage = "Category name can be between 2 and 50 characters.")]
        public string Name { get; set; } = null!;
    }
}
