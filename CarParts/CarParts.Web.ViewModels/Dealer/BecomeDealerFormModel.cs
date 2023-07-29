namespace CarParts.Web.ViewModels.Dealer
{
    using System.ComponentModel.DataAnnotations;
    using static Common.GlobalConstants.PhoneNumber;

    public class BecomeDealerFormModel
    {
        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        [Phone]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; } = null!;
    }
}