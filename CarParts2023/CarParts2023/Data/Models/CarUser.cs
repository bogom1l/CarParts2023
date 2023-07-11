namespace CarParts2023.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class CarUser
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;


        [ForeignKey(nameof(Car))]
        
        public int CarId { get; set; }
        public Car Car { get; set; } = null!;
    }
}
