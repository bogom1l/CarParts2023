namespace CarParts.Web.ViewModels.Dealer
{
    using System.ComponentModel.DataAnnotations;
    using static Common.GlobalConstants.Dealer;

    public class BecomeDealerFormModel
    {
        [Required]
        [StringLength(DealerAddressMaxLength,
            MinimumLength = DealerAddressMinLength,
            ErrorMessage = "Please enter a valid address.")]
        [Display(Name = "Address")]
        public string Address { get; set; } = null!;
    }
}