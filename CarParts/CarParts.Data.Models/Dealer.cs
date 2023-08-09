namespace CarParts.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Common.GlobalConstants.Dealer;

    public class Dealer
    {
        [Key] public int Id { get; set; }

        [Required]
        [MaxLength(DealerAddressMaxLength)]
        public string Address { get; set; } = null!;

        [ForeignKey(nameof(User))] public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;
    }
}