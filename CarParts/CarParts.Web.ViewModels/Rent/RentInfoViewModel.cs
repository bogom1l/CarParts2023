namespace CarParts.Web.ViewModels.Rent
{
    public class RentInfoViewModel
    {
        public string CarMake { get; set; } = null!;
        public string CarModel { get; set; } = null!;

        public string CarImageUrl { get; set; } = null!;

        public string DealerFullName { get; set; } = null!;

        public string DealerEmail { get; set; } = null!;

        public string RenterFullName { get; set; } = null!;

        public string RenterEmail { get; set; } = null!;
    }
}