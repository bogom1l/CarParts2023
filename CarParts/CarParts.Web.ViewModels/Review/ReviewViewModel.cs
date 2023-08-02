namespace CarParts.Web.ViewModels.Review
{
    public class ReviewViewModel
    {
        public string Content { get; set; } = null!;
        public double Rating { get; set; }
        public DateTime DatePosted { get; set; }

        public string UserId { get; set; } = null!;
        public string Username { get; set; } = null!;

        public int CarId { get; set; }
    }
}