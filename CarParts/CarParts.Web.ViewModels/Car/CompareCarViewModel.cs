namespace CarParts.Web.ViewModels.Car
{
    using AutoMapper;
    using Data.Models;
    using Services.Mapping;

    public class CompareCarViewModel : IMapFrom<Car>, IHaveCustomMappings
    {
        public int CarId { get; set; }

        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public int Year { get; set; }

        public string Description { get; set; } = null!;

        public double Price { get; set; }

        public string Color { get; set; } = null!;

        public double EngineSize { get; set; }

        public string FuelTypeName { get; set; } = null!;

        public string TransmissionName { get; set; } = null!;

        public string CategoryName { get; set; } = null!;

        public double Weight { get; set; }

        public double TopSpeed { get; set; }

        public double Acceleration { get; set; }

        public double Horsepower { get; set; }

        public double Torque { get; set; }

        public double FuelConsumption { get; set; }

        public string OwnerEmail { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public double RentPrice { get; set; }


        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<Car, CompareCarViewModel>()
                .ForMember(d => d.OwnerEmail,
                    opt => opt.MapFrom(s => s.Dealer.User.Email));
        }
    }
}