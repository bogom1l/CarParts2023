namespace CarParts.Web.ViewModels.Part.PartProperties
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Data.Models;
    using Services.Mapping;
    using static Common.GlobalConstants.Part;

    public class PartCategoryViewModel : IMapFrom<PartCategory>, IHaveCustomMappings
    {
        [Required] public int Id { get; set; }

        [Required] 
        [StringLength(PartNameMaxLength,
            MinimumLength = PartNameMinLength)]
        public string Name { get; set; } = null!;

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<PartCategory, PartCategoryViewModel>()
                .ForMember(d => d.Id,
                    opt => opt.MapFrom(s => s.CategoryId));
        }
    }
}