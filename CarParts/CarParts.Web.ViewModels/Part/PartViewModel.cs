namespace CarParts.Web.ViewModels.Part
{
    using AutoMapper;
    using Data.Models;
    using Services.Mapping;

    public class PartViewModel : IMapFrom<Part>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public double Price { get; set; }

        public string CategoryName { get; set; } = null!;

        public string OwnerEmail { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string PurchaserEmail { get; set; } = null!;

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<Part, PartViewModel>()
                .ForMember(d => d.OwnerEmail,
                    opt => opt.MapFrom(s => s.Dealer.User.Email))
                .ForMember(d => d.Id,
                    opt => opt.MapFrom(s => s.PartId));
        }
    }
}