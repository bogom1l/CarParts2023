namespace CarParts2023.ViewModels.Description
{
    using Data.Models;

    public class DescriptionViewModel
    {
        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public int Year { get; set; }

        //public ICollection<Part> Parts { get; set; } = new List<Part>();

        public string Wheels { get; set; } = null!;

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

        public double Emission { get; set; }

        public string SafetyFeatures { get; set; } = null!;
    }
}
