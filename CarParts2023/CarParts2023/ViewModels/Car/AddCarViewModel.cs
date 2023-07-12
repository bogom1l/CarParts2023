namespace CarParts2023.ViewModels.Car
{
    using CarParts2023.ViewModels.Description;
    using System.ComponentModel.DataAnnotations;
    using static CarParts2023.GlobalConstants.GlobalConstants.Car;

    public class AddCarViewModel
    {
        public DescriptionViewModel Description { get; set; } = null!;

    }
}
