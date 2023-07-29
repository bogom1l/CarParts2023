namespace CarParts.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.GlobalConstants.Part;

    public class PartCategory
    {
        [Key] public int CategoryId { get; set; }

        [Required]
        [MaxLength(PartNameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Part> Parts { get; set; } = new List<Part>();
    }
}