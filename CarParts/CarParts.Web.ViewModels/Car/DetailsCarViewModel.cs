namespace CarParts.Web.ViewModels.Car
{
    public class DetailsCarViewModel
    {
        public int CarId { get; set; }

        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public int Year { get; set; }

        public string Description { get; set; } = null!;

        public double Price { get; set; }

        public string Color { get; set; } = null!;

        public double EngineSize { get; set; }

        public string FuelType { get; set; } = null!;

        public string Transmission { get; set; } = null!;

        public string Category { get; set; } = null!;

        public double Weight { get; set; }

        public double TopSpeed { get; set; }

        public double Acceleration { get; set; }

        public double Horsepower { get; set; }

        public double Torque { get; set; }

        public double FuelConsumption { get; set; }

        public string ImageUrl { get; set; } = null!;

        public double RentPrice { get; set; }
    }
}