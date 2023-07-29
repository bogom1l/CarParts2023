namespace CarParts.Web.ViewModels.Dealer
{
    using System.ComponentModel.DataAnnotations;
    using static Common.GlobalConstants.User;

    public class BecomeDealerFormModel
    {
        [Required]
        [StringLength(PhoneNumberMaxLength, 
            MinimumLength = PhoneNumberMinLength,
            ErrorMessage = "Please enter a valid phone number.")]
        [Phone]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; } = null!;
    }
}