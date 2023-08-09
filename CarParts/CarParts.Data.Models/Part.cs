namespace CarParts.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Common.GlobalConstants.Part;

    public class Part
    {
        [Key] public int PartId { get; set; }

        [Required]
        [MaxLength(PartNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(PartDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required] public double Price { get; set; }

        public string ImageUrl { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public PartCategory Category { get; set; } = null!;

        public string? PurchaserId { get; set; }
        public ApplicationUser? Purchaser { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Dealer))]
        public int DealerId { get; set; }
        [Required] public Dealer Dealer { get; set; } = null!;

        public ICollection<UserFavoritePart> UserFavoriteParts { get; set; } = new List<UserFavoritePart>();
    }
}