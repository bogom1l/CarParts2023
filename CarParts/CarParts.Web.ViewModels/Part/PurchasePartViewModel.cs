namespace CarParts.Web.ViewModels.Part
{
    using AutoMapper;
    using Data.Models;
    using Services.Mapping;

    public class PurchasePartViewModel : IMapFrom<Part>, IHaveCustomMappings
    {
        public int PartId { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string CategoryName { get; set; } = null!;

        public double Price { get; set; }

        public string ImageUrl { get; set; } = null!;

        public string? PurchaserName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<Part, PurchasePartViewModel>()
                .ForMember(d => d.PurchaserName,
                    opt =>
                        opt.MapFrom(s => s.Purchaser.FirstName + " " + s.Purchaser.LastName));
        }
    }
}