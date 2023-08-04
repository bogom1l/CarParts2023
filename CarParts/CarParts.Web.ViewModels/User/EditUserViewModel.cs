namespace CarParts.Web.ViewModels.User
{
    using System.ComponentModel.DataAnnotations;
    using static Common.GlobalConstants.User;
    public class EditUserViewModel
    {
        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        //public string PhoneNumber { get; set; } = null!;

        //TODO:
        [Required]
        [Range(BalanceMinValue,
            1_000_000,
            ErrorMessage = "Balance can be between 0 and 1 000 000 euro.")]
        public double Balance { get; set; }
    }
}
