namespace CarParts.Web.ViewModels.Dealer
{
    using System.ComponentModel.DataAnnotations;
    using static Common.GlobalConstants.Dealer;

    public class EditDealerViewModel
    {
        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;
        
        [StringLength(DealerAddressMaxLength,
            MinimumLength = DealerAddressMinLength,
            ErrorMessage = "Please enter a valid address.")]
        public string Address { get; set; } = null!;

        public string UserId { get; set; } = null!;
    }
}