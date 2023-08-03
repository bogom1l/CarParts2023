namespace CarParts.Web.ViewModels.Review
{
    using System.ComponentModel.DataAnnotations;

    public class ReviewViewModel
    {
        public string Content { get; set; } = null!;

        [Range(0.0, 10.0, ErrorMessage = "Please enter a rating between 0 and 10.")]
        public double Rating { get; set; }

        public DateTime DatePosted { get; set; }

        public string UserId { get; set; } = null!;
        public string Username { get; set; } = null!;

        public int CarId { get; set; }
    }
}