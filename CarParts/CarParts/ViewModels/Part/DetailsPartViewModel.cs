namespace CarParts.ViewModels.Part
{
    public class DetailsPartViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public double Price { get; set; }

        public string Category { get; set; } = null!;

    }
}
