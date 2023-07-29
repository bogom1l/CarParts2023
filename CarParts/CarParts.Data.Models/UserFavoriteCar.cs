namespace CarParts.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserFavoriteCar
    {
        [ForeignKey(nameof(User))] public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;

        [ForeignKey(nameof(Car))] public int CarId { get; set; }
        public Car Car { get; set; } = null!;
    }
}