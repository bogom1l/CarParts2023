namespace CarParts.Web.ViewModels.User
{
    using System.ComponentModel.DataAnnotations;
    using static Common.GlobalConstants.User;

    public class EditUserViewModel
    {
        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        [StringLength(FirstNameMaxLength,
            MinimumLength = FirstNameMinLength)]
        public string FirstName { get; set; } = null!;

        [StringLength(LastNameMaxLength,
            MinimumLength = LastNameMinLength)]
        public string LastName { get; set; } = null!;

        [Phone]
        [StringLength(PhoneNumberMaxLength,
            MinimumLength = PhoneNumberMinLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [Range(BalanceMinValue,
            BalanceMaxValue,
            ErrorMessage = "Balance can be between 0 and 10 000 000 euro.")]
        public double Balance { get; set; }
    }
}