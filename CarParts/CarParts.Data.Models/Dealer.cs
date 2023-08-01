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


        //TODO: prosto da dobavq oshte nqkwo property, za da se razlichava ot normalnata rolq
        //to veche se razlichava, po tva che ima address, ama vse pak da dobavq oshte neshtichko
    }
}