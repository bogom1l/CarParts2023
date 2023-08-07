namespace CarParts.Web.ViewModels.Rent
{
    using AutoMapper;
    using Common;
    using Data.Models;
    using Services.Mapping;

    public class RentInfoViewModel : IMapFrom<Car>, IHaveCustomMappings
    {
        public string CarMake { get; set; } = null!;
        public string CarModel { get; set; } = null!;

        public string CarImageUrl { get; set; } = null!;

        public string DealerFullName { get; set; } = null!;

        public string DealerEmail { get; set; } = null!;

        public string RenterFullName { get; set; } = null!;

        public string RenterEmail { get; set; } = null!;
        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<Car, RentInfoViewModel>()
                .ForMember(d => d.CarMake, opt =>
                    opt.MapFrom(s => s.Make))
                .ForMember(d => d.CarModel, opt =>
                    opt.MapFrom(s => s.Model))
                .ForMember(d => d.CarImageUrl, opt =>
                    opt.MapFrom(s => s.ImageUrl))
                .ForMember(d => d.DealerFullName, opt => 
                    opt.MapFrom(s => s.Dealer.User.FirstName + " " + s.Dealer.User.LastName))
                .ForMember(d => d.DealerEmail,
                    opt => opt.MapFrom(s => s.Dealer.User.Email))
                .ForMember(d => d.RenterFullName, opt =>
                    opt.MapFrom(s => s.Renter!.FirstName + " " + s.Renter!.LastName))
                .ForMember(d => d.RenterEmail, opt =>
                    opt.MapFrom(s => s.Renter!.Email));
        }
    }
}