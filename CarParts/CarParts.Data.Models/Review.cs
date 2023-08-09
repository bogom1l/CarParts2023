namespace CarParts.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Common.GlobalConstants.Review;

    public class Review
    {
        [Required]
        [MaxLength(ReviewContentMaxLength)]
        public string Content { get; set; } = null!;

        public double Rating { get; set; }

        public DateTime DatePosted { get; set; }

        [ForeignKey(nameof(User))] public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;

        [ForeignKey(nameof(Car))] public int CarId { get; set; }
        public Car Car { get; set; } = null!;
    }
}