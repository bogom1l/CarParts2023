namespace CarParts.Web.ViewModels.Car
{
    public class RentCarViewModel
    {
        public int Id { get; set; }

        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public int Year { get; set; }

        public string Description { get; set; } = null!;

        public double Price { get; set; }

        public string Color { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public double RentPrice { get; set; }

        public DateTime? RentalStartDate { get; set; }

        public DateTime? RentalEndDate { get; set; }

        public string? RenterName { get; set; }
    }
}