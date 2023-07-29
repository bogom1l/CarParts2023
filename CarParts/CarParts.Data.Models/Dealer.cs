namespace CarParts.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Dealer
    {
        [Key] public int Id { get; set; }

        [Required] public string PhoneNumber { get; set; } = null!;

        [ForeignKey(nameof(User))] public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;

        public List<Car> OwnedCars { get; set; } = new();
    }
}