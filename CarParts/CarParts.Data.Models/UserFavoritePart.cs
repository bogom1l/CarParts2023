namespace CarParts.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserFavoritePart
    {
        [ForeignKey(nameof(User))] public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;

        [ForeignKey(nameof(Part))] public int PartId { get; set; }
        public Part Part { get; set; } = null!;
    }
}