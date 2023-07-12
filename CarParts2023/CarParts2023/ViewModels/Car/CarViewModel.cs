using CarParts2023.ViewModels.Description;

namespace CarParts2023.ViewModels.Car
{
    public class CarViewModel
    {
        public int CarId { get; set; }

        public DescriptionViewModel Description { get; set; } = null!;
    }
}
